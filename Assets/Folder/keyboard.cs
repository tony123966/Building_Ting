using UnityEngine;
using System.Collections;
[AddComponentMenu("")]

public class keyboard : MonoBehaviour {



    public Spline spline;
    public SplineMesh splineMesh;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
    {



        if (Input.GetKeyDown(KeyCode.Z))
        {

            //Get the array of nodes
            SplineNode[] splineNodes = spline.SplineNodes;

            //If there are no spline nodes left, return
            if (splineNodes.Length < 1)
            {
                Destroy(GameObject.Find("dot0"));
                spline.RemoveSplineNode(GameObject.Find("dot0"));
                publicvar.number = 0;

                return;
            }

            //Get the spline's first node

            //原本的
            //SplineNode firstNode = splineNodes[0];
            SplineNode firstNode = splineNodes[publicvar.number - 1];


            //Remove it from the spline
            //spline.RemoveSplineNode( firstNode );
            spline.RemoveSplineNode(firstNode);

            splineMesh.segmentCount -= 3;

            Destroy(GameObject.Find("dot" + (publicvar.number - 1)));
            publicvar.number--;
        }


        if (Input.GetKeyDown(KeyCode.X))
        {

            GameObject.Find("Main Camera").GetComponent<mouseclick>().enabled =false;
            GameObject.Find("Main Camera").GetComponent<keyborn>().enabled = false;
            
            for (int n = publicvar.number; n > 0; n--)
            {
                print("gggggggggggggggg" + n);
                //GameObject.Find("dot" + (n - 1)).GetComponent<moveA>().enabled =false;
                Destroy(GameObject.Find("dot" + (n - 1)).GetComponent<moveA>());

            } 
            for (int n = publicvar.number; n > 0; n--)
            {
                
                //GameObject.Find("dot" + (n - 1)).GetComponent<moveA>().enabled =false;
                Destroy(GameObject.Find("dot" + (n - 1)).GetComponent<clicktoborn>());

            }
          
            

        }
	}
}
