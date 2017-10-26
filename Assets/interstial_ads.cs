using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;


public class interstial_ads : MonoBehaviour {

    bool hasShownAdOneTime;
    public score_manager scor_mn;

    public string full_ads_ID;
    // Use this for initialization
    void Start()
    {
        //Request Ad
        RequestInterstitialAds();
                scor_mn = GameObject.FindGameObjectWithTag("score_manager").GetComponent<score_manager>();

    }

   

    public void showInterstitialAd()
    {
        //Show Ad
        if (interstitial.IsLoaded())
        {
            interstitial.Show();

            //Stop Sound
            //

            Debug.Log("SHOW AD XXX");
        }

    }

    InterstitialAd interstitial;
    private void RequestInterstitialAds()
    {
        string adID = full_ads_ID;

#if UNITY_ANDROID
        string adUnitId = adID;
#elif UNITY_IOS
        string adUnitId = adID;
#else
        string adUnitId = adID;
#endif

        // Initialize an InterstitialAd.
        interstitial = new InterstitialAd(adUnitId);

       

        //***Production***
        AdRequest request = new AdRequest.Builder().Build();

        //Register Ad Close Event
        interstitial.OnAdClosed += Interstitial_OnAdClosed;

        // Load the interstitial with the request.
        interstitial.LoadAd(request);

        Debug.Log("AD LOADED XXX");

    }

    //Ad Close Event
    private void Interstitial_OnAdClosed(object sender, System.EventArgs e)
    {
        //Resume Play Sound

    }

    public void show_ads_and_give_score ()
    {
         showInterstitialAd ();
                 scor_mn.gift_score();

    }

}
