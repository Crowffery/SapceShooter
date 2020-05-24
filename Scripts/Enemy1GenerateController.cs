using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1GenerateController : MonoBehaviour
{

    public GameObject Enemy_1;

    public float respawnTime_E1;
    public float minTime_E1 = 4f;
    public float maxTime_E1 = 7f;







    void Start()
    {

        Invoke("Enemy_1Respawn", 1f);

    }



    public void Enemy_1Respawn()
    {
        respawnTime_E1 = Random.Range(minTime_E1, maxTime_E1);
        Instantiate(Enemy_1, transform.position + new Vector3(0, Random.Range(-30, 30), 0), Quaternion.identity);
        Invoke("Enemy_1Respawn", respawnTime_E1);

    }








}