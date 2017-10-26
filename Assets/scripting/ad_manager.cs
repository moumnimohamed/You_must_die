using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds;
using GoogleMobileAds.Api;

public class ad_manager : MonoBehaviour
{

    public static ad_manager Instance { set; get; }

    public string  rewardedID;

    
    private RewardBasedVideoAd rewardBasedVideoAd;

   // public bool rewardedLoaded, adShowed;

     

    public score_manager scor_mn;
    
    private void Start()
    {

// LoadReward();
        scor_mn = GameObject.FindGameObjectWithTag("score_manager").GetComponent<score_manager>();
      
       
        Instance = this;

        rewardBasedVideoAd = RewardBasedVideoAd.Instance;

        rewardBasedVideoAd.OnAdClosed += HandlerOnAdClosed;
        rewardBasedVideoAd.OnAdFailedToLoad += HandlerOnAdFailedToLoad;
        rewardBasedVideoAd.OnAdLeavingApplication += HandlerOnAdLeavingApplication;
        rewardBasedVideoAd.OnAdLoaded += HandlerOnAdLoaded;
        rewardBasedVideoAd.OnAdOpening += HandlerOnAdOpening;
        rewardBasedVideoAd.OnAdRewarded += HandlerOnAdRewarded;
        rewardBasedVideoAd.OnAdStarted += HandlerOnAdStarted;

    } 


// hadi hia fontion li kat tlob les pub avant la pub

    public void LoadRewardBaseAd ()
    {
          #if UNITY_EDITOR
        string adUnitId = "unused";
    #elif UNITY_ANDROID
        string adUnitId = rewardedID;
    #elif UNITY_IPHONE
        string adUnitId = rewardedID;
    #else
        string adUnitId = "unexpected_platform";
    #endif
 
 rewardBasedVideoAd.LoadAd(new AdRequest.Builder().Build(), adUnitId);
    }


// hadi hia fontion li kat afficher les pub
    public void ShowRewardAd()
    {
// had fonction katjib pub 3ad bash doz tban
// khasni nkhadmha hia liwla 3ad pub tban
      //   LoadReward();
        if (rewardBasedVideoAd.IsLoaded())
        {
            rewardBasedVideoAd.Show();
        }else
        {
            MonoBehaviour.print("the ads is not loaded");
        }
      
    }

  /*  public void ShowBanner()
    {
#if UNITY_EDITOR
        Debug.Log("NO ShowBanner AD IN UNITY EDITOR");
#elif UNITY_ANDROID
		bannerView.Show ();
#endif
    }

    public void HideBanner()
    {
#if UNITY_EDITOR
        Debug.Log("NO HideBanner AD IN UNITY EDITOR");
#elif UNITY_ANDROID
		bannerView.Hide ();
#endif
    }
    */
    public void HandlerOnAdLoaded(object sender, EventArgs args)
    {
      
    }

    public void HandlerOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        LoadRewardBaseAd();
    }

    public void HandlerOnAdOpening(object sender, EventArgs args)
    {
    }

    public void HandlerOnAdStarted(object sender, EventArgs args)
    {
    }

    public void HandlerOnAdClosed(object sender, EventArgs args)
    {
      
    }

    public void HandlerOnAdRewarded(object sender, Reward args)
    {
      
        scor_mn.gift_score();
        LoadRewardBaseAd();
    }

    public void HandlerOnAdLeavingApplication(object sender, EventArgs args)
    {
    }

    public void resetAdShowed()
    {
       
    }
}