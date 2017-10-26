using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_magicattack : MonoBehaviour
{

    GameObject nearest;
    //    الهدف الذي سنقوم بتتبعه// . 6
 public   GameObject[] allTargets;

  public  GameObject currentTarget ;
    void Start()
    {
        // بالبحث في كافة الأهداف عن أقربها إلينا
       allTargets = GameObject.FindGameObjectsWithTag("enmy");

        if (allTargets.Length > 0)
        {

            nearest = allTargets[0];

            foreach (GameObject t in allTargets)
            {
                // كان الهدف مصابا من قبل// . 20
                // نهتم لأمره// . 21

                // بين المقذوف// . 23//
                //t والهدف الحالي
                float distance = Vector2.Distance(transform.position, t.transform.position);

                // المسافة بين المقذوف// . 30
                //nearest والهدف الأقرب
                float minDistance = Vector2.Distance(transform.position, nearest.transform.position);

                // بتحديث قيمة الهدف الأقرب إن لزم الأمر// . 37
                if (distance < minDistance)
                {
                    nearest = t;
                }
            }
        }

        // الهدف الأقرب على أنه الهدف الحالي// . 44
        currentTarget = nearest;
    }

    // Update is called once per frame
    void Update()
    {
       
            // بتدوير المقذوف لينظر إلى الهدف الذي نتبع
          //  transform.LookAt(currentTarget.transform.position);
            transform.Translate(currentTarget.transform.position*Time.deltaTime);
        
    }
}
