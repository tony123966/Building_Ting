using UnityEngine;
using System.Collections;

public class rightroof : MonoBehaviour {

	// Use this for initialization
	void Start () {

        gameObject.AddComponent<MeshFilter>();
        gameObject.AddComponent<MeshRenderer>();
       
	}
	
	// Update is called once per frame
	void Update () {
        if(GameObject.Find("Ridge1").transform.GetChild(pubvar.ball-1).transform.hasChanged == true)
        {

        //new







        //new


            int rson = GameObject.Find("roofsurface1").transform.childCount;
            int rson2 = GameObject.Find("roofsurfaceM1").transform.childCount;

            rson = Mathf.Min(rson, rson2);
            
            
            float uvR= (1 / (float)rson);
           

            int angle = int.Parse(UI.stringToEdit);
            int tiled = int.Parse(UI.stringToEdit3);


        int i = int.Parse(gameObject.name.Substring(3, 1));

        //new

        SplinePathCloneBuilder rrr2 = GameObject.Find("roofsurfaceM" + i).GetComponent<SplinePathCloneBuilder>();

        CurvySpline cs = GameObject.Find("roofcurve" + i).GetComponent<CurvySpline>();
        float rrrlength = cs.Length;

        rrr2.Gap = rrrlength / tiled;


        SplinePathCloneBuilder rrr = GameObject.Find("roofsurface" + i).GetComponent<SplinePathCloneBuilder>();

        rrr.Spline = GameObject.Find("Ridge" + i).GetComponent<CurvySpline>();

        CurvySpline cs2 = GameObject.Find("Ridge" + i).GetComponent<CurvySpline>();

        float rrrlength2 = cs2.Length;



        rrr.Gap = rrrlength2 / tiled;



        //new

        /*
            for (int i = 1; i <= angle; i++)
            {
*/
        //RIGHT
        /*
        GameObject TTR = new GameObject();
        TTR.name = ("TTR" + i);
        TTR.AddComponent<MeshFilter>();
        TTR.AddComponent<MeshRenderer>();
        TTR.AddComponent<MeshCollider>();


         * 
         * 
         * 
        MeshRenderer floor = TTR.GetComponent<MeshRenderer>();
        MeshRenderer floor1 = GameObject.Find("roofball").GetComponent<MeshRenderer>();
        floor.material =  floor1.material;
        */


        /*
        gameObject.AddComponent<MeshFilter>();
        gameObject.AddComponent<MeshRenderer>();
        */


        //TTR.AddComponent<rightroof>();



        MeshRenderer floor = gameObject.GetComponent<MeshRenderer>();
        MeshRenderer floor1 = GameObject.Find("roofball").GetComponent<MeshRenderer>();
        floor.material = floor1.material;


        Mesh mesh = transform.GetComponent<MeshFilter>().mesh;
                mesh.Clear();

                //transform.GetComponent<MeshCollider>().sharedMesh = mesh;
                
                Vector3[] v = new Vector3[2 * rson];
                Vector3[] n = new Vector3[2 * rson];
                Vector2[] uv = new Vector2[2 * rson];
                int[] t = new int[6 * rson];

                for (int j = 0; j <= tiled-1 ; j++)
                {
                    if (j == 0)
                    {

                        Vector3 v1 = GameObject.Find("roofsurface" + i).transform.GetChild(j).transform.position;
                        Vector3 v2 = GameObject.Find("roofsurfaceM" + i).transform.GetChild(j + 1).transform.position;
                        Vector3 v3 = GameObject.Find("roofsurface" + i).transform.GetChild(j + 1).transform.position;
                        v[0] = (v1);
                        v[1] = (v2);
                        v[2] = (v3);


                        uv[0] = new Vector2(0, 1);
                        uv[1] = new Vector2(0, 1 - uvR);
                        uv[2] = new Vector2(uvR, 1 - uvR);


                        n[0] = -Vector3.forward;
                        n[1] = -Vector3.forward;
                        n[2] = -Vector3.forward;



                        t[0] = j + 2;
                        t[1] = j + 1;
                        t[2] = j;
                    }
                    else if (j == 1)
                    { }
                    else
                    {
                        Vector3 v3 = GameObject.Find("roofsurfaceM" + i).transform.GetChild(j).transform.position;
                        Vector3 v4 = GameObject.Find("roofsurface" + i).transform.GetChild(j).transform.position;

                        v[2 * j - 1] = (v3);
                        v[2 * j] = (v4);


                        if (j == rson - 1)
                        {
                            uv[2 * j - 1] = new Vector2(0, 0);
                            uv[2 * j] = new Vector2(1, 0);
                        }
                        else
                        {
                            uv[2 * j - 1] = new Vector2(0, 1 - j * uvR);

                            uv[2 * j] = new Vector2(j * uvR, 1 - j * uvR);

                        }

                        //東西南北

                        if ((360 / angle) * i <= 90)
                        {
                            n[2 * j - 1] = -Vector3.forward;
                            n[2 * j] = -Vector3.forward;
                        }
                        if ((360 / angle) * i <= 180 && (360 / angle) * i > 90)
                        {
                            n[2 * j - 1] = -Vector3.right;
                            n[2 * j] = -Vector3.right;
                        }
                        if ((360 / angle) * i <= 270 && (360 / angle) * i > 180)
                        {
                            n[2 * j - 1] = -Vector3.back;
                            n[2 * j] = -Vector3.back;
                        }
                        if ((360 / angle) * i <= 360 && (360 / angle) * i > 270)
                        {
                            n[2 * j - 1] = -Vector3.left;
                            n[2 * j] = -Vector3.left;
                        }

                        //東西南   

                        t[2 + 6 * (j - 1) - 5] = 2 * j - 1;
                        t[2 + 6 * (j - 1) - 4] = 2 * j - 3;
                        t[2 + 6 * (j - 1) - 3] = 2 * j - 2;
                        t[2 + 6 * (j - 1) - 2] = 2 * j;
                        t[2 + 6 * (j - 1) - 1] = 2 * j - 1;
                        t[2 + 6 * (j - 1)] = 2 * j - 2;

                    }
                    mesh.vertices = v;
                    mesh.triangles = t;
                    mesh.normals = n;
                    mesh.uv = uv;
                }
                /*
            }
            */
    }
	}
}
