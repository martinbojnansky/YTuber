using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Windows.System;
using YTuber.Base;
using YTuber.Services.Monetization;

namespace YTuber.ViewModels.Promotion
{
    public class PromotionViewModel : ViewModelBase
    {
        public PromotionService PromotionService { get; set; }

        private ICommand _okCommand;
        public ICommand OkCommand => _okCommand ?? (_okCommand = new Command(Ok));

        private async void Ok()
        {
            if(PromotionService.Promotion != null && !string.IsNullOrWhiteSpace(PromotionService.Promotion.Link))
            {
                await Launcher.LaunchUriAsync(new Uri(PromotionService.Promotion.Link, UriKind.Absolute));
            }

            Navigation.GoBack();
        }
    }
}
