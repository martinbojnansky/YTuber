using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.Networking.BackgroundTransfer;
using Windows.Storage;
using YTuber.Base;

namespace YTuber.Models.Download
{
    public class DownloadOperationObject : ModelBase
    { 
        private double _progress;
        public double Progress
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

        private ICommand _cancelCommand;
        public ICommand CancelCommand => _cancelCommand ?? (_cancelCommand = new Command(Cancel));

        public DownloadOperation DownloadOperation { get; private set; }
        public CancellationTokenSource CancellationToken { get; set; }

        public DownloadOperationObject(DownloadOperation downloadOperation)
        {
            DownloadOperation = downloadOperation;
            CancellationToken = new CancellationTokenSource();
        }

        public async void Cancel() => await CancelAsync();
        public async Task CancelAsync()
        {
            try
            {
                IStorageFile file = DownloadOperation.ResultFile;
                await file.DeleteAsync();
            }
            catch { }   
            finally
            {
                DisposeCancellationToken();
            }
        }

        private void DisposeCancellationToken()
        {
            CancellationToken.Cancel();
            CancellationToken.Dispose();
        }
    }
}
