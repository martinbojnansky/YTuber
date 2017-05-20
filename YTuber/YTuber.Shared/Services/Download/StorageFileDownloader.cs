using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Networking.BackgroundTransfer;
using Windows.Storage;
using YTuber.Services.Monetization;
using YTuber.Helpers;
using YTuber.Base;
using YTuber.IoC;
using YTuber.Models.Download;

namespace YTuber.Services.Download
{
    public class StorageFileDownloader : ModelBase, ISingleResolvable
    {
        private ObservableCollection<DownloadOperationObject> _downloads = new ObservableCollection<DownloadOperationObject>();
        public ObservableCollection<DownloadOperationObject> Downloads
        {
            get
            {
                return _downloads;
            }
            set
            {
                _downloads = value;
                RaisePropertyChanged(nameof(Downloads));
            }
        }

        public bool IsActive
        {
            get
            {
                return (Downloads != null && Downloads.Count > 0);
            }
        }

        public string ActiveDownloadsString => $"Downloading {Downloads.Count} files";


        public Dialogs Dialogs { get; set; }
        public InterstitialAdService InterstitialAdService { get; set; }

        public async Task DownloadFileAsync(string url, string fileName)
        {
            if (string.IsNullOrEmpty(url) || string.IsNullOrEmpty(fileName)) throw new Exception();

            Uri uri = new Uri(url);

            StorageFile storageFile = await KnownFolders.MusicLibrary.CreateFileAsync(
                fileName, CreationCollisionOption.GenerateUniqueName);

            BackgroundDownloader downloader = new BackgroundDownloader();
            DownloadOperationObject download = new DownloadOperationObject(downloader.CreateDownload(uri, storageFile));

            await HandleDownloadAsync(download, true);
        }

        private async Task HandleDownloadAsync(DownloadOperationObject downloadOperationObject, bool isNewDownload)
        {
            try
            {
                Downloads.Add(downloadOperationObject);
                Progress<DownloadOperation> progressCallback = new Progress<DownloadOperation>(DownloadProgressCallback);

                if (isNewDownload)
                {
                    await downloadOperationObject.DownloadOperation.StartAsync().AsTask(downloadOperationObject.CancellationToken.Token, progressCallback);
                }
                else
                {
                    await downloadOperationObject.DownloadOperation.AttachAsync().AsTask(downloadOperationObject.CancellationToken.Token, progressCallback);
                }

                InterstitialAdService.ShowAd();
            }
            catch (TaskCanceledException) { }
            catch (Exception) { }
            finally
            {
                Downloads.Remove(downloadOperationObject);
            }
        }

        public async Task DiscoverActiveDownloadsAsync()
        {
            Downloads = new ObservableCollection<DownloadOperationObject>();
            Downloads.CollectionChanged += Downloads_CollectionChanged;
            IReadOnlyList<DownloadOperation> downloads = null;

            try { downloads = await BackgroundDownloader.GetCurrentDownloadsAsync(); }
            catch { return; }

            if (downloads.Count > 0)
            {
                var tasks = new List<Task>();

                foreach (DownloadOperation download in downloads)
                {
                    DownloadOperationObject downloadObject = new DownloadOperationObject(download);
                    tasks.Add(HandleDownloadAsync(downloadObject, false));
                }

                await Task.WhenAll(tasks);
            }
        }

        private void Downloads_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            RaisePropertyChanged(nameof(IsActive));
            RaisePropertyChanged(nameof(ActiveDownloadsString));
        }

        private void DownloadProgressCallback(DownloadOperation obj)
        {
            double percent = 100;

            if (obj.Progress.TotalBytesToReceive > 0)
            {
                percent = obj.Progress.BytesReceived * 100 / obj.Progress.TotalBytesToReceive;
            }

            DownloadOperationObject download = Downloads.FirstOrDefault(d => d.DownloadOperation.Guid.Equals(obj.Guid));
            download.Progress = percent;
        }
    }
}
