using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class corridorUIC : MonoBehaviour 
{

    public RidgeControl ridgecontrol;
    public ColumnControl columncontrol;
    public EaveControl eavecontrol;
    public roofsurcontrol roofcontrol;
    public roofsurcon2control roofcontrol2;
    public roofsurcontrol2 roofcontrolS;
    public BC bc;
    public FC fc;
    public PlatForm plat;
    public RidgetailControl rtc;

    public upridge up;

    public bool upridge = false;

    public Slider numberslider;
    public Slider tiledwideslider;
    public Slider ohoh;

    public int numberslidervalue;
    public int twvalue;
    public int ohohv;

    public  GameObject center;


	// Use this for initialization
	void Start () 
    {
        
        numberslidervalue = (int)numberslider.value;
        //ohohv = (int)ohoh.value;

        setnumberslidervalue();
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    public void setnumberslidervalue()
    {
        numberslidervalue = (int)numberslider.value;
        ridgecontrol.reset();

        if (upridge == true)
        {
            up.reset();
        }

        rtc.reset();
        columncontrol.reset();
        eavecontrol.reset();
        roofcontrol.reset();
        roofcontrol2.reset();
        roofcontrolS.reset();
        /*
        bc.reset();
        fc.reset();
        plat.reset();
        */
      

            
    }

    public void settwvalue()
    {
        twvalue = (int)tiledwideslider.value;

        roofcontrol.withoutinireset();
        roofcontrol2.reset();
        roofcontrolS.reset();

    }

    public void setohohvalue()
    {
        /*
        ohohv = (int)ohoh.value;

        fc.reset();
        bc.reset();
        */
    }

}

