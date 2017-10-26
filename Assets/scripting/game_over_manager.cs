using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public  class game_over_manager : MonoBehaviour {

public GameObject pause_menu_active;
    public string scene_name;
	// Use this for initialization
    public GameObject black_panel;
    public GameObject store_panel;
    public GameObject ads_panel;


    public GameObject game_over;

    public GameObject twitter;
    public GameObject facebbok;


    AudioSource audi;
  public  AudioClip game_overr_sound;

    public Animator anim;
    public Animator face;
    public Animator twit;

	void Start () {
        anim =game_over. GetComponent<Animator>();
       face =facebbok. GetComponent<Animator>();
        twit =twitter. GetComponent<Animator>();
        audi = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        if (black_panel.activeInHierarchy)
        {
            audi.PlayOneShot(game_overr_sound);
            anim.SetInteger("animstate", 2);
            face.SetInteger("animstate", 2);
            twit.SetInteger("animstate", 2);
        }
	}
    public  void ONclickin_pause()
    {
        anim.SetInteger("animstate", 2);
      face.SetInteger("animstate", 2);
        twit.SetInteger("animstate", 2);
        audi.Play();

    }
    public void ONclickout()
    {
        anim.SetInteger("animstate", 0);
        face.SetInteger("animstate", 0);
        twit.SetInteger("animstate", 0);
        Invoke("load_scene", 0.5f);
        black_panel.SetActive(false);
        audi.Play();
        Time.timeScale = 1f;


    }
    public void load_scene()
    {
        SceneManager.LoadScene(scene_name);

    }

    public void enable_store_panel()
    {
        store_panel.SetActive(true);
        audi.Play();

    }

    public void desanable_store_panel() {
        store_panel.SetActive(false);
        audi.Play();

    }
    public void desanable_ads_panel()
    {
        ads_panel.SetActive(false);
        audi.Play();

    }
 public void active_pause_menu ()
    {
       pause_menu_active .SetActive(true);
        Time.timeScale=0f;

    }
 public void continuer ()
    {
       pause_menu_active .SetActive(false);
        Time.timeScale=1f;

    }

}
