using UnityEngine;
using System.Collections;

public class Pcibp : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        int i = int.Parse(gameObject.name.Substring(5, 1));

        Vector3 vect = Vector3.Normalize(GameObject.Find("Ridge" + i).transform.GetChild(1).transform.position - GameObject.Find("Ridge" + i).transform.GetChild(0).transform.position);


        if (mice1.movenum == ("003 (1)"))
        {



            transform.Translate(mice1.yy * vect.x, 0, mice1.yy * vect.z);
            //transform.Translate(0, mice1.xx, 0);


            //transform.position = GameObject.Find(mice1.movenum).transform.position;




        }
	}
}
