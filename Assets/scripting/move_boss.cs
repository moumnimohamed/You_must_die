using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_boss : MonoBehaviour {




    public float stoppos_haut;

    public float stopposright;
    public float stopposleft;

    public float speed2;  
    public float speed;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // ythark boss lfo9 .if wsal lwahd position yw9af
        transform.Translate(new Vector2(0, speed * Time.deltaTime));
        if (transform.position.y > stoppos_haut)
        {
            transform.position = new Vector2(transform.position.x, stoppos_haut);

            //hadi pour mover le boos ver la douche et la droite
            transform.Translate(new Vector2(speed2 * Time.deltaTime, 0));
            if (transform.position.x > stopposright)
            {
                transform.position = new Vector2(stopposright, transform.position.y);
                speed2 = speed2 *-1 ;

            }
            if (transform.position.x < stopposleft)
            {
                transform.position = new Vector2(stopposleft, transform.position.y);
                speed2 = speed2 * -1;
            }
        }
    }

   
}
