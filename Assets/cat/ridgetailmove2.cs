using UnityEngine;
using System.Collections;

public class ridgetailmove2 : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (mice1.movenum == ("CP00" + (pubvar.ball - 1)))
        {




            transform.Translate(mice1.yy, 0, 0);
            //transform.RotateAround(GameObject.Find("Ridge1").transform.GetChild(0).transform.position, Vector3.up, 90);
            //transform.Translate(0, mice1.xx, 0);


           
        }
	}
}
