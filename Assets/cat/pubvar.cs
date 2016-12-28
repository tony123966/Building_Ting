using UnityEngine;
using System.Collections;

public class pubvar : MonoBehaviour {


    public static int PUBnum;
    public static int ball;
    public static Vector3 CENTER;




    public static Vector3 arrow;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        
        if (GameObject.Find("Ridge2"))
        {
            if (GameObject.Find("Ridge1").transform.GetChild(pubvar.ball - 1).GetComponent<mice1>() && GameObject.Find("Ridge1").transform || GameObject.Find("column1").transform.GetChild(4).GetComponent<mice1>() && GameObject.Find("Ridge1").transform)
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
                        if (j != 4 && j != 6)
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
                                if (j == 3)
                                {

                                    eaveson.AddComponent<copyeave3>();
                                    if (i == 1)
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


                   gl.Splines[3 * angle + 1 + i] = roofcurve.GetComponent<CurvySpline>();








                   //roofcurve.AddComponent<MeshFilter>();







               }




/*
                for(int i = 1; i <= angle; i++)
                {
                    SplinePathCloneBuilder yoho = GameObject.Find("roofsurfaceM" + i).GetComponent<SplinePathCloneBuilder>();

                    yoho.Spline = GameObject.Find("roofcurve" + i).GetComponent<CurvySpline>();




                }
                
                */




               
            }
           
            
            if (GameObject.Find("Ridge1").transform.GetChild(0).GetComponent<mice1>() && GameObject.Find("Ridge2"))
            {
                int angle = int.Parse(UI.stringToEdit);
                for (int i = 2; i <= angle; i++)
                {
                    GameObject.Find("Ridge" + i).transform.GetChild(0).position = GameObject.Find("Ridge1").transform.GetChild(0).position;
                    GameObject.Find("roofcurve" + i).transform.GetChild(0).position = GameObject.Find("Ridge1").transform.GetChild(0).position;
                    GameObject.Find("roofcurve1").transform.GetChild(0).position = GameObject.Find("Ridge1").transform.GetChild(0).position;


                }

            }









        }



 
	
	}
    /*
    public void fuction()
    {

        int angle = int.Parse(UI.stringToEdit);
        for (int i = 1; i <= angle; i++)
        {


            if (GameObject.Find("roofcurve" + i) && GameObject.Find("roofsurfaceM1"))
            { 
            SplinePathCloneBuilder yoho = GameObject.Find("roofsurfaceM" + i).GetComponent<SplinePathCloneBuilder>();

            yoho.Spline = GameObject.Find("roofcurve" + i).GetComponent<CurvySpline>();
            }




        }


    }
    */


}
