/*
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class BasedPlatformIcon
{ 

}
public class platform2icon : MonoBehaviour
{
	public List<GameObject> controlPointList = new List<GameObject>();


	private DragItemController dragitemcontroller;
	private Movement movement;


	Mesh mesh;
	Vector3[] verts;
	Vector3[] ini_verts;


	//for ratio
	public Vector2 chang_platdis;

	void Awake()
	{

		mesh = GetComponent<MeshFilter>().mesh;
		movement = GameObject.Find("Movement").GetComponent<Movement>();

		if (!gameObject.GetComponent<MeshFilter>()) gameObject.AddComponent<MeshFilter>();
		if (!gameObject.GetComponent<MeshRenderer>()) gameObject.AddComponent<MeshRenderer>();


		if (controlPointList.Count == 4)
		{
			mesh.vertices = new Vector3[] {
				 controlPointList [0].transform.localPosition,
				 controlPointList [1].transform.localPosition,
				 controlPointList [2].transform.localPosition,
				 controlPointList [3].transform.localPosition
			};
			mesh.triangles = new int[] { 0, 1, 2, 0, 2, 3 };
			verts = mesh.vertices;
			movement.freelist.AddRange(controlPointList);

			ini_verts = new Vector3[controlPointList.Count];
			for (int i = 0; i < controlPointList.Count; i++)
			{
				ini_verts[i] = controlPointList[i].transform.localPosition;
			}
		}

	}

	// Use this for initialization
	void Start()
	{
		dragitemcontroller = GameObject.Find("DragItemController").GetComponent<DragItemController>();
	}
	void adjMesh()
	{
		for (int i = 0; i < controlPointList.Count; i++)
		{
			verts[i] = controlPointList[i].transform.localPosition;
		}
		mesh.vertices = verts;
		mesh.RecalculateBounds();
		mesh.RecalculateNormals();

	}
	public void adjPos()
	{
		for (int i = 0; i < controlPointList.Count; i++)
		{
			if (dragitemcontroller.chooseObj == controlPointList[i])
			{

				Vector3 tmp = dragitemcontroller.chooseObj.transform.localPosition;
				if (controlPointList.Count == 4)
				{
					float offset_x, offset_y;
					offset_x = tmp.x - verts[i].x;
					offset_y = tmp.y - verts[i].y;
					for (int j = 0; j < controlPointList.Count; j++)
					{
						if (i == j) continue;
						if ((verts[i].x == controlPointList[j].transform.localPosition.x))
						{
							controlPointList[j].transform.localPosition = new Vector3(tmp.x, verts[j].y - (offset_y), verts[j].z);
						}
						else if ((verts[i].y == controlPointList[j].transform.localPosition.y))
						{
							controlPointList[j].transform.localPosition = new Vector3(verts[j].x - (offset_x), tmp.y, verts[j].z);
						}
						else
						{
							controlPointList[j].transform.localPosition = new Vector3(verts[j].x - (offset_x), verts[j].y - (offset_y), verts[j].z);
						}
					}
					//
					chang_platdis.x = tmp.x - ini_verts[i].x;
					chang_platdis.y = tmp.y - ini_verts[i].y;
				}
				break;
			}
		}

		for (int x = 0; x < controlPointList.Count; x++)
		{
			verts[x] = controlPointList[x].transform.localPosition;
		}
		adjMesh();
	}
	public void addpoint()
	{
		if (controlPointList.Count == 4)
		{
			movement.freelist.AddRange(controlPointList);
		}
	}
	public Vector3 ClampPos(Vector3 inputPos)
	{
		float minClampX = float.MinValue;
		float maxClampX = float.MaxValue;
		float minClampY = float.MinValue;
		float maxClampY = float.MaxValue;
		if (controlPointList.Count == 4)
		{
			float minWidth = (ini_verts[1].x - ini_verts[0].x) * 0.2f;
			float minHeight = (ini_verts[1].y - ini_verts[2].y) * 0.2f;

			if (dragitemcontroller.chooseObj == controlPointList[0] )
			{
				maxClampX = controlPointList[1].transform.position.x - minWidth;
				minClampY = controlPointList[3].transform.position.y + minHeight;
			}
			else if (dragitemcontroller.chooseObj == controlPointList[3])
			{
				maxClampX = controlPointList[1].transform.position.x - minWidth;
				maxClampY = controlPointList[0].transform.position.y - minHeight;
			}
			else if (dragitemcontroller.chooseObj == controlPointList[1] )
			{
				minClampX = controlPointList[0].transform.position.x + minWidth;
				minClampY = controlPointList[2].transform.position.y + minHeight;
			}
			else if ( dragitemcontroller.chooseObj == controlPointList[2])
			{
				minClampX = controlPointList[0].transform.position.x + minWidth;
				maxClampY = controlPointList[1].transform.position.y - minHeight;
			}
			float posX = Mathf.Clamp(inputPos.x, minClampX, maxClampX);
			float posY = Mathf.Clamp(inputPos.y, minClampY, maxClampY);
			return new Vector3(posX, posY, inputPos.z);
		}
		return inputPos;
	}
}*/
using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
public class BasedPlatformStairIcon<M> : DecorateIconObject where M : class
{
	public static Vector3 rightUpPoint;
	public static Vector3 rightDownPoint;
	public static Vector3 leftUpPoint;
	public static Vector3 leftDownPoint;

	public int stairIconCount = 1;
	public int stairIconMaxCount = 10;

	public float stairWidth;
	public float stairHeight;

