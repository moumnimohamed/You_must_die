using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class box_explosion : MonoBehaviour
{




    public GameObject bodyparts;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "saro" || coll.gameObject.tag == "Finish1" || coll.gameObject.tag == "Finish")
        {
            Onexploid();
            Destroy(coll.gameObject);
        }

    }
    void Onexploid()
    {
        Destroy(this.gameObject);
        var t = transform;
        for (int i = 0; i < 4; i++)
        {
            t.TransformPoint(0, -100, 0);

            var clone = Instantiate(bodyparts, t.position, Quaternion.identity) as GameObject;
            Destroy(gameObject);
            var body2d = clone.GetComponent<Rigidbody2D>();
            body2d.AddForce(Vector3.up * Random.Range(5000, 9000));
            body2d.AddForce(Vector3.right * Random.Range(-4000, 5000));
            Destroy(clone, 1);

        }
    }
}
