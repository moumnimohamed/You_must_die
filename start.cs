using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class start : MonoBehaviour {

    public string scene_name;

     AudioSource audi;

     void Start()
     {

         audi = GetComponent<AudioSource>();
     }
    public void load_scene()
    {
        if(audi !=null)
        audi.Play();
        SceneManager.LoadScene(scene_name);
        
    }
}