	PlatFormIcon MainComponent;
	public void BasedPlatformStairCreate<T>(T thisGameObject, string objName, M platformIcon, float stairWidth, GameObject correspondingDragItemObject)
where T : Component
	{

		MainComponent = platformIcon as PlatFormIcon;

		InitBodySetting(objName, (int)BodyType.GeneralBody);
		InitIconMenuButtonSetting();

		bodyStruct.mRenderer.sortingOrder = 3;


		this.stairHeight = MainComponent.platformHeight;
		this.stairWidth = stairWidth;

		float centerPosX = (MainComponent.rightDownPoint.transform.position.x + MainComponent.leftDownPoint.transform.position.x) / 2.0f;
		rightDownPoint = new Vector3(centerPosX + stairWidth / 2.0f, MainComponent.rightDownPoint.transform.position.y, MainComponent.rightDownPoint.transform.position.z);
		leftDownPoint = new Vector3(centerPosX - stairWidth / 2.0f, MainComponent.leftDownPoint.transform.position.y, MainComponent.leftDownPoint.transform.position.z);


		rightUpPoint = new Vector3(centerPosX + stairWidth / 2.0f, MainComponent.rightUpPoint.transform.position.y, MainComponent.rightUpPoint.transform.position.z);
		leftUpPoint = new Vector3(centerPosX - stairWidth / 2.0f, MainComponent.leftUpPoint.transform.position.y, MainComponent.leftUpPoint.transform.position.z);


		bodyStruct.mFilter.mesh = CreatRecMesh(leftUpPoint, rightUpPoint, rightDownPoint, leftDownPoint, bodyStruct.mFilter.mesh);

		InitLineRender(thisGameObject);
		SetIconObjectColor();
		SetParent2BodyAndControlPointList(thisGameObject);

		InitDecorateIconObjectSetting(correspondingDragItemObject);
	}
	public void AdjPos(GameObject baseLeftUpPoint, GameObject baseRightUpPoint, GameObject baseRightDownPoint, GameObject baseLeftDownPoint)
	{

		float centerPosX = (baseRightDownPoint.transform.position.x + baseLeftDownPoint.transform.position.x) / 2.0f;
		rightDownPoint = new Vector3(centerPosX + stairWidth / 2.0f, baseRightDownPoint.transform.position.y, baseRightDownPoint.transform.position.z);
		leftDownPoint = new Vector3(centerPosX - stairWidth / 2.0f, baseLeftDownPoint.transform.position.y, baseLeftDownPoint.transform.position.z);


		rightUpPoint = new Vector3(centerPosX + stairWidth / 2.0f, baseRightUpPoint.transform.position.y, baseRightUpPoint.transform.position.z);
		leftUpPoint = new Vector3(centerPosX - stairWidth / 2.0f, baseLeftUpPoint.transform.position.y, baseLeftUpPoint.transform.position.z);
	}
	public void AdjMesh()
	{

		bodyStruct.mFilter.mesh.Clear();
		bodyStruct.mFilter.mesh = CreatRecMesh(leftUpPoint, rightUpPoint, rightDownPoint, leftDownPoint, bodyStruct.mFilter.mesh);

		UpdateLineRender();
		UpdateCollider();
	}
	public void SetIconObjectColor()
	{
		bodyStruct.mRenderer.material.color = Color.white;
	}
	public override void InitLineRender<T>(T thisGameObject)
	{
		controlPointList_Vec3_2_LineRender.Add(leftUpPoint);
		controlPointList_Vec3_2_LineRender.Add(rightUpPoint);
		controlPointList_Vec3_2_LineRender.Add(rightDownPoint);
		controlPointList_Vec3_2_LineRender.Add(leftDownPoint);

		for (int i = 0; i < controlPointList_Vec3_2_LineRender.Count; i++)
		{
			if (i != controlPointList_Vec3_2_LineRender.Count - 1)
				CreateLineRenderer(thisGameObject, controlPointList_Vec3_2_LineRender[i], controlPointList_Vec3_2_LineRender[i + 1]);
			else
				CreateLineRenderer(thisGameObject, controlPointList_Vec3_2_LineRender[i], controlPointList_Vec3_2_LineRender[0]);
		}
	}
	public override void UpdateLineRender()
	{
		controlPointList_Vec3_2_LineRender[(int)PointIndex.LeftUpPoint] = (leftUpPoint);
		controlPointList_Vec3_2_LineRender[(int)PointIndex.RightUpPoint] = (rightUpPoint);
		controlPointList_Vec3_2_LineRender[(int)PointIndex.RightDownPoint] = (rightDownPoint);
		controlPointList_Vec3_2_LineRender[(int)PointIndex.LeftDownPoint] = (leftDownPoint);
		for (int i = 0; i < lineRenderList.Count; i++)
		{
			if (i != controlPointList_Vec3_2_LineRender.Count - 1)
				AdjLineRenderer(i, controlPointList_Vec3_2_LineRender[i], controlPointList_Vec3_2_LineRender[i + 1]);
			else
				AdjLineRenderer(i, controlPointList_Vec3_2_LineRender[i], controlPointList_Vec3_2_LineRender[0]);
		}
	}
	public void InitIconMenuButtonSetting()
	{
		iconMenuControl.delelteButton.isDeleteIconButton = true;
		iconMenuControl.scrollBarButton.isScrollBarIconButton = true;
		iconMenuControl.scrollBarButton.scrollBarIconValue = stairIconCount;
		iconMenuControl.scrollBarButton.scrollBarIconMaxValue = stairIconMaxCount;
		iconMenuControl.scrollBarButton.scrollBarIconType = (int)ScrollBarButton.ScrollType.INT;
	}
	public override void InitIconMenuButtonUpdate()
	{
		stairIconCount = iconMenuControl.scrollBarButton.scrollBarIconValue;
	}
}
public class BasedPlatformBalustradeIcon<M> : DecorateIconObject where M : class
{
	public List<GameObject> body = null;
	public Column leftColumn;
	public Column rightColumn;

	public int mutiColumnIconCount = 1;
	public int mutiColumnIconMaxCount = 13;
	public float columnHeight;
	public float columnWidth;

	public float initColumnHeight;
	public float initColumnWidth;

	float offset = 0.01f;
	PlatFormIcon MainComponent;

