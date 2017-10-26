using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scocial_media : MonoBehaviour {



 public   score_manager scoreManager;

 AudioSource audi;

        void Start() {

            audi = GetComponent<AudioSource>();

           
 
         }


    /* TWITTER VARIABLES*/

    //Twitter Share Link
    string TWITTER_ADDRESS = "http://twitter.com/intent/tweet";
   public string play_store_adress = "https://play.google.com/store/apps/details?id=com.moumnigames.miniadventure";
    public string twitterdescripetionParam = "";

    //Language


    //This is the text which you want to show
 public   string textToDisplay = "Hey Guys! Check out my score: ";

    /*END OF TWITTER VARIABLES*/

    /* FACEBOOK VARAIBLES */

    //App ID //hada dyali ana
   public string AppID ;

    //This link is attached to this post
   public string Link_app_store = "com.moumnigames.wonderleague";

   

    //The Caption of the link appears beneath the link name
    string Caption = "Check out My New Score: ";

    //The Description of the link
    string Description = "Enjoy Fun, free games! Challenge yourself or share with friends. Fun and easy to use games.";

    /* END OF FACEBOOK VARIABLES */

    // Twitter Share Button	
    public void shareScoreOnTwitter()
    {
        audi.Play();
        Application.OpenURL(TWITTER_ADDRESS + "?text=" + WWW.EscapeURL(textToDisplay +  scoreManager.score_to_share + "\n"  + play_store_adress));
      //  Application.OpenURL(twitter_adress + "?text=" + WWW.EscapeURL( nameParameter + "\n" + twitterdescripetionParam + play_store_adress)); 
    }

    // Facebook Share Button
    public void shareScoreOnFacebook()
    {
        audi.Play();

        Application.OpenURL("https://www.facebook.com/dialog/feed?" + "app_id=" + AppID + "&link=" + Link_app_store + "&caption=" + Caption + scoreManager.score + "&description=" + Description);
    }




    public void RateUs()
    {

#if UNITY_ANDROID
        Application.OpenURL("https://play.google.com/store/apps/details?id=com.moumnigames.wonderleague");
#elif UNITY_IPHONE
		Application.OpenURL("itms-apps://itunes.apple.com/app/idYOUR_ID");
#endif
    }
}
