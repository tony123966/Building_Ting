using UnityEngine;
using System.Collections;

public class roofsurface : MonoBehaviour
{

    public Plane p;

    public catline catline;

    

    //public Vector3 vect = Vector3.Normalize(GameObject.Find("roofcurve1").transform.GetChild(2).transform.position - GameObject.Find("roofcurve1").transform.GetChild(0).transform.position);
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (gameObject.name == mice1.movenum && gameObject.transform.parent.name.Substring(0, 3) == mice1.movenumfa)
        {





            if (Input.GetMouseButton(0))
            {
                


                if(transform.parent.name=="roofcurve1")
                {
                    roofsurfacecontrol rf = GameObject.Find("Main Camera").GetComponent<roofsurfacecontrol>();
                    rf.reset();
                }

                

                if (transform.parent.GetComponent<catline>())
                {
                    catline cat = transform.parent.GetComponent<catline>();
                    cat.ResetCatmullRom();
                }
                if (transform.parent.GetComponent<circlecut1>())
                {
                    circlecut1 cir = transform.parent.GetComponent<circlecut1>();
                    cir.reset();
                }
                if (transform.parent.GetComponent<planecut>())
                {
                    planecut pla = transform.parent.GetComponent<planecut>();
                    pla.reset();
                }




                if (transform.parent.GetComponent<newtiled>())
                {
                    newtiled tie = transform.parent.GetComponent<newtiled>();
                    tie.reset();
                }
                if (transform.parent.GetComponent<newtiledL>())
                {
                    newtiledL tie = transform.parent.GetComponent<newtiledL>();
                    tie.reset();
                }


            
            
            }
            if (gameObject.transform.parent.name.Substring(0, 9) == "roofcurve")
            {
                Vector3 vect = Vector3.Normalize(GameObject.Find("roofcurve1").transform.GetChild(2).transform.position - GameObject.Find("roofcurve1").transform.GetChild(0).transform.position);
                transform.Translate(mice1.yy * vect.x, 0, mice1.yy * vect.z);
                transform.Translate(0, mice1.xx, 0);
            }
            else
            {
                
                

                Vector3 vect = Vector3.Normalize(transform.parent.GetChild(2).transform.position - transform.parent.GetChild(0).transform.position);
                //Vector3 vect2 = Vector3.Normalize(GameObject.Find("roofcurve" + int.Parse(gameObject.transform.parent.name.Substring(14, 1))).transform.GetChild(2).transform.position - GameObject.Find("roofcurve" + int.Parse(gameObject.transform.parent.name.Substring(14, 1))).transform.GetChild(0).transform.position);
                
                //float vv = vect.magnitude/vect2.magnitude;

                /*
                transform.Translate(mice1.yy * vect.x, 0, mice1.yy * vect.z);
                transform.Translate(0, mice1.xx, 0);
                */
                

                if (transform.parent.name.Substring(13, 1) == "R")
                {
                    /*
                    print(transform.parent.name.Substring(16, 1));
                    print("rrrR"+int.Parse(transform.parent.name.Substring(14, 1)));
                    */
                    transform.position = GameObject.Find("rrrR"+int.Parse(transform.parent.name.Substring(14, 1))).transform.GetChild((int.Parse(transform.parent.name.Substring(16, 1))) - 1).transform.position;
                }
                if (transform.parent.name.Substring(13, 1) == "L")
                {
                    transform.position = GameObject.Find("rrrL" + int.Parse(transform.parent.name.Substring(14, 1))).transform.GetChild((int.Parse(transform.parent.name.Substring(16, 1))) - 1).transform.position;
                }
                
                /*
                p.Set3Points(transform.parent.GetChild(0).transform.position, transform.parent.GetChild(1).transform.position, transform.parent.GetChild(2).transform.position);
                Vector3 line = (GameObject.Find("Ridge" + int.Parse(gameObject.transform.parent.name.Substring(9, 1))).transform.GetChild(1).transform.position) - (GameObject.Find("roofcurve" + int.Parse(gameObject.transform.parent.name.Substring(9, 1))).transform.GetChild(2).transform.position);
                
                
                p.Set3Points(transform.parent.GetChild(0).transform.position, transform.parent.GetChild(1).transform.position, transform.parent.GetChild(2).transform.position);
                if (gameObject.transform.parent.name.Substring(13, 1) == "R")
                {
                    
                    Vector3 line = (GameObject.Find("Ridge" + int.Parse(gameObject.transform.parent.name.Substring(9, 1))).transform.GetChild(1).transform.position) - (GameObject.Find("roofcurve" + int.Parse(gameObject.transform.parent.name.Substring(9, 1))).transform.GetChild(2).transform.position);
                
                }
                else
                {



                }
                 */


            }

        }

    }

    void lineintersection()
    {




        
    }



    void OnMouseDrag()
    {

       
    }

}
