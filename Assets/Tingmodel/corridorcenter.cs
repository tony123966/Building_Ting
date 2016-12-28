using UnityEngine;
using System.Collections;

public class corridorcenter : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = (transform.parent.GetChild(0).GetChild(10).transform.position + transform.parent.GetChild(1).GetChild(10).transform.position) / 2;
	}
}