	public void BasedPlatformBalustradeCreate<T>(T thisGameObject, string objName, M platformIcon, float columnHeight, GameObject correspondingDragItemObject) where T : Component
	{
		
		MainComponent = platformIcon as PlatFormIcon;

		Vector3 h = new Vector3(0.0f, columnHeight, 0.0f);
		Vector3 offsetVector = new Vector3(0.0f, offset, 0.0f);

		Vector3 rightDownPointPos = MainComponent.rightUpPoint.transform.position + offsetVector;
		Vector3 leftDownPointPos = MainComponent.leftUpPoint.transform.position + offsetVector;
		Vector3 rightUpPointPos = rightDownPointPos + h;
		Vector3 leftUpPointPos = leftDownPointPos + h;
		rightDownPoint = CreateControlPoint("PBRD", MainComponent.rightUpPoint.transform.localScale, rightDownPointPos);
		leftDownPoint = CreateControlPoint("PBLD", MainComponent.leftUpPoint.transform.localScale, leftDownPointPos);
		rightUpPoint = CreateControlPoint("PBRU", MainComponent.rightUpPoint.transform.localScale, rightUpPointPos);
		leftUpPoint = CreateControlPoint("PBLU", MainComponent.leftUpPoint.transform.localScale, leftUpPointPos);


		leftColumn = new Column("BasedPlatformBalustradeIcon", leftUpPoint, leftDownPoint, columnHeight);
		rightColumn = new Column("BasedPlatformBalustradeIcon", rightUpPoint, rightDownPoint, columnHeight);
		initColumnHeight = this.columnHeight = columnHeight;
		initColumnWidth = this.columnWidth = rightDownPointPos.x - leftDownPointPos.x;

		centerX = (rightUpPointPos.x + leftUpPointPos.x) / 2.0f;

		body = new List<GameObject>();
		body.Add(leftColumn.bodyStruct.body);
		body.Add(rightColumn.bodyStruct.body);


		//初始位置
		controlPointList.Add(leftColumn.upPoint);
		controlPointList.Add(rightColumn.upPoint);
		controlPointList.Add(rightColumn.downPoint);
		controlPointList.Add(leftColumn.downPoint);
		controlPointList.Add(rightColumn.bodyStruct.body);
		controlPointList.Add(leftColumn.bodyStruct.body);
		InitControlPointList2lastControlPointPosition();


		SetIconObjectColor();
		SetParent2BodyAndControlPointList(thisGameObject);

		InitDecorateIconObjectSetting(correspondingDragItemObject);
/*

		for (int i = 0; i < body.Count; i++)
		{
			if (body[i].GetComponent<IconControl>())
				UnityEngine.Object.Destroy(body[i].GetComponent<IconControl>());
		}*/

		InitBodySetting(thisGameObject);
		InitIconMenuButtonSetting();
	}
	public void SetIconObjectColor()
	{
		//base.SetIconObjectColor();
		rightColumn.bodyStruct.body.GetComponent<MeshRenderer>().material.color = Color.red;
		leftColumn.bodyStruct.body.GetComponent<MeshRenderer>().material.color = Color.red;
	}
	public void InitDecorateIconObjectSetting(GameObject correspondingDragItemObject)
	{

		if (!correspondingDragItemObject.GetComponent<DecorateEmptyObjectList>()) return;

		DecorateEmptyObjectList decorateEmptyObjectList = correspondingDragItemObject.GetComponent<DecorateEmptyObjectList>();
		decorateEmptyObjectList.objectList.Clear();
		for (int i = 0; i < body.Count; i++)
		{
			decorateEmptyObjectList.objectList.Add(body[i]);
		}
		for (int i = 0; i < controlPointList.Count; i++)
		{
			decorateEmptyObjectList.objectList.Add(controlPointList[i]);
		}
		for (int i = 0; i < lineRenderList.Count; i++)
		{
			decorateEmptyObjectList.objectList.Add(lineRenderList[i].lineObj);
		}

	}
	public void SetParent2BodyAndControlPointList<T>(T thisGameObject)
where T : Component
	{
		for (int i = 0; i < body.Count; i++)
		{
			body[i].transform.parent = thisGameObject.transform;
		}
		for (int i = 0; i < controlPointList.Count; i++)
		{
			controlPointList[i].transform.parent = thisGameObject.transform;
		}
	}
	public Vector3 ClampPos(Vector3 inputPos, GameObject chooseObj)
	{
		float minClampX = float.MinValue;
		float maxClampX = float.MaxValue;
		float minClampY = float.MinValue;
		float maxClampY = float.MaxValue;

		float minWidth = closerDis;
		float minHeight = (initColumnHeight) * 0.4f;

		if (chooseObj == rightUpPoint)
		{
			minClampY = rightDownPoint.transform.position.y + minHeight;
		
		}
		else if (chooseObj == leftUpPoint)
		{
			minClampY = leftDownPoint.transform.position.y + minHeight;
		
		}
		else if (chooseObj == rightDownPoint)
		{
			minClampX = centerX + minWidth;
			maxClampX = MainComponent.rightUpPoint.transform.position.x;
		}
		else if (chooseObj == leftDownPoint)
		{
			maxClampX = centerX - minWidth;
			minClampX = MainComponent.leftUpPoint.transform.position.x;
		}
		else if (chooseObj == rightColumn.bodyStruct.body)
		{
			minClampX = centerX + minWidth;
			maxClampX = MainComponent.rightUpPoint.transform.position.x;
		}
		else if (chooseObj == leftColumn.bodyStruct.body)
		{
			maxClampX = centerX - minWidth;
			minClampX = MainComponent.leftUpPoint.transform.position.x;
		}

		float posX = Mathf.Clamp(inputPos.x, minClampX, maxClampX);
		float posY = Mathf.Clamp(inputPos.y, minClampY, maxClampY);
		return new Vector3(posX, posY, inputPos.z);
	}
	public void AdjPos(Vector3 tmp, GameObject chooseObject)
	{
		float OffsetX = 0;
		if (chooseObject == leftUpPoint || chooseObject == rightUpPoint)
		{
			columnHeight = (tmp.y - rightColumn.downPoint.transform.position.y);
			columnHeight = Mathf.Abs(columnHeight);
			//update point
			rightColumn.upPoint.transform.position = new Vector3(rightColumn.upPoint.transform.position.x, tmp.y, rightColumn.upPoint.transform.position.z);
			leftColumn.upPoint.transform.position = new Vector3(leftColumn.upPoint.transform.position.x, tmp.y, leftColumn.upPoint.transform.position.z);

			rightColumn.bodyStruct.body.transform.position = new Vector3(rightColumn.upPoint.transform.position.x, rightColumn.upPoint.transform.position.y - columnHeight / 2.0f, rightColumn.upPoint.transform.position.z);

			leftColumn.bodyStruct.body.transform.position = new Vector3(leftColumn.upPoint.transform.position.x, leftColumn.upPoint.transform.position.y - columnHeight / 2.0f, leftColumn.upPoint.transform.position.z);

			rightColumn.bodyStruct.body.transform.localScale = new Vector3(rightColumn.radius, columnHeight / 2.0f, rightColumn.radius);
			leftColumn.bodyStruct.body.transform.localScale = new Vector3(leftColumn.radius, columnHeight / 2.0f, leftColumn.radius);
		}
		else if (chooseObject == rightColumn.bodyStruct.body || chooseObject == rightDownPoint)
		{
			OffsetX = (tmp.x - lastControlPointPosition[(int)PointIndex.RightUpPoint].x);

			for (int i = 0; i < rightColumn.controlPointList.Count; i++)
			{
				rightColumn.controlPointList[i].transform.position = new Vector3(tmp.x, rightColumn.controlPointList[i].transform.position.y, rightColumn.controlPointList[i].transform.position.z);
				leftColumn.controlPointList[i].transform.position = new Vector3(leftColumn.controlPointList[i].transform.position.x - (OffsetX), leftColumn.controlPointList[i].transform.position.y, leftColumn.controlPointList[i].transform.position.z);

			}
			columnWidth = rightDownPoint.transform.position.x - leftDownPoint.transform.position.x;
		}
		else if (chooseObject == leftColumn.bodyStruct.body || chooseObject == leftDownPoint)
		{
			OffsetX = (tmp.x - lastControlPointPosition[(int)PointIndex.LeftUpPoint].x);

			for (int i = 0; i < leftColumn.controlPointList.Count; i++)
			{
				leftColumn.controlPointList[i].transform.position = new Vector3(tmp.x, leftColumn.controlPointList[i].transform.position.y, leftColumn.controlPointList[i].transform.position.z);
				rightColumn.controlPointList[i].transform.position = new Vector3(rightColumn.controlPointList[i].transform.position.x - (OffsetX), rightColumn.controlPointList[i].transform.position.y, rightColumn.controlPointList[i].transform.position.z);
			}
			columnWidth = rightDownPoint.transform.position.x - leftDownPoint.transform.position.x;
		}

		rightColumn.UpdateLastPos();
		leftColumn.UpdateLastPos();
		UpdateLastPos();
	}
	public void InitBodySetting<T>(T thisGameObject) where T : Component
	{
		//iconMenuControl = thisGameObject.gameObject.AddComponent<IconControl>();
		iconMenuControl = rightColumn.iconMenuControl;
	}
	public void InitIconMenuButtonSetting()
	{
		iconMenuControl.delelteButton.isDeleteIconButton = true;
		iconMenuControl.scrollBarButton.isScrollBarIconButton = true;
		iconMenuControl.scrollBarButton.scrollBarIconValue = mutiColumnIconCount;
		iconMenuControl.scrollBarButton.scrollBarIconMaxValue = mutiColumnIconMaxCount;
		iconMenuControl.scrollBarButton.scrollBarIconType = (int)ScrollBarButton.ScrollType.OddINT;

		leftColumn.bodyStruct.body.GetComponent<IconControl>().scrollBarButton = iconMenuControl.scrollBarButton;
		leftColumn.bodyStruct.body.GetComponent<IconControl>().delelteButton = iconMenuControl.delelteButton;
	}
	public override void InitIconMenuButtonUpdate()
	{
		mutiColumnIconCount = iconMenuControl.scrollBarButton.scrollBarIconValue;


		rightColumn.bodyStruct.body.GetComponent<IconControl>().scrollBarButton = iconMenuControl.scrollBarButton;
		rightColumn.bodyStruct.body.GetComponent<IconControl>().delelteButton = iconMenuControl.delelteButton;

		leftColumn.bodyStruct.body.GetComponent<IconControl>().scrollBarButton = iconMenuControl.scrollBarButton;
		leftColumn.bodyStruct.body.GetComponent<IconControl>().delelteButton = iconMenuControl.delelteButton;
	}
}
public class CurvePlatformStruct
{
	public List<GameObject> controlPointList = new List<GameObject>();
	public catline catLine;
}
public class PlatFormIcon : RecMeshCreate
{
	public float platformHeight;
	public float platformTopWidth;
	public float platformButtonWidth;

	public float initPlatformHeight;
	public float initPlatformTopWidth;
	public float initPlatformButtonWidth;
}
public class CurvePlatformIcon : PlatFormIcon
{
	public enum PointIndex { LeftUpPoint = 0, RightUpPoint = 1, RightDownPoint = 2, LeftDownPoint = 3, LeftMidPoint = 4, RightMidPoint = 5, };
	public float platMidWidthDis;
	public float ini_platMidWidthDis;
	public float platMid2TopDis;
	public float ini_platMid2TopDis;

	public GameObject rightMidPoint;
	public GameObject leftMidPoint;

	public CurvePlatformStruct rightPlatformLine = new CurvePlatformStruct();
	public CurvePlatformStruct leftPlatformLine = new CurvePlatformStruct();
	public int numberOfPoints = 10;
	public int sliceUnit = 1;

	public BasedPlatformBalustradeIcon<CurvePlatformIcon> basedPlatformBalustradeIcon = null;
	public BasedPlatformStairIcon<CurvePlatformIcon> basedPlatformStairIcon = null;

