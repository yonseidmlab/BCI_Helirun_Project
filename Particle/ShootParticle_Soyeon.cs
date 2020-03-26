using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using extOSC;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using UnityEngine.Events;


public class ShootParticle_Soyeon : MonoBehaviour
{

    public GameObject bullet;
    public GameObject depressNum1;
    public GameObject depressNum2;
    public GameObject depressNum3;
   
    void OnTriggerEnter(Collider co)
    {
       
        if (co.transform.gameObject == depressNum1)
        {
            Debug.Log("bullet collided with depress 1");
            Destroy(bullet);
        }
        else if (co.transform.gameObject == depressNum2)
        {
            Debug.Log("bullet collided with depress 2");
            Destroy(bullet);
        }
        else if (co.transform.gameObject == depressNum3)
        {
            Debug.Log("bullet collided with depress 3");
            Destroy(bullet);
        }
    }
   /* void OnTriggerEnter(Collider co)
    {
        if (co)
        {
            Debug.Log("collided_bullet");
            Destroy(bullet);
        }
    }*/


}