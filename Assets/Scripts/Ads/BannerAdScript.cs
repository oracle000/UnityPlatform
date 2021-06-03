
using UnityEngine;
using GoogleMobileAds.Api;

public class BannerAdScript : MonoBehaviour
{
    
    private BannerView bannerView;

    public void Start()
    {
        MobileAds.Initialize(initStatus => { });       
        RequestBanner();
    }

    private void RequestBanner()
    {
        // prod ad ca-app-pub-1177905240975126/2318963778
        // test ad ca-app-pub-3940256099942544/6300978111

#if UNITY_ANDROID
        string adUnitId = "ca-app-pub-1177905240975126/2318963778";
#elif UNITY_IPHONE
            string adUnitId = "ca-app-pub-3940256099942544/2934735716";
#else
            string adUnitId = "unexpected_platform";
#endif


        bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Top);        
        AdRequest request = new AdRequest.Builder().Build();                
        bannerView.LoadAd(request);
    }

}
