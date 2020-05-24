using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2BulletController : MonoBehaviour
{
    Rigidbody rb;
    public float movingSpeed = 25f;

    private Vector3 moveDirection;
    public Transform rocketTrail;
    public Transform playerDamagedEffect;
    public bool isPassingby = false;
    private GameObject mainCam;
    public GameObject player;

    void Awake()
    {
        player = GameObject.Find("Player");
    }
    void Start()
    {
        mainCam = GameObject.Find("Main Camera");
        Instantiate(rocketTrail, transform.position, transform.rotation);

        Destroy(this.gameObject, 4f);
        
        rb = GetComponent<Rigidbody>();
        

        if (player.transform.position.x < transform.position.x)
        {
            moveDirection = (player.transform.position - transform.position).normalized * movingSpeed;
        }
        else
        {
            Destroy(this.gameObject, 0f);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (moveDirection.x < 0)
        {
            transform.Translate(Vector3.left * Time.deltaTime * movingSpeed);
            rb.velocity = new Vector3(moveDirection.x+5, moveDirection.y, moveDirection.z);
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            Debug.Log("bullet got the Player!!");
            //call function from 
            collider.GetComponent<PlayerController>().playerHealth--;
            mainCam.transform.GetComponent<CameraShake>().ShakeIt();
            Instantiate(playerDamagedEffect, transform.position, Quaternion.identity);
            Destroy(gameObject, 0f);
        }
    }
}
