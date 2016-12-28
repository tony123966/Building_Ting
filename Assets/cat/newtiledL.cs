using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class newtiledL : MonoBehaviour
{



    public float tilelong = 2;
    public float tilelong2 = 1.40f;

    public List<GameObject> tileds = new List<GameObject>();
    public List<GameObject> bonbons = new List<GameObject>();

    public GameObject hhaha ;
    public GameObject hhaha1 ;
    public GameObject hhaha2 ;
    private GameObject bonbon;
    private GameObject bonbon2;

    // Use this for initialization
    void Start()
    {

            hhaha = GameObject.Find("roundtile-eave");
            hhaha1 = GameObject.Find("roundtileEE");
            hhaha2 = GameObject.Find("roundtile");
            bonbon = GameObject.Find("bonbon");
            bonbon2 = GameObject.Find("bonbon2");




        creat();
    }

    // Update is called once per frame
    void Update()
    {

    }





    void creat()
    {

        float x = transform.parent.parent.parent.GetChild(1).GetComponent<roofcontrol>().twvalue;
        Vector3 xx = transform.parent.parent.parent.GetChild(0).GetChild(0).GetChild(0).GetComponent<RidgeControl>().ridgemanage[0].transform.GetChild(2).transform.position -transform.parent.parent.parent.GetChild(0).GetChild(0).GetChild(0).GetComponent<RidgeControl>().ridgemanage[1].transform.GetChild(2).transform.position;


        //tilelong = Vector3.Magnitude(xx / (x));
       



        int ui = transform.parent.parent.parent.GetChild(1).GetComponent<roofcontrol>().numberslidervalue;
        roofsurcontrol2 r2 = transform.parent.parent.GetComponent<roofsurcontrol2>();

        circlecut1 cir = transform.GetComponent<circlecut1>();
        newplanecut pla = transform.GetComponent<newplanecut>();

        // cir.anchorpointlist

        GameObject neew = new GameObject();
        neew.name = (this.name + "-tile");
        neew.transform.parent = this.transform;

        for (int i = 0; i < pla.anchorpointlist.Count - 2; i++)
        {
            Vector3 ori = pla.anchorpointlist[i];
            Vector3 letter = pla.anchorpointlist[i + 1];
            Vector3 bottomline = new Vector3(ori.x - letter.x, 0, ori.z - letter.z);
            Vector3 slopeline = ori - letter;

            //Vector3.AngleBetween(bottomline, slopeline);
            float oo = Vector3.Angle(bottomline, slopeline);
            if (letter.y - ori.y < 0)
            {
                oo = -oo;
            }


            float zz = 0f;
            if (i == 0)
            {
                //GameObject haha = GameObject.Find("roundtile-eave");
                GameObject tile = Instantiate(hhaha, (ori + letter) / 2, Quaternion.identity) as GameObject;
                GameObject bon = Instantiate(bonbon2, (ori + letter) / 2, Quaternion.identity) as GameObject;
                
                
               
                tile.transform.parent = neew.transform;
                bon.transform.parent = neew.transform;

                int angle = r2.roofsurface2manage.IndexOf(this.transform.parent.gameObject);

                //int x = int.Parse(neew.transform.name.Substring(16, 1));
                int y = i;

                /*
                Vector3 zr = plane.sloslopR[x + 1, y] - plane.sloslopR[x, y];
                Vector3 zrp = new Vector3(plane.sloslopR[x + 1, y].x - plane.sloslopR[x, y].x, 0, plane.sloslopR[x + 1, y].z - plane.sloslopR[x, y].z);
                zz = Vector3.Angle(zr, zrp);
                */


                int j = angle;
                /*
                tile.transform.GetChild(2).transform.Rotate(-6, 0, 0);
                 */ 
                tile.transform.Rotate(oo, (90 + (360 / ui) / 2) + (360 / ui) * (j), -zz);
                bon.transform.Rotate(oo, (90 + (360 / ui) / 2) + (360 / ui) * (j), -zz);


                tile.transform.localScale = new Vector3(tilelong, 2, tilelong2);
                bon.transform.localScale = new Vector3(4, 4, tilelong2);
                bon.transform.Translate(0, -0, 0);
                tileds.Add(tile);
                bonbons.Add(bon);
            }

            else if (i == pla.anchorpointlist.Count - 3)
            {
                //GameObject haha1 = GameObject.Find("roundtileEE");
                GameObject tile = Instantiate(hhaha1, (ori + letter) / 2, Quaternion.identity) as GameObject;
               
                tile.transform.parent = neew.transform;
                int angle = r2.roofsurface2manage.IndexOf(this.transform.parent.gameObject);


                //int x = int.Parse(neew.transform.name.Substring(16, 1));
                int y = i;

                /*
                Vector3 zr = plane.sloslopR[x + 1, y] - plane.sloslopR[x, y];
                Vector3 zrp = new Vector3(plane.sloslopR[x + 1, y].x - plane.sloslopR[x, y].x, 0, plane.sloslopR[x + 1, y].z - plane.sloslopR[x, y].z);
                zz = Vector3.Angle(zr, zrp);

    */



                int j = angle;
                tile.transform.GetChild(2).transform.Rotate(-6, 0, 0);
                tile.transform.Rotate(oo, (90 + (360 / ui) / 2) + (360 / ui) * (j), -zz);

                tile.transform.localScale = new Vector3(tilelong, 2, tilelong2);

                tileds.Add(tile);
            }
            else if (i == pla.anchorpointlist.Count - 4)
            {
                //GameObject haha1 = GameObject.Find("roundtileEE");
                GameObject tile = Instantiate(hhaha2, (ori + letter) / 2, Quaternion.identity) as GameObject;

                tile.transform.parent = neew.transform;
                int angle = r2.roofsurface2manage.IndexOf(this.transform.parent.gameObject);


                //int x = int.Parse(neew.transform.name.Substring(16, 1));
                int y = i;

                /*
                Vector3 zr = plane.sloslopR[x + 1, y] - plane.sloslopR[x, y];
                Vector3 zrp = new Vector3(plane.sloslopR[x + 1, y].x - plane.sloslopR[x, y].x, 0, plane.sloslopR[x + 1, y].z - plane.sloslopR[x, y].z);
                zz = Vector3.Angle(zr, zrp);

    */



                int j = angle;
                tile.transform.GetChild(2).transform.Rotate(-6, 0, 0);
                tile.transform.Rotate(oo, (90 + (360 / ui) / 2) + (360 / ui) * (j), -zz);

                tile.transform.localScale = new Vector3(tilelong, 2, tilelong2);

                tileds.Add(tile);
            }

            else
            {
                //GameObject haha2 = GameObject.Find("roundtile");
                GameObject tile = Instantiate(hhaha2, (ori + letter) / 2, Quaternion.identity) as GameObject;
                GameObject bon = Instantiate(bonbon, (ori + letter) / 2, Quaternion.identity) as GameObject;

                tile.transform.parent = neew.transform;
                bon.transform.parent = neew.transform;

                int angle = r2.roofsurface2manage.IndexOf(this.transform.parent.gameObject);


                //int x = int.Parse(neew.transform.name.Substring(16, 1));
                int y = i;

                /*
                Vector3 zr = plane.sloslopR[x + 1, y] - plane.sloslopR[x, y];
                Vector3 zrp = new Vector3(plane.sloslopR[x + 1, y].x - plane.sloslopR[x, y].x, 0, plane.sloslopR[x + 1, y].z - plane.sloslopR[x, y].z);
                zz = Vector3.Angle(zr, zrp);

    */



                int j = angle;
                tile.transform.GetChild(2).transform.Rotate(-6, 0, 0);
                tile.transform.Rotate(oo, (90 + (360 / ui) / 2) + (360 / ui) * (j), -zz);
                bon.transform.Rotate(oo, (90 + (360 / ui) / 2) + (360 / ui) * (j), -zz);



                tile.transform.localScale = new Vector3(tilelong, 2, tilelong2);
                bon.transform.localScale = new Vector3(4, 4, tilelong2);
                bon.transform.Translate(0, -0, 0);

                tileds.Add(tile);
                bonbons.Add(bon);
            }

        }
    }

    public void reset()
    {


        for (int i = 0; i < tileds.Count; i++)
        {
            Destroy(tileds[i]);

        }



        for (int i = 0; i < bonbons.Count; i++)
        {
            Destroy(bonbons[i]);

        }
        /*
        if (GameObject.Find(this.name + "-tile"))
        {
            GameObject trash = (GameObject.Find(this.name + "-tile"));
            Destroy(trash);
        }
        */
        bonbons.Clear();
        tileds.Clear();
        creat();

    }

}
