using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using YTuber.Base;
using YTuber.Helpers;
using YTuber.IoC;
using YTuber.Models.Monetization;
using YTuber.Views.Promotion;

namespace YTuber.Services.Monetization
{
    public class PromotionService : ModelBase, ISingleResolvable
    {
        private const string PROMOTION_CONTAINER = "Promotions";

        private Promotion _promotion;
        public Promotion Promotion
        {
            get
            {
                return _promotion;
            }
            set
            {
                _promotion = value;
                RaisePropertyChanged(nameof(Promotion));
            }
        }

        public Json Json { get; set; }
        public LocalSettings LocalSettings { get; set; }
        public Navigation Navigation { get; set; }

        public async Task ShowAsync()
        {
            try
            {
                var client = new HttpClient();
                var response = await client.GetStringAsync("http://bojnansky.com/apps/ytuber/ytuber.json");

                Promotion = Json.FromJson<Promotion>(response);
                ShowIfNever();
            }
            catch { }
        }

        private void ShowIfNever()
        {
            try
            {
                if (!(bool)LocalSettings.GetValue(Promotion.Id, PROMOTION_CONTAINER))
                {
                    throw new Exception();
                }
            }
            catch
            { 
                LocalSettings.SetValue(Promotion.Id, true, PROMOTION_CONTAINER);
                Navigation.Navigate(typeof(PromotionView));
            }          
        }
    }
}
