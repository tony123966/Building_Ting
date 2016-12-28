using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RidgeControl : MonoBehaviour {

    public List<GameObject> ridgemanage = new List<GameObject>();

    public roofcontrol uict;
    
    public EaveControl eavc;
    public roofsurcontrol rfcon;
    public roofsurcon2control rfcon2;
    public roofsurcontrol2 rfconS;


    public GameObject aio;        


    public float Height;
    public float Wide;





    // Use this for initialization



    void Start () 
    {

        Height = Mathf.Abs(transform.GetChild(0).transform.position.y - transform.GetChild(2).transform.position.y);
        Wide = Mathf.Abs(transform.GetChild(0).transform.position.x - transform.GetChild(2).transform.position.x);

    }
	
	// Update is called once per frame
	void Update () 
    {
	
	}
    



    public void build()
    {

        ridgemanage.Add(this.gameObject);


        
       
        int angle = uict.numberslidervalue;


        if (angle == 4)
        {
            for (int i = 2; i <= angle; i++)
            {
                GameObject go = Instantiate(ridgemanage[0], ridgemanage[0].transform.position, Quaternion.identity) as GameObject;

              
                Destroy(go.transform.GetChild(0).GetComponent<mouseevent>());
                Destroy(go.transform.GetChild(0).GetComponent<topmove>());
                Destroy(go.transform.GetChild(0).GetComponent<MeshRenderer>());
                Destroy(go.transform.GetChild(0).GetComponent<SphereCollider>());

                Destroy(go.transform.GetChild(1).GetComponent<fourmove>());
                Destroy(go.transform.GetChild(1).GetComponent<mouseevent>());
                Destroy(go.transform.GetChild(1).GetComponent<MeshRenderer>());
                Destroy(go.transform.GetChild(1).GetComponent<SphereCollider>());

                Destroy(go.transform.GetChild(2).GetComponent<MeshRenderer>());
                Destroy(go.transform.GetChild(2).GetComponent<SphereCollider>());



                if(i==2)
                {
                    go.transform.GetChild(0).transform.position = Xmirrow(ridgemanage[0].transform.GetChild(0).transform.position);
                    go.transform.GetChild(1).transform.position = Xmirrow(ridgemanage[0].transform.GetChild(1).transform.position);
                    go.transform.GetChild(2).transform.position = Xmirrow(ridgemanage[0].transform.GetChild(2).transform.position);
                }

                if (i == 3)
                {
                    go.transform.GetChild(0).transform.position = Xmirrow(ridgemanage[0].transform.GetChild(0).transform.position);
                    go.transform.GetChild(0).transform.position = Ymirrow(go.transform.GetChild(0).transform.position);

                    go.transform.GetChild(1).transform.position = Xmirrow(ridgemanage[0].transform.GetChild(1).transform.position);
                    go.transform.GetChild(1).transform.position = Ymirrow(go.transform.GetChild(1).transform.position);

                    go.transform.GetChild(2).transform.position = Xmirrow(ridgemanage[0].transform.GetChild(2).transform.position);
                    go.transform.GetChild(2).transform.position = Ymirrow(go.transform.GetChild(2).transform.position);
                }

                if (i == 4)
                {
                    go.transform.GetChild(0).transform.position = Ymirrow(ridgemanage[0].transform.GetChild(0).transform.position);
                    go.transform.GetChild(1).transform.position = Ymirrow(ridgemanage[0].transform.GetChild(1).transform.position);
                    go.transform.GetChild(2).transform.position = Ymirrow(ridgemanage[0].transform.GetChild(2).transform.position);
                }



             
                go.name = ("Ridge" + i);
                
                
                go.GetComponent<catline>().ResetCatmullRom();

           

                go.GetComponent<circlecut1>().reset();
                go.GetComponent<Ridgetile>().reset();



                go.transform.parent = this.gameObject.transform.parent;
                ridgemanage.Add(go);

            }



        }

        else
        {


            for (int i = 2; i <= angle; i++)
            {


                GameObject go = Instantiate(ridgemanage[0], ridgemanage[0].transform.position, Quaternion.identity) as GameObject;


                Destroy(go.transform.GetChild(0).GetComponent<mouseevent>());
                Destroy(go.transform.GetChild(0).GetComponent<topmove>());
                Destroy(go.transform.GetChild(0).GetComponent<MeshRenderer>());
                Destroy(go.transform.GetChild(0).GetComponent<SphereCollider>());

                Destroy(go.transform.GetChild(1).GetComponent<fourmove>());
                Destroy(go.transform.GetChild(1).GetComponent<mouseevent>());
                Destroy(go.transform.GetChild(1).GetComponent<MeshRenderer>());
                Destroy(go.transform.GetChild(1).GetComponent<SphereCollider>());

                Destroy(go.transform.GetChild(2).GetComponent<MeshRenderer>());
                Destroy(go.transform.GetChild(2).GetComponent<SphereCollider>());

              
                go.transform.RotateAround(uict.center.transform.position, Vector3.up, (360 / angle) * (i - 1));
                go.name = ("Ridge" + i);

          


                go.GetComponent<catline>().ResetCatmullRom();
                
            

                /*
                go.GetComponent<circlecut1>().reset();
                go.GetComponent<Ridgetile>().reset();
                */



                go.transform.parent = this.gameObject.transform.parent;
                ridgemanage.Add(go);


                


            }
        }

        
            for (int i = 0; i < ridgemanage.Count; i++)
            {

                ridgemanage[i].GetComponent<catline>().ResetCatmullRom();
                ridgemanage[i].GetComponent<circlecut1>().reset();
                ridgemanage[i].GetComponent<Ridgetile>().reset();
                
            }
        
           
        /*
        GameObject.Find("bao-ding").transform.position = this.transform.GetChild(0).transform.position;
        */

    }



    Vector3 Xmirrow(Vector3 a)
    {
           return new Vector3(-a.z,a.y,-a.x);
           
    }

    Vector3 Ymirrow(Vector3 a)
    {

            return new Vector3(a.z, a.y, a.x);

    }






    public void reset()
    {

        

        for (int i = 1; i < ridgemanage.Count; i++)
        {
        
            Destroy(ridgemanage[i]);
        }
       

        ridgemanage.Clear();

         build();
    
     
     
     
     
     
     
     }




}
