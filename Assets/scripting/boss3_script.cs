using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss3_script : MonoBehaviour
{


    public GameObject[] coin;
    public int nombredecoin;
  List<GameObject> list_coins;
    // pour donner l'argent juste ne fois
  public bool donner = true;

    public int heatlth = 100;
    public int curent_heatlth = 0;
    public float timetodestroy;
    public GameObject effect;
    // effect li 3ankhazno fih effect fi wa9t instantiation
    GameObject eff;

    public int nbr_effect;
    List<GameObject> list_effect;
  public  GameObject bulletHell;
    Animator anim;

    // Use this for initialization
    void Start()
    {
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
    void OnTriggerEnter2D(Collider2D other)
    {



        if (other.tag == "bullet" || other.tag == "bullet2")
        {

            anim.SetInteger("animstate", 1);
            curent_heatlth -= 10;
            if (curent_heatlth <= 0 && donner == true)
            {
                // pour ne pas redonner largent

                donner = false;
                StartCoroutine("explosion");

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
        }



    }
    void OnTriggerExit2D(Collider2D other)
    {

        if (other.tag == "bullet" || other.tag == "bullet2")
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
        bulletHell.SetActive (false);

        {
            for (int i = 0; i < nbr_effect ; i++)
            {
                yield return new WaitForSeconds(0.2f);
                Vector2 marge = new Vector2(Random.Range(-155, 155), Random.Range(-60, 80));
                Vector3 t = transform.position;
                Vector3 newpos = new Vector3(t.x + marge.x, t.y + marge.y, t.z);
                //GameObject	eff = (GameObject)Instantiate (effect, newpos, Quaternion.identity);

                if (!list_effect[i].activeInHierarchy)
                {
                    list_effect[i].SetActive(true);
                    list_effect[i].transform.position = newpos;
                    list_effect[i].transform.parent = transform;

                    gameObject.GetComponent<move_boss>().enabled = false;
                  
                                  }
            }
            Destroy(gameObject);
        }
    }
}
    
