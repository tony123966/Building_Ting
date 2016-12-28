using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraToCenter : MonoBehaviour
{
    private Camera uICamera;
    public GameObject constraintArea;

    public GameObject target;//the target object
    public float dragSpeedMod = 10.0f;//a speed modifier
    public float roomInSpeedMod = 20.0f;//a speed modifier

    public bool clampXY = false;
    public float minDistance = 5.0f;
    public float maxDistance = 300.0f;


    private Vector3 targetPoint;//the coord to the point where the camera looks at
    private float x = 0;
    private float y = 0;
    private int isClamp = 0;
    private bool isRotating = false;
    private Bounds bounds;
    private int lastSize = 0;
    public float distanceToTarget;
    void Start()
    {//Set up things on the start method
        uICamera = GameObject.Find("UICamera").GetComponent<Camera>();
        bounds = NGUIMath.CalculateAbsoluteWidgetBounds(constraintArea.transform);
        targetPoint = target.transform.position;//get target's coords
        transform.LookAt(targetPoint);//makes the camera look to it
        distanceToTarget = Vector3.Distance(targetPoint, transform.position);
    }
    public void ChangeCenter2TargetObject(Vector3 focusNewPos, float disOffset, int size)
    {
        //未移動前距離	
        float lastDistanceToTarget = Vector3.Distance(targetPoint, transform.position);
        //移動目標點
        targetPoint += focusNewPos * (size - lastSize);
        distanceToTarget = Vector3.Distance(targetPoint, transform.position);
        //因移動目標點造成的距離偏移
        float offsetDistance = distanceToTarget - lastDistanceToTarget;
        //移動鏡頭
        lastDistanceToTarget = Vector3.Distance(targetPoint, transform.position);
        transform.position -= (transform.forward * disOffset) * (size - lastSize);
        transform.LookAt(targetPoint);
        distanceToTarget = Vector3.Distance(targetPoint, transform.position);
        //改變最大距離
        maxDistance = maxDistance + ((distanceToTarget - lastDistanceToTarget) + offsetDistance);
        lastSize = size;
    }
    void Update()
    {//makes the camera rotate around "point" coords, rotating around its Y axis, 20 degrees per second times the speed modifier
        Vector2 mousePos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 mousePos2World = uICamera.ScreenToWorldPoint(mousePos);
        if (bounds.Contains(mousePos2World))
        {
            if (Input.GetMouseButtonDown(0) && !isRotating) isRotating = true;

            if (Input.GetAxisRaw("Mouse ScrollWheel") != 0)
            {
                distanceToTarget = Vector3.Distance(targetPoint, transform.position);
                float desiredDistance = distanceToTarget;
                float offset = (-Mathf.Sign(Input.GetAxisRaw("Mouse ScrollWheel")) * roomInSpeedMod * Time.smoothDeltaTime);
                desiredDistance += offset;
                desiredDistance = Mathf.Clamp(desiredDistance, minDistance, maxDistance);

                transform.position = targetPoint - (transform.forward * desiredDistance);

            }
        }
        if (isRotating)
        {
            if (clampXY)
            {
                if (Mathf.Abs(Input.GetAxis("Mouse X")) > Mathf.Abs(Input.GetAxis("Mouse Y")) && isClamp != -1)
                {
                    isClamp = 1;
                    x += Input.GetAxis("Mouse X") * dragSpeedMod * Time.smoothDeltaTime;

                    transform.RotateAround(targetPoint, target.transform.up, x);

                }
                else if (Mathf.Abs(Input.GetAxis("Mouse X")) < Mathf.Abs(Input.GetAxis("Mouse Y")) && isClamp != 1)
                {
                    isClamp = -1;

                    y += Input.GetAxis("Mouse Y") * dragSpeedMod * Time.smoothDeltaTime;
                    transform.RotateAround(targetPoint, -transform.right, y);
                }
            }
            else
            {
                x += Input.GetAxis("Mouse X") * dragSpeedMod * Time.smoothDeltaTime;
                y += Input.GetAxis("Mouse Y") * dragSpeedMod * Time.smoothDeltaTime;
                transform.RotateAround(targetPoint, target.transform.up, x);
                transform.RotateAround(targetPoint, -transform.right, y);
            }

        }
        if (Input.GetMouseButtonUp(0))
        {
            x = 0; y = 0;
            isClamp = 0;
            isRotating = false;
        }
    }
}