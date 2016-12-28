using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//using UnityEditor;
public class FixedWindows : MonoBehaviour
{
	public GameObject cameraWindows;
	public List<CameraWindow> cameraWindowsList;
	public bool render = true;

	public Rect windowPosition;//儲存不可被拖曳的window的位置
	public Rect buttonPosition;//儲存button在window內的位置
	private float buttonWidth = 20f;//按鈕的寬度
	private float buttonHeight = 20f;//按鈕的高度
	public GUISkin customSkin;
	
	
	public GameObject chooseObj = null;
	public Camera chooseCamera = null;
	public Rect choosewindowRect;

	void Update() 
	{ 
		if(Input.GetKeyDown(KeyCode.R))
		{
			ShowAllWindow();
		}
		if (chooseObj)
		{
			if (Input.GetMouseButtonUp(0))
			{
				chooseObj = null;
				return;
			}
			else
			{
				Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
				if (choosewindowRect.Contains(mousePos)) chooseObj.transform.position = new Vector3(chooseCamera.ScreenToWorldPoint(Input.mousePosition).x, chooseCamera.ScreenToWorldPoint(Input.mousePosition).y, 0);
			}
		}
		else
		{
			//Vector3 mousePos = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0);
			if (Input.GetMouseButtonDown(0))
			{
				Ray ray = chooseCamera.ScreenPointToRay(Input.mousePosition);
				RaycastHit hit;
				if (Physics.Raycast(ray, out hit))
				{
					if (hit.collider.gameObject)
					{
						if (hit.collider.gameObject.tag == "ControlPoint") chooseObj = hit.collider.gameObject;
					}
				}
			}
		}
	}
    void Start()
    {
		cameraWindowsList.Clear();
		setFixedWindowPosition();
		setButtonPosition();
		
		initMoveWindowsSetting();
		ShowAllWindow();

    }
	private void initMoveWindowsSetting()
	{
		GameObject clone = Instantiate(cameraWindows, cameraWindows.transform.position, cameraWindows.transform.rotation) as GameObject;
		clone.GetComponent<CameraWindow>().Create(Screen.width * 0.2f, Screen.height * 0.2f, "TopView", cameraWindowsList.Count + 1, "TopViewCamera");
		cameraWindowsList.Add(clone.GetComponent<CameraWindow>());

		clone = Instantiate(cameraWindows, cameraWindows.transform.position, cameraWindows.transform.rotation) as GameObject;
		clone.GetComponent<CameraWindow>().Create(Screen.width * 0.2f, Screen.height * 0.9f, "FrontView", cameraWindowsList.Count + 1, "FrontViewCamera");
		cameraWindowsList.Add(clone.GetComponent<CameraWindow>());

		clone = Instantiate(cameraWindows, cameraWindows.transform.position, cameraWindows.transform.rotation) as GameObject;
		clone.GetComponent<CameraWindow>().Create(Screen.width * 0.7f, Screen.height * 0.7f, "FormFractor", cameraWindowsList.Count + 1, "FormFractorCamera");
		cameraWindowsList.Add(clone.GetComponent<CameraWindow>());

		clone = Instantiate(cameraWindows, cameraWindows.transform.position, cameraWindows.transform.rotation) as GameObject;
		clone.GetComponent<CameraWindow>().Create(Screen.width * 0.5f, Screen.height * 0.5f, "Roof", cameraWindowsList.Count + 1, "RoofCamera");
		cameraWindowsList.Add(clone.GetComponent<CameraWindow>());
	}
    private void setFixedWindowPosition()//設定window的位置
    {
		GUI.BringWindowToBack(0);
		windowPosition = new Rect(0, 0, Screen.width, Screen.height);//將不可被拖曳的window設定在Game左上角
    }

    private void setButtonPosition()//設定windows內的button位置
    {
        float buttonLeft = windowPosition.width - buttonWidth;//按鈕和window左邊的距離，目前的值會讓button顯示在window的正中央
        float buttonTop = 0;//按鈕和window上面的距離，目前的值會讓button顯示在window的正中央

        buttonPosition = new Rect(buttonLeft, buttonTop, buttonWidth, buttonHeight);
    }

    private void OnGUI()
    {
		if (render)
		{
			GUI.skin = customSkin;
			windowPosition=GUI.Window(0, windowPosition, windowEvent, "Chinese Featured Model Modeling");
		}
    }

    protected void windowEvent(int id)//處理視窗裡面要顯示的文字、按鈕、事件處理。必須要有一個為int的傳入參數
    {
		if (GUI.Button(buttonPosition, "X"))//在window上顯示按鈕
        {
            if (id == 0)//若是id為0，代表是不可被拖曳的window
            {
				HideAllWindow();
            }
        }
    }
	public void ShowWindow()
	{
		render = true;
	}
	public void HideWindow()
	{
		render = false;
	}
	public void ShowAllWindow()
	{
		render = true;
		for (int j = 0; j < cameraWindowsList.Count; j++)
		{
			cameraWindowsList[j].ShowWindow();
		}
	}
	public void HideAllWindow()
	{
		render = false;
		for (int j = 0; j < cameraWindowsList.Count; j++)
		{
			cameraWindowsList[j].HideWindow();
		}
	}


}
