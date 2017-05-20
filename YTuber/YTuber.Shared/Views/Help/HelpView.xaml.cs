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
using YTuber.ViewModels.Help;

namespace YTuber.Views.Help
{
    public sealed partial class HelpView : NavigationPage
    {
        public HelpViewModel ViewModel = ((App)Application.Current).MVVMLocator.Resolve<HelpViewModel>();

        public HelpView()
        {
            InitializeComponent();
            DataContext = ViewModel;

            ViewModel.FlipView = HelpItemsFlipView;
        }

        private void HelpItemsFlipView_SelectionChanged(object sender, SelectionChangedEventArgs e) => ViewModel.FlipView_SelectionChanged();
    }
}
