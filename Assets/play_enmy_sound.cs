using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class play_enmy_sound : MonoBehaviour {

	public AudioSource audi;

    
    public AudioClip [] dead;
   
    public AudioClip [] reaction;




	// Use this for initialization
	void Start () {
        audi = GetComponent<AudioSource>();
        Reaction();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Reaction()
    {
        int range = Random.Range(0, reaction.Length);
        AudioClip thiis = reaction[range];
        audi.PlayOneShot(thiis);
    }
    public void Dead()
    {
        int range = Random.Range(0, dead.Length);
        AudioClip thiis = dead[range];
        audi.PlayOneShot(thiis);
    }
}
