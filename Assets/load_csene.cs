using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class load_csene : MonoBehaviour {

    public string scene_name;

	  public void  load_scene ()
    {
       
        SceneManager.LoadScene(scene_name);        
    }
}
