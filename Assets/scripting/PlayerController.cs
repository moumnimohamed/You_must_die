using UnityEngine;
using System.Collections;
using CnControls;


public class PlayerController : MonoBehaviour {

	public Vector2 moving = new Vector2 ();
	public bool shoot_button;
	public bool jump_button;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        shoot_button = CnInputManager.GetButton ("Jump");
		moving.x = moving.y = 0;

        Vector2 movement = new Vector2(CnInputManager.GetAxis("Horizontal"),CnInputManager.GetAxis("Vertical"));

		if (movement.x>0) {
			moving.x = 1;
            transform.localScale =new Vector3( 1,1,1);
        }
        else if (movement.x < 0)
        {
			moving.x = -1;
            transform.localScale = new Vector3(-1, 1, 1);
		}

         // for jump

        
		   

		if (movement.y>0) {
			
			moving.y = 1;
		}
        else if (movement.y<0)
        {
			
            moving.y = -1;
        }



	}
}
