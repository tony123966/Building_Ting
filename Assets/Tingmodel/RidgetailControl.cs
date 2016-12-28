using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RidgetailControl : MonoBehaviour {


    public List<GameObject> ridgetailmanage = new List<GameObject>();
    public roofcontrol uict;
   



    // Use this for initialization



    void Start()
    {
        /*
        build();
        
        */


    }

    // Update is called once per frame
    void Update()
    {

    }
    

    public void build()
    {
        ridgetailmanage.Add(this.gameObject);

        

        

        int angle = uict.numberslidervalue;


        this.GetComponent<catline>().ResetCatmullRom();

        if (angle != 4)
        {

            for (int i = 2; i <= angle; i++)
            {

                GameObject go = Instantiate(ridgetailmanage[0], ridgetailmanage[0].transform.position, Quaternion.identity) as GameObject;

                Destroy(go.GetComponent<RidgetailControl>());


                Destroy(go.transform.GetChild(0).GetComponent<MeshRenderer>());
                Destroy(go.transform.GetChild(0).GetComponent<SphereCollider>());


                Destroy(go.transform.GetChild(1).GetComponent<MeshRenderer>());
                Destroy(go.transform.GetChild(1).GetComponent<SphereCollider>());

                Destroy(go.transform.GetChild(2).GetComponent<MeshRenderer>());
                Destroy(go.transform.GetChild(2).GetComponent<SphereCollider>());


                
                go.transform.RotateAround(uict.center.transform.position, Vector3.up, (360 / angle) * (i - 1));
                









                go.name = ("Ridgetail" + i);

                //go.AddComponent<catline>();


                go.GetComponent<catline>().ResetCatmullRom();



                go.transform.parent = this.gameObject.transform.parent;
                ridgetailmanage.Add(go);

            }
        }

        else
        {
            for (int i = 2; i <= angle; i++)
            {

                GameObject go = Instantiate(ridgetailmanage[0], ridgetailmanage[0].transform.position, Quaternion.identity) as GameObject;

                Destroy(go.GetComponent<RidgetailControl>());


                Destroy(go.transform.GetChild(0).GetComponent<MeshRenderer>());
                Destroy(go.transform.GetChild(0).GetComponent<SphereCollider>());


                Destroy(go.transform.GetChild(1).GetComponent<MeshRenderer>());
                Destroy(go.transform.GetChild(1).GetComponent<SphereCollider>());

                Destroy(go.transform.GetChild(2).GetComponent<MeshRenderer>());
                Destroy(go.transform.GetChild(2).GetComponent<SphereCollider>());


                /*
                go.transform.RotateAround(uict.center.transform.position, Vector3.up, (360 / angle) * (i - 1));
                */



                if (i == 2)
                {
                    go.transform.GetChild(0).transform.position = Xmirrow(ridgetailmanage[0].transform.GetChild(0).transform.position);
                    go.transform.GetChild(1).transform.position = Xmirrow(ridgetailmanage[0].transform.GetChild(1).transform.position);
                    go.transform.GetChild(2).transform.position = Xmirrow(ridgetailmanage[0].transform.GetChild(2).transform.position);
                }

                if (i == 3)
                {
                    go.transform.GetChild(0).transform.position = Xmirrow(ridgetailmanage[0].transform.GetChild(0).transform.position);
                    go.transform.GetChild(0).transform.position = Ymirrow(go.transform.GetChild(0).transform.position);

                    go.transform.GetChild(1).transform.position = Xmirrow(ridgetailmanage[0].transform.GetChild(1).transform.position);
                    go.transform.GetChild(1).transform.position = Ymirrow(go.transform.GetChild(1).transform.position);

                    go.transform.GetChild(2).transform.position = Xmirrow(ridgetailmanage[0].transform.GetChild(2).transform.position);
                    go.transform.GetChild(2).transform.position = Ymirrow(go.transform.GetChild(2).transform.position);
                }

                if (i == 4)
                {
                    go.transform.GetChild(0).transform.position = Ymirrow(ridgetailmanage[0].transform.GetChild(0).transform.position);
                    go.transform.GetChild(1).transform.position = Ymirrow(ridgetailmanage[0].transform.GetChild(1).transform.position);
                    go.transform.GetChild(2).transform.position = Ymirrow(ridgetailmanage[0].transform.GetChild(2).transform.position);
                }


                
                
                
                
                
                go.name = ("Ridgetail" + i);

                //go.AddComponent<catline>();


                go.GetComponent<catline>().ResetCatmullRom();


                //this.GetComponent<circlecut1>().reset();
                //go.GetComponent<circlecut1>().reset();


                //go.GetComponent<Ridgetile>().reset();
                //go.GetComponent<catline>().AddControlPoint(go.transform.GetChild(0).gameObject);
                //go.GetComponent<catline>().AddControlPoint(go.transform.GetChild(1).gameObject);
                //go.GetComponent<catline>().AddControlPoint(go.transform.GetChild(2).gameObject);

                go.transform.parent = this.gameObject.transform.parent;
                ridgetailmanage.Add(go);

            }

        }
        
        for (int i = 0; i < ridgetailmanage.Count; i++)
        {


            // ridgemanage[i].GetComponent<circlecut1>().cutpoint();
            //ridgemanage[i].GetComponent<Ridgetile>().creat();
            
            ridgetailmanage[i].GetComponent<circlecut1>().reset();
            ridgetailmanage[i].GetComponent<rttile>().reset();
           
        }

        

        


    }







    Vector3 Xmirrow(Vector3 a)
    {
        return new Vector3(-a.z, a.y, -a.x);

    }

    Vector3 Ymirrow(Vector3 a)
    {

        return new Vector3(a.z, a.y, a.x);

    }







    public void reset()
    {

        //this.GetComponent<circlecut1>().kill();
        //this.GetComponent<Ridgetile>().kill();


        for (int i = 1; i < ridgetailmanage.Count; i++)
        {

            Destroy(ridgetailmanage[i]);
        }

        




        ridgetailmanage.Clear();





        build();


    }
}
