using UnityEngine;
using GoogleMobileAds.Api;

namespace _Project.Ads
{
    public class AdMod : MonoBehaviour
    {
        private BannerView bannerView;
        
        public void Start()
        {
            RequestBanner();
        }

        private void RequestBanner()
        {
            #if UNITY_ANDROID
                string adUnitId="ca-app-pub-3940256099942544/6300978111";
            #elif UNITY_IPHONE
                string adUnitId="ca-app-pub-3940256099942544/2934735716";
            #else
                string adUnitId="unexpected_platform";
            #endif
            bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Top);
            
            
            AdRequest request = new AdRequest.Builder().Build();
            bannerView.LoadAd(request);
        }
    }
}