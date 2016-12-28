using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class circlecut1 : MonoBehaviour {

    public catline catline;

    public static float tiledlength = 0.5f;
    public List<Vector3> anchorpointlist = new List<Vector3>();
   
    // Use this for initialization
    void Start () {
        //cutpoint();
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    public void cutpoint()
    {
        catline cat = transform.GetComponent<catline>();

        Vector3 born = new Vector3(0, 0, 0);
        Vector3 mid = new Vector3(0, 0, 0);

        //float min = 1000;
       
        for (int k = 0; k < cat.innerPointList.Count; k++)
        {


            if (k == 0)
            {
                /*
                GameObject fi = GameObject.CreatePrimitive(PrimitiveType.Sphere);

                fi.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                //fi.transform.position = transform.GetChild(k).position;
                fi.transform.position = cat.innerPointList[k];
                //sloslopR[m, n] = GameObject.Find("roofcurvylineR" + i + "-" + m + "son").transform.GetChild(k).position;


                fi.GetComponent<MeshRenderer>().material.color = Color.yellow;
                fi.transform.parent = this.transform;
                */
                Vector3 fi = cat.innerPointList[k];
                
                anchorpointlist.Add(fi);



            }
            float min = 1000;
            Vector3 ori = cat.innerPointList[k];

            int h = k;

            for (int j = h; j < cat.innerPointList.Count; j++)
            {
                Vector3 dot = cat.innerPointList[j];
                Vector3 miid = (ori + dot) / 2;

                float iwant = Vector3.Distance(ori, dot);

                if (Mathf.Abs((iwant - tiledlength)) < min)
                {
                    min = Mathf.Abs((iwant - tiledlength));
                    born = dot;
                    mid = miid;
                    k = j;
                }
                else { break; }

            }

            //anchor point



            /*
            GameObject rtson1 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            rtson1.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            rtson1.transform.position = born;

            //sloslopR[m, n] = born;

            rtson1.GetComponent<MeshRenderer>().material.color = Color.yellow;
            rtson1.transform.parent = this.transform;
            */

            Vector3 rtson1 = born;

            anchorpointlist.Add(rtson1);




        }
        
    }

    public void reset()
    {

        /*
        for (int i = 0; i < anchorpointlist.Count; i++)
        {
            Destroy(anchorpointlist[i]);
           
           
        }
        */


        anchorpointlist.Clear();
        cutpoint();

    }

    public void kill()
    {


        /*
        for (int i = 0; i < anchorpointlist.Count; i++)
        {
            Destroy(anchorpointlist[i]);


        }

        */
        anchorpointlist.Clear();


    }




}
