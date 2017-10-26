using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enmy_shoot_now : MonoBehaviour {

    public GameObject fire_magic;
    public GameObject fire_magic_pos;

    public enmy_jet_attack  enmy_jetattack;

	public float velocity;
	public GameObject bullet; 
	public GameObject shoots_pos; 
	GameObject furball;
	private float timetoshot;
	List<GameObject> bullets;

	// Use this for initialization
	void Start () {
        enmy_jetattack= GetComponent <enmy_jet_attack>();
		bullets= new List<GameObject>();
        for (int i = 0; i < 1; i++)
        {
            furball = (GameObject)Instantiate(bullet);
            furball.SetActive(false);
            bullets.Add(furball);
        }
	}
	
	// Update is called once per framess
	void Update () {
	}
    public void shotnow()
    {


        foreach (GameObject fb in bullets)
        {
            if (!fb.activeInHierarchy)
            {

                fb.transform.position = shoots_pos.transform.position;
                fb.transform.rotation = shoots_pos.transform.rotation;
                fb.SetActive(true);
                fb.GetComponent<Rigidbody2D>().velocity = new Vector2(velocity * transform.localScale.x, 0);

                Invoke("Enmy_shot_desable", 5f);
                

            }

        }
    }
	public	void shotnowTow () {

        foreach (GameObject fb in bullets)
        { 
        
			if (!fb.activeInHierarchy) {

				fb.transform.position =shoots_pos. transform.position;
				fb.transform.rotation =shoots_pos. transform.rotation;
                fb.transform.parent = transform;
				fb.SetActive (true);
			fb.GetComponent<Rigidbody2D> ().velocity = new Vector2 (velocity * transform.localScale.x, 0);
            Invoke("Enmy_shot_desable", 5f);

		}
	
	}
    }

    public void shot_sarokh()
    {
      if(enmy_jetattack.gotIt){
        GameObject sarokh = (GameObject)Instantiate(fire_magic, fire_magic_pos.transform.position, Quaternion.identity);
        Destroy(sarokh, 10f);
    }
    }


 void   Enmy_shot_desable(){
     foreach (GameObject fb in bullets)
     { 

          if(fb.activeInHierarchy)
        fb.SetActive(false);
    }
 }
}