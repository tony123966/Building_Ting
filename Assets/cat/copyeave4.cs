using UnityEngine;
using System.Collections;

public class copyeave4 : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        Vector3 vect = Vector3.Normalize(GameObject.Find("eave1").transform.GetChild(6).transform.position - GameObject.Find("eave1").transform.GetChild(7).transform.position);

        if (vectormove.movenum == ("CP003") && gameObject.transform.parent.name.Substring(0, 3) == ("eav"))
        {
            transform.Translate(vectormove.yy * -vect.x, 0, vectormove.yy * -vect.z);
            transform.Translate(0, vectormove.xx, 0);




            //transform.RotateAround(GameObject.Find("DynamicSpline").transform.GetChild(0).transform.position, Vector3.up, leg);
        }


    }

    void OnGUI()
    {

        if (Input.GetKey(KeyCode.T))
            transform.position = transform.position + Vector3.forward * Time.deltaTime * 2;
        if (Input.GetKey(KeyCode.G))
            transform.position = transform.position + Vector3.back * Time.deltaTime * 2;

    }
}
