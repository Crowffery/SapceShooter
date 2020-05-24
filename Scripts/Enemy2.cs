using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{

    public int enemyHP = 2;
    public GameObject Bullet;
    public float fireRate = 2f;
    public float nextfire;
    public GameObject Explosion;
    public int speed = -45;

    public float timeToStay;

    void Start()
    {
        nextfire = Time.time;
        timeToStay = Random.Range(6, 12);
        Invoke("Stay",timeToStay);

    }

    void Update()
    {
        //enemy moving
        Vector3 enemyPosition = transform.position;
        enemyPosition.x += Time.deltaTime * speed;
        transform.position = enemyPosition;


        if (enemyHP <= 0)
        {
            Instantiate(Explosion, transform.position, new Quaternion(0, 0, 0, 1));
            Destroy(this.gameObject, 0f);

        }

        CheckIfTimeToFire();
    }
    void CheckIfTimeToFire()
    {
        if (Time.time > nextfire)
        {
            Instantiate(Bullet, transform.position, Quaternion.identity);


            nextfire = Time.time + fireRate;
        }
    }
    void Stay()
    {
        speed = 0;
    }

}
