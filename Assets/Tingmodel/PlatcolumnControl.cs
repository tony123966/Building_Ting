using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlatcolumnControl : MonoBehaviour {


    public List<GameObject> platcolumnmanage = new List<GameObject>();


    


    //platform
    public List<GameObject> platuppoint = new List<GameObject>();
    public List<GameObject> platdownpoint = new List<GameObject>();

    public List<GameObject> curvepoint = new List<GameObject>();


    public List<GameObject> bigbon = new List<GameObject>();

    public List<GameObject> BCL = new List<GameObject>();

    // childcolumn
    public List<GameObject> childcolumnmanage = new List<GameObject>();
    //balustrade up
    public List<GameObject> balustradepoint = new List<GameObject>();
    public List<GameObject> stairs = new List<GameObject>();



    public UIcontrol uict;



    public GameObject platmesho;

    public float upLong;
    public float downlong;
    public float ini_high;


    public bool B;
    public bool S;

    public GameObject die;

    public int num;
    public int stairnum;


    public float high;


	// Use this for initialization
	
    
    void Awake()
    {
        ini_high = this.transform.GetChild(0).GetChild(0).transform.position.y - this.transform.GetChild(0).GetChild(1).transform.position.y; ;
       
        num = 3;
        stairnum = 2;
    }
    


    
    
    void Start () {
       

        
	}
	
	// Update is called once per frame
	void Update () {
	
	}



    public void build()
    {



        platcolumnmanage.Add(this.transform.GetChild(0).gameObject);
        this.transform.GetChild(0).GetComponent<catline>().ResetCatmullRom();

        balustradepoint.Add(this.transform.GetChild(0).GetChild(2).gameObject);

        platuppoint.Add(this.transform.GetChild(0).GetChild(0).gameObject);
        platdownpoint.Add(this.transform.GetChild(0).GetChild(1).gameObject);
        curvepoint.Add(this.transform.GetChild(0).GetChild(3).gameObject);

        high = platuppoint[0].transform.position.y - platdownpoint[0].transform.position.y;
       


        int angle = uict.numberslidervalue;






        if (angle == 4)
        {


            for (int i = 2; i <= angle; i++)
            {
                GameObject go = Instantiate(this.transform.GetChild(0).gameObject, this.transform.GetChild(0).position, Quaternion.identity) as GameObject;
                /*
                Destroy(go.GetComponent<ColumnControl>());

                Destroy(go.transform.GetChild(0).GetComponent<MeshRenderer>());
                Destroy(go.transform.GetChild(0).GetComponent<SphereCollider>());
                Destroy(go.transform.GetChild(1).GetComponent<MeshRenderer>());
                Destroy(go.transform.GetChild(1).GetComponent<SphereCollider>());
                Destroy(go.transform.GetChild(2).GetComponent<MeshRenderer>());
                Destroy(go.transform.GetChild(2).GetComponent<SphereCollider>());
                Destroy(go.transform.GetChild(3).GetComponent<MeshRenderer>());
                Destroy(go.transform.GetChild(3).GetComponent<SphereCollider>());

                */





                if (i == 2)
                {
                    go.transform.GetChild(0).transform.position = Xmirrow(platcolumnmanage[0].transform.GetChild(0).transform.position);
                    go.transform.GetChild(1).transform.position = Xmirrow(platcolumnmanage[0].transform.GetChild(1).transform.position);
                    go.transform.GetChild(2).transform.position = Xmirrow(platcolumnmanage[0].transform.GetChild(2).transform.position);
                    go.transform.GetChild(3).transform.position = Xmirrow(platcolumnmanage[0].transform.GetChild(3).transform.position);
                }

                if (i == 3)
                {
                    go.transform.GetChild(0).transform.position = Xmirrow(platcolumnmanage[0].transform.GetChild(0).transform.position);
                    go.transform.GetChild(0).transform.position = Ymirrow(go.transform.GetChild(0).transform.position);

                    go.transform.GetChild(1).transform.position = Xmirrow(platcolumnmanage[0].transform.GetChild(1).transform.position);
                    go.transform.GetChild(1).transform.position = Ymirrow(go.transform.GetChild(1).transform.position);

                    go.transform.GetChild(2).transform.position = Xmirrow(platcolumnmanage[0].transform.GetChild(2).transform.position);
                    go.transform.GetChild(2).transform.position = Ymirrow(go.transform.GetChild(2).transform.position);

                    go.transform.GetChild(3).transform.position = Xmirrow(platcolumnmanage[0].transform.GetChild(3).transform.position);
                    go.transform.GetChild(3).transform.position = Ymirrow(go.transform.GetChild(3).transform.position);
                }

                if (i == 4)
                {
                    go.transform.GetChild(0).transform.position = Ymirrow(platcolumnmanage[0].transform.GetChild(0).transform.position);
                    go.transform.GetChild(1).transform.position = Ymirrow(platcolumnmanage[0].transform.GetChild(1).transform.position);
                    go.transform.GetChild(2).transform.position = Ymirrow(platcolumnmanage[0].transform.GetChild(2).transform.position);
                    go.transform.GetChild(3).transform.position = Ymirrow(platcolumnmanage[0].transform.GetChild(3).transform.position);
                }






                go.name = ("platformcolumn" + i);

                go.AddComponent<catline>();
                go.GetComponent<catline>().ResetCatmullRom();


                go.transform.parent = this.transform;

                platcolumnmanage.Add(go);

                platuppoint.Add(go.transform.GetChild(0).gameObject);
                platdownpoint.Add(go.transform.GetChild(1).gameObject);

                balustradepoint.Add(go.transform.GetChild(2).gameObject);
                curvepoint.Add(go.transform.GetChild(3).gameObject);
            }


        }
        else
        {


            for (int i = 2; i <= angle; i++)
            {
                GameObject go = Instantiate(this.transform.GetChild(0).gameObject, this.transform.GetChild(0).position, Quaternion.identity) as GameObject;


                /*
                Destroy(go.GetComponent<ColumnControl>());

                Destroy(go.transform.GetChild(0).GetComponent<MeshRenderer>());
                Destroy(go.transform.GetChild(0).GetComponent<SphereCollider>());
                Destroy(go.transform.GetChild(1).GetComponent<MeshRenderer>());
                Destroy(go.transform.GetChild(1).GetComponent<SphereCollider>());
                Destroy(go.transform.GetChild(2).GetComponent<MeshRenderer>());
                Destroy(go.transform.GetChild(2).GetComponent<SphereCollider>());
                Destroy(go.transform.GetChild(3).GetComponent<MeshRenderer>());
                Destroy(go.transform.GetChild(3).GetComponent<SphereCollider>());
                */


                go.transform.RotateAround(uict.center.transform.position, Vector3.up, (360 / angle) * (i - 1));


                go.name = ("platformcolumn" + i);
                /*
                go.AddComponent<catline>();
                 */ 
                go.GetComponent<catline>().ResetCatmullRom();


                go.transform.parent = this.transform;

                platcolumnmanage.Add(go);

                platuppoint.Add(go.transform.GetChild(0).gameObject);
                platdownpoint.Add(go.transform.GetChild(1).gameObject);

                balustradepoint.Add(go.transform.GetChild(2).gameObject);
                curvepoint.Add(go.transform.GetChild(3).gameObject);
            }
        }



        


        for (int i = 0; i < platcolumnmanage.Count; i++)
        {


            // ridgemanage[i].GetComponent<circlecut1>().cutpoint();
            //ridgemanage[i].GetComponent<Ridgetile>().creat();


            if (platcolumnmanage[i].GetComponent<circlecut1>())
            {
                platcolumnmanage[i].GetComponent<circlecut1>().reset();
                platcolumnmanage[i].GetComponent<Columntile>().kill();
            }

        }
       








    }






    Vector3 Xmirrow(Vector3 a)
    {
        return new Vector3(-a.z, a.y, -a.x);

    }

    Vector3 Ymirrow(Vector3 a)
    {

        return new Vector3(a.z, a.y, a.x);

    }



    public void platmesh()
    {

       
        int angle = uict.numberslidervalue;

        //上面
        GameObject TTL = new GameObject();
        TTL.name = ("platformmesh");
        TTL.AddComponent<MeshFilter>();
        TTL.AddComponent<MeshRenderer>();

        MeshRenderer floor = TTL.GetComponent<MeshRenderer>();

        MeshRenderer floor1 = GameObject.Find("floorball").GetComponent<MeshRenderer>();

        floor.material = floor1.material;

        TTL.transform.parent = this.transform;
        Mesh meshL = TTL.GetComponent<MeshFilter>().mesh;

        meshL.Clear();

        Vector3[] vL = new Vector3[2 * angle];
        Vector3[] nL = new Vector3[2 * angle];
        Vector2[] uvL = new Vector2[2 * angle];
        int[] tL = new int[3 * angle];




        uvL[0] = new Vector2(1, 1);
        uvL[1] = new Vector2(0, 1);
        uvL[2] = new Vector2(1, 0);

        nL[0] = Vector3.up;
        nL[1] = Vector3.up;
        nL[2] = Vector3.up;

        Vector3 v1 = platuppoint[0].transform.position;
        Vector3 v2 = platuppoint[1].transform.position;
        Vector3 v3 = platuppoint[2].transform.position;

        vL[0] = v1;
        vL[1] = v2;
        vL[2] = v3;

        tL[0] = 0;
        tL[1] = 1;
        tL[2] = 2;

        for (int i = 4; i <= angle; i++)
        {

            Vector3 v4 = platuppoint[i-1].transform.position;

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



            nL[i - 1] = Vector3.up;

            tL[i - 1 + (i - 4) * 2] = 0;
            tL[i + (i - 4) * 2] = i - 2;
            tL[(i + 1) + (i - 4) * 2] = i - 1;


        }





        meshL.vertices = vL;
        meshL.triangles = tL;
        meshL.normals = nL;
        meshL.uv = uvL;


        //下面
        
        GameObject TTL2 = new GameObject();
        TTL2.name = ("platformmesh2");
        TTL2.AddComponent<MeshFilter>();
        TTL2.AddComponent<MeshRenderer>();



        MeshRenderer floor2 = TTL2.GetComponent<MeshRenderer>();

        //MeshRenderer floor1 = GameObject.Find("floorball").GetComponent<MeshRenderer>();

        floor2.material = floor1.material;





        Mesh meshL2 = TTL2.GetComponent<MeshFilter>().mesh;

        meshL2.Clear();

        Vector3[] vL2 = new Vector3[2 * angle];
        Vector3[] nL2 = new Vector3[2 * angle];
        Vector2[] uvL2 = new Vector2[2 * angle];
        int[] tL2 = new int[3 * angle];




        uvL2[0] = new Vector2(1, 1);
        uvL2[1] = new Vector2(0, 1);
        uvL2[2] = new Vector2(1, 0);

        nL2[0] = Vector3.down;
        nL2[1] = Vector3.down;
        nL2[2] = Vector3.down;

        Vector3 v12 = platdownpoint[0].transform.position;
        Vector3 v22 = platdownpoint[1].transform.position;
        Vector3 v32 = platdownpoint[2].transform.position;

        vL2[0] = v12;
        vL2[1] = v22;
        vL2[2] = v32;

        tL2[0] = 2;
        tL2[1] = 1;
        tL2[2] = 0;

        for (int i = 4; i <= angle; i++)
        {

            Vector3 v4 = platdownpoint[i - 1].transform.position;

            vL2[i - 1] = v4;


            if (i % 3 == 2)
            {
                uvL2[i - 1] = new Vector2(0, 1);
            }
            else if (i % 3 == 1)
            {
                uvL2[i - 2] = new Vector2(1, 0);
            }
            else
            {
                uvL2[i - 2] = new Vector2(0, 1);
            }



            nL2[i - 1] = Vector3.down;

            tL2[i - 1 + (i - 4) * 2] = i - 1;
            tL2[i + (i - 4) * 2] = i - 2;
            tL2[(i + 1) + (i - 4) * 2] = 0;


        }

        meshL2.vertices = vL2;
        meshL2.triangles = tL2;
        meshL2.normals = nL2;
        meshL2.uv = uvL2;


        TTL2.transform.parent = TTL.transform;
        //邊

        /*
        for (int i = 1; i <= angle; i++)
        {



            GameObject side = new GameObject();
            side.name = ("side" + i);
            side.AddComponent<MeshFilter>();
            side.AddComponent<MeshRenderer>();


            side.transform.parent = TTL.transform;


            MeshRenderer floor3 = side.GetComponent<MeshRenderer>();

            floor3.material = floor1.material;


            Mesh mesh = side.GetComponent<MeshFilter>().mesh;

            mesh.Clear();


            if (i != angle)
            {
                Vector3 V1 = platuppoint[i - 1].transform.position;
                Vector3 V2 = platuppoint[i].transform.position;
                Vector3 V3 = platdownpoint[i - 1].transform.position;
                Vector3 V4 = platdownpoint[i].transform.position;


                mesh.vertices = new Vector3[] { V1, V2, V3, V4 };
            }
            else
            {
                Vector3 V1 = platuppoint[i-1].transform.position;
                Vector3 V2 = platuppoint[0].transform.position;
                Vector3 V3 = platdownpoint[i - 1].transform.position;
                Vector3 V4 = platdownpoint[0].transform.position;


                mesh.vertices = new Vector3[] { V1, V2, V3, V4 };
            }




            mesh.uv = new Vector2[] { new Vector2(0, 0), new Vector2(0, 1), new Vector2(1, 0), new Vector2(1, 1) };

            //東西南北

            if ((360 / angle) * i <= 90)
            {
                mesh.normals = new Vector3[]
                        {
                            
                        Vector3.right,
                        Vector3.right,
                        Vector3.right,
                        Vector3.right,
                             
 
                       

                        };
            }
            if ((360 / angle) * i <= 180 && (360 / angle) * i > 90)
            {
                mesh.normals = new Vector3[]
                        {

                            
                        Vector3.back,
                        Vector3.back,
                        Vector3.back,
                        Vector3.back,
                            
                    
                        };
            }
            if ((360 / angle) * i <= 270 && (360 / angle) * i > 180)
            {
                mesh.normals = new Vector3[]
                        {

                          
                         Vector3.left,
                        Vector3.left,
                        Vector3.left,
                        Vector3.left,
                       
                        };
            }
            if ((360 / angle) * i <= 360 && (360 / angle) * i > 270)
            {
                mesh.normals = new Vector3[]
                        {
                            
                         Vector3.forward,
                        Vector3.forward,
                        Vector3.forward,
                        Vector3.forward,
                        

                        };
            }

            //東西南北

            mesh.triangles = new int[] { 1, 0, 2, 1, 2, 3 };
        





        }
        */

        //new edge


        Vector3 V1;
        Vector3 V2;
        Vector3 V3;
        Vector3 V4;

        for (int i = 1; i <= angle; i++)
        {

            int rson = transform.GetChild(0).GetComponent<catline>().innerPointList.Count;




            float uvR = (1 / (float)rson);


            GameObject side = new GameObject();


            side.transform.parent = transform;

            side.name = ("rooficonmesh");
            side.AddComponent<MeshFilter>();
            side.AddComponent<MeshRenderer>();
            side.transform.parent = TTL.transform;

            MeshRenderer floor3 = side.GetComponent<MeshRenderer>();

            floor3.material = floor1.material;


            Mesh mesh = side.GetComponent<MeshFilter>().mesh;
            mesh.Clear();

            Vector3[] v = new Vector3[2 * rson];
            Vector3[] n = new Vector3[2 * rson];
            Vector2[] uv = new Vector2[2 * rson];
            int[] t = new int[6 * rson];

            for (int j = 0; j <= rson - 1; j++)
            {

                if (j == 0)
                {
                    /*
                    Vector3 V1 = transform.GetComponent<catline>().innerPointList[j];
                    Vector3 V2 = transform.parent.GetChild(1).GetComponent<catline>().innerPointList[j + 1];
                    Vector3 V3 = transform.GetComponent<catline>().innerPointList[j + 1];
                    */

                    

                    if(i==angle)
                    {

                        V1 = platcolumnmanage[i - 1].GetComponent<catline>().innerPointList[j];
                        V2 = platcolumnmanage[0].GetComponent<catline>().innerPointList[j + 1];
                        V3 = platcolumnmanage[i - 1].GetComponent<catline>().innerPointList[j + 1];


                    }
                    else
                    {

                        V1 = platcolumnmanage[i - 1].GetComponent<catline>().innerPointList[j];
                        V2 = platcolumnmanage[i].GetComponent<catline>().innerPointList[j + 1];
                        V3 = platcolumnmanage[i - 1].GetComponent<catline>().innerPointList[j + 1];

                    }



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
                {
                    /*
                    Vector3 V1 = transform.GetComponent<catline>().innerPointList[j];
                    Vector3 V2 = transform.parent.GetChild(1).GetComponent<catline>().innerPointList[j];
                    Vector3 V3 = transform.parent.GetChild(1).GetComponent<catline>().innerPointList[j + 1];
                    */
                   

                    if (i == angle)
                    {
                        V1 = platcolumnmanage[i - 1].GetComponent<catline>().innerPointList[j];
                        V2 = platcolumnmanage[0].GetComponent<catline>().innerPointList[j + 1];
                        V3 = platcolumnmanage[0].GetComponent<catline>().innerPointList[j + 1];

                    }
                    else
                    {
                        V1 = platcolumnmanage[i - 1].GetComponent<catline>().innerPointList[j];
                        V2 = platcolumnmanage[i].GetComponent<catline>().innerPointList[j + 1];
                        V3 = platcolumnmanage[i].GetComponent<catline>().innerPointList[j + 1];


                    }


                    v[0] = (V1);
                    v[1] = (V2);
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
                else
                {


                    /*
                    Vector3 V3 = transform.parent.GetChild(1).GetComponent<catline>().innerPointList[j];
                    Vector3 V4 = transform.GetComponent<catline>().innerPointList[j];
                    */
                   
                    if(i == angle)
                    {

                        V3 = platcolumnmanage[0].GetComponent<catline>().innerPointList[j];
                        V4 = platcolumnmanage[i - 1].GetComponent<catline>().innerPointList[j];

                    }
                    else
                    {
                        V3 = platcolumnmanage[i].GetComponent<catline>().innerPointList[j];
                        V4 = platcolumnmanage[i - 1].GetComponent<catline>().innerPointList[j];

                    }



                    v[2 * j - 1] = (V3);
                    v[2 * j] = (V4);


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

                    t[2 + 6 * (j - 1) - 5] = 2 * j - 1;
                    t[2 + 6 * (j - 1) - 4] = 2 * j - 3;
                    t[2 + 6 * (j - 1) - 3] = 2 * j - 2;
                    t[2 + 6 * (j - 1) - 2] = 2 * j;
                    t[2 + 6 * (j - 1) - 1] = 2 * j - 1;
                    t[2 + 6 * (j - 1)] = 2 * j - 2;
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



                }
                mesh.vertices = v;
                mesh.triangles = t;
                mesh.normals = n;
                mesh.uv = uv;
            }




        }













        platmesho = TTL;


    }


    public void childcolumn(int n)
    {

        

        int angle = uict.numberslidervalue;

        Vector3 v1;
        Vector3 v2;
        Vector3 v3;
        Vector3 v4;
        Vector3 v5;
        Vector3 v6;
        Vector3 v7;

        GameObject CColumn = new GameObject();
        CColumn.name = "childcolumn";
        CColumn.transform.parent = this.transform;


        die = CColumn;

        for (int i = 1; i <= angle; i++)
        {

            GameObject CC = new GameObject();
            CC.transform.parent = CColumn.transform;
            CC.name = ("Mom" + i);






            if (i == angle)
            {

                v1 = balustradepoint[i - 1].transform.position;
                v2 = balustradepoint[0].transform.position;

                v3 = platuppoint[i - 1].transform.position;
                v4 = platuppoint[0].transform.position;




            }


            else
            {


                v1 = balustradepoint[i - 1].transform.position;
                v2 = balustradepoint[i].transform.position;

                v3 = platuppoint[i - 1].transform.position;
                v4 = platuppoint[i].transform.position;




            }








            Vector3 smallv = (v2 - v1) / n;

            float talltall = Vector3.Distance(v2, v4);


            for (int j = 0; j <= n; j++)
            {


              
                GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                GameObject ball = GameObject.CreatePrimitive(PrimitiveType.Sphere);


                ball.transform.parent = CC.transform;
                cube.transform.parent = CC.transform;


                float xxb4 = cube.transform.GetComponent<MeshRenderer>().bounds.size.x;
                float yyb4 = cube.transform.GetComponent<MeshRenderer>().bounds.size.y;
                float zzb4 = cube.transform.GetComponent<MeshRenderer>().bounds.size.z;

                Vector3 scale4 = cube.transform.transform.localScale;

                cube.transform.GetComponent<Renderer>().material.color = Color.grey;






                scale4.x = 0.7f * scale4.x / xxb4;
                scale4.y = talltall * scale4.y / yyb4;
                scale4.z = 0.7f * scale4.z / zzb4;

                cube.transform.transform.localScale = scale4;



                cube.transform.position = v1 + (smallv * j);

                ball.transform.position = v1 + (smallv * j);

                cube.transform.Translate(0, -talltall / 2, 0);



                GameObject p1 = new GameObject();
                p1.transform.parent = cube.transform;
                p1.transform.position = ball.transform.position;

                GameObject p2=new GameObject();
                p2.transform.parent = cube.transform;
                p2.transform.position = new Vector3(ball.transform.position.x, ball.transform.position.y - talltall, ball.transform.position.z);


                





            }




            childcolumnmanage.Add(CC);
        }





    }



    
    public void balustrade(int a)
    {
        int angle = uict.numberslidervalue;

        GameObject haha = GameObject.Find("balustrade");

        Vector3 v0 = new Vector3(0, 0, 0);
        Vector3 v1;
        Vector3 v2;
        Vector3 v3;
        Vector3 v4;
        Vector3 v5= new Vector3(0, 0, 0);
        Vector3 v6 = new Vector3(0, 0, 0);

        for (int i = 1; i <= angle; i++)
        {

            int ohoh = 3;

          

            GameObject bcc = new GameObject();
            bcc.name = ("balustrade"+i);
            bcc.transform.parent = this.transform;





            for (int n = 1; n < a*2; n = n+2)
            {

                if (n != Mathf.FloorToInt(a))
                {


               v1 = childcolumnmanage[i-1].transform.GetChild(n).transform.GetChild(0).position;
                v2 = childcolumnmanage[i-1].transform.GetChild(n + 2).transform.GetChild(0).position;
                 v3 = childcolumnmanage[i-1].transform.GetChild(n).transform.GetChild(1).position;
                 v4 = childcolumnmanage[i-1].transform.GetChild(n + 2).transform.GetChild(1).position;



                 GameObject sbcc = new GameObject();
                 sbcc.name = ("balustrade1-" + n);
                 sbcc.transform.parent = bcc.transform;

                for (int j = 0; j < ohoh; j++)
                {

                   

                    bcc.transform.parent = this.transform;

                    GameObject balustrade = Instantiate(haha, v0, Quaternion.identity) as GameObject;


                    balustrade.transform.parent = sbcc.transform;
                    balustrade.transform.GetChild(0).GetComponent<MeshRenderer>().material.color = Color.white;


                    /*
                    if (i == angle)
                    {

                        v1 = columncon.columnmanage[i - 1].transform.GetChild(2).position;
                        v2 = columncon.columnmanage[0].transform.GetChild(2).position;
                        v3 = columncon.columnmanage[i - 1].transform.GetChild(3).position;
                        v4 = columncon.columnmanage[0].transform.GetChild(3).position;


                    }
                    else
                    {
                        v1 = columncon.columnmanage[i - 1].transform.GetChild(2).position;
                        v2 = columncon.columnmanage[i].transform.GetChild(2).position;
                        v3 = columncon.columnmanage[i - 1].transform.GetChild(3).position;
                        v4 = columncon.columnmanage[i].transform.GetChild(3).position;

                    }
                    */


                    Vector3 bigv = v2 - v1;
                    Vector3 smallv = (v2 - v1) / ohoh;
                    Vector3 mid = (v1 + v3) / 2;



                    //float yy = Vector3.Distance(v1, v3);

                    float yy = Mathf.Abs(v1.y - v3.y);
                    float zz = smallv.magnitude;

                    float xxb = balustrade.transform.GetChild(0).GetComponent<MeshRenderer>().bounds.size.x;
                    float yyb = balustrade.transform.GetChild(0).GetComponent<MeshRenderer>().bounds.size.y;
                    float zzb = balustrade.transform.GetChild(0).GetComponent<MeshRenderer>().bounds.size.z;


                    Vector3 scale = balustrade.transform.GetChild(0).transform.localScale;

                    scale.x = 0.3f * scale.x / xxb;
                    scale.y = yy * scale.y / yyb;
                    scale.z = zz * scale.z / zzb;

                    balustrade.transform.GetChild(0).transform.localScale = scale;

                    balustrade.transform.position = v1 + (smallv * j);
                    
                    
                    
                    balustrade.transform.Rotate(0, (360 / angle / 2) - 180, 0);


                    balustrade.transform.Rotate(0, (360 / angle) * (i - 1), 0);

                  }
               }
                else
                {
                    if(S==false)
                    {
                        v1 = childcolumnmanage[i - 1].transform.GetChild(n).transform.GetChild(0).position;
                        v2 = childcolumnmanage[i - 1].transform.GetChild(n + 2).transform.GetChild(0).position;
                        v3 = childcolumnmanage[i - 1].transform.GetChild(n).transform.GetChild(1).position;
                        v4 = childcolumnmanage[i - 1].transform.GetChild(n + 2).transform.GetChild(1).position;



                        GameObject sbcc = new GameObject();
                        sbcc.name = ("balustrade1-" + n);
                        sbcc.transform.parent = bcc.transform;

                        for (int j = 0; j < ohoh; j++)
                        {
                            bcc.transform.parent = this.transform;

                            GameObject balustrade = Instantiate(haha, v0, Quaternion.identity) as GameObject;


                            balustrade.transform.parent = sbcc.transform;
                            balustrade.transform.GetChild(0).GetComponent<MeshRenderer>().material.color = Color.white;

                            Vector3 bigv = v2 - v1;
                            Vector3 smallv = (v2 - v1) / ohoh;
                            Vector3 mid = (v1 + v3) / 2;

                            //float yy = Vector3.Distance(v1, v3);

                            float yy = Mathf.Abs(v1.y - v3.y);
                            float zz = smallv.magnitude;

                            float xxb = balustrade.transform.GetChild(0).GetComponent<MeshRenderer>().bounds.size.x;
                            float yyb = balustrade.transform.GetChild(0).GetComponent<MeshRenderer>().bounds.size.y;
                            float zzb = balustrade.transform.GetChild(0).GetComponent<MeshRenderer>().bounds.size.z;

                            Vector3 scale = balustrade.transform.GetChild(0).transform.localScale;

                            scale.x = 0.3f * scale.x / xxb;
                            scale.y = yy * scale.y / yyb;
                            scale.z = zz * scale.z / zzb;

                            balustrade.transform.GetChild(0).transform.localScale = scale;

                            balustrade.transform.position = v1 + (smallv * j);



                            balustrade.transform.Rotate(0, (360 / angle / 2) - 180, 0);


                            balustrade.transform.Rotate(0, (360 / angle) * (i - 1), 0);

                        }




                    }
                    else
                    {

                        v1 = childcolumnmanage[i - 1].transform.GetChild(n).transform.GetChild(0).position;
                        v2 = childcolumnmanage[i - 1].transform.GetChild(n + 2).transform.GetChild(0).position;
                        v3 = childcolumnmanage[i - 1].transform.GetChild(n).transform.GetChild(1).position;
                        v4 = childcolumnmanage[i - 1].transform.GetChild(n + 2).transform.GetChild(1).position;



                        if (i != angle)
                        {
                            v5 = (platuppoint[i - 1].transform.position + platuppoint[i].transform.position) / 2;
                            v6 = (platdownpoint[i - 1].transform.position + platdownpoint[i].transform.position) / 2;

                        }
                        else
                        {
                            v5 = (platuppoint[i - 1].transform.position + platuppoint[0].transform.position) / 2;
                            v6 = (platdownpoint[i - 1].transform.position + platdownpoint[0].transform.position) / 2;


                        }





                        for (int z = 1; z <= stairnum; z++)
                        {
                            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);



                            cube.transform.parent = this.transform;



                            float xxb4 = cube.transform.GetComponent<MeshRenderer>().bounds.size.x;
                            float yyb4 = cube.transform.GetComponent<MeshRenderer>().bounds.size.y;
                            float zzb4 = cube.transform.GetComponent<MeshRenderer>().bounds.size.z;

                            Vector3 scale4 = cube.transform.transform.localScale;

                            cube.transform.GetComponent<Renderer>().material.color = Color.grey;





                            scale4.x = (high / stairnum) * scale4.x / xxb4;
                            scale4.y = (high / stairnum) * scale4.y / yyb4;
                            scale4.z = Vector3.Distance(v1, v2) * scale4.z / zzb4;

                            cube.transform.transform.localScale = scale4;



                            // cube.transform.position = (v5+v6)/2);

                            Vector3 line = (v6 - v5) / (stairnum * 2);


                            cube.transform.position = v5 + line * (2 * z - 1);





                            cube.transform.Rotate(0, (360 / angle / 2) - 180, 0);


                            cube.transform.Rotate(0, (360 / angle) * (i - 1), 0);




                            stairs.Add(cube);

                        }




                    }
                    
                }

            }

            BCL.Add(bcc);

          

        }



    }

    

    public void creat_stair(int a,int b)
    {

        print(b);
        int angle = uict.numberslidervalue;

        

        Vector3 v0 = new Vector3(0, 0, 0);
        Vector3 v1;
        Vector3 v2;
        Vector3 v3;
        Vector3 v4;
        Vector3 v5 = new Vector3(0, 0, 0);
        Vector3 v6 = new Vector3(0, 0, 0);

        for (int i = 1; i <= angle; i++)
        {

            int ohoh = 3;



            for (int n = 1; n < a * 2; n = n + 2)
            {

                if (n != Mathf.FloorToInt(a))
                {

                    
                }
                else
                {

                    v1 = childcolumnmanage[i - 1].transform.GetChild(n).transform.GetChild(0).position;
                    v2 = childcolumnmanage[i - 1].transform.GetChild(n + 2).transform.GetChild(0).position;
                    v3 = childcolumnmanage[i - 1].transform.GetChild(n).transform.GetChild(1).position;
                    v4 = childcolumnmanage[i - 1].transform.GetChild(n + 2).transform.GetChild(1).position;

                    

                    if (i != angle)
                    {
                        v5 = (platuppoint[i - 1].transform.position + platuppoint[i].transform.position) / 2;
                        v6 = (platdownpoint[i - 1].transform.position + platdownpoint[i].transform.position) / 2;

                    }
                    else
                    {
                        v5 = (platuppoint[i - 1].transform.position + platuppoint[0].transform.position) / 2;
                        v6 = (platdownpoint[i - 1].transform.position + platdownpoint[0].transform.position) / 2;


                    }





                    for (int z = 1;z<=stairnum ; z++)
                    {
                        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);



                        cube.transform.parent = this.transform;



                        float xxb4 = cube.transform.GetComponent<MeshRenderer>().bounds.size.x;
                        float yyb4 = cube.transform.GetComponent<MeshRenderer>().bounds.size.y;
                        float zzb4 = cube.transform.GetComponent<MeshRenderer>().bounds.size.z;

                        Vector3 scale4 = cube.transform.transform.localScale;

                        cube.transform.GetComponent<Renderer>().material.color = Color.grey;

                        



                        scale4.x = (high/stairnum) * scale4.x / xxb4;
                        scale4.y = (high / stairnum) * scale4.y / yyb4;
                        scale4.z = Vector3.Distance(v1, v2) * scale4.z / zzb4;

                        cube.transform.transform.localScale = scale4;



                        // cube.transform.position = (v5+v6)/2);

                        Vector3 line = (v6 - v5) / (stairnum * 2);


                        cube.transform.position = v5 + line*(2*z-1);

                       



                        cube.transform.Rotate(0, (360 / angle / 2) - 180, 0);


                        cube.transform.Rotate(0, (360 / angle) * (i - 1), 0);




                        stairs.Add(cube);

                    }

                
                }



             

            }

          



        }







    }


    public void bonbon()
    {

        int angle = uict.numberslidervalue;


        Vector3 v0 = new Vector3(0, 0, 0);
        Vector3 v1;
        Vector3 v2;
        Vector3 v3;
        Vector3 v4;


        for (int i = 1; i <= angle; i++)
        {



            GameObject balustrade = GameObject.CreatePrimitive(PrimitiveType.Cube);
            GameObject balustrade2 = GameObject.CreatePrimitive(PrimitiveType.Cube);

            balustrade.transform.parent = this.transform;
            balustrade2.transform.parent = this.transform;

            if (i == angle)
            {

                v1 = platuppoint[i - 1].transform.position;
                v2 = platuppoint[0].transform.position;

                v3 = platdownpoint[i - 1].transform.position;
                v4 = platdownpoint[0].transform.position;


            }


            else
            {


                v1 = platuppoint[i - 1].transform.position;
                v2 = platuppoint[i].transform.position;

                v3 = platdownpoint[i - 1].transform.position;
                v4 = platdownpoint[i].transform.position;



            }

            balustrade.transform.GetComponent<Renderer>().material.color = Color.grey;
            balustrade2.transform.GetComponent<Renderer>().material.color = Color.grey;


            float yy = Vector3.Distance(v1, v2);
            float yy2 = Vector3.Distance(v3, v4);


            float zz = (v1 - v2).magnitude;

            float xxb = balustrade.GetComponent<MeshRenderer>().bounds.size.x;
            float yyb = balustrade.GetComponent<MeshRenderer>().bounds.size.y;
            float zzb = balustrade.GetComponent<MeshRenderer>().bounds.size.z;

            float xxb2 = balustrade2.GetComponent<MeshRenderer>().bounds.size.x;
            float yyb2 = balustrade2.GetComponent<MeshRenderer>().bounds.size.y;
            float zzb2 = balustrade2.GetComponent<MeshRenderer>().bounds.size.z;




            Vector3 scale = balustrade.transform.localScale;
            Vector3 scale2 = balustrade2.transform.localScale;
            /*
                scale.x = 0.6f * scale.x / xxb;
                scale.y = yy * scale.y / yyb;
                scale.z = zz * scale.z / zzb;

             */

            // scale.x = yy * scale.x / xxb;
            scale.x = yy * scale.x / xxb;
            scale.y = 0.75f * scale.y / yyb;
            scale.z = 0.75f * scale.z / zzb;

            scale2.x = yy2 * scale2.x / xxb2;
            scale2.y = 0.75f * scale2.y / yyb2;
            scale2.z = 0.75f * scale2.z / zzb2;


            balustrade.transform.localScale = scale;
            balustrade.transform.position = (v1 + v2) / 2;

            balustrade.transform.Rotate(0, (360 / angle / 2) + 90, 0);
            balustrade.transform.Rotate(0, (360 / angle) * (i - 1), 0);


            balustrade2.transform.localScale = scale2;
            balustrade2.transform.position = (v3 + v4) / 2;

            balustrade2.transform.Rotate(0, (360 / angle / 2) + 90, 0);
            balustrade2.transform.Rotate(0, (360 / angle) * (i - 1), 0);






            bigbon.Add(balustrade);
            bigbon.Add(balustrade2);
        }




        /*
        for (int i = 2; i <= angle; i++)
        {

            GameObject go = Instantiate(BB[0], BB[0].transform.position, Quaternion.identity) as GameObject;

            go.transform.RotateAround(uict.center.transform.position, Vector3.up, (360 / angle) * (i - 1));
            go.name = ("bigbon" + i);
            go.transform.parent = this.transform;


            BB.Add(go);
        }
        */


    }









    public void reset()
    {
        //print((this.transform.parent.transform.childCount) + " haha " + (this.transform.parent.transform.childCount - 1) + " name " + this.transform.parent.transform.GetChild(this.transform.parent.transform.childCount - 1).name);
        //Destroy(this.transform.parent.transform.GetChild(this.transform.parent.transform.childCount - 1).gameObject);

        for (int i = 1; i < platcolumnmanage.Count; i++)
        {
            Destroy(platcolumnmanage[i]);
        }
        for (int i = 1; i < platuppoint.Count; i++)
        {
            Destroy(platuppoint[i]);
        }
        for (int i = 1; i < platdownpoint.Count; i++)
        {
            Destroy(platdownpoint[i]);
        }
        for (int i = 1; i < curvepoint.Count; i++)
        {
            Destroy(curvepoint[i]);
        }

        for (int i = 0; i < bigbon.Count; i++)
        {
            Destroy(bigbon[i]);
        }
        for (int i = 1; i < balustradepoint.Count; i++)
        {
            Destroy(balustradepoint[i]);
        }
        for (int i = 0; i < childcolumnmanage.Count; i++)
        {
            Destroy(childcolumnmanage[i]);
        }

        for (int i = 0; i < BCL.Count; i++)
        {
            Destroy(BCL[i]);
        }

        for (int i = 0; i < stairs.Count; i++)
        {
            Destroy(stairs[i]);
        }


        /*
        for (int i = 0; i < uppoint.Count; i++)
        {
            Destroy(uppoint[i]);
        }
        for (int i = 0; i < downpoint.Count; i++)
        {
            Destroy(downpoint[i]);
        }
        */

           Destroy(die);
        
        



        platcolumnmanage.Clear();

        platdownpoint.Clear();
        platuppoint.Clear();
        curvepoint.Clear();

        bigbon.Clear();
       
        balustradepoint.Clear();
        childcolumnmanage.Clear();
        BCL.Clear();
        stairs.Clear();



        Destroy(platmesho);
       

        build();

        platmesh();
        bonbon();
        
        if(B==true)
        {
            childcolumn(num);
            balustrade(num);
        }


        /*
        if(S==true)


        creat_stair(num,stairnum);
        */
        /*
        ColumnLong = Mathf.Abs(transform.GetChild(0).transform.position.y - transform.GetChild(3).transform.position.y);
        EyeToColumn = Mathf.Abs(transform.GetChild(3).transform.position.x - uict.center.transform.position.x);
        ColumnWide = Vector3.Distance(transform.GetChild(0).transform.position, transform.GetChild(1).transform.position);
    */
    }



}
