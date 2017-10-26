using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_heart : MonoBehaviour {


    public SpriteRenderer spriter_rn;
   public  Color default_color ;
    public Color demage_color;
    play_sound PLAY_SOUND;
	// Use this for initialization
	void Start () {
         PLAY_SOUND = gameObject.GetComponent<play_sound>();

        spriter_rn = gameObject.GetComponent<SpriteRenderer>();
       
        default_color = spriter_rn.color;
	}
	
	// Update is called once per frame
	void Update () {

       
		
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        if ( coll.tag == "deadly")
        {
            PLAY_SOUND.Herted();

            spriter_rn.color = demage_color;
            StartCoroutine("Default_couleur");
        }
    }

    void OnCollisionEnter2D (Collision2D other)
    {

        if (other.gameObject.tag == "deadly" || other.gameObject.tag == "deadly2")
        {
            spriter_rn.color = demage_color;
         
            StartCoroutine("Default_couleur");

        }
    }
    public  IEnumerator Default_couleur ()
    {
        yield return new WaitForSeconds(0.1f);
        spriter_rn.color = default_color;
    }
}
