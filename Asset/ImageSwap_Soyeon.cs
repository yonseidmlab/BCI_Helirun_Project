using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using extOSC;
using System.Linq;

public class ImageSwap_Soyeon : MonoBehaviour
{
    Image myImageComponent;
    public Sprite myFirstImage; //Drag your first sprite here in inspector.
    public Sprite mySecondImage; //Drag your second sprite here in inspector.
    public Sprite myThirdImage; 
    public Sprite myFourthImage; 
    public Sprite myFifthImage;

    //public GameObject heli;
    
    public float betaScore;
    public OSCReceiver Receiver;
    public string deviceName = "Person0";
    private string address;

 

    void Start() //Lets start by getting a reference to our image component.
    {
        myImageComponent = GetComponent<Image>(); //Our image component is the one attached to this gameObject.
        address = deviceName + "/elements/beta_session_score";
    }

    public void Update() 
    {
        //var pos = new Vector3(heli.transform.localPosition.x, heli.transform.localPosition.y-1, heli.transform.localPosition.z+50);
        //this.transform.position = Camera.main.ScreenToWorldPoint(pos);

        Receiver.Bind(address, ReceiveDoubleBeta);
        if (betaScore < 0.2)
        {
            this.GetComponent<SpriteRenderer>().sprite = myFirstImage;
        }
        else if (betaScore < 0.4)
        {
            this.GetComponent<SpriteRenderer>().sprite = mySecondImage;
        }
        else if (betaScore < 0.6)
        {
            this.GetComponent<SpriteRenderer>().sprite = myThirdImage;
        }
        else if (betaScore < 0.8)
        {
            this.GetComponent<SpriteRenderer>().sprite = myFourthImage;
        }
        else if (betaScore <= 1)
        {
            this.GetComponent<SpriteRenderer>().sprite = myFifthImage;
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