	private int linerRenderCount=0;
	public void CurvePlatformIconCreate<T>(T thisGameObject, string objName, GameObject leftUpPoint, GameObject rightUpPoint, GameObject rightDownPoint, GameObject leftDownPoint, GameObject leftMidPoint, GameObject rightMidPoint)
	where T : Component
	{
		InitBodySetting(objName, (int)BodyType.GeneralBody);
		InitIconMenuButtonSetting();

		centerX=(leftUpPoint.transform.position.x+rightUpPoint.transform.position.x)/2.0f;

		this.leftUpPoint = leftUpPoint;
		this.rightUpPoint = rightUpPoint;
		this.rightDownPoint = rightDownPoint;
		this.leftDownPoint = leftDownPoint;
		this.leftMidPoint = leftMidPoint;
		this.rightMidPoint = rightMidPoint;


		initPlatformHeight = platformHeight = rightUpPoint.transform.position.y - rightDownPoint.transform.position.y;
		initPlatformTopWidth = platformTopWidth = (rightUpPoint.transform.position.x - leftUpPoint.transform.position.x);
		initPlatformButtonWidth = platformButtonWidth = (rightDownPoint.transform.position.x - leftDownPoint.transform.position.x);




        Debug.Log((int)PointIndex.LeftMidPoint);
        Debug.Log(controlPointList.Count);


        ini_platMidWidthDis = platMidWidthDis = (rightMidPoint.transform.position.x - leftMidPoint.transform.position.x);
        ini_platMid2TopDis = platMid2TopDis = (rightUpPoint.transform.position.y - rightMidPoint.transform.position.y);



		//RightCatmullromLine
		GameObject cR = new GameObject("CatLine_Right");
		cR.transform.parent = thisGameObject.transform;
		rightPlatformLine.catLine = cR.AddComponent<catline>();
		rightPlatformLine.controlPointList.Add(rightUpPoint);
		rightPlatformLine.controlPointList.Add(rightMidPoint);
		rightPlatformLine.controlPointList.Add(rightDownPoint);
		rightPlatformLine.catLine.AddControlPoint(rightUpPoint);
		rightPlatformLine.catLine.AddControlPoint(rightMidPoint);
		rightPlatformLine.catLine.AddControlPoint(rightDownPoint);
		//RightCatmullromLine
		GameObject cL = new GameObject("CatLine_Left");
		cL.transform.parent = thisGameObject.transform;
		leftPlatformLine.catLine = cR.AddComponent<catline>();
		leftPlatformLine.controlPointList.Add(leftUpPoint);
		leftPlatformLine.controlPointList.Add(leftMidPoint);
		leftPlatformLine.controlPointList.Add(leftDownPoint);
		leftPlatformLine.catLine.AddControlPoint(leftUpPoint);
		leftPlatformLine.catLine.AddControlPoint(leftMidPoint);
		leftPlatformLine.catLine.AddControlPoint(leftDownPoint);


		rightPlatformLine.catLine.SetLineNumberOfPoints(numberOfPoints);
		rightPlatformLine.catLine.ResetCatmullRom();

		leftPlatformLine.catLine.SetLineNumberOfPoints(numberOfPoints);
		leftPlatformLine.catLine.ResetCatmullRom();


		controlPointList.Add(leftUpPoint);
		controlPointList.Add(rightUpPoint);
		controlPointList.Add(rightDownPoint);
		controlPointList.Add(leftDownPoint);
		controlPointList.Add(leftMidPoint);
		controlPointList.Add(rightMidPoint);


		InitControlPointList2lastControlPointPosition();

		SetParent2BodyAndControlPointList(thisGameObject);
		InitLineRender(thisGameObject);

		SetIconObjectColor();

		AdjMesh();
	}
	public void AdjMesh()
	{
		int innerPointCount = rightPlatformLine.catLine.innerPointList.Count;

		Vector3[] v = new Vector3[2 * innerPointCount];
		Vector3[] n = new Vector3[2 * innerPointCount];
		//Vector2[] uv = new Vector2[2 * innerPointCount];
		int[] t = new int[6 * innerPointCount];

		for (int i = 0; i < innerPointCount; i++)
		{
			v[i] = rightPlatformLine.catLine.innerPointList[i];
		}
		for (int i = 0; i < innerPointCount; i++)
		{
			v[i + innerPointCount] = leftPlatformLine.catLine.innerPointList[i];
		}
		int index = 0;
		for (int i = 0; i < innerPointCount - 1; i++)
		{
			t[index] = i;
			t[index + 1] = (i + 1);
			t[index + 2] = i + innerPointCount;
			t[index + 3] = i + innerPointCount;
			t[index + 4] = (i + 1);
			t[index + 5] = (i + 1) + innerPointCount;
			index += 6;
		}
		for (int i = 0; i < 2 * innerPointCount; i++)
		{
			n[i] = -Vector3.forward;
		}
		bodyStruct.mFilter.mesh.Clear();
		bodyStruct.mFilter.mesh.vertices = v;
		bodyStruct.mFilter.mesh.triangles = t;
		bodyStruct.mFilter.mesh.normals = n;

		bodyStruct.mFilter.mesh.RecalculateNormals();
		bodyStruct.mFilter.mesh.RecalculateBounds();
		//mFilter.mesh.uv = uv;
		UpdateLineRender();
		UpdateCollider();
	}
	public override void InitLineRender<T>(T thisGameObject)
	{
		for (int i = 0; i < rightPlatformLine.catLine.innerPointList.Count - 1; i += sliceUnit)
		{
			i = Mathf.Min(i, rightPlatformLine.catLine.innerPointList.Count - 1);
			CreateLineRenderer(thisGameObject, rightPlatformLine.catLine.innerPointList[i], rightPlatformLine.catLine.innerPointList[Mathf.Min((i + sliceUnit), rightPlatformLine.catLine.innerPointList.Count - 1)]);
			linerRenderCount++;
			if (i == rightPlatformLine.catLine.innerPointList.Count - 1) return;
		}
		for (int i = 0; i < leftPlatformLine.catLine.innerPointList.Count - 1; i += sliceUnit)
		{
			i = Mathf.Min(i, leftPlatformLine.catLine.innerPointList.Count - 1);
			CreateLineRenderer(thisGameObject, leftPlatformLine.catLine.innerPointList[i], leftPlatformLine.catLine.innerPointList[Mathf.Min((i + sliceUnit), leftPlatformLine.catLine.innerPointList.Count - 1)]);
			linerRenderCount++;
			if (i == leftPlatformLine.catLine.innerPointList.Count - 1) return;
		}
		CreateLineRenderer(thisGameObject, leftPlatformLine.catLine.innerPointList[0], rightPlatformLine.catLine.innerPointList[0]);
		CreateLineRenderer(thisGameObject, leftPlatformLine.catLine.innerPointList[leftPlatformLine.catLine.innerPointList.Count - 1], rightPlatformLine.catLine.innerPointList[rightPlatformLine.catLine.innerPointList.Count - 1]);
	}
	public override void UpdateLineRender()
	{
		int size = linerRenderCount;
		for (int i = 0; i < size / 2; i++)
		{
			AdjLineRenderer(i, rightPlatformLine.catLine.innerPointList[i * sliceUnit], rightPlatformLine.catLine.innerPointList[Mathf.Min((i * sliceUnit + sliceUnit), rightPlatformLine.catLine.innerPointList.Count - 1)]);
		}
		for (int i = 0; i < size / 2; i++)
		{
			AdjLineRenderer(i + size / 2, leftPlatformLine.catLine.innerPointList[i * sliceUnit], leftPlatformLine.catLine.innerPointList[Mathf.Min((i * sliceUnit + sliceUnit), leftPlatformLine.catLine.innerPointList.Count - 1)]);
		}
		AdjLineRenderer(size, leftPlatformLine.catLine.innerPointList[0], rightPlatformLine.catLine.innerPointList[0]);
		AdjLineRenderer(size + 1, leftPlatformLine.catLine.innerPointList[leftPlatformLine.catLine.innerPointList.Count - 1], rightPlatformLine.catLine.innerPointList[rightPlatformLine.catLine.innerPointList.Count - 1]);
	}
	public Vector3 ClampPos(Vector3 inputPos, GameObject chooseObj)
	{

		float minClampX = float.MinValue;
		float maxClampX = float.MaxValue;
		float minClampY = float.MinValue;
		float maxClampY = float.MaxValue;

		float minWidth = initPlatformTopWidth*0.2f;
		float minHeight = initPlatformHeight*0.2f;
		if (chooseObj == controlPointList[(int)PointIndex.LeftUpPoint])
		{
			if (basedPlatformBalustradeIcon != null)
				maxClampX = basedPlatformBalustradeIcon.leftUpPoint.transform.position.x;
			else
				maxClampX = centerX - minWidth/2.0f;
			minClampY = controlPointList[(int)PointIndex.LeftMidPoint].transform.position.y + minHeight/2.0f;
		}
		else if (chooseObj == controlPointList[(int)PointIndex.LeftDownPoint])
		{
			maxClampX = centerX - minWidth/2.0f;
			maxClampY = controlPointList[(int)PointIndex.LeftMidPoint].transform.position.y - minHeight / 2.0f;
		}
		else if (chooseObj == controlPointList[(int)PointIndex.RightUpPoint])
		{
			if (basedPlatformBalustradeIcon != null)
				minClampX = basedPlatformBalustradeIcon.rightUpPoint.transform.position.x;
			else
				minClampX = centerX + minWidth / 2.0f;

			minClampY = controlPointList[(int)PointIndex.RightMidPoint].transform.position.y + minHeight / 2.0f;

		}
		else if (chooseObj == controlPointList[(int)PointIndex.RightDownPoint])
		{
			minClampX = centerX + minWidth / 2.0f;
			maxClampY = controlPointList[(int)PointIndex.RightMidPoint].transform.position.y - minHeight / 2.0f;
		}
		else if (chooseObj == controlPointList[(int)PointIndex.RightMidPoint])
		{
			minClampX = centerX + minWidth / 2.0f;
			maxClampY = controlPointList[(int)PointIndex.RightUpPoint].transform.position.y - minHeight / 2.0f;
			minClampY = controlPointList[(int)PointIndex.RightDownPoint].transform.position.y + minHeight / 2.0f;
		}
		else if (chooseObj == controlPointList[(int)PointIndex.LeftMidPoint])
		{
			maxClampX = centerX -minWidth / 2.0f;
			maxClampY = controlPointList[(int)PointIndex.LeftUpPoint].transform.position.y - minHeight/2.0f;
			minClampY = controlPointList[(int)PointIndex.LeftDownPoint].transform.position.y + minHeight / 2.0f;
		}
		float posX = Mathf.Clamp(inputPos.x, minClampX, maxClampX);
		float posY = Mathf.Clamp(inputPos.y, minClampY, maxClampY);
		return new Vector3(posX, posY, inputPos.z);
	}
	public Vector3 AdjPos(Vector3 tmp, GameObject chooseObj)
	{
		int index = -1;
		for (int i = 0; i < controlPointList.Count; i++)
		{
			if (chooseObj == controlPointList[i])
			{
				index = i;
				break;
			}
		}
		if (index == -1) return Vector3.zero;
		float offset_x = tmp.x - lastControlPointPosition[index].x;
		float offset_y = tmp.y - lastControlPointPosition[index].y;

		if (chooseObj == controlPointList[(int)PointIndex.LeftUpPoint])
		{
			controlPointList[(int)PointIndex.RightUpPoint].transform.position = new Vector3(controlPointList[(int)PointIndex.RightUpPoint].transform.position.x - (offset_x), tmp.y, controlPointList[(int)PointIndex.RightUpPoint].transform.position.z);

			controlPointList[(int)PointIndex.RightMidPoint].transform.position = (controlPointList[(int)PointIndex.RightUpPoint].transform.position + controlPointList[(int)PointIndex.RightDownPoint].transform.position)/2.0f;

			controlPointList[(int)PointIndex.LeftMidPoint].transform.position = (controlPointList[(int)PointIndex.LeftUpPoint].transform.position + controlPointList[(int)PointIndex.LeftDownPoint].transform.position) / 2.0f; 
		}
		else if (chooseObj == controlPointList[(int)PointIndex.LeftDownPoint])
		{
			controlPointList[(int)PointIndex.RightDownPoint].transform.position = new Vector3(controlPointList[(int)PointIndex.RightDownPoint].transform.position.x - (offset_x), tmp.y, controlPointList[(int)PointIndex.RightDownPoint].transform.position.z);

			controlPointList[(int)PointIndex.RightMidPoint].transform.position = (controlPointList[(int)PointIndex.RightUpPoint].transform.position + controlPointList[(int)PointIndex.RightDownPoint].transform.position) / 2.0f;

			controlPointList[(int)PointIndex.LeftMidPoint].transform.position = (controlPointList[(int)PointIndex.LeftUpPoint].transform.position + controlPointList[(int)PointIndex.LeftDownPoint].transform.position) / 2.0f; 
		}
		else if (chooseObj == controlPointList[(int)PointIndex.RightUpPoint])
		{
			controlPointList[(int)PointIndex.LeftUpPoint].transform.position = new Vector3(controlPointList[(int)PointIndex.LeftUpPoint].transform.position.x - (offset_x), tmp.y, controlPointList[(int)PointIndex.LeftUpPoint].transform.position.z);

			controlPointList[(int)PointIndex.RightMidPoint].transform.position = (controlPointList[(int)PointIndex.RightUpPoint].transform.position + controlPointList[(int)PointIndex.RightDownPoint].transform.position) / 2.0f;

			controlPointList[(int)PointIndex.LeftMidPoint].transform.position = (controlPointList[(int)PointIndex.LeftUpPoint].transform.position + controlPointList[(int)PointIndex.LeftDownPoint].transform.position) / 2.0f; 
		}
		else if (chooseObj == controlPointList[(int)PointIndex.RightDownPoint])
		{
			controlPointList[(int)PointIndex.LeftDownPoint].transform.position = new Vector3(controlPointList[(int)PointIndex.LeftDownPoint].transform.position.x - (offset_x), tmp.y, controlPointList[(int)PointIndex.LeftDownPoint].transform.position.z);

			controlPointList[(int)PointIndex.RightMidPoint].transform.position = (controlPointList[(int)PointIndex.RightUpPoint].transform.position + controlPointList[(int)PointIndex.RightDownPoint].transform.position) / 2.0f;

			controlPointList[(int)PointIndex.LeftMidPoint].transform.position = (controlPointList[(int)PointIndex.LeftUpPoint].transform.position + controlPointList[(int)PointIndex.LeftDownPoint].transform.position) / 2.0f; 
		}
		else if (chooseObj == controlPointList[(int)PointIndex.RightMidPoint])
		{
			controlPointList[(int)PointIndex.LeftMidPoint].transform.position = new Vector3(controlPointList[(int)PointIndex.LeftMidPoint].transform.position.x - (offset_x), tmp.y, controlPointList[(int)PointIndex.LeftMidPoint].transform.position.z); 
		}
		else if (chooseObj == controlPointList[(int)PointIndex.LeftMidPoint])
		{
			controlPointList[(int)PointIndex.RightMidPoint].transform.position = new Vector3(controlPointList[(int)PointIndex.RightMidPoint].transform.position.x - (offset_x), tmp.y, controlPointList[(int)PointIndex.RightMidPoint].transform.position.z); 
		}
		if (chooseObj == rightUpPoint || chooseObj == leftUpPoint)
		{
			if (basedPlatformBalustradeIcon != null)
			{
				for (int i = 0; i < basedPlatformBalustradeIcon.rightColumn.controlPointList.Count; i++)
				{
					basedPlatformBalustradeIcon.rightColumn.controlPointList[i].transform.position = new Vector3(basedPlatformBalustradeIcon.rightColumn.controlPointList[i].transform.position.x, basedPlatformBalustradeIcon.rightColumn.controlPointList[i].transform.position.y + (offset_y), basedPlatformBalustradeIcon.rightColumn.controlPointList[i].transform.position.z);
					basedPlatformBalustradeIcon.leftColumn.controlPointList[i].transform.position = new Vector3(basedPlatformBalustradeIcon.leftColumn.controlPointList[i].transform.position.x, basedPlatformBalustradeIcon.leftColumn.controlPointList[i].transform.position.y + (offset_y), basedPlatformBalustradeIcon.leftColumn.controlPointList[i].transform.position.z);

				}
				basedPlatformBalustradeIcon.UpdateLastPos();
			}
		}
		if (basedPlatformStairIcon != null)
		{
			basedPlatformStairIcon.AdjPos(leftUpPoint, rightUpPoint, rightDownPoint, leftDownPoint);
			basedPlatformStairIcon.AdjMesh();
			basedPlatformStairIcon.UpdateLastPos();
		}
		platformHeight = rightUpPoint.transform.position.y - rightDownPoint.transform.position.y;
		platformTopWidth = (rightUpPoint.transform.position.x - leftUpPoint.transform.position.x);
		platformButtonWidth = (rightDownPoint.transform.position.x - leftDownPoint.transform.position.x);
		platMidWidthDis = (rightMidPoint.transform.position.x - leftMidPoint.transform.position.x);
		platMid2TopDis = (rightUpPoint.transform.position.y - rightMidPoint.transform.position.y);
		UpdateLastPos();
		UpdateLineRender();

		rightPlatformLine.catLine.ResetCatmullRom();
		leftPlatformLine.catLine.ResetCatmullRom();
		return new Vector3(offset_x, offset_y, 0);
	}

