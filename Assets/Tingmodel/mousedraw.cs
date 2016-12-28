using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class mousedraw : MonoBehaviour {

    public List<Vector3> vec3 = new List<Vector3>();
    public List<GameObject> trace = new List<GameObject>();

    bool redd = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
    
    {

        if(Input.GetMouseButton(0))
        {
            redd = false;
            
            Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 54.45f));
            GameObject ball  = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            ball.transform.position = pos;
            ball.layer = LayerMask.NameToLayer("smallcamera");

            trace.Add(ball);
            vec3.Add(pos);

            /*
            if (Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime)
            {
                redd = true;
            }
            */
        }

        if (Input.GetMouseButtonUp(0))
        {

           

            Vector3 v11 = vec3[0];
            Vector3 v22 = vec3[(vec3.Count - 1) / 2];
            Vector3 v33= vec3[vec3.Count - 1];

            if (Mathf.Abs(v11.x - v33.x) > 4)
            {

               



                Vector3 v1 = vec3[0];
                Vector3 v2 = vec3[(vec3.Count - 1) / 2];
                Vector3 v3 = vec3[vec3.Count - 1];



                Vector3 v4 = vec3[vec3.Count - 1];
                Vector3 v5 = vec3[vec3.Count - 1];
                Vector3 v6 = vec3[vec3.Count - 1];

                //Vector3 pos2 = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 54.45f));
                GameObject clone = Instantiate(Resources.Load("RidgeCc"), v1, Quaternion.identity) as GameObject;
                clone.transform.parent = transform;




                clone.transform.GetChild(0).GetChild(0).GetChild(0).GetChild(0).transform.position = v1;
                clone.transform.GetChild(0).GetChild(0).GetChild(0).GetChild(1).transform.position = v2;
                clone.transform.GetChild(0).GetChild(0).GetChild(0).GetChild(2).transform.position = v3;

                clone.transform.GetChild(0).GetChild(2).GetChild(0).transform.position = new Vector3( v1.x,v1.y+1f,v1.z);
                clone.transform.GetChild(0).GetChild(2).transform.position = new Vector3(v1.x, v1.y + 1f, v1.z);


                Vector3 tailvec = Vector3.Normalize(v3 - v1);
                 
                clone.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(0).transform.position = v4;
                clone.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(1).transform.position = v5 + tailvec;
                clone.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(2).transform.position = v6 + tailvec*2;


                if (Mathf.Abs(v11.x - transform.GetChild(0).transform.position.x) > 4)
                { 

                }
              


                clone.transform.GetChild(1).GetComponent<roofcontrol>().setnumberslidervalue();
                clone.transform.GetChild(0).GetChild(2).GetChild(0).GetComponent<uppoint>().selffix(clone.transform.GetChild(0).GetChild(2).GetChild(0).gameObject, clone.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<RidgeControl>());


                //clone.transform.GetChild(1).GetComponent<UIcontrol>().setnumberslidervalue();
                /*
                for (int i = 0; i < trace.Count; i++)
                {
                    Destroy(trace[i]);
                }
                */



                trace.Clear();
                vec3.Clear();

            }
            else
            {

                if (redd = true)
                {
                    Vector3 v1 = vec3[0];

                    Vector3 v3 = vec3[vec3.Count - 1];

                    //Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 54.45f));
                    GameObject clone = Instantiate(Resources.Load("CC"), v1, Quaternion.identity) as GameObject;
                    clone.transform.parent = transform;

                    clone.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(0).transform.position = v1;
                    clone.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(1).transform.position = v1 - new Vector3(0, 3, 0);
                    clone.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(2).transform.position = v1 - new Vector3(0, Mathf.Abs(v1.y - v3.y), 0) + new Vector3(0, 3, 0);
                    clone.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(3).transform.position = v1 - new Vector3(0, Mathf.Abs(v1.y - v3.y), 0);



                    clone.transform.GetChild(0).GetChild(1).GetChild(0).GetComponent<catline>().ResetCatmullRom();

                    /*
                    clone.transform.GetChild(1).GetComponent<UIcontrol>().setnumberslidervalue();

                    */

                    /*
                    for (int i = 0; i < trace.Count; i++)
                    {
                        Destroy(trace[i]);
                    }
                    */
                    


                    trace.Clear();
                    vec3.Clear();
                }
                else
                {
                    Vector3 v1 = vec3[0];

                    Vector3 v3 = vec3[vec3.Count - 1];

                    //Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 54.45f));
                    GameObject clone = Instantiate(Resources.Load("Pt"), v1, Quaternion.identity) as GameObject;

                    clone.transform.parent = transform;



                    clone.transform.GetChild(1).GetComponent<UIcontrol>().setnumberslidervalue();



                    //clone.transform.GetChild(9).GetComponent<PlatForm>().parareset(Mathf.Abs(v1.y - v3.y), v1,v3);

                    //clone.transform.GetChild(9).GetChild(0).GetChild(0).transform.position = new Vector3(clone.transform.GetChild(9).GetChild(0).GetChild(0).transform.position.x,(v1.y+v3.y)/2,clone.transform.GetChild(9).GetChild(0).GetChild(0).transform.position.z);
                    clone.transform.GetChild(9).GetChild(0).GetChild(0).transform.position = new Vector3(clone.transform.GetChild(9).GetChild(0).GetChild(0).transform.position.x, v3.y, clone.transform.GetChild(9).GetChild(0).GetChild(0).transform.position.z);


                    //clone.transform.GetChild(9).GetComponent<PlatForm>().parareset(10);

                    /*
                    for (int i = 0; i < trace.Count; i++)
                    {
                        Destroy(trace[i]);
                    }
                    */



                    trace.Clear();


                    vec3.Clear();

                }

            }
        }



        if (Input.GetMouseButton(1))
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 54.45f));
            GameObject ball = GameObject.CreatePrimitive(PrimitiveType.Sphere);

            ball.layer = LayerMask.NameToLayer("smallcamera");
            ball.GetComponent<Renderer>().material.color = Color.red;


            ball.transform.position = pos;

            trace.Add(ball);
            vec3.Add(pos);


        }

        if (Input.GetMouseButtonUp(1))
        {
            Vector3 v1 = vec3[0];

            Vector3 v3 = vec3[vec3.Count - 1];

            //Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 54.45f));
            GameObject clone = Instantiate(Resources.Load("Pt"), v1, Quaternion.identity) as GameObject;
            
            clone.transform.parent = transform;




            
            clone.transform.GetChild(1).GetComponent<UIcontrol>().setnumberslidervalue();

            //clone.transform.GetChild(3).GetComponent<PlatForm>().parareset(Mathf.Abs(v1.y - v3.y), v1,v3);
          



            print("fuck");
           // clone.transform.GetChild(9).GetChild(0).GetChild(0).transform.position = new Vector3(clone.transform.GetChild(9).GetChild(0).GetChild(0).transform.position.x, 0, clone.transform.GetChild(9).GetChild(0).GetChild(0).transform.position.z);

           
           clone.transform.GetChild(9).GetChild(0).GetChild(0).transform.position = new Vector3(clone.transform.GetChild(9).GetChild(0).GetChild(0).transform.position.x, v3.y , clone.transform.GetChild(9).GetChild(0).GetChild(0).transform.position.z);



           


            trace.Clear();
            
            
            vec3.Clear();




        }


        /*
        if (Input.GetMouseButtonUp(0))
        {
        }

        */

	}



  
  
}
