using UnityEngine;
using System.Collections;

public class clicktoborn : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnMouseDown()
    {
        print("wuwuwuwu");



        //GetComponent<Renderer>().material.color = Color.blue;
        GameObject haha = GameObject.CreatePrimitive(PrimitiveType.Cylinder);

        //haha.transform.position = this.gameObject.transform.position - 2*this.gameObject.transform.up;


        haha.transform.localScale = new Vector3(1, 11, 1);


        haha.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y-11 , this.gameObject.transform.position.z );
        
        //haha.AddComponent<moveA>().enabled = true;

        haha.AddComponent<color>().enabled = true;


    }
}
