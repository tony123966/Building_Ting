using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EaveControl : MonoBehaviour {

    public List<GameObject> eavemanage = new List<GameObject>();
    public roofcontrol uict;
    public RidgeControl ridgecon;


    public Vector3 r2p;
    public Vector3 r3p;
    public Vector3 r4p;
    public Vector3 r5p;
    public Vector3 r6p;
	// Use this for initialization
	void Start () {

       
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    public void ini()
    {
        GameObject eave = new GameObject();
        eave.name = "Eave1";
        eave.AddComponent<catline>();
       

        Vector3 v1 = ridgecon.ridgemanage[0].transform.GetChild(2).transform.position;
        Vector3 v2 = ridgecon.ridgemanage[1].transform.GetChild(2).transform.position;

        Vector3 dis = (v2 - v1) / 8;

        eavemanage.Add(eave.gameObject);

        eave.transform.parent = this.transform;


        for (int j = 1; j <= 9; j++)
        {
            if (j != 4 && j != 6)
            {
                //GameObject eaveson = GameObject.CreatePrimitive(PrimitiveType.Sphere);

                GameObject eaveson = new GameObject();

                eaveson.transform.parent = eave.transform;
                eaveson.transform.localScale = new Vector3(1f, 1f, 1f);
                eaveson.transform.position = v1+ dis * (j - 1);

                if (j == 2 || j == 8)
                {
                    eaveson.transform.Translate(0, -1f, 0);

                    if (j == 8)
                    {

                    }
                }
                if (j == 3 || j == 4 || j == 5 || j == 6 || j == 7)
                {
                    eaveson.transform.Translate(0, -1f, 0);
                    if (j == 3)
                    {
                    }
                    if (j == 7)
                    {
                    }
                    if (j == 5)
                    {
                    }
                }

                if (j == 2)
                {
                    eaveson.AddComponent<mouseevent>();
                    eaveson.AddComponent<eavecontrolpoint2>();
                     r2p = eaveson.transform.position;
                }
                else if (j == 3)
                {
                    eaveson.AddComponent<mouseevent>();
                    eaveson.AddComponent<eavecontrolpoint>();

                    r3p = eaveson.transform.position;
                }
                else if (j == 5)
                {
                    r4p = eaveson.transform.position;
                }
                else if (j == 7)
                {
                    r5p = eaveson.transform.position;
                }
                else if (j == 8)
                {
                    r6p = eaveson.transform.position;
                }
                if (j != 1 && j != 2 && j != 3)
                {

                    Destroy(eaveson.GetComponent<MeshRenderer>());
                    Destroy(eaveson.GetComponent<SphereCollider>());
                }
                eave.GetComponent<catline>().AddControlPoint(eaveson);
            }

        }

        eave.GetComponent<catline>().ResetCatmullRom();
                
    }


    public void inig(GameObject a)
    {

        int n = int.Parse(a.name.Substring(4, 1));

        //GameObject eave = new GameObject();



        a.name = ("Eave"+n);
       
        //a.AddComponent<catline>();
        
        Vector3 v1;
        Vector3 v2;

        for (int z = 0;z<a.transform.childCount ;z++ )
        {
            a.GetComponent<catline>().RemoveControlPoint(a.transform.GetChild(z).gameObject);
            Destroy(a.transform.GetChild(z).gameObject);
            
        }
        
            if (n == 4)
            {

                v1 = ridgecon.ridgemanage[n - 1].transform.GetChild(2).transform.position;
                v2 = ridgecon.ridgemanage[0].transform.GetChild(2).transform.position;


            }
            else
            {
                v1 = ridgecon.ridgemanage[n - 1].transform.GetChild(2).transform.position;
                v2 = ridgecon.ridgemanage[n].transform.GetChild(2).transform.position;

            }
      
        

        Vector3 dis = (v2 - v1) / 8;

        //eavemanage.Add(eave.gameObject);

       
        a.transform.parent = this.transform;


        for (int j = 1; j <= 9; j++)
        {
            if (j != 4 && j != 6)
            {
                GameObject eaveson = new GameObject();

                eaveson.transform.parent = a.transform;
                eaveson.transform.localScale = new Vector3(1f, 1f, 1f);
                eaveson.transform.position = v1 + dis * (j - 1);

                if (j == 2 || j == 8)
                {
                    eaveson.transform.Translate(0, -2f, 0);

                    if (j == 8)
                    {

                    }
                }
                if (j == 3 || j == 4 || j == 5 || j == 6 || j == 7)
                {
                    eaveson.transform.Translate(0, -2f, 0);
                    if (j == 3)
                    {
                    }
                    if (j == 7)
                    {
                    }
                    if (j == 5)
                    {
                    }
                }

                if (j == 2)
                {
                    eaveson.AddComponent<mouseevent>();
                    eaveson.AddComponent<eavecontrolpoint2>();
                    r2p = eaveson.transform.position;
                }
                else if (j == 3)
                {
                    eaveson.AddComponent<mouseevent>();
                    eaveson.AddComponent<eavecontrolpoint>();

                    r3p = eaveson.transform.position;
                }
                else if (j == 5)
                {
                    r4p = eaveson.transform.position;
                }
                else if (j == 7)
                {
                    r5p = eaveson.transform.position;
                }
                else if (j == 8)
                {
                    r6p = eaveson.transform.position;
                }
                if (j != 1 && j != 2 && j != 3)
                {

                    Destroy(eaveson.GetComponent<MeshRenderer>());
                    Destroy(eaveson.GetComponent<SphereCollider>());
                }
                a.GetComponent<catline>().AddControlPoint(eaveson);
            }

        }

        a.GetComponent<catline>().ResetCatmullRom();

        //Destroy(eavemanage[n - 1]);
        eavemanage[n - 1] = a.gameObject;

    }















    public void selfini()
    {
        GameObject eave = new GameObject();
        eave.name = "Eave1";
        eave.AddComponent<catline>();

        Vector3 v1 = ridgecon.ridgemanage[0].transform.GetChild(2).transform.position;
        Vector3 v2 = ridgecon.ridgemanage[1].transform.GetChild(2).transform.position;

        Vector3 dis = (v2 - v1) / 8;

        eavemanage.Add(eave.gameObject);

        eave.transform.parent = this.transform;


        for (int j = 1; j <= 9; j++)
        {
            if (j != 4 && j != 6)
            {
                GameObject eaveson = GameObject.CreatePrimitive(PrimitiveType.Sphere);

                eaveson.transform.parent = eave.transform;
                eaveson.transform.localScale = new Vector3(1f, 1f, 1f);


                if (j == 2)
                {
                    eaveson.AddComponent<mouseevent>();
                    eaveson.AddComponent<eavecontrolpoint2>();

                    eaveson.transform.position = r2p;
                }
                else if (j==3)
                {
                    eaveson.AddComponent<mouseevent>();
                    eaveson.AddComponent<eavecontrolpoint>();

                    eaveson.transform.position = r3p;
                }
                else if (j == 5)
                {
                    eaveson.transform.position = r4p;
                }
                else if (j == 7)
                {
                    eaveson.transform.position = r5p;
                }
                else if (j == 8)
                {
                    eaveson.transform.position = r6p;
                }
                else
                {
                    eaveson.transform.position = v1 + dis * (j - 1);
                }

                if (j == 2 || j == 8)
                {
                    //eaveson.transform.Translate(0, -2f, 0);

                    if (j == 8)
                    {

                    }

                }
                if (j == 3 || j == 4 || j == 5 || j == 6 || j == 7)
                {


                    //eaveson.transform.Translate(0, -2f, 0);
                    if (j == 3)
                    {



                    }
                    if (j == 7)
                    {


                    }
                    if (j == 5)
                    {


                    }




                }


                if (j != 1 && j != 2 && j != 3)
                {

                    Destroy(eaveson.GetComponent<MeshRenderer>());
                    Destroy(eaveson.GetComponent<SphereCollider>());
                }
                eave.GetComponent<catline>().AddControlPoint(eaveson);
            }



        }

        eave.GetComponent<catline>().ResetCatmullRom();



    }


    

    public void build()
    {




        int angle = uict.numberslidervalue;






        for (int i = 2; i <= angle; i++)
        {


            //new        
            GameObject eave = new GameObject();
            eave.name = "Eave"+i;
            eave.AddComponent<catline>();
             Vector3 v1 = new Vector3(0, 0, 0);
             Vector3 v2 = new Vector3(0, 0, 0);


             if (i == angle)
             {
                 v1 = ridgecon.ridgemanage[i - 1].transform.GetChild(2).transform.position;
                 v2 = ridgecon.ridgemanage[0].transform.GetChild(2).transform.position;
             }
             else
             {
                 v1 = ridgecon.ridgemanage[i-1].transform.GetChild(2).transform.position;
                 v2 = ridgecon.ridgemanage[i].transform.GetChild(2).transform.position;
             }
            
            Vector3 dis = (v2 - v1) / 8;

            eavemanage.Add(eave.gameObject);

            eave.transform.parent = this.transform;


            for (int j = 1; j <= 9; j++)
            {
                if (j != 4 && j != 6)
                {
                    //GameObject eaveson = GameObject.CreatePrimitive(PrimitiveType.Sphere);

                    GameObject eaveson = new GameObject();

                    eaveson.transform.parent = eave.transform;
                    eaveson.transform.localScale = new Vector3(1f, 1f, 1f);
                    eaveson.transform.position = v1 + dis * (j - 1);

                    if (j == 2 || j == 8)
                    {
                        eaveson.transform.Translate(0, -1f, 0);

                        if (j == 8)
                        {

                        }
                    }
                    if (j == 3 || j == 4 || j == 5 || j == 6 || j == 7)
                    {
                        eaveson.transform.Translate(0, -1f, 0);
                        if (j == 3)
                        {
                        }
                        if (j == 7)
                        {
                        }
                        if (j == 5)
                        {
                        }
                    }

                    if (j == 2)
                    {
                        eaveson.AddComponent<mouseevent>();
                        eaveson.AddComponent<eavecontrolpoint2>();
                        r2p = eaveson.transform.position;
                    }
                    else if (j == 3)
                    {
                        eaveson.AddComponent<mouseevent>();
                        eaveson.AddComponent<eavecontrolpoint>();

                        r3p = eaveson.transform.position;
                    }
                    else if (j == 5)
                    {
                        r4p = eaveson.transform.position;
                    }
                    else if (j == 7)
                    {
                        r5p = eaveson.transform.position;
                    }
                    else if (j == 8)
                    {
                        r6p = eaveson.transform.position;
                    }
                    if (j != 1 && j != 2 && j != 3)
                    {

                        Destroy(eaveson.GetComponent<MeshRenderer>());
                        Destroy(eaveson.GetComponent<SphereCollider>());
                    }
                    eave.GetComponent<catline>().AddControlPoint(eaveson);
                }

            }

            eave.GetComponent<catline>().ResetCatmullRom();


            

                /*
                GameObject go = Instantiate(eavemanage[0], eavemanage[0].transform.position, Quaternion.identity) as GameObject;

                Destroy(go.GetComponent<EaveControl>());
                go.transform.RotateAround(uict.center.transform.position, Vector3.up, (360 / angle) * (i - 1));
                go.name = ("Eave" + i);
                go.transform.parent = this.transform;

                for (int j = 0;j<go.transform.GetChildCount() ; j++)
                {
                    Destroy(go.transform.GetChild(j).GetComponent<MeshRenderer>());
                    Destroy(go.transform.GetChild(j).GetComponent<SphereCollider>());

                }

                go.AddComponent<catline>();
                go.GetComponent<catline>().ResetCatmullRom();
               



                eavemanage.Add(go);
                */
            

        }
       

    }

    public void reset()
    {
        for (int i = 0; i < eavemanage.Count; i++)
        {
            Destroy(eavemanage[i]);
        }
        eavemanage.Clear();

        ini();
        build();
    }

    public void withoutinireset()
    {

        for (int i = 0; i < eavemanage.Count; i++)
        {
            Destroy(eavemanage[i]);
        }
        eavemanage.Clear();

        selfini();
        build();

    }


}
