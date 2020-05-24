using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletController : MonoBehaviour
{
    // Start is called before the first frame update
    public float movingSpeed = 25f;
    public GameObject rocketTrail;
    public Transform enemyDamagedEffect;
    private GameObject player;


    private AudioSource audioSource;
    private GameObject audiocontroller;




    void Start()
    {
        Instantiate(rocketTrail, transform.position, transform.rotation);
        Destroy(this.gameObject, 4f);
        player = GameObject.Find("Player");
        audiocontroller = GameObject.Find("AudioController");
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();



    }

    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * movingSpeed);
    }

    void OnTriggerEnter(Collider collider)
    {

        if (collider.tag == "Enemy")
        {


            audiocontroller.GetComponent<ExplosionSound>().Enemy1Explosion();
            collider.GetComponent<Enemy>().enemyHP--;

            player.GetComponent<PlayerController>().playerScore += 100;

            Destroy(gameObject, 0f);

        }
        else if (collider.tag == "Enemy2")
        {

            audiocontroller.GetComponent<ExplosionSound>().Enemy2Explosion();
            Instantiate(enemyDamagedEffect, transform.position, Quaternion.identity);
            collider.GetComponent<Enemy2>().enemyHP--;

            player.GetComponent<PlayerController>().playerScore += 200;

            Destroy(gameObject, 0f);
        }

    }


}
