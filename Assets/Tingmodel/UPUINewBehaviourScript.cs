using UnityEngine;
using System.Collections;

public class UPUINewBehaviourScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	


        for(int i = 0; i< transform.GetChildCount() ; i++)
        {

            transform.GetChild(i).gameObject.AddComponent<mouseeventR>();

        }

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
