using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class roofcontrol : MonoBehaviour
{

    public RidgeControl ridgecontrol;
    public EaveControl eavecontrol;
    public roofsurcontrol roofcontrol1;
    public roofsurcon2control roofcontrol2;
    public roofsurcontrol2 roofcontrolS;
    public RidgetailControl rtc;
    public upridge up;

    public bool upridge = false;

    /*
    public Slider numberslider;
    public Slider tiledwideslider;
    public Slider ohoh;
    */




    public int numberslidervalue;
    public int twvalue;
    public int ohohv;

    public GameObject center;


    // Use this for initialization
    void Start()
    {
        center = transform.parent.parent.GetChild(0).gameObject;
        
        //numberslidervalue = (int)numberslider.value;


        //numberslidervalue = 5;
        
        //ohohv = (int)ohoh.value;


            setnumberslidervalue();
        
    
    }

    // Update is called once per frame
    void Update()
    {

        /*
        if (Input.GetKeyDown(KeyCode.A))
        {

            print(transform.name + " : ");
            print(numberslider.value);



            numberslider.value = numberslider.value + 1;


            setnumberslidervalue();




        }
        if (Input.GetKeyDown(KeyCode.S))
        {

            print(transform.name + " : ");
            print(numberslider.value);


            numberslider.value = numberslider.value - 1;

            setnumberslidervalue();



        }
        */
    }

    public void setnumberslidervalue()
    {

       


       
        //numberslidervalue = (int)numberslider.value;



        if (transform.parent.GetChild(0).GetChild(0).GetChild(0).GetComponent<catline>())
        {
            transform.parent.GetChild(0).GetChild(0).GetChild(0).GetComponent<catline>().ResetCatmullRom();
        }


        if (transform.parent.GetChild(0).childCount>2)
        {
            transform.parent.GetChild(0).GetChild(1).GetChild(0).GetComponent<catline>().ResetCatmullRom();
            //print("dgdgdfgdfgdgdfg "+transform.parent.GetChild(0).GetChild(1).GetChild(0).name);
        
        }


        if (ridgecontrol)
        {

            ridgecontrol.reset();



            //print("~~~~~~~~bababababa~~~~~~~~~     " + (center.transform.position.x - transform.parent.GetChild(0).GetChild(0).GetChild(0).GetChild(0).transform.position.x));
            if (Mathf.Abs(center.transform.position.x - transform.parent.GetChild(0).GetChild(0).GetChild(0).GetChild(0).transform.position.x) >1)
            {
               


                upridge = true;

                
            }
            else
            {
               // upridge = false;
                upridge = true;
            }


            if (upridge == true)
            {
                up.reset();
            }


            if (rtc)
            {
                rtc.reset();
            }

            eavecontrol.reset();
            roofcontrol1.reset();
            roofcontrol2.reset();
            roofcontrolS.reset();
        }


        settwvalue();


    }

    public void settwvalue()
    {
        /*
        twvalue = (int)tiledwideslider.value;
        */

        float length = Vector3.Distance(ridgecontrol.ridgemanage[0].transform.GetChild(2).transform.position, ridgecontrol.ridgemanage[1].transform.GetChild(2).transform.position);

       
        twvalue =  Mathf.RoundToInt(length / 2f);

       

        roofcontrol1.withoutinireset();
        roofcontrol2.reset();
        roofcontrolS.reset();

    }



    /*
    public void setohohvalue()
    {
        ohohv = (int)ohoh.value;

        fc.reset();
        bc.reset();

    }
    */
   



}
