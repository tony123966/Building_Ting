using UnityEngine;
using System.Collections;

public class lookyou : MonoBehaviour
{
    public Transform Target;

    public Camera MainCamera;
    public GameObject MainPerson;
    private int RotationSpeed;
    private int ScaleSpeed;
    private int MouseLeftKey = 0;
    private int MouseRightKey = 1;
    private float MinFieldOfView = 30f;
    private float MaxFieldOfView = 80f;

    Transform mTransform;

    // Use this for initialization
    void Start()
    {
        mTransform = transform;

        RotationSpeed = 50;
        ScaleSpeed = 2;
        //將主攝影機看向主要角色的位置
        MainCamera.transform.LookAt(MainPerson.transform.position);


    }


    void LateUpdate()
    {
        if (Target)
            mTransform.LookAt(Target);
        
    }


    void ScaleByMouseCenter()
    {
        //Input.GetAxis("Mouse ScrollWheel") < 0 表示滾輪向前滾動
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            //CurrentFieldOfView 設定為相機的視角
            float CurrentFieldOfView = MainCamera.fieldOfView;
            CurrentFieldOfView += ScaleSpeed;

            //如果CurrentFieldOfView大於最大視角則設定為最大視角
            if (CurrentFieldOfView > MaxFieldOfView)
                MainCamera.fieldOfView = MaxFieldOfView;
            else
                MainCamera.fieldOfView = CurrentFieldOfView;
        }

        //Input.GetAxis("Mouse ScrollWheel") > 0 表示滾輪向後滾動
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            float CurrentFieldOfView = MainCamera.fieldOfView;
            CurrentFieldOfView -= ScaleSpeed;
            if (CurrentFieldOfView < MinFieldOfView)
                MainCamera.fieldOfView = MinFieldOfView;
            else
                MainCamera.fieldOfView = CurrentFieldOfView;
        }
    }

    float speed = 100.0f;
    float x;
    float y;
    float z;



    void OnMouseExit()
    {
       

        if (Input.GetMouseButton(0))
        {//鼠标按着左键移动
            y = Input.GetAxis("Mouse X") * Time.deltaTime * speed;
            x = Input.GetAxis("Mouse Y") * Time.deltaTime * speed;
            transform.Translate(y, 0, 0);
            transform.Translate(0, x, 0);
        }
        else
        {

            x = 0;
            y = 0;
            z = 0;

        }



    }
}
