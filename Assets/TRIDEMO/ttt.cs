using UnityEngine;
using System.Collections;

public class ttt : MonoBehaviour {


    public static Vector3 v1;
    public static Vector3 v2;
    public static Vector3 v3;
	// Use this for initialization
	void Start () {
        /*
        gameObject.AddComponent<MeshFilter>();
        gameObject.AddComponent<MeshRenderer>();

        Mesh mesh = GetComponent<MeshFilter>().mesh;
        //Debug.DrawLine(Camera.main.transform.position, transform.position + mesh.vertices[0]);
        mesh.Clear();

        v1=GameObject.Find("11").transform.position;

        v2=GameObject.Find("22").transform.position;

        v3 = GameObject.Find("33").transform.position;


        //Vector3 v1w = transform.TransformPoint(v1.x, v1.y, v1.z);
        Vector3 v1w = transform.InverseTransformPoint(v1);
        Vector3 v2w = transform.InverseTransformPoint(v2.x, v2.y, v2.z);
        Vector3 v3w = transform.InverseTransformPoint(v3.x, v3.y, v3.z);







        Vector3[] v = new Vector3[3];


        //mesh.vertices = new Vector3[] {v1, v2, v3 };
        //mesh.vertices = new Vector3[] { v1w, v2w, v3w };
        
       v[0] = v1w;
        v[1] = v2w;
        v[2] = v3w;
        

        //Debug.DrawLine(Camera.main.transform.position, transform.position + mesh.vertices[0]);
        mesh.vertices = v;

        mesh.uv = new Vector2[] { new Vector2(0, 0), new Vector2(0, 1), new Vector2(1, 1) };
        //mesh.uv4 = new Vector2[] { new Vector2(0, 0), new Vector2(0, 1), new Vector2(1, 1) };


        mesh.normals = new Vector3[] {       
        -Vector3.forward,
        -Vector3.left,
        -Vector3.right,
        };


        mesh.triangles = new int[] { 0, 1, 2 };
        gameObject.GetComponent<Renderer>().material.color = Color.yellow;
         * */
	}
	
	// Update is called once per frame
	void Update () 
    
    
    
    
    
    {
        
        
        
        
        
        gameObject.AddComponent<MeshFilter>();
       // gameObject.AddComponent<MeshRenderer>();

        Mesh mesh = GetComponent<MeshFilter>().mesh;
        
        mesh.Clear();

        v1 = GameObject.Find("11").transform.position;

        v2 = GameObject.Find("22").transform.position;

        v3 = GameObject.Find("33").transform.position;
        
       
        Vector3 v1w = transform.InverseTransformPoint(v1);
        Vector3 v2w = transform.InverseTransformPoint(v2.x, v2.y, v2.z);
        Vector3 v3w = transform.InverseTransformPoint(v3.x, v3.y, v3.z);
        
        
        Vector3[] v = new Vector3[3];
              
        v[0] = v1w;
        v[1] = v2w;
        v[2] = v3w;
                       
        mesh.vertices = v;
        mesh.uv = new Vector2[] { new Vector2(0, 0), new Vector2(0, 1), new Vector2(1, 1) };
               
        mesh.normals = new Vector3[] {       
        -Vector3.forward,
        -Vector3.left,
        -Vector3.right,
        };
        
        mesh.triangles = new int[] { 0, 1, 2 };
        gameObject.GetComponent<Renderer>().material.color = Color.yellow;
	}
}
