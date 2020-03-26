using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using extOSC;

// This example shows setting a constant rate value.
public class HelirunMove_Person0_gyro_Soyeon : MonoBehaviour
{

    public OSCReceiver Receiver;
    public GameObject Heli;
    public float x;
    public float y;
    public float z;
    public float forward;
    public float speed;
    Vector3 direction = new Vector3();
    private const string _gyroAddress = "Person0/gyro";

    void Start()
    {
        // Get the system and the emission module.
        Receiver.Bind(_gyroAddress, ReceiveXYZ);

        Update();
    }
    
    void Update()
    {

        Heli.transform.position += transform.forward * Time.deltaTime * speed;

    }

    public void ReceiveXYZ(OSCMessage message)
    {
        string s = message.ToString();
        print (s);
        string[] sArray = s.Split('"');
        x = float.Parse(sArray[3]);
        y = float.Parse(sArray[5]);
        z = float.Parse(sArray[7]);

    }
}

