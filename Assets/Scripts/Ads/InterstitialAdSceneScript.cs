using GoogleMobileAds.Api;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InterstitialAdSceneScript : MonoBehaviour
{
    private InterstitialAd interstitial;


    private void Start()
    {        
        RequestInterstitial();
        MobileAds.Initialize(initStatus => { });
    }

    private void RequestInterstitial()
    {

        string adUnitId = "ca-app-pub-1177905240975126~3402020703";


        this.interstitial = new InterstitialAd(adUnitId);
        AdRequest request = new AdRequest.Builder().Build();
        this.interstitial.LoadAd(request);

        this.interstitial.OnAdClosed += (sender, args) => HandleOnAdClosed(sender, args);


        if (this.interstitial.IsLoaded())
        {            
            this.interstitial.Show();            
        }
    }

    public void HandleOnAdClosed(object sender, EventArgs args)
    {
        if (GameManager.instance.loadMainMenuAds)
        {
            SceneManager.LoadScene(0);
        }
    }
}
