using UnityEngine;
using System.Collections;

public class updown : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.name == mice1.movenum)
        {        
            transform.Translate(0, mice1.xx, 0);



            if (Input.GetMouseButton(0))
            {

                if (transform.parent.GetChild(6).GetComponent<Frieze>())
                {
                    Frieze fre = transform.parent.GetChild(6).GetComponent<Frieze>();
                    fre.reset();
                }
            }



        }





    }
}
