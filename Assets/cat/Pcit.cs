using UnityEngine;
using System.Collections;

public class Pcit : MonoBehaviour {



    int angle = int.Parse(UI.stringToEdit);
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (mice1.movenum == ("000"))
        { 
           


                    transform.Translate(0, mice1.xx, 0);
           
 
        
        }
            
        
	}
}
