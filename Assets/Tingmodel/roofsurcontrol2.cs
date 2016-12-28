using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class roofsurcontrol2 : MonoBehaviour {

    public List<GameObject> roofsurface2manage = new List<GameObject>();
    public RidgeControl ridgeControl;
    public roofsurcontrol roofcon;
    public EaveControl eaveControl;
    public roofsurcon2control roofcon2;

    public upridge up;

    public roofcontrol uict;

    /*
    public List<Vector3> ridgepoint = new List<Vector3>();
    public List<Vector3> ridgepoint2 = new List<Vector3>();
    public List<Vector3> midpoint = new List<Vector3>();
    public List<Vector3> eavepoint = new List<Vector3>();
    public List<Vector3> eavepoint2 = new List<Vector3>();
    */
    public Plane plane;

    public int linen ;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}






    public void iniwiththree(Vector3 a,Vector3 b,Vector3 c )
    {
        linen = uict.twvalue;
        Vector3 bornx = new Vector3(0, 0, 0);
        Vector3 born = new Vector3(0, 0, 0);
        Vector3 born2 = new Vector3(0, 0, 0);
        Vector3 born3 = new Vector3(0, 0, 0);

        GameObject roofsur2 = new GameObject();
        roofsur2.transform.parent = this.transform;
        roofsur2.name = ("roofsurface1");

        ridgeControl.ridgemanage[0].GetComponent<catline>();




        Vector3 v1 = ridgeControl.ridgemanage[0].transform.GetChild(0).transform.position;
        Vector3 v2 = ridgeControl.ridgemanage[0].transform.GetChild(2).transform.position;
        Vector3 v3 = ridgeControl.ridgemanage[1].transform.GetChild(2).transform.position;



        plane.Set3Points(roofcon.roofsurfacemanage[0].transform.GetChild(2).transform.position, roofcon.roofsurfacemanage[0].transform.GetChild(1).transform.position, roofcon.roofsurfacemanage[0].transform.GetChild(0).transform.position);

        plane.normal = v2 - v3;

        //plane.SetNormalAndPosition(plane.normal, roofcon.roofsurfacemanage[0].transform.GetChild(0).transform.position);

        Vector3 tilewide = plane.normal / (linen * 2);
        float twide = tilewide.magnitude;

        plane.SetNormalAndPosition(plane.normal, roofcon.roofsurfacemanage[0].transform.GetChild(0).transform.position + (tilewide * 0));

        for (int i = 1; i < linen; i++)
        {



            //Right

            GameObject lineR = new GameObject();
            lineR.AddComponent<catline>();
            lineR.transform.parent = roofsur2.transform;

            float min = 1000;
            float min2 = 1000;
            float min3 = 1000;


            plane.SetNormalAndPosition(plane.normal, roofcon.roofsurfacemanage[0].transform.GetChild(0).transform.position + (tilewide * i));




            if (uict.upridge == true)
            {
                for (int j = 0; j < up.upridgemanage[0].GetComponent<catline>().innerPointList.Count; j++)
                {

                    if (Mathf.Abs(plane.GetDistanceToPoint(up.upridgemanage[0].GetComponent<catline>().innerPointList[j])) < min2)
                    {

                        min2 = Mathf.Abs(plane.GetDistanceToPoint(up.upridgemanage[0].GetComponent<catline>().innerPointList[j]));
                        bornx = up.upridgemanage[0].GetComponent<catline>().innerPointList[j];
                    }
                    else { break; }
                }
                for (int j = 0; j < ridgeControl.ridgemanage[0].GetComponent<catline>().innerPointList.Count; j++)
                {

                    if (Mathf.Abs(plane.GetDistanceToPoint(ridgeControl.ridgemanage[0].GetComponent<catline>().innerPointList[j])) < min)
                    {


                        min = Mathf.Abs(plane.GetDistanceToPoint(ridgeControl.ridgemanage[0].GetComponent<catline>().innerPointList[j]));
                        born = ridgeControl.ridgemanage[0].GetComponent<catline>().innerPointList[j];
                    }
                    else { break; }
                }

                if (min2 < min)
                {
                    born = bornx;
                }

            }
            else
            {
                for (int j = 0; j < ridgeControl.ridgemanage[0].GetComponent<catline>().innerPointList.Count; j++)
                {

                    if (Mathf.Abs(plane.GetDistanceToPoint(ridgeControl.ridgemanage[0].GetComponent<catline>().innerPointList[j])) < min)
                    {


                        min = Mathf.Abs(plane.GetDistanceToPoint(ridgeControl.ridgemanage[0].GetComponent<catline>().innerPointList[j]));
                        born = ridgeControl.ridgemanage[0].GetComponent<catline>().innerPointList[j];
                    }
                    else { break; }
                }


            }


            GameObject r1 = new GameObject();
            r1.transform.parent = lineR.transform;
            r1.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
            r1.transform.position = born;



            GameObject r2 = new GameObject();
            r2.transform.parent = lineR.transform;
            r2.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
            r2.transform.position = roofcon2.rrrRL[0].transform.GetChild(0).transform.GetChild(i - 1).transform.position;


            for (int j = 0; j < eaveControl.eavemanage[0].GetComponent<catline>().innerPointList.Count; j++)
            {
                if (Mathf.Abs(plane.GetDistanceToPoint(eaveControl.eavemanage[0].GetComponent<catline>().innerPointList[j])) < min3)
                {
                    min3 = Mathf.Abs(plane.GetDistanceToPoint(eaveControl.eavemanage[0].GetComponent<catline>().innerPointList[j]));
                    born3 = eaveControl.eavemanage[0].GetComponent<catline>().innerPointList[j];
                }
                else { break; }
            }


            GameObject r3 = new GameObject();
            r3.transform.parent = lineR.transform;
            r3.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
            r3.transform.position = born3;

            lineR.GetComponent<catline>().AddControlPoint(r3);
            lineR.GetComponent<catline>().AddControlPoint(r2);
            lineR.GetComponent<catline>().AddControlPoint(r1);



            lineR.GetComponent<catline>().ResetCatmullRom();
            //lineR.GetComponent<LineRenderer>().material = new Material(Shader.Find("GUI/Text Shader"));
            lineR.GetComponent<LineRenderer>().SetColors(Color.yellow, Color.yellow);


            lineR.AddComponent<newplanecut>();
            lineR.AddComponent<newtiled>();
            //Left

            GameObject lineL = new GameObject();
            lineL.AddComponent<catline>();
            lineL.transform.parent = roofsur2.transform;

            float minL = 1000;
            float min2L = 1000;
            float min3L = 1000;


            plane.SetNormalAndPosition(plane.normal, roofcon.roofsurfacemanage[0].transform.GetChild(0).transform.position - (tilewide * i));

            //print(" sos : pd "+plane.distance);


            if (uict.upridge == true)
            {
                for (int j = 0; j < up.upridgemanage[0].GetComponent<catline>().innerPointList.Count; j++)
                {

                    if (Mathf.Abs(plane.GetDistanceToPoint(up.upridgemanage[0].GetComponent<catline>().innerPointList[j])) < min2L)
                    {


                        min2L = Mathf.Abs(plane.GetDistanceToPoint(up.upridgemanage[0].GetComponent<catline>().innerPointList[j]));
                        bornx = up.upridgemanage[0].GetComponent<catline>().innerPointList[j];
                    }
                    else { break; }
                }
                for (int j = 0; j < ridgeControl.ridgemanage[1].GetComponent<catline>().innerPointList.Count; j++)
                {
                    //print(i + " : " + Mathf.Abs(plane.GetDistanceToPoint(ridgeControl.ridgemanage[0].GetComponent<catline>().innerPointList[j])));
                    if (Mathf.Abs(plane.GetDistanceToPoint(ridgeControl.ridgemanage[1].GetComponent<catline>().innerPointList[j])) < minL)
                    {
                        //print(i+" : "+Mathf.Abs(plane.GetDistanceToPoint(ridgeControl.ridgemanage[0].GetComponent<catline>().innerPointList[j])));

                        minL = Mathf.Abs(plane.GetDistanceToPoint(ridgeControl.ridgemanage[1].GetComponent<catline>().innerPointList[j]));
                        born = ridgeControl.ridgemanage[1].GetComponent<catline>().innerPointList[j];
                    }
                    else { break; }
                }

                if (min2L < minL)
                {
                    born = bornx;
                }

            }
            else
            {
                for (int j = 0; j < ridgeControl.ridgemanage[1].GetComponent<catline>().innerPointList.Count; j++)
                {
                    //print(i + " : " + Mathf.Abs(plane.GetDistanceToPoint(ridgeControl.ridgemanage[0].GetComponent<catline>().innerPointList[j])));
                    if (Mathf.Abs(plane.GetDistanceToPoint(ridgeControl.ridgemanage[1].GetComponent<catline>().innerPointList[j])) < minL)
                    {
                        //print(i+" : "+Mathf.Abs(plane.GetDistanceToPoint(ridgeControl.ridgemanage[0].GetComponent<catline>().innerPointList[j])));

                        minL = Mathf.Abs(plane.GetDistanceToPoint(ridgeControl.ridgemanage[1].GetComponent<catline>().innerPointList[j]));
                        born = ridgeControl.ridgemanage[1].GetComponent<catline>().innerPointList[j];
                    }
                    else { break; }
                }


            }




            GameObject r1L = new GameObject();
            r1L.transform.parent = lineL.transform;
            r1L.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
            r1L.transform.position = born;



            GameObject r2L = new GameObject();
            r2L.transform.parent = lineL.transform;
            r2L.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
            r2L.transform.position = roofcon2.rrrRL[0].transform.GetChild(1).transform.GetChild(i - 1).transform.position;


            for (int j = 0; j < eaveControl.eavemanage[0].GetComponent<catline>().innerPointList.Count; j++)
            {
                if (Mathf.Abs(plane.GetDistanceToPoint(eaveControl.eavemanage[0].GetComponent<catline>().innerPointList[j])) < min3L)
                {
                    min3L = Mathf.Abs(plane.GetDistanceToPoint(eaveControl.eavemanage[0].GetComponent<catline>().innerPointList[j]));
                    born3 = eaveControl.eavemanage[0].GetComponent<catline>().innerPointList[j];
                }
                else { break; }
            }


            GameObject r3L = new GameObject();
            r3L.transform.parent = lineL.transform;
            r3L.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
            r3L.transform.position = born3;

            lineL.GetComponent<catline>().AddControlPoint(r3L);
            lineL.GetComponent<catline>().AddControlPoint(r2L);
            lineL.GetComponent<catline>().AddControlPoint(r1L);



            lineL.GetComponent<catline>().ResetCatmullRom();
            //lineL.GetComponent<LineRenderer>().material = new Material(Shader.Find("GUI/Text Shader"));
            lineL.GetComponent<LineRenderer>().SetColors(Color.yellow, Color.yellow);

            lineL.AddComponent<newplanecut>();
            lineL.AddComponent<newtiledL>();



        }
        roofsurface2manage.Add(roofsur2);
    }


    public void ini()
    {
        linen = uict.twvalue;

        //linen = Mathf.RoundToInt(Vector3.Distance(ridgecon.ridgemanage[0].transform.GetChild(2).transform.position, ridgecon.ridgemanage[1].transform.GetChild(2).transform.position) / 2);

        linen = Mathf.RoundToInt(Vector3.Distance(ridgeControl.ridgemanage[0].transform.GetChild(2).transform.position, ridgeControl.ridgemanage[1].transform.GetChild(2).transform.position) / 2);



        Vector3 bornx = new Vector3(0, 0, 0);
        Vector3 born = new Vector3(0, 0, 0);
        Vector3 born2 = new Vector3(0, 0, 0);
        Vector3 born3 = new Vector3(0, 0, 0);

        GameObject roofsur2 = new GameObject();
        roofsur2.transform.parent = this.transform;
        roofsur2.name=("roofsurface1");

        ridgeControl.ridgemanage[0].GetComponent<catline>();




        Vector3 v1 = ridgeControl.ridgemanage[0].transform.GetChild(0).transform.position;
        Vector3 v2 = ridgeControl.ridgemanage[0].transform.GetChild(2).transform.position;
        Vector3 v3 = ridgeControl.ridgemanage[1].transform.GetChild(2).transform.position;



        plane.Set3Points(roofcon.roofsurfacemanage[0].transform.GetChild(2).transform.position, roofcon.roofsurfacemanage[0].transform.GetChild(1).transform.position, roofcon.roofsurfacemanage[0].transform.GetChild(0).transform.position);

        plane.normal = v2 - v3;

        //plane.SetNormalAndPosition(plane.normal, roofcon.roofsurfacemanage[0].transform.GetChild(0).transform.position);

        Vector3 tilewide = plane.normal / (linen * 2);
        float twide = tilewide.magnitude;

        plane.SetNormalAndPosition(plane.normal, roofcon.roofsurfacemanage[0].transform.GetChild(0).transform.position + (tilewide * 0));

        for (int i = 1; i < linen; i++)
        {



            //Right

            GameObject lineR = new GameObject();
            lineR.AddComponent<catline>();
            lineR.transform.parent = roofsur2.transform;

            float min = 1000;
            float min2 = 1000;
            float min3 = 1000;

           
                plane.SetNormalAndPosition(plane.normal, roofcon.roofsurfacemanage[0].transform.GetChild(0).transform.position + (tilewide * i));
            
            

          
            if (uict.upridge==true)
            {
                for (int j = 0; j < up.upridgemanage[0].GetComponent<catline>().innerPointList.Count; j++)
                {

                    if (Mathf.Abs(plane.GetDistanceToPoint(up.upridgemanage[0].GetComponent<catline>().innerPointList[j])) < min2)
                    {


                        min2 = Mathf.Abs(plane.GetDistanceToPoint(up.upridgemanage[0].GetComponent<catline>().innerPointList[j]));
                        bornx = up.upridgemanage[0].GetComponent<catline>().innerPointList[j];
                    }
                    else { break; }
                }
                for (int j = 0; j < ridgeControl.ridgemanage[0].GetComponent<catline>().innerPointList.Count; j++)
                {

                    if (Mathf.Abs(plane.GetDistanceToPoint(ridgeControl.ridgemanage[0].GetComponent<catline>().innerPointList[j])) < min)
                    {


                        min = Mathf.Abs(plane.GetDistanceToPoint(ridgeControl.ridgemanage[0].GetComponent<catline>().innerPointList[j]));
                        born = ridgeControl.ridgemanage[0].GetComponent<catline>().innerPointList[j];
                    }
                    else { break; }
                }

                if (min2<min)
                {
                    born = bornx;
                }

            }
            else
            {
                for (int j = 0; j < ridgeControl.ridgemanage[0].GetComponent<catline>().innerPointList.Count; j++)
                {

                    if (Mathf.Abs(plane.GetDistanceToPoint(ridgeControl.ridgemanage[0].GetComponent<catline>().innerPointList[j])) < min)
                    {


                        min = Mathf.Abs(plane.GetDistanceToPoint(ridgeControl.ridgemanage[0].GetComponent<catline>().innerPointList[j]));
                        born = ridgeControl.ridgemanage[0].GetComponent<catline>().innerPointList[j];
                    }
                    else { break; }
                }


            }


            GameObject r1 = new GameObject();
            r1.transform.parent = lineR.transform;
            r1.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
            r1.transform.position = born;


            /*
            print("~~~~~~~~~~~~~~:   " + i);
            print("linen:   " + linen);

            print("child  "+roofcon2.rrrRL[0].transform.GetChild(0).transform.GetChildCount());
            */

            GameObject r2 = new GameObject();
            r2.transform.parent = lineR.transform;
            r2.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
            r2.transform.position = roofcon2.rrrRL[0].transform.GetChild(0).transform.GetChild(i-1).transform.position;

           

            for (int j = 0; j < eaveControl.eavemanage[0].GetComponent<catline>().innerPointList.Count; j++)
            {
                if (Mathf.Abs(plane.GetDistanceToPoint(eaveControl.eavemanage[0].GetComponent<catline>().innerPointList[j])) < min3)
                {
                    min3 = Mathf.Abs(plane.GetDistanceToPoint(eaveControl.eavemanage[0].GetComponent<catline>().innerPointList[j]));
                    born3 = eaveControl.eavemanage[0].GetComponent<catline>().innerPointList[j];
                }
                else { break; }
            }


            GameObject r3 = new GameObject();
            r3.transform.parent = lineR.transform;
            r3.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
            r3.transform.position = born3;

            lineR.GetComponent<catline>().AddControlPoint(r3);
            lineR.GetComponent<catline>().AddControlPoint(r2);
            lineR.GetComponent<catline>().AddControlPoint(r1);



            lineR.GetComponent<catline>().ResetCatmullRom();
            //lineR.GetComponent<LineRenderer>().material = new Material(Shader.Find("GUI/Text Shader"));
            lineR.GetComponent<LineRenderer>().SetColors(Color.yellow, Color.yellow);


            lineR.AddComponent<newplanecut>();
            lineR.AddComponent<newtiled>();
            //Left

            GameObject lineL = new GameObject();
            lineL.AddComponent<catline>();
            lineL.transform.parent = roofsur2.transform;

            float minL = 1000;
            float min2L = 1000;
            float min3L = 1000;


            plane.SetNormalAndPosition(plane.normal, roofcon.roofsurfacemanage[0].transform.GetChild(0).transform.position - (tilewide * i));

            //print(" sos : pd "+plane.distance);


            if (uict.upridge == true)
            {
                for (int j = 0; j < up.upridgemanage[0].GetComponent<catline>().innerPointList.Count; j++)
                {

                    if (Mathf.Abs(plane.GetDistanceToPoint(up.upridgemanage[0].GetComponent<catline>().innerPointList[j])) < min2L)
                    {


                        min2L = Mathf.Abs(plane.GetDistanceToPoint(up.upridgemanage[0].GetComponent<catline>().innerPointList[j]));
                        bornx = up.upridgemanage[0].GetComponent<catline>().innerPointList[j];
                    }
                    else { break; }
                }
                for (int j = 0; j < ridgeControl.ridgemanage[1].GetComponent<catline>().innerPointList.Count; j++)
                {
                    //print(i + " : " + Mathf.Abs(plane.GetDistanceToPoint(ridgeControl.ridgemanage[0].GetComponent<catline>().innerPointList[j])));
                    if (Mathf.Abs(plane.GetDistanceToPoint(ridgeControl.ridgemanage[1].GetComponent<catline>().innerPointList[j])) < minL)
                    {
                        //print(i+" : "+Mathf.Abs(plane.GetDistanceToPoint(ridgeControl.ridgemanage[0].GetComponent<catline>().innerPointList[j])));

                        minL = Mathf.Abs(plane.GetDistanceToPoint(ridgeControl.ridgemanage[1].GetComponent<catline>().innerPointList[j]));
                        born = ridgeControl.ridgemanage[1].GetComponent<catline>().innerPointList[j];
                    }
                    else { break; }
                }

                if (min2L < minL)
                {
                    born = bornx;
                }

            }
            else
            {
                for (int j = 0; j < ridgeControl.ridgemanage[1].GetComponent<catline>().innerPointList.Count; j++)
                {
                    //print(i + " : " + Mathf.Abs(plane.GetDistanceToPoint(ridgeControl.ridgemanage[0].GetComponent<catline>().innerPointList[j])));
                    if (Mathf.Abs(plane.GetDistanceToPoint(ridgeControl.ridgemanage[1].GetComponent<catline>().innerPointList[j])) < minL)
                    {
                        //print(i+" : "+Mathf.Abs(plane.GetDistanceToPoint(ridgeControl.ridgemanage[0].GetComponent<catline>().innerPointList[j])));

                        minL = Mathf.Abs(plane.GetDistanceToPoint(ridgeControl.ridgemanage[1].GetComponent<catline>().innerPointList[j]));
                        born = ridgeControl.ridgemanage[1].GetComponent<catline>().innerPointList[j];
                    }
                    else { break; }
                }


            }


            

            GameObject r1L = new GameObject();
            r1L.transform.parent = lineL.transform;
            r1L.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
            r1L.transform.position = born;



            GameObject r2L = new GameObject();
            r2L.transform.parent = lineL.transform;
            r2L.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
            r2L.transform.position = roofcon2.rrrRL[0].transform.GetChild(1).transform.GetChild(i - 1).transform.position;


            for (int j = 0; j < eaveControl.eavemanage[0].GetComponent<catline>().innerPointList.Count; j++)
            {
                if (Mathf.Abs(plane.GetDistanceToPoint(eaveControl.eavemanage[0].GetComponent<catline>().innerPointList[j])) < min3L)
                {
                    min3L = Mathf.Abs(plane.GetDistanceToPoint(eaveControl.eavemanage[0].GetComponent<catline>().innerPointList[j]));
                    born3 = eaveControl.eavemanage[0].GetComponent<catline>().innerPointList[j];
                }
                else { break; }
            }


            GameObject r3L = new GameObject();
            r3L.transform.parent = lineL.transform;
            r3L.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
            r3L.transform.position = born3;

            lineL.GetComponent<catline>().AddControlPoint(r3L);
            lineL.GetComponent<catline>().AddControlPoint(r2L);
            lineL.GetComponent<catline>().AddControlPoint(r1L);



            lineL.GetComponent<catline>().ResetCatmullRom();
            //lineL.GetComponent<LineRenderer>().material = new Material(Shader.Find("GUI/Text Shader"));
            lineL.GetComponent<LineRenderer>().SetColors(Color.yellow, Color.yellow);

            lineL.AddComponent<newplanecut>();
            lineL.AddComponent<newtiledL>();
        
        
            
        
        
        
        
        
        
        }


        roofsurface2manage.Add(roofsur2);

    }



    public void inig(GameObject a)
    {


        int n = int.Parse(a.name.Substring(11, 1));

        for (int z = 0; z < a.transform.childCount; z++)
        {
            //a.GetComponent<catline>().RemoveControlPoint(a.transform.GetChild(z).gameObject);
            Destroy(a.transform.GetChild(z).gameObject);
        }





       // linen = uict.twvalue;
        if (n == 4)
        {

            linen = Mathf.RoundToInt(Vector3.Distance(ridgeControl.ridgemanage[n - 1].transform.GetChild(2).transform.position, ridgeControl.ridgemanage[0].transform.GetChild(2).transform.position) / 2);
        }
        else
        {
            linen = Mathf.RoundToInt(Vector3.Distance(ridgeControl.ridgemanage[n - 1].transform.GetChild(2).transform.position, ridgeControl.ridgemanage[n].transform.GetChild(2).transform.position) / 2);
        }




       





        Vector3 bornx = new Vector3(0, 0, 0);
        Vector3 born = new Vector3(0, 0, 0);
        Vector3 born2 = new Vector3(0, 0, 0);
        Vector3 born3 = new Vector3(0, 0, 0);

        //GameObject roofsur2 = new GameObject();
        a.transform.parent = this.transform;
        a.name = ("roofsurface"+n);

        ridgeControl.ridgemanage[0].GetComponent<catline>();

        Vector3 v1;
        Vector3 v2;
        Vector3 v3;

        if(n==4)
        {
            v1 = ridgeControl.ridgemanage[n - 1].transform.GetChild(0).transform.position;
            v2 = ridgeControl.ridgemanage[n - 1].transform.GetChild(2).transform.position;
            v3 = ridgeControl.ridgemanage[0].transform.GetChild(2).transform.position;
        }
        else
        {
             v1 = ridgeControl.ridgemanage[n-1].transform.GetChild(0).transform.position;
             v2 = ridgeControl.ridgemanage[n-1].transform.GetChild(2).transform.position;
             v3 = ridgeControl.ridgemanage[n].transform.GetChild(2).transform.position;

        }







        plane.Set3Points(roofcon.roofsurfacemanage[n - 1].transform.GetChild(2).transform.position, roofcon.roofsurfacemanage[n - 1].transform.GetChild(1).transform.position, roofcon.roofsurfacemanage[n - 1].transform.GetChild(0).transform.position);

        plane.normal = v2 - v3;

        //plane.SetNormalAndPosition(plane.normal, roofcon.roofsurfacemanage[0].transform.GetChild(0).transform.position);

        Vector3 tilewide = plane.normal / (linen * 2);
        float twide = tilewide.magnitude;

        plane.SetNormalAndPosition(plane.normal, roofcon.roofsurfacemanage[n - 1].transform.GetChild(0).transform.position + (tilewide * 0));

        for (int i = 1; i < linen; i++)
        {



            //Right

            GameObject lineR = new GameObject();
            lineR.AddComponent<catline>();
            lineR.transform.parent = a.transform;

            float min = 1000;
            float min2 = 1000;
            float min3 = 1000;


            plane.SetNormalAndPosition(plane.normal, roofcon.roofsurfacemanage[n - 1].transform.GetChild(0).transform.position + (tilewide * i));




            if (uict.upridge == true)
            {
                for (int j = 0; j < up.upridgemanage[n-1].GetComponent<catline>().innerPointList.Count; j++)
                {

                    if (Mathf.Abs(plane.GetDistanceToPoint(up.upridgemanage[n - 1].GetComponent<catline>().innerPointList[j])) < min2)
                    {


                        min2 = Mathf.Abs(plane.GetDistanceToPoint(up.upridgemanage[n - 1].GetComponent<catline>().innerPointList[j]));
                        bornx = up.upridgemanage[n - 1].GetComponent<catline>().innerPointList[j];
                    }
                    else { break; }
                }
                for (int j = 0; j < ridgeControl.ridgemanage[n - 1].GetComponent<catline>().innerPointList.Count; j++)
                {

                    if (Mathf.Abs(plane.GetDistanceToPoint(ridgeControl.ridgemanage[n - 1].GetComponent<catline>().innerPointList[j])) < min)
                    {


                        min = Mathf.Abs(plane.GetDistanceToPoint(ridgeControl.ridgemanage[n - 1].GetComponent<catline>().innerPointList[j]));
                        born = ridgeControl.ridgemanage[n - 1].GetComponent<catline>().innerPointList[j];
                    }
                    else { break; }
                }

                if (min2 < min)
                {
                    born = bornx;
                }

            }
            else
            {
                for (int j = 0; j < ridgeControl.ridgemanage[n - 1].GetComponent<catline>().innerPointList.Count; j++)
                {

                    if (Mathf.Abs(plane.GetDistanceToPoint(ridgeControl.ridgemanage[n - 1].GetComponent<catline>().innerPointList[j])) < min)
                    {


                        min = Mathf.Abs(plane.GetDistanceToPoint(ridgeControl.ridgemanage[n - 1].GetComponent<catline>().innerPointList[j]));
                        born = ridgeControl.ridgemanage[n - 1].GetComponent<catline>().innerPointList[j];
                    }
                    else { break; }
                }


            }


            GameObject r1 = new GameObject();
            r1.transform.parent = lineR.transform;
            r1.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
            r1.transform.position = born;



            GameObject r2 = new GameObject();
            r2.transform.parent = lineR.transform;
            r2.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
            r2.transform.position = roofcon2.rrrRL[n - 1].transform.GetChild(0).transform.GetChild(i - 1).transform.position;


            for (int j = 0; j < eaveControl.eavemanage[n - 1].GetComponent<catline>().innerPointList.Count; j++)
            {
                if (Mathf.Abs(plane.GetDistanceToPoint(eaveControl.eavemanage[n - 1].GetComponent<catline>().innerPointList[j])) < min3)
                {
                    min3 = Mathf.Abs(plane.GetDistanceToPoint(eaveControl.eavemanage[n - 1].GetComponent<catline>().innerPointList[j]));
                    born3 = eaveControl.eavemanage[n - 1].GetComponent<catline>().innerPointList[j];
                }
                else { break; }
            }


            GameObject r3 = new GameObject();
            r3.transform.parent = lineR.transform;
            r3.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
            r3.transform.position = born3;

            lineR.GetComponent<catline>().AddControlPoint(r3);
            lineR.GetComponent<catline>().AddControlPoint(r2);
            lineR.GetComponent<catline>().AddControlPoint(r1);



            lineR.GetComponent<catline>().ResetCatmullRom();
            //lineR.GetComponent<LineRenderer>().material = new Material(Shader.Find("GUI/Text Shader"));
            lineR.GetComponent<LineRenderer>().SetColors(Color.yellow, Color.yellow);


            lineR.AddComponent<newplanecut>();
            lineR.AddComponent<newtiled>();
            //Left

            GameObject lineL = new GameObject();
            lineL.AddComponent<catline>();
            lineL.transform.parent = a.transform;

            float minL = 1000;
            float min2L = 1000;
            float min3L = 1000;


            plane.SetNormalAndPosition(plane.normal, roofcon.roofsurfacemanage[n - 1].transform.GetChild(0).transform.position - (tilewide * i));

            //print(" sos : pd "+plane.distance);



            if (n == 4)
            {
                if (uict.upridge == true)
                {
                    for (int j = 0; j < up.upridgemanage[n - 1].GetComponent<catline>().innerPointList.Count; j++)
                    {

                        if (Mathf.Abs(plane.GetDistanceToPoint(up.upridgemanage[n - 1].GetComponent<catline>().innerPointList[j])) < min2L)
                        {


                            min2L = Mathf.Abs(plane.GetDistanceToPoint(up.upridgemanage[n - 1].GetComponent<catline>().innerPointList[j]));
                            bornx = up.upridgemanage[n - 1].GetComponent<catline>().innerPointList[j];
                        }
                        else { break; }
                    }
                    for (int j = 0; j < ridgeControl.ridgemanage[0].GetComponent<catline>().innerPointList.Count; j++)
                    {
                        //print(i + " : " + Mathf.Abs(plane.GetDistanceToPoint(ridgeControl.ridgemanage[0].GetComponent<catline>().innerPointList[j])));
                        if (Mathf.Abs(plane.GetDistanceToPoint(ridgeControl.ridgemanage[0].GetComponent<catline>().innerPointList[j])) < minL)
                        {
                            //print(i+" : "+Mathf.Abs(plane.GetDistanceToPoint(ridgeControl.ridgemanage[0].GetComponent<catline>().innerPointList[j])));

                            minL = Mathf.Abs(plane.GetDistanceToPoint(ridgeControl.ridgemanage[0].GetComponent<catline>().innerPointList[j]));
                            born = ridgeControl.ridgemanage[0].GetComponent<catline>().innerPointList[j];
                        }
                        else { break; }
                    }

                    if (min2L < minL)
                    {
                        born = bornx;
                    }

                }
                else
                {
                    for (int j = 0; j < ridgeControl.ridgemanage[0].GetComponent<catline>().innerPointList.Count; j++)
                    {
                        //print(i + " : " + Mathf.Abs(plane.GetDistanceToPoint(ridgeControl.ridgemanage[0].GetComponent<catline>().innerPointList[j])));
                        if (Mathf.Abs(plane.GetDistanceToPoint(ridgeControl.ridgemanage[0].GetComponent<catline>().innerPointList[j])) < minL)
                        {
                            //print(i+" : "+Mathf.Abs(plane.GetDistanceToPoint(ridgeControl.ridgemanage[0].GetComponent<catline>().innerPointList[j])));

                            minL = Mathf.Abs(plane.GetDistanceToPoint(ridgeControl.ridgemanage[0].GetComponent<catline>().innerPointList[j]));
                            born = ridgeControl.ridgemanage[0].GetComponent<catline>().innerPointList[j];
                        }
                        else { break; }
                    }


                }
            }
            else
            {
                if (uict.upridge == true)
                {
                    for (int j = 0; j < up.upridgemanage[n - 1].GetComponent<catline>().innerPointList.Count; j++)
                    {

                        if (Mathf.Abs(plane.GetDistanceToPoint(up.upridgemanage[n - 1].GetComponent<catline>().innerPointList[j])) < min2L)
                        {


                            min2L = Mathf.Abs(plane.GetDistanceToPoint(up.upridgemanage[n - 1].GetComponent<catline>().innerPointList[j]));
                            bornx = up.upridgemanage[n - 1].GetComponent<catline>().innerPointList[j];
                        }
                        else { break; }
                    }
                    for (int j = 0; j < ridgeControl.ridgemanage[n].GetComponent<catline>().innerPointList.Count; j++)
                    {
                        //print(i + " : " + Mathf.Abs(plane.GetDistanceToPoint(ridgeControl.ridgemanage[0].GetComponent<catline>().innerPointList[j])));
                        if (Mathf.Abs(plane.GetDistanceToPoint(ridgeControl.ridgemanage[n].GetComponent<catline>().innerPointList[j])) < minL)
                        {
                            //print(i+" : "+Mathf.Abs(plane.GetDistanceToPoint(ridgeControl.ridgemanage[0].GetComponent<catline>().innerPointList[j])));

                            minL = Mathf.Abs(plane.GetDistanceToPoint(ridgeControl.ridgemanage[n].GetComponent<catline>().innerPointList[j]));
                            born = ridgeControl.ridgemanage[n].GetComponent<catline>().innerPointList[j];
                        }
                        else { break; }
                    }

                    if (min2L < minL)
                    {
                        born = bornx;
                    }

                }
                else
                {
                    for (int j = 0; j < ridgeControl.ridgemanage[n].GetComponent<catline>().innerPointList.Count; j++)
                    {
                        //print(i + " : " + Mathf.Abs(plane.GetDistanceToPoint(ridgeControl.ridgemanage[0].GetComponent<catline>().innerPointList[j])));
                        if (Mathf.Abs(plane.GetDistanceToPoint(ridgeControl.ridgemanage[n].GetComponent<catline>().innerPointList[j])) < minL)
                        {
                            //print(i+" : "+Mathf.Abs(plane.GetDistanceToPoint(ridgeControl.ridgemanage[0].GetComponent<catline>().innerPointList[j])));

                            minL = Mathf.Abs(plane.GetDistanceToPoint(ridgeControl.ridgemanage[n].GetComponent<catline>().innerPointList[j]));
                            born = ridgeControl.ridgemanage[n].GetComponent<catline>().innerPointList[j];
                        }
                        else { break; }
                    }


                }




            }



            GameObject r1L = new GameObject();
            r1L.transform.parent = lineL.transform;
            r1L.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
            r1L.transform.position = born;



            GameObject r2L = new GameObject();
            r2L.transform.parent = lineL.transform;
            r2L.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
            r2L.transform.position = roofcon2.rrrRL[n - 1].transform.GetChild(1).transform.GetChild(i - 1).transform.position;


            for (int j = 0; j < eaveControl.eavemanage[n - 1].GetComponent<catline>().innerPointList.Count; j++)
            {
                if (Mathf.Abs(plane.GetDistanceToPoint(eaveControl.eavemanage[n - 1].GetComponent<catline>().innerPointList[j])) < min3L)
                {
                    min3L = Mathf.Abs(plane.GetDistanceToPoint(eaveControl.eavemanage[n - 1].GetComponent<catline>().innerPointList[j]));
                    born3 = eaveControl.eavemanage[n - 1].GetComponent<catline>().innerPointList[j];
                }
                else { break; }
            }


            GameObject r3L = new GameObject();
            r3L.transform.parent = lineL.transform;
            r3L.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
            r3L.transform.position = born3;

            lineL.GetComponent<catline>().AddControlPoint(r3L);
            lineL.GetComponent<catline>().AddControlPoint(r2L);
            lineL.GetComponent<catline>().AddControlPoint(r1L);



            lineL.GetComponent<catline>().ResetCatmullRom();
            //lineL.GetComponent<LineRenderer>().material = new Material(Shader.Find("GUI/Text Shader"));
            lineL.GetComponent<LineRenderer>().SetColors(Color.yellow, Color.yellow);

            lineL.AddComponent<newplanecut>();
            lineL.AddComponent<newtiledL>();

        }

        roofsurface2manage[n-1]=a.gameObject;

    }





    public void build()
    {
        int angle = uict.numberslidervalue;










        for (int i = 2; i <= angle; i++)
        {


            linen = uict.twvalue;



            if (i != angle)
            {
                linen = Mathf.RoundToInt(Vector3.Distance(ridgeControl.ridgemanage[i - 1].transform.GetChild(2).transform.position, ridgeControl.ridgemanage[i].transform.GetChild(2).transform.position) / 2);
            }
            else
            {

                linen = Mathf.RoundToInt(Vector3.Distance(ridgeControl.ridgemanage[i - 1].transform.GetChild(2).transform.position, ridgeControl.ridgemanage[0].transform.GetChild(2).transform.position) / 2);

            }





            Vector3 bornx = new Vector3(0, 0, 0);
            Vector3 born = new Vector3(0, 0, 0);
            Vector3 born2 = new Vector3(0, 0, 0);
            Vector3 born3 = new Vector3(0, 0, 0);

             Vector3 v1= new Vector3(0, 0, 0);
            Vector3 v2 = new Vector3(0, 0, 0);
            Vector3 v3 = new Vector3(0, 0, 0);





            GameObject roofsur2 = new GameObject();
            roofsur2.transform.parent = this.transform;
            roofsur2.name = ("roofsurface"+i);

            ridgeControl.ridgemanage[0].GetComponent<catline>();



            if (i == angle)
            {

                v1 = ridgeControl.ridgemanage[i - 1].transform.GetChild(0).transform.position;
                v2 = ridgeControl.ridgemanage[i - 1].transform.GetChild(2).transform.position;
                v3 = ridgeControl.ridgemanage[0].transform.GetChild(2).transform.position;
            }
            else
            {
                v1 = ridgeControl.ridgemanage[i-1].transform.GetChild(0).transform.position;
                v2 = ridgeControl.ridgemanage[i - 1].transform.GetChild(2).transform.position;
                v3 = ridgeControl.ridgemanage[i ].transform.GetChild(2).transform.position;

            }

            plane.Set3Points(roofcon.roofsurfacemanage[i - 1].transform.GetChild(2).transform.position, roofcon.roofsurfacemanage[0].transform.GetChild(1).transform.position, roofcon.roofsurfacemanage[0].transform.GetChild(0).transform.position);

            plane.normal = v2 - v3;

            //plane.SetNormalAndPosition(plane.normal, roofcon.roofsurfacemanage[0].transform.GetChild(0).transform.position);

            Vector3 tilewide = plane.normal / (linen * 2);
            float twide = tilewide.magnitude;

            plane.SetNormalAndPosition(plane.normal, roofcon.roofsurfacemanage[i - 1].transform.GetChild(0).transform.position + (tilewide * 0));

            for (int m = 1; m < linen; m++)
            {



                //Right

                GameObject lineR = new GameObject();
                lineR.AddComponent<catline>();
                lineR.transform.parent = roofsur2.transform;

                float min = 1000;
                float min2 = 1000;
                float min3 = 1000;


                plane.SetNormalAndPosition(plane.normal, roofcon.roofsurfacemanage[i - 1].transform.GetChild(0).transform.position + (tilewide * m));







                if (uict.upridge == true)
                {
                    for (int j = 0; j < up.upridgemanage[i - 1].GetComponent<catline>().innerPointList.Count; j++)
                    {

                        if (Mathf.Abs(plane.GetDistanceToPoint(up.upridgemanage[i - 1].GetComponent<catline>().innerPointList[j])) < min2)
                        {


                            min2 = Mathf.Abs(plane.GetDistanceToPoint(up.upridgemanage[i - 1].GetComponent<catline>().innerPointList[j]));
                            bornx = up.upridgemanage[i - 1].GetComponent<catline>().innerPointList[j];
                        }
                        else { break; }
                    }
                    for (int j = 0; j < ridgeControl.ridgemanage[i - 1].GetComponent<catline>().innerPointList.Count; j++)
                    {

                        if (Mathf.Abs(plane.GetDistanceToPoint(ridgeControl.ridgemanage[i - 1].GetComponent<catline>().innerPointList[j])) < min)
                        {


                            min = Mathf.Abs(plane.GetDistanceToPoint(ridgeControl.ridgemanage[i - 1].GetComponent<catline>().innerPointList[j]));
                            born = ridgeControl.ridgemanage[i - 1].GetComponent<catline>().innerPointList[j];
                        }
                        else { break; }
                    }

                    if (min2 < min)
                    {
                        born = bornx;
                    }

                }
                else
                {
                    for (int j = 0; j < ridgeControl.ridgemanage[i - 1].GetComponent<catline>().innerPointList.Count; j++)
                    {

                        if (Mathf.Abs(plane.GetDistanceToPoint(ridgeControl.ridgemanage[i - 1].GetComponent<catline>().innerPointList[j])) < min)
                        {


                            min = Mathf.Abs(plane.GetDistanceToPoint(ridgeControl.ridgemanage[i - 1].GetComponent<catline>().innerPointList[j]));
                            born = ridgeControl.ridgemanage[i - 1].GetComponent<catline>().innerPointList[j];
                        }
                        else { break; }
                    }


                }









                GameObject r1 = new GameObject();
                r1.transform.parent = lineR.transform;
                r1.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                r1.transform.position = born;


                /*
                print("~~~~~~~~~~~~~~:   " + i);
                print("linen:   " + linen);

                print("child  "+roofcon2.rrrRL[0].transform.GetChild(0).transform.GetChildCount());
                */

                GameObject r2 = new GameObject();
                r2.transform.parent = lineR.transform;
                r2.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                r2.transform.position = roofcon2.rrrRL[i - 1].transform.GetChild(0).transform.GetChild(m - 1).transform.position;



                for (int j = 0; j < eaveControl.eavemanage[i - 1].GetComponent<catline>().innerPointList.Count; j++)
                {
                    if (Mathf.Abs(plane.GetDistanceToPoint(eaveControl.eavemanage[i - 1].GetComponent<catline>().innerPointList[j])) < min3)
                    {
                        min3 = Mathf.Abs(plane.GetDistanceToPoint(eaveControl.eavemanage[i - 1].GetComponent<catline>().innerPointList[j]));
                        born3 = eaveControl.eavemanage[i - 1].GetComponent<catline>().innerPointList[j];
                    }
                    else { break; }
                }


                GameObject r3 = new GameObject();
                r3.transform.parent = lineR.transform;
                r3.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                r3.transform.position = born3;

                lineR.GetComponent<catline>().AddControlPoint(r3);
                lineR.GetComponent<catline>().AddControlPoint(r2);
                lineR.GetComponent<catline>().AddControlPoint(r1);



                lineR.GetComponent<catline>().ResetCatmullRom();
                //lineR.GetComponent<LineRenderer>().material = new Material(Shader.Find("GUI/Text Shader"));
                lineR.GetComponent<LineRenderer>().SetColors(Color.yellow, Color.yellow);


                lineR.AddComponent<newplanecut>();
                lineR.AddComponent<newtiled>();
                //Left

                GameObject lineL = new GameObject();
                lineL.AddComponent<catline>();
                lineL.transform.parent = roofsur2.transform;

                float minL = 1000;
                float min2L = 1000;
                float min3L = 1000;


                plane.SetNormalAndPosition(plane.normal, roofcon.roofsurfacemanage[i - 1].transform.GetChild(0).transform.position - (tilewide * m));

                //print(" sos : pd "+plane.distance);




                if(i==angle)
                {
                    if (uict.upridge == true)
                    {
                        for (int j = 0; j < up.upridgemanage[i - 1].GetComponent<catline>().innerPointList.Count; j++)
                        {

                            if (Mathf.Abs(plane.GetDistanceToPoint(up.upridgemanage[i - 1].GetComponent<catline>().innerPointList[j])) < min2L)
                            {


                                min2L = Mathf.Abs(plane.GetDistanceToPoint(up.upridgemanage[i - 1].GetComponent<catline>().innerPointList[j]));
                                bornx = up.upridgemanage[i - 1].GetComponent<catline>().innerPointList[j];
                            }
                            else { break; }
                        }
                        for (int j = 0; j < ridgeControl.ridgemanage[0].GetComponent<catline>().innerPointList.Count; j++)
                        {
                            //print(i + " : " + Mathf.Abs(plane.GetDistanceToPoint(ridgeControl.ridgemanage[0].GetComponent<catline>().innerPointList[j])));
                            if (Mathf.Abs(plane.GetDistanceToPoint(ridgeControl.ridgemanage[0].GetComponent<catline>().innerPointList[j])) < minL)
                            {
                                //print(i+" : "+Mathf.Abs(plane.GetDistanceToPoint(ridgeControl.ridgemanage[0].GetComponent<catline>().innerPointList[j])));

                                minL = Mathf.Abs(plane.GetDistanceToPoint(ridgeControl.ridgemanage[0].GetComponent<catline>().innerPointList[j]));
                                born = ridgeControl.ridgemanage[0].GetComponent<catline>().innerPointList[j];
                            }
                            else { break; }
                        }

                        if (min2L < minL)
                        {
                            born = bornx;
                        }

                    }
                    else
                    {
                        for (int j = 0; j < ridgeControl.ridgemanage[0].GetComponent<catline>().innerPointList.Count; j++)
                        {
                            //print(i + " : " + Mathf.Abs(plane.GetDistanceToPoint(ridgeControl.ridgemanage[0].GetComponent<catline>().innerPointList[j])));
                            if (Mathf.Abs(plane.GetDistanceToPoint(ridgeControl.ridgemanage[0].GetComponent<catline>().innerPointList[j])) < minL)
                            {
                                //print(i+" : "+Mathf.Abs(plane.GetDistanceToPoint(ridgeControl.ridgemanage[0].GetComponent<catline>().innerPointList[j])));

                                minL = Mathf.Abs(plane.GetDistanceToPoint(ridgeControl.ridgemanage[0].GetComponent<catline>().innerPointList[j]));
                                born = ridgeControl.ridgemanage[0].GetComponent<catline>().innerPointList[j];
                            }
                            else { break; }
                        }


                    }

                }
                else
                {
                if (uict.upridge == true)
                {
                    for (int j = 0; j < up.upridgemanage[i - 1].GetComponent<catline>().innerPointList.Count; j++)
                    {

                        if (Mathf.Abs(plane.GetDistanceToPoint(up.upridgemanage[i - 1].GetComponent<catline>().innerPointList[j])) < min2L)
                        {


                            min2L = Mathf.Abs(plane.GetDistanceToPoint(up.upridgemanage[i - 1].GetComponent<catline>().innerPointList[j]));
                            bornx = up.upridgemanage[i - 1].GetComponent<catline>().innerPointList[j];
                        }
                        else { break; }
                    }
                    for (int j = 0; j < ridgeControl.ridgemanage[i].GetComponent<catline>().innerPointList.Count; j++)
                    {
                        //print(i + " : " + Mathf.Abs(plane.GetDistanceToPoint(ridgeControl.ridgemanage[0].GetComponent<catline>().innerPointList[j])));
                        if (Mathf.Abs(plane.GetDistanceToPoint(ridgeControl.ridgemanage[i].GetComponent<catline>().innerPointList[j])) < minL)
                        {
                            //print(i+" : "+Mathf.Abs(plane.GetDistanceToPoint(ridgeControl.ridgemanage[0].GetComponent<catline>().innerPointList[j])));

                            minL = Mathf.Abs(plane.GetDistanceToPoint(ridgeControl.ridgemanage[i].GetComponent<catline>().innerPointList[j]));
                            born = ridgeControl.ridgemanage[i].GetComponent<catline>().innerPointList[j];
                        }
                        else { break; }
                    }

                    if (min2L < minL)
                    {
                        born = bornx;
                    }

                }
                else
                {
                    for (int j = 0; j < ridgeControl.ridgemanage[i].GetComponent<catline>().innerPointList.Count; j++)
                    {
                        //print(i + " : " + Mathf.Abs(plane.GetDistanceToPoint(ridgeControl.ridgemanage[0].GetComponent<catline>().innerPointList[j])));
                        if (Mathf.Abs(plane.GetDistanceToPoint(ridgeControl.ridgemanage[i].GetComponent<catline>().innerPointList[j])) < minL)
                        {
                            //print(i+" : "+Mathf.Abs(plane.GetDistanceToPoint(ridgeControl.ridgemanage[0].GetComponent<catline>().innerPointList[j])));

                            minL = Mathf.Abs(plane.GetDistanceToPoint(ridgeControl.ridgemanage[i].GetComponent<catline>().innerPointList[j]));
                            born = ridgeControl.ridgemanage[i].GetComponent<catline>().innerPointList[j];
                        }
                        else { break; }
                    }


                }
                }



                GameObject r1L = new GameObject();
                r1L.transform.parent = lineL.transform;
                r1L.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                r1L.transform.position = born;



                GameObject r2L = new GameObject();
                r2L.transform.parent = lineL.transform;
                r2L.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                r2L.transform.position = roofcon2.rrrRL[i - 1].transform.GetChild(1).transform.GetChild(m - 1).transform.position;


                for (int j = 0; j < eaveControl.eavemanage[i - 1].GetComponent<catline>().innerPointList.Count; j++)
                {
                    if (Mathf.Abs(plane.GetDistanceToPoint(eaveControl.eavemanage[i - 1].GetComponent<catline>().innerPointList[j])) < min3L)
                    {
                        min3L = Mathf.Abs(plane.GetDistanceToPoint(eaveControl.eavemanage[i - 1].GetComponent<catline>().innerPointList[j]));
                        born3 = eaveControl.eavemanage[i - 1].GetComponent<catline>().innerPointList[j];
                    }
                    else { break; }
                }


                GameObject r3L = new GameObject();
                r3L.transform.parent = lineL.transform;
                r3L.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                r3L.transform.position = born3;

                lineL.GetComponent<catline>().AddControlPoint(r3L);
                lineL.GetComponent<catline>().AddControlPoint(r2L);
                lineL.GetComponent<catline>().AddControlPoint(r1L);



                lineL.GetComponent<catline>().ResetCatmullRom();
                //lineL.GetComponent<LineRenderer>().material = new Material(Shader.Find("GUI/Text Shader"));
                lineL.GetComponent<LineRenderer>().SetColors(Color.yellow, Color.yellow);

                lineL.AddComponent<newplanecut>();
                lineL.AddComponent<newtiledL>();


            }




            /*
            GameObject go = Instantiate(roofsurface2manage[0], roofsurface2manage[0].transform.position, Quaternion.identity) as GameObject;

            Destroy(go.GetComponent<EaveControl>());
            go.transform.RotateAround(uict.center.transform.position, Vector3.up, (360 / angle) * (i - 1));
            go.name = ("roofsurface" + i);
            go.transform.parent = this.transform;

            

            for (int j=0; j < go.transform.GetChildCount() ;j++)
            {
                go.transform.GetChild(j).GetComponent<catline>().ResetCatmullRom();
                //go.transform.GetChild(j).GetComponent<LineRenderer>().SetColors(Color.yellow, Color.yellow);
            }
            */


            roofsurface2manage.Add(roofsur2);
        }
    }

    public void reset()
    {
        for (int i = 0; i < roofsurface2manage.Count; i++)
        {
            Destroy(roofsurface2manage[i]);
        }
        roofsurface2manage.Clear();

        ini();
        build();
    }

}
