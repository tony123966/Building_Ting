using UnityEngine;
using System.Collections;

public class triangle : MonoBehaviour {

	// Use this for initialization



    public static Vector3 v1;
    public static Vector3 v2;
    public static Vector3 v3;

	void Start () {

       
        print("1"+v1);
        print("2"+v2);
        print("3"+v3);

        gameObject.AddComponent<MeshFilter>();
        gameObject.AddComponent<MeshRenderer>();

        Mesh mesh = GetComponent<MeshFilter>().mesh;
        mesh.Clear();

        Vector3 v1w = transform.InverseTransformPoint(v1.x, v1.y, v1.z);
        Vector3 v2w = transform.InverseTransformPoint(v2.x, v2.y, v2.z);
        Vector3 v3w = transform.InverseTransformPoint(v3.x, v3.y, v3.z);




        mesh.vertices = new Vector3[] { v1w, v2w, v3w };


        mesh.uv = new Vector2[] { new Vector2(0, 0), new Vector2(0, 1), new Vector2(1, 1) };
        //mesh.uv4 = new Vector2[] { new Vector2(0, 0), new Vector2(0, 1), new Vector2(1, 1) };


        mesh.normals = new Vector3[] {       
        -Vector3.forward,
        -Vector3.forward,
        -Vector3.forward,
        };


        mesh.triangles = new int[] { 0, 1, 2 };
        gameObject.GetComponent<Renderer>().material.color = Color.yellow;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void threepoint (Vector3 v1,Vector3 v2 ,Vector3 v3)
    {
        gameObject.AddComponent<MeshFilter>();
        gameObject.AddComponent<MeshRenderer>();
        Mesh mesh = GetComponent<MeshFilter>().mesh;
        mesh.Clear();

        Vector3 v1w = transform.TransformPoint(v1.x, v1.y, v1.z);
        Vector3 v2w = transform.TransformPoint(v2.x, v2.y, v2.z);
        Vector3 v3w = transform.TransformPoint(v3.x, v3.y, v3.z);




        mesh.vertices = new Vector3[] { v1w, v2w, v3w };


        mesh.uv = new Vector2[] { new Vector2(0, 0), new Vector2(0, 1), new Vector2(1, 1) };
        //mesh.uv4 = new Vector2[] { new Vector2(0, 0), new Vector2(0, 1), new Vector2(1, 1) };


        mesh.normals = new Vector3[] {       
        -Vector3.forward,
        -Vector3.forward,
        -Vector3.forward,
        };


        mesh.triangles = new int[] { 0, 1, 2 };
        gameObject.GetComponent<Renderer>().material.color = Color.yellow;

    }




}
