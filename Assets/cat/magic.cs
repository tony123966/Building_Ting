using UnityEngine;
using System.Collections;

public class magic : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        int angle = int.Parse(UI.stringToEdit);
        for (int i = 1; i <= angle; i++)
        {


            if (GameObject.Find("roofcurve" + i) && GameObject.Find("roofsurfaceM1"))
            {
                SplinePathCloneBuilder yoho = GameObject.Find("roofsurfaceM" + i).GetComponent<SplinePathCloneBuilder>();

                yoho.Spline = GameObject.Find("roofcurve" + i).GetComponent<CurvySpline>();
            }




        }
	}
}
