using UnityEngine;
using System.Collections;

public class SetSliderValue : UILabel {
	public int value;
	public int maxValue = 10;
	private GameObject sliderGameObject;
	void Update() 
	{
		if (Input.GetMouseButtonUp(0) && sliderGameObject!=null)
		{
			Exit();
		}
	
	}
	public void SetValue(int value, int maxValue)
	{
		this.value=value;
		this.maxValue = maxValue;
		GetComponentInParent<UISlider>().value = (float)value / maxValue;
		text = value.ToString();
	}
	public void SetCurrentValue()
	{
		switch(DragItemController.Instance.lastChooseIconObject.GetComponentInParent<IconControl>().scrollBarButton.scrollBarIconType)
		{
			case (int)ScrollBarButton.ScrollType.INT:
			if (UIProgressBar.current != null)
				{
					value = Mathf.RoundToInt(UIProgressBar.current.value * maxValue);
					text = value.ToString();
					DragItemController.Instance.lastChooseIconObject.GetComponentInParent<IconControl>().scrollBarButton.scrollBarIconValue=value;
					DragItemController.Instance.lastChooseIconObject.transform.parent.SendMessage("IconUpdate");
					sliderGameObject = UIProgressBar.current.gameObject;
				}
			break;
			case (int)ScrollBarButton.ScrollType.OddINT:
			if (UIProgressBar.current != null)
			{
				value = Mathf.RoundToInt(UIProgressBar.current.value * maxValue);
				value = Mathf.Clamp(((value % 2 == 1)) ? value : value - 1,0,maxValue);
				text = value.ToString();
				DragItemController.Instance.lastChooseIconObject.GetComponentInParent<IconControl>().scrollBarButton.scrollBarIconValue = value;
				DragItemController.Instance.lastChooseIconObject.transform.parent.SendMessage("IconUpdate");
				sliderGameObject = UIProgressBar.current.gameObject;
			}
			break;
			case (int)ScrollBarButton.ScrollType.EvenINT:
				if (UIProgressBar.current != null)
				{
					value = Mathf.RoundToInt(UIProgressBar.current.value * maxValue);
					value = Mathf.Clamp(((value % 2 == 0)) ? value : value - 1,0,maxValue);
					text = value.ToString();
					DragItemController.Instance.lastChooseIconObject.GetComponentInParent<IconControl>().scrollBarButton.scrollBarIconValue = value;
					DragItemController.Instance.lastChooseIconObject.transform.parent.SendMessage("IconUpdate");
					sliderGameObject = UIProgressBar.current.gameObject;
				}
			break;
		}

		DragItemController.Instance.SetSliderValue2Icon();
	}
	public void Exit()
	{
		Destroy(sliderGameObject);
	}
}
