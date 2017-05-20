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
using YTuber.ViewModels.Addons;

namespace YTuber.Views.Addons
{
    public sealed partial class AddonsView : NavigationPage
    {
        public AddonsViewModel ViewModel = ((App)Application.Current).MVVMLocator.Resolve<AddonsViewModel>();

        public AddonsView()
        {
            InitializeComponent();
            DataContext = ViewModel;
        }
    }
}
