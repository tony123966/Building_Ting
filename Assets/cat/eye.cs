using UnityEngine;
using System.Collections;

public class eye : MonoBehaviour {

    public Transform target;
    public float x;
    public float y;
    public float xSpeed = 100;
    public float ySpeed = 100;
    public float distance;
    public float disSpeed = 500;
    public float minDistance = 10;
    public float maxDistance = 45;

    

    private Quaternion rotationEuler;
    private Vector3 cameraPosition;


    Transform mTransform;

    // Use this for initialization
    void Start () {
        mTransform = transform;

    }
	
	// Update is called once per frame
	void Update () {
	
	}







    void LateUpdate()
    {
        if (target)
            mTransform.LookAt(target);



        if (Input.GetMouseButton(0) && mouseevent.myname ==("0")  )
        { 
        x += Input.GetAxis("Mouse X") * xSpeed * Time.deltaTime;
        y -= Input.GetAxis("Mouse Y") * ySpeed * Time.deltaTime;
    }
         

            distance -= Input.GetAxis("Mouse ScrollWheel") * disSpeed * Time.deltaTime;

            distance = Mathf.Clamp(distance, minDistance, maxDistance);

            rotationEuler = Quaternion.Euler(y, x, 0);
            cameraPosition = rotationEuler * new Vector3(0, 0, -distance) + target.position;

            transform.rotation = rotationEuler;
            transform.position = cameraPosition;

     

    }
}
