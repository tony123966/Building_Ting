using UnityEngine;
using System.Collections;

public class LRmove : MonoBehaviour {
    public RidgeControl ridgecontrol;
    public ColumnControl columncontrol;
    public EaveControl eavecontrol;
    public roofsurcontrol roofcontrol;
    public roofsurcon2control roofcontrol2;
    public roofsurcontrol2 roofcontrolS;
    public RidgetailControl rtc;



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
        Vector3 vector = this.transform.parent.GetChild(0).transform.position - this.transform.parent.GetChild(2).transform.position;


        if (Input.GetMouseButton(0))
        {//鼠标按着左键移动
            y = Input.GetAxis("Mouse X") * Time.deltaTime * speed;
            x = Input.GetAxis("Mouse Y") * Time.deltaTime * speed;
         
            //transform.Translate(0, x*5, 0);
            transform.Translate(y * -vector.x, 0, y * -vector.z);
            rtc.ridgetailmanage[0].transform.Translate(y * -vector.x, 0, y * -vector.z);
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

        this.transform.parent.GetComponent<RidgeControl>().ridgemanage[0].GetComponent<catline>().ResetCatmullRom();

        ridgecontrol.reset();
        eavecontrol.reset();

        roofcontrol.reset();

        roofcontrol2.reset();
        roofcontrolS.reset();
        rtc.reset();


    }
}
