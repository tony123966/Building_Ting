using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ColumnBody : MonoBehaviour
{

    public List<GameObject> BB = new List<GameObject>();
    public List<GameObject> BB2 = new List<GameObject>();
    public List<GameObject> WINDOW = new List<GameObject>();

    public UIcontrol uict;
    public ColumnControl columncon;

    public GameObject haha;
    public GameObject windows;


    public bool windows_or_not;



    public int ohoh;

    private Vector3 Windowsup;
    private Vector3 windowsdown;

    public float up;
    public float down;

    private float body_wide;

    public int number;

    // Use this for initialization


    void Awake()
    {
        //GameObject haha = GameObject.Find("frieze_old");

        haha = GameObject.Find("bigbonA");
        windows = GameObject.Find("frieze_old");
        
        windows_or_not = true;


        up = 1/9f;
        down = 4 / 9f;
    }



    void Start()
    {
      

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ini(float a,float b)
    {
        //ohoh = (int)uict.ohoh.value;
        print(a+"  **************  "+b);

        ohoh = 2;

        int i = uict.numberslidervalue;



        number = Mathf.RoundToInt(body_wide / 4);




        for (int n = 0; n < columncon.bodycolumnnumber; n++)
        {



            GameObject bcc = new GameObject();
            bcc.name = ("bigbon1");
            bcc.transform.parent = this.transform;


            Vector3 v0 = new Vector3(0, 0, 0);

            GameObject balustrade = Instantiate(haha, v0, Quaternion.identity) as GameObject;
            balustrade.transform.parent = bcc.transform;


            Vector3 v1 = columncon.childcolumnmanage[0].transform.GetChild(n).transform.GetChild(0).position;
            Vector3 v2 = columncon.childcolumnmanage[0].transform.GetChild(n + 1).transform.GetChild(0).position;
            Vector3 v3 = columncon.childcolumnmanage[0].transform.GetChild(n).transform.GetChild(1).position;
            Vector3 v4 = columncon.childcolumnmanage[0].transform.GetChild(n + 1).transform.GetChild(1).position;

            Vector3 v5 = columncon.childcolumnmanage[0].transform.GetChild(n + 1).transform.GetChild(3).position;




            Vector3 bigv = v2 - v1;
            //Vector3 smallv = (v2 - v1) / 2;
            Vector3 mid = (v1 + v3) / 2;



            //float yy = Vector3.Distance(v1, v2);

            float yy = Vector3.Distance(v1, v2);

            float talltall = Vector3.Distance(v2, v5);


            // float mini = talltall / 10;



            float mini = talltall * a;
            float mini_ass = talltall * (1 - b);







            Vector3 v6 = new Vector3(v1.x, v1.y - mini, v1.z);
            Vector3 v7 = new Vector3(v1.x, v1.y - mini_ass, v1.z);


            Vector3 v8 = new Vector3(v2.x, v2.y - mini, v2.z);
            Vector3 v9 = new Vector3(v2.x, v2.y - mini_ass, v2.z);





            float zz = (v1 - v2).magnitude;

            float xxb = balustrade.transform.GetChild(0).GetComponent<MeshRenderer>().bounds.size.x;
            float yyb = balustrade.transform.GetChild(0).GetComponent<MeshRenderer>().bounds.size.y;
            float zzb = balustrade.transform.GetChild(0).GetComponent<MeshRenderer>().bounds.size.z;


            Vector3 scale = balustrade.transform.GetChild(0).transform.localScale;

            scale.x = yy * scale.x / xxb;
            scale.y = (talltall - mini_ass) * scale.y / yyb;
            scale.z = 0.8f * scale.z / zzb;




           // balustrade.transform.GetChild(0).transform.GetComponent<Renderer>().material.color = Color.red;

            balustrade.transform.GetChild(0).transform.localScale = scale;


            balustrade.transform.position = (v7 + v5) / 2;

            balustrade.transform.Rotate(0, (360 / i / 2) + 90, 0);

            BB.Add(bcc);





            if (windows_or_not == true)
            {
                GameObject bcc2 = new GameObject();
                bcc2.name = ("bigbonUP1");
                bcc2.transform.parent = this.transform;


                GameObject balustrade2 = Instantiate(haha, v0, Quaternion.identity) as GameObject;
                balustrade2.transform.parent = bcc2.transform;

                float zz2 = (v1 - v2).magnitude;

                float xxb2 = balustrade2.transform.GetChild(0).GetComponent<MeshRenderer>().bounds.size.x;
                float yyb2 = balustrade2.transform.GetChild(0).GetComponent<MeshRenderer>().bounds.size.y;
                float zzb2 = balustrade2.transform.GetChild(0).GetComponent<MeshRenderer>().bounds.size.z;


                Vector3 scale2 = balustrade2.transform.GetChild(0).transform.localScale;

                scale2.x = yy * scale2.x / xxb2;
                //scale2.y = (talltall - mini_ass) * scale2.y / yyb2;
                scale2.y = mini * scale2.y / yyb2;

                scale2.z = 0.8f * scale2.z / zzb2;


                //balustrade2.transform.GetChild(0).transform.GetComponent<Renderer>().material.color = Color.red;

                balustrade2.transform.GetChild(0).transform.localScale = scale2;


                balustrade2.transform.position = (v8 + v1) / 2;

                balustrade2.transform.Rotate(0, (360 / i / 2) + 90, 0);

                BB2.Add(bcc2);




                //WINDOWS
                GameObject bcc3 = new GameObject();
                bcc3.name = ("window1");
                bcc3.transform.parent = this.transform;

                for (int j = 0; j < ohoh; j++)
                {


                    GameObject balustrade3 = Instantiate(windows, v0, Quaternion.identity) as GameObject;


                    balustrade3.transform.parent = bcc3.transform;


                    Vector3 smallv = (v2 - v1) / ohoh;

                    float xxb3 = balustrade3.transform.GetChild(0).GetComponent<MeshRenderer>().bounds.size.x;
                    float yyb3 = balustrade3.transform.GetChild(0).GetComponent<MeshRenderer>().bounds.size.y;
                    float zzb3 = balustrade3.transform.GetChild(0).GetComponent<MeshRenderer>().bounds.size.z;


                    Vector3 scale3 = balustrade3.transform.GetChild(0).transform.localScale;

                    float wt = Vector3.Distance(v6, v7);



                    scale3.x = 1.0f * scale3.x / xxb3;
                    scale3.y = wt * scale3.y / yyb3;
                    scale3.z = (smallv.magnitude - 2) * scale3.z / zzb3;

                    balustrade3.transform.GetChild(0).transform.localScale = scale3;

                    balustrade3.transform.position = v6 + (smallv * j) + smallv.normalized;
                    balustrade3.transform.Rotate(0, (360 / i / 2) - 180, 0);



                    if (j != ohoh - 1)
                    {


                        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cylinder);

                        cube.transform.parent = bcc3.transform;


                        float xxb4 = cube.transform.GetComponent<MeshRenderer>().bounds.size.x;
                        float yyb4 = cube.transform.GetComponent<MeshRenderer>().bounds.size.y;
                        float zzb4 = cube.transform.GetComponent<MeshRenderer>().bounds.size.z;


                        Vector3 scale4 = cube.transform.transform.localScale;

                        cube.transform.GetComponent<Renderer>().material.color = Color.red;


                        scale4.x = 1.4f * scale4.x / xxb4;
                        scale4.y = talltall * scale4.y / yyb4;
                        scale4.z = 1.4f * scale4.z / zzb4;

                        cube.transform.transform.localScale = scale4;

                        cube.transform.position = v1 + (smallv * j) + (smallv);
                        cube.transform.Rotate(0, (360 / i / 2) - 180, 0);

                        cube.transform.Translate(0, -talltall / 2, 0);


                    }


                }


                WINDOW.Add(bcc3);


            }














        }

    }

    public void build(float a, float b)
    {
        int angle = uict.numberslidervalue;


        Vector3 v0 = new Vector3(0, 0, 0);
        Vector3 v1;
        Vector3 v2;
        Vector3 v3;
        Vector3 v4;
        Vector3 v5;

        for (int i = 2; i <= angle; i++)
        {



            for (int n = 0; n < columncon.bodycolumnnumber; n++)
            {




           // ohoh = (int)uict.ohoh.value;
            GameObject bcc = new GameObject();
            bcc.name = ("bigbon" + i);
            bcc.transform.parent = this.transform;



            GameObject balustrade = Instantiate(haha, v0, Quaternion.identity) as GameObject;
            balustrade.transform.parent = bcc.transform;




            v1 = columncon.childcolumnmanage[i-1].transform.GetChild(n).transform.GetChild(0).position;
            v2 = columncon.childcolumnmanage[i - 1].transform.GetChild(n + 1).transform.GetChild(0).position;
            v3 = columncon.childcolumnmanage[i - 1].transform.GetChild(n).transform.GetChild(1).position;
           v4 = columncon.childcolumnmanage[i - 1].transform.GetChild(n + 1).transform.GetChild(1).position;

            v5 = columncon.childcolumnmanage[i - 1].transform.GetChild(n + 1).transform.GetChild(3).position;







                /*
                if (i == angle)
                {

                    v1 = columncon.columnmanage[i - 1].transform.GetChild(0).position;
                    v2 = columncon.columnmanage[0].transform.GetChild(0).position;
                    v3 = columncon.columnmanage[i - 1].transform.GetChild(1).position;
                    v4 = columncon.columnmanage[0].transform.GetChild(1).position;
                    v5 =  columncon.columnmanage[0].transform.GetChild(3).position;
                }
                else
                {
                    v1 = columncon.columnmanage[i - 1].transform.GetChild(0).position;
                    v2 = columncon.columnmanage[i].transform.GetChild(0).position;
                    v3 = columncon.columnmanage[i - 1].transform.GetChild(1).position;
                    v4 = columncon.columnmanage[i].transform.GetChild(1).position;

                    v5 = columncon.columnmanage[i].transform.GetChild(3).position;

                }
                */

                Vector3 bigv = v2 - v1;
                //Vector3 smallv = (v2 - v1) / 2;
                Vector3 mid = (v1 + v3) / 2;



                //float yy = Vector3.Distance(v1, v2);

                float yy = Vector3.Distance(v1, v2);

                float talltall = Vector3.Distance(v2, v5);


                // float mini = talltall / 10;



                float mini = talltall * a;
                float mini_ass = talltall * (1 - b);


                Vector3 v6 = new Vector3(v1.x, v1.y - mini, v1.z);
                Vector3 v7 = new Vector3(v1.x, v1.y - mini_ass, v1.z);
                Vector3 v8 = new Vector3(v2.x, v2.y - mini, v2.z);
                Vector3 v9 = new Vector3(v2.x, v2.y - mini_ass, v2.z);




                float zz = (v1 - v2).magnitude;

                float xxb = balustrade.transform.GetChild(0).GetComponent<MeshRenderer>().bounds.size.x;
                float yyb = balustrade.transform.GetChild(0).GetComponent<MeshRenderer>().bounds.size.y;
                float zzb = balustrade.transform.GetChild(0).GetComponent<MeshRenderer>().bounds.size.z;


                Vector3 scale = balustrade.transform.GetChild(0).transform.localScale;

                scale.x = yy * scale.x / xxb;
                scale.y = (talltall - mini_ass) * scale.y / yyb;
                scale.z = 0.8f * scale.z / zzb;




                //balustrade.transform.GetChild(0).transform.GetComponent<Renderer>().material.color = Color.red;

                balustrade.transform.GetChild(0).transform.localScale = scale;


                balustrade.transform.position = (v7 + v5) / 2;

                balustrade.transform.Rotate(0, (360 / angle / 2) + 90, 0);

                balustrade.transform.Rotate(0, (360 / angle) * (i - 1), 0);


                BB.Add(bcc);


                if (windows_or_not == true)
                {
                    GameObject bcc2 = new GameObject();
                    bcc2.name = ("bigbonUP"+i);
                    bcc2.transform.parent = this.transform;


                    GameObject balustrade2 = Instantiate(haha, v0, Quaternion.identity) as GameObject;
                    balustrade2.transform.parent = bcc2.transform;

                    float zz2 = (v1 - v2).magnitude;

                    float xxb2 = balustrade2.transform.GetChild(0).GetComponent<MeshRenderer>().bounds.size.x;
                    float yyb2 = balustrade2.transform.GetChild(0).GetComponent<MeshRenderer>().bounds.size.y;
                    float zzb2 = balustrade2.transform.GetChild(0).GetComponent<MeshRenderer>().bounds.size.z;


                    Vector3 scale2 = balustrade2.transform.GetChild(0).transform.localScale;

                    scale2.x = yy * scale2.x / xxb2;
                    //scale2.y = (talltall - mini_ass) * scale2.y / yyb2;
                    scale2.y = mini * scale2.y / yyb2;

                    scale2.z = 0.8f * scale2.z / zzb2;


                   // balustrade2.transform.GetChild(0).transform.GetComponent<Renderer>().material.color = Color.red;

                    balustrade2.transform.GetChild(0).transform.localScale = scale2;


                    balustrade2.transform.position = (v8 + v1) / 2;

                    balustrade2.transform.Rotate(0, (360 / angle / 2) + 90, 0);

                    balustrade2.transform.Rotate(0, (360 / angle) * (i - 1), 0);

                    BB2.Add(bcc2);




                    //WINDOWS
                    GameObject bcc3 = new GameObject();
                    bcc3.name = ("window"+i);
                    bcc3.transform.parent = this.transform;

                    for (int j = 0; j < ohoh; j++)
                    {


                        GameObject balustrade3 = Instantiate(windows, v0, Quaternion.identity) as GameObject;


                        balustrade3.transform.parent = bcc3.transform;


                        Vector3 smallv = (v2 - v1) / ohoh;

                        float xxb3 = balustrade3.transform.GetChild(0).GetComponent<MeshRenderer>().bounds.size.x;
                        float yyb3 = balustrade3.transform.GetChild(0).GetComponent<MeshRenderer>().bounds.size.y;
                        float zzb3 = balustrade3.transform.GetChild(0).GetComponent<MeshRenderer>().bounds.size.z;


                        Vector3 scale3 = balustrade3.transform.GetChild(0).transform.localScale;

                        float wt = Vector3.Distance(v6, v7);



                        scale3.x = 1.0f * scale3.x / xxb3;
                        scale3.y = wt * scale3.y / yyb3;
                        scale3.z = (smallv.magnitude - 2) * scale3.z / zzb3;

                        balustrade3.transform.GetChild(0).transform.localScale = scale3;

                        balustrade3.transform.position = v6 + (smallv * j) + smallv.normalized;
                        balustrade3.transform.Rotate(0, (360 / angle / 2) - 180, 0);
                        balustrade3.transform.Rotate(0, (360 / angle) * (i - 1), 0);


                        if (j != ohoh - 1)
                        {


                            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cylinder);

                            cube.transform.parent = bcc3.transform;


                            float xxb4 = cube.transform.GetComponent<MeshRenderer>().bounds.size.x;
                            float yyb4 = cube.transform.GetComponent<MeshRenderer>().bounds.size.y;
                            float zzb4 = cube.transform.GetComponent<MeshRenderer>().bounds.size.z;


                            Vector3 scale4 = cube.transform.transform.localScale;

                            cube.transform.GetComponent<Renderer>().material.color = Color.red;


                            scale4.x = 1.4f * scale4.x / xxb4;
                            scale4.y = talltall * scale4.y / yyb4;
                            scale4.z = 1.4f * scale4.z / zzb4;

                            cube.transform.transform.localScale = scale4;

                            cube.transform.position = v1 + (smallv * j) + (smallv);
                            cube.transform.Rotate(0, (360 / angle / 2) - 180, 0);
                            cube.transform.Rotate(0, (360 / angle) * (i - 1), 0);
                            cube.transform.Translate(0, -talltall / 2, 0);


                        }


                    }

                    WINDOW.Add(bcc3);


                }












        }



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
        for (int i = 0; i < BB.Count; i++)
        {
            Destroy(BB[i]);
        }

        for (int i = 0; i < BB2.Count; i++)
        {
            Destroy(BB2[i]);
        }
        for (int i = 0; i < WINDOW.Count; i++)
        {
            Destroy(WINDOW[i]);
        }


        BB.Clear();
        BB2.Clear();
        WINDOW.Clear();



        if(uict.isCb==true)
        { 
            ini(up,down);
            build(up, down);
        }



        body_wide = Vector3.Distance(columncon.columnmanage[0].transform.GetChild(0).transform.position, columncon.columnmanage[1].transform.GetChild(0).transform.position);
    
    
    
    }


}
