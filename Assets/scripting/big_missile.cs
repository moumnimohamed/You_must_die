using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class big_missile : MonoBehaviour {

	public float speed;

	private float maxY;

	private float minY;

	public float espace;

	private int direction = 1;

    GameObject effet;

	// Use this for initialization

	void Start () {


		maxY = this.transform.position.y + espace;

		minY = maxY - espace;


	}

	// Update is called once per frame

	void Update () {
        Destroy(effet, 1f);
        
		transform.Translate(Vector2.left * speed);


		this.transform.position = new Vector2 (this.transform.position.x, this.transform.position.y +(direction * 0.5f));

		if (this.transform.position.y > maxY)

			direction = -1;

		if (this.transform.position.y < minY)

			direction = 1;
		
	}

	public GameObject bomb_effect;
    void OnTriggerEnter2D(Collider2D other)
	{
		effet = (GameObject)Instantiate (bomb_effect, transform.position, Quaternion.identity);
        shake_camera.Chacknow(100f, 1f);

		Destroy (gameObject);
		Destroy (effet,1f);
	}

}
