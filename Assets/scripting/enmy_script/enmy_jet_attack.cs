using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enmy_jet_attack : MonoBehaviour {

public float range1= 300;

 public bool gotIt;
  public GameObject  fire_magic;

 public play_enmy_sound pl_s_enmy;


	public enmy_shoot_now shoot_now;
	public GameObject [] etems; 
	public GameObject coin;

	public float groundradius = 0.2f;
	public bool isGrounded = false;
	public Transform groundcode;
	public LayerMask theground;

	public bool folowNow=true;

	public Animator anim;
	public Vector3 distance_between;

	public GameObject target;
	public float ratio=0.05f;
	// Use this for initialization
	public int valueDistance;

	public GameObject blood;
	GameObject clone;

    //for enmy ,test if he is a life
    bool iamIlive = true;
	void Start () {



        pl_s_enmy = GameObject.FindGameObjectWithTag("enmy_sound").GetComponent<play_enmy_sound>();



		clone = (GameObject)Instantiate (blood, transform.position, Quaternion.identity);
		clone.SetActive (false);

		valueDistance = Random.Range (100, 200);
		anim = GetComponent<Animator>();
		
		ratio = Random.Range (1f, 2f);

		shoot_now = GetComponent<enmy_shoot_now> ();
	}
	
	// Update is called once per frame
	void LateUpdate () {
		if (!gotIt) {
						Collider2D[] hits = Physics2D.OverlapCircleAll (transform.position, range1);

						foreach (Collider2D h in hits)
								if (h.gameObject == target) {
										gotIt = true;
										break;			
		
								}
				}


        if (target == null)
            target = GameObject.FindGameObjectWithTag("Player");
		//hadi bash ytba3ni 3adow ila kont kanshof fih
		if (gotIt) {
		if (folowNow==true) {
			//if (Vector3.Dot (target.transform.position - transform.position, target.transform.localScale.x * Vector3.right)< 0) 
			transform.position = Vector3.MoveTowards (transform.position, target.transform.position + distance_between, ratio);

		}}
		float distanceX = transform.position.x - target.transform.position.x;
		float distanceY = transform.position.y - target.transform.position.y;

		//hadi bash hta yt9abl m3aya 3ad ytiri3lia
        if (distanceY == 0 && iamIlive == true)
        {
			shoot_now.shotnow();
		}

		Flip (distanceX);
		Debug.Log (distanceY);
		}
	void FixedUpdate ()
	{
		isGrounded = Physics2D.OverlapCircle(groundcode.position, groundradius, theground);
		if (isGrounded && folowNow ==true) {
			anim.SetInteger ("animstate", 1);
		} else if (folowNow==true){
			anim.SetInteger ("animstate", 0);
		}
	}



	//hadi bash thafd 3ala wahd distanse bini w bin enmy
	void Flip (float dis)
	{
		if (dis>=0) {
			transform.localScale = new Vector3(-2,2,2);
			distance_between.x = valueDistance ;
		} else {
			transform.localScale = new Vector3(2,2,2);
			distance_between.x = -valueDistance;

		}
	}

	void  OnTriggerEnter2D(Collider2D other){

 

        if (other.tag == "Finish" && iamIlive == true)
        {
            Instantiate(fire_magic, transform.position, Quaternion.identity);
            iamIlive = false;
            anim.SetInteger("animstate", 2);
            pl_s_enmy.Dead();


            folowNow = false;
            for (int i = 0; i < Random.Range(2, 6); i++)
            {
                var t = transform;
                t.TransformPoint(0, -100, 0);

                GameObject floss = (GameObject)Instantiate(coin, t.position, Quaternion.identity);

                var body2d = floss.GetComponent<Rigidbody2D>();
                body2d.AddForce(Vector3.up * Random.Range(3000, 5000));
                body2d.AddForce(Vector3.right * Random.Range(-1000, 1000));

            }
            GameObject etem = etems[Random.Range(0, etems.Length)];
            GameObject kass = (GameObject)Instantiate(etem, transform.position, Quaternion.identity);
            kass.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 2000);
            Destroy(gameObject);
            Destroy(other.gameObject);

        }





        if (other.tag == "Finish1" && iamIlive == true)
        {
            Destroy(other.gameObject);
            pl_s_enmy.Dead();

            this.GetComponent<CircleCollider2D>().enabled = false;
            this.GetComponent<BoxCollider2D>().enabled = false;
            this.GetComponent<Rigidbody2D>().gravityScale = 0f;
            this.GetComponent<Rigidbody2D>().mass = 0f;

			iamIlive=false;
			anim.SetInteger ("animstate",2);
			//bash nhaydo dm mn haieraki
			if (!clone.activeInHierarchy) {

				clone.transform.position =transform.position;
				clone.SetActive (true);
				clone.transform.parent =this.transform;
			}

			Destroy (gameObject, 2);
			folowNow = false;
			for (int i = 0; i < Random.Range (2, 6); i++) {
				var t = transform;
				t.TransformPoint (0, -100, 0);

				GameObject	floss =(GameObject)	Instantiate (coin, t.position, Quaternion.identity);

				var body2d = floss.GetComponent<Rigidbody2D> ();
				body2d.AddForce ( Vector3.up*Random.Range(3000,5000));
				body2d.AddForce (Vector3.right*Random.Range(-1000,1000));

			}
			GameObject etem = etems[ Random.Range (0, etems.Length)];
			GameObject	kass =(GameObject)	Instantiate (etem, transform.position, Quaternion.identity);
			kass.GetComponent<Rigidbody2D> ().AddForce (Vector2.up*2000);
}
	}


	
	void OnDrawGizmos()
	{
		Gizmos.color = Color.white;

		Gizmos.DrawWireSphere (transform.position, range1);


		}
}




