using UnityEngine;
using System.Collections;
using System.Threading;

public class UI : MonoBehaviour {

    private Rect btnRect;
    public static string stringToEdit = "";
    public static string stringToEdit2 = "";
    public static string stringToEdit3 = "";
    public static string stringToEdit4 = "";
    public int rson = 0;
    public int rson2 = 0;
    public static int whichroof;
    //public CurvySplineBase[] spline;


    // Use this for initialization
    void Start () {
        stringToEdit = "4";
        stringToEdit2 = "10";
        stringToEdit3 = "100";




	}
	
	// Update is called once per frame
	void Update () {
	
	}


    public void FUCK()
    {

        int angle = int.Parse(UI.stringToEdit);







        for (int i = 1; i <= angle; i++)
        {



            SplinePathCloneBuilder rrr2 = GameObject.Find("roofsurfaceM" + i).GetComponent<SplinePathCloneBuilder>();



            rrr2.Spline = GameObject.Find("roofcurve" + i).GetComponent<CurvySpline>();





        }


    }






    void OnGUI()
    {
        Vector3 pos = Camera.main.WorldToScreenPoint(this.gameObject.transform.position);

        // Make a background box

        //GUI.Box(new Rect(10, 10, 150, 180), "Menu");
        GUI.Box(new Rect(20, 50, 150, 300), "Option");


        stringToEdit2 = GUI.TextField(new Rect(20 + 15, 50 + 90, 120, 20), stringToEdit2);

        // Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
        if (GUI.Button(new Rect(20 + 15, 50 + 60, 120, 20), "ridge"))
        {
            int angle = int.Parse(UI.stringToEdit);
            if (GameObject.Find("RidgeMusle1"))
            {
                for (int i = 1; i <= angle; i++)
                {
                    if (GameObject.Find("RidgeMusle" + i))
                    {
                        Destroy(GameObject.Find("RidgeMusle" + i).gameObject);
                    }

                }
                GameObject.Find("bao-ding").transform.position = new Vector3(0,0,0);
            }
            else
            {

                for (int i = 1; i <= angle; i++)
                {



                    GameObject rm = new GameObject();
                    rm.name = ("RidgeMusle" + i);
                    rm.AddComponent<SplinePathCloneBuilder>();
                    SplinePathCloneBuilder rrr = rm.GetComponent<SplinePathCloneBuilder>();

                    rrr.Spline = GameObject.Find("Ridge" + i).GetComponent<CurvySpline>();


                    
                    rrr.Gap = 0.5f;
                    rrr.Source = new GameObject[1];
                    rrr.Source[0] = GameObject.Find("main_ridge");




                }
                GameObject.Find("bao-ding").transform.position = GameObject.Find("Ridge1").transform.GetChild(0).transform.position;
            }



        }

        stringToEdit = GUI.TextField(new Rect(20 + 15, 50 + 30, 120, 20), stringToEdit);








        if (GUI.Button(new Rect(20 + 15, 50 + 120, 120, 20), "ridge tail"))
        {
            int angle = int.Parse(UI.stringToEdit);

            GLCurvyRenderer gl = GameObject.Find("Main Camera").GetComponent<GLCurvyRenderer>();

            if (GameObject.Find("ridge tail2"))
            {
                for (int i = 1; i <= angle; i++)
                {

                    print("??" + i);
                    if (GameObject.Find("ridge tail" + i))
                    {
                        print("??");
                        Destroy(GameObject.Find("ridge tail" + i).gameObject);
                    }
                }

            }


            else
            {




                for (int i = 1; i <= 1; i++)
                {
                    print("~~~~~~~~~~~~~~~~~~~" + i);
                    GameObject rt = new GameObject();
                    rt.name = ("ridge tail" + i);
                    rt.transform.RotateAround(GameObject.Find("Ridge1").transform.GetChild(0).transform.position, Vector3.up, (360 / angle) * (i - 1));
                    rt.AddComponent<CurvySpline>();
                    rt.AddComponent<ridgetailmove>();
                    rt.AddComponent<Pcit>();
                    rt.AddComponent<Pcib>();

                    Vector3 ori = GameObject.Find("Ridge" + i).transform.GetChild(pubvar.ball - 1).transform.position;
                    Vector3 ori2 = GameObject.Find("Ridge" + i).transform.GetChild(0).transform.position;
                    Vector3 vec = (ori2 - ori).normalized;


                    for (int j = 1; j <= 3; j++)
                    {


                        if (j == 1)
                        {
                            GameObject rtson = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                            rtson.transform.parent = rt.transform;
                            rtson.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                            rtson.name = ("rtson" + j);
                            rtson.transform.position = GameObject.Find("Ridge" + i).transform.GetChild(pubvar.ball - 1).transform.position + (-vec * (j - 1));
                            rtson.transform.position = new Vector3(rtson.transform.position.x, rtson.transform.position.y + (0.5f * (j - 1)), rtson.transform.position.z);
                            rtson.AddComponent<CurvySplineSegment>();
                            rtson.AddComponent<Zevent>();
                            rtson.AddComponent<copyevent>();
                            if (i != 1)
                            {
                                Destroy(rtson.GetComponent<MeshRenderer>());
                            }
                        }
                        if (j == 2)
                        {
                            GameObject rtson = GameObject.CreatePrimitive(PrimitiveType.Cube);
                            rtson.transform.parent = rt.transform;
                            rtson.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                            rtson.name = ("rtson" + j);
                            rtson.transform.position = GameObject.Find("Ridge" + i).transform.GetChild(pubvar.ball - 1).transform.position + (-vec * (j - 1));
                            rtson.transform.position = new Vector3(rtson.transform.position.x, rtson.transform.position.y + (0.5f * 1), rtson.transform.position.z);
                            rtson.AddComponent<CurvySplineSegment>();
                            rtson.AddComponent<Zevent>();
                            rtson.AddComponent<copyevent>();
                            if (i != 1)
                            {
                                Destroy(rtson.GetComponent<MeshRenderer>());
                            }
                        }
                        if (j == 3)
                        {
                            GameObject rtson = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                            rtson.transform.parent = rt.transform;
                            rtson.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                            rtson.name = ("rtson" + j);
                            rtson.transform.position = GameObject.Find("Ridge" + i).transform.GetChild(pubvar.ball - 1).transform.position + (-vec * (j - 1));
                            rtson.transform.position = new Vector3(rtson.transform.position.x, rtson.transform.position.y + (0.5f * 3), rtson.transform.position.z);
                            rtson.AddComponent<CurvySplineSegment>();
                            rtson.AddComponent<Zevent>();
                            rtson.AddComponent<copyevent>();
                            if (i != 1)
                            {
                                Destroy(rtson.GetComponent<MeshRenderer>());
                            }
                        }

                        //rtson.AddComponent<copyevent>();

                        //Destroy(rtson.GetComponent<MeshRenderer>());
                    }




                    //rt.transform.RotateAround(GameObject.Find("Ridge1").transform.GetChild(0).transform.position, Vector3.up, (360 / angle) * (i-1));
                    print("aaaaa:" + (360 / angle) * (i - 2));

                    gl.Splines[80 + i] = rt.GetComponent<CurvySpline>();
                }
                for (int i = 1; i <= angle - 1; i++)
                {
                    GameObject go = Instantiate(GameObject.Find("ridge tail1"), GameObject.Find("ridge tail1").transform.position, Quaternion.identity) as GameObject;
                    go.transform.RotateAround(GameObject.Find("Ridge1").transform.GetChild(0).transform.position, Vector3.up, (360 / angle) * i);
                    go.name = ("ridge tail" + (i + 1));

                    Destroy(go.transform.GetChild(0).gameObject.GetComponent<MeshRenderer>());
                    Destroy(go.transform.GetChild(1).gameObject.GetComponent<MeshRenderer>());
                    Destroy(go.transform.GetChild(2).gameObject.GetComponent<MeshRenderer>());


                    gl.Splines[80 + i + 1] = go.GetComponent<CurvySpline>();


                }

            }







        }




        if (GUI.Button(new Rect(20 + 15, 50 + 150, 120, 20), "column"))
        {
            int angle = int.Parse(UI.stringToEdit);


            if (GameObject.Find("column1").transform.GetChild(5).gameObject.GetComponent<MeshRenderer>().enabled == false)
            {
                for (int i = 2; i <= angle; i++)
                {
                    GameObject.Find("column" + i).transform.GetChild(5).gameObject.AddComponent<MeshRenderer>();
                    GameObject.Find("column" + i).transform.GetChild(5).gameObject.GetComponent<Renderer>().material.color = Color.white;
                    GameObject.Find("column1").transform.GetChild(5).gameObject.GetComponent<MeshRenderer>().enabled = true;
                }
            }
            else
            {

                for (int i = 2; i <= angle; i++)
                {
                    Destroy(GameObject.Find("column" + i).transform.GetChild(5).gameObject.GetComponent<MeshRenderer>());
                    GameObject.Find("column1").transform.GetChild(5).gameObject.GetComponent<MeshRenderer>().enabled = false;
                }
            }





        }

        if (GUI.Button(new Rect(20 + 15, 50 + 180, 120, 20), "roofsurface"))
        {
            int angle = int.Parse(UI.stringToEdit);
            //GLCurvyRenderer gl = GameObject.Find("Main Camera").GetComponent<GLCurvyRenderer>();
            int tiled = int.Parse(UI.stringToEdit3);

            if (GameObject.Find("roofsurface1"))
            {
                for (int i = 1; i <= angle; i++)
                {
                    if (GameObject.Find("roofsurface" + i))
                    {
                        Destroy(GameObject.Find("roofsurface" + i).gameObject);

                    }

                }
            }
            else
            {

                for (int i = 1; i <= angle; i++)
                {



                    GameObject rm = new GameObject();
                    rm.name = ("roofsurface" + i);
                    rm.AddComponent<SplinePathCloneBuilder>();
                    //rm.AddComponent<CurvySpline>();
                    SplinePathCloneBuilder rrr = rm.GetComponent<SplinePathCloneBuilder>();

                    rrr.Spline = GameObject.Find("Ridge" + i).GetComponent<CurvySpline>();

                    CurvySpline cs = GameObject.Find("Ridge" + i).GetComponent<CurvySpline>();

                    float rrrlength = cs.Length;

                    //rrr.Gap = 0.25f;
                    rrr.Mode = SplinePathCloneBuilderMode.CloneGroup;
                    rrr.Gap = rrrlength / tiled;
                    rrr.Source = new GameObject[1];
                    rrr.Source[0] = GameObject.Find("empty").gameObject;

                    //middle




                }


            }
        }

        if (GUI.Button(new Rect(20 + 15, 50 + 210, 120, 20), "roofsurface2"))
        {
            if (GameObject.Find("roofsurfacelineR1"))
            {

                int angle = int.Parse(UI.stringToEdit);
                for (int i = 1; i <= angle; i++)
                {
                    Destroy(GameObject.Find("roofsurfacelineR" + i));
                    Destroy(GameObject.Find("roofsurfacelineL" + i));
                }
            }
            else
            {


                int angle = int.Parse(UI.stringToEdit);



                rson = GameObject.Find("roofsurface1").transform.childCount;
                rson2 = GameObject.Find("roofsurfaceM1").transform.childCount;

                rson = Mathf.Min(rson, rson2);


                //stop
                for (int i = 1; i <= angle; i++)
                {
                    SplinePathCloneBuilder rrr = GameObject.Find("roofsurfaceM" + i).GetComponent<SplinePathCloneBuilder>();
                    rrr.AutoRefresh = false;
                }



                for (int i = 1; i <= angle; i++)
                {
                    GameObject rs = new GameObject();
                    rs.name = ("roofsurfacelineR" + i);
                    rs.AddComponent<Spline>();
                    rs.AddComponent<SplineMesh>();
                    rs.AddComponent<MeshRenderer>();
                    rs.GetComponent<Renderer>().material.color = Color.yellow;

                    Spline sp = GameObject.Find("roofsurfacelineR" + i).GetComponent<Spline>();
                    SplineMesh spm = GameObject.Find("roofsurfacelineR" + i).GetComponent<SplineMesh>();


                    spm.spline = sp;
                    spm.xyScale = new Vector2(0.025f, 0.025f);
                    spm.highAccuracy = true;
                    spm.segmentCount = 1000;
                    Mesh cy = GameObject.Find("myline").GetComponent<MeshFilter>().mesh;
                    spm.baseMesh = cy;


                    GameObject rs2 = new GameObject();
                    rs2.name = ("roofsurfacelineL" + i);
                    rs2.AddComponent<Spline>();
                    rs2.AddComponent<SplineMesh>();
                    rs2.AddComponent<MeshRenderer>();
                    rs2.GetComponent<Renderer>().material.color = Color.red;

                    Spline sp2 = GameObject.Find("roofsurfacelineL" + i).GetComponent<Spline>();
                    SplineMesh spm2 = GameObject.Find("roofsurfacelineL" + i).GetComponent<SplineMesh>();


                    spm2.spline = sp2;
                    spm2.xyScale = new Vector2(0.025f, 0.025f);
                    spm2.highAccuracy = true;
                    spm2.segmentCount = 1000;
                    Mesh cy2 = GameObject.Find("myline").GetComponent<MeshFilter>().mesh;
                    spm2.baseMesh = cy2;









                    if (i != angle)
                    {
                        for (int j = 0; j <= rson - 1; j++)
                        {
                            if (j % 2 == 1)
                            {
                                // GameObject.Find("roofsurface" + i + 1).transform.GetChild(j).gameObject.AddComponent<CurvySplineSegment>();
                                // GameObject.Find("roofsurface" + i + 1).transform.GetChild(j).transform.parent = GameObject.Find("roofsurface" + i).transform;
                                sp.splineNodesArray.Add(GameObject.Find("roofsurfaceM" + i).transform.GetChild(j).gameObject.GetComponent<SplineNode>());
                                sp2.splineNodesArray.Add(GameObject.Find("roofsurface" + (i + 1)).transform.GetChild(j).gameObject.GetComponent<SplineNode>());
                            }
                            else
                            {
                                //  GameObject.Find("roofsurface" + i).transform.GetChild(j).gameObject.AddComponent<CurvySplineSegment>();
                                //  GameObject.Find("roofsurface" + i).transform.GetChild(j).transform.parent = GameObject.Find("roofsurface" + i).transform;
                                sp.splineNodesArray.Add(GameObject.Find("roofsurface" + i).transform.GetChild(j).gameObject.GetComponent<SplineNode>());
                                sp2.splineNodesArray.Add(GameObject.Find("roofsurfaceM" + i).transform.GetChild(j).gameObject.GetComponent<SplineNode>());
                            }
                        }
                    }
                    else
                    {
                        for (int j = 0; j <= rson - 1; j++)
                        {
                            if (j % 2 == 1)
                            {
                                //  GameObject.Find("roofsurface1").transform.GetChild(j).gameObject.AddComponent<CurvySplineSegment>();
                                //  GameObject.Find("roofsurface1").transform.GetChild(j).transform.parent = GameObject.Find("roofsurface" + i).transform;
                                sp.splineNodesArray.Add(GameObject.Find("roofsurfaceM" + i).transform.GetChild(j).gameObject.GetComponent<SplineNode>());
                                sp2.splineNodesArray.Add(GameObject.Find("roofsurface1").transform.GetChild(j).gameObject.GetComponent<SplineNode>());
                            }
                            else
                            {
                                //  GameObject.Find("roofsurface" + i).transform.GetChild(j).gameObject.AddComponent<CurvySplineSegment>();
                                //  GameObject.Find("roofsurface" + i).transform.GetChild(j).transform.parent = GameObject.Find("roofsurface" + i).transform;
                                sp.splineNodesArray.Add(GameObject.Find("roofsurface" + i).transform.GetChild(j).gameObject.GetComponent<SplineNode>());
                                sp2.splineNodesArray.Add(GameObject.Find("roofsurfaceM" + i).transform.GetChild(j).gameObject.GetComponent<SplineNode>());
                            }
                        }
                    }
                }







            }











        }


        //PPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPP

        if (GUI.Button(new Rect(20 + 15, 50 + 240, 120, 20), "platform"))
        {
            int angle = int.Parse(UI.stringToEdit);


            if (GameObject.Find("pdotU1"))
            {
                Spline sp = GameObject.Find("platform").GetComponent<Spline>();
                Spline spD = GameObject.Find("platformD").GetComponent<Spline>();



                for (int i = 1; i <= angle; i++)
                {
                    sp.RemoveSplineNode(GameObject.Find("pdotU1"));
                    sp.RemoveSplineNode(GameObject.Find("pdotU" + i));
                    Destroy(GameObject.Find("pdotU" + i));
                    spD.RemoveSplineNode(GameObject.Find("pdotD1"));
                    spD.RemoveSplineNode(GameObject.Find("pdotD" + i));
                    Destroy(GameObject.Find("pdotD" + i));

                }

            }
            else
            {
                Vector3 ori = GameObject.Find("Ridge1").transform.GetChild(0).transform.position;




                Spline sp = GameObject.Find("platform").GetComponent<Spline>();
                Spline spD = GameObject.Find("platformD").GetComponent<Spline>();
                //SplineMesh spm = GameObject.Find("platform").GetComponent<SplineMesh>();
                for (int i = 1; i <= angle; i++)
                {
                    Vector3 colpos = GameObject.Find("column" + i).transform.GetChild(5).transform.position;
                    Vector3 vec = new Vector3(colpos.x - ori.x, 0, colpos.z - ori.z).normalized;

                    GameObject ptdot = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    ptdot.transform.parent = GameObject.Find("platform").transform;
                    ptdot.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                    Destroy(ptdot.GetComponent<Collider>());
                    Destroy(ptdot.GetComponent<MeshRenderer>());
                    Destroy(ptdot.GetComponent<MeshFilter>());
                    ptdot.name = ("pdotU" + i);
                    ptdot.transform.position = GameObject.Find("column" + i).transform.GetChild(4).transform.position + vec;
                    ptdot.AddComponent<SplineNode>();
                    ptdot.AddComponent<Pcibp>();
                    sp.splineNodesArray.Add(ptdot.gameObject.GetComponent<SplineNode>());

                    if (i == angle)
                    {
                        sp.splineNodesArray.Add(GameObject.Find("pdotU1").gameObject.GetComponent<SplineNode>());
                    }



                    GameObject ptdot2 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    ptdot2.transform.parent = GameObject.Find("platformD").transform;
                    ptdot2.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                    Destroy(ptdot2.GetComponent<Collider>());
                    Destroy(ptdot2.GetComponent<MeshRenderer>());
                    Destroy(ptdot2.GetComponent<MeshFilter>());
                    ptdot2.name = ("pdotD" + i);
                    ptdot2.transform.position = new Vector3(GameObject.Find("column" + i).transform.GetChild(4).transform.position.x, GameObject.Find("column" + i).transform.GetChild(4).transform.position.y - 1, GameObject.Find("column" + i).transform.GetChild(4).transform.position.z) + vec;
                    ptdot2.AddComponent<SplineNode>();
                    ptdot2.AddComponent<Pcibp>();
                    spD.splineNodesArray.Add(ptdot2.gameObject.GetComponent<SplineNode>());

                    if (i == angle)
                    {
                        spD.splineNodesArray.Add(GameObject.Find("pdotD1").gameObject.GetComponent<SplineNode>());
                    }
                }




            }
        }

        //******************************************************

        if (GUI.Button(new Rect(20 + 15, 50 + 270, 120, 20), "roofcurve"))
        {
            int angle = int.Parse(UI.stringToEdit);

            int tiled = int.Parse(UI.stringToEdit3);



            if (GameObject.Find("roofsurfaceM1"))
            {
                for (int i = 1; i <= angle; i++)
                {

                    Destroy(GameObject.Find("roofsurfaceM" + i));

                }
            }
            else
            {




                for (int i = 1; i <= angle; i++)
                {
                    GameObject rm2 = new GameObject();
                    rm2.name = ("roofsurfaceM" + i);
                    rm2.AddComponent<SplinePathCloneBuilder>();

                    SplinePathCloneBuilder rrr2 = rm2.GetComponent<SplinePathCloneBuilder>();

                    CurvySpline cs = GameObject.Find("roofcurve" + i).GetComponent<CurvySpline>();
                    float rrrlength = cs.Length;

                    rrr2.Gap = rrrlength / tiled;
                    rrr2.Source = new GameObject[1];
                    rrr2.Source[0] = GameObject.Find("empty").gameObject;
                    rrr2.Mode = SplinePathCloneBuilderMode.CloneGroup;

                    rrr2.Spline = GameObject.Find("Ridge" + i).GetComponent<CurvySpline>();




                     
                }

                //+++





                //+++


                //FUCK();

            }



        }



        if (GUI.Button(new Rect(20 + 15, 50 + 300, 120, 20), "magic"))
        {

            int angle = int.Parse(UI.stringToEdit);



            //GameObject.Find("Main Camera").AddComponent<magic>();



            for (int i = 1; i <= angle; i++)
            {



                SplinePathCloneBuilder rrr2 = GameObject.Find("roofsurfaceM" + i).GetComponent<SplinePathCloneBuilder>();
                SplinePathCloneBuilder rrr3 = GameObject.Find("eavepoint" + i).GetComponent<SplinePathCloneBuilder>();



                rrr2.Spline = GameObject.Find("roofcurve" + i).GetComponent<CurvySpline>();
                rrr3.Spline = GameObject.Find("eave" + i).GetComponent<CurvySpline>();
            }



        }

        if (GUI.Button(new Rect(20 + 15, 50 + 330, 120, 20), "platform mesh"))
        {

            int angle = int.Parse(UI.stringToEdit);
           
            
            
            



            GameObject TTL = new GameObject();
            TTL.name=("platformmesh");
            TTL.AddComponent<MeshFilter>();
            TTL.AddComponent<MeshRenderer>();


            MeshRenderer floor = TTL.GetComponent<MeshRenderer>();

            MeshRenderer floor1 = GameObject.Find("floorball").GetComponent<MeshRenderer>();

            floor.material = floor1.material;


            Mesh meshL = TTL.GetComponent<MeshFilter>().mesh;

            meshL.Clear();

            Vector3[] vL = new Vector3[2 * angle];
            Vector3[] nL = new Vector3[2 * angle];
            Vector2[] uvL = new Vector2[2 * angle];
            int[] tL = new int[3 * angle];




            uvL[0] = new Vector2(1, 1);
            uvL[1] = new Vector2(0, 1);
            uvL[2] = new Vector2(1, 0);

            nL[0] = -Vector3.up;
            nL[1] = -Vector3.up;
            nL[2] = -Vector3.up;

            Vector3 v1 = GameObject.Find("pdotU1").transform.position;
            Vector3 v2 = GameObject.Find("pdotU2").transform.position;
            Vector3 v3 = GameObject.Find("pdotU3").transform.position;

            vL[0] = v1;
            vL[1] = v2;
            vL[2] = v3;

            tL[0] = 0;
            tL[1] = 1;
            tL[2] = 2;

            for (int i = 4; i <= angle; i++)
            {

                Vector3 v4 = GameObject.Find("pdotU" + i).transform.position;

                vL[i - 1] = v4;


                if (i % 3 == 2)
                {
                    uvL[i - 1] = new Vector2(0, 1);
                }
                else if (i % 3 == 1)
                {
                    uvL[i - 2] = new Vector2(1, 0);
                }
                else
                {
                    uvL[i - 2] = new Vector2(0, 1);
                }



                nL[i - 1] = -Vector3.up;

                tL[i - 1 + (i - 4) * 2] = 0;
                tL[i + (i - 4) * 2] = i - 2;
                tL[(i + 1) + (i - 4) * 2] = i - 1;


            }











            meshL.vertices = vL;
            meshL.triangles = tL;
            meshL.normals = nL;
            meshL.uv = uvL;




            for (int i = 1; i <= angle; i++)
            {
                GameObject side = new GameObject();
                side.name = ("side" + i);
                side.AddComponent<MeshFilter>();
                side.AddComponent<MeshRenderer>();

                MeshRenderer floor2 = side.GetComponent<MeshRenderer>();

                floor2.material = floor1.material;


                Mesh mesh = side.GetComponent<MeshFilter>().mesh;

                mesh.Clear();


                if (i != angle)
                {
                    Vector3 V1 = GameObject.Find("pdotU" + i).transform.position;
                    Vector3 V2 = GameObject.Find("pdotU" + (i + 1)).transform.position;
                    Vector3 V3 = GameObject.Find("pdotD" + i).transform.position;
                    Vector3 V4 = GameObject.Find("pdotD" + (i + 1)).transform.position;


                    mesh.vertices = new Vector3[] { V1, V2, V3, V4 };
                }
                else
                {
                    Vector3 V1 = GameObject.Find("pdotU" + i).transform.position;
                    Vector3 V2 = GameObject.Find("pdotU1").transform.position;
                    Vector3 V3 = GameObject.Find("pdotD" + i).transform.position;
                    Vector3 V4 = GameObject.Find("pdotD1").transform.position;


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

        //ya
        if (GUI.Button(new Rect(20 + 15, 50 + 360, 120, 20), "luff"))
        {
            rson = GameObject.Find("roofsurface1").transform.childCount;
            rson2 = GameObject.Find("roofsurfaceM1").transform.childCount;

            rson = Mathf.Min(rson, rson2);


            float uvR = (1 / (float)rson);


            int angle = int.Parse(UI.stringToEdit);

            MeshRenderer floor1 = GameObject.Find("roofball").GetComponent<MeshRenderer>();


            for (int i = 1; i <= angle; i++)
            {
                whichroof = i;
                //RIGHT
                GameObject TTR = new GameObject();
                TTR.name = ("TTR" + i);
                /*
                TTR.AddComponent<MeshFilter>();
                TTR.AddComponent<MeshRenderer>();
                */
                TTR.AddComponent<rightroof>();


                /*
                MeshRenderer floor = TTR.GetComponent<MeshRenderer>();
                MeshRenderer floor1 = GameObject.Find("roofball").GetComponent<MeshRenderer>();
                floor.material = floor1.material;
                */
                /*
                Mesh mesh = TTR.GetComponent<MeshFilter>().mesh;
                mesh.Clear();

                TTR.GetComponent<MeshCollider>().sharedMesh = mesh;

                Vector3[] v = new Vector3[2 * rson];
                Vector3[] n = new Vector3[2 * rson];
                Vector2[] uv = new Vector2[2 * rson];
                int[] t = new int[6 * rson];

                for (int j = 0; j <= rson - 1; j++)
                {
                    if (j == 0)
                    {
                       
                        Vector3 v1 = GameObject.Find("roofsurface"+i).transform.GetChild(j).transform.position;
                        Vector3 v2 = GameObject.Find("roofsurfaceM"+i).transform.GetChild(j + 1).transform.position;
                        Vector3 v3 = GameObject.Find("roofsurface"+i).transform.GetChild(j + 1).transform.position;
                        v[0] = (v1);
                        v[1] = (v2);
                        v[2] = (v3);


                        uv[0] = new Vector2(0, 1);
                        uv[1] = new Vector2(0, 1-uvR);
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
                        Vector3 v3 = GameObject.Find("roofsurfaceM"+i).transform.GetChild(j).transform.position;
                        Vector3 v4 = GameObject.Find("roofsurface"+i).transform.GetChild(j).transform.position;

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
                */
                //LEFT
                GameObject TTL = new GameObject();
                TTL.name = ("TTL" + i);


                TTL.AddComponent<leftroof>();





            }

        }
        //ya
        //*****

        if (GUI.Button(new Rect(20 + 15, 50 + 390, 120, 20), "p"))
        {
            int angle = int.Parse(UI.stringToEdit);

            for (int i = 1; i <= angle; i++)
            {
                GameObject side = new GameObject();
                side.name = ("Frieze" + i);
                side.AddComponent<Frieze>();
                side.transform.parent = GameObject.Find("column" + i).transform;

            }

            /*
            int angle = int.Parse(UI.stringToEdit);

            for (int i = 1; i <= angle; i++)
            {
                GameObject side = new GameObject();
                side.name = ("Frieze" + i);
                side.AddComponent<Friezemesh>();
 
            }
            */
        }

        if (GUI.Button(new Rect(20 + 15, 50 + 420, 120, 20), "b"))
        {
            int angle = int.Parse(UI.stringToEdit);

            for (int i = 1; i <= angle; i++)
            {
                GameObject side = new GameObject();
                side.name = ("Balustrade" + i);

                side.AddComponent<Balustrade>();

            }


            /*
            int angle = int.Parse(UI.stringToEdit);
            
            for (int i = 1; i <= angle; i++)
            {
                GameObject side = new GameObject();
                side.name = ("Balustrade" + i);
           
                side.AddComponent<Balustrademesh>();
                
            }
            */
        }

        stringToEdit3 = GUI.TextField(new Rect(20 + 15, 50 + 450, 120, 20), stringToEdit3);

        if (GUI.Button(new Rect(20 + 15, 50 + 480, 120, 20), "z"))
        {
            GLCurvyRenderer gl = GameObject.Find("Main Camera").GetComponent<GLCurvyRenderer>();
            int angle = int.Parse(UI.stringToEdit);
            int haha = int.Parse(UI.stringToEdit3);


            for (int i = 1; i <= angle; i++)
            {
                //GameObject roofcurve = GameObject.CreatePrimitive(PrimitiveType.Sphere); 


                int haha2;
                haha2 = 60 / haha;


                for (int j = 1; j <= haha; j++)
                {
                    
                    GameObject roofcurve = new GameObject();
                    roofcurve.transform.RotateAround(GameObject.Find("Ridge1").transform.GetChild(0).transform.position, Vector3.up, (360 / angle) * (i - 1));
                    roofcurve.AddComponent<CurvySpline>();


                    //roofcurve.GetComponent<MeshRenderer>().enabled = false;
                    //roofcurve.GetComponent<Renderer>().material.color = Color.green;


                    //****************
                    Vector3 ori = GameObject.Find("Ridge1").transform.GetChild(0).transform.position;
                    Vector3 ori3 = GameObject.Find("eave1").transform.GetChild(5).transform.position;
                    Vector3 ori2 = (ori3 + ori) / 2;

                    ori2.y = ori2.y - 0.5f;



                    GameObject roofson1 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    roofson1.transform.parent = roofcurve.transform;
                    roofson1.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                    roofson1.name = ("CP000");
                    roofson1.AddComponent<CurvySplineSegment>();
                    CurvySplineSegment csg = roofson1.GetComponent<CurvySplineSegment>();

                    csg._InitializeControlPoint();


                    roofson1.transform.position = ori;
                    roofson1.transform.RotateAround(GameObject.Find("Ridge1").transform.GetChild(0).transform.position, Vector3.up, (360 / angle) * (i - 1));

                    if (i != 1)
                    {
                        Destroy(roofson1.GetComponent<MeshRenderer>());
                    }


                    GameObject roofson2 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    roofson2.transform.parent = roofcurve.transform;
                    roofson2.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                    roofson2.name = ("CP001");
                    roofson2.AddComponent<CurvySplineSegment>();
                    roofson2.AddComponent<roofsurface>();

                    roofson2.transform.position = ori2;
                    roofson2.transform.RotateAround(GameObject.Find("Ridge1").transform.GetChild(0).transform.position, Vector3.up, (360 / angle) * (i - 1));
                    if (i != 1)
                    {
                        Destroy(roofson2.GetComponent<MeshRenderer>());
                    }
                    GameObject roofson3 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    roofson3.transform.parent = roofcurve.transform;
                    roofson3.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                    roofson3.name = ("CP002");
                    roofson3.AddComponent<CurvySplineSegment>();
                    roofson3.AddComponent<copyeave5>();

                    roofson3.transform.position = ori3;
                    roofson3.transform.RotateAround(GameObject.Find("Ridge1").transform.GetChild(0).transform.position, Vector3.up, (360 / angle) * (i - 1));

                    Destroy(roofson3.GetComponent<MeshRenderer>());


                    //***********************


                    gl.Splines[4 * angle + 1 + i] = roofcurve.GetComponent<CurvySpline>();








                    //roofcurve.AddComponent<MeshFilter>();





                }

            }
        }

        if (GUI.Button(new Rect(20 + 15, 50 + 510, 120, 20), "eave point"))
        {
            int angle = int.Parse(UI.stringToEdit);

            int tiled = int.Parse(UI.stringToEdit3);

            //eavepoint

                for (int i = 1; i <= angle; i++)
                {
                    GameObject rm2 = new GameObject();
                    rm2.name = ("eavepoint" + i);
                    rm2.AddComponent<SplinePathCloneBuilder>();

                    SplinePathCloneBuilder rrr2 = rm2.GetComponent<SplinePathCloneBuilder>();

                    CurvySpline cs = GameObject.Find("eave" + i).GetComponent<CurvySpline>();
                    float rrrlength = cs.Length;

                    rrr2.Gap = rrrlength / (tiled*2);
                    rrr2.Source = new GameObject[1];
                    rrr2.Source[0] = GameObject.Find("empty").gameObject;
                    rrr2.Mode = SplinePathCloneBuilderMode.CloneGroup;

                    rrr2.Spline = GameObject.Find("Ridge" + i).GetComponent<CurvySpline>();





                }
            
            //十字









              


        }
        if (GUI.Button(new Rect(20 + 15, 50 + 540, 120, 20), "444"))
        {
            int angle = int.Parse(UI.stringToEdit);
            int tiled = int.Parse(UI.stringToEdit2);

            GLCurvyRenderer gl = GameObject.Find("Main Camera").GetComponent<GLCurvyRenderer>();
            int num = 0;

            for (int i = 1; i <= angle; i++)
            {
                //GameObject roofcurve = GameObject.CreatePrimitive(PrimitiveType.Sphere); 



                for (int j = 1; j <= (tiled-1); j++)
                {



                GameObject roofcurve = new GameObject();
                roofcurve.transform.RotateAround(GameObject.Find("Ridge1").transform.GetChild(0).transform.position, Vector3.up, (360 / angle) * (i - 1));
                roofcurve.AddComponent<CurvySpline>();
                roofcurve.name = ("roofcurveex" + i+"R"+j);
                roofcurve.AddComponent<Pcit>();
                //roofcurve.GetComponent<MeshRenderer>().enabled = false;
                //roofcurve.GetComponent<Renderer>().material.color = Color.green;


                //****************
                Vector3 ori = GameObject.Find("Ridge1").transform.GetChild(0).transform.position;
                Vector3 ori3 = GameObject.Find("eave1").transform.GetChild(5).transform.position;
                Vector3 ori2 = (ori3 + ori) / 2;

                ori2.y = ori2.y - 0.5f;


                GameObject roofson1 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                roofson1.transform.parent = roofcurve.transform;
                roofson1.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                roofson1.name = ("CP002");
                roofson1.AddComponent<CurvySplineSegment>();
                CurvySplineSegment csg = roofson1.GetComponent<CurvySplineSegment>();

                csg._InitializeControlPoint();


                    roofson1.transform.position = GameObject.Find("roofsurface1").transform.GetChild(j).transform.position;
               // roofson1.transform.RotateAround(GameObject.Find("Ridge1").transform.GetChild(0).transform.position, Vector3.up, (360 / angle) * (i - 1));

              
                
                    Destroy(roofson1.GetComponent<MeshRenderer>());


                    int eavenum = GameObject.Find("eavepoint" + i).transform.GetChildCount();
                    Vector3 r2= GameObject.Find("eavepoint1").transform.GetChild(eavenum / 2 - j).transform.position;
                    


                GameObject roofson2 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                roofson2.transform.parent = roofcurve.transform;
                roofson2.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                roofson2.name = ("CP001");
                roofson2.AddComponent<CurvySplineSegment>();
                roofson2.AddComponent<roofsurface>();




                  Vector3 rr2=  (roofson1.transform.position + r2) / 2;


                roofson2.transform.position = rr2;
                roofson2.transform.position = new Vector3(roofson2.transform.position.x, roofson2.transform.position.y - 0.5f, roofson2.transform.position.z);
               // roofson2.transform.RotateAround(GameObject.Find("Ridge1").transform.GetChild(0).transform.position, Vector3.up, (360 / angle) * (i - 1));
                
                    Destroy(roofson2.GetComponent<MeshRenderer>());
                
                GameObject roofson3 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                roofson3.transform.parent = roofcurve.transform;
                roofson3.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                roofson3.name = ("CP000");
                roofson3.AddComponent<CurvySplineSegment>();
                roofson3.AddComponent<copyeave5>();

                 
                roofson3.transform.position = GameObject.Find("eavepoint1").transform.GetChild(eavenum/2-j).transform.position; 
               // roofson3.transform.RotateAround(GameObject.Find("Ridge1").transform.GetChild(0).transform.position, Vector3.up, (360 / angle) * (i - 1));

                Destroy(roofson3.GetComponent<MeshRenderer>());

                    roofson1.transform.RotateAround(GameObject.Find("Ridge1").transform.GetChild(0).transform.position, Vector3.up, (360 / angle) * (i - 1));
                    roofson2.transform.RotateAround(GameObject.Find("Ridge1").transform.GetChild(0).transform.position, Vector3.up, (360 / angle) * (i - 1));
                    roofson3.transform.RotateAround(GameObject.Find("Ridge1").transform.GetChild(0).transform.position, Vector3.up, (360 / angle) * (i - 1));
                    //***********************
                    num++;

                    gl.Splines[100 + num] = roofcurve.GetComponent<CurvySpline>();

                    /*
                    GameObject rm = new GameObject();
                    rm.name = ("roofsurfaceMusle" + i);
                    rm.AddComponent<SplinePathCloneBuilder>();
                    SplinePathCloneBuilder rrr = rm.GetComponent<SplinePathCloneBuilder>();

                    rrr.Spline = roofcurve.GetComponent<CurvySpline>();



                    CurvySpline cs = roofcurve.GetComponent<CurvySpline>();
                    float rrrlength = cs.Length;


                    print("haha:" + cs.Length);
                    print("ttttt:" + (tiled - j));



                    rrr.Gap = rrrlength / (tiled - j);
                    rrr.Mode = SplinePathCloneBuilderMode.CloneGroup;
                    rrr.Source = new GameObject[1];
                    rrr.Source[0] = GameObject.Find("empty");

                    */
                    


                    //roofcurve.AddComponent<MeshFilter>();
                    

                }




            }

            for (int i = 1; i <= angle; i++)
            {
                //GameObject roofcurve = GameObject.CreatePrimitive(PrimitiveType.Sphere); 



                for (int j = 1; j <= (tiled-1); j++)
                {



                    GameObject roofcurve = new GameObject();
                    roofcurve.transform.RotateAround(GameObject.Find("Ridge1").transform.GetChild(0).transform.position, Vector3.up, (360 / angle) * (i - 1));
                    roofcurve.AddComponent<CurvySpline>();
                    roofcurve.name = ("roofcurveex" + i+"L"+j);
                    roofcurve.AddComponent<Pcit>();
                    //roofcurve.GetComponent<MeshRenderer>().enabled = false;
                    //roofcurve.GetComponent<Renderer>().material.color = Color.green;


                    //****************
                    Vector3 ori = GameObject.Find("Ridge1").transform.GetChild(0).transform.position;
                    Vector3 ori3 = GameObject.Find("eave1").transform.GetChild(5).transform.position;
                    Vector3 ori2 = (ori3 + ori) / 2;

                    ori2.y = ori2.y - 0.5f;


                    GameObject roofson1 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    roofson1.transform.parent = roofcurve.transform;
                    roofson1.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                    roofson1.name = ("CP002");
                    roofson1.AddComponent<CurvySplineSegment>();
                    CurvySplineSegment csg = roofson1.GetComponent<CurvySplineSegment>();

                    csg._InitializeControlPoint();


                    roofson1.transform.position = GameObject.Find("roofsurface2").transform.GetChild(j).transform.position;
                    // roofson1.transform.RotateAround(GameObject.Find("Ridge1").transform.GetChild(0).transform.position, Vector3.up, (360 / angle) * (i - 1));



                    Destroy(roofson1.GetComponent<MeshRenderer>());


                    int eavenum = GameObject.Find("eavepoint" + i).transform.GetChildCount();
                    Vector3 r2 = GameObject.Find("eavepoint1").transform.GetChild(eavenum / 2 + j).transform.position;



                    GameObject roofson2 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    roofson2.transform.parent = roofcurve.transform;
                    roofson2.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                    roofson2.name = ("CP001");
                    roofson2.AddComponent<CurvySplineSegment>();
                    roofson2.AddComponent<roofsurface>();




                    Vector3 rr2 = (roofson1.transform.position + r2) / 2;


                    roofson2.transform.position = rr2;
                    roofson2.transform.position = new Vector3(roofson2.transform.position.x, roofson2.transform.position.y - 0.5f, roofson2.transform.position.z);
                    // roofson2.transform.RotateAround(GameObject.Find("Ridge1").transform.GetChild(0).transform.position, Vector3.up, (360 / angle) * (i - 1));

                    Destroy(roofson2.GetComponent<MeshRenderer>());

                    GameObject roofson3 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    roofson3.transform.parent = roofcurve.transform;
                    roofson3.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                    roofson3.name = ("CP000");
                    roofson3.AddComponent<CurvySplineSegment>();
                    roofson3.AddComponent<copyeave5>();


                    roofson3.transform.position = GameObject.Find("eavepoint1").transform.GetChild(eavenum / 2 + j).transform.position;
                    // roofson3.transform.RotateAround(GameObject.Find("Ridge1").transform.GetChild(0).transform.position, Vector3.up, (360 / angle) * (i - 1));

                    Destroy(roofson3.GetComponent<MeshRenderer>());

                    roofson1.transform.RotateAround(GameObject.Find("Ridge1").transform.GetChild(0).transform.position, Vector3.up, (360 / angle) * (i - 1));
                    roofson2.transform.RotateAround(GameObject.Find("Ridge1").transform.GetChild(0).transform.position, Vector3.up, (360 / angle) * (i - 1));
                    roofson3.transform.RotateAround(GameObject.Find("Ridge1").transform.GetChild(0).transform.position, Vector3.up, (360 / angle) * (i - 1));
                    //***********************
                    num++;

                    gl.Splines[200 + num] = roofcurve.GetComponent<CurvySpline>();

                    /*
                    
                    GameObject rm = new GameObject();
                    rm.name = ("roofsurfaceMusle" + i);
                    rm.AddComponent<SplinePathCloneBuilder>();
                    SplinePathCloneBuilder rrr = rm.GetComponent<SplinePathCloneBuilder>();

                    rrr.Spline = roofcurve.GetComponent<CurvySpline>();

                    CurvySpline cs = roofcurve.GetComponent<CurvySpline>();

                    float rrrlength = cs.Length;

                    rrr.Gap = rrrlength / (tiled - j);
                    rrr.Mode = SplinePathCloneBuilderMode.CloneGroup;
                    rrr.Source = new GameObject[1];
                    rrr.Source[0] = GameObject.Find("empty");

                    */




                    //roofcurve.AddComponent<MeshFilter>();


                }

               




            }
           















        }
        
        stringToEdit4 = GUI.TextField(new Rect(20 + 15, 50 + 570, 120, 20), stringToEdit4);
        if (GUI.Button(new Rect(20 + 15, 50 +600, 120, 20), "AP+"))
        {


        }





    }


    public void addpoint()
    {

      

        int angle = int.Parse(UI.stringToEdit);

        int tiled = int.Parse(UI.stringToEdit2);

     

        //右邊

        for (int i =1;i<=angle;i++)
        {

           GameObject R1 =new GameObject();

            R1.name = ("rrrR" + i);
            Vector3 start = GameObject.Find("roofcurve" + i).transform.GetChild(1).transform.position;
            Vector3 end = GameObject.Find("Ridge" + i).transform.GetChild(pubvar.ball - 1).transform.position;

            Vector3 mid = (end - start) / tiled;
            for (int j = 1; j <= tiled; j++)
            {
                GameObject oh = new GameObject();
                oh.transform.parent=R1.transform;
                oh.transform.position = start + mid * j;
    
            
            }

        }

        //左邊

        for (int i = 1; i <= angle; i++)
        {

            if (i != angle)
            {

                GameObject L1 = new GameObject();

                L1.name = ("rrrL" + i);
                Vector3 start = GameObject.Find("roofcurve" + i).transform.GetChild(1).transform.position;
                Vector3 end = GameObject.Find("Ridge" + (i + 1)).transform.GetChild(pubvar.ball - 1).transform.position;

                Vector3 mid = (end - start) / tiled;
                for (int j = 1; j <= tiled; j++)
                {
                    GameObject oh = new GameObject();
                    oh.transform.parent = L1.transform;
                    oh.transform.position = start + mid * j;


                }
            }
            else
            {
                GameObject L1 = new GameObject();

                L1.name = ("rrrL" + i);
                Vector3 start = GameObject.Find("roofcurve" + i).transform.GetChild(1).transform.position;
                Vector3 end = GameObject.Find("Ridge1").transform.GetChild(pubvar.ball - 1).transform.position;

                Vector3 mid = (end - start) / tiled;
                for (int j = 1; j <= tiled; j++)
                {
                    GameObject oh = new GameObject();
                    oh.transform.parent = L1.transform;
                    oh.transform.position = start + mid * j;


                }
            }




        }



        





    }
    public void deletepoint()
    {
        int angle = int.Parse(UI.stringToEdit);
        for (int i = 1; i <= angle; i++)
        {
            Destroy(GameObject.Find("rrrR" + i));
            Destroy(GameObject.Find("rrrL" + i));
        }
    }



    
}
