using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using extOSC;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;

// This example shows setting a constant rate value.
public class HelirunMove_Person1_Soyeon : MonoBehaviour
{

    public OSCReceiver Receiver;
    public GameObject Heli;

    public float speed;

    public string deviceName;
    private string address;

    public float betaScore;

    public GameObject cameraMoving;
    public float limit;

    void Start()
    {
        address = deviceName + "/elements/beta_session_score";
       // cameraMoving = GameObject.Find("CM_Scene13-14");
        Receiver.Bind(address, ReceiveDoubleBeta);
    }
    
    void Update()
    {


        // float distCovered = (Time.time - startTime) * speed;
        // float fracJourney = distCovered / journeyLength;
        //transform.position = Vector3.Lerp(transform.position, targetItem.transform.position, fracJourney);
        Debug.Log(cameraMoving.transform.localPosition.y);

       if (betaScore > 0.3)
        {
            Heli.transform.position+= new Vector3(0,  betaScore* speed * Time.deltaTime, 0);
        }
        else
        {
            Heli.transform.position+= new Vector3 (0,  betaScore * speed *-1* Time.deltaTime,0);
        }
        
        //if (Heli.transform.position.y > cameraMoving.transform.localPosition.y)
            //Heli.transform.position = new Vector3(-6.5f, Heli.transform.localPosition.y +limit, 0);

        //if (Heli.transform.position.y < cameraMoving.transform.localPosition.y)
           // Heli.transform.position = new Vector3(-6.5f, Heli.transform.localPosition.y - limit, 0);

    }

 
    public void ReceiveDoubleBeta(OSCMessage message)
    {
        Debug.LogFormat("Received: {0}", message);
        if (address == "Person0/elements/beta_session_score")
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

