﻿using UnityEngine;
using System.Collections;

public class LRcolumnbottom : MonoBehaviour {
    public RidgeControl ridgecontrol;
    public ColumnControl columncontrol;
    public EaveControl eavecontrol;
    public roofsurcontrol roofcontrol;
    public roofsurcon2control roofcontrol2;
    public roofsurcontrol2 roofcontrolS;
    public RidgetailControl rtc;

    public BC bc;
    public FC fc;

    public PlatForm pt;

    float speed = 2.0f;
    float x;
    float y;
    float z;
    // Use this for initialization




    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDrag()
    {
        Vector3 vector = this.transform.parent.parent.parent.GetChild(0).GetChild(0).GetChild(0).transform.position - this.transform.parent.parent.parent.GetChild(0).GetChild(0).GetChild(2).transform.position;


        if (Input.GetMouseButton(0))
        {//鼠标按着左键移动
            y = Input.GetAxis("Mouse X") * Time.deltaTime * speed;
            x = Input.GetAxis("Mouse Y") * Time.deltaTime * speed;

            transform.parent.parent.parent.GetChild(0).GetChild(0).GetChild(2).Translate(y * -vector.x, 0, y * -vector.z);
            transform.parent.Translate(y * -vector.x, 0, y * -vector.z);
       
            if (rtc)
            {
                rtc.ridgetailmanage[0].transform.Translate(y * -vector.x, 0, y * -vector.z);
            }
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
        if(transform.parent.parent.parent.GetChild(0).GetChild(0).GetComponent<RidgeControl>())
        {
        this.transform.parent.parent.parent.GetChild(0).GetChild(0).GetComponent<RidgeControl>().ridgemanage[0].GetComponent<catline>().ResetCatmullRom();
        }
            this.transform.parent.GetComponent<ColumnControl>().columnmanage[0].GetComponent<catline>().ResetCatmullRom();

        columncontrol.reset();

        if (ridgecontrol)
        {
            ridgecontrol.reset();
            eavecontrol.reset();

            roofcontrol.withoutinireset();

            roofcontrol2.reset();
            roofcontrolS.reset();
        }
        bc.reset();
        fc.reset();

        if (pt)
        {
            pt.reset();
        }
        if (rtc)
        {
            rtc.reset();
        }
    }
}