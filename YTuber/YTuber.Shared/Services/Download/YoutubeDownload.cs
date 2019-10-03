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
        public override async Task StartConvertingVideoAsync()
        {
            // Get url of youtube video
            string videoUrl = await InvokeScriptAsync("document.location.href;", YoutubeWebView);
            // Wait for navigation
            await WaitForNavigationAsync();
            // Set url to convert video
            await InvokeScriptAsync($"document.querySelector(\"input[name='video']\").value = \"{videoUrl}\";", DownloaderWebView);
            // Start converting video
            await InvokeScriptAsync($"document.querySelector(\"input[type='submit']\").click();", DownloaderWebView);
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
                var progress = "document.querySelector(\"#progress']\").style[\"display\"]";
                var error = await InvokeScriptAsync("document.querySelector(\"#error']\").innerText;", DownloaderWebView);

                if (progress != "none" || !string.IsNullOrEmpty(error))
                {
                    isConverted = true;
                }
                // Check for errors
                else
                {
                    await HandleConversionErrorAsync();
                    return false;
                }

                // Update status
                await UpdateStatusAsync();
            }

            return true;
        }

        public override async Task UpdateStatusAsync()
        {
            //Progress = await InvokeScriptAsync("document.querySelector(\"#progress\").innerText;", DownloaderWebView);
            Status =
               await InvokeScriptAsync("document.querySelector(\"#progress\").innerText;", DownloaderWebView)
               + " " + Progress;
        }

        private async Task HandleConversionErrorAsync()
        {
            // var error = await InvokeScriptAsync("document.querySelector(\"div[role='alert']\").innerText;", DownloaderWebView);
            await Dialogs.ShowError("We were not able to download this video :(");

            return;
        }

        public override async Task<string> GetDownloadUrlAsync()
        {
            return await InvokeScriptAsync("document.querySelector(\"#buttons a:first-child\").href;", DownloaderWebView);
        }

        public override async Task<string> GetFileNameAsync()
        {
            var title = await InvokeScriptAsync("document.querySelector(\"#title\").innerText;", DownloaderWebView);
            var fileName = RemoveInvalidFileNameCharacters(title + ".mp3");

            return fileName;
        }

        public override async Task NavigateToConverterAsync()
        {
            await InvokeScriptAsync("window.location = 'https://ytmp3.cc/';", DownloaderWebView);
        }
    }
}