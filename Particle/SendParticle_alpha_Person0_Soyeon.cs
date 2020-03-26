using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using extOSC;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;

// This example shows setting a constant rate value.
public class SendParticle_alpha_Person0_Soyeon : MonoBehaviour
{
    ParticleSystem ps;
    ParticleSystem.EmissionModule emissionModule;
    public OSCReceiver Receiver;
    public float alphaScore;
  


    private const string address = "Person0/elements/alpha_relative";

    void Start()
    {
        // Get the system and the emission module.
        Receiver.Bind(address, ReceiveDoubleAlpha);

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
        float newEmissionRate = (float)alphaScore;
        emissionModule = ps.emission;
        ParticleSystem.MinMaxCurve tempCurve = emissionModule.rateOverTime;
        tempCurve.constant = newEmissionRate;
        emissionModule.rateOverTime = tempCurve;
    }


    public void ReceiveDoubleAlpha(OSCMessage message)
    {
        Debug.LogFormat("Received: {0}", message);
        if (address == "Person0/elements/alpha_relative")
        {
            string s = message.ToString();
            string[] sArray = s.Split('"');
            var alphas = new List <float>() {float.Parse(sArray[3]),float.Parse(sArray[5]),float.Parse(sArray[7]),float.Parse(sArray[9])};
            if (alphas.Contains(0))
            {
                alphas.RemoveAll(i => i == 0);
            }
            alphaScore =alphas.Average();    
        }

        Debug.Log(alphaScore);

    }

}

