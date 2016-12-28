using UnityEngine;
using System.Collections;

public class mousemoveA : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    float speed = 12.0f;
    float x;
    float y;
    float z;




    void OnMouseOver()
    {
       

        if (Input.GetMouseButton(0))
        {//鼠标按着左键移动
            y = Input.GetAxis("Mouse X") * Time.deltaTime * speed;
            x = Input.GetAxis("Mouse Y") * Time.deltaTime * speed;
            transform.Translate(y, 0, 0);
            //transform.Translate(0, x , 0);
            transform.Translate(0, x, 0);
        }
        else
        {

            x = 0;
            y = 0;
            z = 0;

        }
         if (Input.GetMouseButton(1))
         {
            
             //彈回去
             Vector3 p = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y + 1, this.gameObject.transform.position.z);
             float d = 10;
             for (int i = 0; i < GameObject.Find("path").transform.childCount; i++)
             {

                 GameObject go = GameObject.Find("path").transform.GetChild(i).gameObject;
                 float d2 = Vector3.Distance(go.transform.position, p);

                 if (d2 < d)
                 {
                     Vector3 h = go.transform.position;
                     h = new Vector3(go.transform.position.x, go.transform.position.y - 1.9f, go.transform.position.z);
                     this.gameObject.transform.position = h;


                     d = d2;
                 }
             }
             //****


         }

    }
    void OnMouseEnter()
    {
       
        GetComponent<Renderer>().material.color = Color.red;

        if (Input.GetMouseButton(0))
        {//鼠标按着左键移动
            y = Input.GetAxis("Mouse X") * Time.deltaTime * speed;
            x = Input.GetAxis("Mouse Y") * Time.deltaTime * speed;
            transform.Translate(y, 0, 0);
            //transform.Translate(0, x, 0);
            transform.Translate(0, x, 0);
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
        if (Input.GetKey(KeyCode.T))
            transform.position = transform.position + Vector3.forward * Time.deltaTime * 2;
        if (Input.GetKey(KeyCode.G))
            transform.position = transform.position + Vector3.back * Time.deltaTime * 2;

    }




}
