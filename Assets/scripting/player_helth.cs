using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class player_helth : MonoBehaviour {

  static  int time_to_ads = 0;
  public int to_ads = 0;

    public GameObject en_manager;

    public GameObject black_panel;

    AudioSource audi;
    public AudioClip makla;

	public float max_healt=100f;
	public float cur_healt=0;
	public  GameObject healtbar;
    public int nbr_bodyparts;
	private movement movem;
    public GameObject bodyparts;
    public GameObject blood;

    public score_manager score__manger;

    public interstial_ads interstial_ads_inad_manager;
    void Awake()
    {
        black_panel = GameObject.FindWithTag("black_panel");
        black_panel.SetActive(false);

        interstial_ads_inad_manager = GameObject.FindGameObjectWithTag("ads").GetComponent<interstial_ads>();


    }
	void Start()
	{
        en_manager = GameObject.FindGameObjectWithTag("manager");

        audi = GetComponent<AudioSource>();
        score__manger = GameObject.FindGameObjectWithTag ("score_manager").GetComponent<score_manager>();
		cur_healt = max_healt;
		movem = GetComponent<movement> ();

        
	}
   



	void OnTriggerEnter2D (Collider2D coll)
	{
		if (movem.playerIsDied == false && coll.tag == "deadly") {
			if(cur_healt <= 0f){

                score__manger.Addscore();
			movem.body2d.gravityScale = 100;
			movem.playerIsDied = true;
			movem.anim.SetInteger("animstate",5);
			Destroy (gameObject,2);
            coll.gameObject.SetActive(false);
                // ici tout qui concerne UI

            StartCoroutine("Black_panel");
            black_panel.SetActive(true);

          
			}
			decreseHealth ();
		}

		if (movem.playerIsDied == false && coll.tag == "saro") {
			Onexploid ();
		}
        if (coll .gameObject.tag == "etem"){
            score__manger.number += 1;
            score__manger.Addscore();
            Destroy(coll.gameObject); 
        }
        if (coll.gameObject.tag == "makla")
        {
            if (cur_healt < max_healt)
                add_Health();
            Destroy(coll.gameObject);
            audi.PlayOneShot(makla);
        }	
	}

	void Onexploid (){
        score__manger.Addscore();

        Destroy(this.gameObject);

		var t = transform;
		for (int i = 0; i < nbr_bodyparts ; i++) {
			t.TransformPoint (0, -100, 0);

            var clone = Instantiate(bodyparts, t.position, Quaternion.identity) as GameObject;
			Destroy (gameObject);
			var body2d = clone.GetComponent<Rigidbody2D> ();
			body2d.AddForce ( Vector3.up*Random.Range(5000,9000));
			body2d.AddForce (Vector3.right*Random.Range(-4000,5000));
            Destroy(clone, 10);
            
		}
        var bloo = Instantiate(blood, transform.position, Quaternion.identity) as GameObject;
        Destroy(bloo,2);
StartCoroutine("Black_panel");
            black_panel.SetActive(true);
           
	}

	public void decreseHealth () {
		cur_healt -= 5f;
		float valculeHealth = cur_healt / max_healt;
		setHealthBar (valculeHealth);
	}
    public void add_Health()
    {
        cur_healt += 5f;
        float valculeHealth = cur_healt / max_healt;
        setHealthBar(valculeHealth);
    }
	// dyal healt bar bash n9ss mn scal dyal image 
	public void setHealthBar(float myhealt){
		healtbar.transform.localScale = new Vector3 (myhealt, healtbar.transform.localScale.y, healtbar.transform.localScale.z);
	}


    public IEnumerator Black_panel()
    {
        Destroy(en_manager);

        GameObject [] enmys = GameObject.FindGameObjectsWithTag("enmy");

        foreach (GameObject enmy in enmys)
        {
            Destroy(enmy);
        }

        if (Time.timeScale == 1f)
            Time.timeScale = 0.2f;
        yield return new WaitForSeconds(1f);
        
        time_to_ads += 1;
        to_ads = time_to_ads;
        if (time_to_ads == 2)
        {
            interstial_ads_inad_manager.showInterstitialAd();
            time_to_ads = 0;
        }
    }


}
