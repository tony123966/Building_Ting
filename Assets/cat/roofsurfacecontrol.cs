using UnityEngine;
using System.Collections;

public class roofsurfacecontrol : MonoBehaviour {



    public int a = 0;
    public int b = 0;
    public int c = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	        
	}

    public void addpoint()
    {

        int angle = int.Parse(UI.stringToEdit);
        int tiled = int.Parse(UI.stringToEdit2);


       


        //右邊
       for (int i = 1; i <= angle; i++)
        {

            GameObject R1 = new GameObject();

            R1.name = ("rrrR" + i);
            Vector3 start = GameObject.Find("roofcurve" + i).transform.GetChild(1).transform.position;
            Vector3 end = GameObject.Find("Ridge" + i).transform.GetChild(pubvar.ball - 1).transform.position;

            Vector3 mid = (end - start) / tiled;
            for (int j = 1; j <= tiled; j++)
            {
                GameObject oh = new GameObject();
                oh.transform.parent = R1.transform;
                oh.transform.position = start + mid * j;


            }

        }

        //左邊

        for (int i = 1; i <= angle; i++)
        {

            if (i != angle)
            {

                GameObject L1 = new GameObject();

                L1.name = ("rrrL" + i);
                Vector3 start = GameObject.Find("roofcurve" + i).transform.GetChild(1).transform.position;
                Vector3 end = GameObject.Find("Ridge" + (i + 1)).transform.GetChild(pubvar.ball - 1).transform.position;

                Vector3 mid = (end - start) / tiled;
                for (int j = 1; j <= tiled; j++)
                {
                    GameObject oh = new GameObject();
                    oh.transform.parent = L1.transform;
                    oh.transform.position = start + mid * j;


                }
            }
            else
            {
                GameObject L1 = new GameObject();

                L1.name = ("rrrL" + i);
                Vector3 start = GameObject.Find("roofcurve" + i).transform.GetChild(1).transform.position;
                Vector3 end = GameObject.Find("Ridge1").transform.GetChild(pubvar.ball - 1).transform.position;

                Vector3 mid = (end - start) / tiled;
                for (int j = 1; j <= tiled; j++)
                {
                    GameObject oh = new GameObject();
                    oh.transform.parent = L1.transform;
                    oh.transform.position = start + mid * j;


                }
            }




        }

    }


    public void deletepoint()
    {
      

        int angle = int.Parse(UI.stringToEdit);
        for (int i = 1; i <= angle; i++)
        {
            
                GameObject R = GameObject.Find("rrrR" + i);
                Destroy(R);
            
           
                GameObject L = GameObject.Find("rrrL" + i);
                Destroy(L);
            
        }
    }

    public void reset()
    {
       
        deletepoint();



        addpoint();
    }


}
