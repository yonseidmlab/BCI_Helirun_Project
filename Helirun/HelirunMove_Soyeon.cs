using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
//using extOSC;
using System.Collections;
using System;
using System.Linq;

// This example shows setting a constant rate value.
public class HelirunMove_Soyeon : MonoBehaviour
{
    [Header("Device Settings")]

    #region Variable
    //public OSCReceiver Receiver;
    public string deviceName = "Person0";

    public GameObject heli;
    //public GameObject follow;

    private string addressAlpha;
    private string addressBeta;
    private float _animationTimePosition;

    [Header("Heli Control")]
    public float betaScore;
    public float alphaScore;
    public float smooth = 4.0f;
    public ParticleSystem[] AlphaPSs;
    public ParticleSystem[] BetaPSs;

    public GameObject tracking;


    #endregion

    /*public void ReceiveDoubleAlpha(OSCMessage message)
    {
        // Debug.LogFormat("Received: {0}", message);
        if (addressAlpha == deviceName + "/elements/alpha_session_score")
        {
            string s = message.ToString();
            string[] sArray = s.Split('"');
            var alphas = new List<float>() { float.Parse(sArray[3]), float.Parse(sArray[5]), float.Parse(sArray[7]), float.Parse(sArray[9]) };
            if (alphas.Contains(0))
            {
                alphas.RemoveAll(i => i == 0);
            }
            alphaScore = alphas.Average();
        }

    }
    public void ReceiveDoubleBeta(OSCMessage message)
    {
        // Debug.LogFormat("Received: {0}", message);
        if (addressBeta == deviceName + "/elements/beta_session_score")
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
    //ParticleSystem.MainModule main;
    public float Remap(float s, float a1, float a2, float b1, float b2)
    {
        return b1 + (s - a1) * (b2 - b1) / (a2 - a1);
    }


    void Start()
    {
        //addressAlpha = deviceName + "/elements/alpha_session_score";
        //addressBeta = deviceName + "/elements/beta_session_score";
        // Debug.Log(address);
        //AlphaPSs = GameObject.Find("alphaParticlePrefab").GetComponentsInChildren<ParticleSystem>();
        //BetaPSs = GameObject.Find("betaParticlePrefab").GetComponentsInChildren<ParticleSystem>();
        AlphaPSs = transform.Find("alphaParticlePrefab").GetComponentsInChildren<ParticleSystem>();
        BetaPSs = transform.Find("betaParticlePrefab").GetComponentsInChildren<ParticleSystem>();

    }

    void Update()
    {
        // float distCovered = (Time.time - startTime) * speed;
        // float fracJourney = distCovered / journeyLength;
        //transform.position = Vector3.Lerp(transform.position, targetItem.transform.position, fracJourney);
        // 밑에 줄 출력이 넘 많아서 잠시 코멘트아웃했습니다 - 다인
        //Debug.Log(heli.transform.localPosition.y);
        //Receiver.Bind(addressAlpha, ReceiveDoubleAlpha);
        //Receiver.Bind(addressBeta, ReceiveDoubleBeta);

        OSC_Receiver_Soyeon oscreader = tracking.GetComponent<OSC_Receiver_Soyeon>();
        betaScore = oscreader.betaScore;
        alphaScore = oscreader.alphaScore;

        float y = Remap(betaScore, 0, 0.5f, 0, 4);
        Vector3 newVector = new Vector3(heli.transform.localPosition.x, y, heli.transform.localPosition.z);
        heli.transform.localPosition = Vector3.Lerp(transform.localPosition, newVector, Time.deltaTime * smooth);
        /*
         *_animationTimePosition += Time.deltaTime;
        Vector3 newVector = new Vector3(transform.localPosition.x, y, transform.localPosition.z, MoveCurve.Evaluate(_animationTimePosition));
         heli.transform.position = Vector3.Lerp(transform.position, newVector);
         */

        //if (Heli.transform.position.y > cameraMoving.transform.localPosition.y)
        //Heli.transform.position = new Vector3(-6.5f, Heli.transform.localPosition.y +limit, 0);

        //if (Heli.transform.position.y < cameraMoving.transform.localPosition.y)
        // Heli.transform.position = new Vector3(-6.5f, Heli.transform.localPosition.y - limit, 0);
        foreach (var main in AlphaPSs)
        {
            main.startSize = alphaScore;
            main.playbackSpeed = alphaScore;
            Debug.Log("alpha startSize:  " + main.startSize);

        }
        foreach (var main in BetaPSs)
        {
            main.startSize = betaScore;
            main.playbackSpeed = betaScore;
            Debug.Log("beta startSize:  " + main.startSize);
            //Debug.Log("startSize: " + main.startSize + "                    betaSccore : " +betaScore);

        }
    }
}
