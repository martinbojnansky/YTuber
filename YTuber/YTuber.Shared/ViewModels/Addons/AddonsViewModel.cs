using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using YTuber.Base;
using YTuber.Services.Monetization;

namespace YTuber.ViewModels.Addons
{
    public class AddonsViewModel : ViewModelBase
    {
        public InAppPurchaseService InAppPurchaseService { get; set; }

        public bool IsAdvertisementFreeAddonActive => InAppPurchaseService.IsFeatureEnabled(nameof(InAppPurchaseService.ADVERTISEMENT_FREE));

        private ICommand _buyAdvertisementFreeAddonCommand;
        public ICommand BuyAdvertisementFreeAddonCommand => _buyAdvertisementFreeAddonCommand ?? (_buyAdvertisementFreeAddonCommand = new Command(BuyAdvertisementFreeAddon));

        private async void BuyAdvertisementFreeAddon()
        {
            var result = await InAppPurchaseService.BuyFeatureAsync(InAppPurchaseService.ADVERTISEMENT_FREE);
            RaisePropertyChanged(nameof(IsAdvertisementFreeAddonActive));
        }
    }
}
