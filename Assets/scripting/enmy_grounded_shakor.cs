using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enmy_grounded_shakor : MonoBehaviour {


  public  play_enmy_sound pl_s_enmy;

    public GameObject fire_magic;

	public float time_toshot;
	private float timer;

	public  GameObject blood;
	private float distancevalur;

    //for enmy ,test if he is a life
    bool iamIlive = true;
	public float groundradius = 0.2f;
	public bool isGrounded = false;
	public Transform groundcode;
	public LayerMask theground;
	//icon sur la tete d'enmy
	public GameObject attenstion;
	public bool player_Standing;
	private bool iam_die = false;
	//distance between 3adow w player
	float distance;
	public Animator anim;
	public Vector3 distance_between;
	public movement player_movement;
	public GameObject target;
	public float ratio=0.05f;
	// Use this for initialization
	GameObject clone;
	void Start () {
		clone = (GameObject)Instantiate (blood, transform.position, Quaternion.identity);


        pl_s_enmy =  GameObject.FindGameObjectWithTag("enmy_sound").GetComponent<play_enmy_sound>();


		clone.SetActive (false);

		ratio = Random.Range (2f, 5f);
		distancevalur = Random.Range (100f,200f);
		anim = GetComponent<Animator>();
		
	}

	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;

        if (target == null)
            target = GameObject.FindGameObjectWithTag("Player");
        player_movement = target.GetComponent<movement>();

		//hadi htan kon ana player 3la lard 3ad ytba3ni 3adow
		if (player_movement.standing == true) {
			player_Standing = true;
			attenstion.SetActive (true);


		} else {
			attenstion.SetActive (false);
			player_Standing = false;

		}

		//hadi bash ytba3ni 3adow ila kont kanshof fih
        if (player_Standing == true && iamIlive == true)
        {
			transform.position = Vector3.MoveTowards (transform.position, target.transform.position + distance_between, ratio);
			distance = transform.position.x - target.transform.position.x;
			Debug.Log (distance);
			Flip (distance);
		} 

	}
	void FixedUpdate ()
	{
		if (player_Standing == true) {
			isGrounded = Physics2D.OverlapCircle (groundcode.position, groundradius, theground);
			// hadi bash ytba3ni 3adow ila kan masafa li binatna != distance
			if (player_Standing == true && distance != distance_between.x && iam_die==false) {
				anim.SetInteger ("animstate", 1);

			}
			else if (player_Standing == true && distance == distance_between.x && iam_die==false ) {
				anim.SetInteger ("animstate", 3);
				if (timer>time_toshot)
					
				timer = 0;
			}
		}
	}



	//hadi bash thafd 3ala wahd distanse bini w bin enmy
	void Flip (float dis)
	{
		if (dis>=0) {
			transform.localScale = new Vector3(-2,2,2);
			distance_between.x = distancevalur;
		} else {
			transform.localScale = new Vector3(2,2,2);
			distance_between.x = -distancevalur;

		}
	}

	void  OnTriggerEnter2D(Collider2D other){
        if (other.tag == "Finish" && iamIlive == true)
        {
            Instantiate(fire_magic, transform.position, Quaternion.identity);
            iamIlive = false;
            anim.SetInteger("animstate", 2);


            Destroy(gameObject);
            Destroy(other.gameObject);

            //play sound of dead
            pl_s_enmy.Dead();
        }
      //  Finish1 howa 9ortass
        if (other.tag == "Finish1" && iamIlive == true)
        {
            Destroy(other.gameObject);
            pl_s_enmy.Dead();

            this.GetComponent<CircleCollider2D>().enabled = false;
            this.GetComponent<BoxCollider2D>().enabled = false;
            this.GetComponent<Rigidbody2D>().gravityScale = 0f;
            this.GetComponent<Rigidbody2D>().mass = 0f;

            iamIlive = false;
			player_Standing = false;
			iam_die=true;
			if (!clone.activeInHierarchy) {
				clone.transform.position =  transform.position;
				clone.SetActive (true);
				clone.transform.parent =this.transform;

			}
			anim.SetInteger ("animstate", 2);
			Destroy (gameObject, 2);
		}

	}


}
