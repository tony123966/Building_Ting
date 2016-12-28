using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class HandleCursor : MonoBehaviour {

	const string MAINCOMPONENT = "MainComponent";
	const string CONTROLPOINT = "ControlPoint";
	const string CYLINDER = "Cylinder";

	// Use this for initialization
	public Texture2D mouse;
	public Texture2D hand;
	public Texture2D grad;
	public CursorMode cursorMode = CursorMode.Auto;
	public Vector2 hotSpot;
	public DragItemController dragitemcontroller;


	bool carrying;



	void Start () {
		dragitemcontroller = GameObject.Find ("DragItemController").GetComponent<DragItemController> ();
		hotSpot = new Vector2 (16, 16);
	}
	
	// Update is called once per frame
	void Update () {
		
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit raycasthit;
		if (Physics.Raycast (ray, out raycasthit)) {
		
			if (raycasthit.collider.gameObject.tag == CONTROLPOINT || raycasthit.collider.gameObject.tag == CYLINDER) {
				Debug.Log ("okok");
			}
		
		
		}



		if (dragitemcontroller.chooseObj) {
			setGrab ();
		} else {
			setMouse ();
		} 

	}

	public void setMouse(){
		Cursor.SetCursor (null, hotSpot, cursorMode);
	}

	public void setHand(){
		Cursor.SetCursor (hand, hotSpot, cursorMode);

	}
	public void setGrab(){
		Cursor.SetCursor (grad, hotSpot, cursorMode);

	}
}
