using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomb_and_missile : MonoBehaviour {

  public  GameObject missileOrbomb ;
  
  public float range ;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	/// <summary>
	/// OnTriggerStay is called once per frame for every Collider other
	/// that is touching the trigger.
	/// </summary>
	/// <param name="other">The other Collider involved in this collision.</param>
	/// <summary>
	/// Sent each frame where another object is within a trigger collider
	/// attached to this object (2D physics only).
	/// </summary>
	/// <param name="other">The other Collider2D involved in this collision.</param>
	void OnTriggerStay2D(Collider2D other)
	
	{
		if
		(other.tag=="Player"
		)
		StartCoroutine("shot");
	}

	IEnumerator shot() {
             
			 yield return new WaitForSeconds(10f);

			float rang = Random.Range(-range,range);

			Vector2 pos= new Vector3 (rang+transform.position.x,transform.position.y);
			 
			  Instantiate(missileOrbomb,pos,Quaternion.identity);
			  



	}
}
