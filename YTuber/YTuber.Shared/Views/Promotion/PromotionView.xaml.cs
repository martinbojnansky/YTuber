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
using YTuber.ViewModels.Promotion;

namespace YTuber.Views.Promotion
{
    public sealed partial class PromotionView : NavigationPage
    {
        public PromotionViewModel ViewModel = ((App)Application.Current).MVVMLocator.Resolve<PromotionViewModel>();

        public PromotionView()
        {
            InitializeComponent();
            DataContext = ViewModel;
        }
    }
}
