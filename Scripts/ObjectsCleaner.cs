using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsCleaner : MonoBehaviour
{
     void OnTriggerEnter(Collider collider)
     {
         if(collider.tag == "Monster")
         {
             Destroy(collider.gameObject, 0f);
             Debug.Log("monster is destroied");
         }
     }
   
}
