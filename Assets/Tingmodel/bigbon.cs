using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class bigbon : MonoBehaviour
{

    public List<GameObject> BB = new List<GameObject>();



    public UIcontrol uict;
    public ColumnControl columncon;

    public GameObject haha;


    public int ohoh;

    // Use this for initialization


    void Awake()
    {
        //GameObject haha = GameObject.Find("frieze_old");

        haha = GameObject.Find("bigbonB");


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
        ohoh = (int)uict.ohoh.value;

        int i = uict.numberslidervalue;

        GameObject bcc = new GameObject();
        bcc.name = ("bigbon1");
        bcc.transform.parent = this.transform;

       
            Vector3 v0 = new Vector3(0, 0, 0);

            GameObject balustrade = Instantiate(haha, v0, Quaternion.identity) as GameObject;


            balustrade.transform.parent = bcc.transform;


            Vector3 v1 = columncon.columnmanage[0].transform.GetChild(0).position;
            Vector3 v2 = columncon.columnmanage[1].transform.GetChild(0).position;
            Vector3 v3 = columncon.columnmanage[0].transform.GetChild(1).position;
            Vector3 v4 = columncon.columnmanage[1].transform.GetChild(1).position;

            Vector3 bigv = v2 - v1;
            Vector3 smallv = (v2 - v1) / 2;
            Vector3 mid = (v1 + v3) / 2;



            float yy = Vector3.Distance(v1, v2);

          

            float zz = (v1-v2).magnitude;

            float xxb = balustrade.transform.GetChild(0).GetComponent<MeshRenderer>().bounds.size.x;
            float yyb = balustrade.transform.GetChild(0).GetComponent<MeshRenderer>().bounds.size.y;
            float zzb = balustrade.transform.GetChild(0).GetComponent<MeshRenderer>().bounds.size.z;


            Vector3 scale = balustrade.transform.GetChild(0).transform.localScale;

        /*
            scale.x = 0.6f * scale.x / xxb;
            scale.y = yy * scale.y / yyb;
            scale.z = zz * scale.z / zzb;

         */

           // scale.x = yy * scale.x / xxb;
            scale.x = yy * scale.x / xxb;
            scale.y = 2.5f * scale.y / yyb;
            scale.z = 1 * scale.z / zzb;




            balustrade.transform.GetChild(0).transform.localScale = scale;

            balustrade.transform.position = (v1+v2 )/2;


            balustrade.transform.Rotate(0, (360 / i / 2)+90 , 0);

            //dodo.transform.GetChild(0).transform.localScale = new Vector3(0.1f, yy, zz);

        

        BB.Add(bcc);


    }

    public void build()
    {
        int angle = uict.numberslidervalue;


        Vector3 v0 = new Vector3(0, 0, 0);
        Vector3 v1;
        Vector3 v2;
        Vector3 v3;
        Vector3 v4;


        for (int i = 2; i <= angle; i++)
        {

            

            GameObject bcc = new GameObject();
            bcc.name = ("bigbon"+i);
            bcc.transform.parent = this.transform;



            
                GameObject balustrade = Instantiate(haha, v0, Quaternion.identity) as GameObject;


                balustrade.transform.parent = bcc.transform;


                if (i == angle)
                {

                    v1 = columncon.columnmanage[i - 1].transform.GetChild(0).position;
                    v2 = columncon.columnmanage[0].transform.GetChild(0).position;
                    v3 = columncon.columnmanage[i - 1].transform.GetChild(1).position;
                    v4 = columncon.columnmanage[0].transform.GetChild(1).position;


                }
                else
                {
                    v1 = columncon.columnmanage[i - 1].transform.GetChild(0).position;
                    v2 = columncon.columnmanage[i].transform.GetChild(0).position;
                    v3 = columncon.columnmanage[i - 1].transform.GetChild(1).position;
                    v4 = columncon.columnmanage[i].transform.GetChild(1).position;

                }



                float yy = Vector3.Distance(v1, v2);

               

                float zz = (v1 - v2).magnitude;

                float xxb = balustrade.transform.GetChild(0).GetComponent<MeshRenderer>().bounds.size.x;
                float yyb = balustrade.transform.GetChild(0).GetComponent<MeshRenderer>().bounds.size.y;
                float zzb = balustrade.transform.GetChild(0).GetComponent<MeshRenderer>().bounds.size.z;


                Vector3 scale = balustrade.transform.GetChild(0).transform.localScale;

                /*
                    scale.x = 0.6f * scale.x / xxb;
                    scale.y = yy * scale.y / yyb;
                    scale.z = zz * scale.z / zzb;

                 */

                // scale.x = yy * scale.x / xxb;
                scale.x = yy * scale.x / xxb;
                scale.y = 2.5f * scale.y / yyb;
                scale.z = 1 * scale.z / zzb;




                balustrade.transform.GetChild(0).transform.localScale = scale;

                balustrade.transform.position = (v1 + v2) / 2;


                balustrade.transform.Rotate(0, (360 / angle / 2) + 90, 0);

                balustrade.transform.Rotate(0, (360 / angle) * (i-1), 0);

            
            
            





            BB.Add(bcc);

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
        BB.Clear();

        ini();
        build();
    }


}
