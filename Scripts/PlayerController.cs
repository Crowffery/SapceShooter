using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    
    public float movingSpeed = 10f;

    
    public Transform rocket;

    public LayerMask whatToHit;

    

    public Transform rocketBullet;
    private Rigidbody rb;


    public float playerHealth = 6;
    public float playerHP= 6;
    public int playerScore = 0;
    public float fireRate = 0;
    public float timeToFire = 0;

    	float timeToSpawnEffect = 0;
	public float effectSpawnRate = 10;

    public Transform hpbar;

    public Text displayPlayerScore;
    public GameObject gameOver;
    public GameObject backgroundPanel;
    public GameObject restart;
    public Transform explosionEffect;
    public GameObject Quit;
    private SpriteRenderer HP_hp;
    public Joystick joystick;
    private GameObject mainCam;

    private Animator playerAnim;

    private GameObject ObjectGenerateController;

    private float moveHorizontalPC;
    private float moveVerticalPC;

    public GameObject lowHealthParticle;


    void Start()
    {
        mainCam = GameObject.Find("Main Camera");
        HP_hp = hpbar.GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody>();
        playerHP = playerHealth;

        gameOver.SetActive(false);
        backgroundPanel.SetActive(false);
        
        restart.SetActive(false);
        Quit.SetActive(false);
        joystick.gameObject.SetActive(true);
        ObjectGenerateController = GameObject.Find("ObjectGenerateController");

        playerAnim = GetComponentInChildren<Animator>();

        lowHealthParticle.SetActive(false);








    }

    // Update is called once per frame
    void Update()
    {

        Wave();

        
        hpbar.transform.localScale = new Vector3( playerHealth /playerHP ,1.0f,1.0f);
        if(playerHealth<=3)
        {
            HP_hp.color = Color.red;
        }
        else
        {
            HP_hp.color = Color.white;
        }

        
        displayPlayerScore.text = "Score:" + playerScore.ToString();


        
        if(fireRate == 0)
        {
            if (Input.GetKeyDown(KeyCode.Space ) ) 
            {

                Shoot();

            }

        }
        else
        {
            if(Input.GetKeyDown(KeyCode.Space )  && Time.time >timeToFire)
            {
                timeToFire = Time.time + 1/fireRate;
                Shoot();
            }
        }
        

        if(playerHealth <= 0)
        {
            Time.timeScale = 0;

            gameOver.SetActive(true);
            backgroundPanel.SetActive(true);
            restart.SetActive(true);
            Quit.SetActive(true);
            joystick.gameObject.SetActive(false);

            Destroy(gameObject,0f);

        }

        playerAnim.SetFloat("VelY", moveVerticalPC);
        Debug.Log("The value is" + moveVerticalPC);

        if(playerHealth <= 2)
        {
            lowHealthParticle.SetActive(true);
        }
        else
        {
            lowHealthParticle.SetActive(false);
        }

  
    }
    
    
    
    void FixedUpdate()
    {
         float moveHorizontal = joystick.Horizontal;
         float moveVertical = joystick.Vertical;

        moveHorizontalPC = Input.GetAxis("Horizontal");
         moveVerticalPC = Input.GetAxis("Vertical");



        rb.velocity = new Vector3 (moveHorizontalPC, moveVerticalPC, 0) * movingSpeed;

        
        if ( joystick.Horizontal >= 0.2f || joystick.Horizontal <= -0.2f)
        {
            rb.velocity = new Vector3 (moveHorizontal, moveVertical, 0) * movingSpeed;
        }
        
        else if( joystick.Vertical >= 0.2f || joystick.Vertical <= -0.2f)
        {
            rb.velocity = new Vector3 (moveHorizontal, moveVertical, 0) * movingSpeed;
        }
  
        
    }
    
    public void Shoot()
    {

        if (Time.time >= timeToSpawnEffect)
        {
		    Effect ();
		    timeToSpawnEffect = Time.time + 1/effectSpawnRate;
		}

  
    }
    void Effect()
    {
        Instantiate(rocketBullet, rocket.position ,rocket.rotation);
    }





     public void PowerUp()
     {
    
            //for pickup2
        transform.GetChild(3).gameObject.SetActive(true);
        movingSpeed += 10;
        fireRate ++;
        effectSpawnRate ++;
        Invoke("DePowerup", 20f);

 
         
  

     }
     public void DePowerup()
     {
                Debug.Log("decrease!!!!!!!");
        transform.GetChild(3).gameObject.SetActive(false);
        movingSpeed -= 10;
        fireRate --;
        effectSpawnRate --;
     }
    public void Wave()
{
    var s15000 = false;
    var s30000 = false;
    var s50000 = false;
    var s75000 = false;
    var s100000 = false;
    var s150000 = false;

  
        if(playerScore  == 15000 && s15000== false)
        {
            ObjectGenerateController.transform.GetComponent<Enemy1GenerateController>().maxTime_E1 -=0.5f;
            s15000 = true;
            

        }else if(playerScore  == 30000 && s30000== false)
        {
            ObjectGenerateController.transform.GetComponent<Enemy2Generatiion>().maxTime_E2  -= 1;
            s30000 = true;
        }
        else if(playerScore  == 50000 && s50000== false)
        {
            ObjectGenerateController.transform.GetComponent<Enemy1GenerateController>().maxTime_E1 -=0.5f;
            s50000 = true;

        }
        else if(playerScore  == 75000 && s75000== false)
        {
            
            ObjectGenerateController.transform.GetComponent<Enemy2Generatiion>().minTime_E2  -= 1;
            s75000 = true;
        }
        else if(playerScore == 100000 && s100000== false)
        {
            ObjectGenerateController.transform.GetComponent<Enemy1GenerateController>().maxTime_E1 -=0.5f;
            s100000 = true;
            
        }
        else if(playerScore == 150000 && s150000== false)
        {
            ObjectGenerateController.transform.GetComponent<Enemy2Generatiion>().minTime_E2  -= 1;
            ObjectGenerateController.transform.GetComponent<Enemy2Generatiion>().maxTime_E2  -= 1;
            s150000 = true;
        }









}
    void OnTriggerEnter(Collider collider)
    {
      

        if(collider.tag == "Enemy" || collider.tag == "Enemy2")
        {
            mainCam.transform.GetComponent<CameraShake>().ShakeIt();
            playerHealth--;

            
            Instantiate(explosionEffect, transform.position, Quaternion.identity);



        }


    }
    


    
}
