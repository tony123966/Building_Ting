using UnityEngine;
using System.Collections;

public class uppoint : MonoBehaviour {


    public roofcontrol ucit;
    public RidgeControl ridgecontrol;
    public ColumnControl columncontrol;
    public EaveControl eavecontrol;
    public roofsurcontrol roofcontrol;
    public roofsurcon2control roofcontrol2;
    public roofsurcontrol2 roofcontrolS;
    public RidgetailControl rtc;
    public upridge up;


    float speed = 2.0f;
    float x;
    float y;
    float z;
    // Use this for initialization




    void Start()
    {
        /*
        GameObject clone = Instantiate(Resources.Load("CC"), Vector3.zero, Quaternion.identity) as GameObject;
        */


        

        Vector3 x = transform.parent.position;
        transform.parent.position = new Vector3(transform.parent.parent.parent.parent.GetChild(0).transform.position.x, transform.parent.position.y, transform.parent.parent.parent.parent.GetChild(0).transform.position.z);
        transform.position = x;
        if (Vector3.Distance(transform.position, transform.parent.position) > 2)
        {
            ucit.upridge = true;

            ridgecontrol.reset();


            up.reset();




            
            eavecontrol.reset();
            
            roofcontrol.reset();
            roofcontrol2.reset();
            roofcontrolS.reset();
            

            //20160829
            ridgecontrol.GetComponent<RidgeControl>().ridgemanage[0].GetComponent<catline>().ResetCatmullRom();

        }


        
        //ridgecontrol.ridgemanage[0].GetComponent<RidgeControl>().ridgemanage[0].GetComponent<catline>().ResetCatmullRom();
        

       
        /*
        eavecontrol.reset();
        up.reset();
        roofcontrol.reset();

        roofcontrol2.reset();
        roofcontrolS.reset();
         */
        



        /*
        rtc.reset();
        */

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDrag()
    {
        Vector3 vector = ridgecontrol.ridgemanage[0].transform.GetChild(0).transform.position - ridgecontrol.ridgemanage[0].transform.GetChild(2).transform.position;


        if (Input.GetMouseButton(0))
        {//鼠标按着左键移动
            y = Input.GetAxis("Mouse X") * Time.deltaTime * speed;
            x = Input.GetAxis("Mouse Y") * Time.deltaTime * speed;
         
            //transform.Translate(0, x*5, 0);
            transform.Translate(y * -vector.x, 0, y * -vector.z);
            ridgecontrol.ridgemanage[0].transform.GetChild(0).transform.Translate(y * -vector.x, 0, y * -vector.z);
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
        /*

        if (Vector3.Distance(transform.position, transform.parent.position) > 2)
        {
            ucit.upridge = true;
            up.reset();

        }
        else
        {
            ucit.upridge =false;
            up.reset();

            transform.position = transform.parent.position;

            Vector3 temp = ridgecontrol.ridgemanage[0].transform.GetChild(0).transform.position;
            temp.x = transform.parent.position.x;
            temp.z = transform.parent.position.z;

            ridgecontrol.ridgemanage[0].transform.GetChild(0).transform.position = temp;

        }


        ridgecontrol.ridgemanage[0].GetComponent<RidgeControl>().ridgemanage[0].GetComponent<catline>().ResetCatmullRom();

        ridgecontrol.reset();
        eavecontrol.reset();
        up.reset();
        roofcontrol.reset();

        roofcontrol2.reset();
        roofcontrolS.reset();
        */
        selffix(transform.gameObject, ridgecontrol);


        /*
        rtc.reset();

        */
      


    }


    public void selffix(GameObject bb, RidgeControl rl)
    {
       




        

        if (Vector3.Distance(bb.transform.position, bb.transform.parent.position) > 2)
        {


            ucit.upridge = true;

           
            up.reset();

        }
        else


        {


            ucit.upridge = false;
            up.reset();

            bb.transform.position = bb.transform.parent.position;

            Vector3 temp = rl.ridgemanage[0].transform.GetChild(0).transform.position;
            temp.x = bb.transform.parent.position.x;
            temp.z = bb.transform.parent.position.z;

            rl.ridgemanage[0].transform.GetChild(0).transform.position = temp;

       }

        
        rl.ridgemanage[0].GetComponent<RidgeControl>().ridgemanage[0].GetComponent<catline>().ResetCatmullRom();

        rl.reset();
        eavecontrol.reset();
        up.reset();
        
        roofcontrol.reset();

        roofcontrol2.reset();
        roofcontrolS.reset();
        

    }


}
