using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml.Controls;
using YTuber.Base;
using YTuber.Exceptions;

namespace YTuber.Services.Download
{
    public abstract class YoutubeConverter : StorageFileDownloader
    {
        private const string DEFAULT_STATUS = "Please wait...";
        private bool _cancel;
        private SemaphoreSlim _semaphore = new SemaphoreSlim(1);

        public WebView YoutubeWebView { get; set; }
        public WebView DownloaderWebView { get; set; }

        private bool _isNavigating;
        public bool IsNavigating
        {
            get
            {
                return _isNavigating;
            }
            set
            {
                _isNavigating = value;
                RaisePropertyChanged(nameof(IsNavigating));
            }
        }

        private bool _isConverting;
        public bool IsConverting
        {
            get
            {
                return _isConverting;
            }
            set
            {
                _isConverting = value;
                RaisePropertyChanged(nameof(IsConverting));
            }
        }

        private string _progress;
        public string Progress
        {
            get
            {
                return _progress;
            }
            set
            {
                _progress = value;
                RaisePropertyChanged(nameof(Progress));
            }
        }

        private string _status = DEFAULT_STATUS;
        public string Status
        {
            get
            {
                return _status;
            }
            set
            {
                _status = value;
                RaisePropertyChanged(nameof(Status));
            }
        }

        private ICommand _cancelCommand;
        public ICommand CancelCommand => _cancelCommand ?? (_cancelCommand = new Command(() => { _cancel = true; }));

        public YoutubeConverter()
        { }

        public void SetWebViews(WebView youtubeWebView, WebView downloaderWebView)
        {
            YoutubeWebView = youtubeWebView;

            DownloaderWebView = downloaderWebView;
            DownloaderWebView.NavigationStarting += (s, e) => { UpdateIsNavigatingProperty(true); };
            DownloaderWebView.NavigationCompleted += (s, e) => { UpdateIsNavigatingProperty(false); };
            DownloaderWebView.NavigationFailed += (s, e) => { UpdateIsNavigatingProperty(true); };
        }

        public async Task<string> InvokeScriptAsync(string javascript, WebView webView)
        {
            try
            {
                return await webView.InvokeScriptAsync("eval", new string[] { javascript });
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        private async Task Lock()
        {
            await _semaphore.WaitAsync();
            IsConverting = true;
        }

        private async Task Unlock()
        {
            await NavigateToConverterAsync();
            _semaphore.Release();

            IsConverting = false;
            Status = DEFAULT_STATUS;
            Progress = string.Empty;
        }

        private void UpdateIsNavigatingProperty(bool value)
        {
            IsNavigating = value;
        }

        public string RemoveInvalidFileNameCharacters(string fileName)
        {
            string invalid = new string(Path.GetInvalidFileNameChars()) + new string(Path.GetInvalidPathChars());

            foreach (char c in invalid)
            {
                fileName = fileName.Replace(c.ToString(), string.Empty);
            }

            return fileName;
        }

        public void CheckCancel()
        {
            if (_cancel)
            {
                _cancel = false;
                throw new YoutubeDownloadCancelledException();
            }
        }

        #region Download

        public async Task DownloadMp3Async()
        {
            try
            {
                await Lock();

                await StartConvertingVideoAsync();
                var isSuccessful = await WaitForConversionAsync();

                if (isSuccessful)
                {
                    var downloadUrl = await GetDownloadUrlAsync();
                    var fileName = await GetFileNameAsync();
                    await Unlock();

                    await DownloadFileAsync(downloadUrl, fileName);
                }
                else
                {
                    await Unlock();
                }
            }
            catch(YoutubeDownloadCancelledException)
            {
                await Unlock();
            }
            catch(YoutubeDownloadFreezeException)
            {
                await Unlock();
                await DownloadMp3Async();
            }
            catch
            {
                await Dialogs.ShowError("MP3 file download failed.");
                await Unlock();
            }
        }

        public abstract Task StartConvertingVideoAsync();
        public abstract Task<bool> WaitForConversionAsync();
        public abstract Task<string> GetDownloadUrlAsync();
        public abstract Task<string> GetFileNameAsync();
        public abstract Task NavigateToConverterAsync();
        public abstract Task UpdateStatusAsync();

        #endregion
    }
}
