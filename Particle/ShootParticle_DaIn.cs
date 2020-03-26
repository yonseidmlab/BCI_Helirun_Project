using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using extOSC;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using UnityEngine.Events;

public class ShootParticle_DaIn : MonoBehaviour
{
    public GameObject bullet;

    public Particle_DaIn PD;

    void OnTriggerEnter(Collider co)
    {
        if (co)
        {
            Debug.Log("collided_bullet");
            Destroy(this);
            PD.isBulletFiring = false;
            Debug.Log("Shoot Particle isBulletFiring: " + PD.isBulletFiring);
        }
    }
}
