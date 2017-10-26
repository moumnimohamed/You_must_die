using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy_effect : MonoBehaviour {

	// Use this for initialization
    public float time_todestroy;
	void Start () {

        
	}
	
	// Update is called once per frame
	void Update () {
		if(this.gameObject.activeInHierarchy){
            Invoke("Destroyeffect", time_todestroy);
        }

	}
    void Destroyeffect()
    {
        this.gameObject.SetActive(false);
    }
}
