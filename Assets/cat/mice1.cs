using UnityEngine;
using System.Collections;

public class mice1 : MonoBehaviour
{
    public bool RemoveUnusedSegments = false;
    CurvySpline mSpline;
    SplineWalkerDistance Walker;

    

    // Use this for initialization
    void Start()
    {
        mSpline = GetComponent<CurvySpline>();
        Walker = GameObject.FindObjectOfType(typeof(SplineWalkerDistance)) as SplineWalkerDistance;
        //while (!mSpline.IsInitialized)
        //    yield return null;
    }

    // Update is called once per frame
    void Update()
    {
        // Add Control Point by mouseclick
        if (GetComponent<Renderer>())
        { 
        GetComponent<Renderer>().material.color = Color.green;
    }


    }



    
    float speed = 5.0f;
    public static float xx;
    public static float yy;
    public static float zz;

    public static string movenum;
    public static string movenumfa;

    /*
    void OnMouseOver()
    {
        //Vector3 yoho = GameObject  transform.GetChild(1).position - transform.GetChild(0).position;


        movenum = gameObject.name;
        movenumfa = gameObject.transform.parent.name.Substring(0,3);



        if (GetComponent<Renderer>())
        {
            GetComponent<Renderer>().material.color = Color.green;
        }

            if (Input.GetMouseButton(0))
            {//鼠标按着左键移动

                

              









                yy = Input.GetAxis("Mouse X") ;
                xx = Input.GetAxis("Mouse Y") ;

                //transform.Translate(mice1.yy , 0, 0);
                //transform.Translate(0, mice1.xx, 0);


               // Vector3 initial = new Vector3(GameObject.Find("Ridge1").transform.GetChild(pubvar.ball - 1).transform.position.x - GameObject.Find("Ridge1").transform.GetChild(0).transform.position.x, 0, GameObject.Find("Ridge1").transform.GetChild(pubvar.ball - 1).transform.position.z - GameObject.Find("Ridge1").transform.GetChild(0).transform.position.z);
                //Vector3 now = new Vector3(transform.position.x - GameObject.Find("Ridge1").transform.GetChild(0).transform.position.x, 0, transform.position.z - GameObject.Find("Ridge1").transform.GetChild(0).transform.position.z);

                //float leg = Vector3.Angle(initial, now);

                //transform.RotateAround(GameObject.Find("Ridge1").transform.GetChild(0).transform.position, Vector3.up, leg);
              
            }
            else
            {

                xx = 0;
                yy = 0;
                zz = 0;

            }


       


       
        if (Input.GetMouseButtonDown(1))
        {
            Vector3 p = Input.mousePosition;
            p.z = 10;
            p = Camera.main.ScreenToWorldPoint(p);


            pubvar.PUBnum = 0;
            print(pubvar.PUBnum+"~~~");
            Destroy(this.gameObject.GetComponent<mice1>());

            //mSpline.RefreshImmediately();

           



            //remove the oldest segment, if it's no longer used
            if (RemoveUnusedSegments)
            {
                var seg = mSpline.DistanceToSegment(Walker.Distance);
                if (seg != mSpline[0])
                {
                    Walker.Distance -= mSpline[0].Length;
                    mSpline.Delete(mSpline[0]);
                }
            }
        }



    }
    */
    /*
    void OnMouseEnter()
    {
        movenum = gameObject.name;
        movenumfa = gameObject.transform.parent.name.Substring(0, 3);

        if (GetComponent<Renderer>())
        { 
                GetComponent<Renderer>().material.color = Color.green;
        }

        if (Input.GetMouseButton(0))
        {

            yy = Input.GetAxis("Mouse X") ;
            xx = Input.GetAxis("Mouse Y") ;            
        }
        else
        {
            xx = 0;
            yy = 0;
            zz = 0;
        }
    }
    */

    void OnMouseDrag()
    {
       

        if (GetComponent<Renderer>())
        {
            GetComponent<Renderer>().material.color = Color.green;
        }

        if (Input.GetMouseButton(0))
        {

            

            movenum = gameObject.name;
            movenumfa = gameObject.transform.parent.name.Substring(0, 3);

            yy = Input.GetAxis("Mouse X");
            xx = Input.GetAxis("Mouse Y");
        }

        

        

   }
    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1))
        {
            pubvar.PUBnum = 0;
            Destroy(this.gameObject.GetComponent<mice1>());
        }
    }


    void OnMouseExit()
    {
        xx = 0;
        yy = 0;
        zz = 0;

        movenum = "0";
        movenumfa = "0";

        if (GetComponent<Renderer>())
        {
            GetComponent<Renderer>().material.color = Color.white;
        }


    }


    void OnMouseUp()
    {
        xx = 0;
        yy = 0;
        zz = 0;

        movenum = "0";
        movenumfa = "0";

        if (GetComponent<Renderer>())
        {
            GetComponent<Renderer>().material.color = Color.white;
        }


    }



    /*

     void OnMouseExit()
    {
        xx = 0;
        yy = 0;
        zz = 0;
        movenum = "0";
        movenumfa = "0";

        if (GetComponent<Renderer>())
        {
            GetComponent<Renderer>().material.color = Color.white;
        }

     
    }



   */








}
