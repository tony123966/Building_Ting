using UnityEngine;
using System.Collections;

public class copyeave2 : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        Vector3 vect = Vector3.Normalize(GameObject.Find("eave1").transform.GetChild(6).transform.position - GameObject.Find("eave1").transform.GetChild(7).transform.position);

        if (vectormove.movenum == ("CP002")&& gameObject.transform.parent.name.Substring(0,3)==("eav"))
        {
            transform.Translate(vectormove.xx * vect.x, 0, vectormove.xx *vect.z);
            //transform.Translate(0, vectormove.xx, 0);




            //transform.RotateAround(GameObject.Find("DynamicSpline").transform.GetChild(0).transform.position, Vector3.up, leg);
        }





    }



}
