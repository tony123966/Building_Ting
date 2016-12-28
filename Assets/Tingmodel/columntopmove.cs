using UnityEngine;
using System.Collections;

public class columntopmove : MonoBehaviour {
    public RidgeControl ridgecontrol;
    public ColumnControl columncontrol;
    public EaveControl eavecontrol;
    public roofsurcontrol roofcontrol;
    public roofsurcon2control roofcontrol2;
    public roofsurcontrol2 roofcontrolS;
    public RidgetailControl rtc;

    public FC fc;



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



        if (Input.GetMouseButton(0))
        {//鼠标按着左键移动
            y = Input.GetAxis("Mouse X") * Time.deltaTime * speed;
            x = Input.GetAxis("Mouse Y") * Time.deltaTime * speed;
            transform.Translate(0, x * 5, 0);
            transform.parent.parent.parent.GetChild(0).transform.Translate(0, x * 5, 0);
            transform.parent.GetChild(1).transform.Translate(0, x * 5, 0);

            if (rtc)
            {
                rtc.ridgetailmanage[0].transform.Translate(0, x * 5, 0);
            }

            if (roofcontrol.roofsurfacemanage[0])
            {
                roofcontrol.roofsurfacemanage[0].transform.GetChild(1).transform.Translate(0, x * 5, 0);
            }
            if (eavecontrol)
            {
                eavecontrol.eavemanage[0].transform.Translate(0, x * 5, 0);
            }
            //transform.Translate(0, x, 0);


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
        

        eavecontrol.r2p = eavecontrol.eavemanage[0].transform.GetChild(1).transform.position;
        eavecontrol.r3p = eavecontrol.eavemanage[0].transform.GetChild(2).transform.position;
        eavecontrol.r4p = eavecontrol.eavemanage[0].transform.GetChild(3).transform.position;
        eavecontrol.r5p = eavecontrol.eavemanage[0].transform.GetChild(4).transform.position;
        eavecontrol.r6p = eavecontrol.eavemanage[0].transform.GetChild(5).transform.position;



        roofcontrol.r2p = roofcontrol.roofsurfacemanage[0].transform.GetChild(1).transform.position;

        this.transform.parent.parent.parent.GetChild(0).GetChild(0).GetComponent<RidgeControl>().ridgemanage[0].GetComponent<catline>().ResetCatmullRom();
        this.transform.parent.GetComponent<ColumnControl>().columnmanage[0].GetComponent<catline>().ResetCatmullRom();

        ridgecontrol.reset();
        columncontrol.reset();
        eavecontrol.withoutinireset();
        roofcontrol.withoutinireset();
        roofcontrol2.reset();
        roofcontrolS.reset();
        fc.reset();
        rtc.reset();

    }
}
