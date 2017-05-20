using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using YTuber.Base;
using YTuber.Helpers;
using YTuber.Services.Download;
using YTuber.Services.Help;
using YTuber.Services.Monetization;

namespace YTuber.ViewModels.Main
{
    public class MainViewModel : ViewModelBase
    {
        public Dialogs Dialogs { get; set; }
        public YoutubeDownload YoutubeDownload { get; set; }
        public PromotionService PromotionService { get; set; }
        public HelpService HelpService { get; set; }
        public InAppPurchaseService InAppPurchaseService { get; set; }

        private bool _isPageLoading;
        public bool IsPageLoading
        {
            get
            {
                return _isPageLoading;
            }
            set
            {
                _isPageLoading = value;
                RaisePropertyChanged(nameof(IsPageLoading));
            }
        }

        private bool _canGoBack;
        public bool CanGoBack
        {
            get
            {
                return _canGoBack;
            }
            set
            {
                _canGoBack = value;
                RaisePropertyChanged(nameof(CanGoBack));
            }
        }

        private bool _canGoForward;
        public bool CanGoForward
        {
            get
            {
                return _canGoForward;
            }
            set
            {
                _canGoForward = value;
                RaisePropertyChanged(nameof(CanGoForward));
            }
        }

        private bool _isDownloadsPopupVisible;
        public bool IsDownloadsPopupVisible
        {
            get
            {
                return _isDownloadsPopupVisible;
            }
            set
            {
                _isDownloadsPopupVisible = value;
                RaisePropertyChanged(nameof(IsDownloadsPopupVisible));
                RaisePropertyChanged(nameof(IsLightDismissVisible));
            }
        }

        private bool _isMenuPopupVisible;
        public bool IsMenuPopupVisible
        {
            get
            {
                return _isMenuPopupVisible;
            }
            set
            {
                _isMenuPopupVisible = value;
                RaisePropertyChanged(nameof(IsMenuPopupVisible));
                RaisePropertyChanged(nameof(IsLightDismissVisible));
            }
        }

        public bool IsLightDismissVisible => (IsMenuPopupVisible || IsDownloadsPopupVisible);
        public bool IsAdvertisementFreeAddonEnabled => InAppPurchaseService.IsFeatureEnabled(InAppPurchaseService.ADVERTISEMENT_FREE);

        private ICommand _goBackCommand;
        public ICommand GoBackCommand => _goBackCommand ?? (_goBackCommand = new Command(GoBack));

        private ICommand _goForwardCommand;
        public ICommand GoForwardCommand => _goForwardCommand ?? (_goForwardCommand = new Command(GoForward));

        private ICommand _refreshCommand;
        public ICommand RefreshCommand => _refreshCommand ?? (_refreshCommand = new Command(Refresh));

        private ICommand _downloadCommand;
        public ICommand DownloadCommand => _downloadCommand ?? (_downloadCommand = new Command(Download));

        public MainViewModel()
        { }

        public async Task OnNavigatedTo()
        {
            await YoutubeDownload.DiscoverActiveDownloadsAsync();
        }

        public async Task Loaded()
        {
            if(!HelpService.ShowHelp())
            {
                await PromotionService.ShowAsync();
            }
        }

        #region Webview

        public void GoBack()
        {
            if (YoutubeDownload.YoutubeWebView.CanGoBack)
            {
                YoutubeDownload.YoutubeWebView.GoBack();
            }
        }

        public void GoForward()
        {
            if (YoutubeDownload.YoutubeWebView.CanGoForward)
            {
                YoutubeDownload.YoutubeWebView.GoForward();
            }
        }

        public void Refresh()
        {
            YoutubeDownload.YoutubeWebView.Refresh();
        }

        public void YoutubeWebView_NavigationStarting()
        {
            IsPageLoading = true;
        }

        public void YoutubeWebView_NavigationCompleted()
        {
            IsPageLoading = false;
            CanGoBack = YoutubeDownload.YoutubeWebView.CanGoBack;
            CanGoForward = YoutubeDownload.YoutubeWebView.CanGoForward;
        }

        public async void YoutubeWebView_NavigationFailed()
        {
            IsPageLoading = false;
            await Dialogs.ShowError("Can't reach the page. Please check your network connection. ");
        }

        #endregion

        #region Download

        private async void Download()
        {
            await YoutubeDownload.DownloadMp3Async();
        }

        #endregion

        #region Menu

        public void LightDismiss()
        {
            if (IsMenuPopupVisible)
            {
                IsMenuPopupVisible = false;
            }
            else if (IsDownloadsPopupVisible)
            {
                IsDownloadsPopupVisible = false;
            }
        }

        #endregion
    }
}
