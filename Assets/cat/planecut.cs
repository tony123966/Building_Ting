using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class planecut : MonoBehaviour
{

    public catline catline;

    public  float tiledlength = 0.5f;
    public List<GameObject> anchorpointlist = new List<GameObject>();

    int angle = int.Parse(UI.stringToEdit);

    public Plane pp;

    // Use this for initialization
    void Start()
    {
      
       int i= int.Parse(this.name.Substring(14, 1));

        if (i == angle)
        {


            pp.Set3Points(GameObject.Find("Ridge1").transform.GetChild(0).transform.position, GameObject.Find("Ridge" + i).transform.GetChild(2).transform.position, GameObject.Find("Ridge1").transform.GetChild(2).transform.position);
           
        }

        else
        {




           pp.Set3Points(GameObject.Find("Ridge1").transform.GetChild(0).transform.position, GameObject.Find("Ridge" + i).transform.GetChild(2).transform.position, GameObject.Find("Ridge" + (i + 1)).transform.GetChild(2).transform.position);
          
         
        }




        cutpoint();
      

    }

    // Update is called once per frame
    void Update()
    {

    }


    void cutpoint()
    {
        /*
        plane p = GameObject.Find("Main Camera").GetComponent<plane>();

        print(p.planenumbers[0]);


        Plane pp = p.planenumbers[(int.Parse(this.name.Substring(14, 1)))-1];
        
        */

        catline cat = transform.GetComponent<catline>();

        Vector3 born = new Vector3(0, 0, 0);
        Vector3 mid = new Vector3(0, 0, 0);

        //float min = 1000;

        for (int k = 0; k < cat.innerPointList.Count; k++)
        {


            if (k == 0)
            {

                GameObject fi = GameObject.CreatePrimitive(PrimitiveType.Sphere);

                fi.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                //fi.transform.position = transform.GetChild(k).position;
                fi.transform.position = cat.innerPointList[k];
                //sloslopR[m, n] = GameObject.Find("roofcurvylineR" + i + "-" + m + "son").transform.GetChild(k).position;


                fi.GetComponent<MeshRenderer>().material.color = Color.yellow;
                fi.transform.parent = this.transform;

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

                if (Mathf.Abs((Vector3.Magnitude(Vector3.ProjectOnPlane((dot - ori), pp.normal))) - tiledlength) < min)
                {
                    min = Mathf.Abs((Vector3.Magnitude(Vector3.ProjectOnPlane((dot - ori), pp.normal))) - tiledlength);
                    born = dot;
                    mid = miid;
                    k = j;
                }
                else { break; }

            }

            //anchor point

            GameObject rtson1 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            rtson1.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            rtson1.transform.position = born;

            //sloslopR[m, n] = born;

            rtson1.GetComponent<MeshRenderer>().material.color = Color.yellow;
            rtson1.transform.parent = this.transform;

            anchorpointlist.Add(rtson1);




        }

    }

    public void reset()
    {


        for (int i = 0; i < anchorpointlist.Count; i++)
        {
            Destroy(anchorpointlist[i]);


        }
        anchorpointlist.Clear();
        cutpoint();

    }



}
