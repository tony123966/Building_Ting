using UnityEngine;
using System.Collections;

public class ridgetailmove : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {


        if (mice1.movenum == ("CP00"+(pubvar.ball-1)))
        {

            transform.Translate(mice1.yy, 0, 0);
            //transform.Translate(0, mice1.xx, 0);


            //transform.position = GameObject.Find(mice1.movenum).transform.position;



            Vector3 initial = new Vector3(GameObject.Find("Ridge1").transform.GetChild(pubvar.ball - 1).transform.position.x - GameObject.Find("Ridge1").transform.GetChild(0).transform.position.x, 0, GameObject.Find("Ridge1").transform.GetChild(pubvar.ball - 1).transform.position.z - GameObject.Find("Ridge1").transform.GetChild(0).transform.position.z);


            Vector3 now = new Vector3(transform.position.x - GameObject.Find("Ridge1").transform.GetChild(0).transform.position.x, 0, transform.position.z - GameObject.Find("Ridge1").transform.GetChild(0).transform.position.z);

            float leg = Vector3.Angle(initial, now);



            //transform.RotateAround(GameObject.Find("Ridge1").transform.GetChild(0).transform.position, Vector3.up, leg);
        }

	}
}
