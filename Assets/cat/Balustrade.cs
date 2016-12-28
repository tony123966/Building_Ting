using UnityEngine;
using System.Collections;

public class Balustrade : MonoBehaviour {

    public static int ohoh = 7;

	// Use this for initialization
	void Start () {

        int i = int.Parse(gameObject.name.Substring(10, 1));
        for (int k =1;k<= ohoh; k++)
        {
            Vector3 v0 = new Vector3(0, 0, 0);
            GameObject haha = GameObject.Find("balustrade");
            GameObject balustrade = Instantiate(haha, v0, Quaternion.identity) as GameObject;
            balustrade.name=("balustrades"+i+"-"+k);
            balustrade.transform.parent = this.transform;
            //balustrade.transform.Rotate(0, ((360 / int.Parse(UI.stringToEdit)) / 2) + (360 / int.Parse(UI.stringToEdit)) * (i - 1), 0);
        }






        creat();
    }

    // Update is called once per frame
    void Update () {

        
       
        
        }

    void creat()
    {
        int i = int.Parse(gameObject.name.Substring(10, 1));

        Vector3 v1 = new Vector3(0, 0, 0);
        Vector3 v2 = new Vector3(0, 0, 0);
        Vector3 v3 = new Vector3(0, 0, 0);
        Vector3 v4 = new Vector3(0, 0, 0);

        int angle = int.Parse(UI.stringToEdit);




        if (i != angle)
        {
            v1 = GameObject.Find("column" + i).transform.GetChild(2).position;
            v2 = GameObject.Find("column" + (i + 1)).transform.GetChild(2).position;
            v3 = GameObject.Find("column" + i).transform.GetChild(3).position;
            v4 = GameObject.Find("column" + (i + 1)).transform.GetChild(3).position;


        }
        else
        {
            v1 = GameObject.Find("column" + i).transform.GetChild(2).position;
            v2 = GameObject.Find("column1").transform.GetChild(2).position;
            v3 = GameObject.Find("column" + i).transform.GetChild(3).position;
            v4 = GameObject.Find("column1").transform.GetChild(3).position;


        }

        Vector3 bigv = v2 - v1;
        Vector3 smallv = (v2 - v1) / ohoh;
        Vector3 mid = (v1 + v3) / 2;


        for (int j = 1; j <= ohoh; j++)
        {
            GameObject dodo = GameObject.Find("balustrades" + i + "-" + j);

            float yy = Vector3.Distance(v1, v3);
            float zz = smallv.magnitude;

            float xxb = dodo.transform.GetChild(0).GetComponent<MeshRenderer>().bounds.size.x;
            float yyb = dodo.transform.GetChild(0).GetComponent<MeshRenderer>().bounds.size.y;
            float zzb = dodo.transform.GetChild(0).GetComponent<MeshRenderer>().bounds.size.z;


            Vector3 scale = dodo.transform.GetChild(0).transform.localScale;

            scale.x = 0.15f * scale.x / xxb;
            scale.y = yy * scale.y / yyb;
            scale.z = zz * scale.z / zzb;

            dodo.transform.GetChild(0).transform.localScale = scale;

            dodo.transform.position = v1 + (smallv * j);
            dodo.transform.Rotate(0, ((360 / int.Parse(UI.stringToEdit)) / 2) + (360 / int.Parse(UI.stringToEdit)) * (i - 1), 0);

            //dodo.transform.GetChild(0).transform.localScale = new Vector3(0.1f, yy, zz);



        }


    }


    void nor()
    {

        int i = int.Parse(gameObject.name.Substring(10, 1));

        Vector3 v1 = new Vector3(0, 0, 0);
        Vector3 v2 = new Vector3(0, 0, 0);
        Vector3 v3 = new Vector3(0, 0, 0);
        Vector3 v4 = new Vector3(0, 0, 0);

        int angle = int.Parse(UI.stringToEdit);




        if (i != angle)
        {
            v1 = GameObject.Find("column" + i).transform.GetChild(2).position;
            v2 = GameObject.Find("column" + (i + 1)).transform.GetChild(2).position;
            v3 = GameObject.Find("column" + i).transform.GetChild(3).position;
            v4 = GameObject.Find("column" + (i + 1)).transform.GetChild(3).position;


        }
        else
        {
            v1 = GameObject.Find("column" + i).transform.GetChild(2).position;
            v2 = GameObject.Find("column1").transform.GetChild(2).position;
            v3 = GameObject.Find("column" + i).transform.GetChild(3).position;
            v4 = GameObject.Find("column1").transform.GetChild(3).position;


        }

        Vector3 bigv = v2 - v1;
        Vector3 smallv = (v2 - v1) / ohoh;
        Vector3 mid = (v1 + v3) / 2;


        for (int j = 1; j <= ohoh; j++)
        {
            GameObject dodo = GameObject.Find("balustrades" + i + "-" + j);
          
             


            float xx = smallv.magnitude;
            float yy = Vector3.Distance(v1, v3);
            float zz = smallv.magnitude;

            float xxb = dodo.transform.GetChild(0).GetComponent<MeshRenderer>().bounds.size.x;
            float yyb = dodo.transform.GetChild(0).GetComponent<MeshRenderer>().bounds.size.y;
            float zzb = dodo.transform.GetChild(0).GetComponent<MeshRenderer>().bounds.size.z;


            Vector3 scale = dodo.transform.GetChild(0).transform.localScale;

            //scale.x = xx * scale.x / xxb;
            scale.y = yy * scale.y / yyb;
            //scale.z = zz * scale.z / zzb;

            dodo.transform.GetChild(0).transform.localScale = scale;

            dodo.transform.position = v1 + (smallv * j);
        }

    }

    void delete()
    {

        
           
       
    }


}
