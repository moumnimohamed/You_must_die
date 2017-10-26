using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enmy_projictile : MonoBehaviour
{


    void Start()
    {
        Invoke("Destroy", 2);
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Player")
        {

            this.gameObject.SetActive(false);

        }
    }
    void Destroy()
    {
        gameObject.SetActive(false);
    }
}