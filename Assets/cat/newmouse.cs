using UnityEngine;
using System.Collections;

public class newmouse : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    float speed = 0.05f;
   float x;
    float y;
    float z;
	// Update is called once per frame
	void Update () {


	}




    void OnMouseDrag()
    {
        if (Input.GetMouseButton(0))
        {
            x = Input.GetAxis("Mouse X");
            y = Input.GetAxis("Mouse Y");
            //z = Input.GetAxis("Mouse Z");

            transform.Translate(x, y, z);

        }

    }
}
