using UnityEngine;
using System.Collections;

public class Lookyou : MonoBehaviour {
    public Transform Target;

    Transform mTransform;

	// Use this for initialization
	void Start () {
        mTransform = transform;
	}
	
	
	void LateUpdate () {
        if (Target)
            mTransform.LookAt(Target);
        transform.Translate(Vector3.right * Time.deltaTime);
	}
}
