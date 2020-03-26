using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using extOSC;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;

public class Particle_Soyeon : MonoBehaviour
{

    // Speed
    //public float speed = 10;
    // Target (set by Tower)
    public Transform target1;
    public Transform target2;
    public Transform target3;
    public GameObject bullet;

    //public float smooth = 4.0f;
    public AnimationCurve MoveCurve;
    private float animationTimePosition;
    public float betaScore;
    public OSCReceiver Receiver;
    public string deviceName = "Person0";
    private string address;
    private GameObject cloneBullet;
    public float beta_min = 0.8f;

    public float bulletSpeed;
    public float Timer = 2;


    void Start()
    {
        address = deviceName + "/elements/beta_session_score";
    }

    void FixedUpdate()
    {
        Receiver.Bind(address, ReceiveDoubleBeta);
      
        //RenderSettings.skybox.SetFloat("_Exposure", 0.2f);


        //go to target
        if (betaScore > beta_min)
        {
            //Debug.Log("Particle_Soyeon found target");
            //Mathf.Sin(Time.time * Mathf.Deg2Rad * 100) + 1
            cloneBullet = Instantiate(bullet, bullet.transform.position, Quaternion.identity);

            for (int i=0; i<3;i++)
            {
                
                //cloneBullet = Instantiate(bullet, bullet.transform.position, Quaternion.identity);
                //ShootParticle_Soyeon.firing = true;
                //Debug.Log("depress1_alive");
                // bulletSpeed로 나누는걸 추가함 - 다인
                animationTimePosition += Time.deltaTime;
                cloneBullet.transform.position = Vector3.Lerp(cloneBullet.transform.position, target1.position, MoveCurve.Evaluate(animationTimePosition / bulletSpeed));
                Debug.Log(target1.position);
            }
            for (int i = 0; i < 3; i++)
            {
                //cloneBullet = Instantiate(bullet, bullet.transform.position, Quaternion.identity);
                //ShootParticle_Soyeon.firing = true;
                //Debug.Log("depress2_alive");
                animationTimePosition += Time.deltaTime;
                cloneBullet.transform.position = Vector3.Lerp(cloneBullet.transform.position, target2.position, MoveCurve.Evaluate(animationTimePosition / bulletSpeed));
            }
            for (int i = 0; i < 3; i++)
            {
                //cloneBullet = Instantiate(bullet, bullet.transform.position, Quaternion.identity);
                //ShootParticle_Soyeon.firing = true;
                //Debug.Log("depress3_alive");
                animationTimePosition += Time.deltaTime;
                cloneBullet.transform.position = Vector3.Lerp(cloneBullet.transform.position, target3.position, MoveCurve.Evaluate(animationTimePosition / bulletSpeed));
            }

        }
    }

    public void ReceiveDoubleBeta(OSCMessage message)
    {
        // Debug.LogFormat("Received: {0}", message);
        if (address == deviceName + "/elements/beta_session_score")
        {
            string s = message.ToString();
            string[] sArray = s.Split('"');
            var betas = new List<float>() { float.Parse(sArray[3]), float.Parse(sArray[5]), float.Parse(sArray[7]), float.Parse(sArray[9]) };
            if (betas.Contains(0))
            {
                betas.RemoveAll(i => i == 0);
            }
            betaScore = betas.Average();
        }

    }
}