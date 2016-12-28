using UnityEngine;
using System.Collections;

public class Balustrademesh : MonoBehaviour {

	// Use this for initialization
	void Start () {
        gameObject.AddComponent<MeshFilter>();
        gameObject.AddComponent<MeshRenderer>();
    }
	
	// Update is called once per frame
	void Update () {

        int angle = int.Parse(UI.stringToEdit);

        int i = int.Parse(gameObject.name.Substring(10, 1));

        MeshRenderer floor2 = gameObject.GetComponent<MeshRenderer>();
        MeshRenderer floor1 = GameObject.Find("wallball").GetComponent<MeshRenderer>();



        floor2.material = floor1.material;


        Mesh mesh = gameObject.GetComponent<MeshFilter>().mesh;

        mesh.Clear();


        if (i != angle)
        {
            Vector3 V1 = GameObject.Find("column" + i).transform.GetChild(2).position;
            Vector3 V2 = GameObject.Find("column" + (i + 1)).transform.GetChild(2).position;
            Vector3 V3 = GameObject.Find("column" + i).transform.GetChild(3).position;
            Vector3 V4 = GameObject.Find("column" + (i + 1)).transform.GetChild(3).position;


            mesh.vertices = new Vector3[] { V1, V2, V3, V4 };
        }
        else
        {
            Vector3 V1 = GameObject.Find("column" + i).transform.GetChild(2).position;
            Vector3 V2 = GameObject.Find("column1").transform.GetChild(2).position;
            Vector3 V3 = GameObject.Find("column" + i).transform.GetChild(3).position;
            Vector3 V4 = GameObject.Find("column1").transform.GetChild(3).position;


            mesh.vertices = new Vector3[] { V1, V2, V3, V4 };
        }




        mesh.uv = new Vector2[] { new Vector2(0, 0), new Vector2(0, 1), new Vector2(1, 0), new Vector2(1, 1) };

        //東西南北

        if ((360 / angle) * i <= 90)
        {
            mesh.normals = new Vector3[]
                {
                        -Vector3.forward,
                        -Vector3.forward,
                        -Vector3.forward,
                        -Vector3.forward,
                };
        }
        if ((360 / angle) * i <= 180 && (360 / angle) * i > 90)
        {
            mesh.normals = new Vector3[]
                {
                        -Vector3.right,
                        -Vector3.right,
                        -Vector3.right,
                         -Vector3.right,


                };
        }
        if ((360 / angle) * i <= 270 && (360 / angle) * i > 180)
        {
            mesh.normals = new Vector3[]
                {
                        -Vector3.back,
                        -Vector3.back,
                        -Vector3.back,
                        -Vector3.back,
                };
        }
        if ((360 / angle) * i <= 360 && (360 / angle) * i > 270)
        {
            mesh.normals = new Vector3[]
                {
                        -Vector3.left,
                        -Vector3.left,
                        -Vector3.left,
                        -Vector3.left,
                };
        }

        //東西南北

        mesh.triangles = new int[] { 1, 0, 2, 1, 2, 3 };



    }
}
