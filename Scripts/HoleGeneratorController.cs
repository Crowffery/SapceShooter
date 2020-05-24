using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HoleGeneratorController : MonoBehaviour
{

public static HoleGeneratorController holeGeneratorController;


    




public int startMinNum = 3; // minum number of cubes that the holes are randomly generated  start with
public int startMaxNum = 40; // minum number of cubes that the holes are randomly generated start with



public int amountMin = 4; //  minum amount of cubes to generate holes 
public int amountMax = 9; // minum amount of cubes to generate holes 
   
public int startOfCube = 1;


public int amountOfCube = -1;





public float boxColliderSize_x = 1f;
public float boxColliderSize_y = 6f;
public float boxColliderSize_z = 1f;

private Vector3 boxColliderSize;

public Component[] cubeMashRenderer;//create a cubeMashRenderer array

public Component[] cubeBoxCollider;//create cubeBoxCollider array

public Component[] cubeRig;



    void Awake()
    {

        holeGeneratorController = this;
        Debug.Log("Before randomly generate,startOfCube is: " + startOfCube.ToString() +" and the amountOfCube is: " + amountOfCube.ToString());
    }


    
    void OnTriggerEnter(Collider collider)
    {

        if(collider.tag == "Tube1" || collider.tag == "Tube2" || collider.tag == "Tube3" )   
        Debug.Log("Hole generator starts to working!");

        
        
        startOfCube = Random.Range(startMinNum, startMaxNum); // Randomly generate start number of the cubes;
        Debug.Log("The startOfCube  is " + startOfCube.ToString());



         amountOfCube = Random.Range(amountMin, amountMax); //the amount of the cubes will disappear;
        Debug.Log("The amountOfCube is " + amountOfCube.ToString());




        cubeMashRenderer =collider.gameObject.GetComponentsInChildren<MeshRenderer>();

           
        cubeBoxCollider = collider.gameObject.GetComponentsInChildren<BoxCollider>();

        

            
        boxColliderSize = new Vector3(boxColliderSize_x,boxColliderSize_y,boxColliderSize_z); // assign the vector values of wanted changing size to  boxColliderSize


            for(int i = 0; i<49; i++)
            {
               cubeMashRenderer[i].gameObject.GetComponentInChildren<MeshRenderer>().enabled = true; // Active the mesh renderer of the cubes 
                
                cubeBoxCollider[i].gameObject.GetComponentInChildren<BoxCollider>().size = new Vector3(1f,1f,1f); // recover the size of the disappeared collider
                
            }
            for (int i = startOfCube; i<= startOfCube + amountOfCube; i++ )
            {



                cubeMashRenderer[i].gameObject.GetComponentInChildren<MeshRenderer>().enabled = false; //disable the mesh renderer of the cubes 
                
                cubeBoxCollider[i].gameObject.GetComponentInChildren<BoxCollider>().size = boxColliderSize; // enlarge the size of the disappeared collider


            }
        

    }



}
