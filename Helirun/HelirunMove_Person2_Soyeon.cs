using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using extOSC;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;

// This example shows setting a constant rate value.
public class HelirunMove_Person2_Soyeon : MonoBehaviour
{

    public OSCReceiver Receiver;
    public GameObject Heli;

    public float speed;
    
    private const string address = "Person2/elements/beta_session_score";

    public float betaScore;
    
    public float highLimit;
    public float lowLimit;

    void Start()
    {
        Receiver.Bind(address, ReceiveDoubleBeta);
    }
    
    void Update()
    {


       // float distCovered = (Time.time - startTime) * speed;
       // float fracJourney = distCovered / journeyLength;
        //transform.position = Vector3.Lerp(transform.position, targetItem.transform.position, fracJourney);

        if (betaScore > 0.3)
        {
            Heli.transform.position += (Vector3.up * speed * Time.deltaTime);
        }
        else
        {
            Heli.transform.position+= (Vector3.up * -1 * speed * Time.deltaTime);
        }

        if (Heli.transform.position.y > highLimit)
            Heli.transform.position = new Vector3(Heli.transform.position.x, 103, Heli.transform.position.z);

        if (Heli.transform.position.y < lowLimit)
            Heli.transform.position = new Vector3(Heli.transform.position.x, 83, Heli.transform.position.z);

    }

 
    public void ReceiveDoubleBeta(OSCMessage message)
    {
        Debug.LogFormat("Received: {0}", message);
        if (address == "Person2/elements/beta_session_score")
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

