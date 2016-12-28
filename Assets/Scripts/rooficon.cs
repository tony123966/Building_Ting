using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class rooficon : MonoBehaviour
{

    public List<GameObject> cp1 = new List<GameObject>();
    public List<GameObject> cp2 = new List<GameObject>();
    public List<GameObject> cp3 = new List<GameObject>();
    public List<GameObject> cp4 = new List<GameObject>();
    public List<GameObject> cp5 = new List<GameObject>();

    public GameObject ori;

    public GameObject meshh;

    public GameObject right;
    public GameObject left;


    public GameObject center;


    public DragItemController dragitemcontroller;

    public GameObject ting;
    public GameObject ControlPoint1;
    public GameObject ControlPoint2;

    //cp1-ORINGIN
    public Vector3 ini_ControlPoint_1_Position;


    public Vector3 ControlPoint_1_position;
    public Vector3 ControlPoint_2_position;
    public Vector3 ControlPoint_3_position;
    public Vector3 ControlPoint_4_position;
    public Vector3 ControlPoint_5_position;


    public Vector2 ControlPoint1Move;
    public Vector2 ControlPoint2Move;
    public Vector2 ControlPoint3Move;
    public Vector2 ControlPoint4Move;
    public Vector2 ControlPoint5Move;


    public Movement movement;

    public float RooficonHeight;
    public float RooficonWide;


    void Awake()
    {


        ini_ControlPoint_1_Position = transform.GetChild(0).gameObject.transform.position;

        dragitemcontroller = GameObject.Find("DragItemController").GetComponent<DragItemController>();

        ori = transform.parent.parent.GetChild(1).gameObject;

        movement = GameObject.Find("Movement").GetComponent<Movement>();

        RooficonHeight = Mathf.Abs(transform.GetChild(0).transform.position.y - transform.GetChild(2).transform.position.y);
        RooficonWide = Mathf.Abs(transform.GetChild(0).transform.position.x - transform.GetChild(2).transform.position.x);




    }



    // Use this for initialization
    void Start()
    {


        right = transform.gameObject;

        catline ca = transform.gameObject.AddComponent<catline>();

        ca.AddControlPoint(transform.GetChild(0).gameObject);
        ca.AddControlPoint(transform.GetChild(1).gameObject);
        ca.AddControlPoint(transform.GetChild(2).gameObject);


        cp1.Add(transform.GetChild(0).gameObject);
        cp2.Add(transform.GetChild(1).gameObject);
        cp3.Add(transform.GetChild(2).gameObject);
        //tail
        cp4.Add(transform.GetChild(3).gameObject);
        cp5.Add(transform.GetChild(4).gameObject);


        movement.freelist.AddRange(cp1);
        movement.freelist.AddRange(cp2);
        movement.freelist.AddRange(cp3);
        //tail
        movement.freelist.AddRange(cp4);
        movement.freelist.AddRange(cp5);

        ca.ResetCatmullRom();
        transform.gameObject.AddComponent<circlecut1>().reset();



        Vector3 v1 = transform.GetChild(0).transform.position;
        Vector3 v2 = transform.GetChild(1).transform.position;
        Vector3 v3 = transform.GetChild(2).transform.position;
        //tail
        Vector3 v4 = transform.GetChild(3).transform.position;
        Vector3 v5 = transform.GetChild(4).transform.position;


        GameObject v1c = new GameObject();
        GameObject v2c = new GameObject();
        GameObject v3c = new GameObject();
        //tail
        GameObject v4c = new GameObject();
        GameObject v5c = new GameObject();


        v1c.transform.parent = transform.parent.GetChild(1);
        v2c.transform.parent = transform.parent.GetChild(1);
        v3c.transform.parent = transform.parent.GetChild(1);
        //tail
        v4c.transform.parent = transform.parent.GetChild(1);
        v5c.transform.parent = transform.parent.GetChild(1);



        v1c.transform.position = new Vector3(v1.x - 2 * (v1.x - ini_ControlPoint_1_Position.x), v1.y, v1.z);
        v2c.transform.position = new Vector3(v2.x - 2 * (v2.x - ini_ControlPoint_1_Position.x), v2.y, v2.z);
        v3c.transform.position = new Vector3(v3.x - 2 * (v3.x - ini_ControlPoint_1_Position.x), v3.y, v3.z);
        //tail
        v4c.transform.position = new Vector3(v4.x - 2 * (v4.x - ini_ControlPoint_1_Position.x), v4.y, v4.z);
        v5c.transform.position = new Vector3(v5.x - 2 * (v5.x - ini_ControlPoint_1_Position.x), v5.y, v5.z);


        left = transform.parent.GetChild(1).gameObject;

        catline ca2 = transform.parent.GetChild(1).gameObject.AddComponent<catline>();

        ca2.AddControlPoint(v1c);
        ca2.AddControlPoint(v2c);
        ca2.AddControlPoint(v3c);
        //tail
        ca2.AddControlPoint(v4c);
        ca2.AddControlPoint(v5c);


        ca2.ResetCatmullRom();
        transform.parent.GetChild(1).gameObject.AddComponent<circlecut1>().reset();

        mesh();

        ControlPoint_1_position = cp1[0].transform.position;
        ControlPoint_2_position = cp2[0].transform.position;
        ControlPoint_3_position = cp3[0].transform.position;

        //tail
        ControlPoint_4_position = cp4[0].transform.position;
        ControlPoint_5_position = cp5[0].transform.position;


        //ThreePointToBuild();


    }

    // Update is called once per frame
    void Update()
    {

    }


    void rebuild()
    {

        right = transform.gameObject;

        catline ca = transform.gameObject.AddComponent<catline>();

        ca.AddControlPoint(transform.GetChild(0).gameObject);
        ca.AddControlPoint(transform.GetChild(1).gameObject);
        ca.AddControlPoint(transform.GetChild(2).gameObject);




        ca.ResetCatmullRom();
        transform.gameObject.AddComponent<circlecut1>().reset();



        Vector3 v1 = transform.GetChild(0).transform.position;
        Vector3 v2 = transform.GetChild(1).transform.position;
        Vector3 v3 = transform.GetChild(2).transform.position;
        //tail
        Vector3 v4 = transform.GetChild(3).transform.position;
        Vector3 v5 = transform.GetChild(4).transform.position;


        GameObject v1c = new GameObject();
        GameObject v2c = new GameObject();
        GameObject v3c = new GameObject();
        //tail
        GameObject v4c = new GameObject();
        GameObject v5c = new GameObject();





        GameObject another = new GameObject();

        another.transform.parent = transform.parent;

        /*
        v1c.transform.parent = transform.GetChild(0).GetChild(1);
        v2c.transform.parent = transform.GetChild(0).GetChild(1);
        v3c.transform.parent = transform.GetChild(0).GetChild(1);
        */

        v1c.transform.parent = another.transform;
        v2c.transform.parent = another.transform;
        v3c.transform.parent = another.transform;
        //tail
        v4c.transform.parent = another.transform;
        v5c.transform.parent = another.transform;


        v1c.transform.position = new Vector3(v1.x - 2 * (v1.x - ini_ControlPoint_1_Position.x), v1.y, v1.z);
        v2c.transform.position = new Vector3(v2.x - 2 * (v2.x - ini_ControlPoint_1_Position.x), v2.y, v2.z);
        v3c.transform.position = new Vector3(v3.x - 2 * (v3.x - ini_ControlPoint_1_Position.x), v3.y, v3.z);
        //tail
        v4c.transform.position = new Vector3(v4.x - 2 * (v4.x - ini_ControlPoint_1_Position.x), v4.y, v4.z);
        v5c.transform.position = new Vector3(v5.x - 2 * (v5.x - ini_ControlPoint_1_Position.x), v5.y, v5.z);


        left = another.gameObject;

        catline ca2 = transform.parent.GetChild(1).gameObject.AddComponent<catline>();

        ca2.AddControlPoint(v1c);
        ca2.AddControlPoint(v2c);
        ca2.AddControlPoint(v3c);
        ca2.AddControlPoint(v4c);
        ca2.AddControlPoint(v5c);


        ca2.ResetCatmullRom();
        transform.parent.GetChild(1).gameObject.AddComponent<circlecut1>().reset();

        // mesh();





        //ThreePointToBuild();





    }


    public void addpoint()
    {
        print("DFGDFGDGDGDGDGDG");

        movement.freelist.AddRange(cp1);

        movement.freelist.AddRange(cp2);
        movement.freelist.AddRange(cp3);

        movement.freelist.AddRange(cp4);
        movement.freelist.AddRange(cp5);

        reset();
    }




    void mesh()
    {


        //int rson = transform.GetChild(0).GetChild(0).GetComponent<circlecut1>().anchorpointlist.Count;

        int rson = transform.GetComponent<catline>().innerPointList.Count;




        float uvR = (1 / (float)rson);


        GameObject TTL = new GameObject();


        meshh = TTL;

        TTL.transform.parent = transform;

        TTL.name = ("rooficonmesh");
        TTL.AddComponent<MeshFilter>();
        TTL.AddComponent<MeshRenderer>();



        MeshRenderer floor = TTL.GetComponent<MeshRenderer>();
        MeshRenderer floor1 = ori.GetComponent<MeshRenderer>();
        floor.material = floor1.material;


        Mesh mesh = TTL.GetComponent<MeshFilter>().mesh;
        mesh.Clear();

        Vector3[] v = new Vector3[2 * rson];
        Vector3[] n = new Vector3[2 * rson];
        Vector2[] uv = new Vector2[2 * rson];
        int[] t = new int[6 * rson];

        for (int j = 0; j <= rson - 1; j++)
        {

            if (j == 0)
            {
                Vector3 v1 = transform.GetComponent<catline>().innerPointList[j];
                Vector3 v2 = transform.parent.GetChild(1).GetComponent<catline>().innerPointList[j + 1];
                Vector3 v3 = transform.GetComponent<catline>().innerPointList[j + 1];


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
                Vector3 v1 = transform.GetComponent<catline>().innerPointList[j];
                Vector3 v2 = transform.parent.GetChild(1).GetComponent<catline>().innerPointList[j];
                Vector3 v3 = transform.parent.GetChild(1).GetComponent<catline>().innerPointList[j + 1];


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
            else
            {

               

                Vector3 v3 = transform.parent.GetChild(1).GetComponent<catline>().innerPointList[j];
                Vector3 v4 = transform.GetComponent<catline>().innerPointList[j];


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

                t[2 + 6 * (j - 1) - 5] = 2 * j - 1;
                t[2 + 6 * (j - 1) - 4] = 2 * j - 3;
                t[2 + 6 * (j - 1) - 3] = 2 * j - 2;
                t[2 + 6 * (j - 1) - 2] = 2 * j;
                t[2 + 6 * (j - 1) - 1] = 2 * j - 1;
                t[2 + 6 * (j - 1)] = 2 * j - 2;
                //東西南北
               /*
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
                */
                //東西南   



            }
            mesh.vertices = v;
            mesh.triangles = t;
            mesh.normals = n;
            mesh.uv = uv;
        }

    }



    public void reset()
    {


        ControlPoint1Move = new Vector2((cp1[0].transform.position.x - ControlPoint_1_position.x) / RooficonWide, (cp1[0].transform.position.y - ControlPoint_1_position.y) / RooficonHeight);
        ControlPoint2Move = new Vector2((cp2[0].transform.position.x - ControlPoint_2_position.x) / RooficonWide, (cp2[0].transform.position.y - ControlPoint_2_position.y) / RooficonHeight);
        ControlPoint3Move = new Vector2((cp3[0].transform.position.x - ControlPoint_3_position.x) / RooficonWide, (cp3[0].transform.position.y - ControlPoint_3_position.y) / RooficonHeight);



        print("yayaya");

        Destroy(left);
        Destroy(meshh);
        Destroy(ting);






        transform.GetComponent<catline>().ResetCatmullRom();
        //transform.GetChild(0).GetChild(1).gameObject.GetComponent<catline>().ResetCatmullRom();

        transform.gameObject.GetComponent<circlecut1>().reset();





        // transform.GetChild(0).GetChild(1).gameObject.GetComponent<circlecut1>().reset();
        rebuild();

        mesh();

        ControlPoint_1_position = cp1[0].transform.position;
        ControlPoint_2_position = cp2[0].transform.position;
        ControlPoint_3_position = cp3[0].transform.position;



        /*
        ThreePointToBuild();
         */
    }




    /*
    void ThreePointToBuild()
    {

        Vector3 move = center.transform.position - right.transform.GetChild(0).transform.position;





        Vector3 v1 = (right.transform.GetChild(0).transform.position  + move);
        Vector3 v2 = (right.transform.GetChild(1).transform.position + move) ;
        Vector3 v3 = (right.transform.GetChild(2).transform.position + move) ;





        GameObject clone = Instantiate(Resources.Load("RidgeCc"), v1, Quaternion.identity) as GameObject;

        ting = clone;
        
        //clone.transform.parent = transform;
        clone.transform.parent = GameObject.Find("build").transform;



        clone.transform.GetChild(0).GetChild(0).GetChild(0).GetChild(0).transform.position = v1;
        clone.transform.GetChild(0).GetChild(0).GetChild(0).GetChild(1).transform.position = v2;
        clone.transform.GetChild(0).GetChild(0).GetChild(0).GetChild(2).transform.position = v3;
        
        clone.transform.GetChild(0).GetChild(2).GetChild(0).transform.position = new Vector3(v1.x, v1.y + 1f, v1.z);
        clone.transform.GetChild(0).GetChild(2).transform.position = new Vector3(v1.x, v1.y + 1f, v1.z);
        
        
        clone.transform.GetChild(0).GetChild(2).GetChild(0).transform.position = new Vector3(v1.x, v1.y , v1.z);
        clone.transform.GetChild(0).GetChild(2).transform.position = new Vector3(v1.x, v1.y , v1.z);
        
        
        Vector3 tailvec = Vector3.Normalize(v3 - v1);

        clone.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(0).transform.position = v3;
        clone.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(1).transform.position = v3 + tailvec;
        clone.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(2).transform.position = v3 + tailvec * 2;

        




        clone.transform.GetChild(1).GetComponent<roofcontrol>().setnumberslidervalue();
        clone.transform.GetChild(0).GetChild(2).GetChild(0).GetComponent<uppoint>().selffix(clone.transform.GetChild(0).GetChild(2).GetChild(0).gameObject, clone.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<RidgeControl>());



        ControlPoint1 = clone.transform.GetChild(0).GetChild(0).GetChild(0).GetChild(0).gameObject;
        ControlPoint2 =  clone.transform.GetChild(0).GetChild(0).GetChild(0).GetChild(1).gameObject;

    }
    */








}
