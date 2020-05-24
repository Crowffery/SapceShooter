using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{

    
    public  int speed = -10;

    // Update is called once per frame
    void Update()
    {
        
        Vector3 pickUPPosition = transform.position;
        pickUPPosition.x  += Time.deltaTime  * speed;
        transform.position = pickUPPosition;
    }

       void OnTriggerEnter(Collider collider)
    {
      

        if(collider.tag == "Player")
        {
           collider.GetComponent<PlayerController>().playerHealth ++;
           collider.GetComponent<PlayerController>().playerHP ++;
        

            Destroy(this.gameObject);


        }

    }

}
