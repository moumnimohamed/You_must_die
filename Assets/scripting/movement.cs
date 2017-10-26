using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{

    public GameObject jetfire;
	public bool playerIsDied=false;

    public float speed = 150f;
    public Vector2 maxvelocity = new Vector2(60, 100);
	public Animator anim;

    private PlayerController pcontro;

    public float jetspeed = 200f;
    public float airSpeedMultiplier = .3f;
    public bool standing;
    public float standingThreshold = 4f;
	public Rigidbody2D body2d;
  
    // Use this for initialization
    void Start()
    {
		       
		anim = GetComponent<Animator>();
        pcontro =GetComponent<PlayerController>();
        body2d = GetComponent<Rigidbody2D>();
      
    }

    // Update is called once per frame
    void Update()
    {
		if (playerIsDied == false) {


			var absvesX = Mathf.Abs (body2d.velocity.x);
			var absvesY = Mathf.Abs (body2d.velocity.y);

			if (absvesY <= standingThreshold) {
				standing = true;
			} else {
				standing = false;
			}

			var forceX = 0f;
			var forceY = 0f;





			if (pcontro.moving.x != 0f) {
                           
               

                           
				if (absvesX < maxvelocity.x) {
					var newspeed = speed * pcontro.moving.x;
					forceX = standing ? newspeed : (newspeed * airSpeedMultiplier);
					if (standing) {
						anim.SetInteger ("animstate", 1);
					} else {
						anim.SetInteger ("animstate", 0);
					}
				}


			} else {
				anim.SetInteger ("animstate", 0);

			}
    
			if (pcontro.moving.y > 0) {
				//  if (absvesY < maxvelocity.y )
       
				forceY = jetspeed * pcontro.moving.y;
				//  }
                if(jetfire !=null)
				jetfire.SetActive (true);
				anim.SetInteger ("animstate", 2);
           
			} else if (absvesY > 0 && !standing) {
                if (jetfire != null)
				jetfire.SetActive (false);
				anim.SetInteger ("animstate", 0);
            

			}
			if ((pcontro.moving.x == 0f && standing) && pcontro.shoot_button) {
			
				anim.SetInteger ("animstate", 3);


			} else if (!standing && pcontro.shoot_button) {
			
				anim.SetInteger ("animstate", 4);

			}      
			body2d.AddForce (new Vector2 (forceX, forceY));
		}
    }






}
