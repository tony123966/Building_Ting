using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]
public class ContextMenuItem {
	public string text;             // text to display on button
	public Button button;           // sample button prefab
	public Action<Image> action;    // delegate to method that needs to be executed when button is clicked
	public ContextMenuItem(string text, Button button, Action<Image> action)
    {
        this.text = text;
        this.button = button;
        this.action = action;
    }
}
public class IconMenu:MonoBehaviour{

	public Image contentPanel;              // content panel prefab
	public Canvas canvas;                   // link to main canvas, where will be Context Menu
	private static IconMenu instance;    // some kind of singleton here

	public static IconMenu Instance
	{
		get
		{
			if (instance == null)
			{
				instance = FindObjectOfType(typeof(IconMenu)) as IconMenu;
				if (instance == null)
				{
					instance = new IconMenu();
				}
			}
			return instance;
		}
	}
	public Image CreateIconMenu(List<ContextMenuItem> items, Vector2 position)
	{
		// here we are creating and displaying Context Menu

		Image panel = Instantiate(contentPanel, new Vector3(position.x, position.y, 0), Quaternion.identity) as Image;
		panel.transform.SetParent(canvas.transform);
		panel.transform.SetAsLastSibling();
		panel.rectTransform.anchoredPosition = position;

		foreach (var item in items)
		{
			ContextMenuItem tempReference = item;
			Button button = Instantiate(item.button) as Button;
			Text buttonText = button.GetComponentInChildren(typeof(Text)) as Text;
			buttonText.text = item.text;
			button.onClick.AddListener(delegate { tempReference.action(panel); });
			button.transform.SetParent(panel.transform);
		}
		return panel;
	}

}

