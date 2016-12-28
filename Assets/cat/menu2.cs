using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class menu2 : MonoBehaviour {


    static CurvySplineSegment shit;
    CurvySpline mSpline=shit.Spline;

   
    
   

	// Use this for initialization
    void Start() 
    {

        print("ghahahahah");
       
       
	}

    // Update is called once per frame
    void Update()
    {
        if (pubvar.ball >= 2)
        {

            //GameObject.Find("path").GetComponent<SplinePathCloneBuilder>().enabled = true;
        }
        else
        {
            //GameObject.Find("path").GetComponent<SplinePathCloneBuilder>().enabled = false;
        }
        //PRESS Z
        if (Input.GetKeyDown(KeyCode.Z))
        {
            
            int angle = int.Parse(UI.stringToEdit);


            Destroy(GameObject.Find("column1").transform.GetChild(0).GetComponent<Zevent>());
            Destroy(GameObject.Find("column1").transform.GetChild(1).GetComponent<Zevent>());
            Destroy(GameObject.Find("column1").transform.GetChild(2).GetComponent<Zevent>());
            Destroy(GameObject.Find("column1").transform.GetChild(4).GetComponent<Zevent>());

            Destroy(GameObject.Find("Ridge1").transform.GetChild(pubvar.ball - 1).GetComponent<copyevent>());


            if (GameObject.Find("Ridge1").GetComponent<Zevent>().enabled == true)
            {



                for (int i = 0; i < GameObject.Find("Ridge1").transform.childCount; i++)
                {
                    GameObject go = GameObject.Find("Ridge1").transform.GetChild(i).gameObject;
                    Destroy(go.GetComponent<mice1>());
                    Destroy(go.GetComponent<Zevent>());

                    Destroy(go.GetComponent<copyevent>());
                    //Destroy(go.GetComponent<ridgetailmove>());

                    go.GetComponent<Renderer>().material.color = Color.white;
                    pubvar.PUBnum = 0;
                }

                for (int i = 1; i <= angle; i++)
                {
                    if (GameObject.Find("Ridge" + i).transform.GetChild(pubvar.ball - 1).GetComponent<Pcib>())
                    {
                        if (GameObject.Find("roofcurve" + i))
                        {
                             Destroy(GameObject.Find("roofcurve" + i).transform.GetChild(1).GetComponent<Zevent>());
                        }

                        Destroy(GameObject.Find("Ridge" + i).transform.GetChild(pubvar.ball - 1).GetComponent<Pcib>());
                    }
                }


                GameObject.Find("Ridge1").GetComponent<Zevent>().enabled = false;
                GameObject.Find("ZZZ").GetComponent<Renderer>().material.color = Color.white;

                Destroy(GameObject.Find("Ridge1").transform.GetChild(0).gameObject.GetComponent<updown>());

            }
            else
            {

                GameObject.Find("column1").transform.GetChild(0).gameObject.AddComponent<Zevent>();
                GameObject.Find("column1").transform.GetChild(1).gameObject.AddComponent<Zevent>();
                GameObject.Find("column1").transform.GetChild(2).gameObject.AddComponent<Zevent>();
                GameObject.Find("column1").transform.GetChild(4).gameObject.AddComponent<Zevent>();
                for (int i = 1; i <= angle; i++)
                {
                    GameObject.Find("Ridge" + i).transform.GetChild(pubvar.ball - 1).gameObject.AddComponent<Pcib>();
                    if (GameObject.Find("roofcurve" + i))
                    {
                        if(GameObject.Find("roofcurve" + i).transform.GetChild(1))
                        {
                            GameObject.Find("roofcurve" + i).transform.GetChild(1).gameObject.AddComponent<Zevent>();
                        }
                    }

                }

                for (int i = 0; i < GameObject.Find("Ridge1").transform.childCount; i++)
                {
                    GameObject go = GameObject.Find("Ridge1").transform.GetChild(i).gameObject;
                    go.AddComponent<Zevent>();


                    if (i != pubvar.ball - 1)
                    {

                        if (i != 0)
                        {
                            go.AddComponent<copyevent>();
                        }
                    }



                }

                GameObject.Find("Ridge1").GetComponent<Zevent>().enabled = true;
                GameObject.Find("ZZZ").GetComponent<Renderer>().material.color = Color.green;

                GameObject.Find("Ridge1").transform.GetChild(0).gameObject.AddComponent<updown>();

            }



        }
        //
        //PRESS X
        if (Input.GetKeyDown(KeyCode.X))
        {

            if (GameObject.Find("Ridge1").GetComponent<MouseAddControlPoint>().enabled == true)
            {
                for (int i = 0; i < GameObject.Find("Ridge1").transform.childCount; i++)
                {
                    GameObject go = GameObject.Find("Ridge1").transform.GetChild(i).gameObject;
                    Destroy(go.GetComponent<mice2>());
                }
                GameObject.Find("Ridge1").GetComponent<MouseAddControlPoint>().enabled = false;
                GameObject.Find("XXX").GetComponent<Renderer>().material.color = Color.white;
            }
            else
            {
                for (int i = 0; i < GameObject.Find("Ridge1").transform.childCount; i++)
                {
                    GameObject go = GameObject.Find("Ridge1").transform.GetChild(i).gameObject;
                    go.AddComponent<mice2>();
                }

                GameObject.Find("Ridge1").GetComponent<MouseAddControlPoint>().enabled = true;
                GameObject.Find("XXX").GetComponent<Renderer>().material.color = Color.red;

            }
        }
        //
        //PRESS C
        if (Input.GetKeyDown(KeyCode.C))
        {
            /*
            GameObject haha = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            haha.transform.position = new Vector3(0, 0, -7.06f);
            haha.transform.localScale = new Vector3(0.25f, 2, 0.25f);
            haha.AddComponent<mousemoveA>();
            haha.AddComponent<Zevent>();
            haha.tag = "PIG";

            */
              GameObject seeme = new GameObject();
            seeme.name=("seeme");
            seeme.transform.position = new Vector3(GameObject.Find("Ridge1").transform.GetChild(0).transform.position.x, (GameObject.Find("Ridge1").transform.GetChild(0).transform.position.y + GameObject.Find("column1").transform.GetChild(3).transform.position.y) / 2, GameObject.Find("Ridge1").transform.GetChild(0).transform.position.z);
            
            GameObject.Find("Main Camera").AddComponent<eye>();          
           eye see = GameObject.Find("Main Camera").GetComponent<eye>();


            see.target = GameObject.Find("seeme").transform;

        }
        //
        if (Input.GetKeyDown(KeyCode.V))
        {


            for (int i = 1; i < (pubvar.ball); i++)
            {
                Destroy(GameObject.Find("Ridge1").transform.GetChild(i - 1).GetComponent<ridgetailmove>());
            }




            int angle = int.Parse(UI.stringToEdit);

            //GameObject.Find("DynamicSpline").transform.GetChild(0).transform.localScale = new Vector3(0.5f,0.5f,0.5f);
            //line~~~
            GLCurvyRenderer gl = GameObject.Find("Main Camera").GetComponent<GLCurvyRenderer>();



            gl.Splines = new CurvySplineBase[500];
            gl.Splines[0] = GameObject.Find("Ridge1").GetComponent<CurvySpline>();
            gl.Splines[1] = GameObject.Find("column1").GetComponent<CurvySpline>();


            //gl.Splines = new CurvySplineBase[angle+10];





            // GameObject.Find("DynamicSpline").transform.RotateAround(GameObject.Find("DynamicSpline").transform.GetChild(0).transform.position,Vector3.up, 360/angle);

            //Instantiate(GameObject.Find("DynamicSpline"), GameObject.Find("DynamicSpline").transform.position, Quaternion.Euler(0, 360 / angle, 0));
            if (GameObject.Find("Ridge2"))
            {

                for (int i = 2; i < angle; i++)
                {
                    if (GameObject.Find("Ridge" + i))
                    {
                        Destroy(GameObject.Find("Ridge" + i));
                    }
                }
            }
            else
            {
                for (int i = 1; i < angle; i++)
                {
                    Destroy(GameObject.Find("Ridge" + i).transform.GetChild(pubvar.ball - 1).GetComponent<copyevent>());
               
                    print("~~~~~~~~~~~~~~~~~~~" + i);
                    GameObject go = Instantiate(GameObject.Find("Ridge1"), GameObject.Find("Ridge1").transform.position, Quaternion.identity) as GameObject;
                    go.transform.RotateAround(GameObject.Find("Ridge1").transform.GetChild(0).transform.position, Vector3.up, (360 / angle) * i);
                    go.name = ("Ridge" + (i + 1));

                    //column
                    GameObject col = Instantiate(GameObject.Find("column1"), GameObject.Find("column1").transform.position, Quaternion.identity) as GameObject;
                    col.transform.RotateAround(GameObject.Find("Ridge1").transform.GetChild(0).transform.position, Vector3.up, (360 / angle) * i);
                    col.name = ("column" + (i + 1));

                    for (int j = 0; j < go.transform.childCount; j++)
                    {
                        GameObject goson = go.transform.GetChild(j).gameObject;
                        //goson.AddComponent<copyevent>();
                        if (j != 0)
                        {
                            goson.AddComponent<copyevent>();
                        }
                        Destroy(goson.GetComponent<MeshRenderer>());
                    }

                    for (int k = 0; k < col.transform.childCount; k++)
                    {
                        GameObject colson = col.transform.GetChild(k).gameObject;
                        Destroy(colson.GetComponent<MeshRenderer>());
                    }





                    gl.Splines[2 * i] = go.GetComponent<CurvySpline>();
                    gl.Splines[2 * i + 1] = col.GetComponent<CurvySpline>();


                }
            }
            if (GameObject.Find("Ridge"+angle))
            {
                Destroy(GameObject.Find("Ridge" + angle).transform.GetChild(pubvar.ball - 1).GetComponent<copyevent>());
            }



        }
        if (Input.GetKeyDown(KeyCode.B))
        {

            GLCurvyRenderer gl = GameObject.Find("Main Camera").GetComponent<GLCurvyRenderer>();


            int angle = int.Parse(UI.stringToEdit);

            if (GameObject.Find("eave1"))
            {
                for (int i = 1; i <= angle; i++)
                {
                    Destroy(GameObject.Find("eave" + i));
                }
            }



            for (int i = 1; i <= angle; i++)
            {

                GameObject eave = new GameObject();
                eave.AddComponent<CurvySpline>();
                eave.name = ("eave" + i);
                eave.AddComponent<Pcit>();

                Vector3 ori = GameObject.Find("Ridge1").transform.GetChild(pubvar.ball - 1).transform.position;
                Vector3[] y = new Vector3[2];
                //transform.RotateAround(GameObject.Find("DynamicSpline").transform.GetChild(0).transform.position, Vector3.up, (360 / angle) * i);


                for (int j = 1; j <= 2; j++)
                {
                    GameObject eaveson = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    eaveson.transform.parent = eave.transform;
                    //eaveson.transform.parent = GameObject.Find("Main Camera").transform;
                    eaveson.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                    eaveson.name = ("haha");
                    //eaveson.AddComponent<CurvySplineSegment>();
                    eaveson.transform.position = ori;
                    eaveson.transform.RotateAround(GameObject.Find("Ridge1").transform.GetChild(0).transform.position, Vector3.up, (360 / angle) * (i + j - 2));

                    y[j - 1] = eaveson.transform.position;

                    Destroy(eaveson.GetComponent<MeshRenderer>());


                }

                Vector3 dis = (y[1] - y[0]) / 8;
                pubvar.arrow = dis;

                for (int j = 1; j <= 9; j++)
                {
                    if (j != 4 && j != 6 )
                    { 
                    GameObject eaveson = GameObject.CreatePrimitive(PrimitiveType.Sphere);

                    eaveson.transform.parent = eave.transform;
                    eaveson.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                    eaveson.name = ("CP00" + j);
                    eaveson.AddComponent<CurvySplineSegment>();
                    eaveson.AddComponent<ridgetailmove2>();
                    //eaveson.AddComponent<Zevent>();
                   
                    eaveson.transform.position = ori;
                    eaveson.transform.RotateAround(GameObject.Find("Ridge1").transform.GetChild(0).transform.position, Vector3.up, (360 / angle) * (i - 1));

                    Vector3 ori2 = eaveson.transform.position;
                    eaveson.transform.position = ori2 + dis * (j - 1);

                    if (j == 2 || j == 8)
                    {
                        eaveson.transform.Translate(0, -0.35f, 0);
                        if (j == 2 && i == 1)
                        {
                            eaveson.AddComponent<vectormove>();
                            eaveson.AddComponent<copyeave>();
                        }
                        if (j == 2 && i != 1)
                        {
                            eaveson.AddComponent<copyeave>();
                        }
                        if (j == 8)
                        {
                            eaveson.AddComponent<copyeave2>();
                        }

                    }
                    if (j == 3 || j == 4 || j == 5 || j == 6 || j == 7)
                    {
         

                        eaveson.transform.Translate(0, -0.45f, 0);
                        if (j==3)
                        {

                            eaveson.AddComponent<copyeave3>();
                            if (i==1)
                            {
                                eaveson.AddComponent<vectormove>();
                            }
                        }
                        if (j == 7)
                        {

                            eaveson.AddComponent<copyeave4>();
                        }
                        if (j == 5)
                        {

                            eaveson.AddComponent<copyeave5>();
                        }




                    }
                    if (i != 1)
                    {
                        Destroy(eaveson.GetComponent<MeshRenderer>());
                    }

                    if (j != 1 && j != 2 && j != 3)
                    {

                        Destroy(eaveson.GetComponent<MeshRenderer>());
                    }

                }
                }


                gl.Splines[2 * angle + i - 1] = eave.GetComponent<CurvySpline>();

            }

        }

        //屋頂曲度


        if (Input.GetKeyDown(KeyCode.N))
        {
            GLCurvyRenderer gl = GameObject.Find("Main Camera").GetComponent<GLCurvyRenderer>();
            int angle = int.Parse(UI.stringToEdit);


            if (GameObject.Find("roofcurve2"))
            {
                for (int i = 1; i <= angle; i++)
                {
                    Destroy(GameObject.Find("roofcurve" + i));
                }             
            }



            
                for (int i = 1; i <= angle; i++)
                {
                    //GameObject roofcurve = GameObject.CreatePrimitive(PrimitiveType.Sphere); 




                        GameObject roofcurve = new GameObject();
                        roofcurve.transform.RotateAround(GameObject.Find("Ridge1").transform.GetChild(0).transform.position, Vector3.up, (360 / angle) * (i - 1));
                        roofcurve.AddComponent<CurvySpline>();


                        roofcurve.AddComponent<catline>();
                roofcurve.AddComponent<planecut>();
                
                roofcurve.AddComponent<newtiled>();


                roofcurve.name = ("roofcurve" + i);
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
                        roofson3.name = ("CP000");
                        roofson3.AddComponent<CurvySplineSegment>();
                        roofson3.AddComponent<copyeave5>();

                        roofson3.transform.position = ori3;
                        roofson3.transform.RotateAround(GameObject.Find("Ridge1").transform.GetChild(0).transform.position, Vector3.up, (360 / angle) * (i - 1));

                        Destroy(roofson3.GetComponent<MeshRenderer>());


                        //***********************


                        gl.Splines[3 * angle + 1 + i] = roofcurve.GetComponent<CurvySpline>();

            
                    
           

                        

                    
                    //roofcurve.AddComponent<MeshFilter>();







                }
            



            GameObject.Find("Ridge1").transform.GetChild(0).transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
            GameObject.Find("Ridge1").transform.GetChild(pubvar.ball - 1).transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);


            //gameObject.AddComponent<updown>();

            roofsurfacecontrol RF = GameObject.Find("Main Camera").GetComponent<roofsurfacecontrol>();
            RF.addpoint();

            //Destroy(GameObject.Find("Main Camera").GetComponent<updown>());


        }
        if (Input.GetKeyDown(KeyCode.M))
        {



        }

    }

}
