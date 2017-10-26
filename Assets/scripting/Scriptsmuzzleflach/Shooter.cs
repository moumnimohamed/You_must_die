using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {

    public GameObject bullet;
    public float bulletSpeed;
    public float velocity;


	void Update () {

        if (Input.GetButtonDown("Jump"))
        {
            GameObject furball = Instantiate(bullet, transform.position, Quaternion.identity) as GameObject;
            furball.GetComponent<Rigidbody2D>().velocity = new Vector2(velocity* transform.localScale.x, 0);

        }

	}
}
