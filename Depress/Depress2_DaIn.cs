using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Depress2_DaIn : MonoBehaviour
{
    [Header("Unity Setup")]
    public ParticleSystem deathParticles;
    public GameObject Depress;
    public static bool enemyDead = false;
    public int life;
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
            enemyDead = true;
            Destroy(Depress);
            Debug.Log("depress 2 destroyed");
        }
    }
}
