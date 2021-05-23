﻿
using UnityEngine;
using GoogleMobileAds.Api;


public class GoogleAdScript : MonoBehaviour
{
    
    private BannerView bannerView;

    public void Start()
    {
        MobileAds.Initialize(initStatus => { });        
        RequestBanner();
    }

    private void RequestBanner()
    {
        
#if UNITY_ANDROID
        string adUnitId = "ca-app-pub-1177905240975126/2318963778";
#elif UNITY_IPHONE
            string adUnitId = "ca-app-pub-3940256099942544/2934735716";
#else
            string adUnitId = "unexpected_platform";
#endif


        bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Bottom);        
        AdRequest request = new AdRequest.Builder().Build();                
        bannerView.LoadAd(request);
    }

}
