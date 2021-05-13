
using UnityEngine;
using GoogleMobileAds.Api;


public class GoogleAdScript : MonoBehaviour
{

    private BannerView bannerView;

    public void Start()
    {
        MobileAds.Initialize(InitStatus => { });
        RequestBanner();
    }

    private void RequestBanner()
    {

        string adUnitId = "ca-app-pub-1177905240975126~2318963778";        
        // string adUnitId = "ca-app-pub-3940256099942544~6300978111";        

        this.bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Bottom);
        
        AdRequest request = new AdRequest.Builder().Build();

        Debug.Log(request);
        this.bannerView.LoadAd(request);
    }

}
