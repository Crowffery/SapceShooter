using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TubeLoopController : MonoBehaviour
{
    public static TubeLoopController tubeLoopController;


    public Transform row1;
    public Transform row2;
    public Transform row3;
    public Transform row4;
    

    public Transform[,] rowTransformArray;


    
[SerializeField]
    public static int movingSpeed = -20; // the speed of the tube's moving speed;
    private Vector3 tubePosition; //the position of the tubes

    private Vector3 row1TubePositionY;// fined Y axis values 
    private Vector3 row2TubePositionY;
    private Vector3 row3TubePositionY;
    private Vector3 row4TubePositionY;

    //private float lengthOfTubet;

    private Vector3 restartLoopingDistance; // the Distance where the tube supposes to loop start with.

    Component[] cubeMashRenderer; //create an array to contain  mesh renderer game componenets.
     Component[] cubeBoxCollider;//create cubeBoxCollider array

    //public HoleGeneratorController holeGeneratorController;// 


    
    void Awake(){
        tubeLoopController = this;
    }

    void Start()
{



    if(row1 == null || row2 == null || row3 == null || row4 == null)
    {
        Debug.Log("Row objects are missing!");
        return;

    }
    // create a multi-dimensional array that includes all the tubes' transform informations
    rowTransformArray = new Transform[4,3]
    {
        {row1.gameObject.transform.GetChild(0), row1.gameObject.transform.GetChild(1), row1.gameObject.transform.GetChild(2)},
         {row2.gameObject.transform.GetChild(0), row2.gameObject.transform.GetChild(1), row2.gameObject.transform.GetChild(2)},
        {row3.gameObject.transform.GetChild(0), row3.gameObject.transform.GetChild(1), row3.gameObject.transform.GetChild(2)},
         {row4.gameObject.transform.GetChild(0), row4.gameObject.transform.GetChild(1), row4.gameObject.transform.GetChild(2)},

    };


    //No need
   // row1TubePositionY  = new Vector3 (0,rowTransformArray[0,0].position.y,0);
   // row2TubePositionY  = new Vector3 (0,rowTransformArray[1,0].position.y,0);
    //row3TubePositionY  = new Vector3 (0,rowTransformArray[2,0].position.y,0);
   // row4TubePositionY  = new Vector3 (0,rowTransformArray[3,0].position.y,0);
    // 



    restartLoopingDistance = new Vector3 (50,0,0);
}
    void Update()
    {

        for(int row = 0; row < 4; row++)
        {
            for(int col = 0; col < 3; col++)
            {
                tubePosition = rowTransformArray[row,col].position;// get the location of the tube.
                tubePosition.x  += movingSpeed  * Time.deltaTime;// change the x value per seconds.
                rowTransformArray[row,col].position = tubePosition;//assign the changed value to object.

            }

        }


    }

    void OnTriggerEnter(Collider collider)
    {
        if(collider.tag == "Tube1" )
        {
            Debug.Log("Moving tube 1 behinds of tube 3");
            rowTransformArray[0,0].position = rowTransformArray[0,2].transform.position + restartLoopingDistance ;//+row1TubePositionY; // move tube 1 the 50 units behinds of tube 3
             rowTransformArray[1,0].position = rowTransformArray[1,2].transform.position + restartLoopingDistance ;//+row2TubePositionY;
              rowTransformArray[2,0].position = rowTransformArray[2,2].transform.position + restartLoopingDistance ;//+row3TubePositionY;
               rowTransformArray[3,0].position = rowTransformArray[3,2].transform.position + restartLoopingDistance ;//+row4TubePositionY;

        }   
        else if(collider.tag == "Tube2")      
        {
            Debug.Log("Moving tube 2 behinds of tube 1");
            rowTransformArray[0,1].position = rowTransformArray[0,0].transform.position + restartLoopingDistance ;//+row1TubePositionY;// move tube 2 the 50 units behinds of tube 1
            rowTransformArray[1,1].position = rowTransformArray[1,0].transform.position + restartLoopingDistance ;//+row2TubePositionY;;
            rowTransformArray[2,1].position = rowTransformArray[2,0].transform.position + restartLoopingDistance ;//+row3TubePositionY;
            rowTransformArray[3,1].position = rowTransformArray[3,0].transform.position + restartLoopingDistance;// +row4TubePositionY;
        
        }
        else if(collider.tag == "Tube3")      
        {
            Debug.Log("Moving tube 3 behinds of tube 2");
            rowTransformArray[0,2].position = rowTransformArray[0,1].transform.position + restartLoopingDistance ;//+row1TubePositionY;// move tube 3the 50 units behinds of tube 2
            rowTransformArray[1,2].position = rowTransformArray[1,1].transform.position + restartLoopingDistance ;//+row2TubePositionY;;
            rowTransformArray[2,2].position = rowTransformArray[2,1].transform.position + restartLoopingDistance ;//+row3TubePositionY;
            rowTransformArray[3,2].position = rowTransformArray[3,1].transform.position + restartLoopingDistance ;//+row4TubePositionY;
        
        }

  
             
        cubeMashRenderer = gameObject.GetComponentsInChildren<MeshRenderer>();// give all the renderer type componenets to the array.
            
           
        cubeBoxCollider = gameObject.GetComponentsInChildren<BoxCollider>();// give all the boxcollider type componenets to the array.

         // create an instance  of holw generator
          //  if(holeGeneratorController != null)
          //  {
           //      for (int i = holeGeneratorController.startOfCube; i<= holeGeneratorController.startOfCube +holeGeneratorController.amountOfCube; i++ )
            //    {
            //        Debug.Log("The startOfCube that we retrived from hole generator is "+ holeGeneratorController.startOfCube.ToString() + ", The amountOfCube that we get from hole generator is  " + holeGeneratorController.amountOfCube.ToString());
             //       cubeMashRenderer[i-1].gameObject.GetComponentInChildren<Renderer>().enabled = true; //recover mesh renderer of EVERY cube,

                    //check the elements of box colliders array
              //      foreach( var x in cubeBoxCollider) {
            //         Debug.Log( x.ToString());
                 
                 
              //      cubeBoxCollider[i].gameObject.GetComponentInChildren<BoxCollider>().size = new Vector3(1f,1f,1f); //recover the size of the coliders

             //   }

           // }
           // else
           // {
            //    Debug.Log("HoleG is missing");
           // }
           
        // for (int i = startOfCube; i<= startOfCube + amountOfCube; i++ )

    }



    

}