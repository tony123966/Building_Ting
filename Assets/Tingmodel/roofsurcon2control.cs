using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class roofsurcon2control : MonoBehaviour {

    public roofsurcontrol roofsurcon;
    public RidgeControl ridgecon;

    public roofcontrol uict;

    public int linen ;

    public List<GameObject> rrrRL = new List<GameObject>();
    

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ini()
    {

        //linen = uict.twvalue;

         linen =Mathf.RoundToInt(Vector3.Distance(ridgecon.ridgemanage[0].transform.GetChild(2).transform.position,ridgecon.ridgemanage[1].transform.GetChild(2).transform.position)/2);
        

       
        GameObject RL = new GameObject();
        RL.transform.parent = this.transform;
        RL.name = "RL1";
        
        GameObject R1 = new GameObject();
        R1.transform.parent = RL.transform;
        R1.name = ("rrrR1");
        GameObject L1 = new GameObject();
        L1.transform.parent = RL.transform;
        L1.name = ("rrrL1");

        Vector3 v1 = roofsurcon.roofsurfacemanage[0].transform.GetChild(1).transform.position;
        Vector3 v2 = ridgecon.ridgemanage[0].transform.GetChild(2).transform.position;
        Vector3 v3 = ridgecon.ridgemanage[1].transform.GetChild(2).transform.position;

        Vector3 mid = (v2 - v1) / linen;
        Vector3 mid2 = (v3 - v1) / linen;

        for (int i = 1; i < linen; i++)
        {
            GameObject oh = new GameObject();
            oh.transform.parent = R1.transform;
            oh.transform.position = v1 + mid * i;



            GameObject oh2 = new GameObject();
            oh2.transform.parent = L1.transform;
            oh2.transform.position = v1 + mid2 * i; 
        }

        rrrRL.Add(RL);

    }


    public void inig(GameObject a)
    {

        for (int z = 0; z < a.transform.childCount; z++)
        {
            //a.GetComponent<catline>().RemoveControlPoint(a.transform.GetChild(z).gameObject);
            Destroy(a.transform.GetChild(z).gameObject);

        }

        //linen = uict.twvalue;


        int n = int.Parse(a.name.Substring(2, 1));


        if (n == 4)
        {

            linen = Mathf.RoundToInt(Vector3.Distance(ridgecon.ridgemanage[n-1].transform.GetChild(2).transform.position, ridgecon.ridgemanage[0].transform.GetChild(2).transform.position) / 2);
        }
        else 
        {
            linen = Mathf.RoundToInt(Vector3.Distance(ridgecon.ridgemanage[n-1].transform.GetChild(2).transform.position, ridgecon.ridgemanage[n].transform.GetChild(2).transform.position) / 2);
        }


        /*
        GameObject RL = new GameObject();
        RL.transform.parent = a.transform;
        RL.name = "RL1";
        */
        GameObject R1 = new GameObject();
        R1.transform.parent = a.transform;
        R1.name = ("rrrR1");
        GameObject L1 = new GameObject();
        L1.transform.parent = a.transform;
        L1.name = ("rrrL1");

        Vector3 v1;
        Vector3 v2;
        Vector3 v3;


        if(n==4)
        {
            v1 = roofsurcon.roofsurfacemanage[n - 1].transform.GetChild(1).transform.position;
            v2 = ridgecon.ridgemanage[n - 1].transform.GetChild(2).transform.position;
            v3 = ridgecon.ridgemanage[0].transform.GetChild(2).transform.position;
        }
        else
        {
             v1 = roofsurcon.roofsurfacemanage[n-1].transform.GetChild(1).transform.position;
             v2 = ridgecon.ridgemanage[n - 1].transform.GetChild(2).transform.position;
             v3 = ridgecon.ridgemanage[n].transform.GetChild(2).transform.position;

        }
        

        Vector3 mid = (v2 - v1) / linen;
        Vector3 mid2 = (v3 - v1) / linen;

        for (int i = 1; i < linen; i++)
        {
            //GameObject oh = new GameObject();
            GameObject oh = new GameObject();

            oh.transform.parent = R1.transform;
            oh.transform.position = v1 + mid * i;



            GameObject oh2 = new GameObject();
            //GameObject oh2 = GameObject.CreatePrimitive(PrimitiveType.Sphere);

            oh2.transform.parent = L1.transform;
            oh2.transform.position = v1 + mid2 * i;
        }

        rrrRL[n - 1] = a.gameObject;

    }











    public void build()
    {

        int angle = uict.numberslidervalue;
        linen = uict.twvalue;



        Vector3 v1 = new Vector3(0,0,0);
        Vector3 v2 = new Vector3(0,0,0);
        Vector3 v3 = new Vector3(0, 0, 0);


        for (int i = 2; i <= angle; i++)
        {
          


            linen = uict.twvalue;

            if (i != angle)
            {
                linen = Mathf.RoundToInt(Vector3.Distance(ridgecon.ridgemanage[i - 1].transform.GetChild(2).transform.position, ridgecon.ridgemanage[i].transform.GetChild(2).transform.position) / 2);
            }
            else
            {

                linen = Mathf.RoundToInt(Vector3.Distance(ridgecon.ridgemanage[i - 1].transform.GetChild(2).transform.position, ridgecon.ridgemanage[0].transform.GetChild(2).transform.position) / 2);

            }


            GameObject RL = new GameObject();
            RL.transform.parent = this.transform;
            RL.name = "RL"+i;

            GameObject R1 = new GameObject();
            R1.transform.parent = RL.transform;
            R1.name = ("rrrR"+i);
            GameObject L1 = new GameObject();
            L1.transform.parent = RL.transform;
            L1.name = ("rrrL"+i);


            if (i == angle)
            {
                v1 = roofsurcon.roofsurfacemanage[i - 1].transform.GetChild(1).transform.position;
                v2 = ridgecon.ridgemanage[i - 1].transform.GetChild(2).transform.position;
                v3 = ridgecon.ridgemanage[0].transform.GetChild(2).transform.position;
            }
            else
            {
                v1 = roofsurcon.roofsurfacemanage[i-1].transform.GetChild(1).transform.position;
                v2 = ridgecon.ridgemanage[i - 1].transform.GetChild(2).transform.position;
                v3 = ridgecon.ridgemanage[i].transform.GetChild(2).transform.position;
            }


            Vector3 mid = (v2 - v1) / linen;
            Vector3 mid2 = (v3 - v1) / linen;

            for (int j = 1; j < linen; j++)
            {
                GameObject oh = new GameObject();
                oh.transform.parent = R1.transform;
                oh.transform.position = v1 + mid * j;



                GameObject oh2 = new GameObject();
                oh2.transform.parent = L1.transform;
                oh2.transform.position = v1 + mid2 * j;
            }




            /*
            GameObject go = Instantiate(rrrRL[0], rrrRL[0].transform.position, Quaternion.identity) as GameObject;

            Destroy(go.GetComponent<EaveControl>());
            go.transform.RotateAround(uict.center.transform.position, Vector3.up, (360 / angle) * (i - 1));
            go.name = ("RL" + i);
            go.transform.parent = this.transform;

            */
            Destroy(RL.GetComponent<EaveControl>());



            rrrRL.Add(RL);
        }

    }

    public void reset()
    {

        for (int i = 0; i < rrrRL.Count; i++)
        {
            Destroy(rrrRL[i]);
        }
        rrrRL.Clear();

        ini();
        build();
    }


}

