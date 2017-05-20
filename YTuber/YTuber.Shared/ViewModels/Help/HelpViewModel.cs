using System;
using System.Collections.Generic;
using System.Text;
using Windows.UI.Xaml.Controls;
using YTuber.Base;
using System.Windows.Input;

namespace YTuber.ViewModels.Help
{
    public class HelpViewModel : ViewModelBase
    {
        public FlipView FlipView { get; set; }

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

        private ICommand _goBackCommand;
        public ICommand GoBackCommand => _goBackCommand ?? (_goBackCommand = new Command(GoBack));

        private ICommand _goForwardCommand;
        public ICommand GoForwardCommand => _goForwardCommand ?? (_goForwardCommand = new Command(GoForward));

        private void GoBack()
        {
            FlipView.SelectedIndex = FlipView.SelectedIndex - 1;
        }

        private void GoForward()
        {
            FlipView.SelectedIndex = FlipView.SelectedIndex + 1;
        }

        public void FlipView_SelectionChanged()
        {
            if (FlipView == null) return;

            CanGoBack = FlipView.SelectedIndex > 0;

            if(FlipView.SelectedIndex == FlipView.Items.Count - 1)
            {
                Navigation.GoBack();
            }
        }
    }
}
