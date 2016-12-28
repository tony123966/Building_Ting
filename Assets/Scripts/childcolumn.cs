using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class childcolumn : MonoBehaviour
{

    public List<GameObject> childcolumnmanage = new List<GameObject>();



    public UIcontrol uict;
    public ColumnControl columncon;

    


    public int ohoh;

    // Use this for initialization


    public int n =3;


    void Awake()
    {
        //GameObject haha = GameObject.Find("frieze_old");


    }



    void Start()
    {



    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ini()
    {

         

        int angle = uict.numberslidervalue;

        Vector3 v1;
        Vector3 v2;
        Vector3 v3;
        Vector3 v4;
        Vector3 v5;
        Vector3 v6;
        

        GameObject CColumn = new GameObject();
        CColumn.name = "childcolumn";
        CColumn.transform.parent = this.transform.parent;




        for (int i = 1; i <= angle; i++)
        {

            GameObject CC = new GameObject();
            CC.transform.parent = CColumn.transform;
            CC.name = ("Mom" + i);


            v1 = columncon.columnmanage[0].transform.GetChild(0).position;
            v2 = columncon.columnmanage[1].transform.GetChild(0).position;
            v3 = columncon.columnmanage[0].transform.GetChild(1).position;
            v4 = columncon.columnmanage[1].transform.GetChild(1).position;
            v5 = columncon.columnmanage[1].transform.GetChild(3).position;


            v6 = columncon.columnmanage[1].transform.GetChild(2).position;





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


                /*
                 GameObject dot1 = new GameObject();
                 dot1.transform.parent = cube.transform;
                 dot1.transform.position = v1 + (smallv * j);

                 GameObject dot2 = new GameObject();
                 dot2.transform.parent = cube.transform;

                 GameObject dot3 = new GameObject();
                 dot3.transform.parent = cube.transform;

                 GameObject dot4 = new GameObject();
                 dot4.transform.parent = cube.transform;
                */


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


                cube.transform.position = v1 + (smallv * j);


                cube.transform.Translate(0, -talltall / 2, 0);




            }




            childcolumnmanage.Add(CC);

        }
    }

    public void build()
    {
       

        





    }

    public void reset()
    {
        for (int i = 0; i <  childcolumnmanage.Count; i++)
        {
            Destroy(childcolumnmanage[i]);
        }
        childcolumnmanage.Clear();

        ini();
        build();
    }


}
