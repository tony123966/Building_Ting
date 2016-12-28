using UnityEngine;
using System.Collections;

public class mouseeventR : MonoBehaviour
{

    public static string myname;
    // Use this for initialization
    void Start()
    {
        myname = "0";
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (GetComponent<Renderer>())
        {
            GetComponent<Renderer>().material.color = Color.green;
        } 
         */
    }




    void OnMouseOver()
    {
        if (GetComponent<Renderer>())
        {
            GetComponent<Renderer>().material.color = Color.red;
        }

        if (Input.GetMouseButton(0))
        {
            myname = gameObject.name;
        }

    }



    void OnMouseDrag()
    {


        if (GetComponent<Renderer>())
        {
            GetComponent<Renderer>().material.color = Color.red;
        }

        if (Input.GetMouseButton(0))
        {
            myname = gameObject.name;
        }





    }


    void OnMouseExit()
    {

        myname = "0";
        if (GetComponent<Renderer>())
        {
            GetComponent<Renderer>().material.color = Color.white;
        }


    }


    void OnMouseUp()
    {


        myname = "0";

        if (GetComponent<Renderer>())
        {
            GetComponent<Renderer>().material.color = Color.white;
        }


    }


}
