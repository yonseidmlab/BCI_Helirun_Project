using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using extOSC;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;

// This example shows setting a constant rate value.
public class HelirunMove_Jaewan : MonoBehaviour
{
    [Header("Device Settings")]

    #region Variable
    public OSCReceiver Receiver;
    public string deviceName = "Person1";

    public GameObject heli;
    //public GameObject follow;

    private string alphaAddress;
    private string betaAddress;

    [Header("Heli Control")]

    public float alphaScore;
    public float betaScore;
    //public float particleControl;

    #endregion

    void Start()
    {
        alphaAddress = deviceName + "/elements/alpha_session_score";
        betaAddress = deviceName + "/elements/beta_session_score";
        //Debug.Log(address);
        Receiver.Bind(alphaAddress, ReceiveDouble);
        Receiver.Bind(betaAddress, ReceiveDouble);

    }

    void Update()
    {
        // 밑에 줄 출력이 넘 많아서 잠시 코멘트아웃했습니다 - 다인
        //Debug.Log(transform.localPosition.y);

        float y = Remap(betaScore, 0, 1, 0, 5);

       this.transform.localPosition = new Vector3(transform.localPosition.x, y, transform.localPosition.z);

        //particleControl = Remap(betaScore, 0, 1, 0, 255);

    }
    public void ReceiveDouble(OSCMessage message)
    {
       // Debug.LogFormat("Received: {0}", message);
        if (alphaAddress == deviceName+"/elements/alpha_session_score")
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
        if (betaAddress == deviceName + "/elements/beta_session_score")
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

    float Remap(float s, float a1, float a2, float b1, float b2)
    {
        return b1 + (s - a1) * (b2 - b1) / (a2 - a1);
    }

}

