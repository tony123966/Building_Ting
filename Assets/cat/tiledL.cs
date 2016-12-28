using UnityEngine;
using System.Collections;

public class tiledL : MonoBehaviour
{

    float tilelong = tiled.tilelong;


    float tilelong2 = tiled.tilelong2;
    // Use this for initialization
    void Start()
    {
        creat();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void creat()
    {
        GameObject neew = new GameObject();
        neew.name = (this.name + "-tile");
        for (int i = 0; i < this.gameObject.transform.childCount - 1; i++)
        {
            Vector3 ori = this.gameObject.transform.GetChild(i).position;
            Vector3 letter = this.gameObject.transform.GetChild(i + 1).position;
            Vector3 bottomline = new Vector3(ori.x - letter.x, 0, ori.z - letter.z);
            Vector3 slopeline = ori - letter;

            //Vector3.AngleBetween(bottomline, slopeline);
            float oo = Vector3.Angle(bottomline, slopeline);
            float zz = 0f;
            if (i == 0)
            {
                GameObject haha = GameObject.Find("roundtile-eave");
                GameObject tile = Instantiate(haha, (ori + letter) / 2, Quaternion.identity) as GameObject;
                tile.tag = ("PIG");
                tile.transform.parent = neew.transform;
                string angle = neew.transform.name.Substring(14, 1);

                int x = int.Parse(neew.transform.name.Substring(16, 1));
                int y = i;

               
                    Vector3 zr = plane.sloslopL[x+1, y] - plane.sloslopL[x , y ];
                    Vector3 zrp = new Vector3(plane.sloslopL[x+1, y].x - plane.sloslopL[x , y].x, 0, plane.sloslopL[x+1, y].z - plane.sloslopL[x , y].z);
                    zz = Vector3.Angle(zr, zrp);
                


                int j = int.Parse(angle);
                tile.transform.GetChild(2).transform.Rotate(-6, 0, 0);
                tile.transform.Rotate(oo, (90 + (360 / int.Parse(UI.stringToEdit)) / 2) + (360 / int.Parse(UI.stringToEdit)) * (j - 1), zz);

                tile.transform.localScale = new Vector3(tilelong, 1, tilelong2);
            }
            else if (i== this.gameObject.transform.childCount - 2)
            {
                GameObject haha = GameObject.Find("roundtileEE");
                GameObject tile = Instantiate(haha, (ori + letter) / 2, Quaternion.identity) as GameObject;
                tile.tag = ("PIG");
                tile.transform.parent = neew.transform;
                string angle = neew.transform.name.Substring(14, 1);


                int x = int.Parse(neew.transform.name.Substring(16, 1));
                int y = i;


                Vector3 zr = plane.sloslopL[x + 1, y] - plane.sloslopL[x, y];
                Vector3 zrp = new Vector3(plane.sloslopL[x + 1, y].x - plane.sloslopL[x, y].x, 0, plane.sloslopL[x + 1, y].z - plane.sloslopL[x, y].z);
                zz = Vector3.Angle(zr, zrp);





                int j = int.Parse(angle);
                tile.transform.GetChild(2).transform.Rotate(-6, 0, 0);
                tile.transform.Rotate(oo, (90 + (360 / int.Parse(UI.stringToEdit)) / 2) + (360 / int.Parse(UI.stringToEdit)) * (j - 1), zz);

                tile.transform.localScale = new Vector3(tilelong, 1, tilelong2);
            }
            else
            {
                GameObject haha = GameObject.Find("roundtile");
                GameObject tile = Instantiate(haha, (ori + letter) / 2, Quaternion.identity) as GameObject;
                tile.tag = ("PIG");
                tile.transform.parent = neew.transform;
                string angle = neew.transform.name.Substring(14, 1);


                int x = int.Parse(neew.transform.name.Substring(16, 1));
                int y = i;

               
                    Vector3 zr = plane.sloslopL[x+1, y] - plane.sloslopL[x , y ];
                    Vector3 zrp = new Vector3(plane.sloslopL[x+1, y].x - plane.sloslopL[x , y].x, 0, plane.sloslopL[x+1, y].z - plane.sloslopL[x , y].z);
                    zz = Vector3.Angle(zr, zrp);
                




                int j = int.Parse(angle);
                tile.transform.GetChild(2).transform.Rotate(-6, 0, 0);
                tile.transform.Rotate(oo, (90 + (360 / int.Parse(UI.stringToEdit)) / 2) + (360 / int.Parse(UI.stringToEdit)) * (j - 1), zz);

                tile.transform.localScale = new Vector3(tilelong, 1, tilelong2);
            }

        }
    }


    void adjust()
    {




    }

}
