using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetSpreader_Jaewan : MonoBehaviour

{
    public int numberOfObjects; // number of objects to place
    private int currentObjects; // number of placed objects
    public GameObject[] objectToPlace; // GameObject to place
    /*
     * public int x_max;
    public int x_min;
    public int y_max;
    public int y_min;
    public int z_max;
    public int z_min;*/

    public Vector3 size;

    void Start()
    {
        //size = new Vector3(10f, 10f, 10f);
    }
    // Update is called once per frame
    void Update()
    {
        // 밑에 줄 출력이 넘 많아서 잠시 코멘트아웃했습니다 - 다인
        //Debug.Log(size);
        // generate objects
        if (currentObjects <= numberOfObjects)
        {
            for (int i = 0; i < objectToPlace.Length; i++)
            {

                // generate random x position
                float posx = Random.Range(-size.x / 2, size.x / 2) + transform.position.x;
                // generate random z position
                float posy = Random.Range(-size.y / 2, size.y / 2) + transform.position.y;
                // get the terrain height at the random position
                float posz = Random.Range(-size.z / 2, size.z / 2) + transform.position.z;

                Vector3 newPosition = new Vector3(posx, posy, posz);

                // 밑에 줄 출력이 넘 많아서 잠시 코멘트아웃했습니다 - 다인
                //Debug.Log(newPosition);
                int rotate_y = Random.Range(-40, 40);
                // create new gameObject on random position
                GameObject newObject = (GameObject)Instantiate(objectToPlace[i], newPosition, Quaternion.Euler(0, rotate_y, 0));
                newObject.transform.parent = gameObject.transform;
                // 잠깐 코멘트아웃 하겠습니다 - 다인
                //Debug.Log(transform.position);

                currentObjects += 1;
            }
            if (currentObjects == numberOfObjects)
            {
                Debug.Log("Generate objects complete!");
            }
        }
    }

    bool IsTooClose(GameObject x, Vector3 minimumDistance, List<GameObject> list)
    {
        if (list.Count == 0)
        {
            return false;
        }

        bool tooClose = false;

        foreach (var f in list)
        {
                if (Vector3.Distance(x.transform.position,f.transform.position) >Vector3.kEpsilon)
            {
                tooClose = true;
                break;
            }
        }

        return tooClose;
    }
}



