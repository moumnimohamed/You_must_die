using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour {

	public float velocity;
	public GameObject shoots;
  

 
	public GameObject shoots_pos; 
	GameObject furball;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
    public void shotnow(   )
    {

        furball = (GameObject)Instantiate(shoots, shoots_pos.transform.position, Quaternion.identity);
        furball.GetComponent<Rigidbody2D>().velocity = new Vector2(velocity * this.transform.localScale.x , 0);
        furball.transform.localScale =  new Vector3 (furball.transform.localScale.x * this.transform.localScale.x,1,1);
        
        Destroy(furball, .9f);
    }
    
   
	}

