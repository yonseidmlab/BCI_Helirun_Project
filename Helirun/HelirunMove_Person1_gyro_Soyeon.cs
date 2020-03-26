using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using extOSC;

// This example shows setting a constant rate value.
public class HelirunMove_Person1_gyro_Soyeon : MonoBehaviour
{

    public OSCReceiver Receiver;
    public GameObject Heli;
    public float x;
    public float y;
    public float z;
    Vector3 direction = new Vector3();
    private const string _gyroAddress = "Person1/gyro";

    void Start()
    {
        // Get the system and the emission module.
        Receiver.Bind(_gyroAddress, ReceiveXYZ);

        //Update();
    }

    void Update()
    {
        //float x_n = Mathf.Clamp(x,-1,1);
        //float y_n = Mathf.Clamp(y,-1,1);
        direction = new Vector3(x, y, 0.0f);

        if (direction.x > 50)
            x = 50;
        if (direction.x < 30)
            x = 30;
        if (direction.y > 20)
            y = 20;
        if (direction.y < -20)
            y = -20;
        direction = new Vector3(x, y, 0.0f);

        Heli.transform.position = direction;
    }

    public void ReceiveXYZ(OSCMessage message)
    {
        string s = message.ToString();
        print(s);
        string[] sArray = s.Split('"');
        x = float.Parse(sArray[3]);
        y = float.Parse(sArray[5]);
        z = float.Parse(sArray[7]);

    }
}

