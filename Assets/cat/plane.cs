using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class plane : MonoBehaviour {

    // Use this for initialization



    public catline catline;



    public Plane ppp;
    //public int wide=8;
    public int length = int.Parse(UI.stringToEdit2);
   // public int wide = int.Parse(UI.stringToEdit2);
    public int wide = 15;
    public static float tiledlength = 0.5f; 
    
    public static Vector3[,] sloslopR = new Vector3[20,20];
    public static Vector3[,] sloslopL = new Vector3[20,20];


    public List<Plane> planenumbers = new List<Plane>();


    int angle = int.Parse(UI.stringToEdit);

    int tiled = int.Parse(UI.stringToEdit3);

    public static float twide = 0f; 

    void Start () 
    {
        print("tttt haha  " + tiledlength);
	}
	
	// Update is called once per frame
	void Update ()
    {

        if (Input.GetKeyDown(KeyCode.A))
        {
            creatplane();
            //change();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            creatplane();
            roofsurfaceconstruction();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            roofsurfacesegmentation();
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            circle();
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            TTT();
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Vector3 pn = GameObject.Find("Ridge1").transform.GetChild(pubvar.ball - 1).transform.position - GameObject.Find("Ridge2").transform.GetChild(pubvar.ball - 1).transform.position;

            ppp.normal = pn.normalized;
            ppp.distance = 1;

            print(pn);
        }






        }


    public void creatplane()
    {
        Plane ppp2 = new Plane();

        for (int i =1;i<=angle;i++)
        {
            if (i == angle)
            {
                
                
                ppp2.Set3Points(GameObject.Find("Ridge1").transform.GetChild(0).transform.position, GameObject.Find("Ridge" + i).transform.GetChild(2).transform.position, GameObject.Find("Ridge1").transform.GetChild(2).transform.position);
                planenumbers.Add(ppp2);
                print("PPPPPPPPPP  "+ppp2);
            }

            else
            {
                
                
                ppp2.Set3Points(GameObject.Find("Ridge1").transform.GetChild(0).transform.position, GameObject.Find("Ridge" + i).transform.GetChild(2).transform.position, GameObject.Find("Ridge" + (i + 1)).transform.GetChild(2).transform.position);
                planenumbers.Add(ppp2);
                print("PPPPPPPPPP  " + ppp2);
            }

        }


    }



    public void  roofsurfaceconstruction()
    {

      
       

        int a = 0;
        Vector3 born = new Vector3(0,0,0);
        Vector3 born2 = new Vector3(0, 0, 0);
        Vector3 born3 = new Vector3(0, 0, 0);
        int number = int.Parse(UI.stringToEdit);
        //GLCurvyRenderer gl = GameObject.Find("Main Camera").GetComponent<GLCurvyRenderer>();

        for (int i = 1; i <= number; i++)
        {
            

            if(i!=number)
            {
                
            ppp.normal = GameObject.Find("Ridge"+(i)).transform.GetChild(pubvar.ball - 1).transform.position - GameObject.Find("Ridge"+(i+1)).transform.GetChild(pubvar.ball - 1).transform.position;

            wide = int.Parse(UI.stringToEdit2);


            Vector3 tilewide = ppp.normal / (wide * 2);

                twide = tilewide.magnitude;
                print("ttttwwww" + twide);

                //right
            for (int k = 1; k < wide; k++)
            {
                float min = 1000;
                float min2 = 1000;
                float min3 = 1000;
                ppp.distance = 0;
                ppp.SetNormalAndPosition(ppp.normal, GameObject.Find("roofcurve" + i).transform.GetChild(1).transform.position);




                GameObject Line = new GameObject();
                Line.name = ("roofcurvylineR" + i + "-" + k);
                Line.AddComponent<CurvySpline>();
                    Line.AddComponent<catline>();
                    catline cat = Line.GetComponent<catline>();

                    Vector3 middle = (GameObject.Find("Ridge" + i).transform.GetChild(pubvar.ball - 1).transform.position + GameObject.Find("Ridge" + (i + 1)).transform.GetChild(pubvar.ball - 1).transform.position)/2;

                ppp.SetNormalAndPosition(ppp.normal, GameObject.Find("roofcurve" + i).transform.GetChild(1).transform.position + tilewide*k);

                for (int j = 0; j < GameObject.Find("roofsurface"+i).transform.childCount; j++)
                {
                    if (Mathf.Abs(ppp.GetDistanceToPoint(GameObject.Find("roofsurface"+i).transform.GetChild(j).transform.position)) < min)
                    {
                        min = Mathf.Abs(ppp.GetDistanceToPoint(GameObject.Find("roofsurface"+i).transform.GetChild(j).transform.position));
                        born = GameObject.Find("roofsurface"+i).transform.GetChild(j).position;                                  
                    }
                    else{ break; }                
                }


                //ridge上的點
              
                GameObject rtson = new GameObject();
                rtson.transform.parent = Line.transform;
                rtson.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                rtson.name = ("CP002");
                rtson.transform.position = born;
                rtson.AddComponent<CurvySplineSegment>();


                   
                    //cat.fuck(born);
                    //cat.AddControlPoint(rtson);
                    //cat.ResetCatmullRom();
                    

                    //動動點

                    for (int j = 0; j < GameObject.Find("rrrR" + i).transform.childCount; j++)
                {
                    if (Mathf.Abs(ppp.GetDistanceToPoint(GameObject.Find("rrrR" + i).transform.GetChild(j).transform.position)) < min2)
                    {
                        min2 = Mathf.Abs(ppp.GetDistanceToPoint(GameObject.Find("rrrR" + i).transform.GetChild(j).transform.position));
                        born2 = GameObject.Find("rrrR" + i).transform.GetChild(j).position;
                    }
                        else { break; }
                    }


                GameObject rtson2 = new GameObject();
                rtson2.transform.parent = Line.transform;
                rtson2.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                rtson2.name = ("CP001");
                rtson2.transform.position = born2;
                rtson2.AddComponent<CurvySplineSegment>();
                    rtson2.AddComponent<roofsurface>();
                    //cat.AddControlPoint(rtson2);
                    //cat.ResetCatmullRom();


                    //eave

                    for (int j = 0; j < GameObject.Find("eavepoint" + i).transform.childCount; j++)
                    {                  
                        if (Mathf.Abs(ppp.GetDistanceToPoint(GameObject.Find("eavepoint" + i).transform.GetChild(j).transform.position)) < min3)
                        {
                            min3 = Mathf.Abs(ppp.GetDistanceToPoint(GameObject.Find("eavepoint" + i).transform.GetChild(j).transform.position));
                            born3 = GameObject.Find("eavepoint" + i).transform.GetChild(j).position;
                        }
                        else { break; }
                    }

                    GameObject rtson3 = new GameObject();
                    rtson3.transform.parent = Line.transform;
                    rtson3.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                    rtson3.name = ("CP000");
                    rtson3.transform.position = born3;
                    rtson3.AddComponent<CurvySplineSegment>();

                    cat.AddControlPoint(rtson3);
                    cat.AddControlPoint(rtson2);
                    cat.AddControlPoint(rtson);
                    cat.ResetCatmullRom();


                    //Line.AddComponent<circlecut1>();

                    Line.AddComponent<planecut>();


                    //Line.AddComponent<newtiled>();



                    //gl.Splines[100 + a] = Line.GetComponent<CurvySpline>();
                    a++;

                /*
                    GameObject empty = new GameObject();
                    empty.AddComponent<SplinePathCloneBuilder>();
                    empty.name=(Line.name+"son");
                    
                    SplinePathCloneBuilder meet = empty.GetComponent<SplinePathCloneBuilder>();
                    meet.Spline = GameObject.Find("Ridge" + i).GetComponent<CurvySpline>();
                    meet.Gap = 0;

                    meet.Source = new GameObject[1];
                    meet.Source[0] = GameObject.Find("empty").gameObject;
                    meet.Mode = SplinePathCloneBuilderMode.CloneGroup;



                    empty.transform.parent = Line.transform;

                    */



                }

                //left

            for (int k = 1; k < wide; k++)
            {
                float min = 1000;
                float min2 = 1000;
                float min3 = 1000;
                ppp.distance = 0;
                ppp.SetNormalAndPosition(ppp.normal, GameObject.Find("roofcurve" + i).transform.GetChild(1).transform.position);




                GameObject Line = new GameObject();
                Line.name = ("roofcurvylineL" + i + "-" + k);
                Line.AddComponent<CurvySpline>();
                    Line.AddComponent<catline>();
                    catline cat = Line.GetComponent<catline>();


                    Vector3 middle = (GameObject.Find("Ridge" + i).transform.GetChild(pubvar.ball - 1).transform.position + GameObject.Find("Ridge" + (i + 1)).transform.GetChild(pubvar.ball - 1).transform.position) / 2;

                ppp.SetNormalAndPosition(ppp.normal, GameObject.Find("roofcurve" + i).transform.GetChild(1).transform.position - tilewide * k);

                for (int j = 0; j < GameObject.Find("roofsurface" + (i+1)).transform.childCount; j++)
                {
                    if (Mathf.Abs(ppp.GetDistanceToPoint(GameObject.Find("roofsurface" + (i + 1)).transform.GetChild(j).transform.position)) < min)
                    {
                        min = Mathf.Abs(ppp.GetDistanceToPoint(GameObject.Find("roofsurface" + (i + 1)).transform.GetChild(j).transform.position));
                        born = GameObject.Find("roofsurface" + (i + 1)).transform.GetChild(j).position;
                    }
                        else { break; }
                    }


                //ridge上的點

                GameObject rtson = new GameObject();
                rtson.transform.parent = Line.transform;
                rtson.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                rtson.name = ("CP002");
                rtson.transform.position = born;
                rtson.AddComponent<CurvySplineSegment>();



                //動動點

                for (int j = 0; j < GameObject.Find("rrrL" + i).transform.childCount; j++)
                {
                    if (Mathf.Abs(ppp.GetDistanceToPoint(GameObject.Find("rrrL" + i).transform.GetChild(j).transform.position)) < min2)
                    {
                        min2 = Mathf.Abs(ppp.GetDistanceToPoint(GameObject.Find("rrrL" + i).transform.GetChild(j).transform.position));
                        born2 = GameObject.Find("rrrL" + i).transform.GetChild(j).position;
                    }
                        else { break; }
                    }


                GameObject rtson2 = new GameObject();
                rtson2.transform.parent = Line.transform;
                rtson2.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                rtson2.name = ("CP001");
                rtson2.transform.position = born2;
                rtson2.AddComponent<CurvySplineSegment>();
                    rtson2.AddComponent<roofsurface>();
                   

                    //eave

                    for (int j = 0; j < GameObject.Find("eavepoint" + i).transform.childCount; j++)
                {
                    if (Mathf.Abs(ppp.GetDistanceToPoint(GameObject.Find("eavepoint" + i).transform.GetChild(j).transform.position)) < min3)
                    {
                        min3 = Mathf.Abs(ppp.GetDistanceToPoint(GameObject.Find("eavepoint" + i).transform.GetChild(j).transform.position));
                        born3 = GameObject.Find("eavepoint" + i).transform.GetChild(j).position;
                    }
                        else { break; }
                    }

                GameObject rtson3 = new GameObject();
                rtson3.transform.parent = Line.transform;
                rtson3.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                rtson3.name = ("CP000");
                rtson3.transform.position = born3;
                rtson3.AddComponent<CurvySplineSegment>();


                cat.AddControlPoint(rtson3);
                cat.AddControlPoint(rtson2);
                cat.AddControlPoint(rtson);
                cat.ResetCatmullRom();


                Line.AddComponent<planecut>();
                Line.AddComponent<newtiledL>();
                    //gl.Splines[100 + a] = Line.GetComponent<CurvySpline>();
                    a++;

                GameObject empty = new GameObject();
                empty.AddComponent<SplinePathCloneBuilder>();
                empty.name = (Line.name + "son");

                SplinePathCloneBuilder meet = empty.GetComponent<SplinePathCloneBuilder>();
                meet.Spline = GameObject.Find("Ridge" + i).GetComponent<CurvySpline>();
                meet.Gap = 0;

                meet.Source = new GameObject[1];
                meet.Source[0] = GameObject.Find("empty").gameObject;
                meet.Mode = SplinePathCloneBuilderMode.CloneGroup;



                empty.transform.parent = Line.transform;


            }


            

            }
            else
            {
                ppp.normal = GameObject.Find("Ridge" + (i)).transform.GetChild(pubvar.ball - 1).transform.position - GameObject.Find("Ridge1").transform.GetChild(pubvar.ball - 1).transform.position;

                Vector3 tilewide = ppp.normal / (wide * 2);

                for (int k = 1; k < wide; k++)
                {
                    float min = 1000;
                    float min2 = 1000;
                    float min3 = 1000;
                    ppp.distance = 0;
                    ppp.SetNormalAndPosition(ppp.normal, GameObject.Find("roofcurve" + i).transform.GetChild(1).transform.position);




                    GameObject Line = new GameObject();
                    Line.name = ("roofcurvylineR" + i + "-" + k);
                    Line.AddComponent<CurvySpline>();
                    Line.AddComponent<catline>();
                    catline cat = Line.GetComponent<catline>();


                    Vector3 middle = (GameObject.Find("Ridge" + i).transform.GetChild(pubvar.ball - 1).transform.position + GameObject.Find("Ridge1").transform.GetChild(pubvar.ball - 1).transform.position) / 2;

                    ppp.SetNormalAndPosition(ppp.normal, GameObject.Find("roofcurve" + i).transform.GetChild(1).transform.position + tilewide * k);

                    for (int j = 0; j < GameObject.Find("roofsurface" + i).transform.childCount; j++)
                    {
                        if (Mathf.Abs(ppp.GetDistanceToPoint(GameObject.Find("roofsurface" + i).transform.GetChild(j).transform.position)) < min)
                        {
                            min = Mathf.Abs(ppp.GetDistanceToPoint(GameObject.Find("roofsurface" + i).transform.GetChild(j).transform.position));
                            born = GameObject.Find("roofsurface" + i).transform.GetChild(j).position;
                        }
                        else { break; }
                    }


                    //ridge上的點

                    GameObject rtson = new GameObject();
                    rtson.transform.parent = Line.transform;
                    rtson.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                    rtson.name = ("CP002");
                    rtson.transform.position = born;
                    rtson.AddComponent<CurvySplineSegment>();


                    


                    //動動點

                    for (int j = 0; j < GameObject.Find("rrrR" + i).transform.childCount; j++)
                    {
                        if (Mathf.Abs(ppp.GetDistanceToPoint(GameObject.Find("rrrR" + i).transform.GetChild(j).transform.position)) < min2)
                        {
                            min2 = Mathf.Abs(ppp.GetDistanceToPoint(GameObject.Find("rrrR" + i).transform.GetChild(j).transform.position));
                            born2 = GameObject.Find("rrrR" + i).transform.GetChild(j).position;
                        }
                        else { break; }
                    }


                    GameObject rtson2 = new GameObject();
                    rtson2.transform.parent = Line.transform;
                    rtson2.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                    rtson2.name = ("CP001");
                    rtson2.transform.position = born2;
                    rtson2.AddComponent<CurvySplineSegment>();
                    rtson2.AddComponent<roofsurface>();



                    //eave

                    for (int j = 0; j < GameObject.Find("eavepoint" + i).transform.childCount; j++)
                    {
                        if (Mathf.Abs(ppp.GetDistanceToPoint(GameObject.Find("eavepoint" + i).transform.GetChild(j).transform.position)) < min3)
                        {
                            min3 = Mathf.Abs(ppp.GetDistanceToPoint(GameObject.Find("eavepoint" + i).transform.GetChild(j).transform.position));
                            born3 = GameObject.Find("eavepoint" + i).transform.GetChild(j).position;
                        }
                        else { break; }
                    }

                    GameObject rtson3 = new GameObject();
                    rtson3.transform.parent = Line.transform;
                    rtson3.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                    rtson3.name = ("CP000");
                    rtson3.transform.position = born3;
                    rtson3.AddComponent<CurvySplineSegment>();


                    cat.AddControlPoint(rtson3);
                    cat.AddControlPoint(rtson2);
                    cat.AddControlPoint(rtson);
                    cat.ResetCatmullRom();


                    Line.AddComponent<planecut>();
                    Line.AddComponent<newtiled>();





                    //gl.Splines[100 + a] = Line.GetComponent<CurvySpline>();
                    a++;
                    /*
                    GameObject empty = new GameObject();
                    empty.AddComponent<SplinePathCloneBuilder>();
                    empty.name = (Line.name + "son");

                    SplinePathCloneBuilder meet = empty.GetComponent<SplinePathCloneBuilder>();
                    meet.Spline = GameObject.Find("Ridge" + i).GetComponent<CurvySpline>();
                    meet.Gap = 0;

                    meet.Source = new GameObject[1];
                    meet.Source[0] = GameObject.Find("empty").gameObject;
                    meet.Mode = SplinePathCloneBuilderMode.CloneGroup;



                    empty.transform.parent = Line.transform;

                    */
                }

                //尾左
                for (int k = 1; k < wide; k++)
                {
                    float min = 1000;
                    float min2 = 1000;
                    float min3 = 1000;
                    ppp.distance = 0;
                    ppp.SetNormalAndPosition(ppp.normal, GameObject.Find("roofcurve" + i).transform.GetChild(1).transform.position);




                    GameObject Line = new GameObject();
                    Line.name = ("roofcurvylineL" + i + "-" + k);
                    Line.AddComponent<CurvySpline>();
                    Line.AddComponent<catline>();
                    catline cat = Line.GetComponent<catline>();


                    Vector3 middle = (GameObject.Find("Ridge" + i).transform.GetChild(pubvar.ball - 1).transform.position + GameObject.Find("Ridge1").transform.GetChild(pubvar.ball - 1).transform.position) / 2;

                    ppp.SetNormalAndPosition(ppp.normal, GameObject.Find("roofcurve" + i).transform.GetChild(1).transform.position - tilewide * k);

                    for (int j = 0; j < GameObject.Find("roofsurface1" ).transform.childCount; j++)
                    {
                        if (Mathf.Abs(ppp.GetDistanceToPoint(GameObject.Find("roofsurface1").transform.GetChild(j).transform.position)) < min)
                        {
                            min = Mathf.Abs(ppp.GetDistanceToPoint(GameObject.Find("roofsurface1").transform.GetChild(j).transform.position));
                            born = GameObject.Find("roofsurface1").transform.GetChild(j).position;
                        }
                        else { break; }
                    }


                    //ridge上的點

                    GameObject rtson = new GameObject();
                    rtson.transform.parent = Line.transform;
                    rtson.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                    rtson.name = ("CP002");
                    rtson.transform.position = born;
                    rtson.AddComponent<CurvySplineSegment>();



                    //動動點

                    for (int j = 0; j < GameObject.Find("rrrL" + i).transform.childCount; j++)
                    {
                        if (Mathf.Abs(ppp.GetDistanceToPoint(GameObject.Find("rrrL" + i).transform.GetChild(j).transform.position)) < min2)
                        {
                            min2 = Mathf.Abs(ppp.GetDistanceToPoint(GameObject.Find("rrrL" + i).transform.GetChild(j).transform.position));
                            born2 = GameObject.Find("rrrL" + i).transform.GetChild(j).position;
                        }
                        else { break; }
                    }


                    GameObject rtson2 = new GameObject();
                    rtson2.transform.parent = Line.transform;
                    rtson2.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                    rtson2.name = ("CP001");
                    rtson2.transform.position = born2;
                    rtson2.AddComponent<CurvySplineSegment>();
                    rtson2.AddComponent<roofsurface>();



                    //eave

                    for (int j = 0; j < GameObject.Find("eavepoint" + i).transform.childCount; j++)
                    {
                        if (Mathf.Abs(ppp.GetDistanceToPoint(GameObject.Find("eavepoint" + i).transform.GetChild(j).transform.position)) < min3)
                        {
                            min3 = Mathf.Abs(ppp.GetDistanceToPoint(GameObject.Find("eavepoint" + i).transform.GetChild(j).transform.position));
                            born3 = GameObject.Find("eavepoint" + i).transform.GetChild(j).position;
                        }
                        else { break; }
                    }

                    GameObject rtson3 = new GameObject();
                    rtson3.transform.parent = Line.transform;
                    rtson3.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                    rtson3.name = ("CP000");
                    rtson3.transform.position = born3;
                    rtson3.AddComponent<CurvySplineSegment>();



                    cat.AddControlPoint(rtson3);
                    cat.AddControlPoint(rtson2);
                    cat.AddControlPoint(rtson);
                    cat.ResetCatmullRom();


                    Line.AddComponent<planecut>();
                    Line.AddComponent<newtiledL>();
                    /*
                    //gl.Splines[100 + a] = Line.GetComponent<CurvySpline>();
                    a++;


                    GameObject empty = new GameObject();
                    empty.AddComponent<SplinePathCloneBuilder>();
                    empty.name = (Line.name + "son");

                    SplinePathCloneBuilder meet = empty.GetComponent<SplinePathCloneBuilder>();
                    meet.Spline = GameObject.Find("Ridge" + i).GetComponent<CurvySpline>();
                    meet.Gap = 0;

                    meet.Source = new GameObject[1];
                    meet.Source[0] = GameObject.Find("empty").gameObject;
                    meet.Mode = SplinePathCloneBuilderMode.CloneGroup;



                    empty.transform.parent = Line.transform;

                    */

                }











            
            
            
            }


            //左



    }

        //以上為number迴圈








        /*
        GameObject rtson = GameObject.CreatePrimitive(PrimitiveType.Sphere);

        rtson.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
        rtson.name = ("yoyoyoyo");
        rtson.transform.position = born;


        */


    }
    //以上為roofsurfaceconstruction

    //以下為magic
    public void change() 
    {
        int number = int.Parse(UI.stringToEdit);
        
        for (int i = 1 ;  i <= number ; i++)
        {
            for (int j = 1; j < wide; j++ )
            {
                
                SplinePathCloneBuilder meet = GameObject.Find("roofcurvylineR" + i + "-" + j+"son").GetComponent<SplinePathCloneBuilder>();
                meet.Spline = GameObject.Find("roofcurvylineR" + i + "-" + j).GetComponent<CurvySpline>();
                meet.Gap = 0.05f;

                SplinePathCloneBuilder meet2 = GameObject.Find("roofcurvylineL" + i + "-" + j + "son").GetComponent<SplinePathCloneBuilder>();
                meet2.Spline = GameObject.Find("roofcurvylineL" + i + "-" + j).GetComponent<CurvySpline>();
                meet2.Gap = 0.05f;

            }
        }


    }


    //其實做錯的切斷

    public void roofsurfacesegmentation()
    {
        int number = int.Parse(UI.stringToEdit);



        for (int i = 1; i <= number; i++)
        {
         
            
       
            Vector3 born=new Vector3(0,0,0); 
            Vector3 born2=new Vector3(0, 0, 0);
            Vector3 born3 = new Vector3(0, 0, 0);

            ppp.normal = new Vector3(GameObject.Find("roofcurve" + i).transform.GetChild(0).transform.position.x - GameObject.Find("roofcurve" + i).transform.GetChild(2).transform.position.x, 0f, GameObject.Find("roofcurve" + i).transform.GetChild(0).transform.position.z - GameObject.Find("roofcurve" + i).transform.GetChild(2).transform.position.z);

            ppp.SetNormalAndPosition(ppp.normal, GameObject.Find("roofcurve" + i).transform.GetChild(2).transform.position);

            //Vector3 l = ppp.normal / length;
            Vector3 l = ppp.normal;
            print(ppp.normal + " % "+l);

            for (int j = 0; j < length; j++)
            {
                float min3 = 1000;
                ppp.SetNormalAndPosition(ppp.normal, GameObject.Find("roofcurve" + i).transform.GetChild(2).transform.position + (l * j));
                


                for (int m = 1; m < wide; m++)
                {
                    float min = 1000;
                    float min2 = 1000;
                   

                    for (int k = 0; k < GameObject.Find("roofcurvylineR" + i + "-" + m+"son").transform.childCount; k++)
                    {
                        //if (Mathf.Abs(ppp.GetDistanceToPoint(GameObject.Find("roofcurvylineR" + i + "-" + m + "son").transform.GetChild(k).transform.position)) < min && ppp.GetDistanceToPoint(GameObject.Find("roofcurvylineR" + i + "-" + m + "son").transform.GetChild(k).transform.position)<0)

                        if (Mathf.Abs(ppp.GetDistanceToPoint(GameObject.Find("roofcurvylineR" + i + "-" + m + "son").transform.GetChild(k).transform.position)) < min )
                        {
                            min = Mathf.Abs(ppp.GetDistanceToPoint(GameObject.Find("roofcurvylineR" + i + "-" + m + "son").transform.GetChild(k).transform.position));
                            born = GameObject.Find("roofcurvylineR" + i + "-" + m + "son").transform.GetChild(k).position;
                        }

                        
                    }

                    GameObject rtson1 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    
                    rtson1.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                    rtson1.transform.position = born;
                    rtson1.GetComponent<MeshRenderer>().material.color = Color.blue;
                    



                    for (int k = 0; k < GameObject.Find("roofcurvylineL" + i + "-" + m + "son").transform.childCount; k++)
                    {
                        //if (Mathf.Abs(ppp.GetDistanceToPoint(GameObject.Find("roofcurvylineL" + i + "-" + m + "son").transform.GetChild(k).transform.position)) < min2  && ppp.GetDistanceToPoint(GameObject.Find("roofcurvylineL" + i + "-" + m + "son").transform.GetChild(k).transform.position)<0)
                        if (Mathf.Abs(ppp.GetDistanceToPoint(GameObject.Find("roofcurvylineL" + i + "-" + m + "son").transform.GetChild(k).transform.position)) < min2 )
                        {
                            min2 = Mathf.Abs(ppp.GetDistanceToPoint(GameObject.Find("roofcurvylineL" + i + "-" + m + "son").transform.GetChild(k).transform.position));
                            born2 = GameObject.Find("roofcurvylineL" + i + "-" + m + "son").transform.GetChild(k).position;
                        }

                    
                    }

                   
                        GameObject rtson2 = GameObject.CreatePrimitive(PrimitiveType.Sphere);

                        rtson2.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                        rtson2.transform.position = born2;
                        rtson2.GetComponent<MeshRenderer>().material.color = Color.blue;
                    

                    




                }
                

                for (int k = 0; k < GameObject.Find("roofsurfaceM" + i).transform.childCount; k++)
                {
                    if (Mathf.Abs(ppp.GetDistanceToPoint(GameObject.Find("roofsurfaceM" + i).transform.GetChild(k).transform.position)) < min3  )
                    {
                        min3 = Mathf.Abs(ppp.GetDistanceToPoint(GameObject.Find("roofsurfaceM" + i).transform.GetChild(k).transform.position));
                        born3 = GameObject.Find("roofsurfaceM" + i).transform.GetChild(k).position;
                    }


                }
                
                 GameObject rtson3 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                 rtson3.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                 rtson3.transform.position = born3;
                 rtson3.GetComponent<MeshRenderer>().material.color = Color.blue;
                


            }
           



        }
    }

    //正確的切斷

    public void circle()
    {

        //GameObject.Find("roofsurfaceM" + i).transform.childCount

        int number = int.Parse(UI.stringToEdit);



        for (int i = 1; i <= number; i++)
        {



            Vector3 born = new Vector3(0, 0, 0);
            Vector3 mid = new Vector3(0, 0, 0);

            Vector3 born2 = new Vector3(0, 0, 0);
            Vector3 born3 = new Vector3(0, 0, 0);

            ppp.normal = new Vector3(GameObject.Find("roofcurve" + i).transform.GetChild(0).transform.position.x - GameObject.Find("roofcurve" + i).transform.GetChild(2).transform.position.x, 0f, GameObject.Find("roofcurve" + i).transform.GetChild(0).transform.position.z - GameObject.Find("roofcurve" + i).transform.GetChild(2).transform.position.z);

            ppp.SetNormalAndPosition(ppp.normal, GameObject.Find("roofcurve" + i).transform.GetChild(2).transform.position);

            //Vector3 l = ppp.normal / length;
            Vector3 l = ppp.normal;
            //print(ppp.normal + " % " + l);

            



                for (int m = 1; m < wide; m++)
                {
               
                GameObject line = new GameObject();
                line.name = ("ballinsurfaceR"+i+"-"+m);

                    float min2 = 1000;

                    int n=0;

                    for (int k = 0; k < GameObject.Find("roofcurvylineR" + i + "-" + m + "son").transform.childCount; k++)
                    {
                        if (k == 0)
                        {
                       
                            GameObject fi = GameObject.CreatePrimitive(PrimitiveType.Sphere);

                           fi.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                           fi.transform.position = GameObject.Find("roofcurvylineR" + i + "-" + m + "son").transform.GetChild(k).position;

                           sloslopR[m, n] = GameObject.Find("roofcurvylineR" + i + "-" + m + "son").transform.GetChild(k).position;
                           
                            
                           fi.GetComponent<MeshRenderer>().material.color = Color.yellow;
                           fi.transform.parent = line.transform;
                        n++;
                        }
                        float min = 1000;
                        Vector3 ori  = GameObject.Find("roofcurvylineR" + i + "-" + m + "son").transform.GetChild(k).position;

                        int h = k;

                    for (int j = h; j < GameObject.Find("roofcurvylineR" + i + "-" + m + "son").transform.childCount; j++)
                        {
                            Vector3 dot = GameObject.Find("roofcurvylineR" + i + "-" + m + "son").transform.GetChild(j).position;
                            Vector3 miid = (ori + dot)/2;
                            
                            float iwant = Vector3.Distance(ori, dot);
 
                            if( Mathf.Abs((iwant- tiledlength))<min)
                            {
                                min = Mathf.Abs((iwant - tiledlength));
                                born = dot;
                                mid = miid;
                                k = j;
                            }
                             
                        }                     

                        //anchor point

                        GameObject rtson1 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                        rtson1.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                        rtson1.transform.position = born;

                        sloslopR[m, n] = born;

                        rtson1.GetComponent<MeshRenderer>().material.color = Color.yellow;
                        rtson1.transform.parent = line.transform;
                    n++;
                }
                line.AddComponent<tiled>();

                GameObject line2 = new GameObject();
                line2.name = ("ballinsurfaceL" + i + "-" + m);

                int b =0;
                for (int k = 0; k < GameObject.Find("roofcurvylineL" + i + "-" + m + "son").transform.childCount; k++)
                    {
                        if (k == 0)
                        {
                            GameObject fi = GameObject.CreatePrimitive(PrimitiveType.Sphere);

                            fi.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                            fi.transform.position = GameObject.Find("roofcurvylineL" + i + "-" + m + "son").transform.GetChild(k).position;

                            sloslopL[m, b] = fi.transform.position;
                            
                            fi.GetComponent<MeshRenderer>().material.color = Color.yellow;
                            fi.transform.parent = line2.transform;
                        b++;
                        }
                        float min = 1000;
                        Vector3 ori = GameObject.Find("roofcurvylineL" + i + "-" + m + "son").transform.GetChild(k).position;

                        int h = k;

                        for (int j = h; j < GameObject.Find("roofcurvylineL" + i + "-" + m + "son").transform.childCount; j++)
                        {
                            Vector3 dot = GameObject.Find("roofcurvylineL" + i + "-" + m + "son").transform.GetChild(j).position;
                            float iwant = Vector3.Distance(ori, dot);


                            if (Mathf.Abs((iwant - tiledlength)) < min)
                            {
                                min = Mathf.Abs((iwant - tiledlength));
                                born2 = dot;
                                k = j;
                            }

                        }
                        GameObject rtson1 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                        rtson1.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                        rtson1.transform.position = born2;

                        sloslopL[m, b] = born2;
                    
                        rtson1.GetComponent<MeshRenderer>().material.color = Color.yellow;
                        rtson1.transform.parent = line2.transform;

                    b++;
                        //line2.AddComponent<tiled>();
                }
                line2.AddComponent<tiledL>();



                }

            GameObject line3 = new GameObject();
            line3.name = ("ballinsurfaceM" + i );


            for (int k = 0; k < GameObject.Find("roofsurfaceM" + i).transform.childCount; k++)
                {
                   if (k == 0)
                        {
                            GameObject fi = GameObject.CreatePrimitive(PrimitiveType.Sphere);

                            fi.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                            fi.transform.position = GameObject.Find("roofsurfaceM" + i).transform.GetChild(k).position;
                            fi.GetComponent<MeshRenderer>().material.color = Color.yellow;
                            fi.transform.parent = line3.transform;
                        }
                        float min = 1000;
                        Vector3 ori = GameObject.Find("roofsurfaceM" + i).transform.GetChild(k).position;

                        int h = k;

                        for (int j = h; j < GameObject.Find("roofsurfaceM" + i).transform.childCount; j++)
                        {
                            Vector3 dot = GameObject.Find("roofsurfaceM" + i).transform.GetChild(j).position;
                            float iwant = Vector3.Distance(ori, dot);

                            if (Mathf.Abs((iwant - tiledlength)) < min)
                            {
                                min = Mathf.Abs((iwant - tiledlength));
                                born = dot;
                                k = j;
                            }

                        }
                        GameObject rtson1 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                        rtson1.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                        rtson1.transform.position = born;
                        rtson1.GetComponent<MeshRenderer>().material.color = Color.yellow;
                        rtson1.transform.parent = line3.transform;
                        
                    }

                    line3.AddComponent<tiledM>();


                }

        }
        public void TTT()
        {
          

        }

    public void addpoint()
    {



        int angle = int.Parse(UI.stringToEdit);

        int tiled = int.Parse(UI.stringToEdit3);



        //右邊

        for (int i = 1; i <= angle; i++)
        {

            GameObject R1 = new GameObject();

            R1.name = ("rrrR" + i);
            Vector3 start = GameObject.Find("roofcurve" + i).transform.GetChild(1).transform.position;
            Vector3 end = GameObject.Find("Ridge" + i).transform.GetChild(pubvar.ball - 1).transform.position;

            Vector3 mid = (end - start) / tiled;
            for (int j = 1; j <= tiled; j++)
            {
                GameObject oh = new GameObject();
                oh.transform.parent = R1.transform;
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







