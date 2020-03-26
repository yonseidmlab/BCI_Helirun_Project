// Floater v0.0.2
// by Donovan Keith
//
// [MIT License](https://opensource.org/licenses/MIT)

using UnityEngine;
using System.Collections;

// Makes objects float up & down while gently spinning.
public class Floater_Soyeon : MonoBehaviour
{
    // User Inputs
   // public float degreesPerSecond = 15.0f;
    public float amplitude_max;
    public float amplitude_min;
    public float frequency_max;
    public float frequency_min;

    private float frequency;
    private float amplitude;


    // Position Storage Variables
    Vector3 posOffset = new Vector3();
    Vector3 tempPos = new Vector3();

    // Use this for initialization
    void Start()
    {
        frequency = Random.Range(frequency_min, frequency_max);
        amplitude = Random.Range(amplitude_min, amplitude_max);

        // Store the starting position & rotation of the object
        posOffset = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Spin object around Y-Axis
        //transform.Rotate(new Vector3(0f, Time.deltaTime * degreesPerSecond, 0f), Space.World);

        // Float up/down with a Sin()
        tempPos = posOffset;
        tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;

        transform.position = tempPos;
    }
}
