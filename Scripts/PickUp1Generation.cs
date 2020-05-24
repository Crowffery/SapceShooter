using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp1Generation : MonoBehaviour
{

    
    public GameObject PickUp_1;
    public float respawnTime_P1;
    public float minTime_P1 = 30f;
   public float maxTime_P1 = 40f;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("PickUp_1Respawn",10f);
    }

    // Update is called once per frame
  public void  PickUp_1Respawn()
     {
        respawnTime_P1 = Random.Range(minTime_P1, maxTime_P1);
        Instantiate (PickUp_1, transform.position + new Vector3 (0,Random.Range(-8,8),0),Quaternion.identity);
        Invoke("PickUp_1Respawn",respawnTime_P1);

    }

}
