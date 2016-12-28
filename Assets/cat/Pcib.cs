using UnityEngine;
using System.Collections;

public class Pcib : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
    {

        if (mice1.movenum == ("003 (1)"))
        {
            


            transform.Translate(mice1.yy, 0,0);
            //transform.Translate(0, mice1.xx, 0);


            //transform.position = GameObject.Find(mice1.movenum).transform.position;



           
        }
	}
}
