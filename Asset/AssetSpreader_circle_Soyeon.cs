 using UnityEngine;
 using System.Collections;
 
 public class AssetSpreader_circle_Soyeon : MonoBehaviour {
 
     public int numObjects;
     public GameObject prefab;
     public Vector3 center;
    public int r;
 
     void Start() {
         int rotate_y= Random.Range (0,80);
         for (int i = 0; i < numObjects; i++){
             Vector3 pos = transform.position = (Random.insideUnitSphere + center);
             pos= pos *r;
             Quaternion rot = Quaternion.Euler(0, rotate_y, 0);
             Instantiate(prefab, pos, rot);
         }
     }
 /*
     Vector3 RandomCircle ( Vector3 center ,   float radius  ){
         float ang = Random.value * 360;
         Vector3 pos;
         pos.x = center.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
         pos.y = center.y + radius * Mathf.Cos(ang * Mathf.Deg2Rad);
         pos.z = center.z;
         return pos;
     }
     */
 }