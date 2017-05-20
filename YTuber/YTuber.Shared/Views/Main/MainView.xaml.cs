using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using YTuber.Base;
using YTuber.ViewModels.Main;

namespace YTuber.Views.Main
{
    public sealed partial class MainView : NavigationPage
    {
        public MainViewModel ViewModel = ((App)Application.Current).MVVMLocator.Resolve<MainViewModel>();

        public MainView()
        {
            InitializeComponent();
            DataContext = ViewModel;

            ViewModel.YoutubeDownload.SetWebViews(YoutubeWebView, DownloaderWebView);

            Loaded += MainView_Loaded;
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            await ViewModel.OnNavigatedTo();
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
            HaltWebviewNavigations();
        }

        private async void MainView_Loaded(object sender, RoutedEventArgs e) => await ViewModel.Loaded();
        private void YoutubeWebView_NavigationStarting(WebView sender, WebViewNavigationStartingEventArgs args) => ViewModel.YoutubeWebView_NavigationStarting();
        private void YoutubeWebView_NavigationCompleted(WebView sender, WebViewNavigationCompletedEventArgs args) => ViewModel.YoutubeWebView_NavigationCompleted();
        private void YoutubeWebView_NavigationFailed(object sender, WebViewNavigationFailedEventArgs e) => ViewModel.YoutubeWebView_NavigationFailed();
        private void LightDismiss_Tapped(object sender, TappedRoutedEventArgs e) => ViewModel.LightDismiss();
        private void Menu_ItemClick(object sender, ItemClickEventArgs e)
        {
            var navigationLink = (NavigationLink)e.ClickedItem;

            if(navigationLink != null)
            {
                ViewModel.Navigation.Navigate(navigationLink.PageType);
            }
        }
        private void HaltWebviewNavigations()
        {
            YoutubeWebView.Stop();
            DownloaderWebView.Stop();
        }
    }
}
