using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hodod : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D coll)
	{
	}

    void OnTriggerEnter2D(Collider2D coll)
    {

        if (coll.tag == "bullet" || coll.tag == "bullet2" )
        {
            coll.gameObject.SetActive(false);
        }
        else if (coll.tag == "Finish" || coll.tag == "Finish1")
        {
            Destroy(coll.gameObject);
        }
        if (coll.tag == "saro")
        {
            Destroy(coll.gameObject);
        }
    }
}
