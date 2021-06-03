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
    }

    private void RequestInterstitial()
    {

        // prod ad ca-app-pub-1177905240975126/3402020703
        // test ad ca-app-pub-3940256099942544/1033173712

#if UNITY_ANDROID
        string adUnitId = "ca-app-pub-1177905240975126/3402020703";
#elif UNITY_IPHONE
        string adUnitId = "ca-app-pub-3940256099942544/4411468910";
#else
        string adUnitId = "unexpected_platform";
#endif

        this.interstitial = new InterstitialAd(adUnitId);

        if (this.interstitial != null)
        {
            this.interstitial.Destroy();
        }

        AdRequest request = new AdRequest.Builder().Build();
        this.interstitial.LoadAd(request);
        this.interstitial.OnAdClosed += (sender, args) => HandleOnAdClosed(sender, args);

        if (this.interstitial.IsLoaded())
        {            
            this.interstitial.Show();            
        } else
        {            
            SceneManager.LoadScene(0);
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
