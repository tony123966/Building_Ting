using UnityEngine;
using System.Collections;

public class upridgemidpoint : MonoBehaviour {




    float speed = 2.0f;
    float x;
    float y;
    float z;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseDrag()
    {

        

        //Vector3 vector = ridgecontrol.ridgemanage[0].transform.GetChild(0).transform.position - ridgecontrol.ridgemanage[0].transform.GetChild(2).transform.position;


        Vector3 vector = Quaternion.AngleAxis(-90, Vector3.up)*(transform.parent.GetChild(0).transform.position - transform.position);
        Vector3 vector2 = Quaternion.AngleAxis(-180, Vector3.up) * (transform.parent.GetChild(0).transform.position - transform.position);


        if (Input.GetMouseButton(0))
        {//鼠标按着左键移动
            y = Input.GetAxis("Mouse X") * Time.deltaTime * speed;
            x = Input.GetAxis("Mouse Y") * Time.deltaTime * speed;

            //transform.Translate(0, x*5, 0);
            transform.parent.Translate(y * -vector.x, 0, y * -vector.z);

            transform.parent.parent.GetChild(2).Translate(y * -vector.x, 0, y * -vector.z);

            transform.parent.parent.parent.GetChild(0).GetChild(0).GetChild(0).Translate(y * -vector.x, 0, y * -vector.z);
            transform.parent.parent.parent.GetChild(0).GetChild(0).GetChild(1).Translate(y * -vector2.x, 0, y * -vector2.z);
            transform.parent.parent.parent.GetChild(0).GetChild(0).GetChild(2).Translate(y * -vector.x, 0, y * -vector.z);
            transform.parent.parent.parent.GetChild(0).GetChild(0).GetChild(3).Translate(y * -vector2.x, 0, y * -vector2.z);



            transform.parent.parent.parent.GetChild(5).GetChild(0).Translate(y * -vector.x, 0, y * -vector.z);
            //transform.parent.parent.parent.GetChild(5).GetChild(1).Translate(y * -vector2.x, 0, y * -vector2.z);
            transform.parent.parent.parent.GetChild(5).GetChild(2).Translate(y * -vector.x, 0, y * -vector.z);
            //transform.parent.parent.parent.GetChild(5).GetChild(3).Translate(y * -vector2.x, 0, y * -vector2.z);

            transform.parent.parent.parent.GetChild(2).GetChild(0).Translate(y * -vector.x, 0, y * -vector.z);
        
            transform.parent.parent.parent.GetChild(2).GetChild(2).Translate(y * -vector.x, 0, y * -vector.z);

            transform.parent.parent.parent.GetChild(3).GetChild(0).Translate(y * -vector.x, 0, y * -vector.z);

            transform.parent.parent.parent.GetChild(3).GetChild(2).Translate(y * -vector.x, 0, y * -vector.z);


            transform.parent.parent.parent.GetChild(4).GetChild(0).Translate(y * -vector.x, 0, y * -vector.z);

            transform.parent.parent.parent.GetChild(4).GetChild(2).Translate(y * -vector.x, 0, y * -vector.z);

            //ridgecontrol.ridgemanage[0].transform.GetChild(0).transform.Translate(y * -vector.x, 0, y * -vector.z);
        }
        else
        {

            x = 0;
            y = 0;
            z = 0;

        }


    }

    void OnMouseUp()
    {

        upridge up;

        //transform.parent.parent.GetComponent<upridge>().reset();


        transform.parent.parent.parent.GetChild(0).GetChild(0).GetChild(0).GetComponent<catline>().ResetCatmullRom();
        transform.parent.parent.parent.GetChild(0).GetChild(0).GetChild(1).GetComponent<catline>().ResetCatmullRom();
        transform.parent.parent.parent.GetChild(0).GetChild(0).GetChild(2).GetComponent<catline>().ResetCatmullRom();
        transform.parent.parent.parent.GetChild(0).GetChild(0).GetChild(3).GetComponent<catline>().ResetCatmullRom();

        up = transform.parent.parent.GetComponent<upridge>();


        up.inig1(transform.parent.parent.GetChild(1).transform.gameObject);
        up.inig2(transform.parent.parent.GetChild(3).transform.gameObject);
        //eave
        transform.parent.parent.parent.GetChild(5).GetComponent<EaveControl>().inig(transform.parent.parent.parent.GetChild(5).GetComponent<EaveControl>().eavemanage[0]);
        transform.parent.parent.parent.GetChild(5).GetComponent<EaveControl>().inig(transform.parent.parent.parent.GetChild(5).GetComponent<EaveControl>().eavemanage[2]);
        transform.parent.parent.parent.GetChild(5).GetComponent<EaveControl>().inig(transform.parent.parent.parent.GetChild(5).GetComponent<EaveControl>().eavemanage[1]);
        transform.parent.parent.parent.GetChild(5).GetComponent<EaveControl>().inig(transform.parent.parent.parent.GetChild(5).GetComponent<EaveControl>().eavemanage[3]);
        
        //rf
        transform.parent.parent.parent.GetChild(2).GetComponent<roofsurcontrol>().inig(transform.parent.parent.parent.GetChild(2).GetComponent<roofsurcontrol>().roofsurfacemanage[0]);
        transform.parent.parent.parent.GetChild(2).GetComponent<roofsurcontrol>().inig(transform.parent.parent.parent.GetChild(2).GetComponent<roofsurcontrol>().roofsurfacemanage[2]);
        transform.parent.parent.parent.GetChild(2).GetComponent<roofsurcontrol>().inig(transform.parent.parent.parent.GetChild(2).GetComponent<roofsurcontrol>().roofsurfacemanage[1]);
        transform.parent.parent.parent.GetChild(2).GetComponent<roofsurcontrol>().inig(transform.parent.parent.parent.GetChild(2).GetComponent<roofsurcontrol>().roofsurfacemanage[3]);
        
        //RRR
        transform.parent.parent.parent.GetChild(3).GetComponent<roofsurcon2control>().inig(transform.parent.parent.parent.GetChild(3).GetComponent<roofsurcon2control>().rrrRL[0]);
        transform.parent.parent.parent.GetChild(3).GetComponent<roofsurcon2control>().inig(transform.parent.parent.parent.GetChild(3).GetComponent<roofsurcon2control>().rrrRL[2]);
        transform.parent.parent.parent.GetChild(3).GetComponent<roofsurcon2control>().inig(transform.parent.parent.parent.GetChild(3).GetComponent<roofsurcon2control>().rrrRL[1]);
        transform.parent.parent.parent.GetChild(3).GetComponent<roofsurcon2control>().inig(transform.parent.parent.parent.GetChild(3).GetComponent<roofsurcon2control>().rrrRL[3]);
        //rf2

        
        transform.parent.parent.parent.GetChild(4).GetComponent<roofsurcontrol2>().inig(transform.parent.parent.parent.GetChild(4).GetComponent<roofsurcontrol2>().roofsurface2manage[0]);
        transform.parent.parent.parent.GetChild(4).GetComponent<roofsurcontrol2>().inig(transform.parent.parent.parent.GetChild(4).GetComponent<roofsurcontrol2>().roofsurface2manage[2]);
        transform.parent.parent.parent.GetChild(4).GetComponent<roofsurcontrol2>().inig(transform.parent.parent.parent.GetChild(4).GetComponent<roofsurcontrol2>().roofsurface2manage[1]);
        transform.parent.parent.parent.GetChild(4).GetComponent<roofsurcontrol2>().inig(transform.parent.parent.parent.GetChild(4).GetComponent<roofsurcontrol2>().roofsurface2manage[3]);
      

        

    }








}
