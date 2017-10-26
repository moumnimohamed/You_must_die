using System.Collections;
using System.Collections.Generic;
using UnityEngine;

  public class shake_camera : MonoBehaviour {

  static  public float shaketimer;
  static  public float shakeamount;

  static public GameObject player;
  public GameObject playerr ;
	// Use this for initialization
  void Start() {


  }
	
	// Update is called once per frame
	void Update () {

        playerr = GameObject.FindGameObjectWithTag("Player");
        player = playerr;

        if (player != null)
        {
            if (shaketimer >= 0)
            {
                Vector2 shakepos = Random.insideUnitCircle * shakeamount;
                transform.position = new Vector3(transform.position.x + shakepos.x, shakepos.y, transform.position.z);
                shaketimer -= Time.deltaTime;
            }
        }
	}

    public static void Chacknow(float shakepwr, float shakedur)
    {
       
            shakeamount = shakepwr;
            shaketimer = shakedur;
        
    }
}
