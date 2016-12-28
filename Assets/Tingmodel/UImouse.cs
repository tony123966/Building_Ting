using UnityEngine;
using System.Collections;

public class UImouse : MonoBehaviour {



    public UIcontrol uic;


    public GameObject rf;



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {





        if(Input.GetMouseButton(1))
        {

            //Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 40));
            Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 54.45f));
            GameObject clone = Instantiate(Resources.Load("CC"), pos, Quaternion.identity) as GameObject;
            clone.transform.parent = GameObject.Find("build").transform;
            clone.transform.GetChild(1).GetComponent<UIcontrol>().setnumberslidervalue();



        }

        if (Input.GetKeyDown(KeyCode.A))
        {

            Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 54.45f));
            GameObject clone = Instantiate(Resources.Load("RidgeC"), pos, Quaternion.identity) as GameObject;
            clone.transform.parent = GameObject.Find("build").transform;
            clone.transform.GetChild(1).GetComponent<UIcontrol>().setnumberslidervalue();



        }

        if (Input.GetKeyDown(KeyCode.S))
        {

            Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 54.45f));
            GameObject clone = Instantiate(Resources.Load("Pt"), pos, Quaternion.identity) as GameObject;
            clone.transform.parent = GameObject.Find("build").transform;
            clone.transform.GetChild(1).GetComponent<UIcontrol>().setnumberslidervalue();



        }



        if (Input.GetKeyDown(KeyCode.D))
        {


            Vector3 v1 = rf.transform.GetChild(0).GetChild(0).GetChild(0).transform.position;
            Vector3 v2 = rf.transform.GetChild(0).GetChild(0).GetChild(1).transform.position;
            Vector3 v3 = rf.transform.GetChild(0).GetChild(0).GetChild(2).transform.position;

            v1.y = v1.y + 10;
            v2.y = v2.y + 10;
            v3.y = v3.y + 10;

            GameObject clone = Instantiate(Resources.Load("RidgeCc"), v1, Quaternion.identity) as GameObject;

            clone.transform.GetComponent<roofcontrol>().center = rf.transform.GetChild(0).GetChild(0).GetChild(0).gameObject;
            
            clone.transform.parent = transform;




            clone.transform.GetChild(0).GetChild(0).GetChild(0).GetChild(0).transform.position = v1;
            clone.transform.GetChild(0).GetChild(0).GetChild(0).GetChild(1).transform.position = v2;
            clone.transform.GetChild(0).GetChild(0).GetChild(0).GetChild(2).transform.position = v3;

            clone.transform.GetChild(0).GetChild(2).GetChild(0).transform.position = new Vector3(v1.x, v1.y + 1f, v1.z);
            clone.transform.GetChild(0).GetChild(2).transform.position = new Vector3(v1.x, v1.y + 1f, v1.z);


            Vector3 tailvec = Vector3.Normalize(v3 - v1);
            /*
            clone.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(0).transform.position = v4;
            clone.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(1).transform.position = v5 + tailvec;
            clone.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(2).transform.position = v6 + tailvec * 2;


            */


            clone.transform.GetChild(1).GetComponent<roofcontrol>().setnumberslidervalue();
            clone.transform.GetChild(0).GetChild(2).GetChild(0).GetComponent<uppoint>().selffix(clone.transform.GetChild(0).GetChild(2).GetChild(0).gameObject, clone.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<RidgeControl>());


            //clone.transform.GetChild(1).GetComponent<UIcontrol>().setnumberslidervalue();
            /*
            for (int i = 0; i < trace.Count; i++)
            {
                Destroy(trace[i]);
            }
            */










        }






	}
    


}
