using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class boss_4script : MonoBehaviour {



    public string scene_name;



 

    AudioSource audi;
    public AudioClip[] demage_sound;


    // pour donner l'argent juste ne fois
    public bool donner = true;

    public int heatlth = 100;
    public int curent_heatlth = 0;
    public float timetodestroy;
    public GameObject effect;
    // effect li 3ankhazno fih effect fi wa9t instantiation
    GameObject eff;

    public GameObject[] coin;
    public int nombredecoin;
  List<GameObject> list_coins;

    public int nbr_effect;
    List<GameObject> list_effect;
    public GameObject bulletHell;
    Animator anim;

    // Use this for initialization
    void Start()
    {
  

        audi = GetComponent<AudioSource>();

        GetComponent<Rigidbody2D>().isKinematic = true;
        list_effect = new List<GameObject>();
        anim = GetComponent<Animator>();
        curent_heatlth = heatlth;
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
    }

    // Update is called once per frame
    void Update()
    {

        timetodestroy += Time.deltaTime;



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
            damage();

            anim.SetInteger("animstate", 1);
            curent_heatlth -= 10;

            if (curent_heatlth <= 0 && donner==true)
            {
                
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
                donner = false;

            }
        }


    }
    void OnTriggerExit2D(Collider2D other)
    {

        if (other.tag == "Finish" || other.tag == "Finish1")
        {
            anim.SetInteger("animstate", 0);
            Destroy(other.gameObject);

        }

    }
    IEnumerator onfloos()
    {
        for (int i = 0; i < nombredecoin; i++)
        {
            yield return new WaitForSeconds(0.1f);

            var t = transform;
            t.TransformPoint(0, -100, 0);


            if (!list_coins[i].activeInHierarchy)
            {
                list_coins[i].SetActive(true);
                list_coins[i].transform.position = transform.position;
                var body2d = list_coins[i].GetComponent<Rigidbody2D>();
                body2d.AddForce(Vector3.up * Random.Range(3000, 5000));
                body2d.AddForce(Vector3.right * Random.Range(-1000, 1000));
            }
        }
    }
    IEnumerator explosion()
    {

        GetComponent<Rigidbody2D>().isKinematic = false;
        bulletHell.SetActive(false);

        {
             Time.timeScale=0.5f;
            for (int i = 0; i < nbr_effect; i++)
            {
                yield return new WaitForSeconds(0.2f);
                Vector2 marge = new Vector2(Random.Range(-30, 30), Random.Range(-20, 20));
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
      IEnumerator  load_scene ()
    {
    Debug.Log("i'am working moumni");
       yield return new WaitForSeconds(4f);
       
        SceneManager.LoadScene(scene_name);
        
    Debug.Log("i finish working moumni");
        
    }
}
