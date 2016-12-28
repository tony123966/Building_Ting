using UnityEngine;
using System.Collections;

public class eavecontrolpoint : MonoBehaviour {

	// Use this for initialization

    float speed = 1.0f;
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
        Vector3 vector = this.transform.parent.GetChild(6).transform.position - this.transform.parent.GetChild(0).transform.position;


        if (Input.GetMouseButton(0))
        {//鼠标按着左键移动
            y = Input.GetAxis("Mouse X") * Time.deltaTime * speed;
            x = Input.GetAxis("Mouse Y") * Time.deltaTime * speed;

            transform.parent.GetChild(1).transform.Translate(0, x * 5, 0);
            transform.parent.GetChild(3).transform.Translate(0, x * 5, 0);
            transform.parent.GetChild(4).transform.Translate(0, x * 5, 0);
            transform.parent.GetChild(5).transform.Translate(0, x * 5, 0);
            transform.Translate(0, x * 5, 0);
            //transform.Translate(0, x, 0);
            transform.Translate(y * -vector.x, 0, y * -vector.z);
            transform.parent.GetChild(1).transform.Translate(y * -vector.x, 0, y * -vector.z);
            transform.parent.GetChild(4).transform.Translate(y * vector.x, 0, y * vector.z);
            transform.parent.GetChild(5).transform.Translate(y * vector.x, 0, y * vector.z);
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

        this.transform.parent.parent.GetComponent<EaveControl>().r3p = this.transform.position;
        this.transform.parent.parent.GetComponent<EaveControl>().r2p = this.transform.parent.GetChild(1).position;
        this.transform.parent.parent.GetComponent<EaveControl>().r4p = this.transform.parent.GetChild(3).position;
        this.transform.parent.parent.GetComponent<EaveControl>().r5p = this.transform.parent.GetChild(4).position;
        this.transform.parent.parent.GetComponent<EaveControl>().r6p = this.transform.parent.GetChild(5).position;






        this.transform.parent.parent.GetComponent<EaveControl>().eavemanage[0].GetComponent<catline>().ResetCatmullRom();
        this.transform.parent.parent.GetComponent<EaveControl>().withoutinireset();



        transform.parent.parent.parent.GetChild(2).GetComponent<roofsurcontrol>().withoutinireset();
        transform.parent.parent.parent.GetChild(3).GetComponent<roofsurcon2control>().reset();
        transform.parent.parent.parent.GetChild(4).GetComponent<roofsurcontrol2>().reset();





        /*
        roofcontrol.reset();
        roofcontrol2.reset();
        roofcontrolS.reset();
        */


    }
}
