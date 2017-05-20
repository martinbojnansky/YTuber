using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using YTuber.Models.Download;

namespace YTuber.Controls
{
    public sealed partial class DownloadsListView : UserControl
    {
        public bool IsActive
        {
            get { return (bool)GetValue(IsActiveProperty); }
            set { SetValue(IsActiveProperty, value); }
        }

        public static readonly DependencyProperty IsActiveProperty =
            DependencyProperty.Register(nameof(IsActive), typeof(bool), typeof(DownloadsListView), new PropertyMetadata(false));

        public ObservableCollection<DownloadOperationObject> Downloads
        {
            get { return (ObservableCollection<DownloadOperationObject>)GetValue(DownloadsProperty); }
            set { SetValue(DownloadsProperty, value); }
        }

        public static readonly DependencyProperty DownloadsProperty =
            DependencyProperty.Register(nameof(Downloads), typeof(ObservableCollection<DownloadOperationObject>), typeof(DownloadsListView), new PropertyMetadata(0));


        public DownloadsListView()
        {
            InitializeComponent();
        }
    }
}
