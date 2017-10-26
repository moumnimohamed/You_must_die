using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_character : MonoBehaviour {



    public GameObject[] players;
    public Animator [] anim;
	// Use this for initialization
	void Start () {
        Time.timeScale = 0.5f;
            for (int i = 0; i < players.Length;i++ )
            {
                anim[i] = players[i].GetComponent<Animator>();
            }
	}
	
	// Update is called once per frame
	void Update () {
        for (int i = 0; i < anim.Length; i++)
        {
            
            anim[i].SetInteger("animstate", 1);
        }
	}
}
