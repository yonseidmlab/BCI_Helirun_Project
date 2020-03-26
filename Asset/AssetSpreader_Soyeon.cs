using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetSpreader_Soyeon : MonoBehaviour

{
    public int numberOfObjects; // number of objects to place
    private int currentObjects; // number of placed objects
    public GameObject[] objectToPlace; // GameObject to place
    public int x_max;
    public int x_min;
    public int y_max;
    public int y_min;
    public int z_max;
    public int z_min;


    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
    // generate objects
    if(currentObjects <= numberOfObjects)
    {
        // generate random x position
        int posx = Random.Range(x_min, x_max);
        // generate random z position
        int posz = Random.Range(z_min, z_max);
        // get the terrain height at the random position
        float posy = Random.Range (y_min, y_max);
        int rotate_y= Random.Range (0,80);
        // create new gameObject on random position
        for(int i=0; i < objectToPlace.Length; i++)
        {
            GameObject newObject = (GameObject)Instantiate(objectToPlace[i], new Vector3(posx, posy, posz), Quaternion.Euler(0, rotate_y, 0));
              //newObject.transform.parent = gameObject.transform;
        }
        currentObjects += 1;
    }
        if(currentObjects == numberOfObjects)
        {
            Debug.Log("Generate objects complete!");
        }
    }
}



