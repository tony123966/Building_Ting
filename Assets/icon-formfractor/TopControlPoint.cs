using UnityEngine;
using System.Collections;

public class TopControlPoint : MonoBehaviour {

    public GameObject meshreset;



    public GameObject ControlPoint11;


    // Use this for initialization
    void Start()
    {
        //ControlPoint2 = GameObject.Find("RidgeCc(Clone)").transform.GetChild(0).GetChild(0).GetChild(0).GetChild(1).gameObject;

        print("+ + +" + meshreset.transform.name);

        ControlPoint11 = meshreset.transform.GetComponent<rooficon>().ControlPoint1;
    }

    // Update is called once per frame
    void Update()
    {
        ControlPoint11 = meshreset.transform.GetComponent<rooficon>().ControlPoint1;
    }



    float speed = 2.0f;
    float x;
    float y;
    float z;

    void OnMouseDrag()
    {







        if (Input.GetMouseButton(0))
        {//鼠标按着左键移动
            //y = Input.GetAxis("Mouse X") * Time.deltaTime * speed;
            x = Input.GetAxis("Mouse Y") * Time.deltaTime * speed;
            transform.Translate(0, x, 0);
            transform.parent.parent.GetChild(1).GetChild(0).transform.Translate(0, x, 0);

            //transform.parent.parent.GetChild(1).GetChild(1).transform.Translate(-y, 0, 0);

            //transform.Translate(0, x, 0);
            //transform.Translate(y, 0, 0);

            //連結


            ControlPoint11.transform.Translate(0, x, 0);
            //ControlPoint22.transform.Translate(y, 0, 0);





            meshreset.GetComponent<rooficon>().reset();
        }
        else
        {

            x = 0;
            y = 0;
            z = 0;

        }


    }


    void OnMouseUp()
    {



        ControlPoint11.GetComponent<topmove>().reset();

        meshreset.GetComponent<rooficon>().reset();



    }
}
