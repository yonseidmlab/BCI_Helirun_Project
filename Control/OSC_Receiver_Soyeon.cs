using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using extOSC;
using System.Linq;

public class OSC_Receiver_Soyeon : MonoBehaviour
{
    public OSCReceiver Receiver;
    public string deviceName = "Person0";
    private string address_beta;
    private string address_alpha;
    public float betaScore;
    public float alphaScore;
private int num=0;
    
    void Start()
    {
        address_alpha = deviceName + "/elements/alpha_session_score";
        address_beta = deviceName + "/elements/beta_session_score";
      
    }

    // Update is called once per frame
    void Update()
    {
        Receiver.Bind(address_beta, ReceiveDoubleBeta);
        Receiver.Bind(address_alpha, ReceiveDoubleAlpha);
        Debug.Log(deviceName + "beta"+ betaScore);
        Debug.Log(deviceName+"alpha"+ alphaScore);
        num++;
        if (num==5){
        	Receiver.UnbindAll();
	        num=0;
        }
        
    }

   	public void ReceiveDoubleBeta(OSCMessage message)
    {
        // Debug.LogFormat("Received: {0}", message);
        if (address_beta == deviceName + "/elements/beta_session_score")
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
    public void ReceiveDoubleAlpha(OSCMessage message)
    {
        // Debug.LogFormat("Received: {0}", message);
        if (address_alpha == deviceName + "/elements/alpha_session_score")
        {
            string s = message.ToString();
            string[] sArray = s.Split('"');
            var betas = new List<float>() { float.Parse(sArray[3]), float.Parse(sArray[5]), float.Parse(sArray[7]), float.Parse(sArray[9]) };
            if (betas.Contains(0))
            {
                betas.RemoveAll(i => i == 0);
            }
            alphaScore = betas.Average();
        }

    }
}