	public void CreateBasedPlatformBalustrade<T>(T thisGameObject, string objName, float ini_platBalustradeHeight, GameObject correspondingDragItemObject) where T : Component
	{
		basedPlatformBalustradeIcon = new BasedPlatformBalustradeIcon<CurvePlatformIcon>();
		basedPlatformBalustradeIcon.BasedPlatformBalustradeCreate(thisGameObject, objName, this, ini_platBalustradeHeight, correspondingDragItemObject);
	}
	public void CreateBasedPlatformStair<T>(T thisGameObject, string objName, float stairWidth, GameObject correspondingDragItemObject) where T : Component
	{
		basedPlatformStairIcon = new BasedPlatformStairIcon<CurvePlatformIcon>();
		basedPlatformStairIcon.BasedPlatformStairCreate(thisGameObject, objName, this, stairWidth, correspondingDragItemObject);
	}
	public override void InitIconMenuButtonUpdate()
	{
		if (basedPlatformBalustradeIcon != null) basedPlatformBalustradeIcon.InitIconMenuButtonUpdate();
		if (basedPlatformStairIcon != null) basedPlatformStairIcon.InitIconMenuButtonUpdate();
	}
}
public class BasedPlatformIcon : PlatFormIcon
{

	public BasedPlatformBalustradeIcon<BasedPlatformIcon> basedPlatformBalustradeIcon = null;
	public BasedPlatformStairIcon<BasedPlatformIcon> basedPlatformStairIcon = null;
	public void BasedPlatformIconCreate<T>(T thisGameObject, string objName, GameObject leftUpPoint, GameObject rightUpPoint, GameObject rightDownPoint, GameObject leftDownPoint)
	where T : Component
	{
		InitBodySetting("BasedPlatformIcon", (int)BodyType.GeneralBody);
		InitIconMenuButtonSetting();

		centerX=(leftUpPoint.transform.position.x+rightUpPoint.transform.position.x)/2.0f;

		this.rightUpPoint = rightUpPoint;
		this.rightDownPoint = rightDownPoint;
		this.leftUpPoint = leftUpPoint;
		this.leftDownPoint = leftDownPoint;


		initPlatformHeight = platformHeight = rightUpPoint.transform.position.y - rightDownPoint.transform.position.y;
		initPlatformTopWidth = platformTopWidth = (rightUpPoint.transform.position.x - leftUpPoint.transform.position.x);
		initPlatformButtonWidth = platformButtonWidth = (rightDownPoint.transform.position.x - leftDownPoint.transform.position.x);

		bodyStruct.mFilter.mesh = CreatRecMesh(leftUpPoint.transform.position, rightUpPoint.transform.position, rightDownPoint.transform.position, leftDownPoint.transform.position, bodyStruct.mFilter.mesh);

		//初始位置
		controlPointList.Add(leftUpPoint);
		controlPointList.Add(rightUpPoint);
		controlPointList.Add(rightDownPoint);
		controlPointList.Add(leftDownPoint);
		InitControlPointList2lastControlPointPosition();

		SetParent2BodyAndControlPointList(thisGameObject);
		InitLineRender(thisGameObject);
		SetIconObjectColor();
	}
	public Vector3 ClampPos(Vector3 inputPos, GameObject chooseObj)
	{
		float minClampX = float.MinValue;
		float maxClampX = float.MaxValue;
		float minClampY = float.MinValue;
		float maxClampY = float.MaxValue;

		float minWidth = (initPlatformTopWidth) * 0.2f;
		float minHeight = (initPlatformHeight) * 0.2f;

		if (chooseObj == controlPointList[(int)PointIndex.LeftUpPoint])
		{
			if (basedPlatformBalustradeIcon != null)
				maxClampX = basedPlatformBalustradeIcon.leftUpPoint.transform.position.x;
			else
				maxClampX = centerX - minWidth/2.0f;
			minClampY = controlPointList[(int)PointIndex.LeftDownPoint].transform.position.y + minHeight;
		}
		else if (chooseObj == controlPointList[(int)PointIndex.LeftDownPoint])
		{
			maxClampX = centerX - minWidth / 2.0f;
			maxClampY = controlPointList[(int)PointIndex.LeftUpPoint].transform.position.y - minHeight;
		}
		else if (chooseObj == controlPointList[(int)PointIndex.RightUpPoint])
		{
			if (basedPlatformBalustradeIcon != null)
				minClampX = basedPlatformBalustradeIcon.rightUpPoint.transform.position.x;
			else
				minClampX = centerX+ minWidth/2.0f;

			minClampY = controlPointList[(int)PointIndex.RightDownPoint].transform.position.y + minHeight;

		}
		else if (chooseObj == controlPointList[(int)PointIndex.RightDownPoint])
		{
			minClampX = centerX + minWidth / 2.0f;
			maxClampY = controlPointList[(int)PointIndex.RightUpPoint].transform.position.y - minHeight;
		}

		float posX = Mathf.Clamp(inputPos.x, minClampX, maxClampX);
		float posY = Mathf.Clamp(inputPos.y, minClampY, maxClampY);
		return new Vector3(posX, posY, inputPos.z);
	}
	public Vector3 AdjPos(Vector3 tmp, GameObject chooseObj)
	{
		int index = -1;
		for (int i = 0; i < controlPointList.Count; i++)
		{
			if (chooseObj == controlPointList[i])
			{
				index = i;
				break;
			}
		}
		if (index == -1) return Vector3.zero;

		float offset_x = tmp.x - lastControlPointPosition[index].x;
		float offset_y = tmp.y - lastControlPointPosition[index].y;

		if (chooseObj == controlPointList[(int)PointIndex.LeftUpPoint])
		{
			controlPointList[(int)PointIndex.RightUpPoint].transform.position = new Vector3(controlPointList[(int)PointIndex.RightUpPoint].transform.position.x - (offset_x), tmp.y, controlPointList[(int)PointIndex.RightUpPoint].transform.position.z);
		}
		else if (chooseObj == controlPointList[(int)PointIndex.LeftDownPoint])
		{
			controlPointList[(int)PointIndex.RightUpPoint].transform.position = new Vector3(controlPointList[(int)PointIndex.RightUpPoint].transform.position.x - (offset_x), tmp.y, controlPointList[(int)PointIndex.RightUpPoint].transform.position.z);
		}
		else if (chooseObj == controlPointList[(int)PointIndex.RightUpPoint])
		{
			controlPointList[(int)PointIndex.LeftUpPoint].transform.position = new Vector3(controlPointList[(int)PointIndex.LeftUpPoint].transform.position.x - (offset_x), tmp.y, controlPointList[(int)PointIndex.LeftUpPoint].transform.position.z);
		}
		else if (chooseObj == controlPointList[(int)PointIndex.RightDownPoint])
		{
			controlPointList[(int)PointIndex.LeftDownPoint].transform.position = new Vector3(controlPointList[(int)PointIndex.LeftDownPoint].transform.position.x - (offset_x), tmp.y, controlPointList[(int)PointIndex.LeftDownPoint].transform.position.z);
		}
		if (chooseObj == rightUpPoint || chooseObj == leftUpPoint)
		{
			if (basedPlatformBalustradeIcon != null)
			{
				for (int i = 0; i < basedPlatformBalustradeIcon.rightColumn.controlPointList.Count; i++)
				{
					basedPlatformBalustradeIcon.rightColumn.controlPointList[i].transform.position = new Vector3(basedPlatformBalustradeIcon.rightColumn.controlPointList[i].transform.position.x, basedPlatformBalustradeIcon.rightColumn.controlPointList[i].transform.position.y + (offset_y), basedPlatformBalustradeIcon.rightColumn.controlPointList[i].transform.position.z);
					basedPlatformBalustradeIcon.leftColumn.controlPointList[i].transform.position = new Vector3(basedPlatformBalustradeIcon.leftColumn.controlPointList[i].transform.position.x, basedPlatformBalustradeIcon.leftColumn.controlPointList[i].transform.position.y + (offset_y), basedPlatformBalustradeIcon.leftColumn.controlPointList[i].transform.position.z);

				}
				basedPlatformBalustradeIcon.UpdateLastPos();
			}
		}
		if (basedPlatformStairIcon != null)
		{
			basedPlatformStairIcon.AdjPos(leftUpPoint, rightUpPoint, rightDownPoint, leftDownPoint);
			basedPlatformStairIcon.AdjMesh();
			basedPlatformStairIcon.UpdateLastPos();
		}
		platformHeight = rightUpPoint.transform.position.y - rightDownPoint.transform.position.y;
		platformTopWidth = (rightUpPoint.transform.position.x - leftUpPoint.transform.position.x);
		platformButtonWidth = (rightDownPoint.transform.position.x - leftDownPoint.transform.position.x);
		UpdateLastPos();
		UpdateLineRender();
		return new Vector3(offset_x, offset_y, 0);
	}

