using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using extOSC;
using System;
using System.Linq;
using static System.Console;

public class Depress_Particle_Soyeon : MonoBehaviour
{
    [Header("Unity Setup")]
    public ParticleSystem deathParticles;
	public OSCReceiver Receiver;
    public GameObject Depress;

    public int life;

    private float journeyLength;
    private float startTime;

    void OnTriggerEnter(Collider co) {
        //Health health = co.GetComponentInChildren<Health>();
        if (co)
        {
            Debug.Log("collided_depress");
            life = life - 1;
            print(life);
        }
        if (co && life == 0) {
            Instantiate(deathParticles, transform.position, Quaternion.identity);
            Debug.Log("DESTROY");
            Destroy (Depress);
        }
    }
}
