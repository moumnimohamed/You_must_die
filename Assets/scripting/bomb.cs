using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomb : MonoBehaviour {
	public GameObject bomb_effect;
    GameObject effet;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" || other.tag == "ground")
        {
            effet = (GameObject)Instantiate(bomb_effect, transform.position, Quaternion.identity);
            shake_camera.Chacknow(100f, 1f);
            Destroy(this.gameObject);
           

        }
    }
}
