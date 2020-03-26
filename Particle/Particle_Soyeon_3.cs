using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using extOSC;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;

public class Particle_Soyeon_3 : MonoBehaviour
{

    // Speed 
    //public float speed = 10;
    // Target (set by Tower)
    public GameObject target1;
    public GameObject target2;
    public GameObject target3;
    public GameObject bullet1;
    public GameObject bullet2;
    public GameObject bullet3;
    public GameObject bullet4;
    public GameObject bullet5;
    public GameObject bullet6;
    public GameObject bullet7;
    public GameObject bullet8;
    public GameObject bullet9;

    public GameObject tracking;


    //public float smooth = 4.0f;
    public AnimationCurve MoveCurve;
    private float animationTimePosition;
    public float betaScore;
    //public OSCReceiver Receiver;
    //public string deviceName = "Person0";
    private string address;
    public float beta_min = 0.8f;

    public float bulletSpeed;

    void Start()
    {
        //address = deviceName + "/elements/beta_session_score";
        Debug.Log(address);
    }

    void FixedUpdate()
    {
        //Receiver.Bind(address, ReceiveDoubleBeta);
        //RenderSettings.skybox.SetFloat("_Exposure", 0.2f);

        //OSC_Receiver_Soyeon oscreader = tracking.GetComponent<OSC_Receiver_Soyeon>();
        //betaScore= oscreader.betaScore;
        
        OSC_Receiver_Soyeon oscreader = tracking.GetComponent<OSC_Receiver_Soyeon>();
        betaScore = oscreader.betaScore;
        
        //betaScore = 1;
        //go to target

        if (target1 != null)
        {

            //Debug.Log("depress1_alive");

            if (betaScore > beta_min)
            {
                //for (int i =0; i<2; i++)
                //{
                bullet1.transform.position = Vector3.Lerp(bullet1.transform.position, target1.transform.position, MoveCurve.Evaluate(bulletSpeed));
                //yield return new WaitForSeconds(wait);
                //}
                //for (int i = 0; i < 2; i++)
                //{

                bullet2.transform.position = Vector3.Lerp(bullet2.transform.position, target1.transform.position, MoveCurve.Evaluate(bulletSpeed));
                //}
                //for(int i = 0; i < 2; i++)
                //{

                bullet3.transform.position = Vector3.Lerp(bullet3.transform.position, target1.transform.position, MoveCurve.Evaluate(bulletSpeed));
                //}

            }
        }
        else if (target2 != null)
        {

            if (betaScore > beta_min)
            {
                //if (Depress2_Soyeon.life == 3)
                //{

                bullet4.transform.position = Vector3.Lerp(bullet4.transform.position, target2.transform.position, MoveCurve.Evaluate(bulletSpeed));
                //yield return new WaitForSeconds(wait);
                //}
                //else if (Depress2_Soyeon.life == 2)
                //{
                bullet5.transform.position = Vector3.Lerp(bullet5.transform.position, target2.transform.position, MoveCurve.Evaluate(bulletSpeed));
                //}
                //else if (Depress2_Soyeon.life == 1)
                //{
                bullet6.transform.position = Vector3.Lerp(bullet6.transform.position, target2.transform.position, MoveCurve.Evaluate(bulletSpeed));
                //}

            }
        }
        else if (target3 != null)
        {
            //Debug.Log("depress3_alive");

            if (betaScore > beta_min)
            {
                //if (Depress3_Soyeon.life == 3)
                //{
                bullet7.transform.position = Vector3.Lerp(bullet7.transform.position, target3.transform.position, MoveCurve.Evaluate(bulletSpeed));
                //yield return new WaitForSeconds(wait);
                //}
                //else if (Depress3_Soyeon.life == 2)
                //{
                bullet8.transform.position = Vector3.Lerp(bullet8.transform.position, target3.transform.position, MoveCurve.Evaluate(bulletSpeed));
                //}
                //else if (Depress3_Soyeon.life == 1)
                //{
                bullet9.transform.position = Vector3.Lerp(bullet9.transform.position, target3.transform.position, MoveCurve.Evaluate(bulletSpeed));
                //}

            }

        }


    }

    /*public void ReceiveDoubleBeta(OSCMessage message)
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

    }*/
}