using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using extOSC;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;

// This example shows setting a constant rate value.
public class SendParticle_beta_Person2_Soyeon : MonoBehaviour
{
    ParticleSystem ps;
    ParticleSystem.EmissionModule emissionModule;
    public OSCReceiver Receiver;
    public float betaScore;
  


    private const string address = "Person2/elements/beta_relative";

    void Start()
    {
        // Get the system and the emission module.
        Receiver.Bind(address, ReceiveDoubleBeta);

        ps = GetComponent<ParticleSystem>();
        var emissionModule = ps.emission;

        GetValue();
        Update();
    }

    void GetValue()
    {
        print("The constant value is " + emissionModule.rateOverTime.constant);
    }

    void Update()
    {
        float newEmissionRate = (float)betaScore;
        emissionModule = ps.emission;
        ParticleSystem.MinMaxCurve tempCurve = emissionModule.rateOverTime;
        tempCurve.constant = newEmissionRate;
        emissionModule.rateOverTime = tempCurve;
    }


    public void ReceiveDoubleBeta(OSCMessage message)
    {
        Debug.LogFormat("Received: {0}", message);
        if (address == "Person2/elements/beta_relative")
        {
            string s = message.ToString();
            string[] sArray = s.Split('"');
            var betas = new List <float>() {float.Parse(sArray[3]),float.Parse(sArray[5]),float.Parse(sArray[7]),float.Parse(sArray[9])};
            if (betas.Contains(0))
            {
                betas.RemoveAll(i => i == 0);
            }
            betaScore =betas.Average();    
        }

        Debug.Log(betaScore);

    }

}

