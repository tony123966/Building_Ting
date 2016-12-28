using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ColumnControl : MonoBehaviour
{

    public List<GameObject> columnmanage = new List<GameObject>();
    public List<GameObject> childcolumnmanage = new List<GameObject>();


    public UIcontrol uict;

    // Use this for initialization
    public FC fc;
    public BC bc;
    public PlatForm pf;

    public Vector3 top;
    public Vector3 down;


    public float EyeToColumn;

    public float ColumnLong;

    public float ColumnWide;

    public Vector2 ini_EyeToColumn;


    public GameObject die;


    //multi-column

    public int columnnumber;
    public int bodycolumnnumber;

    public bool multi_or_not;

    public bool C;
    public bool B;




    void Awake()
    {
        bodycolumnnumber = 1;
        columnnumber = 1;
    }


    void Start()
    {
        multi_or_not=true;
        

        EyeToColumn = Mathf.Abs(transform.GetChild(3).transform.position.x - uict.center.transform.position.x);

        ColumnLong = Mathf.Abs(transform.GetChild(0).transform.position.y - transform.GetChild(3).transform.position.y);

        ColumnWide = Vector3.Distance(transform.GetChild(0).transform.position ,transform.GetChild(1).transform.position);

        ini_EyeToColumn.x = transform.position.x ;
        ini_EyeToColumn.y = transform.position.z;
        








        /*
        build();
        fc.ini();
        fc.build();
        bc.ini();
        bc.build();
        pf.build();
        */


    }

    // Update is called once per frame
    void Update()
    {

    }


    public void build()
    {
        columnmanage.Add(this.gameObject);

        int angle = uict.numberslidervalue;




        if (angle == 4)
        {


            for (int i = 2; i <= angle; i++)
            {
                GameObject go = Instantiate(this.gameObject, this.transform.position, Quaternion.identity) as GameObject;

                Destroy(go.GetComponent<ColumnControl>());

                Destroy(go.transform.GetChild(0).GetComponent<MeshRenderer>());
                Destroy(go.transform.GetChild(0).GetComponent<SphereCollider>());
                Destroy(go.transform.GetChild(1).GetComponent<MeshRenderer>());
                Destroy(go.transform.GetChild(1).GetComponent<SphereCollider>());
                Destroy(go.transform.GetChild(2).GetComponent<MeshRenderer>());
                Destroy(go.transform.GetChild(2).GetComponent<SphereCollider>());
                Destroy(go.transform.GetChild(3).GetComponent<MeshRenderer>());
                Destroy(go.transform.GetChild(3).GetComponent<SphereCollider>());







                if (i == 2)
                {
                    go.transform.GetChild(0).transform.position = Xmirrow(columnmanage[0].transform.GetChild(0).transform.position);
                    go.transform.GetChild(1).transform.position = Xmirrow(columnmanage[0].transform.GetChild(1).transform.position);
                    go.transform.GetChild(2).transform.position = Xmirrow(columnmanage[0].transform.GetChild(2).transform.position);
                    go.transform.GetChild(3).transform.position = Xmirrow(columnmanage[0].transform.GetChild(3).transform.position);
                }

                if (i == 3)
                {
                    go.transform.GetChild(0).transform.position = Xmirrow(columnmanage[0].transform.GetChild(0).transform.position);
                    go.transform.GetChild(0).transform.position = Ymirrow(go.transform.GetChild(0).transform.position);

                    go.transform.GetChild(1).transform.position = Xmirrow(columnmanage[0].transform.GetChild(1).transform.position);
                    go.transform.GetChild(1).transform.position = Ymirrow(go.transform.GetChild(1).transform.position);

                    go.transform.GetChild(2).transform.position = Xmirrow(columnmanage[0].transform.GetChild(2).transform.position);
                    go.transform.GetChild(2).transform.position = Ymirrow(go.transform.GetChild(2).transform.position);

                    go.transform.GetChild(3).transform.position = Xmirrow(columnmanage[0].transform.GetChild(3).transform.position);
                    go.transform.GetChild(3).transform.position = Ymirrow(go.transform.GetChild(3).transform.position);
                }

                if (i == 4)
                {
                    go.transform.GetChild(0).transform.position = Ymirrow(columnmanage[0].transform.GetChild(0).transform.position);
                    go.transform.GetChild(1).transform.position = Ymirrow(columnmanage[0].transform.GetChild(1).transform.position);
                    go.transform.GetChild(2).transform.position = Ymirrow(columnmanage[0].transform.GetChild(2).transform.position);
                    go.transform.GetChild(3).transform.position = Ymirrow(columnmanage[0].transform.GetChild(3).transform.position);
                }






                go.name = ("Column" + i);

                go.AddComponent<catline>();
                go.GetComponent<catline>().ResetCatmullRom();
             

                go.transform.parent = this.transform.parent;

                columnmanage.Add(go);

            }

        }
        else
        {


            for (int i = 2; i <= angle; i++)
            {
                GameObject go = Instantiate(this.gameObject, this.transform.position, Quaternion.identity) as GameObject;

                Destroy(go.GetComponent<ColumnControl>());

                Destroy(go.transform.GetChild(0).GetComponent<MeshRenderer>());
                Destroy(go.transform.GetChild(0).GetComponent<SphereCollider>());
                Destroy(go.transform.GetChild(1).GetComponent<MeshRenderer>());
                Destroy(go.transform.GetChild(1).GetComponent<SphereCollider>());
                Destroy(go.transform.GetChild(2).GetComponent<MeshRenderer>());
                Destroy(go.transform.GetChild(2).GetComponent<SphereCollider>());
                Destroy(go.transform.GetChild(3).GetComponent<MeshRenderer>());
                Destroy(go.transform.GetChild(3).GetComponent<SphereCollider>());



                go.transform.RotateAround(uict.center.transform.position, Vector3.up, (360 / angle) * (i - 1));


                go.name = ("Column" + i);

                go.AddComponent<catline>();
                go.GetComponent<catline>().ResetCatmullRom();
                go.transform.parent = this.transform.parent;

                columnmanage.Add(go);

            }
        }



        


        for (int i = 0; i < columnmanage.Count; i++)
        {


            // ridgemanage[i].GetComponent<circlecut1>().cutpoint();
            //ridgemanage[i].GetComponent<Ridgetile>().creat();


            if (columnmanage[i].GetComponent<circlecut1>())
            {
                columnmanage[i].GetComponent<circlecut1>().reset();
                columnmanage[i].GetComponent<Columntile>().kill();
            }

        }
       








    }


    public void childbuild(int n)
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
        CColumn.transform.parent = this.transform.parent;


       die =CColumn ;

        for (int i = 1; i <= angle; i++)
        {

            GameObject CC = new GameObject();
            CC.transform.parent = CColumn.transform;
            CC.name = ("Mom" + i);






            if (i == angle)
            {
                v1 = columnmanage[i- 1].transform.GetChild(0).position;
                v2 = columnmanage[0].transform.GetChild(0).position;
                v3 = columnmanage[i - 1].transform.GetChild(1).position;
                v4 = columnmanage[0].transform.GetChild(1).position;
                v5 = columnmanage[0].transform.GetChild(3).position;


                v6 = columnmanage[i - 1].transform.GetChild(2).position;
                v7 = columnmanage[i - 1].transform.GetChild(3).position;
            
            }
            else
            {
                v1 = columnmanage[i-1].transform.GetChild(0).position;
                v2 = columnmanage[i].transform.GetChild(0).position;
                v3 = columnmanage[i - 1].transform.GetChild(1).position;
                v4 = columnmanage[i].transform.GetChild(1).position;
                v5 = columnmanage[i].transform.GetChild(3).position;


                v6 = columnmanage[i - 1].transform.GetChild(2).position;
                v7 = columnmanage[i - 1].transform.GetChild(3).position;

            }








            Vector3 smallv = (v2 - v1) / n;

            float talltall = Vector3.Distance(v2, v5);


            for (int j = 0; j <= n; j++)
            {

                GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cylinder);

                cube.transform.parent = CC.transform;


                float xxb4 = cube.transform.GetComponent<MeshRenderer>().bounds.size.x;
                float yyb4 = cube.transform.GetComponent<MeshRenderer>().bounds.size.y;
                float zzb4 = cube.transform.GetComponent<MeshRenderer>().bounds.size.z;

                Vector3 scale4 = cube.transform.transform.localScale;

                cube.transform.GetComponent<Renderer>().material.color = Color.red;



                


                scale4.x = 1.4f * scale4.x / xxb4;
                scale4.y = talltall * scale4.y / yyb4;
                scale4.z = 1.4f * scale4.z / zzb4;

                cube.transform.transform.localScale = scale4;

                /*
                if (j == 0)
                {
                    cube.transform.position = v1;
                
                }*/
               
                //cube.transform.position = v1 + (smallv * j) + (smallv);
                
                
                cube.transform.position = v1 + (smallv * j) ;
               

                cube.transform.Translate(0, -talltall / 2, 0);




                GameObject dot1 = new GameObject();
                dot1.transform.parent = cube.transform;
                dot1.transform.position = (v1 + (smallv * j));


                GameObject dot2 = new GameObject();
                dot2.transform.parent = cube.transform;
                dot2.transform.position = (v3 + (smallv * j));
                dot1.transform.parent = cube.transform;

                GameObject dot3 = new GameObject();
                dot3.transform.parent = cube.transform;
                dot3.transform.position = (v6 + (smallv * j));
                dot1.transform.parent = cube.transform;

                GameObject dot4 = new GameObject();
                dot4.transform.parent = cube.transform;
                dot4.transform.position = (v7 + (smallv * j));
                dot1.transform.parent = cube.transform;






            }




            childcolumnmanage.Add(CC);
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




    public void reset()
    {
        //print((this.transform.parent.transform.childCount) + " haha " + (this.transform.parent.transform.childCount - 1) + " name " + this.transform.parent.transform.GetChild(this.transform.parent.transform.childCount - 1).name);
        //Destroy(this.transform.parent.transform.GetChild(this.transform.parent.transform.childCount - 1).gameObject);

        for (int i = 1; i < columnmanage.Count; i++)
        {
            Destroy(columnmanage[i]);
        }


        
        for (int i = 0; i < childcolumnmanage.Count; i++)
        {
            Destroy(childcolumnmanage[i]);
            
        }



            Destroy(die);
        
        childcolumnmanage.Clear();
        columnmanage.Clear();

       
        build();

        if (C == true)
        {
            childbuild(columnnumber);
        }
        if(B == true)
        {
            childbuild(bodycolumnnumber);

        }


        ColumnLong = Mathf.Abs(transform.GetChild(0).transform.position.y - transform.GetChild(3).transform.position.y);
        EyeToColumn = Mathf.Abs(transform.GetChild(3).transform.position.x - uict.center.transform.position.x);
        ColumnWide = Vector3.Distance(transform.GetChild(0).transform.position, transform.GetChild(1).transform.position);
    }


}
