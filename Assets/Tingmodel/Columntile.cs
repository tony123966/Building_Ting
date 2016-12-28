using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Columntile : MonoBehaviour {


    

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
        int ui = transform.parent.parent.parent.GetChild(1).GetComponent<UIcontrol>().numberslidervalue;
       // int ui = GameObject.Find("Canvas").GetComponent<UIcontrol>().numberslidervalue;



        //RidgeControl r2 = this.transform.parent.GetChild(0).GetComponent<RidgeControl>();

        circlecut1 pla = transform.GetComponent<circlecut1>();
        //midplanecut pla = transform.GetComponent<midplanecut>();

        // cir.anchorpointlist

        GameObject haha = GameObject.Find("cylinder");
        //GameObject tile = Instantiate(haha, (ori + letter) / 2, Quaternion.identity) as GameObject;


        for (int i = 0; i < pla.anchorpointlist.Count - 2; i++)
        {
            Vector3 ori = pla.anchorpointlist[i];
            Vector3 letter = pla.anchorpointlist[i + 1];
            Vector3 bottomline = new Vector3(ori.x - letter.x, 0, ori.z - letter.z);
            Vector3 slopeline = ori - letter;

            //Vector3.AngleBetween(bottomline, slopeline);
            float oo = 90f;
            


            float zz = 0f;
            if (i == 0)
            {
                
                GameObject tile = Instantiate(haha, (ori + letter) / 2, Quaternion.identity) as GameObject;
                tile.tag = ("PIG");
                tile.transform.parent = this.transform;
                

                //int x = int.Parse(neew.transform.name.Substring(16, 1));
                int y = i;

                /*
                Vector3 zr = plane.sloslopR[x + 1, y] - plane.sloslopR[x, y];
                Vector3 zrp = new Vector3(plane.sloslopR[x + 1, y].x - plane.sloslopR[x, y].x, 0, plane.sloslopR[x + 1, y].z - plane.sloslopR[x, y].z);
                zz = Vector3.Angle(zr, zrp);
                */


                tile.transform.Rotate(oo, 0, 0);

                tile.transform.localScale = new Vector3(0.8f, 0.8f, 1.6f);
                tileds.Add(tile);

            }

            else if (i == pla.anchorpointlist.Count - 3)
            {
               
                GameObject tile = Instantiate(haha, (ori + letter) / 2, Quaternion.identity) as GameObject;
                tile.tag = ("PIG");
                tile.transform.parent = this.transform;
           


                //int x = int.Parse(neew.transform.name.Substring(16, 1));
                int y = i;

                /*
                Vector3 zr = plane.sloslopR[x + 1, y] - plane.sloslopR[x, y];
                Vector3 zrp = new Vector3(plane.sloslopR[x + 1, y].x - plane.sloslopR[x, y].x, 0, plane.sloslopR[x + 1, y].z - plane.sloslopR[x, y].z);
                zz = Vector3.Angle(zr, zrp);

    */



              
                tile.transform.Rotate(oo, 0, 0);

                tile.transform.localScale = new Vector3(0.8f, 0.8f, 1.6f);

                tileds.Add(tile);
            }

            else
            {
               
                GameObject tile = Instantiate(haha, (ori + letter) / 2, Quaternion.identity) as GameObject;
                tile.tag = ("PIG");
                tile.transform.parent = this.transform;
                


                //int x = int.Parse(neew.transform.name.Substring(16, 1));
                int y = i;

                /*
                Vector3 zr = plane.sloslopR[x + 1, y] - plane.sloslopR[x, y];
                Vector3 zrp = new Vector3(plane.sloslopR[x + 1, y].x - plane.sloslopR[x, y].x, 0, plane.sloslopR[x + 1, y].z - plane.sloslopR[x, y].z);
                zz = Vector3.Angle(zr, zrp);

    */




                tile.transform.Rotate(oo, 0, 0);

                tile.transform.localScale = new Vector3(0.8f, 0.8f, 1.6f);
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
