using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enmy_manager : MonoBehaviour {

 bool foix= false;
	// Use this for initialization
    public int nbr_enmy;
    public GameObject [] enmys;
    public Vector2 enmy_pos;

    public int nbr_bomb;
    public GameObject bomb;
    public Transform bomb_pos;
    public Vector2 add_posbombX;

    public int nbr_missile;
    public GameObject missile;
    public Transform missile_pos;
    public Vector2 add_posmissile;
    public GameObject attention_misille;
 
    public int nbr_boss2;
    public GameObject boss2;

    public int nbr_boss4;
    public GameObject boss4;

   

     public int nbr_starwar_ship;
    public GameObject starwar;
     public Vector3 starwar_pos;
  




    void Start()
    {

     // StartCoroutine("Appel_enmy");
      //  InvokeRepeating("appel_missile", 2f, 40f);
       
    }
	// Update is called once per frame
	void Update () {

 
	}

    public  IEnumerator  Appel_enmy (){

        yield return new WaitForSeconds(3f);
        int test =10;
        do
        {
            yield return new WaitForSeconds(1f);

            for (int i = 0; i < nbr_enmy; i++)
            {
                //pour faire instaiate fois droite fis gauche
                int nbr = Random.Range(0, 1);
                yield return new WaitForSeconds(0.9f);
                enmy_pos = new Vector2(nbr == 0 ? -enmy_pos.x : enmy_pos.x, enmy_pos.y);
                GameObject enmy = enmys[Random.Range(0, enmys.Length)];
                Instantiate(enmy, enmy_pos, Quaternion.identity);
                test -= 1;
            }
        } while (test >= 0);
        nbr_enmy += 5;
        StartCoroutine("Appel_starwar_ship");

    }


    public IEnumerator Appel_starwar_ship()
    {
        yield return new WaitForSeconds(10f);

        for (int i = 0; i < nbr_starwar_ship; i++)
        {
            Instantiate(starwar, starwar_pos , Quaternion.identity);
        }
        StartCoroutine("Appel_bomb");

        nbr_starwar_ship += 1;
    }


    public IEnumerator Appel_bomb() {

        yield return new WaitForSeconds(2f);

        for (int i = 0; i < nbr_bomb; i++)
        {
            yield return new WaitForSeconds(0.5f);

            add_posbombX = new Vector2(Random.Range(-add_posbombX.x + bomb_pos.position.x, add_posbombX.x
                                               + bomb_pos.position.x),  bomb_pos.position.y);
Instantiate(bomb, add_posbombX, Quaternion.identity);
        }
        yield return new WaitForSeconds(10f);

        StartCoroutine("Appel_boos2");

    
    }

   

    public IEnumerator Appel_boos2()
    {
        yield return new WaitForSeconds(2f);

        for (int i = 0; i < nbr_boss2; i++)
        {
         Instantiate(boss2,transform.position,Quaternion.identity);
        }
      //  StartCoroutine("Appel_boos4");
       
     
    }

    public IEnumerator Appel_boos4()
    {
        yield return new WaitForSeconds(10f);

        for (int i = 0; i < nbr_boss4; i++)
        {
         Instantiate(boss4, transform.position, Quaternion.identity);
        }
        StartCoroutine("Appel_enmy");


    }
   void OnTriggerEnter2D(Collider2D other)
   {
     
        if (other.tag == "Player" && foix==false){
         StartCoroutine("Appel_boos2");
         foix=true;
    }
    }
       }
