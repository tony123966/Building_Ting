using UnityEngine;
using System.Collections;

public class ScrollBarButton
{
	public enum ScrollType { INT = 0, OddINT = 1, EvenINT = 2 };
	public bool isScrollBarIconButton = true;
	public int scrollBarIconValue = 0;
	public int scrollBarIconMaxValue = 10;
	public int scrollBarIconType = (int)ScrollType.INT;
}
public class DelelteButton
{
	public bool isDeleteIconButton = true;
}
public class IconControl:MonoBehaviour
{
	public DelelteButton delelteButton=new DelelteButton();

	public ScrollBarButton scrollBarButton = new ScrollBarButton();
}