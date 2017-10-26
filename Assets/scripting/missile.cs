using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class missile : MonoBehaviour {
    public GameObject effect;
	public float speed = 5;
	public float rotatingSpeed;
	public GameObject target;
    public string withTag ="Player";
	Rigidbody2D rb;

	// Use this for initialization
	void Start () {

        target = GameObject.FindGameObjectWithTag(withTag);

		rb = GetComponent<Rigidbody2D> ();
		rotatingSpeed = Random.Range (200,500);

	}

	// Update is called once per frame
	void FixedUpdate () {
		
		Vector2 point2Target = (Vector2)transform.position - (Vector2)target.transform.position;

		point2Target.Normalize ();

		float value = Vector3.Cross (point2Target, transform.right).z;

		/*
				if (value > 0) {
				
						rb.angularVelocity = rotatingSpeed;
				} else if (value < 0)
						rb.angularVelocity = -rotatingSpeed;
				else
						rotatingSpeed = 0;
*/

		rb.angularVelocity = rotatingSpeed * value;


		rb.velocity = transform.right * speed;


	}


	void OnTriggerEnter2D(Collider2D other)
	{

		if (other.tag == "Player" || other.tag == "Finish1") {

			Destroy (this.gameObject, 0.02f);
            GameObject effe = (GameObject)Instantiate(effect, transform.position, Quaternion.identity);
            Destroy(effe, 1f);

		}

	}
}
