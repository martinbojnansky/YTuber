using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using YTuber.Exceptions;
using YTuber.Models.Download;

namespace YTuber.Services.Download
{
    public class YoutubeDownload : YoutubeConverter
    {
        private int _freezeCount = 0;

        public override async Task StartConvertingVideoAsync()
        {
            // Get url of youtube video
            string videoUrl = await InvokeScriptAsync("document.location.href;", YoutubeWebView);
            // Wait for navigation
            await WaitForNavigationAsync();
            // Set url to convert video
            await InvokeScriptAsync($"document.querySelector(\"input[name='videoURL']\").value = \"{videoUrl}\";", DownloaderWebView);
            // Start converting video
            await InvokeScriptAsync($"document.querySelector(\"input[name='submitForm']\").click();", DownloaderWebView);
        }

        public async Task WaitForNavigationAsync()
        {
            while(IsNavigating)
            {
                await Task.Delay(100);
            }
        }

        public override async Task<bool> WaitForConversionAsync()
        {
            bool isConverted = false;

            // Wait for navigation
            await WaitForNavigationAsync();

            // Periodically check conversion status
            while (!isConverted)
            {
                await Task.Delay(100);

                // Handle cancellation
                CheckCancel();

                // Check for completition
                var alert = await InvokeScriptAsync("document.querySelector(\"div[role='alert']\").className;", DownloaderWebView);

                if (alert.Contains("alert-success"))
                {
                    isConverted = true;
                }
                // Check for errors
                else if(alert.Contains("alert-danger"))
                {
                    await HandleConversionErrorAsync();
                    return false;
                }
                // Handle conversion freeze
                else
                {
                    await HandleConversionFreeze();
                }

                // Update status
                await UpdateStatusAsync();
            }

            return true;
        }

        public override async Task UpdateStatusAsync()
        {
            Progress = await InvokeScriptAsync("document.querySelector(\"#progress\").innerText;", DownloaderWebView);
            Status = 
                await InvokeScriptAsync("document.querySelector(\"div[role='alert']\").innerText;", DownloaderWebView)
                + " " + Progress;
        }

        private async Task HandleConversionFreeze()
        {
            var progress = await InvokeScriptAsync("document.querySelector(\"#progress\").innerText;", DownloaderWebView);

            if(progress == "0%" || progress == "100%")
            {
                _freezeCount++;
            }
            else
            {
                _freezeCount = 0;
            }

            if (_freezeCount == 50)
            {
                throw new YoutubeDownloadFreezeException();
            }
        }

        private async Task HandleConversionErrorAsync()
        {
            var error = await InvokeScriptAsync("document.querySelector(\"div[role='alert']\").innerText;", DownloaderWebView);
            await Dialogs.ShowError(error);

            return;
        }

        public override async Task<string> GetDownloadUrlAsync()
        {
            return await InvokeScriptAsync("document.querySelector(\"div.completed a\").href;", DownloaderWebView);
        }

        public override async Task<string> GetFileNameAsync()
        {
            var title = await InvokeScriptAsync("document.querySelector(\"div.form-container h1\").innerText;", DownloaderWebView);
            var fileName = RemoveInvalidFileNameCharacters(title + ".mp3");

            return fileName;
        }

        public override async Task NavigateToConverterAsync()
        {
            await InvokeScriptAsync("window.location = 'http://www.youtubemp3.to';", DownloaderWebView);
        }
    }
}