	public void CreateBasedPlatformBalustrade<T>(T thisGameObject, string objName, float ini_platBalustradeHeight, GameObject correspondingDragItemObject) where T : Component
	{
		basedPlatformBalustradeIcon = new BasedPlatformBalustradeIcon<BasedPlatformIcon>();
		basedPlatformBalustradeIcon.BasedPlatformBalustradeCreate(thisGameObject, objName, this, ini_platBalustradeHeight, correspondingDragItemObject);
	}
	public void CreateBasedPlatformStair<T>(T thisGameObject, string objName, float stairWidth, GameObject correspondingDragItemObject) where T : Component
	{
		basedPlatformStairIcon = new BasedPlatformStairIcon<BasedPlatformIcon>();
		basedPlatformStairIcon.BasedPlatformStairCreate(thisGameObject, objName, this, stairWidth, correspondingDragItemObject);
	}
	public override void InitIconMenuButtonUpdate()
	{
		if (basedPlatformBalustradeIcon != null) basedPlatformBalustradeIcon.InitIconMenuButtonUpdate();
		if (basedPlatformStairIcon != null) basedPlatformStairIcon.InitIconMenuButtonUpdate();
	}
}
public class platform2icon : MonoBehaviour
{
	public enum PointIndex { LeftUpPoint = 0, RightUpPoint = 1, RightDownPoint = 2, LeftDownPoint = 3, LeftMidPoint = 4, RightMidPoint = 5, };
	public List<GameObject> controlPointList = new List<GameObject>();


