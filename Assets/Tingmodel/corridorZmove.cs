using UnityEngine;
using System.Collections;

public class corridorZmove : MonoBehaviour {

    float speed = 20.0f;
    float x;
    float y;
    float z;
    // Use this for initialization

    public UIcontrol ucit;
    public corridorcontrol CC;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDrag()
    {
        


        if (Input.GetMouseButton(0))
        {//鼠标按着左键移动
            y = Input.GetAxis("Mouse X") * Time.deltaTime * speed;
            x = Input.GetAxis("Mouse Y") * Time.deltaTime * speed;

            //transform.Translate(0, x*5, 0);
            transform.parent.Translate(0, 0, y );
           
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
        
        transform.parent.GetChild(0).GetChild(0).GetChild(0).GetComponent<RidgeControl>().ridgemanage[0].GetComponent<catline>().ResetCatmullRom();
        transform.parent.GetChild(0).GetChild(1).GetChild(0).GetComponent<ColumnControl>().columnmanage[0].GetComponent<catline>().ResetCatmullRom();
        transform.parent.parent.GetChild(3).GetComponent<catline>().ResetCatmullRom();
        transform.parent.parent.GetChild(3).GetComponent<circlecut1>().reset();
        CC.updatelong();
        ucit.setnumberslidervalue();
        /*
        print("haha");
        CC.updatelong();
       */
    }


    public void change(float a)
    {
        
        transform.parent.Translate(0, 0, a);
        /*
        transform.parent.GetChild(0).GetChild(0).GetChild(0).GetComponent<RidgeControl>().ridgemanage[0].GetComponent<catline>().ResetCatmullRom();
        transform.parent.GetChild(0).GetChild(1).GetChild(0).GetComponent<ColumnControl>().columnmanage[0].GetComponent<catline>().ResetCatmullRom();
        transform.parent.parent.GetChild(3).GetComponent<catline>().ResetCatmullRom();
        transform.parent.parent.GetChild(3).GetComponent<circlecut1>().reset();

        ucit.setnumberslidervalue();
        */

        OnMouseUp();
        CC.updatelong();
    }




}
