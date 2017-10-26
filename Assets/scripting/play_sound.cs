using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class play_sound : MonoBehaviour {


    public AudioSource audi;
  
    public AudioClip [] herted;
    public AudioClip dead;
   
    public AudioClip flay;



	// Use this for initialization
	void Start () {

        
        audi = GetComponent<AudioSource>();
		
	}
	
  
	// Update is called once per frame
	void Update () {
		
	}

    public void shot_sound()
    {
        audi.Play();
    }
    public void Herted()
    {
        int range = Random.Range(0, herted.Length);
        AudioClip thiis = herted [range];
        audi.PlayOneShot(thiis);
    }
    public void Dead()
    {
        audi.PlayOneShot(dead);
    }
   
    public void Flay()
    {
        audi.PlayOneShot(flay);
    }

    
}
