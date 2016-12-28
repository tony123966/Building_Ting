using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class upridgetile : MonoBehaviour
{

    public float tilelong = 0.03f;
    public float tilelong2 = 0.0140f;

    public List<GameObject> tileds = new List<GameObject>();




    // Use this for initialization
    void Start()
    {
        //creat();
    }

    // Update is called once per frame
    void Update()
    {

    }





    public void creat()
    {

        //int ui = GameObject.Find("Canvas").GetComponent<UIcontrol>().numberslidervalue;


        int ui = transform.parent.parent.GetChild(1).GetComponent<roofcontrol>().numberslidervalue; ;

        upridge r2 = this.transform.parent.GetComponent<upridge>();

        circlecut1 pla = transform.GetComponent<circlecut1>();
        //midplanecut pla = transform.GetComponent<midplanecut>();

        // cir.anchorpointlist



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
                GameObject haha = GameObject.Find("main_ridge");
                GameObject tile = Instantiate(haha, (ori + letter) / 2, Quaternion.identity) as GameObject;

                tile.tag = ("PIG");
                tile.transform.parent = this.transform;
                int angle = r2.upridgemanage.IndexOf(this.transform.gameObject);

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
                tile.transform.Rotate(oo, ((180 / ui) - 180) + ((360 / ui) * j), 0);

                tile.transform.localScale = new Vector3(tilelong, 0.02f, tilelong2);
                tileds.Add(tile);

            }

            else if (i == pla.anchorpointlist.Count - 3)
            {
                GameObject haha = GameObject.Find("main_ridge");
                GameObject tile = Instantiate(haha, (ori + letter) / 2, Quaternion.identity) as GameObject;
                tile.tag = ("PIG");
                tile.transform.parent = this.transform;
                int angle = r2.upridgemanage.IndexOf(this.transform.gameObject);


                //int x = int.Parse(neew.transform.name.Substring(16, 1));
                int y = i;

                /*
                Vector3 zr = plane.sloslopR[x + 1, y] - plane.sloslopR[x, y];
                Vector3 zrp = new Vector3(plane.sloslopR[x + 1, y].x - plane.sloslopR[x, y].x, 0, plane.sloslopR[x + 1, y].z - plane.sloslopR[x, y].z);
                zz = Vector3.Angle(zr, zrp);

    */



                int j = angle;

                tile.transform.Rotate(oo, ((180 / ui) - 180) + ((360 / ui) * j), 0);

                tile.transform.localScale = new Vector3(tilelong, 0.02f, tilelong2);

                tileds.Add(tile);
            }

            else
            {
                GameObject haha = GameObject.Find("main_ridge");
                GameObject tile = Instantiate(haha, (ori + letter) / 2, Quaternion.identity) as GameObject;
                tile.tag = ("PIG");
                tile.transform.parent = this.transform;
                int angle = r2.upridgemanage.IndexOf(this.transform.gameObject);


                //int x = int.Parse(neew.transform.name.Substring(16, 1));
                int y = i;

                /*
                Vector3 zr = plane.sloslopR[x + 1, y] - plane.sloslopR[x, y];
                Vector3 zrp = new Vector3(plane.sloslopR[x + 1, y].x - plane.sloslopR[x, y].x, 0, plane.sloslopR[x + 1, y].z - plane.sloslopR[x, y].z);
                zz = Vector3.Angle(zr, zrp);

    */



                int j = angle;

                tile.transform.Rotate(oo, ((180 / ui)-180) + ((360 / ui) * j), 0);

                tile.transform.localScale = new Vector3(tilelong, 0.02f, tilelong2);
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


        tileds.Clear();
        creat();

    }


    public void kill()
    {


        for (int i = 0; i < tileds.Count; i++)
        {
            Destroy(tileds[i]);

        }


        tileds.Clear();


    }
}