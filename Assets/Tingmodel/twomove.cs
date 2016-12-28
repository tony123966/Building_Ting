 using UnityEngine;
using System.Collections;

public class twomove : MonoBehaviour {


    public RidgeControl ridgecontrol;
    public ColumnControl columncontrol;
    public EaveControl eavecontrol;
    public roofsurcontrol roofcontrol;
    public roofsurcon2control roofcontrol2;
    public roofsurcontrol2 roofcontrolS;

    public BC bc;
    public FC fc;


    float speed = 2.0f;
    float x;
    float y;
    float z;
    // Use this for initialization




    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDrag()
    {



        if (Input.GetMouseButton(0))
        {//鼠标按着左键移动
            y = Input.GetAxis("Mouse X") * Time.deltaTime * speed;
            x = Input.GetAxis("Mouse Y") * Time.deltaTime * speed;
            transform.Translate(0, x * 5, 0);
          
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

      
        this.transform.parent.GetComponent<ColumnControl>().columnmanage[0].GetComponent<catline>().ResetCatmullRom();

       
        columncontrol.reset();
        bc.reset();
        fc.reset();


    }
}
