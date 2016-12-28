using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class tiledM : MonoBehaviour
{


    public float tilelong = 2;
    public float tilelong2 = 1.40f;

    public List<GameObject> tileds = new List<GameObject>();
    public List<GameObject> bonbons = new List<GameObject>();

    public GameObject haha;
    public GameObject haha1;
    public GameObject haha2;
    public GameObject bonbon;
    public GameObject bonbon2;

    // Use this for initialization
    void Start()
    {

        haha = GameObject.Find("MIDroundtile-eave");
        haha1 = GameObject.Find("MIDroundtop");
        haha2 = GameObject.Find("MIDroundtile");
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


        float x = transform.parent.parent.GetChild(1).GetComponent<roofcontrol>().twvalue;
        Vector3 xx = transform.parent.parent.GetChild(0).GetChild(0).GetChild(0).GetComponent<RidgeControl>().ridgemanage[0].transform.GetChild(2).transform.position - transform.parent.parent.GetChild(0).GetChild(0).GetChild(0).GetComponent<RidgeControl>().ridgemanage[1].transform.GetChild(2).transform.position;


        //tilelong = Vector3.Magnitude(xx / (x));
       



        int ui = transform.parent.parent.GetChild(1).GetComponent<roofcontrol>().numberslidervalue;
        roofsurcontrol r2 =  transform.parent.GetComponent<roofsurcontrol>();

        circlecut1 cir = transform.GetComponent<circlecut1>();
        midplanecut pla = transform.GetComponent<midplanecut>();

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
                //GameObject haha = GameObject.Find("MIDroundtile-eave");
                GameObject tile = Instantiate(haha, (ori + letter) / 2, Quaternion.identity) as GameObject;
                GameObject bon = Instantiate(bonbon2, (ori + letter) / 2, Quaternion.identity) as GameObject;
                
               
                tile.transform.parent = neew.transform;
                bon.transform.parent = neew.transform;

                int angle = r2.roofsurfacemanage.IndexOf(this.transform.gameObject);

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
                tile.transform.GetChild(4).transform.Rotate(-6, 0, 0);
                 * */
                tile.transform.Rotate(oo, (90 + (360 / ui) / 2) + (360 / ui) * (j), -zz);
                bon.transform.Rotate(oo, (90 + (360 / ui) / 2) + (360 / ui) * (j), -zz);


                bon.transform.localScale = new Vector3(4, 4, tilelong2);
                bon.transform.Translate(0, -0, 0);
                bonbons.Add(bon);

                tile.transform.localScale = new Vector3(tilelong, 2, tilelong2);
                tileds.Add(tile);

            }

            else if (i == pla.anchorpointlist.Count - 3)
            {
                //GameObject haha1 = GameObject.Find("MIDroundtop");
                GameObject tile = Instantiate(haha1, (ori + letter) / 2, Quaternion.identity) as GameObject;
               
                tile.transform.parent = neew.transform;
                int angle = r2.roofsurfacemanage.IndexOf(this.transform.gameObject);


                //int x = int.Parse(neew.transform.name.Substring(16, 1));
                int y = i;

                /*
                Vector3 zr = plane.sloslopR[x + 1, y] - plane.sloslopR[x, y];
                Vector3 zrp = new Vector3(plane.sloslopR[x + 1, y].x - plane.sloslopR[x, y].x, 0, plane.sloslopR[x + 1, y].z - plane.sloslopR[x, y].z);
                zz = Vector3.Angle(zr, zrp);

    */



                int j = angle;
                tile.transform.GetChild(2).transform.Rotate(-6, 0, 0);
                tile.transform.GetChild(4).transform.Rotate(-6, 0, 0);
                tile.transform.Rotate(oo, (90 + (360 / ui) / 2) + (360 / ui) * (j), -zz);
                
                tile.transform.localScale = new Vector3(tilelong, 2, tilelong2);

                tileds.Add(tile);
            }

            else
            {
               // GameObject haha2 = GameObject.Find("MIDroundtile");
                GameObject tile = Instantiate(haha2, (ori + letter) / 2, Quaternion.identity) as GameObject;
                GameObject bon = Instantiate(bonbon, (ori + letter) / 2, Quaternion.identity) as GameObject;
                
                
                tile.transform.parent = neew.transform;
                bon.transform.parent = neew.transform;

                int angle = r2.roofsurfacemanage.IndexOf(this.transform.gameObject);


                //int x = int.Parse(neew.transform.name.Substring(16, 1));
                int y = i;

                /*
                Vector3 zr = plane.sloslopR[x + 1, y] - plane.sloslopR[x, y];
                Vector3 zrp = new Vector3(plane.sloslopR[x + 1, y].x - plane.sloslopR[x, y].x, 0, plane.sloslopR[x + 1, y].z - plane.sloslopR[x, y].z);
                zz = Vector3.Angle(zr, zrp);

    */



                int j = angle;
                tile.transform.GetChild(2).transform.Rotate(-6, 0, 0);
                tile.transform.GetChild(4).transform.Rotate(-6, 0, 0);
                tile.transform.Rotate(oo, (90 + (360 / ui) / 2) + (360 / ui) * (j), -zz);
                bon.transform.Rotate(oo, (90 + (360 / ui) / 2) + (360 / ui) * (j), -zz);
                bon.transform.localScale = new Vector3(4, 4, tilelong2);
                bon.transform.Translate(0, -0, 0);
                bonbons.Add(bon);



                tile.transform.localScale = new Vector3(tilelong, 2, tilelong2);
                tileds.Add(tile);
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
