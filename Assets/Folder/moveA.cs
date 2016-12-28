using UnityEngine;
using System.Collections;

public class moveA : MonoBehaviour 
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    float speed = 100.0f;
    float x;
    float y;
    float z;




    void OnMouseOver()
    {
        print(gameObject.name);

        if (Input.GetMouseButton(0))
        {//鼠标按着左键移动
            y = Input.GetAxis("Mouse X") * Time.deltaTime * speed;
            x = Input.GetAxis("Mouse Y") * Time.deltaTime * speed;
            transform.Translate(y , 0, 0);
            //transform.Translate(0, x , 0);
            transform.Translate(0, 0, x);
        }
        else
        {

            x = 0;
            y = 0;
            z = 0;

        }

    }
    void OnMouseEnter()
    {
        print(gameObject.name);
        GetComponent<Renderer>().material.color = Color.red;

        if (Input.GetMouseButton(0))
        {//鼠标按着左键移动
            y = Input.GetAxis("Mouse X") * Time.deltaTime * speed;
            x = Input.GetAxis("Mouse Y") * Time.deltaTime * speed;
            transform.Translate(y, 0, 0);
            //transform.Translate(0, x, 0);
            transform.Translate(0, 0, x);
        }
        else
        {

            x = 0;
            y = 0;
            z = 0;

        }



    }

    void OnMouseExit()
    {
        print("......");
        GetComponent<Renderer>().material.color = Color.white;

    }
    void OnGUI()
    {
        if (Input.GetKey("down"))
        {
            transform.Translate(0, -2 * Time.deltaTime, 0);
        }

        if (Input.GetKey("up"))
        {
            transform.Translate(0, 2 * Time.deltaTime, 0);
        }

        if (Input.GetKey("left"))
        {
            //.Rotate(0, -180 / 10 * Time.deltaTime, 0);
            transform.Translate(-2 * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey("right"))
        {
            //transform.Rotate(0, 180 / 10 * Time.deltaTime, 0);
            transform.Translate(2 * Time.deltaTime, 0, 0);
        }
    }




}
