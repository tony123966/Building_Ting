using UnityEngine;
using System.Collections;

public class copyevent : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
    void Update() 
    
    {

        if (gameObject.name == mice1.movenum && gameObject.transform.parent.name.Substring(0,3) == mice1.movenumfa )
        {

            transform.Translate(mice1.yy , 0, 0);
            transform.Translate(0, mice1.xx , 0);
        
        }
	}
}
