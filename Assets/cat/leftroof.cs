using UnityEngine;
using System.Collections;

public class leftroof : MonoBehaviour {

	// Use this for initialization
	void Start () {
        gameObject.AddComponent<MeshFilter>();
        gameObject.AddComponent<MeshRenderer>();
	}
	
	// Update is called once per frame
	void Update () {

        int rson = GameObject.Find("roofsurface1").transform.childCount;
        int rson2 = GameObject.Find("roofsurfaceM1").transform.childCount;

        rson = Mathf.Min(rson, rson2);


        float uvR = (1 / (float)rson);


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

        MeshRenderer floorL = gameObject.GetComponent<MeshRenderer>();
        MeshRenderer floor1 = GameObject.Find("roofball").GetComponent<MeshRenderer>();
        floorL.material = floor1.material;

        Mesh meshL = gameObject.GetComponent<MeshFilter>().mesh;
        meshL.Clear();


        Vector3[] vL = new Vector3[2 * rson];
        Vector3[] nL = new Vector3[2 * rson];
        Vector2[] uvL = new Vector2[2 * rson];
        int[] tL = new int[6 * rson];

        for (int j = 0; j <= tiled-1; j++)
        {
            if (j == 0)
            {
                if (i == angle)
                {
                    Vector3 v1 = GameObject.Find("roofsurfaceM" + i).transform.GetChild(j).transform.position;
                    Vector3 v2 = GameObject.Find("roofsurface1").transform.GetChild(j + 1).transform.position;
                    Vector3 v3 = GameObject.Find("roofsurfaceM" + i).transform.GetChild(j + 1).transform.position;
                    vL[0] = (v1);
                    vL[1] = (v2);
                    vL[2] = (v3);
                }
                else
                {
                    Vector3 v1 = GameObject.Find("roofsurfaceM" + i).transform.GetChild(j).transform.position;
                    Vector3 v2 = GameObject.Find("roofsurface" + (i + 1)).transform.GetChild(j + 1).transform.position;
                    Vector3 v3 = GameObject.Find("roofsurfaceM" + i).transform.GetChild(j + 1).transform.position;
                    vL[0] = (v1);
                    vL[1] = (v2);
                    vL[2] = (v3);
                }


                /*
                uvL[0] = new Vector2(0, 0);
                uvL[1] = new Vector2(0, 1);
                uvL[2] = new Vector2(1, 0);
                */

                uvL[0] = new Vector2(1, 1);
                uvL[1] = new Vector2(1 - uvR, 1 - uvR);
                uvL[2] = new Vector2(1, 1 - uvR);


                nL[0] = -Vector3.forward;
                nL[1] = -Vector3.forward;
                nL[2] = -Vector3.forward;



                tL[0] = j + 2;
                tL[1] = j + 1;
                tL[2] = j;
            }
            else if (j == 1)
            { }
            else
            {
                if (i == angle)
                {
                    Vector3 v3 = GameObject.Find("roofsurface1").transform.GetChild(j).transform.position;

                    Vector3 v4 = GameObject.Find("roofsurfaceM" + i).transform.GetChild(j).transform.position;

                    vL[2 * j - 1] = (v3);
                    vL[2 * j] = (v4);
                }
                else
                {
                    Vector3 v3 = GameObject.Find("roofsurface" + (i + 1)).transform.GetChild(j).transform.position;

                    Vector3 v4 = GameObject.Find("roofsurfaceM" + i).transform.GetChild(j).transform.position;

                    vL[2 * j - 1] = (v3);
                    vL[2 * j] = (v4);
                }
                /*
                uvL[2 * j - 1] = new Vector2(0, 1);
                uvL[2 * j] = new Vector2(1, 0);
                */
                if (j == rson - 1)
                {
                    uvL[2 * j - 1] = new Vector2(0, 0);
                    uvL[2 * j] = new Vector2(1, 0);
                }
                else
                {
                    uvL[2 * j - 1] = new Vector2(1 - j * uvR, 1 - j * uvR);

                    uvL[2 * j] = new Vector2(1, 1 - j * uvR);

                }

                //東西南北

                if ((360 / angle) * i <= 90)
                {
                    nL[2 * j - 1] = -Vector3.forward;
                    nL[2 * j] = -Vector3.forward;
                }
                if ((360 / angle) * i <= 180 && (360 / angle) * i > 90)
                {
                    nL[2 * j - 1] = -Vector3.right;
                    nL[2 * j] = -Vector3.right;
                }
                if ((360 / angle) * i <= 270 && (360 / angle) * i > 180)
                {
                    nL[2 * j - 1] = -Vector3.back;
                    nL[2 * j] = -Vector3.back;
                }
                if ((360 / angle) * i <= 360 && (360 / angle) * i > 270)
                {
                    nL[2 * j - 1] = -Vector3.left;
                    nL[2 * j] = -Vector3.left;
                }

                //東西南   

                tL[2 + 6 * (j - 1) - 5] = 2 * j - 1;
                tL[2 + 6 * (j - 1) - 4] = 2 * j - 3;
                tL[2 + 6 * (j - 1) - 3] = 2 * j - 2;
                tL[2 + 6 * (j - 1) - 2] = 2 * j;
                tL[2 + 6 * (j - 1) - 1] = 2 * j - 1;
                tL[2 + 6 * (j - 1)] = 2 * j - 2;

            }
            meshL.vertices = vL;
            meshL.triangles = tL;
            meshL.normals = nL;
            meshL.uv = uvL;
        }

	
	}
}
