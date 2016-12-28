using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class upridge : MonoBehaviour {

    public List<GameObject> upridgemanage = new List<GameObject>();
    public roofcontrol uict;
    public RidgeControl ridgecon;
    public AllInOne  AIO;



	// Use this for initialization
	void Start () {
        AIO = transform.parent.parent.GetComponent<AllInOne>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    public void ini()
    {


        GameObject upri = new GameObject();
        upri.name = "upri1";
        upri.AddComponent<catline>();

        Vector3 v1 = ridgecon.ridgemanage[0].transform.GetChild(0).transform.position;
        Vector3 v2 = ridgecon.ridgemanage[1].transform.GetChild(0).transform.position;


        GameObject g1 = new GameObject();
        g1.transform.position = v1;
        g1.transform.parent = upri.transform;
        upri.GetComponent<catline>().AddControlPoint(g1);

       
        GameObject g2 = new GameObject();
        g2.transform.position = (v1 + v2) / 2;
        g2.transform.parent = upri.transform;
        upri.GetComponent<catline>().AddControlPoint(g2);

        GameObject g3 = new GameObject();
        g3.transform.position = v2;
        g3.transform.parent = upri.transform;
        upri.GetComponent<catline>().AddControlPoint(g3);


        upridgemanage.Add(upri.gameObject);

        upri.transform.parent = this.transform;


   

        upri.GetComponent<catline>().ResetCatmullRom();

    }



    public void inig1(GameObject a)
    {

       

        
      

        if (AIO.Rectangle_Or_Not == true)
        {


            upridgemanage[0].GetComponent<catline>().ResetCatmullRom();
            upridgemanage[2].GetComponent<catline>().ResetCatmullRom();


            a.GetComponent<catline>().ResetCatmullRom();
            a.GetComponent<circlecut1>().reset();
            a.GetComponent<upridgetile>().reset();
        }
        else
        {
            a.transform.GetChild(0).transform.position = upridgemanage[0].transform.GetChild(2).transform.position;

            a.transform.GetChild(2).transform.position = upridgemanage[2].transform.GetChild(0).transform.position;




            a.transform.GetChild(1).transform.position = (a.transform.GetChild(0).transform.position + a.transform.GetChild(2).transform.position) / 2;



            upridgemanage[0].GetComponent<catline>().ResetCatmullRom();
            upridgemanage[2].GetComponent<catline>().ResetCatmullRom();


            a.GetComponent<catline>().ResetCatmullRom();
            a.GetComponent<circlecut1>().reset();
            a.GetComponent<upridgetile>().reset();
        }


    }

    public void inig2(GameObject a)
    {
        if (AIO.Rectangle_Or_Not == true)
        {


            upridgemanage[0].GetComponent<catline>().ResetCatmullRom();
            upridgemanage[2].GetComponent<catline>().ResetCatmullRom();


            a.GetComponent<catline>().ResetCatmullRom();
            a.GetComponent<circlecut1>().reset();
            a.GetComponent<upridgetile>().reset();
        }
        else
        {

            a.transform.GetChild(0).transform.position = upridgemanage[2].transform.GetChild(2).transform.position;

            a.transform.GetChild(2).transform.position = upridgemanage[0].transform.GetChild(0).transform.position;

            a.transform.GetChild(1).transform.position = (a.transform.GetChild(0).transform.position + a.transform.GetChild(2).transform.position) / 2;


            upridgemanage[2].GetComponent<catline>().ResetCatmullRom();
            upridgemanage[0].GetComponent<catline>().ResetCatmullRom();



            a.GetComponent<catline>().ResetCatmullRom();
            a.GetComponent<circlecut1>().reset();
            a.GetComponent<upridgetile>().reset();

        }

    }

    public void inig3(GameObject a)
    {
        if (AIO.Rectangle_Or_Not == true)
        {


            upridgemanage[0].GetComponent<catline>().ResetCatmullRom();
            upridgemanage[2].GetComponent<catline>().ResetCatmullRom();


            a.GetComponent<catline>().ResetCatmullRom();
            a.GetComponent<circlecut1>().reset();
            a.GetComponent<upridgetile>().reset();
        }
        else
        {

            a.transform.GetChild(0).transform.position = upridgemanage[1].transform.GetChild(2).transform.position;

            a.transform.GetChild(2).transform.position = upridgemanage[3].transform.GetChild(0).transform.position;

            a.transform.GetChild(1).transform.position = (a.transform.GetChild(0).transform.position + a.transform.GetChild(2).transform.position) / 2;


            upridgemanage[1].GetComponent<catline>().ResetCatmullRom();
            upridgemanage[3].GetComponent<catline>().ResetCatmullRom();

            a.GetComponent<catline>().ResetCatmullRom();
            a.GetComponent<circlecut1>().reset();
            a.GetComponent<upridgetile>().reset();
        }


    }

    public void inig4(GameObject a)
    {
        if (AIO.Rectangle_Or_Not == true)
        {


            upridgemanage[0].GetComponent<catline>().ResetCatmullRom();
            upridgemanage[2].GetComponent<catline>().ResetCatmullRom();


            a.GetComponent<catline>().ResetCatmullRom();
            a.GetComponent<circlecut1>().reset();
            a.GetComponent<upridgetile>().reset();
        }
        else
        {

            a.transform.GetChild(0).transform.position = upridgemanage[3].transform.GetChild(2).transform.position;

            a.transform.GetChild(2).transform.position = upridgemanage[1].transform.GetChild(0).transform.position;

            a.transform.GetChild(1).transform.position = (a.transform.GetChild(0).transform.position + a.transform.GetChild(2).transform.position) / 2;


            upridgemanage[3].GetComponent<catline>().ResetCatmullRom();
            upridgemanage[1].GetComponent<catline>().ResetCatmullRom();

            a.GetComponent<catline>().ResetCatmullRom();
            a.GetComponent<circlecut1>().reset();
            a.GetComponent<upridgetile>().reset();
        }


    }



    public void build()
    {
        int angle = uict.numberslidervalue;


        Vector3 v1=new Vector3(0,0,0);
        Vector3 v2 = new Vector3(0, 0, 0);

        for (int i = 2; i <= angle; i++)
        {





                /*
                GameObject go = Instantiate(upridgemanage[0], upridgemanage[0].transform.position, Quaternion.identity) as GameObject;

                Destroy(go.GetComponent<EaveControl>());
                go.transform.RotateAround(uict.center.transform.position, Vector3.up, (360 / angle) * (i - 1));
                go.name = ("upri" + i);
                go.transform.parent = this.transform;

                Destroy(go.transform.GetChild(1).GetComponent<upridgemidpoint>());
               


                if(i==2)
                {

                    go.transform.GetChild(1).gameObject.AddComponent<upridgemidpoint2>();


                }



                for (int j = 0; j < go.transform.GetChildCount(); j++)
                {


                    if (i == 2 && j != 1)
                    {
                        Destroy(go.transform.GetChild(j).GetComponent<MeshRenderer>());
                        Destroy(go.transform.GetChild(j).GetComponent<SphereCollider>());
                    }
                
                
                }


            */





            //新

            GameObject upri = new GameObject();
            upri.name = "upri"+i;
            upri.AddComponent<catline>();



            if (i == angle)
            {
                v1 = ridgecon.ridgemanage[i - 1].transform.GetChild(0).transform.position;
                v2 = ridgecon.ridgemanage[0].transform.GetChild(0).transform.position;
            }
            else
            {
                v1 = ridgecon.ridgemanage[i-1].transform.GetChild(0).transform.position;
                v2 = ridgecon.ridgemanage[i].transform.GetChild(0).transform.position;
            }

            GameObject g1 = new GameObject();
            g1.transform.position = v1;
            g1.transform.parent = upri.transform;
            upri.GetComponent<catline>().AddControlPoint(g1);


            GameObject g2 = new GameObject();
            g2.transform.position = (v1 + v2) / 2;
            g2.transform.parent = upri.transform;
            upri.GetComponent<catline>().AddControlPoint(g2);

            GameObject g3 = new GameObject();
            g3.transform.position = v2;
            g3.transform.parent = upri.transform;
            upri.GetComponent<catline>().AddControlPoint(g3);


           

            upri.transform.parent = this.transform;





            upri.AddComponent<catline>();
           upri.GetComponent<catline>().ResetCatmullRom();




            upridgemanage.Add(upri);

           

        }




        for (int i = 0; i < upridgemanage.Count; i++)
        {


            upridgemanage[i].AddComponent<circlecut1>().reset();
            upridgemanage[i].AddComponent<upridgetile>().reset();

        }


    }

    public void reset()
    {
        for (int i = 0; i < upridgemanage.Count; i++)
        {
            Destroy(upridgemanage[i]);
        }
        upridgemanage.Clear();


        if (uict.upridge == true)
        {
            ini();
            build();
        }
    }

  
}
