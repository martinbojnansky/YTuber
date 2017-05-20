using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Store;
using YTuber.IoC;

namespace YTuber.Services.Monetization
{
    public class InAppPurchaseService : IResolvable
    {
        public const string ADVERTISEMENT_FREE = "AdFree";

        private LicenseInformation _licenseInformation;

        public InAppPurchaseService()
        {
#if DEBUG     
            _licenseInformation = CurrentAppSimulator.LicenseInformation;
#else
            _licenseInformation = CurrentApp.LicenseInformation;
#endif
        }

        public bool IsFeatureEnabled(string name) => _licenseInformation.ProductLicenses[name].IsActive;

        public async Task<ProductPurchaseStatus> BuyFeatureAsync(string name)
        {
            if (!_licenseInformation.ProductLicenses[name].IsActive)
            {
                try
                {
#if DEBUG
                    var result = await CurrentAppSimulator.RequestProductPurchaseAsync(name);
#else
                    var result = await CurrentApp.RequestProductPurchaseAsync(name);
#endif
                    return result.Status;
                }
                catch { return ProductPurchaseStatus.NotPurchased; }
            }
            else
            {
                return ProductPurchaseStatus.AlreadyPurchased;
            }
        }
    }
}
