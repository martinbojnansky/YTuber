using Microsoft.Advertising.WinRT.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace YTuber.Controls
{
    public sealed partial class AdvertisementBanner : UserControl
    {
#if WINDOWS_APP
        private const string APPLICATION_ID = "d9d49676-631c-4c16-b135-21798551513e";
        private const string SMALL_BANNER_AD_UNIT_ID = "11670951";
        private const string LARGE_BANNER_AD_UNIT_ID = "11670950";
        private const double SMALL_BANNER_WIDTH = 160;
        private const double SMALL_BANNER_HEIGHT = 600;
        private const double LARGE_BANNER_WIDTH = 300;
        private const double LARGE_BANNER_HEIGHT = 600;
        private double _breakpoint = 1368;
#endif
#if WINDOWS_PHONE_APP
        private const string APPLICATION_ID = "6b732470-66b2-4a1c-8234-5caf1d3786da";
        private const string SMALL_BANNER_AD_UNIT_ID = "11670955";
        private const string LARGE_BANNER_AD_UNIT_ID = "11670954";
        private const double SMALL_BANNER_WIDTH = 320;
        private const double SMALL_BANNER_HEIGHT = 50;
        private const double LARGE_BANNER_WIDTH = 480;
        private const double LARGE_BANNER_HEIGHT = 80;
        private double _breakpoint = 320;
#endif

        private AdControl _smallBanner => new AdControl()
        {
            ApplicationId = APPLICATION_ID,
            AdUnitId = SMALL_BANNER_AD_UNIT_ID,
            Width = SMALL_BANNER_WIDTH,
            Height = SMALL_BANNER_HEIGHT,
            IsBackgroundTransparent = true
        };

        private AdControl _largeBanner => new AdControl()
        {
            ApplicationId = APPLICATION_ID,
            AdUnitId = LARGE_BANNER_AD_UNIT_ID,
            Width = LARGE_BANNER_WIDTH,
            Height = LARGE_BANNER_HEIGHT,
            IsBackgroundTransparent = true
        };

        public AdvertisementBanner()
        {
            InitializeComponent();

            ((Frame)Window.Current.Content).SizeChanged += AdvertisementBanner_SizeChanged;
        }

        private void AdvertisementBanner_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if(e.NewSize.Width <= _breakpoint && 
                (Content == null || (Content as AdControl).Width != SMALL_BANNER_WIDTH))
            {
                Content = _smallBanner;
            }
            else if(e.NewSize.Width > _breakpoint &&
                    (Content == null || (Content as AdControl).Width != LARGE_BANNER_WIDTH))
            {
                Content = _largeBanner;
            }
        }
    }
}
