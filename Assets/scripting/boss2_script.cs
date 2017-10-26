using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class boss2_script : MonoBehaviour {
    public string scene_name;

    AudioSource audi;
    public AudioClip[] demage_sound;

	public GameObject boss_parts;
    public GameObject[] bulletHell ;
	public int heatlth =100;
	public int curent_heatlth =0;

    // pour donner l'argent juste ne fois
    public bool donner = true;

	public GameObject  effect;
    // effect li 3ankhazno fih effect fi wa9t instantiation
     GameObject eff;

  public   GameObject[] coin;

  List<GameObject> list_coins;
  public int nombredecoin;

    public int nbr_effect;
    List<GameObject> list_effect;

	Animator anim;

	// Use this for initialization
    void Start()
    {
        list_effect = new List<GameObject>();
        audi = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        curent_heatlth = heatlth;
        for (int i = 0; i < nbr_effect; i++)
        {
        GameObject  eff = (GameObject)Instantiate(effect);   
             eff.SetActive(false);
            list_effect.Add(eff);
        }

        list_coins = new List<GameObject>();

        for (int i = 0; i < nombredecoin; i++)
        {
        GameObject   coins = coin[ Random.Range(0, coin.Length)];
            GameObject floss = (GameObject)Instantiate(coins);
            floss.SetActive(false);
            list_coins.Add(floss);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
		
			


	}
    public void damage()
    {
        int range = Random.Range(0, demage_sound.Length);
        AudioClip thiis = demage_sound[range];
        audi.PlayOneShot(thiis);
    }

	void  OnTriggerEnter2D(Collider2D other){
        if (other.tag == "Finish" || other.tag == "Finish1")
        {
            damage();
			anim.SetInteger ("animstate", 1);
			curent_heatlth-=10;


            if (curent_heatlth <= 0 && donner == true)
            {
              
				StartCoroutine ("explosion");
                // bash n3tiw floss l player
                StartCoroutine("onfloos");

                donner = false;  
			}
		} 
         if (curent_heatlth > 0 )
	StartCoroutine("defalt_anim");

		}
/*void  OnTriggerExit2D(Collider2D other){

        if (other.tag == "Finish" || other.tag == "Finish1")
        {
			anim.SetInteger ("animstate", 0);
		

		}
   }*/ 
	
	IEnumerator explosion (){

        bulletHell[0].SetActive(false);
        bulletHell[1].SetActive(false);

             Time.timeScale=0.5f;

			for (int i = 0; i < nbr_effect; i++) {
				yield return new WaitForSeconds (0.2f);
					Vector2 marge = new Vector2 (Random.Range (-50, 50), Random.Range (-60, 80));
					Vector3	t = transform.position;
					Vector3 newpos = new  Vector3 (t.x + marge.x, t.y + marge.y, t.z); 
					//GameObject	eff = (GameObject)Instantiate (effect, newpos, Quaternion.identity);

                    if (!list_effect[i].activeInHierarchy)
                        {
                            list_effect[i].SetActive(true);
                            list_effect[i].transform.position = newpos;
                        }
                    
		}

		GameObject parts = (GameObject) Instantiate (boss_parts, transform.position, Quaternion.identity);
        shake_camera.Chacknow(100f, 1f);

		foreach (Transform chield  in  parts.transform) {
			chield.GetComponent<Rigidbody2D> ().velocity = new Vector2 (Random.Range (-50f, 50f), Random.Range (50f, 50f));
		}
		Destroy (this.gameObject);
		Destroy (parts,5f);

	}
    IEnumerator onfloos ()
    {
        for (int i = 0; i < nombredecoin; i++)
        {
            yield return new WaitForSeconds(0.1f);

            var t = transform;
            t.TransformPoint(0, -100, 0);


            if (!list_coins[i] .activeInHierarchy)
            {
                list_coins[i].SetActive(true);
                list_coins[i].transform.position = transform.position;
                var body2d = list_coins[i].GetComponent<Rigidbody2D>();
                body2d.AddForce(Vector3.up * Random.Range(3000, 5000));
                body2d.AddForce(Vector3.right * Random.Range(-1000, 1000));
            }

         

        }
                StartCoroutine("load_scene");

    }
    IEnumerator defalt_anim (){
        yield return new WaitForSeconds(0.2f);
anim.SetInteger ("animstate", 0);
    }

      IEnumerator  load_scene ()
    {
    Debug.Log("i'am working moumni");
       yield return new WaitForSeconds(4f);
       
        SceneManager.LoadScene(scene_name);
        
    Debug.Log("i finish working moumni");
        
    }
}
