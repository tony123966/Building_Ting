using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Ridgetile : MonoBehaviour
{



   // public float tilelong = 0.03f;

    public float tilelong = 0.02f;
    public float tilelong2 = 0.0140f;

    public List<GameObject> tileds = new List<GameObject>();
    

    public GameObject mridge;


    public Vector3 right;
    public Vector3 down;
    public Vector3 left;
    public Vector3 up;

    void Awake()
    {

        right = new Vector3(1, 0, 0);
        down = new Vector3(0, 0, -1);
        left = new Vector3(-1, 0, 0);
        up = new Vector3(0, 0, 1);




        mridge = GameObject.Find("main_ridge");

        //mridge = GameObject.Find("main_ridge");

    }
    // Use this for initialization
    void Start()
    {
        if(transform.name == "Ridge1")
        { 
        creat();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }


    float haha(Vector3 a)
    {

        float aa = Mathf.Min(Vector3.Angle(right, a), Vector3.Angle(down, a));
        float bb = Mathf.Min(Vector3.Angle(left, a), Vector3.Angle(up, a));

        float cc = Mathf.Min(aa, bb);


        if (cc == Vector3.Angle(right, a))
        {
            float dd = Mathf.Min(Vector3.Angle(up, a), Vector3.Angle(down, a));
            if (dd == Vector3.Angle(up, a))
            {
                return 360 - Vector3.Angle(right, a) - 90;
            }
            else
            {
                return Vector3.Angle(right, a) - 90;
            }

        }
        else if (cc == Vector3.Angle(down, a))
        {
            return Vector3.Angle(right, a) - 90;
        }
        else if (cc == Vector3.Angle(left, a))
        {
            float dd = Mathf.Min(Vector3.Angle(up, a), Vector3.Angle(down, a));
            if (dd == Vector3.Angle(up, a))
            {
                return 360 - Vector3.Angle(right, a) - 90;
            }
            else
            {
                return Vector3.Angle(right, a) - 90;
            }
        }
        else if (cc == Vector3.Angle(up, a))
        {
            return 360 - Vector3.Angle(right, a) - 90;
        }

        return 0;

    }



    public void creat()
    {

     
      
        /*
        print(this.transform.GetChild(0).name);
        print(this.transform.GetChild(transform.childCount - 1).name);
        */

        Vector3 up = this.transform.GetChild(0).transform.position;
        //Vector3 down = this.transform.GetChild(transform.childCount - 1).transform.position;

        Vector3 down = this.transform.GetChild(transform.childCount - 1).transform.position;
        
        Vector3 NowRight = new Vector3(down.x - up.x, 0, down.z - up.z);

        haha(NowRight);

        circlecut1 pla = transform.GetComponent<circlecut1>();
       

        for (int i = 0; i < pla.anchorpointlist.Count - 2; i++)
        {
            Vector3 ori = pla.anchorpointlist[i];
            Vector3 letter = pla.anchorpointlist[i + 1];
            Vector3 bottomline = new Vector3(ori.x - letter.x, 0, ori.z - letter.z);
            Vector3 slopeline = ori - letter;

            
            float oo = Vector3.Angle(bottomline, slopeline);
            if (letter.y - ori.y < 0)
            {
                oo = -oo;
            }


            float zz = 0f;
            if (i == 0)
            {

                GameObject tile = Instantiate(mridge, (ori + letter) / 2, Quaternion.identity) as GameObject;


                tile.transform.parent = this.transform;
                
               
                int y = i;

               


                tile.transform.Rotate(oo, haha(NowRight), 0);


                tile.transform.localScale = new Vector3(tilelong, 0.02f, tilelong2);
                tileds.Add(tile);

            }

            else if (i == pla.anchorpointlist.Count - 3)
            {

                GameObject tile = Instantiate(mridge, (ori + letter) / 2, Quaternion.identity) as GameObject;

                tile.transform.parent = this.transform;
               
                int y = i;

            
                tile.transform.Rotate(oo, haha(NowRight), 0);

                tile.transform.localScale = new Vector3(tilelong, 0.02f, tilelong2);

                tileds.Add(tile);
            }

            else
            {


                GameObject tile = Instantiate(mridge, (ori + letter) / 2, Quaternion.identity) as GameObject;

                tile.transform.parent = this.transform;
               
                int y = i;


                tile.transform.Rotate(oo, haha(NowRight), 0);

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
