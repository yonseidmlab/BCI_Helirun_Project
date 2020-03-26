using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using extOSC;
using System;
using System.Linq;
using static System.Console;

public class Depress2_Soyeon : MonoBehaviour
{
    [Header("Unity Setup")]
    public ParticleSystem deathParticles;
    public GameObject Depress;
    public static bool enemyDead = false;

    public int life = 3;

    private float journeyLength;
    private float startTime;



    void OnTriggerEnter(Collider co)
    {
        //Health health = co.GetComponentInChildren<Health>();
        if (co)
        {
            Debug.Log("depress 2 collided");
            life = life - 1;
            print(life);


        }
        if (co && life == 0)
        {
            Instantiate(deathParticles, transform.position, Quaternion.identity);
            Debug.Log("DESTROY");
            enemyDead = true;
            Destroy(Depress);
            Debug.Log("depress 2 destroyed");
        }
    }
}
