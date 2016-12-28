using UnityEngine;
using System.Collections;

public class menu : MonoBehaviour {

    public Spline spline;
    public SplineMesh splineMesh;

    private Rect btnRect;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnGUI() 
    
    {
        //Vector3 pos = Camera.main.WorldToScreenPoint(this.gameObject.transform.position);

        // Make a background box

        //GUI.Box(new Rect(10, 10, 150, 180), "Menu");
        GUI.Box(new Rect(50, 50, 150, 180), "Menu");

        // Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
        if (GUI.Button(new Rect(50 + 15, 50 + 30, 120, 20), "creat"))
        {
           GameObject.Find("Main Camera").GetComponent<mouseclick>().enabled =true;

        }

        if (GUI.Button(new Rect(50 + 15, 50 + 60, 120, 20), "hand"))
        {
            GameObject.Find("Main Camera").GetComponent<keyborn>().enabled = true;
        }

        // Make the second button.
        if (GUI.Button(new Rect(50 + 15, 50 + 90, 120, 20), "ADJUST"))
        {


            for (int n = publicvar.number; n > 0; n--)
            {
                print("gggggggggggggggg" + n);
                GameObject.Find("dot" + (n-1)).AddComponent<moveA>().enabled = true;
            }
          
            

        }

        if (GUI.Button(new Rect(50 + 15, 50 + 120, 120, 20), "born"))
        {
            for (int n = publicvar.number; n > 0; n--)
            {
                
                GameObject.Find("dot" + (n - 1)).AddComponent<clicktoborn>().enabled = true;
            }
           
        }


        if (GUI.Button(new Rect(50 + 15, 50 + 150, 120, 20), "destoy"))
        {
            

            while(publicvar.number==0)
            {
                //Destroy(GameObject.Find("dot" + publicvar.number));
               // spline.RemoveSplineNode(GameObject.Find("dot" + publicvar.number));
               // publicvar.number--;


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
                SplineNode firstNode = splineNodes[publicvar.number];


                //Remove it from the spline
                //spline.RemoveSplineNode( firstNode );
                spline.RemoveSplineNode(firstNode);

                splineMesh.segmentCount -= 3;

                Destroy(GameObject.Find("dot" + (publicvar.number)));
                publicvar.number--;


            }


            publicvar.number = 0;
        }
    }
}
