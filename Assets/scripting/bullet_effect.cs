using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_effect : MonoBehaviour {

    public GameObject shoot_effect;
    GameObject hot_effect;
	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	void Update () {

	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == ("enmy") )
        {
            hot_effect = (GameObject)Instantiate(shoot_effect, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
            Destroy(hot_effect, 0.5f);
        }

    }
    /// <summary>
    /// Sent when an incoming collider makes contact with this object's
    /// collider (2D physics only).
    /// </summary>
    /// <param name="other">The Collision2D data associated with this collision.</param>
    void OnCollisionEnter2D(Collision2D other)
    {

            hot_effect = (GameObject)Instantiate(shoot_effect, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
            Destroy(hot_effect, 0.5f);
       
    }
}
