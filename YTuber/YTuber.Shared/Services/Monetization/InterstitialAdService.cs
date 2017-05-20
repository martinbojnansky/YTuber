using Microsoft.Advertising.WinRT.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YTuber.IoC;

namespace YTuber.Services.Monetization
{
    public class InterstitialAdService : ISingleResolvable
    { 
        private InterstitialAd _interstitialAd;

        public InAppPurchaseService InAppPurchaseService { get; set; }

#if WINDOWS_APP
        public string AppId = "d9d49676-631c-4c16-b135-21798551513e";
        public string AdUnitId = "11555391";
#endif
#if WINDOWS_PHONE_APP
        public string AppId = "6b732470-66b2-4a1c-8234-5caf1d3786da";
        public string AdUnitId = "11556891";
#endif

        public InterstitialAdService()
        {
            _interstitialAd = new InterstitialAd();
            _interstitialAd.AdReady += InterstitialAd_AdReady;
            _interstitialAd.ErrorOccurred += InterstitialAd_ErrorOccurred;
            _interstitialAd.Completed += InterstitialAd_Completed;
            _interstitialAd.Cancelled += InterstitialAd_Cancelled;

            // Pre-fetch an advert 30-60 seconds before you it's needed
            RequestAd();
        }

        public void ShowAd()
        {
            if (InAppPurchaseService.IsFeatureEnabled(InAppPurchaseService.ADVERTISEMENT_FREE))
                return;

            if (InterstitialAdState.Ready == _interstitialAd.State)
            {
                _interstitialAd.Show();
                //RequestAd(); Calling request from every event instead is stupid, but it rapidly boosts our income :)
            }
        }

        public void RequestAd()
        {
            _interstitialAd.RequestAd(AdType.Video, AppId, AdUnitId);
        }

        private void InterstitialAd_AdReady(object sender, object e) { }

        private void InterstitialAd_ErrorOccurred(object sender, AdErrorEventArgs e) { RequestAd(); }

        private void InterstitialAd_Completed(object sender, object e) { RequestAd(); }

        private void InterstitialAd_Cancelled(object sender, object e) { RequestAd(); }
    }
}
