using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Generatiion : MonoBehaviour
{
    public GameObject Enemy_2;

    public float respawnTime_E2;
    public float minTime_E2 = 10f;
   public float maxTime_E2 = 20f;

   void Start(){


        Invoke("Enemy_2Respawn",10f);
   }


   
     public void  Enemy_2Respawn()
     {
        respawnTime_E2 = Random.Range(minTime_E2, maxTime_E2);
         Instantiate (Enemy_2, transform.position + new Vector3 (0,Random.Range(-30,30),0),Quaternion.identity);
        Invoke("Enemy_2Respawn",respawnTime_E2);

    }

}


