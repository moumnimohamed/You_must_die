using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy_automatique : MonoBehaviour {


    public float time_to_destroy;

    public void Update()
    {
        Destroy(gameObject, time_to_destroy);
    }

    
}
