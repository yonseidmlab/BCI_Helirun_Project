using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class PlayControl : MonoBehaviour
{
    public PlayableDirector director;
    public float[] TimePoint; 
    //float time = 3;
    bool isLooping = true;
    bool isPlaying = true;



    // Start is called before the first frame update
    void Start()
    {
        /*TimePoint[0] = 0;
        TimePoint[1] = 3;
        TimePoint[2] = 10;
        TimePoint[3] = 75;
        TimePoint[4] = 105;
        TimePoint[5] = 130;
        TimePoint[6] = 150;
        TimePoint[7] = 171;
        TimePoint[8] = 240;
        TimePoint[9] = 288;*/

    }


    // Update is called once per frame
    void Update()
    {
        if (director.time > TimePoint[1] && isLooping == true)
        {
            director.time = 0;
        }

        else if (Input.GetKeyUp(KeyCode.L))
        {
            isLooping = false;
        }

        if (isPlaying)
        {
            if (Input.GetKeyDown(KeyCode.Space))//pause
            {
                director.Pause();
                isPlaying = false;
                Debug.Log("Pause");
            }
        }

        else if (!isPlaying)
        {
            if (Input.GetKeyDown(KeyCode.Space)) //play
            {
                director.Play();
                isPlaying = true;
                Debug.Log("Play");
            }
        }


        /*if (Input.GetKeyUp(KeyCode.Space))//pause
            {
                director.Pause();
            }

        if (Input.GetKeyUp(KeyCode.Space))//play
            {
                director.Play();
            }
        */

        for (int i = 0; i < 10; i++)  //jump
        {
            if (director.time - TimePoint[i] < 0)
            {
                if (Input.GetKeyUp(KeyCode.D))//next scene              
                {
                    director.time = TimePoint[i];
                    //director.Play();
                }

                if (Input.GetKeyUp(KeyCode.A))//front scene
                {
                    director.time = TimePoint[i - 2];
                    // director.time = director.time - 2f;
                    //director.Play();
                }
                break;
            }
        }
    }
}
