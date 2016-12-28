using UnityEngine;
using System.Collections;

public class corridorcontrol : MonoBehaviour {


    public float longlong;
    public corridorZmove zz;


	// Use this for initialization
	void Start () {
   
	}
	
	// Update is called once per frame
	void Update () {
	     
	}



    public void updatelong()
    {


        longlong = Vector3.Distance(transform.GetChild(0).GetChild(11).transform.position, transform.GetChild(1).GetChild(11).transform.position);
        print(longlong);

    }
}
