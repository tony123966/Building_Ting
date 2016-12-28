using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FC : MonoBehaviour {

    public List<GameObject> FCL = new List<GameObject>();

    

    public UIcontrol uict;
    public ColumnControl columncon;

    public GameObject haha;
    public GameObject crycry;

    public int ohoh ;

    // Use this for initialization


    void Awake()
    {
        //GameObject haha = GameObject.Find("frieze_old");

       haha = GameObject.Find("frieze");
        crycry = GameObject.Find("Sparrow_Brace");

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
        bcc.name = ("frieze1");
        bcc.transform.parent = this.transform;







        for (int n = 0; n < columncon.columnnumber; n++)
        {


            Vector3 v1 = columncon.childcolumnmanage[0].transform.GetChild(n).transform.GetChild(0).position;
            Vector3 v2 = columncon.childcolumnmanage[0].transform.GetChild(n + 1).transform.GetChild(0).position;
            Vector3 v3 = columncon.childcolumnmanage[0].transform.GetChild(n).transform.GetChild(1).position;
            Vector3 v4 = columncon.childcolumnmanage[0].transform.GetChild(n + 1).transform.GetChild(1).position;

            Vector3 v5 = columncon.childcolumnmanage[0].transform.GetChild(n).transform.GetChild(3).position;






            for (int j = 0; j < ohoh; j++)
            {
                Vector3 v0 = new Vector3(0, 0, 0);

                GameObject balustrade = Instantiate(haha, v0, Quaternion.identity) as GameObject;


                balustrade.transform.parent = bcc.transform;


                /*
                Vector3 v1 = columncon.columnmanage[0].transform.GetChild(0).position;
                Vector3 v2 = columncon.columnmanage[1].transform.GetChild(0).position;
                Vector3 v3 = columncon.columnmanage[0].transform.GetChild(1).position;
                Vector3 v4 = columncon.columnmanage[1].transform.GetChild(1).position;

                Vector3 v5 = columncon.columnmanage[0].transform.GetChild(3).position;

                */





                Vector3 bigv = v2 - v1;
                Vector3 smallv = (v2 - v1) / ohoh;
                Vector3 mid = (v1 + v3) / 2;



                float yy = Vector3.Distance(v1, v3);
                float zz = smallv.magnitude;

                float xxb = balustrade.transform.GetChild(0).GetComponent<MeshRenderer>().bounds.size.x;
                float yyb = balustrade.transform.GetChild(0).GetComponent<MeshRenderer>().bounds.size.y;
                float zzb = balustrade.transform.GetChild(0).GetComponent<MeshRenderer>().bounds.size.z;


                Vector3 scale = balustrade.transform.GetChild(0).transform.localScale;

                scale.x = 0.6f * scale.x / xxb;
                scale.y = yy * scale.y / yyb;
                scale.z = zz * scale.z / zzb;

                balustrade.transform.GetChild(0).transform.localScale = scale;

                balustrade.transform.position = v1 + (smallv * j);
                balustrade.transform.Rotate(0, (360 / i / 2) - 180, 0);




                //Sparrow

                if (j == 0)
                {
                    GameObject Sparrow = Instantiate(crycry, v0, Quaternion.identity) as GameObject;


                    Sparrow.transform.parent = bcc.transform;

                    float xxbs = Sparrow.transform.GetChild(0).GetComponent<MeshRenderer>().bounds.size.x;
                    float yybs = Sparrow.transform.GetChild(0).GetComponent<MeshRenderer>().bounds.size.y;
                    float zzbs = Sparrow.transform.GetChild(0).GetComponent<MeshRenderer>().bounds.size.z;

                    Vector3 scale2 = Sparrow.transform.GetChild(0).transform.localScale;

                    scale2.x = 0.6f * scale2.x / xxbs;
                    scale2.y = Vector3.Distance(v1, v5) / 10 * scale2.y / yybs;
                    scale2.z = Vector3.Distance(v1, v2) / 4 * scale2.z / zzbs;

                    Sparrow.transform.GetChild(0).transform.localScale = scale2;

                    //Sparrow.transform.position = v1 + (smallv);

                    Sparrow.transform.position = v3;
                    Sparrow.transform.Translate(0, 0.1f, 0);
                    Sparrow.transform.Rotate(0, (360 / i / 2) - 180, 0);


                    GameObject Sparrow2 = Instantiate(Sparrow, v3 + smallv * (ohoh), Quaternion.identity) as GameObject;

                    Sparrow2.transform.parent = bcc.transform;
                    Sparrow2.transform.Translate(0, 0.1f, 0);


                    Sparrow2.transform.Rotate(0, (360 / i / 2), 0);

                }


            }

        }

        FCL.Add(bcc);


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
            ohoh = (int)uict.ohoh.value;

            GameObject bcc = new GameObject();
            bcc.name = ("frieze"+i);
            bcc.transform.parent = this.transform;






            for (int n = 0; n < columncon.columnnumber; n++)
            {


                v1 = columncon.childcolumnmanage[i-1].transform.GetChild(n).transform.GetChild(0).position;
                v2 = columncon.childcolumnmanage[i-1].transform.GetChild(n + 1).transform.GetChild(0).position;
                v3 = columncon.childcolumnmanage[i-1].transform.GetChild(n).transform.GetChild(1).position;
                v4 = columncon.childcolumnmanage[i-1].transform.GetChild(n + 1).transform.GetChild(1).position;

                Vector3 v5 = columncon.childcolumnmanage[i-1].transform.GetChild(n).transform.GetChild(3).position;






                for (int j = 0; j < ohoh; j++)
                {


                    GameObject balustrade = Instantiate(haha, v0, Quaternion.identity) as GameObject;
                    balustrade.transform.parent = bcc.transform;

                    /*
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

                    Vector3 v5 = columncon.columnmanage[i - 1].transform.GetChild(3).position;

                    */


                    Vector3 bigv = v2 - v1;
                    Vector3 smallv = (v2 - v1) / ohoh;
                    Vector3 mid = (v1 + v3) / 2;



                    float yy = Vector3.Distance(v1, v3);
                    float zz = smallv.magnitude;

                    float xxb = balustrade.transform.GetChild(0).GetComponent<MeshRenderer>().bounds.size.x;
                    float yyb = balustrade.transform.GetChild(0).GetComponent<MeshRenderer>().bounds.size.y;
                    float zzb = balustrade.transform.GetChild(0).GetComponent<MeshRenderer>().bounds.size.z;


                    Vector3 scale = balustrade.transform.GetChild(0).transform.localScale;

                    scale.x = 0.6f * scale.x / xxb;
                    scale.y = yy * scale.y / yyb;
                    scale.z = zz * scale.z / zzb;

                    balustrade.transform.GetChild(0).transform.localScale = scale;

                    balustrade.transform.position = v1 + (smallv * j);
                    balustrade.transform.Rotate(0, (360 / angle / 2) - 180, 0);


                    balustrade.transform.Rotate(0, (360 / angle) * (i - 1), 0);



                    //Sparrow

                    if (j == 0)
                    {
                        GameObject Sparrow = Instantiate(crycry, v0, Quaternion.identity) as GameObject;


                        Sparrow.transform.parent = bcc.transform;

                        float xxbs = Sparrow.transform.GetChild(0).GetComponent<MeshRenderer>().bounds.size.x;
                        float yybs = Sparrow.transform.GetChild(0).GetComponent<MeshRenderer>().bounds.size.y;
                        float zzbs = Sparrow.transform.GetChild(0).GetComponent<MeshRenderer>().bounds.size.z;

                        Vector3 scale2 = Sparrow.transform.GetChild(0).transform.localScale;

                        scale2.x = 0.6f * scale2.x / xxbs;
                        scale2.y = Vector3.Distance(v1, v5) / 10 * scale2.y / yybs;
                        scale2.z = Vector3.Distance(v1, v2) / 4 * scale2.z / zzbs;

                        Sparrow.transform.GetChild(0).transform.localScale = scale2;

                        //Sparrow.transform.position = v1 + (smallv);

                        Sparrow.transform.position = v3;
                        Sparrow.transform.Translate(0, 0.1f, 0);
                        Sparrow.transform.Rotate(0, (360 / angle / 2) - 180, 0);

                        Sparrow.transform.Rotate(0, (360 / angle) * (i - 1), 0);


                        GameObject Sparrow2 = Instantiate(Sparrow, v3 + smallv * (ohoh), Quaternion.identity) as GameObject;

                        Sparrow2.transform.parent = bcc.transform;
                        Sparrow2.transform.Translate(0, 0.1f, 0);


                        Sparrow2.transform.Rotate(0, (360 / angle / 2), 0);
                        Sparrow2.transform.Rotate(0, (360 / angle) * (i - 1), 0);



                    }










                }
            }
            FCL.Add(bcc);
        }

       
        /*
        GameObject go = Instantiate(FCL[0], FCL[0].transform.position, Quaternion.identity) as GameObject;

        go.transform.RotateAround(uict.center.transform.position, Vector3.up, (360 / angle) * (i - 1));
        go.name = ("frieze" + i);
        go.transform.parent = this.transform;


        FCL.Add(go);
        */



    }



    public void reset()
    {
        for (int i = 0; i < FCL.Count; i++)
        {
            Destroy(FCL[i]);
        }
        FCL.Clear();


        if (uict.isb == true)
        {
            ini();
            build();
        }
    }


}
