using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombie_enmy : MonoBehaviour {
public float range1= 300;
 public bool gotIt;

    public GameObject fire_magic;
	public GameObject blood;
    public int nbr_bodyparts;
    public GameObject bodyparts;

    public GameObject [] coin;


	public float groundradius = 0.2f;
	public bool isGrounded = false;
	public Transform groundcode;
	public LayerMask theground;
	//icon sur la tete d'enmy
	
	public bool player_Standing;

	//distance between 3adow w player
	float distance;
	public Animator anim;

	public movement player_movement;
	public GameObject target;
	 float ratio=0.01f;
    //for enmy ,test if he is a life

	// Use this for initialization
	GameObject clone;
    void Start()
    {

        clone = (GameObject)Instantiate(blood, transform.position, Quaternion.identity);
        clone.SetActive(false);

        ratio = Random.Range(2f, 5f);
        anim = GetComponent<Animator>();
    }
    void LateUpdate () {
		if (!gotIt) {
						Collider2D[] hits = Physics2D.OverlapCircleAll (transform.position, range1);

						foreach (Collider2D h in hits)
								if (h.gameObject == target) {
										gotIt = true;
										break;			
		
								}
        }}

	// Update is called once per frame
	void Update () {
		if (target == null)
			target = GameObject.FindGameObjectWithTag ("Player");
		player_movement = target.GetComponent<movement> ();
	

		//hadi htan kon ana player 3la lard 3ad ytba3ni 3adow
		if (player_movement.standing == true) {
			player_Standing = true;


		} else {
			player_Standing = false;

		}

		//hadi bash ytba3ni 3adow ila kont kanshof fih
        if (gotIt) {
        
        if(player_Standing){
        
		
				transform.position = Vector3.MoveTowards (transform.position, target.transform.position , ratio);
			distance = transform.position.x - target.transform.position.x;
			Debug.Log (distance);
			Flip (distance);
	}}
    }
    void FixedUpdate()
    {
        if (player_Standing == true)
        {
            isGrounded = Physics2D.OverlapCircle(groundcode.position, groundradius, theground);
            // hadi bash ytba3ni zombi
           
                anim.SetInteger("animstate", 1);
        }
        else 
        {
            anim.SetInteger("animstate", 0);
        }
    }



	//hadi bash thafd 3ala wahd distanse bini w bin enmy
	void Flip (float dis)
	{
		if (dis>=0) {
			transform.localScale = new Vector3(-2,2,2);
		} else {
			transform.localScale = new Vector3(2,2,2);

		}
	}

    //litafjir  zombie
    void Onexploid()
    {
        Destroy(this.gameObject);
        var t = transform;
        for (int i = 0; i < nbr_bodyparts; i++)
        {
            t.TransformPoint(0, -100, 0);

            var clone = Instantiate(bodyparts, t.position, Quaternion.identity) as GameObject;
            Destroy(gameObject);
            var body2d = clone.GetComponent<Rigidbody2D>();
            body2d.AddForce(Vector3.up * Random.Range(10000, 9000));
            body2d.AddForce(Vector3.right * Random.Range(-4000, 5000));
            Destroy(clone, 2);

        }
        var bloo = Instantiate(blood, transform.position, Quaternion.identity) as GameObject;
        Destroy(bloo, 2);

    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Player"  || coll.tag == "Finish1")
        {
            Onexploid();
        }
        if (coll.tag == "Finish")
        {
            Instantiate(fire_magic, transform.position, Quaternion.identity);

            anim.SetInteger("animstate", 2);


            Destroy(gameObject);
            Destroy(coll.gameObject);


        }
    }

    	void OnDrawGizmos()
	{
		Gizmos.color = Color.white;

		Gizmos.DrawWireSphere (transform.position, range1);


		}
}
