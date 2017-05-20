using System;
using System.Collections.Generic;
using System.Text;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace YTuber.Base
{
    public abstract class NavigationPage : Page
    {
        private NavigationManager _navigationManager;

        public NavigationPage()
        {
            _navigationManager = new NavigationManager(this);
            _navigationManager.LoadState += NavigationManager_LoadState;
            _navigationManager.SaveState += NavigationManager_SaveState;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            _navigationManager.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            _navigationManager.OnNavigatedFrom(e);
        }

        private virtual void NavigationManager_LoadState(object sender, LoadStateEventArgs e)
        {
        }

        private virtual void NavigationManager_SaveState(object sender, SaveStateEventArgs e)
        {
        }
    }
}
