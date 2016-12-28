using UnityEngine;
using System.Collections;

public class Zevent : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseOver()
    {
        if (GetComponent<Renderer>())
        {
            GetComponent<Renderer>().material.color = Color.yellow;
        }
    }
    void OnMouseExit()
    {
        if (GetComponent<Renderer>())
        {
            GetComponent<Renderer>().material.color = Color.white;
        }
    }
    void OnMouseDown()
    {
        
        if (pubvar.PUBnum == 0)
        {
            this.gameObject.AddComponent<mice1>().enabled = true;
            pubvar.PUBnum++;
        }
    }
}