	private DragItemController dragitemcontroller;
	private Movement movement;

	[HideInInspector]
	[SerializeField]
	public BasedPlatformIcon basedPlatformIcon;
	[HideInInspector]
	[SerializeField]
	public CurvePlatformIcon curvePlatformIcon;
	public float stairWidth;
	//for ratio
	public float platMidWidthDis;
	public float ini_platMidWidthDis;
	public float platMid2TopDis;
	public float ini_platMid2TopDis;
	public float platTopWidthDis;
	public float ini_platTopWidthDis;
	public float platButtomWidthDis;
	public float ini_platButtomWidthDis;
	public float platHeightDis;
	public float ini_platHeightDis;
	public Vector2 platBalustradeDis;
	public Vector2 ini_platBalustradeDis;

	public bool isPlatformBalustrade;
	public bool isPlatformStair;

	public float platHeightChange;
	void Awake()
	{
		dragitemcontroller = GameObject.Find("DragItemController").GetComponent<DragItemController>();
		movement = GameObject.Find("Movement").GetComponent<Movement>();


		switch (gameObject.tag)
		{
			case "CurvePlatformIcon"://specialCase
				curvePlatformIcon = CreateCurvePlatformIcon();
				break;
			case "BasedPlatformIcon"://specialCase
				basedPlatformIcon = CreateBasedPlatformIcon();
				break;
		}

       
	}
	private CurvePlatformIcon CreateCurvePlatformIcon()
	{
		CurvePlatformIcon curvePlatformIcon = new CurvePlatformIcon();

		curvePlatformIcon.CurvePlatformIconCreate(this, "CurvePlatformIcon", controlPointList[(int)PointIndex.LeftUpPoint], controlPointList[(int)PointIndex.RightUpPoint], controlPointList[(int)PointIndex.RightDownPoint], controlPointList[(int)PointIndex.LeftDownPoint], controlPointList[(int)PointIndex.LeftMidPoint], controlPointList[(int)PointIndex.RightMidPoint]);

		ini_platTopWidthDis = platTopWidthDis = (controlPointList[(int)PointIndex.RightUpPoint].transform.position.x - controlPointList[(int)PointIndex.LeftUpPoint].transform.position.x) / 2.0f;
		ini_platButtomWidthDis = platButtomWidthDis = (controlPointList[(int)PointIndex.RightDownPoint].transform.position.x - controlPointList[(int)PointIndex.LeftDownPoint].transform.position.x) / 2.0f;
		ini_platHeightDis = (controlPointList[(int)PointIndex.RightUpPoint].transform.position.y - controlPointList[(int)PointIndex.RightDownPoint].transform.position.y);

		ini_platMidWidthDis=platMidWidthDis = (controlPointList[(int)PointIndex.RightMidPoint].transform.position.x - controlPointList[(int)PointIndex.LeftMidPoint].transform.position.x) / 2.0f;
		ini_platMid2TopDis = platMid2TopDis = (controlPointList[(int)PointIndex.RightUpPoint].transform.position.y - controlPointList[(int)PointIndex.RightMidPoint].transform.position.y);

		ini_platBalustradeDis.x = ini_platTopWidthDis;
		ini_platBalustradeDis.y = ini_platHeightDis * 0.8f;

		stairWidth = ini_platTopWidthDis * 0.3f;

		return curvePlatformIcon;
	}
	private BasedPlatformIcon CreateBasedPlatformIcon()
	{
		BasedPlatformIcon basedPlatformIcon = new BasedPlatformIcon();

		basedPlatformIcon.BasedPlatformIconCreate(this, "BasedPlatformIcon", controlPointList[(int)PointIndex.LeftUpPoint], controlPointList[(int)PointIndex.RightUpPoint], controlPointList[(int)PointIndex.RightDownPoint], controlPointList[(int)PointIndex.LeftDownPoint]);

		ini_platTopWidthDis = platTopWidthDis = (controlPointList[(int)PointIndex.RightUpPoint].transform.position.x - controlPointList[(int)PointIndex.LeftUpPoint].transform.position.x) / 2.0f;
		ini_platButtomWidthDis = platButtomWidthDis = (controlPointList[(int)PointIndex.RightDownPoint].transform.position.x - controlPointList[(int)PointIndex.LeftDownPoint].transform.position.x) / 2.0f;
		ini_platHeightDis = (controlPointList[(int)PointIndex.RightUpPoint].transform.position.y - controlPointList[(int)PointIndex.RightDownPoint].transform.position.y);


		ini_platBalustradeDis.x = ini_platTopWidthDis;
		ini_platBalustradeDis.y = ini_platHeightDis * 0.8f;

		stairWidth = ini_platTopWidthDis * 0.3f;

		return basedPlatformIcon;
	}
	public void adjPos()
	{
		platHeightChange=0;
		Vector3 offset;
		Vector3 tmp = dragitemcontroller.chooseObj.transform.position;
		GameObject chooseObj = dragitemcontroller.chooseObj;
		switch (gameObject.tag)
		{
			case "CurvePlatformIcon"://specialCase
				offset=curvePlatformIcon.AdjPos(tmp, chooseObj);
				curvePlatformIcon.AdjMesh();
				
				if (chooseObj == curvePlatformIcon.rightUpPoint || chooseObj == curvePlatformIcon.leftUpPoint)
				{
					platTopWidthDis = curvePlatformIcon.platformTopWidth / 2.0f;
					platHeightDis = curvePlatformIcon.platformHeight;
					platHeightChange=offset.y;
				}
				else if (chooseObj == curvePlatformIcon.rightDownPoint || chooseObj == curvePlatformIcon.leftDownPoint)
				{
					platButtomWidthDis = curvePlatformIcon.platformButtonWidth / 2.0f;
					platHeightDis = curvePlatformIcon.platformHeight;
					platHeightChange = -offset.y;
				}
				else if (chooseObj == curvePlatformIcon.rightMidPoint || chooseObj == curvePlatformIcon.leftMidPoint)
				{
					platMidWidthDis = curvePlatformIcon.platMidWidthDis/2.0f;
					platMid2TopDis = curvePlatformIcon.platMid2TopDis;
				}
				if (isPlatformBalustrade)
				{
					if (chooseObj == curvePlatformIcon.basedPlatformBalustradeIcon.rightColumn.bodyStruct.body || chooseObj == curvePlatformIcon.basedPlatformBalustradeIcon.leftColumn.bodyStruct.body || chooseObj == curvePlatformIcon.basedPlatformBalustradeIcon.rightUpPoint || chooseObj == curvePlatformIcon.basedPlatformBalustradeIcon.leftUpPoint || chooseObj == curvePlatformIcon.basedPlatformBalustradeIcon.rightDownPoint || chooseObj == curvePlatformIcon.basedPlatformBalustradeIcon.leftDownPoint)
					{
						curvePlatformIcon.basedPlatformBalustradeIcon.AdjPos(tmp, chooseObj);
					}

					platBalustradeDis.x = curvePlatformIcon.basedPlatformBalustradeIcon.columnWidth / 2.0f;
					platBalustradeDis.y = curvePlatformIcon.basedPlatformBalustradeIcon.columnHeight;
				}
				break;
			case "BasedPlatformIcon"://specialCase
				offset=basedPlatformIcon.AdjPos(tmp, chooseObj);
				basedPlatformIcon.AdjMesh();
				
				if (chooseObj == basedPlatformIcon.rightUpPoint || chooseObj == basedPlatformIcon.leftUpPoint)
				{
					platTopWidthDis = basedPlatformIcon.platformTopWidth / 2.0f;
					platHeightDis = basedPlatformIcon.platformHeight;
					
					platHeightChange = offset.y;
				}
				else if (chooseObj == basedPlatformIcon.rightDownPoint || chooseObj == basedPlatformIcon.leftDownPoint)
				{
	
					platButtomWidthDis = basedPlatformIcon.platformButtonWidth / 2.0f;
					platHeightDis = basedPlatformIcon.platformHeight;

					platHeightChange = -offset.y;
				}
				if (isPlatformBalustrade)
				{
					if (chooseObj == basedPlatformIcon.basedPlatformBalustradeIcon.rightColumn.bodyStruct.body || chooseObj == basedPlatformIcon.basedPlatformBalustradeIcon.leftColumn.bodyStruct.body || chooseObj == basedPlatformIcon.basedPlatformBalustradeIcon.rightUpPoint || chooseObj == basedPlatformIcon.basedPlatformBalustradeIcon.leftUpPoint || chooseObj == basedPlatformIcon.basedPlatformBalustradeIcon.rightDownPoint || chooseObj == basedPlatformIcon.basedPlatformBalustradeIcon.leftDownPoint)
					{
						basedPlatformIcon.basedPlatformBalustradeIcon.AdjPos(tmp, chooseObj);
					}

					platBalustradeDis.x = basedPlatformIcon.basedPlatformBalustradeIcon.columnWidth / 2.0f;
					platBalustradeDis.y = basedPlatformIcon.basedPlatformBalustradeIcon.columnHeight;
				}
				break;
		}
		//transform.CenterOnChildred();
	}
	public void DestroyFunction(string objName)
	{
		switch (gameObject.tag)
		{
			case "CurvePlatformIcon"://specialCase
				switch (objName)
				{
					case "BasePlatFormBalustrade":
						isPlatformBalustrade = false;

						curvePlatformIcon.basedPlatformBalustradeIcon = null;
						break;
					case "BasedPlatformStair":
						isPlatformStair = false;
						curvePlatformIcon.basedPlatformStairIcon = null;
						break;
				}
				break;
			case "BasedPlatformIcon"://specialCase
				switch (objName)
				{
					case "BasePlatFormBalustrade":
						isPlatformBalustrade = false;

						basedPlatformIcon.basedPlatformBalustradeIcon = null;
						break;
					case "BasedPlatformStair":
						isPlatformStair = false;
						basedPlatformIcon.basedPlatformStairIcon = null;
						break;
				}
				break;

		}

	}
	public void UpdateFunction(string objName, GameObject correspondingDragItemObject)
	{
		switch (gameObject.tag)
		{
			case "CurvePlatformIcon"://specialCase
				switch (objName)
				{
					case "BasePlatFormBalustrade":
						if (curvePlatformIcon.basedPlatformBalustradeIcon == null)
						{
							isPlatformBalustrade = true;
							curvePlatformIcon.CreateBasedPlatformBalustrade(this, "BasedPlatformBalustradeIcon", ini_platBalustradeDis.y, correspondingDragItemObject);
						}
						break;
					case "BasedPlatformStair":
						if (curvePlatformIcon.basedPlatformStairIcon == null)
						{
							isPlatformStair = true;
							curvePlatformIcon.CreateBasedPlatformStair(this, "BasedPlatformStairIcon", stairWidth, correspondingDragItemObject);
						}
						break;
				}
				break;
			case "BasedPlatformIcon"://specialCase
				switch (objName)
				{
					case "BasePlatFormBalustrade":
						if (basedPlatformIcon.basedPlatformBalustradeIcon == null)
						{
							isPlatformBalustrade = true;
							basedPlatformIcon.CreateBasedPlatformBalustrade(this, "BasedPlatformBalustradeIcon", ini_platBalustradeDis.y, correspondingDragItemObject);
						}
						break;
					case "BasedPlatformStair":
						if (basedPlatformIcon.basedPlatformStairIcon == null)
						{
							isPlatformStair = true;
							basedPlatformIcon.CreateBasedPlatformStair(this, "BasedPlatformStairIcon", stairWidth, correspondingDragItemObject);
						}
						break;
				}
				break;
		}

	}
	public void addpoint()
	{
		controlPointList.RemoveAll(GameObject => GameObject == null);
		switch (gameObject.tag)
		{
			case "CurvePlatformIcon"://specialCase
					movement.freelist.AddRange(controlPointList);
				if (isPlatformBalustrade)
				{
					movement.verlist.Add(curvePlatformIcon.basedPlatformBalustradeIcon.leftUpPoint);
					movement.verlist.Add(curvePlatformIcon.basedPlatformBalustradeIcon.rightUpPoint);
					movement.horlist.Add(curvePlatformIcon.basedPlatformBalustradeIcon.rightDownPoint);
					movement.horlist.Add(curvePlatformIcon.basedPlatformBalustradeIcon.leftDownPoint);

					movement.horlist.Add(curvePlatformIcon.basedPlatformBalustradeIcon.rightColumn.bodyStruct.body);
					movement.horlist.Add(curvePlatformIcon.basedPlatformBalustradeIcon.leftColumn.bodyStruct.body);
				}
				break;
			case "BasedPlatformIcon":
				movement.freelist.AddRange(controlPointList);
				if (isPlatformBalustrade)
				{
					movement.verlist.Add(basedPlatformIcon.basedPlatformBalustradeIcon.leftUpPoint);
					movement.verlist.Add(basedPlatformIcon.basedPlatformBalustradeIcon.rightUpPoint);
					movement.horlist.Add(basedPlatformIcon.basedPlatformBalustradeIcon.rightDownPoint);
					movement.horlist.Add(basedPlatformIcon.basedPlatformBalustradeIcon.leftDownPoint);

					movement.horlist.Add(basedPlatformIcon.basedPlatformBalustradeIcon.rightColumn.bodyStruct.body);
					movement.horlist.Add(basedPlatformIcon.basedPlatformBalustradeIcon.leftColumn.bodyStruct.body);
				}
				break;
		}


	}
	public Vector3 ClampPos(Vector3 inputPos)
	{
		GameObject chooseObj = dragitemcontroller.chooseObj;
		switch (gameObject.tag)
		{
			case "CurvePlatformIcon"://specialCase
				if (curvePlatformIcon.basedPlatformBalustradeIcon != null)
				{
					foreach (GameObject controlPoint in curvePlatformIcon.basedPlatformBalustradeIcon.controlPointList)
					{
						if (chooseObj == controlPoint)
							return curvePlatformIcon.basedPlatformBalustradeIcon.ClampPos(inputPos, chooseObj);
					}
				}

				foreach (GameObject controlPoint in controlPointList)
				{
					if (chooseObj == controlPoint)
						return curvePlatformIcon.ClampPos(inputPos, chooseObj);
				}
				break;
			case "BasedPlatformIcon"://specialCase
				if (basedPlatformIcon.basedPlatformBalustradeIcon != null)
				{
					foreach (GameObject controlPoint in basedPlatformIcon.basedPlatformBalustradeIcon.controlPointList)
					{
						if (chooseObj == controlPoint)
							return basedPlatformIcon.basedPlatformBalustradeIcon.ClampPos(inputPos, chooseObj);
					}
				}

				foreach (GameObject controlPoint in controlPointList)
				{
					if (chooseObj == controlPoint)
						return basedPlatformIcon.ClampPos(inputPos, chooseObj);
				}
				break;
		}

		return inputPos;
	}
	public void IconUpdate()
	{

		switch (gameObject.tag)
		{
			case "CurvePlatformIcon"://specialCase
				curvePlatformIcon.InitIconMenuButtonUpdate();
				break;
			case "BasedPlatformIcon"://specialCase
				basedPlatformIcon.InitIconMenuButtonUpdate();
				break;
		}
	}
}