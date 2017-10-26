using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class player_manager_store : MonoBehaviour
{
    public static int player_index = 0;
    public int    player__index ;

  public  score_manager score_mn;

    public GameObject current_player;
    public GameObject[] player_prefebs;

    public  GameObject ads_panel;
    public GameObject store_panel;
    public  ad_manager ads_manage;


    // Use this for initialization
    AudioSource audi;

    void Start()
    {
        ads_manage = GameObject.FindGameObjectWithTag("ads").GetComponent<ad_manager>();

        audi = GetComponent<AudioSource>();
        Switch_player(player_index);
    }

    // Update is called once per frame
    void Update()
    {
   player__index = player_index;
    }
    public void Switch_player(int index)
    {
        current_player = player_prefebs[index];
        Instantiate(current_player, transform.position, Quaternion.identity);
        }


  public void  appel_police () {
      audi.Play();
      player_index = 0;
      store_panel.SetActive(false);
}
  public void  appel_bandit () {
      audi.Play();

      player_index = 1;
      store_panel.SetActive(false);

}
  public void  appel_summon() {
      audi.Play();

     ads_manage.LoadRewardBaseAd ();
      if (score_mn.a >= 1000)
      {
          audi.Play();

          player_index = 2;
          store_panel.SetActive(false);

      }
      else
      {
          ads_panel.SetActive(true);

      }
}
  public void  appel_mia () {
     ads_manage.LoadRewardBaseAd ();
      
      audi.Play();


      if (score_mn.a >= 2000)
      {
          player_index = 3;
          store_panel.SetActive(false);
           

      }
      else
      {
          ads_panel.SetActive(true);
      }

}
  public void  appel_warrior () {
     ads_manage.LoadRewardBaseAd ();
      
      if (score_mn.a >= 4000)
      {
          audi.Play();

          player_index = 4;
          store_panel.SetActive(false);

      }
      else
      {
          ads_panel.SetActive(true);

      }

}


}
