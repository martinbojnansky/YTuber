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
using YTuber.ViewModels.About;

namespace YTuber.Views.About
{
    public sealed partial class AboutView : NavigationPage
    {
        public AboutViewModel ViewModel = ((App)Application.Current).MVVMLocator.Resolve<AboutViewModel>();

        public AboutView()
        {
            InitializeComponent();
            DataContext = ViewModel;
        }
    }
}
