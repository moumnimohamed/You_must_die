using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class misille_lanser : MonoBehaviour {


   public int nbr_missile;
    public GameObject missile;
    public Transform missile_pos;
    public Vector2 add_posmissile;
 
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	/// <summary>
	/// Sent each frame where another object is within a trigger collider
	/// attached to this object (2D physics only).
	/// </summary>
	/// <param name="other">The other Collider2D involved in this collision.</param>
	void OnTriggerStay2D(Collider2D other)
	{
        if (other.tag == "Player" ){          
           InvokeRepeating("appel_missile", 2f, 40f);
		}
}
 public void appel_missile()
    {
        StartCoroutine("Appel_missile");
    }
 public IEnumerator Appel_missile()
    {
        yield return new WaitForSeconds(2f);
            add_posmissile = new Vector2(transform.position.x, Random.Range(-add_posmissile.y + missile_pos.position.y, add_posmissile.y
                                               + missile_pos.position.y));
            yield return new WaitForSeconds(0.5f);

            Instantiate(missile, add_posmissile, Quaternion.identity);
      
        nbr_missile += 1;
  }

}
