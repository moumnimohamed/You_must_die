using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class boosX : MonoBehaviour {
    public string scene_name;


    AudioSource audi;
    public AudioClip[] demage_sound;
	
    public GameObject[] coin;

    public int nombreenmy;
    public GameObject[] enmys;

    public int nombredecoin;
  List<GameObject> list_coins;
    // pour donner l'argent juste ne fois
  public bool donner = true;

    public int heatlth2 = 100;
    public int curent_heatlth2 = 0;
    public GameObject effect;
    // effect li 3ankhazno fih effect fi wa9t instantiation
    GameObject eff;

    public int nbr_effect;
  public  List<GameObject> list_effect;
    Animator anim;

    // Use this for initialization
    void Start()
    {
        audi = GetComponent<AudioSource>();


        GetComponent<Rigidbody2D>().isKinematic = true;
        list_effect = new List<GameObject>();
        anim = GetComponent<Animator>();
        curent_heatlth2 = heatlth2 ;
        for (int i = 0; i < nbr_effect; i++)
        {
            GameObject eff = (GameObject)Instantiate(effect);
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
      this.InvokeRepeating ("Appel_bossX",1.5f,2);
        
    }

    // Update is called once per frame
    void Update()
    {
     
      

    }

    public void damage()
    {
        int range = Random.Range(0, demage_sound.Length);
        AudioClip thiis = demage_sound[range];
        audi.PlayOneShot(thiis);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Finish" || other.tag == "Finish1")
        {
            anim.SetInteger("animstate", 1);

            damage();

            curent_heatlth2 -= 10;
            if (curent_heatlth2 <= 0 && donner == true)
            {
                // pour ne pas redonner largent

                donner = false;
                StartCoroutine("explosion");
                shake_camera.Chacknow(100f, 1f);

                // bash n3tiw floss l player
                for (int i = 0; i < nombredecoin; i++)
                {
                    var t = transform;
                    t.TransformPoint(0, -100, 0);


                    GameObject etem = coin[Random.Range(0, coin.Length)];
                    GameObject floss = (GameObject)Instantiate(etem, transform.position, Quaternion.identity);

                    var body2d = floss.GetComponent<Rigidbody2D>();
                    body2d.AddForce(Vector3.up * Random.Range(3000, 5000));
                    body2d.AddForce(Vector3.right * Random.Range(-1000, 1000));
                }
            }
            if (curent_heatlth2 > 0 )
	StartCoroutine("defalt_anim");
        }
     
    }

   

    IEnumerator explosion()
    {

        GetComponent<Rigidbody2D>().isKinematic = false;

        {
                Time.timeScale=0.5f;


            for (int i = 0; i < nbr_effect; i++)
            {
                yield return new WaitForSeconds(0.2f);
                Vector2 marge = new Vector2(Random.Range(-125, 125), Random.Range(-39, 100));
                Vector3 t = transform.position;
                Vector3 newpos = new Vector3(t.x + marge.x, t.y + marge.y, t.z);
                //GameObject	eff = (GameObject)Instantiate (effect, newpos, Quaternion.identity);

                if (!list_effect[i].activeInHierarchy)
                {
                    list_effect[i].SetActive(true);
                    list_effect[i].transform.position = newpos;
                    list_effect[i].transform.parent = transform;


                }
            }
                   StartCoroutine("load_scene");

        }
    }
    public void Appel_bossX ()
    {
              //pour faire instaiate fois droite fis gauche
                GameObject enmy = enmys[Random.Range(0, enmys.Length)];
                Instantiate(enmy, transform.position, Quaternion.identity);
            nombreenmy += 2;
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
