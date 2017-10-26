using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_folower : MonoBehaviour {



	Vector3 campos;
	Vector3 playerpos;
	// Use this for initialization
	
	
	// Update is called once per frame
    public Transform player_trans;
    public GameObject player;

    public float maxdistanceright = 1.5f;
    public float maxdistanceleft = 1.5f;
    public float maxdestanceup = .5f;
    public float maxdestancedown = .5f;

    public float maxright = 1147f;
    public float maxleft = 1147f;
    public float maxup = 834f;


    void Start (){

        
        
    
}
   void LateUpdate ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        player_trans = player.transform;
        if (player != null)
        {

            Vector3 campos = transform.position;

            Vector3 playerpos = player_trans.position;


            if (playerpos.x - campos.x > maxdistanceright)
            {

                campos.x = playerpos.x - maxdistanceright;
            }
            else

                if (campos.x - playerpos.x > maxdistanceleft)
                {

                    campos.x = playerpos.x + maxdistanceleft;
                }



            if (playerpos.y - campos.y > maxdestanceup)
            {
                campos.y = playerpos.y - maxdestanceup;
            }
            else if (campos.y - playerpos.y > maxdestancedown)
            {
                campos.y = playerpos.y + maxdestancedown;
            }

            if (campos.x >= maxright)
            {
                campos.x = maxright;
            }
            else if (campos.x <= maxleft)
            {
                campos.x = maxleft;

            }
            if (campos.y >= maxup)
            {
                campos.y = maxup;

            }
            transform.position = campos;
        }
        else {
            Debug.Log("player is dead");
        }
    }


}
