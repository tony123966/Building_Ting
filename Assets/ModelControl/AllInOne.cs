using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class AllInOne : MonoBehaviour
{


    


    

    public roofcontrol ucit;
	public GameObject center;

	public GameObject roof;
	public GameObject body;
	public GameObject platform;




	public List<GameObject> TingPartList = new List<GameObject>();
	public List<Vector3> TingPartPosition = new List<Vector3>();

    //tower

    public List<GameObject> tower = new List<GameObject>();
    public List<GameObject> tower_roof = new List<GameObject>();
    //public List<GameOB> tower_roof = new List<GameOB>();


    //platform

    public List<GameObject> plat_tower = new List<GameObject>();





	public int number;

	


	public float platpercent;
    public float percent2;

    public float columntall;


    public float Roof_Height_Percent;
    public float Roof_Wide_Percent;



    public float roof_tall;
    public float roof_long;

    public float ini_roof_tall;
    public float ini_roof_long;

    public float ini_platwide;
    public float ini_plathigh;


    //roof
    public Vector2 ini_main_ridgedis;
    public Vector2 ini_side_ridgedis;

    public Vector2 main_ridgedis;
    public Vector2 side_ridgedis;

    public Vector2 main_ridgedis_rec;
    public Vector2 side_ridgedis_rec;



    //column's percent
    public float percent_1;
    public float percent_2;
    public float percentdis;

    public float move_percent_1;
    public float move_percent_2;
    public float move_percentdis;

    public float percent_1_rec;
    public float percent_2_rec;
    public float percentdis_rec;


    public Vector2 ini_ridgetail;

    //platform
    public Vector2 ini_platpoint_0;
    public Vector2 ini_platpoint_1;
    public Vector2 ini_platpoint_2;
    public Vector2 ini_platblas;


    public Vector2 move_platpoint_0;
    public Vector2 move_platpoint_1;
    public Vector2 move_platpoint_2;
    public Vector2 move_platblas;


    public Vector2 platpoint_0_rec;
    public Vector2 platpoint_1_rec;
    public Vector2 platpoint_2_rec;
    public Vector2 platblas_rec;







    /*
    public float ini_column;
    public Vector2 ini_columnRec;
    */
    





    public bool Rectangle_Or_Not;


    public int inUseTab;
    public int num;



    public Vector3 p1;
    public Vector3 p2;
    public Vector3 p3;



    void Awake()
    {
        Application.targetFrameRate = 30;
        num = 0;
        inUseTab=0;


    


    }


	// Use this for initialization
	void Start()
	{

        tower_roof.Add(null);

		TingPartList.Add(roof);

		TingPartList.Add(body);
        tower.Add(body);

        plat_tower.Add(platform);
        //tower_roof.Add(roof);

		TingPartList.Add(platform);



		TingPartPosition.Add(roof.transform.position);
		TingPartPosition.Add(body.transform.position);
		TingPartPosition.Add(platform.transform.position);

		percent_1 =  body.transform.GetChild(0).GetChild(1).GetChild(0).GetComponent<ColumnControl>().ini_EyeToColumn.x;
        percent_2 =  body.transform.GetChild(0).GetChild(1).GetChild(0).GetComponent<ColumnControl>().ini_EyeToColumn.y;
        percentdis = body.transform.GetChild(0).GetChild(1).GetChild(0).GetComponent<ColumnControl>().ini_EyeToColumn.magnitude;



        percent2 = 1 / body.transform.GetChild(0).GetChild(2).GetChild(0).GetComponent<ColumnControl>().EyeToColumn;
        
        platpercent = platform.transform.GetChild(2).GetComponent<PlatForm>().percent;
        columntall = body.transform.GetChild(0).GetChild(1).GetChild(0).GetComponent<ColumnControl>().ColumnLong;


        Roof_Height_Percent = roof.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<RidgeControl>().Height;
        Roof_Wide_Percent = roof.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<RidgeControl>().Wide;

        Rectangle_Or_Not = false;

        GameObject Ridge_Nick = TingPartList[0].transform.GetChild(0).GetChild(0).gameObject;
        
        ini_roof_tall = Vector3.Distance(Ridge_Nick.transform.GetChild(0).GetChild(2).transform.position, Ridge_Nick.transform.GetChild(3).GetChild(2).transform.position)/2f;
        ini_roof_long = Vector3.Distance(Ridge_Nick.transform.GetChild(0).GetChild(2).transform.position, Ridge_Nick.transform.GetChild(1).GetChild(2).transform.position)/2f;

        GameObject.Find("bao-ding").transform.position = TingPartList[0].transform.GetChild(0).GetChild(0).GetChild(0).GetChild(0).transform.position;


        ini_platwide = Vector3.Distance(TingPartList[2].transform.GetChild(4).GetChild(0).GetChild(0).transform.position,this.transform.GetChild(0).transform.position);
        ini_plathigh = Vector3.Distance(TingPartList[2].transform.GetChild(4).GetChild(0).GetChild(0).transform.position, TingPartList[2].transform.GetChild(4).GetChild(0).GetChild(1).transform.position);


        threep();


        ini_main_ridgedis = new Vector2(TingPartList[0].transform.GetChild(0).GetChild(0).GetChild(0).GetChild(0).transform.position.x,TingPartList[0].transform.GetChild(0).GetChild(0).GetChild(0).GetChild(0).transform.position.z);

        ini_side_ridgedis = new Vector2(TingPartList[0].transform.GetChild(0).GetChild(0).GetChild(0).GetChild(2).transform.position.x, TingPartList[0].transform.GetChild(0).GetChild(0).GetChild(0).GetChild(2).transform.position.z);

        ini_ridgetail = new Vector2(TingPartList[0].transform.GetChild(0).GetChild(1).GetChild(0).transform.position.x, TingPartList[0].transform.GetChild(0).GetChild(1).GetChild(0).transform.position.z);

        main_ridgedis= ini_main_ridgedis;

        side_ridgedis = ini_side_ridgedis;


        //ini_column = body.transform.GetChild(0).GetChild(1).GetChild(0).GetComponent<ColumnControl>().ColumnWide;




        ini_platpoint_0= new Vector2(TingPartList[2].transform.GetChild(4).GetChild(0).GetChild(0).transform.position.x,TingPartList[2].transform.GetChild(4).GetChild(0).GetChild(0).transform.position.z);
        ini_platpoint_1 = new Vector2(TingPartList[2].transform.GetChild(4).GetChild(0).GetChild(3).transform.position.x, TingPartList[2].transform.GetChild(4).GetChild(0).GetChild(3).transform.position.z);
        ini_platpoint_2 = new Vector2(TingPartList[2].transform.GetChild(4).GetChild(0).GetChild(1).transform.position.x, TingPartList[2].transform.GetChild(4).GetChild(0).GetChild(1).transform.position.z);
        ini_platblas = new Vector2(TingPartList[2].transform.GetChild(4).GetChild(0).GetChild(2).transform.position.x, TingPartList[2].transform.GetChild(4).GetChild(0).GetChild(2).transform.position.z);

	}


    void threep()
    {
        p1 = TingPartList[0].transform.GetChild(0).GetChild(0).GetChild(0).GetChild(0).transform.position;
        p2 = TingPartList[0].transform.GetChild(0).GetChild(0).GetChild(0).GetChild(1).transform.position;
        p3 = TingPartList[0].transform.GetChild(0).GetChild(0).GetChild(0).GetChild(2).transform.position;


    }




	// Update is called once per frame
	void Update()
	{
        
		if (Input.GetKeyDown(KeyCode.Alpha1))
		{
            Shanding(2f);
            
		}
        
		if (Input.GetKeyDown(KeyCode.Alpha2))
		{
            eaveupdate2();
            
		}

		if (Input.GetKeyDown(KeyCode.Alpha3))
		{


            TingPartList[2].transform.GetChild(4).GetComponent<PlatcolumnControl>().num = TingPartList[2].transform.GetChild(4).GetComponent<PlatcolumnControl>().num + 2;
            TingPartList[2].transform.GetChild(4).GetComponent<PlatcolumnControl>().reset();

		}
		if (Input.GetKeyDown(KeyCode.Alpha4))
		{


            TingPartList[2].transform.GetChild(4).GetComponent<PlatcolumnControl>().num = TingPartList[2].transform.GetChild(4).GetComponent<PlatcolumnControl>().num - 2;
            TingPartList[2].transform.GetChild(4).GetComponent<PlatcolumnControl>().reset();
		}
		if (Input.GetKeyDown(KeyCode.Alpha5))
		{

            TingPartList[2].transform.GetChild(4).GetComponent<PlatcolumnControl>().stairnum = TingPartList[2].transform.GetChild(4).GetComponent<PlatcolumnControl>().stairnum + 1;
            TingPartList[2].transform.GetChild(4).GetComponent<PlatcolumnControl>().reset();

		}
		if (Input.GetKeyDown(KeyCode.Alpha6))
		{
            TingPartList[2].transform.GetChild(4).GetComponent<PlatcolumnControl>().stairnum = TingPartList[2].transform.GetChild(4).GetComponent<PlatcolumnControl>().stairnum-1;
            TingPartList[2].transform.GetChild(4).GetComponent<PlatcolumnControl>().reset();
		}

		if (Input.GetKeyDown(KeyCode.Alpha7))
		{

            TingPartList[1].transform.GetChild(0).GetChild(2).GetChild(0).GetComponent<ColumnControl>().bodycolumnnumber = TingPartList[1].transform.GetChild(0).GetChild(2).GetChild(0).GetComponent<ColumnControl>().bodycolumnnumber + 1;
            TingPartList[1].transform.GetChild(1).GetComponent<UIcontrol>().setnumberslidervalue();
		}

		if (Input.GetKeyDown(KeyCode.Alpha8))
		{

            TingPartList[1].transform.GetChild(0).GetChild(2).GetChild(0).GetComponent<ColumnControl>().bodycolumnnumber = TingPartList[1].transform.GetChild(0).GetChild(2).GetChild(0).GetComponent<ColumnControl>().bodycolumnnumber - 1;
            TingPartList[1].transform.GetChild(1).GetComponent<UIcontrol>().setnumberslidervalue();
		}

		if (Input.GetKeyDown(KeyCode.Alpha9))
		{

            TingPartList[1].transform.GetChild(0).GetChild(1).GetChild(0).GetComponent<ColumnControl>().columnnumber = TingPartList[1].transform.GetChild(0).GetChild(1).GetChild(0).GetComponent<ColumnControl>().columnnumber + 2;
            TingPartList[1].transform.GetChild(1).GetComponent<UIcontrol>().setnumberslidervalue();
		}
	

        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            
            TingPartList[1].transform.GetChild(0).GetChild(1).GetChild(0).GetComponent<ColumnControl>().columnnumber = TingPartList[1].transform.GetChild(0).GetChild(1).GetChild(0).GetComponent<ColumnControl>().columnnumber - 2;
            TingPartList[1].transform.GetChild(1).GetComponent<UIcontrol>().setnumberslidervalue();
        
        }
        


    }



    public void multi_column(int a)
    {
        TingPartList[1].transform.GetChild(0).GetChild(1).GetChild(0).GetComponent<ColumnControl>().columnnumber = a;
        TingPartList[1].transform.GetChild(1).GetComponent<UIcontrol>().setnumberslidervalue();

    }

    public void multi_body(int a)
    {
        TingPartList[1].transform.GetChild(0).GetChild(2).GetChild(0).GetComponent<ColumnControl>().bodycolumnnumber = a;
        TingPartList[1].transform.GetChild(1).GetComponent<UIcontrol>().setnumberslidervalue();

    }

    public void multi_platbla(int a)
    {
        TingPartList[2].transform.GetChild(4).GetComponent<PlatcolumnControl>().num = a;
        TingPartList[2].transform.GetChild(4).GetComponent<PlatcolumnControl>().reset();

    }

    public void multi_stair(int a)
    {

        TingPartList[2].transform.GetChild(4).GetComponent<PlatcolumnControl>().stairnum = a;
        TingPartList[2].transform.GetChild(4).GetComponent<PlatcolumnControl>().reset();
    }






    public void Change_Double_Eave(int b)
    {


        GameObject c = tower[b];
      

        Vector3 v1 = new Vector3(c.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(0).transform.position.x, c.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(0).transform.position.y - 17, c.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(0).transform.position.z);

      

        GameObject clone2 = Instantiate(Resources.Load("RidgeCctwolayer"), v1, Quaternion.identity) as GameObject;


        clone2.transform.parent = transform;
        //clone2.transform.GetChild(1).GetComponent<roofcontrol>().numberslider.value = ucit.numberslidervalue;

        clone2.transform.GetChild(1).GetComponent<roofcontrol>().numberslidervalue = ucit.numberslidervalue;

      
        clone2.transform.GetChild(1).GetComponent<roofcontrol>().setnumberslidervalue();



        Destroy(tower_roof[b]);

        tower_roof[b] = clone2;


    }

    public void Change_Double_Eave_2()
    {


        GameObject c = TingPartList[1];

        for(int i =0;i<tower.Count;i++)
        {

            if(tower[i].name==TingPartList[1].name)
            {

                if (tower_roof[i]!=null)
                {

                    Vector3 v1 = new Vector3(c.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(0).transform.position.x, c.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(0).transform.position.y - 17, c.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(0).transform.position.z);


                    GameObject clone2 = Instantiate(Resources.Load("RidgeCctwolayer"), v1, Quaternion.identity) as GameObject;


                    clone2.transform.parent = transform;
                   // clone2.transform.GetChild(1).GetComponent<roofcontrol>().numberslider.value = ucit.numberslidervalue;


                    clone2.transform.GetChild(1).GetComponent<roofcontrol>().numberslidervalue = ucit.numberslidervalue;
                    clone2.transform.GetChild(1).GetComponent<roofcontrol>().setnumberslidervalue();

                    Destroy(tower_roof[i]);

                    tower_roof[i] = clone2;

                   

                }



                break;
            }
        }




       


    }



    public void Double_Eave()
    {


        GameObject cc = TingPartList[1];

       
        Vector3 v1 = new Vector3(cc.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(0).transform.position.x, cc.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(0).transform.position.y - 15, cc.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(0).transform.position.z);

        print(" dd  " + v1);
        GameObject clone2 = Instantiate(Resources.Load("RidgeCctwolayer"), v1, Quaternion.identity) as GameObject;


        clone2.transform.parent = transform;
        //clone2.transform.GetChild(1).GetComponent<roofcontrol>().numberslider.value = ucit.numberslidervalue;

        print(ucit.numberslidervalue);



        
         clone2.transform.GetChild(1).GetComponent<roofcontrol>().numberslidervalue = ucit.numberslidervalue;
         clone2.transform.GetChild(1).GetComponent<roofcontrol>().setnumberslidervalue();
        


        tower_roof[inUseTab] = clone2;
     

    }





    public void Bodytruefalse(bool a)
    {

        TingPartList[1].transform.GetChild(1).GetComponent<UIcontrol>().isCb = a;

        TingPartList[1].transform.GetChild(0).GetChild(2).GetChild(0).GetComponent<ColumnControl>().reset();
        TingPartList[1].transform.GetChild(7).GetComponent<ColumnBody>().reset();
    }











    //rectangle system


    //寶塔 *****************
    public void upup(float a)
    {
        columntall = tower[tower.Count-1].transform.GetChild(0).GetChild(1).GetChild(0).GetComponent<ColumnControl>().ColumnLong;
        a = columntall;


        TingPartList[0].transform.Translate(0,a,0);
       
        //GameObject clone = Instantiate(TingPartList[1], TingPartList[1].transform.position, Quaternion.identity) as GameObject;

        GameObject clone = Instantiate(tower[tower.Count - 1], tower[tower.Count - 1].transform.position, Quaternion.identity) as GameObject;
        
        clone.transform.parent = transform;
        clone.transform.Translate(0, a, 0);

        clone.name = "body" + num;
        num++;



        MoveTowerBody(clone);

        //clone.transform.GetChild(2).GetComponent<UIcontrol>().numberslidervalue = ucit.numberslidervalue;
        
        

        clone.transform.GetChild(0).GetChild(1).GetChild(0).GetComponent<catline>().ResetCatmullRom();
        clone.transform.GetChild(0).GetChild(1).GetChild(0).GetComponent<circlecut1>().reset();
        clone.transform.GetChild(0).GetChild(1).GetChild(0).GetComponent<Columntile>().reset();


        clone.transform.GetChild(0).GetChild(2).GetChild(0).GetComponent<catline>().ResetCatmullRom();
        clone.transform.GetChild(0).GetChild(2).GetChild(0).GetComponent<circlecut1>().reset();
        clone.transform.GetChild(0).GetChild(2).GetChild(0).GetComponent<Columntile>().reset();

        clone.transform.GetChild(1).GetComponent<UIcontrol>().setnumberslidervalue();
        /*
        GameObject cc = TingPartList[1];

        Vector3 v1 = new Vector3(cc.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(0).transform.position.x, cc.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(0).transform.position.y-15,cc.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(0).transform.position.z);



        
        GameObject clone2 = Instantiate(Resources.Load("RidgeCctwolayer"), v1, Quaternion.identity) as GameObject;
        
       
        clone2.transform.parent = transform;
        clone2.transform.GetChild(1).GetComponent<roofcontrol>().numberslider.value = ucit.numberslidervalue;
        */

       
        GameObject.Find("bao-ding").transform.position = TingPartList[0].transform.GetChild(0).GetChild(0).GetChild(0).GetChild(0).transform.position;
        
        // TingPartList[0].transform.GetChild(1).GetComponent<roofcontrol>().setnumberslidervalue();


        TingPartList[1] = clone;

        tower.Add(clone);
        tower_roof.Add(null);


        if (TingPartList[1].transform.GetChild(1).GetComponent<UIcontrol>().isCb == true)
        {
            clone.transform.GetChild(7).GetComponent<ColumnBody>().reset();
        }

        threep();
        

    }



    public void changeLayer(int a)
    {
        TingPartList[1] = tower[a];
        inUseTab=a;


        columntall = TingPartList[1].transform.GetChild(0).GetChild(1).GetChild(0).GetComponent<ColumnControl>().ColumnLong;

    }


    public void DeleteLayer(int a)
    {

       

        TingPartList[1] = tower[a];
        inUseTab = a;


        columntall = tower[a].transform.GetChild(0).GetChild(1).GetChild(0).GetComponent<ColumnControl>().ColumnLong;



        TingPartList[0].transform.Translate(0, -columntall, 0);



        for (int i = 0; i < tower.Count; i++)
        {
            if (TingPartList[1].name == tower[i].name)
            {

                for (int j = i + 1; j < tower.Count; j++)
                {
                    tower[j].transform.Translate(0, -columntall , 0);
                    if (tower_roof[j - 1] != null)
                        tower_roof[j - 1].transform.Translate(0, -columntall, 0);
                }


                TingPartList[1].transform.GetChild(0).GetChild(1).GetChild(0).GetChild(0).transform.Translate(0, (columntall) * a, 0);
                TingPartList[1].transform.GetChild(0).GetChild(1).GetChild(0).GetChild(1).transform.Translate(0, (columntall) * a, 0);

                TingPartList[1].transform.GetChild(0).GetChild(2).GetChild(0).GetChild(0).transform.Translate(0, (columntall) * a, 0);
                TingPartList[1].transform.GetChild(0).GetChild(2).GetChild(0).GetChild(1).transform.Translate(0, (columntall) * a, 0);



                break;
            }

        }



    

        

        tower.Remove(tower[a]);

       
        if (tower_roof[a]!=null)
        {
            print("ffffff");
        Destroy(tower_roof[a].gameObject);
        }
        
        tower_roof.Remove(tower_roof[a]);


        Destroy(TingPartList[1].gameObject);



        GameObject.Find("bao-ding").transform.position = TingPartList[0].transform.GetChild(0).GetChild(0).GetChild(0).GetChild(0).transform.position;
        if(a!=0)
        { 

        TingPartList[1] = tower[a-1];
        inUseTab = a-1;
         }
        else
        {
            TingPartList[1] = tower[a];
            inUseTab = a;


        }
        //changeLayer(inUseTab);
        threep();
    }













    public void MoveTowerBody(GameObject a)
    {


        
        a.transform.GetChild(0).GetChild(1).GetChild(0).transform.Translate(0, 0, 0);

        a.transform.GetChild(0).GetChild(1).GetChild(0).GetComponent<ColumnControl>().columnmanage[0].GetComponent<catline>().ResetCatmullRom();
        a.transform.GetChild(0).GetChild(1).GetChild(0).GetComponent<ColumnControl>().reset();
        

    }

    //**** ****************

    //平台tower系統
    public void addplatform()
    {

       float  a = plat_tower[plat_tower.Count - 1].transform.GetChild(4).GetComponent<PlatcolumnControl>().high;
        


        TingPartList[0].transform.Translate(0, a, 0);



        //GameObject clone = Instantiate(TingPartList[1], TingPartList[1].transform.position, Quaternion.identity) as GameObject;

        GameObject clone = Instantiate(plat_tower[plat_tower.Count - 1], plat_tower[plat_tower.Count - 1].transform.position, Quaternion.identity) as GameObject;

        clone.transform.parent = transform;
        clone.transform.Translate(0, a, 0);

        clone.name = "PLAT" + num;
        num++;




        for (int i = 0; i<tower.Count; i++)
        {
            tower[i].transform.Translate(0, a, 0);

        }
        for (int i = 0; i < tower_roof.Count; i++)
        {
            if (tower_roof[i]!=null)
            tower_roof[i].transform.Translate(0, a, 0);

        }

            //MoveTowerBody(clone);

            //clone.transform.GetChild(2).GetComponent<UIcontrol>().numberslidervalue = ucit.numberslidervalue;


            /*
            clone.transform.GetChild(0).GetChild(1).GetChild(0).GetComponent<catline>().ResetCatmullRom();
            clone.transform.GetChild(0).GetChild(1).GetChild(0).GetComponent<circlecut1>().reset();
            clone.transform.GetChild(0).GetChild(1).GetChild(0).GetComponent<Columntile>().reset();


            clone.transform.GetChild(0).GetChild(2).GetChild(0).GetComponent<catline>().ResetCatmullRom();
            clone.transform.GetChild(0).GetChild(2).GetChild(0).GetComponent<circlecut1>().reset();
            clone.transform.GetChild(0).GetChild(2).GetChild(0).GetComponent<Columntile>().reset();

            clone.transform.GetChild(1).GetComponent<UIcontrol>().setnumberslidervalue();
           */


            GameObject.Find("bao-ding").transform.position = TingPartList[0].transform.GetChild(0).GetChild(0).GetChild(0).GetChild(0).transform.position;

       

        TingPartList[2] = clone;




        plat_tower.Add(clone);
       
        /*

        if (TingPartList[1].transform.GetChild(1).GetComponent<UIcontrol>().isCb == true)
        {
            clone.transform.GetChild(7).GetComponent<ColumnBody>().reset();
        }

        */





    }


    public void deleteplatform()
    {






    }






    //歇山頂偷吃步



    public void Shanding(float a)
    {
        GameObject Ridge_Nick = TingPartList[0].transform.GetChild(0).GetChild(0).gameObject;


        Vector3 P1 = (Ridge_Nick.transform.parent.parent.GetChild(7).GetComponent<upridge>().upridgemanage[0].transform.GetChild(0).transform.position + Ridge_Nick.transform.parent.parent.GetChild(7).GetComponent<upridge>().upridgemanage[2].transform.GetChild(2).transform.position)/2;
        Vector3 P2 = (Ridge_Nick.transform.parent.parent.GetChild(7).GetComponent<upridge>().upridgemanage[0].transform.GetChild(1).transform.position + Ridge_Nick.transform.parent.parent.GetChild(7).GetComponent<upridge>().upridgemanage[2].transform.GetChild(1).transform.position) / 2;
        Vector3 P3 = (Ridge_Nick.transform.parent.parent.GetChild(7).GetComponent<upridge>().upridgemanage[0].transform.GetChild(2).transform.position + Ridge_Nick.transform.parent.parent.GetChild(7).GetComponent<upridge>().upridgemanage[2].transform.GetChild(0).transform.position) / 2;

        P1 = new Vector3(P1.x, P1.y+a, P1.z);
        P2 = new Vector3(P2.x, P2.y + a, P2.z);
        P3 = new Vector3(P3.x, P3.y + a, P3.z);


        Ridge_Nick.transform.parent.parent.GetChild(7).GetComponent<upridge>().upridgemanage[0].transform.GetChild(0).transform.position = P1;
        Ridge_Nick.transform.parent.parent.GetChild(7).GetComponent<upridge>().upridgemanage[2].transform.GetChild(2).transform.position = P1;

        Ridge_Nick.transform.parent.parent.GetChild(7).GetComponent<upridge>().upridgemanage[0].transform.GetChild(1).transform.position = P2;
        Ridge_Nick.transform.parent.parent.GetChild(7).GetComponent<upridge>().upridgemanage[2].transform.GetChild(1).transform.position = P2;

        Ridge_Nick.transform.parent.parent.GetChild(7).GetComponent<upridge>().upridgemanage[0].transform.GetChild(2).transform.position = P3;
        Ridge_Nick.transform.parent.parent.GetChild(7).GetComponent<upridge>().upridgemanage[2].transform.GetChild(0).transform.position = P3;



    
    }


    //長方形屋頂

    //恢復
    public void rectangleundo()
    {

        Rectangle_Or_Not = false;

        float newmx = main_ridgedis.x - ini_main_ridgedis.x;
        float newmz = main_ridgedis.y - ini_main_ridgedis.y;

        float newsx = side_ridgedis.x - ini_side_ridgedis.x;
        float newsz = side_ridgedis.y - ini_side_ridgedis.y;






        //ChangeRoof(0,-newmx,-newmz);
        //ChangeRoof(2, -newsx, -newsz);
        if (ini_side_ridgedis != side_ridgedis || ini_main_ridgedis != main_ridgedis)
        {

         



        TingPartList[0].transform.GetChild(0).GetChild(0).GetChild(0).GetChild(0).transform.position = new Vector3(ini_main_ridgedis.x, TingPartList[0].transform.GetChild(0).GetChild(0).GetChild(0).GetChild(0).transform.position.y, ini_main_ridgedis.y);
        TingPartList[0].transform.GetChild(0).GetChild(0).GetChild(0).GetChild(2).transform.position = new Vector3(ini_side_ridgedis.x, TingPartList[0].transform.GetChild(0).GetChild(0).GetChild(0).GetChild(2).transform.position.y, ini_side_ridgedis.y);
        TingPartList[0].transform.GetChild(0).GetChild(0).GetChild(0).GetChild(1).transform.position = con2posiotion(TingPartList[0].transform.GetChild(0).GetChild(0).GetChild(0).GetChild(0).transform.position, TingPartList[0].transform.GetChild(0).GetChild(0).GetChild(0).GetChild(2).transform.position);

        TingPartList[0].transform.GetChild(0).GetChild(1).GetChild(0).transform.position = new Vector3(ini_ridgetail.x, TingPartList[0].transform.GetChild(0).GetChild(1).GetChild(0).transform.position.y, ini_ridgetail.y);

            /*
        TingPartList[0].transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<RidgeControl>().reset();
        TingPartList[0].transform.GetChild(0).GetChild(1).GetChild(0).GetComponent<RidgetailControl>().reset();
            */

            /*
        rectangle_column(-newsx,-newsz);
        rectangle_Platform(-newsx, -newsz);
            */
        
        }




        main_ridgedis = ini_main_ridgedis;
        side_ridgedis = ini_side_ridgedis;



    }



    public void ChangeRoof(int n, float a, float b)
    {


        


        GameObject Ridge_Nick = TingPartList[0].transform.GetChild(0).GetChild(0).gameObject;



        if (n == 0)
        {
            
           
            /*
            Ridge_Nick.transform.GetChild(0).GetChild(n).transform.Translate(a, 0, b);
            Ridge_Nick.transform.GetChild(1).GetChild(n).transform.Translate(-b, 0, -a);
            Ridge_Nick.transform.GetChild(2).GetChild(n).transform.Translate(-a, 0, -b);

            if (Ridge_Nick.transform.GetChild(3))
             Ridge_Nick.transform.GetChild(3).GetChild(n).transform.Translate(b, 0, a);
            */

            

            Ridge_Nick.transform.GetChild(0).GetChild(n).transform.position = new Vector3(ini_main_ridgedis.x + a * Mathf.Cos(45f), Ridge_Nick.transform.GetChild(0).GetChild(n).transform.position.y, ini_main_ridgedis.y + b * Mathf.Cos(45f));








            
            //特別
            Ridge_Nick.transform.parent.parent.GetChild(7).GetComponent<upridge>().upridgemanage[0].transform.GetChild(0).transform.Translate(a, 0, b);
            Ridge_Nick.transform.parent.parent.GetChild(7).GetComponent<upridge>().upridgemanage[0].transform.GetChild(2).transform.Translate(-b, 0, -a);

            
            Ridge_Nick.transform.parent.parent.GetChild(7).GetComponent<upridge>().upridgemanage[1].transform.GetChild(0).transform.Translate(a, 0, -b);
            //Ridge_Nick.transform.parent.parent.GetChild(7).GetComponent<upridge>().upridgemanage[1].transform.GetChild(2).transform.Translate(b, 0, -a);


            Ridge_Nick.transform.parent.parent.GetChild(7).GetComponent<upridge>().upridgemanage[2].transform.GetChild(0).transform.Translate(a, 0, b);
            Ridge_Nick.transform.parent.parent.GetChild(7).GetComponent<upridge>().upridgemanage[2].transform.GetChild(2).transform.Translate(-b, 0, -a);

            Ridge_Nick.transform.parent.parent.GetChild(7).GetComponent<upridge>().upridgemanage[3].transform.GetChild(0).transform.Translate(a, 0, -b);
           // Ridge_Nick.transform.parent.parent.GetChild(7).GetComponent<upridge>().upridgemanage[3].transform.GetChild(2).transform.Translate(b, 0, -a);





           
        }
        else if (n == 2)
        {
            /*
            Ridge_Nick.transform.GetChild(0).GetChild(n).transform.Translate(a, 0, b);
            */
            //print(a+"   :  "+b);
            Ridge_Nick.transform.GetChild(0).GetChild(n).transform.position = new Vector3(ini_side_ridgedis.x + a * Mathf.Cos(45f), Ridge_Nick.transform.GetChild(0).GetChild(n).transform.position.y, ini_side_ridgedis.y + b * Mathf.Cos(45f));
           
            //Ridge_Nick.transform.GetChild(0).GetChild(n).transform.position = new Vector3(ini_side_ridgedis.x , Ridge_Nick.transform.GetChild(0).GetChild(n).transform.position.y, ini_side_ridgedis.y );




            //ini_side_ridgedis;


            /*
             
            Ridge_Nick.transform.GetChild(1).GetChild(n).transform.Translate(-b, 0, -a);
            Ridge_Nick.transform.GetChild(2).GetChild(n).transform.Translate(-a, 0, -b);

            if (Ridge_Nick.transform.GetChild(3))
            Ridge_Nick.transform.GetChild(3).GetChild(n).transform.Translate(b, 0, a);

            */

            side_ridgedis = new Vector2(side_ridgedis.x + a, side_ridgedis.y + b);

            TingPartList[0].transform.GetChild(0).GetChild(1).GetChild(0).transform.Translate(a, 0, b);


        }


        Ridge_Nick.transform.GetChild(0).GetChild(1).transform.position = con2posiotion(Ridge_Nick.transform.GetChild(0).GetChild(0).transform.position, Ridge_Nick.transform.GetChild(0).GetChild(2).transform.position);
        Ridge_Nick.transform.GetChild(1).GetChild(1).transform.position = con2posiotion(Ridge_Nick.transform.GetChild(1).GetChild(0).transform.position, Ridge_Nick.transform.GetChild(1).GetChild(2).transform.position);
        Ridge_Nick.transform.GetChild(2).GetChild(1).transform.position = con2posiotion(Ridge_Nick.transform.GetChild(2).GetChild(0).transform.position, Ridge_Nick.transform.GetChild(2).GetChild(2).transform.position);

        if (Ridge_Nick.transform.GetChild(3))
        Ridge_Nick.transform.GetChild(3).GetChild(1).transform.position = con2posiotion(Ridge_Nick.transform.GetChild(3).GetChild(0).transform.position, Ridge_Nick.transform.GetChild(3).GetChild(2).transform.position);

        //Ridge重整
        Ridge_Nick.transform.GetChild(0).GetComponent<catline>().ResetCatmullRom();
        Ridge_Nick.transform.GetChild(1).GetComponent<catline>().ResetCatmullRom();
        Ridge_Nick.transform.GetChild(2).GetComponent<catline>().ResetCatmullRom();
        if (Ridge_Nick.transform.GetChild(3))
        Ridge_Nick.transform.GetChild(3).GetComponent<catline>().ResetCatmullRom();

        Ridge_Nick.transform.GetChild(0).GetComponent<circlecut1>().reset();
        Ridge_Nick.transform.GetChild(1).GetComponent<circlecut1>().reset();
        Ridge_Nick.transform.GetChild(2).GetComponent<circlecut1>().reset();
        if (Ridge_Nick.transform.GetChild(3))
        Ridge_Nick.transform.GetChild(3).GetComponent<circlecut1>().reset();

        Ridge_Nick.transform.GetChild(0).GetComponent<Ridgetile>().reset();

        /*
        Ridge_Nick.transform.GetChild(1).GetComponent<Ridgetile>().reset();

        Ridge_Nick.transform.GetChild(2).GetComponent<Ridgetile>().reset();
        if (Ridge_Nick.transform.GetChild(3))
        Ridge_Nick.transform.GetChild(3).GetComponent<Ridgetile>().reset();


        TingPartList[0].transform.GetChild(0).GetChild(1).GetChild(0).GetComponent<RidgetailControl>().reset();
        */
        //eaveupdate();



        //TingPartList[0].transform.GetChild(1).GetComponent<roofcontrol>().setnumberslidervalue();

        roof_tall = Vector3.Distance(Ridge_Nick.transform.GetChild(0).GetChild(2).transform.position, Ridge_Nick.transform.GetChild(3).GetChild(2).transform.position);
        roof_long = Vector3.Distance(Ridge_Nick.transform.GetChild(0).GetChild(2).transform.position, Ridge_Nick.transform.GetChild(1).GetChild(2).transform.position);

         main_ridgedis_rec = new Vector2(ini_main_ridgedis.x + a * Mathf.Cos(45f),ini_main_ridgedis.y + b * Mathf.Cos(45f));
         side_ridgedis_rec = new Vector2(ini_side_ridgedis.x + a * Mathf.Cos(45f), ini_side_ridgedis.y + b * Mathf.Cos(45f));
       
         percent_1_rec = percent_1+ a * Mathf.Cos(45f);
         percent_2_rec = percent_2 + b * Mathf.Cos(45f);

         platpoint_0_rec = new Vector2(ini_platpoint_0.x + a * Mathf.Cos(45f), ini_platpoint_0.y + b * Mathf.Cos(45f));
         platpoint_1_rec = new Vector2(ini_platpoint_1.x + a * Mathf.Cos(45f), ini_platpoint_1.y + b * Mathf.Cos(45f));
         platpoint_2_rec = new Vector2(ini_platpoint_2.x + a * Mathf.Cos(45f), ini_platpoint_2.y + b * Mathf.Cos(45f));
         platblas_rec = new Vector2(ini_platblas.x + a * Mathf.Cos(45f), ini_platblas.y + b * Mathf.Cos(45f));

    }

    public void eaveupdate()
    {
        GameObject Ridge_Nick = TingPartList[0].transform.GetChild(0).GetChild(0).gameObject;

      

        //others

        
        upridge ups = Ridge_Nick.transform.parent.parent.GetChild(7).GetComponent<upridge>();




        ups.reset();

        Ridge_Nick.transform.parent.parent.GetChild(5).GetComponent<EaveControl>().reset();
        Ridge_Nick.transform.parent.parent.GetChild(2).GetComponent<roofsurcontrol>().reset();
        Ridge_Nick.transform.parent.parent.GetChild(3).GetComponent<roofsurcon2control>().reset();
        Ridge_Nick.transform.parent.parent.GetChild(4).GetComponent<roofsurcontrol2>().reset();

        


    }




    public void eaveupdate2()
    {

        //Rectangle_Or_Not = true;

        GameObject Ridge_Nick = TingPartList[0].transform.GetChild(0).GetChild(0).gameObject;



        //others


        upridge ups = Ridge_Nick.transform.parent.parent.GetChild(7).GetComponent<upridge>();

        
        ups.inig1(ups.transform.GetChild(1).transform.gameObject);
        ups.inig2(ups.transform.GetChild(3).transform.gameObject);
        


        ups.inig3(ups.transform.GetChild(2).transform.gameObject);
        ups.inig4(ups.transform.GetChild(0).transform.gameObject);


        //creat roofthxSanding

        GameObject sanding = new GameObject();

       

        GameObject Ridge1 = new GameObject();
        GameObject Ridge2 = new GameObject();
        GameObject Ridge3 = new GameObject();
        GameObject Ridge4 = new GameObject();


        Ridge1.transform.parent = sanding.transform;
        Ridge2.transform.parent = sanding.transform;
        Ridge3.transform.parent = sanding.transform;
        Ridge4.transform.parent = sanding.transform;

        GameObject R11 = Instantiate(Ridge_Nick.transform.GetChild(0).GetChild(0).gameObject, Ridge_Nick.transform.GetChild(0).GetChild(0).gameObject.transform.position, Quaternion.identity) as GameObject;
        GameObject R12 = Instantiate(Ridge_Nick.transform.parent.parent.GetChild(7).GetComponent<upridge>().upridgemanage[0].transform.GetChild(0).gameObject, Ridge_Nick.transform.parent.parent.GetChild(7).GetComponent<upridge>().upridgemanage[0].transform.GetChild(0).gameObject.transform.position, Quaternion.identity) as GameObject;

        R11.transform.parent = Ridge1.transform;
        R12.transform.parent = Ridge1.transform;

        Ridge1.AddComponent<catline>().AddControlPoint(R11);
        Ridge1.GetComponent<catline>().AddControlPoint(R12);
        Ridge1.GetComponent<catline>().ResetCatmullRom();

        GameObject R21 = Instantiate(Ridge_Nick.transform.GetChild(1).GetChild(0).gameObject, Ridge_Nick.transform.GetChild(1).GetChild(0).gameObject.transform.position, Quaternion.identity) as GameObject;
        GameObject R22 = Instantiate(Ridge_Nick.transform.parent.parent.GetChild(7).GetComponent<upridge>().upridgemanage[0].transform.GetChild(2).gameObject, Ridge_Nick.transform.parent.parent.GetChild(7).GetComponent<upridge>().upridgemanage[0].transform.GetChild(2).gameObject.transform.position, Quaternion.identity) as GameObject;

        R21.transform.parent = Ridge2.transform;
        R22.transform.parent = Ridge2.transform;

        Ridge2.AddComponent<catline>().AddControlPoint(R21);
        Ridge2.GetComponent<catline>().AddControlPoint(R22);
        Ridge2.GetComponent<catline>().ResetCatmullRom();

        GameObject R31 = Instantiate(Ridge_Nick.transform.GetChild(2).GetChild(0).gameObject, Ridge_Nick.transform.GetChild(2).GetChild(0).gameObject.transform.position, Quaternion.identity) as GameObject;
        GameObject R32 = Instantiate(Ridge_Nick.transform.parent.parent.GetChild(7).GetComponent<upridge>().upridgemanage[2].transform.GetChild(0).gameObject, Ridge_Nick.transform.parent.parent.GetChild(7).GetComponent<upridge>().upridgemanage[2].transform.GetChild(0).gameObject.transform.position, Quaternion.identity) as GameObject;

        R31.transform.parent = Ridge3.transform;
        R32.transform.parent = Ridge3.transform;

        Ridge3.AddComponent<catline>().AddControlPoint(R31);
        Ridge3.GetComponent<catline>().AddControlPoint(R32);
        Ridge3.GetComponent<catline>().ResetCatmullRom();

        GameObject R41 = Instantiate(Ridge_Nick.transform.GetChild(3).GetChild(0).gameObject, Ridge_Nick.transform.GetChild(3).GetChild(0).gameObject.transform.position, Quaternion.identity) as GameObject;
        GameObject R42 = Instantiate(Ridge_Nick.transform.parent.parent.GetChild(7).GetComponent<upridge>().upridgemanage[2].transform.GetChild(2).gameObject, Ridge_Nick.transform.parent.parent.GetChild(7).GetComponent<upridge>().upridgemanage[2].transform.GetChild(2).gameObject.transform.position, Quaternion.identity) as GameObject;

        R41.transform.parent = Ridge4.transform;
        R42.transform.parent = Ridge4.transform;

        Ridge4.AddComponent<catline>().AddControlPoint(R41);
        Ridge4.GetComponent<catline>().AddControlPoint(R42);
        Ridge4.GetComponent<catline>().ResetCatmullRom();




        Ridge1.AddComponent<circlecut1>().reset();
        Ridge2.AddComponent<circlecut1>().reset();
        Ridge3.AddComponent<circlecut1>().reset();
        Ridge4.AddComponent<circlecut1>().reset();


        Ridge1.AddComponent<Ridgetile>().reset();
        Ridge2.AddComponent<Ridgetile>().reset();
        Ridge3.AddComponent<Ridgetile>().reset();
        Ridge4.AddComponent<Ridgetile>().reset();










        //eave
        Ridge_Nick.transform.parent.parent.GetChild(5).GetComponent<EaveControl>().inig(Ridge_Nick.transform.parent.parent.GetChild(5).GetComponent<EaveControl>().eavemanage[0]);
        Ridge_Nick.transform.parent.parent.GetChild(5).GetComponent<EaveControl>().inig(Ridge_Nick.transform.parent.parent.GetChild(5).GetComponent<EaveControl>().eavemanage[2]);
        Ridge_Nick.transform.parent.parent.GetChild(5).GetComponent<EaveControl>().inig(Ridge_Nick.transform.parent.parent.GetChild(5).GetComponent<EaveControl>().eavemanage[1]);
        Ridge_Nick.transform.parent.parent.GetChild(5).GetComponent<EaveControl>().inig(Ridge_Nick.transform.parent.parent.GetChild(5).GetComponent<EaveControl>().eavemanage[3]);

        //rf
        Ridge_Nick.transform.parent.parent.GetChild(2).GetComponent<roofsurcontrol>().inig(Ridge_Nick.transform.parent.parent.GetChild(2).GetComponent<roofsurcontrol>().roofsurfacemanage[0]);
        Ridge_Nick.transform.parent.parent.GetChild(2).GetComponent<roofsurcontrol>().inig(Ridge_Nick.transform.parent.parent.GetChild(2).GetComponent<roofsurcontrol>().roofsurfacemanage[2]);
        Ridge_Nick.transform.parent.parent.GetChild(2).GetComponent<roofsurcontrol>().inig(Ridge_Nick.transform.parent.parent.GetChild(2).GetComponent<roofsurcontrol>().roofsurfacemanage[1]);
        Ridge_Nick.transform.parent.parent.GetChild(2).GetComponent<roofsurcontrol>().inig(Ridge_Nick.transform.parent.parent.GetChild(2).GetComponent<roofsurcontrol>().roofsurfacemanage[3]);

        //RRR
        Ridge_Nick.transform.parent.parent.GetChild(3).GetComponent<roofsurcon2control>().inig(Ridge_Nick.transform.parent.parent.GetChild(3).GetComponent<roofsurcon2control>().rrrRL[0]);
        Ridge_Nick.transform.parent.parent.GetChild(3).GetComponent<roofsurcon2control>().inig(Ridge_Nick.transform.parent.parent.GetChild(3).GetComponent<roofsurcon2control>().rrrRL[2]);
        Ridge_Nick.transform.parent.parent.GetChild(3).GetComponent<roofsurcon2control>().inig(Ridge_Nick.transform.parent.parent.GetChild(3).GetComponent<roofsurcon2control>().rrrRL[1]);
        Ridge_Nick.transform.parent.parent.GetChild(3).GetComponent<roofsurcon2control>().inig(Ridge_Nick.transform.parent.parent.GetChild(3).GetComponent<roofsurcon2control>().rrrRL[3]);
        //rf2


        Ridge_Nick.transform.parent.parent.GetChild(4).GetComponent<roofsurcontrol2>().inig(Ridge_Nick.transform.parent.parent.GetChild(4).GetComponent<roofsurcontrol2>().roofsurface2manage[0]);
        Ridge_Nick.transform.parent.parent.GetChild(4).GetComponent<roofsurcontrol2>().inig(Ridge_Nick.transform.parent.parent.GetChild(4).GetComponent<roofsurcontrol2>().roofsurface2manage[2]);
        Ridge_Nick.transform.parent.parent.GetChild(4).GetComponent<roofsurcontrol2>().inig(Ridge_Nick.transform.parent.parent.GetChild(4).GetComponent<roofsurcontrol2>().roofsurface2manage[1]);
        Ridge_Nick.transform.parent.parent.GetChild(4).GetComponent<roofsurcontrol2>().inig(Ridge_Nick.transform.parent.parent.GetChild(4).GetComponent<roofsurcontrol2>().roofsurface2manage[3]);

    }


    Vector3 con2posiotion(Vector3 a, Vector3 b)
    {

        return new Vector3((a.x + b.x) / 2, ((a.y + b.y) / 2)-2f, (a.z + b.z) / 2);

    }

    public void rectangle_column(float a,float b)
    {

        GameObject Ridge_Nick = TingPartList[0].transform.GetChild(0).GetChild(0).gameObject;

        print("  cccccc     "+a + "   :  " + b);

        for (int k = 0; k < tower.Count; k++)
        {
            GameObject column_nick = tower[k].transform.GetChild(0).GetChild(1).gameObject;
            GameObject column_BODY_nick = tower[k].transform.GetChild(0).GetChild(2).gameObject;

            

            
            for (int i = 0; i < 4; i++)
            {


                for (int j = 0; j < 4; j++)
                {


                    //column_nick.transform.GetChild(i).GetChild(j).transform.position = new Vector3(percent_1 , column_nick.transform.GetChild(i).GetChild(j).transform.position.y, percent_2 );








                    column_nick.transform.GetChild(i).transform.position = new Vector3(percent_1 + a * Mathf.Cos(45f), column_nick.transform.GetChild(i).transform.position.y, percent_2 + b * Mathf.Cos(45f));

                    column_BODY_nick.transform.GetChild(i).transform.position = new Vector3(percent_1 + a * Mathf.Cos(45f), column_BODY_nick.transform.GetChild(i).transform.position.y, percent_2 + b * Mathf.Cos(45f));
                    

                    /*
                    column_nick.transform.GetChild(i).GetChild(j).transform.Translate(a, 0, b);
                    column_BODY_nick.transform.GetChild(i).GetChild(j).transform.Translate(a, 0, b);

                    */



                }


                column_nick.transform.GetChild(i).GetComponent<catline>().ResetCatmullRom();
                column_nick.transform.GetChild(i).GetComponent<circlecut1>().reset();
                column_nick.transform.GetChild(i).GetComponent<Columntile>().reset();


                column_BODY_nick.transform.GetChild(i).GetComponent<catline>().ResetCatmullRom();
                column_BODY_nick.transform.GetChild(i).GetComponent<circlecut1>().reset();
                column_BODY_nick.transform.GetChild(i).GetComponent<Columntile>().reset();



            }
            
            column_nick.transform.GetChild(0).GetComponent<catline>().ResetCatmullRom();
            column_nick.transform.GetChild(0).GetComponent<circlecut1>().reset();
            column_nick.transform.GetChild(0).GetComponent<Columntile>().reset();


            column_BODY_nick.transform.GetChild(0).GetComponent<catline>().ResetCatmullRom();
            column_BODY_nick.transform.GetChild(0).GetComponent<circlecut1>().reset();
            column_BODY_nick.transform.GetChild(0).GetComponent<Columntile>().reset();
            





            tower[k].transform.GetChild(0).GetChild(1).GetChild(0).GetComponent<ColumnControl>().columnmanage[0].GetComponent<catline>().ResetCatmullRom();
            column_nick.transform.GetChild(0).GetComponent<ColumnControl>().reset();
            column_BODY_nick.transform.GetChild(0).GetComponent<ColumnControl>().reset();


            tower[k].transform.GetChild(3).GetComponent<FC>().reset();
            tower[k].transform.GetChild(2).GetComponent<BC>().reset();



            //上梁
            tower[k].transform.GetChild(6).GetComponent<bigbon>().reset();

            tower[k].transform.GetChild(7).GetComponent<ColumnBody>().reset();
            
          

        }









    }

    public void multi_roof()
    {

        for (int k = 0; k < tower.Count; k++)
        {
            if (tower_roof[k] != null)
            {
                Change_Double_Eave(k);
            }
        }


    }




    public void rectangle_Platform(float a,float b)
    {

        /*
        for(int i=0;i<plat_tower.Count;i++)
        {
            plat_tower[i].transform.GetChild(4).transform.GetChild(0).GetChild(0).transform.Translate(a, 0, b);
            plat_tower[i].transform.GetChild(4).transform.GetChild(0).GetChild(1).transform.Translate(a, 0, b);
            plat_tower[i].transform.GetChild(4).transform.GetChild(0).GetChild(2).transform.Translate(a, 0, b);
            plat_tower[i].transform.GetChild(4).transform.GetChild(0).GetChild(3).transform.Translate(a, 0, b);


            plat_tower[i].transform.GetChild(1).GetComponent<UIcontrol>().setnumberslidervalue();


        }
        */

        for (int i = 0; i < plat_tower.Count; i++)
        {
            plat_tower[i].transform.GetChild(4).transform.GetChild(0).GetChild(0).transform.position = new Vector3(ini_platpoint_0.x +  a * Mathf.Cos(45), plat_tower[i].transform.GetChild(4).transform.GetChild(0).GetChild(0).transform.position.y, ini_platpoint_0.y +  b * Mathf.Cos(45));
            plat_tower[i].transform.GetChild(4).transform.GetChild(0).GetChild(1).transform.position = new Vector3(ini_platpoint_2.x +  a * Mathf.Cos(45), plat_tower[i].transform.GetChild(4).transform.GetChild(0).GetChild(1).transform.position.y, ini_platpoint_2.y +  b * Mathf.Cos(45));
            plat_tower[i].transform.GetChild(4).transform.GetChild(0).GetChild(2).transform.position = new Vector3(ini_platblas.x +  a * Mathf.Cos(45), plat_tower[i].transform.GetChild(4).transform.GetChild(0).GetChild(2).transform.position.y, ini_platblas.y +  b * Mathf.Cos(45));
            plat_tower[i].transform.GetChild(4).transform.GetChild(0).GetChild(3).transform.position = new Vector3(ini_platpoint_1.x +  a * Mathf.Cos(45), plat_tower[i].transform.GetChild(4).transform.GetChild(0).GetChild(3).transform.position.y, ini_platpoint_1.y +  b * Mathf.Cos(45));


            plat_tower[i].transform.GetChild(1).GetComponent<UIcontrol>().setnumberslidervalue();


        }





    }



    //刪除


    public void deleteFrieze()
    {

        TingPartList[1].transform.GetChild(1).GetComponent<UIcontrol>().isb = false;

        TingPartList[1].transform.GetChild(1).GetComponent<UIcontrol>().setnumberslidervalue();
    }

    public void deleteBalustrade()
    {

        TingPartList[1].transform.GetChild(1).GetComponent<UIcontrol>().isf = false;

        TingPartList[1].transform.GetChild(1).GetComponent<UIcontrol>().setnumberslidervalue();
    }

    public void deleteBody()
    {

        TingPartList[1].transform.GetChild(1).GetComponent<UIcontrol>().isCb = false;

        TingPartList[1].transform.GetChild(1).GetComponent<UIcontrol>().setnumberslidervalue();
    }

    public void deleteDoubleRoof()
    {

        for(int i =0;i<tower.Count;i++)
        {

            if (tower[i].name == TingPartList[1].name)
            {
                Destroy(tower_roof[i]);
                tower_roof[i] = null;

                break;
            }



        }



    }



    //rectangle_up
    /*
    public void twolayer()
    {


        Vector3 v1 = new Vector3(TingPartPosition[0].x + 17, TingPartPosition[0].y - 15, TingPartPosition[0].z);


        GameObject clone = Instantiate(Resources.Load("RidgeCctwolayer"), v1, Quaternion.identity) as GameObject;
        
        
        clone.transform.parent = transform;
        clone.transform.GetChild(1).GetComponent<roofcontrol>().numberslider.value = 4;
        
       // TingPartList[0].transform.GetChild(1).GetComponent<roofcontrol>().setnumberslidervalue();
    }
    */



	public void ResetRoof(int a)
	{
		//Destroy(TingPartList[0]);


		Vector3 v1 = new Vector3(TingPartPosition[0].x + 20, TingPartPosition[0].y - 10, TingPartPosition[0].z);

		GameObject clone = Instantiate(Resources.Load("RidgeCc"), v1, Quaternion.identity) as GameObject;

		clone.transform.GetChild(0).GetChild(0).GetChild(0).GetChild(1).transform.Translate(-3, 1, 0);
		clone.transform.GetChild(0).GetChild(0).GetChild(0).GetChild(2).transform.Translate(-3, 1, 0);

		clone.transform.parent = transform;

		//clone.transform.GetChild(1).GetComponent<roofcontrol>().numberslider.value = a;

        clone.transform.GetChild(1).GetComponent<roofcontrol>().numberslidervalue = a;
        clone.transform.GetChild(1).GetComponent<roofcontrol>().setnumberslidervalue();
		//clone.transform.GetChild(1).GetComponent<roofcontrol>().setnumberslidervalue();

		TingPartList[0] = clone;


        GameObject.Find("bao-ding").transform.position = TingPartList[0].transform.GetChild(0).GetChild(0).GetChild(0).GetChild(0).transform.position;



        GameObject Ridge_Nick = TingPartList[0].transform.GetChild(0).GetChild(0).gameObject;

        ini_roof_tall = Vector3.Distance(Ridge_Nick.transform.GetChild(0).GetChild(2).transform.position, Ridge_Nick.transform.GetChild(3).GetChild(2).transform.position) / 2f;
        ini_roof_long = Vector3.Distance(Ridge_Nick.transform.GetChild(0).GetChild(2).transform.position, Ridge_Nick.transform.GetChild(1).GetChild(2).transform.position) / 2f;




    }

	public void ResetBody(int a)
	{

		Destroy(TingPartList[1]);

		GameObject clone = Instantiate(Resources.Load("CC"), TingPartPosition[1], Quaternion.identity) as GameObject;
		clone.transform.parent = transform;





		clone.transform.GetChild(1).GetComponent<UIcontrol>().numberslider.value = a;
		TingPartList[1] = clone;





	}

	public void ResetPlatForm(int a)
	{

		Destroy(TingPartList[2]);

		GameObject clone = Instantiate(Resources.Load("Pt"), TingPartPosition[2], Quaternion.identity) as GameObject;
		clone.transform.parent = transform;

		clone.transform.GetChild(1).GetComponent<UIcontrol>().numberslider.value = a;
		TingPartList[2] = clone;
	}

	public void ResetAll(int a)
	{
        


		ResetRoof(a);
		ResetBody(a);
		ResetPlatForm(a);

        GameObject.Find("bao-ding").transform.position = TingPartList[0].transform.GetChild(0).GetChild(0).GetChild(0).GetChild(0).transform.position;

        GameObject Ridge_Nick = TingPartList[0].transform.GetChild(0).GetChild(0).gameObject;

        ini_roof_tall = Vector3.Distance(Ridge_Nick.transform.GetChild(0).GetChild(2).transform.position, Ridge_Nick.transform.GetChild(3).GetChild(2).transform.position) / 2f;
        ini_roof_long = Vector3.Distance(Ridge_Nick.transform.GetChild(0).GetChild(2).transform.position, Ridge_Nick.transform.GetChild(1).GetChild(2).transform.position) / 2f;


	}

    //this 

	public void UpdateAll(int a)
	{
       
        //TingPartList[0].transform.GetChild(1).GetComponent<roofcontrol>().numberslider.value = a;
        TingPartList[0].transform.GetChild(1).GetComponent<roofcontrol>().numberslidervalue = a;
         TingPartList[0].transform.GetChild(1).GetComponent<roofcontrol>().setnumberslidervalue();
      
        for (int i = 0; i < tower.Count ;i++ )
        {


            tower[i].transform.GetChild(1).GetComponent<UIcontrol>().numberslider.value = a;
            if (tower_roof[i] != null)
            {


                tower[i].transform.GetChild(0).GetChild(2).GetChild(0).GetComponent<ColumnControl>().reset();

                tower[i].transform.GetChild(7).GetComponent<ColumnBody>().reset();


                Change_Double_Eave(i);
            }
        }



        for (int i = 0; i < plat_tower.Count; i++)
        {
            plat_tower[i].transform.GetChild(1).GetComponent<UIcontrol>().numberslider.value = a;
        }



        GameObject.Find("bao-ding").transform.position = TingPartList[0].transform.GetChild(0).GetChild(0).GetChild(0).GetChild(0).transform.position;
        GameObject Ridge_Nick = TingPartList[0].transform.GetChild(0).GetChild(0).gameObject;
        

        if(a==4)
        { 
        ini_roof_tall = Vector3.Distance(Ridge_Nick.transform.GetChild(0).GetChild(2).transform.position, Ridge_Nick.transform.GetChild(3).GetChild(2).transform.position) / 2f;
        ini_roof_long = Vector3.Distance(Ridge_Nick.transform.GetChild(0).GetChild(2).transform.position, Ridge_Nick.transform.GetChild(1).GetChild(2).transform.position) / 2f;
        }
    
    }



	


	//formfactor



	//roof
    public void ChangeRoof_Roofchild_one()
    {

        TingPartList[0].transform.GetChild(0).GetChild(0).GetChild(0).GetChild(0).transform.Translate(2, 0, 0);
        TingPartList[0].transform.GetChild(1).GetComponent<roofcontrol>().setnumberslidervalue();

    }




	public void UpdateRoof()
	{

       TingPartList[0].transform.GetChild(1).GetComponent<roofcontrol>().setnumberslidervalue();



	}

    public void MoveRoof_Cp1(Vector2 a)
    {

        TingPartList[0].transform.GetChild(0).GetChild(0).GetChild(0).GetChild(0).transform.Translate(Roof_Wide_Percent*a.x, Roof_Height_Percent * a.y, 0);

        TingPartList[0].transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<RidgeControl>().ridgemanage[0].GetComponent<catline>().ResetCatmullRom();
        TingPartList[0].transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<RidgeControl>().reset();
        //TingPartList[0].transform.GetChild(1).GetComponent<roofcontrol>().setnumberslidervalue();
    
    }
    public void MoveRoof_Cp2(Vector2 a)
    {

        TingPartList[0].transform.GetChild(0).GetChild(0).GetChild(0).GetChild(1).transform.Translate(Roof_Wide_Percent * a.x, Roof_Height_Percent * a.y, 0);

        TingPartList[0].transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<RidgeControl>().ridgemanage[0].GetComponent<catline>().ResetCatmullRom();
        TingPartList[0].transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<RidgeControl>().reset();
        

        //TingPartList[0].transform.GetChild(1).GetComponent<roofcontrol>().setnumberslidervalue();
    
    }
    public void MoveRoof_Cp3(Vector2 a)
    {
        //ridge
        TingPartList[0].transform.GetChild(0).GetChild(0).GetChild(0).GetChild(2).transform.Translate(Roof_Wide_Percent * a.x, Roof_Height_Percent * a.y, 0);
        //ridgetail
        TingPartList[0].transform.GetChild(0).GetChild(1).GetChild(0).transform.Translate(Roof_Wide_Percent * a.x, Roof_Height_Percent * a.y, 0);


        //ridge
        TingPartList[0].transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<RidgeControl>().ridgemanage[0].GetComponent<catline>().ResetCatmullRom();
        TingPartList[0].transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<RidgeControl>().reset();


        //ridgetail
        TingPartList[0].transform.GetChild(0).GetChild(1).GetChild(0).GetComponent<RidgetailControl>().ridgetailmanage[0].GetComponent<catline>().ResetCatmullRom();
        TingPartList[0].transform.GetChild(0).GetChild(1).GetChild(0).GetComponent<RidgetailControl>().reset();




        //TingPartList[0].transform.GetChild(1).GetComponent<roofcontrol>().setnumberslidervalue();
    
    }








	//body

   
	public IEnumerator MoveBody(float a)
	{

        Vector3 arrow = TingPartList[1].transform.GetChild(0).GetChild(1).GetChild(0).GetChild(3).transform.position-this.transform.GetChild(0).transform.position;



        Vector3 arrow2 = Vector3.Normalize(arrow);

      

        /*
        TingPartList[1].transform.GetChild(0).GetChild(1).GetChild(0).transform.position = new Vector3(TingPartList[1].transform.GetChild(0).GetChild(1).GetChild(0).transform.position.x + ((1 / percent) * a * arrow2.x), TingPartList[1].transform.GetChild(0).GetChild(1).GetChild(0).transform.position.y, TingPartList[1].transform.GetChild(0).GetChild(1).GetChild(0).transform.position.z + ((1 / percent) * a * arrow2.z));



        if (TingPartList[1].transform.GetChild(1).GetComponent<UIcontrol>().isCb == false)
        {
            TingPartList[1].transform.GetChild(0).GetChild(2).GetChild(0).transform.position = new Vector3(TingPartList[1].transform.GetChild(0).GetChild(2).GetChild(0).transform.position.x + ((1 / percent) * a * arrow2.x), TingPartList[1].transform.GetChild(0).GetChild(2).GetChild(0).transform.position.y, TingPartList[1].transform.GetChild(0).GetChild(2).GetChild(0).transform.position.z + ((1 / percent) * a * arrow2.z));
        }
        
        */

        /*
        print("~AAAAA~    " + arrow2);
        print("~~~~~~~~~~~~    "+a);
        print(arrow2.x);
        print(arrow2.z);
        */




        if(Rectangle_Or_Not==false)
        { 
        TingPartList[1].transform.GetChild(0).GetChild(1).GetChild(0).transform.position = new Vector3(percent_1 + percentdis * (a - 1) * arrow2.x, TingPartList[1].transform.GetChild(0).GetChild(1).GetChild(0).transform.position.y, percent_2 + percentdis * (a - 1) * arrow2.z);



        //TingPartList[1].transform.GetChild(0).GetChild(1).GetChild(0).transform.position = new Vector3(percent_1*2, TingPartList[1].transform.GetChild(0).GetChild(1).GetChild(0).transform.position.y, percent_2 *2);
        if (TingPartList[1].transform.GetChild(1).GetComponent<UIcontrol>().isCb == false)
        {

            //TingPartList[1].transform.GetChild(0).GetChild(2).GetChild(0).transform.position = new Vector3(percent_1 + ((percentdis) * (a - 1) * arrow2.x), TingPartList[1].transform.GetChild(0).GetChild(2).GetChild(0).transform.position.y, percent_2 + percentdis * (a - 1) * arrow2.z);

            TingPartList[1].transform.GetChild(0).GetChild(2).GetChild(0).transform.position = new Vector3(percent_1 + ((arrow.magnitude) * (a - 1) * arrow2.x), TingPartList[1].transform.GetChild(0).GetChild(2).GetChild(0).transform.position.y, percent_2 + arrow.magnitude * (a - 1) * arrow2.z);
       
        
        
        }

        }
        else
        {
            TingPartList[1].transform.GetChild(0).GetChild(1).GetChild(0).transform.position = new Vector3(percent_1_rec + percentdis * (a - 1) * arrow2.x, TingPartList[1].transform.GetChild(0).GetChild(1).GetChild(0).transform.position.y, percent_2_rec + percentdis * (a - 1) * arrow2.z);



            //TingPartList[1].transform.GetChild(0).GetChild(1).GetChild(0).transform.position = new Vector3(percent_1*2, TingPartList[1].transform.GetChild(0).GetChild(1).GetChild(0).transform.position.y, percent_2 *2);
            if (TingPartList[1].transform.GetChild(1).GetComponent<UIcontrol>().isCb == false)
            {
                TingPartList[1].transform.GetChild(0).GetChild(2).GetChild(0).transform.position = new Vector3(percent_1_rec + ((percentdis) * (a - 1) * arrow2.x), TingPartList[1].transform.GetChild(0).GetChild(2).GetChild(0).transform.position.y, percent_2_rec + percentdis * (a - 1) * arrow2.z);



            }

        }







        //*************
		TingPartList[1].transform.GetChild(0).GetChild(1).GetChild(0).GetComponent<ColumnControl>().columnmanage[0].GetComponent<catline>().ResetCatmullRom();
		TingPartList[1].transform.GetChild(0).GetChild(1).GetChild(0).GetComponent<ColumnControl>().reset();


        
            TingPartList[1].transform.GetChild(0).GetChild(2).GetChild(0).GetComponent<ColumnControl>().columnmanage[0].GetComponent<catline>().ResetCatmullRom();
            TingPartList[1].transform.GetChild(0).GetChild(2).GetChild(0).GetComponent<ColumnControl>().reset();
        if (TingPartList[1].transform.GetChild(1).GetComponent<UIcontrol>().isCb == true)
        {
            TingPartList[1].transform.GetChild(7).GetComponent<ColumnBody>().reset();
        }

        TingPartList[1].transform.GetChild(1).GetComponent<UIcontrol>().setnumberslidervalue();

        //new


        if (TingPartList[1].transform.GetChild(1).GetComponent<UIcontrol>().isf == true)
        {
            TingPartList[1].transform.GetChild(3).GetComponent<FC>().reset();
        }

        if (TingPartList[1].transform.GetChild(1).GetComponent<UIcontrol>().isb == true)
        {
            TingPartList[1].transform.GetChild(2).GetComponent<BC>().reset();
        }

        //上梁

        
        TingPartList[1].transform.GetChild(6).GetComponent<bigbon>().reset();

        yield return 0;

	}


    public void Move_F(float a,float b)
    {

        if (TingPartList[1].transform.GetChild(1).GetComponent<UIcontrol>().isb == true)
        {
            TingPartList[1].transform.GetChild(0).GetChild(1).GetChild(0).GetChild(1).transform.position = new Vector3(TingPartList[1].transform.GetChild(0).GetChild(1).GetChild(0).GetChild(1).transform.position.x, TingPartList[1].transform.GetChild(0).GetChild(1).GetChild(0).GetChild(0).transform.position.y - ((a / b) * columntall), TingPartList[1].transform.GetChild(0).GetChild(1).GetChild(0).GetChild(1).transform.position.z);
        }

      }

    public void Move_B(float a, float b)
    {

        if (TingPartList[1].transform.GetChild(1).GetComponent<UIcontrol>().isf == true)
        {
            TingPartList[1].transform.GetChild(0).GetChild(1).GetChild(0).GetChild(2).transform.position = new Vector3(TingPartList[1].transform.GetChild(0).GetChild(1).GetChild(0).GetChild(2).transform.position.x, TingPartList[1].transform.GetChild(0).GetChild(1).GetChild(0).GetChild(3).transform.position.y + ((a / b) * columntall), TingPartList[1].transform.GetChild(0).GetChild(1).GetChild(0).GetChild(2).transform.position.z);
        }
    }




    public void UpdateBody_F(bool a)
    {

        print("#$@#$@#$@#$@$@#$@#$@$@#$@#$  "+a);

        TingPartList[1].transform.GetChild(1).GetComponent<UIcontrol>().isf = a;
        TingPartList[1].transform.GetChild(1).GetComponent<UIcontrol>().setnumberslidervalue();
        


    }
    public void UpdateBody_B(bool a)
    {

        TingPartList[1].transform.GetChild(1).GetComponent<UIcontrol>().isb = a;
        TingPartList[1].transform.GetChild(1).GetComponent<UIcontrol>().setnumberslidervalue();
        

    }



    public void moveBOBODY(float a)
    {





        if (TingPartList[1].transform.GetChild(1).GetComponent<UIcontrol>().isCb == true)
        {
           // TingPartList[1].transform.GetChild(0).GetChild(2).GetChild(0).transform.Translate((1 / percent2) * a, 0, 0);
        }





        TingPartList[1].transform.GetChild(0).GetChild(2).GetChild(0).GetComponent<ColumnControl>().columnmanage[0].GetComponent<catline>().ResetCatmullRom();
        TingPartList[1].transform.GetChild(0).GetChild(2).GetChild(0).GetComponent<ColumnControl>().reset();
        if (TingPartList[1].transform.GetChild(1).GetComponent<UIcontrol>().isCb == true)
        {
            TingPartList[1].transform.GetChild(7).GetComponent<ColumnBody>().reset();
        }



      }



    public void bodytall(float a)
    {

        

        TingPartList[0].transform.Translate(0, (columntall)*a, 0);


        for (int i = 0; i < tower.Count; i++)
        {
            if (TingPartList[1].name == tower[i].name)
            {

                for (int j = i+1; j < tower.Count; j++)
                {
                    tower[j].transform.Translate(0, (columntall) * a, 0);
                    if (tower_roof[j - 1]!=null)
                    tower_roof[j-1].transform.Translate(0, (columntall) * a, 0);
                }


                TingPartList[1].transform.GetChild(0).GetChild(1).GetChild(0).GetChild(0).transform.Translate(0, (columntall) * a, 0);
                TingPartList[1].transform.GetChild(0).GetChild(1).GetChild(0).GetChild(1).transform.Translate(0, (columntall) * a, 0);

                TingPartList[1].transform.GetChild(0).GetChild(2).GetChild(0).GetChild(0).transform.Translate(0, (columntall) * a, 0);
                TingPartList[1].transform.GetChild(0).GetChild(2).GetChild(0).GetChild(1).transform.Translate(0, (columntall) * a, 0);



                break;
            }

        }

        TingPartList[1].transform.GetChild(1).GetComponent<UIcontrol>().setnumberslidervalue();
        columntall = TingPartList[1].transform.GetChild(0).GetChild(1).GetChild(0).GetComponent<ColumnControl>().ColumnLong;


        GameObject.Find("bao-ding").transform.position = TingPartList[0].transform.GetChild(0).GetChild(0).GetChild(0).GetChild(0).transform.position;


        
    }

    public void window(float a, float b)
    {

        TingPartList[1].transform.GetChild(7).GetComponent<ColumnBody>().up = a;
        TingPartList[1].transform.GetChild(7).GetComponent<ColumnBody>().down = b;

        TingPartList[1].transform.GetChild(1).GetComponent<UIcontrol>().setnumberslidervalue();
    }



	//platform
	public void paraplat(float a, float b)
	{

		TingPartList[2].transform.GetChild(2).GetComponent<PlatForm>().parareset((platpercent) * a, (platpercent) * b);



	}


    public void moveplatform(float a,float b,float c)
    {
        //注意
        print(a+" + "+c);


        //Vector3 arrow = TingPartList[2].transform.GetChild(4).GetChild(0).GetChild(0).transform.position - this.transform.GetChild(0).transform.position;
        Vector3 arrow = new Vector3(1, 0, 0);
        Vector3 arrow2 = Vector3.Normalize(arrow);

        
        b = 1;
        /*
        TingPartList[2].transform.GetChild(4).GetChild(0).GetChild(0).transform.Translate((ini_platwide) * a * arrow2.x, b * (ini_plathigh), (ini_platwide) * a * arrow2.z);
        TingPartList[2].transform.GetChild(4).GetChild(0).GetChild(1).transform.Translate((ini_platwide) * c * arrow2.x, -b * (ini_plathigh), (ini_platwide) * c * arrow2.z);
        TingPartList[2].transform.GetChild(4).GetChild(0).GetChild(2).transform.Translate((ini_platwide) * a * arrow2.x, b * (ini_plathigh), (ini_platwide) * a * arrow2.z);
        */


        if(Rectangle_Or_Not==false)
        { 
        TingPartList[2].transform.GetChild(4).GetChild(0).GetChild(0).transform.position = new Vector3(ini_platpoint_0.x + ini_platpoint_0.magnitude * (a - 1) * arrow2.x, TingPartList[2].transform.GetChild(4).GetChild(0).GetChild(0).transform.position.y, ini_platpoint_0.y + ini_platpoint_0.magnitude*(a-1) * arrow2.z);
        TingPartList[2].transform.GetChild(4).GetChild(0).GetChild(2).transform.position = new Vector3(ini_platblas.x + ini_platblas.magnitude * (a - 1) * arrow2.x, TingPartList[2].transform.GetChild(4).GetChild(0).GetChild(2).transform.position.y, ini_platblas.y + ini_platblas.magnitude * (a-1) * arrow2.z);
        
        TingPartList[2].transform.GetChild(4).GetChild(0).GetChild(1).transform.position = new Vector3(ini_platpoint_2.x + ini_platpoint_2.magnitude * (c - 1) * arrow2.x, TingPartList[2].transform.GetChild(4).GetChild(0).GetChild(1).transform.position.y, ini_platpoint_2.y + ini_platpoint_2.magnitude * (c-1) * arrow2.z);
        }
        else
        {
            TingPartList[2].transform.GetChild(4).GetChild(0).GetChild(0).transform.position = new Vector3(platpoint_0_rec.x + platpoint_0_rec.magnitude * (a - 1) * arrow2.x, TingPartList[2].transform.GetChild(4).GetChild(0).GetChild(0).transform.position.y, platpoint_0_rec.y + platpoint_0_rec.magnitude * (a-1) * arrow2.z);
            TingPartList[2].transform.GetChild(4).GetChild(0).GetChild(2).transform.position = new Vector3(platblas_rec.x + platblas_rec.magnitude * (a - 1) * arrow2.x, TingPartList[2].transform.GetChild(4).GetChild(0).GetChild(2).transform.position.y, platblas_rec.y + platblas_rec.magnitude * (a-1) * arrow2.z);

            TingPartList[2].transform.GetChild(4).GetChild(0).GetChild(1).transform.position = new Vector3(platpoint_2_rec.x + platpoint_2_rec.magnitude * (c - 1) * arrow2.x, TingPartList[2].transform.GetChild(4).GetChild(0).GetChild(1).transform.position.y, platpoint_2_rec.y + platpoint_2_rec.magnitude * (c-1) * arrow2.z);


        }


        
        
        
        
        
        
        TingPartList[2].transform.GetChild(4).GetChild(0).GetChild(3).transform.position = halfposition(TingPartList[2].transform.GetChild(4).GetChild(0).GetChild(0).transform.position, TingPartList[2].transform.GetChild(4).GetChild(0).GetChild(1).transform.position);


        TingPartList[2].transform.GetChild(4).GetComponent<PlatcolumnControl>().reset();
        /*
        TingPartList[0].transform.Translate(0, b * (ini_plathigh), 0);

        
        for (int i = 0; i < tower.Count; i++)
        {
            

               
                    tower[i].transform.Translate(0, b * (ini_plathigh), 0);
                    if (tower_roof[i] != null)
                        tower_roof[i].transform.Translate(0, b * (ini_plathigh), 0);
                
        }


        for (int i = 0; i < plat_tower.Count; i++)
        {
            if (TingPartList[2].name == plat_tower[i].name)
            {

                for (int j = i+1; j < plat_tower.Count; j++)
                {
                    plat_tower[j].transform.Translate(0, b * (ini_plathigh), 0);
                    print("haha");
                }



                for (int j = i - 1; j >=0; j--)
                {
                    plat_tower[j].transform.Translate(0, -b * (ini_plathigh), 0);
                    print("haha2");
                }

                break;
            }

        }

        */


        GameObject.Find("bao-ding").transform.position = TingPartList[0].transform.GetChild(0).GetChild(0).GetChild(0).GetChild(0).transform.position;


    }


    public Vector3 halfposition(Vector3 a,Vector3 b)
    {


        Vector3  c = (a + b) / 2;

        return c;

    }




    public void changplatblaustrade(float a,float b)
    {
        Vector3 arrow = TingPartList[2].transform.GetChild(4).GetChild(0).GetChild(0).transform.position - this.transform.GetChild(0).transform.position;

        Vector3 arrow2 = Vector3.Normalize(arrow);

        //TingPartList[2].transform.GetChild(4).GetChild(0).GetChild(0).transform.Translate((ini_platwide) * a * arrow2.x, b * (ini_plathigh), (ini_platwide) * a * arrow2.z);
        
        TingPartList[2].transform.GetChild(4).GetChild(0).GetChild(2).transform.Translate((ini_platwide) * a * arrow2.x, b * (ini_plathigh), (ini_platwide) * a * arrow2.z);


       

        TingPartList[2].transform.GetChild(4).GetComponent<PlatcolumnControl>().reset();

    }

    public void changeplatlayer(int a)
    {
        TingPartList[2] = plat_tower[a];
        inUseTab = a;


        //columntall = TingPartList[2].transform.GetChild(4).GetComponent<ColumnControl>().ColumnLong;

    }




    public void deleteplatlayer(int a)
    {
        TingPartList[2] = plat_tower[a];
        inUseTab = a;


        columntall = plat_tower[a].transform.GetChild(4).GetComponent<PlatcolumnControl>().high;



        TingPartList[0].transform.Translate(0, -columntall, 0);



        for (int i = 0; i < tower.Count; i++)
        {

            tower[i].transform.Translate(0, -columntall, 0);
            if (tower_roof[i]!=null)
            tower_roof[i].transform.Translate(0, -columntall, 0);
              

           
        }


        for (int i = 0; i < plat_tower.Count; i++)
        {
            if (TingPartList[2].name == plat_tower[i].name)
            {

                for (int j = i + 1; j < plat_tower.Count; j++)
                {
                    plat_tower[j].transform.Translate(0, -columntall, 0);
                    print("haha");
                }

                /*
                for (int j = i - 1; j >= 0; j--)
                {
                    plat_tower[j].transform.Translate(0, -columntall, 0);
                    print("haha2");
                }

                */

                break;
            }

        }


        plat_tower.Remove(plat_tower[a]);


        Destroy(TingPartList[2].gameObject);



        GameObject.Find("bao-ding").transform.position = TingPartList[0].transform.GetChild(0).GetChild(0).GetChild(0).GetChild(0).transform.position;
        
        if (a != 0)
        {

            TingPartList[2] = plat_tower[a - 1];
            inUseTab = a - 1;
        }
        else
        {
            TingPartList[2] = plat_tower[a];
            inUseTab = a;


        }

    }

 


    public void platblas(bool a)
    {


        TingPartList[2].transform.GetChild(4).GetComponent<PlatcolumnControl>().B=a;
        TingPartList[2].transform.GetChild(4).GetComponent<PlatcolumnControl>().reset();

    }

   public void platstair(bool a)
    {
        if (TingPartList[2].transform.GetChild(4).GetComponent<PlatcolumnControl>().B==true)
        { 
        TingPartList[2].transform.GetChild(4).GetComponent<PlatcolumnControl>().S = a;
        TingPartList[2].transform.GetChild(4).GetComponent<PlatcolumnControl>().reset();
        }
    }


    public void delete_platblas()
   {
       TingPartList[2].transform.GetChild(4).GetComponent<PlatcolumnControl>().B = false;
       TingPartList[2].transform.GetChild(4).GetComponent<PlatcolumnControl>().S = false;
       TingPartList[2].transform.GetChild(4).GetComponent<PlatcolumnControl>().reset();

   }

    public void delete_platstair()
    {
        TingPartList[2].transform.GetChild(4).GetComponent<PlatcolumnControl>().S = false;
        TingPartList[2].transform.GetChild(4).GetComponent<PlatcolumnControl>().reset();

    }





}
