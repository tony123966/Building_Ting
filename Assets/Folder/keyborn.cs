using UnityEngine;
using System.Collections;


[AddComponentMenu("")]
public class keyborn : MonoBehaviour {


    public Spline spline;
    public SplineMesh splineMesh;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
 


        Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 40));

        
        if (Input.GetKey(KeyCode.C))
        {

            if (publicvar.number < 1)
            {

                GameObject haha = spline.AddSplineNode();

                haha.transform.position = new Vector3(pos.x, pos.y, pos.z);


                haha.AddComponent<MeshFilter>().mesh = new Mesh();
                //*****************
                GameObject temp = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                haha.GetComponent<MeshFilter>().sharedMesh = temp.GetComponent<MeshFilter>().sharedMesh;
                Destroy(temp);
                //*****************
                haha.AddComponent<MeshRenderer>();
                haha.AddComponent<SphereCollider>();
                haha.GetComponent<Renderer>().material.color = Color.white;
                haha.AddComponent<moveA>().enabled = false;

                haha.name = ("dot" + publicvar.number);
                //haha.AddComponent<SplineNode>();
                //haha.AddComponent<NodeCreator>();

                splineMesh.segmentCount += 3;
                publicvar.number++;
            }
            else
            {

                GameObject haha = spline.AddSplineNode();
                haha.transform.position = new Vector3(pos.x, pos.y, pos.z);

                haha.AddComponent<MeshFilter>().mesh = new Mesh();
                //*****************
                GameObject temp = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                haha.GetComponent<MeshFilter>().sharedMesh = temp.GetComponent<MeshFilter>().sharedMesh;
                Destroy(temp);
                //*****************
                haha.AddComponent<SphereCollider>();
                haha.AddComponent<MeshRenderer>();
                haha.GetComponent<Renderer>().material.color = Color.white;
                haha.AddComponent<moveA>().enabled = false;

                haha.name = ("dot" + publicvar.number);
                //haha.AddComponent<SplineNode>();
                splineMesh.segmentCount += 3;
                publicvar.number++;
            }
        }

        print("hahaha");
	}


}
