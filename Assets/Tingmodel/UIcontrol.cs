using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIcontrol : MonoBehaviour 
{
    /*
    public RidgeControl ridgecontrol;
   
    public EaveControl eavecontrol;
    public roofsurcontrol roofcontrol;
    public roofsurcon2control roofcontrol2;
    public roofsurcontrol2 roofcontrolS;

    public RidgetailControl rtc;
    
    */

    public ColumnControl columncontrol;

    public ColumnControl columncontrol_b;

    public BC bc;
    public FC fc;

    public bigbon bb;
    public ColumnBody body;

    public PlatForm plat;
    public PlatcolumnControl platform;
   // public RidgetailControl rtc;

   // public upridge up;

   // public bool upridge = false;

    public Slider numberslider;
    public Slider tiledwideslider;
    public Slider ohoh;

    public int numberslidervalue;
    public int twvalue;
    public int ohohv;

    public  GameObject center;

   public  bool isf;
    public bool isb;
    public bool isCb;

	// Use this for initialization
	void Start () 
    {
        center = transform.parent.parent.GetChild(0).gameObject;
        numberslidervalue = (int)numberslider.value;



        isf = false;
        isb = false;
        isCb = false;
        //ohohv = (int)ohoh.value;

        setnumberslidervalue();
	}
	
	// Update is called once per frame
	void Update () 
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
       
        numberslidervalue = (int)numberslider.value;

        


        if (columncontrol)
        {

            columncontrol.reset();

        }


        if (bc) bc.reset();
        if (fc) fc.reset();



        if (columncontrol_b)
        {
            columncontrol_b.reset();
        }



        
        if (bb)
        {
            bb.reset();
        }
        
        if (body)
        { 
            body.reset();
        }


        
        if (plat)
        {




            
            //if (ridgecontrol)
            //{
                plat.reset();
            //}
             
            //else
            //{


            
            plat.reset();


                //print(plat.parayn);



                if (plat.parayn == true)
                {
                    
                    print("~~~");
                    

                    Destroy(plat.platform[0]);
                    plat.platform.Clear();
                    
                    plat.para2reset();
                    //plat.parareset(plat.looog,plat.doot);
                     
                }
                


            //}
           
        }


        if(platform)
        {


            platform.reset();

        }
        

            
    }





    public void settwvalue()
    {
        /*
        twvalue = (int)tiledwideslider.value;

        roofcontrol.withoutinireset();
        roofcontrol2.reset();
        roofcontrolS.reset();
         */ 

    }




    public void setohohvalue()
    {
        ohohv = (int)ohoh.value;

        fc.reset();
        bc.reset();

    }

    /*
    void OnGUI()
    {

        if (Input.GetKeyDown(KeyCode.A))
        {

            print(transform.name + " : ");
            print(numberslider.value);



            numberslider.value = numberslider.value+1;
              

               setnumberslidervalue();




        }
        if (Input.GetKeyDown(KeyCode.S))
        {

            print(transform.name + " : ");
            print(numberslider.value);


            numberslider.value = numberslider.value-1;

               setnumberslidervalue();


            
        }

    }

    */



}
