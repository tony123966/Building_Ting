using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class roofsurcontrol : MonoBehaviour {

    public List<GameObject> roofsurfacemanage = new List<GameObject>();

    public List<GameObject> rrrR = new List<GameObject>();
    public List<GameObject> rrrL = new List<GameObject>();

    public RidgeControl ridgeControl;
    public EaveControl eaveControl;
    public upridge up;

    public Vector3 r2p;

    public roofcontrol uict;

    public int linen=8;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    public void inig(GameObject a)
    {



        for (int z = 0; z < a.transform.childCount; z++)
        {
            a.GetComponent<catline>().RemoveControlPoint(a.transform.GetChild(z).gameObject);
            Destroy(a.transform.GetChild(z).gameObject);

        }


        int n = int.Parse(a.name.Substring(11, 1));

        
        a.name = ("roofsurface" + n);



        Vector3 v1;
        Vector3 v2;
        Vector3 v3;

        if(n==4)
        {
            v1 = ridgeControl.ridgemanage[n - 1].transform.GetChild(0).transform.position;
            v2 = eaveControl.eavemanage[n - 1].transform.GetChild(3).transform.position;
            v3 = (ridgeControl.ridgemanage[n - 1].transform.GetChild(1).transform.position + ridgeControl.ridgemanage[0].transform.GetChild(1).transform.position) / 2;
        }
        else
        {
            v1 = ridgeControl.ridgemanage[n - 1].transform.GetChild(0).transform.position;
            v2 = eaveControl.eavemanage[n - 1].transform.GetChild(3).transform.position;
            v3 = (ridgeControl.ridgemanage[n - 1].transform.GetChild(1).transform.position + ridgeControl.ridgemanage[n].transform.GetChild(1).transform.position) / 2;
        }
       
        
        
        
        //Vector3 v4 = (v1 + v3) / 2;
        v3.y = v3.y - 2f;



        /*
        GameObject rf = new GameObject();
        rf.AddComponent<catline>();
        rf.name = "roofsurface1";
        rf.transform.parent = this.transform;
        */

        GameObject rfson1 = new GameObject();

        rfson1.transform.parent = a.transform;

        if (uict.upridge == true)
        {
            rfson1.transform.position = up.upridgemanage[n-1].transform.GetChild(1).transform.position;
        }
        else
        {
            rfson1.transform.position = v1;
        }


       // GameObject rfson2 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        GameObject rfson2 = new GameObject();


        rfson2.transform.parent = a.transform;
        rfson2.transform.position = v3;
        rfson2.AddComponent<mouseevent>();
        rfson2.AddComponent<rsfourmove>();

        r2p = v3;

        GameObject rfson3 = new GameObject();

        rfson3.transform.parent = a.transform;
        rfson3.transform.position = v2;

        a.GetComponent<catline>().AddControlPoint(rfson3);
        a.GetComponent<catline>().AddControlPoint(rfson2);
        a.GetComponent<catline>().AddControlPoint(rfson1);


        //roofsurfacemanage.Add(rf);
        roofsurfacemanage[n - 1] = a.gameObject;

        a.GetComponent<catline>().ResetCatmullRom();

        a.GetComponent<midplanecut>().reset();
        a.GetComponent<tiledM>().reset();


    }



    public void ini()
    {
        Vector3 v1 = ridgeControl.ridgemanage[0].transform.GetChild(0).transform.position;
        Vector3 v2 = eaveControl.eavemanage[0].transform.GetChild(3).transform.position;
        Vector3 v3 = (ridgeControl.ridgemanage[0].transform.GetChild(1).transform.position + ridgeControl.ridgemanage[1].transform.GetChild(1).transform.position)/2;
      
        v3.y = v3.y - 2f;

  


        GameObject rf = new GameObject();
        rf.AddComponent<catline>();
        rf.name = "roofsurface1";
        rf.transform.parent = this.transform;
        

        GameObject rfson1 = new GameObject();

        rfson1.transform.parent = rf.transform;

        if (uict.upridge == true)
        {
            rfson1.transform.position = up.upridgemanage[0].transform.GetChild(1).transform.position;
        }
        else
        {
            rfson1.transform.position = v1;
        }


       // GameObject rfson2 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        GameObject rfson2 = new GameObject();


        rfson2.transform.parent = rf.transform;
        rfson2.transform.position = v3;
        rfson2.AddComponent<mouseevent>();
        rfson2.AddComponent<rsfourmove>();

        r2p = v3;

        GameObject rfson3 = new GameObject();

        rfson3.transform.parent = rf.transform;
        rfson3.transform.position = v2;

        rf.GetComponent<catline>().AddControlPoint(rfson3);
        rf.GetComponent<catline>().AddControlPoint(rfson2);
        rf.GetComponent<catline>().AddControlPoint(rfson1);
        
        
        roofsurfacemanage.Add(rf);

        rf.GetComponent<catline>().ResetCatmullRom();
       
    }

    public void selfini()
    {

        Vector3 v1 = ridgeControl.ridgemanage[0].transform.GetChild(0).transform.position;
        Vector3 v2 = eaveControl.eavemanage[0].transform.GetChild(3).transform.position;
        Vector3 v3 = (ridgeControl.ridgemanage[0].transform.GetChild(1).transform.position + ridgeControl.ridgemanage[1].transform.GetChild(1).transform.position) / 2;
        //Vector3 v4 = (v1 + v3) / 2;
        v3.y = v3.y - 1f;

        GameObject rf = new GameObject();
        rf.AddComponent<catline>();
        rf.name = "roofsurface1";
        rf.transform.parent = this.transform;






        GameObject rfson1 = new GameObject();
        rfson1.transform.parent = rf.transform;

        if (uict.upridge == true)
        {
            rfson1.transform.position = up.upridgemanage[0].transform.GetChild(1).transform.position;
        }
        else
        {
            rfson1.transform.position = v1;
        }


        //GameObject rfson2 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        GameObject rfson2 = new GameObject();


        rfson2.transform.parent = rf.transform;
        rfson2.transform.position = r2p;
        rfson2.AddComponent<mouseevent>();
        rfson2.AddComponent<rsfourmove>();



        GameObject rfson3 = new GameObject();

        rfson3.transform.parent = rf.transform;
        rfson3.transform.position = v2;

        rf.GetComponent<catline>().AddControlPoint(rfson3);
        rf.GetComponent<catline>().AddControlPoint(rfson2);
        rf.GetComponent<catline>().AddControlPoint(rfson1);


        roofsurfacemanage.Add(rf);

        rf.GetComponent<catline>().ResetCatmullRom();



    }



    public void build()
    {

        int angle = uict.numberslidervalue;

        //new

        Vector3 v1;
        Vector3 v2;
        Vector3 v3;


        
        for (int i = 2; i <= angle; i++)
        {




        if(i==angle)
        {
            v1 = ridgeControl.ridgemanage[i - 1].transform.GetChild(0).transform.position;
            v2 = eaveControl.eavemanage[i - 1].transform.GetChild(3).transform.position;
            v3 = (ridgeControl.ridgemanage[i - 1].transform.GetChild(1).transform.position + ridgeControl.ridgemanage[0].transform.GetChild(1).transform.position) / 2;
        }
        else
        { 


         v1 = ridgeControl.ridgemanage[i-1].transform.GetChild(0).transform.position;
         v2 = eaveControl.eavemanage[i - 1].transform.GetChild(3).transform.position;
         v3 = (ridgeControl.ridgemanage[i - 1].transform.GetChild(1).transform.position + ridgeControl.ridgemanage[i].transform.GetChild(1).transform.position) / 2;
        
        }
        v3.y = v3.y - 1f;




        GameObject rf = new GameObject();
        rf.AddComponent<catline>();
        rf.name = ("roofsurface"+i);
        rf.transform.parent = this.transform;


        GameObject rfson1 = new GameObject();

        rfson1.transform.parent = rf.transform;

        if (uict.upridge == true)
        {
            rfson1.transform.position = up.upridgemanage[i - 1].transform.GetChild(1).transform.position;
        }
        else
        {
            rfson1.transform.position = v1;
        }


        // GameObject rfson2 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        GameObject rfson2 = new GameObject();


        rfson2.transform.parent = rf.transform;
        rfson2.transform.position = v3;
        rfson2.AddComponent<mouseevent>();
        rfson2.AddComponent<rsfourmove>();

        r2p = v3;

        GameObject rfson3 = new GameObject();

        rfson3.transform.parent = rf.transform;
        rfson3.transform.position = v2;

        rf.GetComponent<catline>().AddControlPoint(rfson3);
        rf.GetComponent<catline>().AddControlPoint(rfson2);
        rf.GetComponent<catline>().AddControlPoint(rfson1);


        roofsurfacemanage.Add(rf);

        rf.GetComponent<catline>().ResetCatmullRom();



        }
        

        /*
        for (int i = 2; i <= angle; i++)
        {

            GameObject go = Instantiate(roofsurfacemanage[0], roofsurfacemanage[0].transform.position, Quaternion.identity) as GameObject;

            Destroy(go.GetComponent<EaveControl>());
            go.transform.RotateAround(uict.center.transform.position, Vector3.up, (360 / angle) * (i - 1));
            go.name = ("roofsurface" + i);
            go.transform.parent = this.transform;

            Destroy(go.transform.GetChild(1).GetComponent<MeshRenderer>());
            Destroy(go.transform.GetChild(1).GetComponent<SphereCollider>());

            
            go.GetComponent<catline>().ResetCatmullRom();



            roofsurfacemanage.Add(go);
        }
        */
        
        for (int i = 0; i < roofsurfacemanage.Count; i++)
        {


            roofsurfacemanage[i].AddComponent<midplanecut>();
            roofsurfacemanage[i].AddComponent<tiledM>();

        }
        

    }

    public void reset()
    {
        
        for (int i = 0; i < roofsurfacemanage.Count; i++)
        {
            Destroy(roofsurfacemanage[i]);
        }
        roofsurfacemanage.Clear();

        ini();
        build();
         

       



    }

    public void withoutinireset()
    {
        for (int i = 0; i < roofsurfacemanage.Count; i++)
        {
            Destroy(roofsurfacemanage[i]);
        }
        roofsurfacemanage.Clear();



        ini();

        build();

    }

    

}
