/*
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RecMeshCreate : IconObject
{
	public Mesh CreatRecMesh(Vector3 lu, Vector3 ru, Vector3 rd, Vector3 ld, Mesh ismesh)
	{
		if (!ismesh)
		{
			ismesh = new Mesh();
			if (mCollider.GetComponent<MeshCollider>()) 
				mCollider.GetComponent<MeshCollider>().sharedMesh = ismesh;
		}
		ismesh.vertices = new Vector3[] {

			lu,
			ru,
			rd,
			ld
		};
		ismesh.triangles = new int[] { 0, 1, 2, 0, 2, 3 };
		ismesh.RecalculateNormals();

		return ismesh;
	}
	public override void InitLineRender<T>(T thisGameObject)
	{
		for (int i = 0; i < controlPointList.Count; i++)
		{
			controlPointList_Vec3_2_LineRender.Add(controlPointList[i].transform.position);
		}

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
		for (int i = 0; i < controlPointList.Count; i++)
		{
			controlPointList_Vec3_2_LineRender[i] = (controlPointList[i].transform.position);
		}
		for (int i = 0; i < lineRenderList.Count; i++)
		{
			if (i != controlPointList_Vec3_2_LineRender.Count - 1)
				AdjLineRenderer(i, controlPointList_Vec3_2_LineRender[i], controlPointList_Vec3_2_LineRender[i + 1]);
			else
				AdjLineRenderer(i, controlPointList_Vec3_2_LineRender[i], controlPointList_Vec3_2_LineRender[0]);
		}
	}
}
public class DoubleRoofIcon : RecMeshCreate
{
	public enum PointIndex { LeftUpPoint = 0, RightUpPoint = 1, RightDownPoint = 2, LeftDownPoint = 3, };
	public Vector3 rightUpPoint;
	public Vector3 rightDownPoint;
	public Vector3 leftUpPoint;
	public Vector3 leftDownPoint;
	public float doubleRoofWidth;
	public float doubleRoofHeight;
	public void DoubleRoofIconCreate<T>(T thisGameObject, string objName, ColumnIcon columnIcon, float doubleRoofHeight, float doubleRoofWidth)
	where T : Component
	{
		InitBodySetting(objName,(int)BodyType.GeneralBody);

		this.doubleRoofHeight=doubleRoofHeight;
		this.doubleRoofWidth = doubleRoofWidth;

		rightDownPoint = columnIcon.rightColumn.upPoint.transform.position;
		leftDownPoint = columnIcon.leftColumn.upPoint.transform.position;

		float tmp = rightDownPoint.y + doubleRoofHeight;
		rightUpPoint = new Vector3(rightDownPoint.x, tmp, rightDownPoint.z);
		leftUpPoint = new Vector3(leftDownPoint.x, tmp, leftDownPoint.z);

		rightDownPoint.x = rightDownPoint.x + doubleRoofWidth;
		leftDownPoint.x = leftDownPoint.x - doubleRoofWidth;

		mFilter.mesh = CreatRecMesh(leftUpPoint, rightUpPoint, rightDownPoint, leftDownPoint, mFilter.mesh);

		InitLineRender(thisGameObject);
		SetIconObjectColor();
		SetParent2BodyAndControlPointList(thisGameObject);
	}
	public void AdjMesh(ColumnIcon columnIcon, float doubleRoofHeight, float doubleRoofWidth)
	{
		this.doubleRoofHeight = doubleRoofHeight;
		this.doubleRoofWidth = doubleRoofWidth;

		rightDownPoint = new Vector3(columnIcon.rightColumn.upPoint.transform.position.x, columnIcon.rightColumn.upPoint.transform.position.y, columnIcon.rightColumn.upPoint.transform.position.z);
		leftDownPoint = new Vector3(columnIcon.leftColumn.upPoint.transform.position.x, columnIcon.leftColumn.upPoint.transform.position.y, columnIcon.leftColumn.upPoint.transform.position.z);

		float _upr = rightDownPoint.y + doubleRoofHeight;
		rightUpPoint = new Vector3(rightUpPoint.x, _upr, rightUpPoint.z);
		float _upl = leftDownPoint.y + doubleRoofHeight;
		leftUpPoint = new Vector3(leftUpPoint.x, _upl, leftUpPoint.z);
		rightDownPoint.x = rightDownPoint.x + doubleRoofWidth;
		leftDownPoint.x = leftDownPoint.x - doubleRoofWidth;

		mFilter.mesh.Clear();
		mFilter.mesh = CreatRecMesh(leftUpPoint, rightUpPoint, rightDownPoint, leftDownPoint, mFilter.mesh);

		UpdateLineRender();
	}
	public void SetIconObjectColor()
	{
		mRenderer.material.color = Color.red;
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
}
public class FriezeIcon : RecMeshCreate
{
	public enum PointIndex { LeftUpPoint = 0, RightUpPoint = 1, RightDownPoint = 2, LeftDownPoint = 3, };
	public GameObject rightUpPoint;
	public GameObject rightDownPoint;
	public GameObject leftUpPoint;
	public GameObject leftDownPoint;
	public float friezeHeight;
	public void FriezeIconCreate<T>(T thisGameObject, string objName, ColumnIcon columnIcon, float ini_friezeHeight) where T : Component
	{
		InitBodySetting(objName, (int)BodyType.GeneralBody);

		Vector3 h = new Vector3(0.0f, ini_friezeHeight, 0.0f);
		friezeHeight = ini_friezeHeight;
		rightUpPoint = columnIcon.rightColumn.upPoint;
		leftUpPoint = columnIcon.leftColumn.upPoint;
		Vector3 rightDownPointPos = rightUpPoint.transform.position - h;
		Vector3 leftDownPointPos = leftUpPoint.transform.position - h;

		//frieze cp
		rightDownPoint = columnIcon.rightColumn.friezePoint = CreateControlPoint("FRD", columnIcon.rightColumn.downPoint.transform.localScale, rightDownPointPos);
		leftDownPoint = columnIcon.leftColumn.friezePoint = CreateControlPoint("FLD", columnIcon.rightColumn.downPoint.transform.localScale, leftDownPointPos); ;


		mFilter.mesh = CreatRecMesh(leftUpPoint.transform.position, rightUpPoint.transform.position, rightDownPoint.transform.position, leftDownPoint.transform.position, mFilter.mesh);
		//初始位置
		controlPointList.Add(leftUpPoint);
		controlPointList.Add(rightUpPoint);
		controlPointList.Add(rightDownPoint);
		controlPointList.Add(leftDownPoint);
		InitControlPointList2lastControlPointPosition();


		//columnIcon.leftColumn.controlPointList.Add(columnIcon.leftColumn.friezePoint);
		//columnIcon.rightColumn.controlPointList.Add(columnIcon.rightColumn.friezePoint);


		InitLineRender(thisGameObject);
		SetIconObjectColor();
		SetParent2BodyAndControlPointList(thisGameObject);
	}
	public void AdjMesh()
	{
		Vector3 h = new Vector3(0.0f, friezeHeight, 0.0f);
		mFilter.mesh.Clear();

		rightDownPoint.transform.position = rightUpPoint.transform.position - h;
		leftDownPoint.transform.position = leftUpPoint.transform.position - h;
		mFilter.mesh = CreatRecMesh(leftUpPoint.transform.position, rightUpPoint.transform.position, rightDownPoint.transform.position, leftDownPoint.transform.position, mFilter.mesh);

		UpdateLineRender();

	}

	
	//public void SetParent2BodyAndControlPointList<T>(T thisGameObject)
	//	where T : Component
	//{
	//	if (body != null) body.transform.parent = thisGameObject.transform;
	//	rightDownPoint.transform.parent = body.transform;
	//	leftDownPoint.transform.parent = body.transform;
	//}
	public void SetIconObjectColor()
	{
		if (silhouetteShader != null)
		{
			rightDownPoint.GetComponent<MeshRenderer>().material = silhouetteShader;
			leftDownPoint.GetComponent<MeshRenderer>().material = silhouetteShader;
		}
		mRenderer.material.color = Color.red;
		rightDownPoint.GetComponent<MeshRenderer>().material.color = Color.yellow;
		leftDownPoint.GetComponent<MeshRenderer>().material.color = Color.yellow;
	}
	public void AdjPos(Vector3 tmp)
	{
		leftDownPoint.transform.position = new Vector3(leftDownPoint.transform.position.x, tmp.y, leftDownPoint.transform.position.z);
		rightDownPoint.transform.position = new Vector3(rightDownPoint.transform.position.x, tmp.y, rightDownPoint.transform.position.z);

		friezeHeight = rightUpPoint.transform.position.y - rightDownPoint.transform.position.y;
		UpdateLastPos();
	}
}
public class WallIcon : RecMeshCreate
{
	public enum PointIndex { LeftUpPoint = 0, RightUpPoint = 1, RightDownPoint = 2, LeftDownPoint = 3, LeftUpWindowPoint = 4, RightUpWindowPoint = 5, RightDownWindowPoint = 6, LeftDownWindowPoint = 7, };
	public GameObject rightUpPoint;
	public GameObject rightDownPoint;
	public GameObject leftUpPoint;
	public GameObject leftDownPoint;

	public GameObject rightUpWindowPoint;
	public GameObject rightDownWindowPoint;
	public GameObject leftUpWindowPoint;
	public GameObject leftDownWindowPoint;

	public float wallWidth;
	public float windowHeight;

	public void WallIconCreate<T>(T thisGameObject, string objName, ColumnIcon columnIcon, float ini_wallWidth, float ini_windowsHeight) where T : Component
	{
		InitBodySetting(objName, (int)BodyType.GeneralBody);

		Vector3 wallOffset = new Vector3(Mathf.Abs(columnIcon.rightColumn.upPoint.transform.transform.position.x - columnIcon.leftColumn.upPoint.transform.transform.position.x) / 2.0f - ini_wallWidth, 0, 0);
		float columnHeight = columnIcon.rightColumn.upPoint.transform.transform.position.y - columnIcon.rightColumn.downPoint.transform.transform.position.y;
		Vector3 windowsOffset = new Vector3(0, columnHeight / 2.0f - ini_windowsHeight / 2.0f, 0);

		wallWidth = ini_wallWidth;
		windowHeight = ini_windowsHeight;
		//WallIcon cp
		rightUpPoint = CreateControlPoint("WRU", columnIcon.rightColumn.upPoint.transform.localScale, columnIcon.rightColumn.upPoint.transform.transform.position - wallOffset);
		rightDownPoint = CreateControlPoint("WRD", columnIcon.rightColumn.downPoint.transform.localScale, columnIcon.rightColumn.downPoint.transform.transform.position - wallOffset);
		leftUpPoint = CreateControlPoint("WLU", columnIcon.leftColumn.upPoint.transform.localScale, columnIcon.leftColumn.upPoint.transform.transform.position + wallOffset);
		leftDownPoint = CreateControlPoint("WLD", columnIcon.leftColumn.downPoint.transform.localScale, columnIcon.leftColumn.downPoint.transform.transform.position + wallOffset);
		rightUpWindowPoint = CreateControlPoint("WWRU", columnIcon.rightColumn.upPoint.transform.localScale, columnIcon.rightColumn.upPoint.transform.transform.position - windowsOffset - wallOffset);
		rightDownWindowPoint = CreateControlPoint("WWRD", columnIcon.rightColumn.downPoint.transform.localScale, columnIcon.rightColumn.downPoint.transform.transform.position + windowsOffset - wallOffset);
		leftUpWindowPoint = CreateControlPoint("WWLU", columnIcon.leftColumn.upPoint.transform.localScale, columnIcon.leftColumn.upPoint.transform.transform.position - windowsOffset + wallOffset);
		leftDownWindowPoint = CreateControlPoint("WWLD", columnIcon.leftColumn.downPoint.transform.localScale, columnIcon.leftColumn.downPoint.transform.transform.position + windowsOffset + wallOffset);


		mFilter.mesh = CreatRecMesh(leftUpPoint.transform.position, rightUpPoint.transform.position, rightDownPoint.transform.position, leftDownPoint.transform.position, mFilter.mesh);

		controlPointList.Add(leftUpPoint);
		controlPointList.Add(rightUpPoint);
		controlPointList.Add(rightDownPoint);
		controlPointList.Add(leftDownPoint);
		controlPointList.Add(leftUpWindowPoint);
		controlPointList.Add(rightUpWindowPoint);
		controlPointList.Add(rightDownWindowPoint);
		controlPointList.Add(leftDownWindowPoint);
		InitControlPointList2lastControlPointPosition();


		InitLineRender(thisGameObject);
		SetIconObjectColor();
		SetParent2BodyAndControlPointList(thisGameObject);
	}
	public void AdjMesh()
	{
		mFilter.mesh.Clear();
		mFilter.mesh = CreatRecMesh(leftUpPoint.transform.position, rightUpPoint.transform.position, rightDownPoint.transform.position, leftDownPoint.transform.position, mFilter.mesh);

		UpdateLineRender();
	}
	public override void InitLineRender<T>(T thisGameObject)
	{
		controlPointList_Vec3_2_LineRender.Add(leftUpPoint.transform.position);
		controlPointList_Vec3_2_LineRender.Add(rightUpPoint.transform.position);
		controlPointList_Vec3_2_LineRender.Add(rightDownPoint.transform.position);
		controlPointList_Vec3_2_LineRender.Add(leftDownPoint.transform.position);
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
		controlPointList_Vec3_2_LineRender[(int)PointIndex.LeftUpPoint] = (leftUpPoint.transform.position);
		controlPointList_Vec3_2_LineRender[(int)PointIndex.RightUpPoint] = (rightUpPoint.transform.position);
		controlPointList_Vec3_2_LineRender[(int)PointIndex.RightDownPoint] = (rightDownPoint.transform.position);
		controlPointList_Vec3_2_LineRender[(int)PointIndex.LeftDownPoint] = (leftDownPoint.transform.position);
		for (int i = 0; i < lineRenderList.Count; i++)
		{
			if (i != controlPointList_Vec3_2_LineRender.Count - 1)
				AdjLineRenderer(i, controlPointList_Vec3_2_LineRender[i], controlPointList_Vec3_2_LineRender[i + 1]);
			else
				AdjLineRenderer(i, controlPointList_Vec3_2_LineRender[i], controlPointList_Vec3_2_LineRender[0]);
		}
	}
	public void SetIconObjectColor()
	{
		mRenderer.material.color = Color.red;
		leftUpPoint.GetComponent<MeshRenderer>().material.color = Color.white;
		rightUpPoint.GetComponent<MeshRenderer>().material.color = Color.white;
		rightDownPoint.GetComponent<MeshRenderer>().material.color = Color.white;
		leftDownPoint.GetComponent<MeshRenderer>().material.color = Color.white;

		leftUpWindowPoint.GetComponent<MeshRenderer>().material.color = Color.blue;
		rightUpWindowPoint.GetComponent<MeshRenderer>().material.color = Color.blue;
		rightDownWindowPoint.GetComponent<MeshRenderer>().material.color = Color.blue;
		leftDownWindowPoint.GetComponent<MeshRenderer>().material.color = Color.blue;
	}
	public void AdjPos(Vector3 tmp, GameObject chooseGameObject)
	{
		float OffsetX = 0;
		float OffsetY = 0;
		if (chooseGameObject == leftUpPoint)
		{
			OffsetX = (tmp.x - lastControlPointPosition[(int)PointIndex.LeftUpPoint].x);
			rightUpPoint.transform.position = new Vector3(rightUpPoint.transform.position.x + (OffsetX), rightUpPoint.transform.position.y, rightUpPoint.transform.position.z);
			rightDownPoint.transform.position = new Vector3(rightDownPoint.transform.position.x + (OffsetX), rightDownPoint.transform.position.y, rightDownPoint.transform.position.z);
			leftDownPoint.transform.position = new Vector3(tmp.x, leftDownPoint.transform.position.y, leftDownPoint.transform.position.z);

			rightUpWindowPoint.transform.position = new Vector3(rightUpWindowPoint.transform.position.x + (OffsetX), rightUpWindowPoint.transform.position.y, rightUpWindowPoint.transform.position.z);
			rightDownWindowPoint.transform.position = new Vector3(rightDownWindowPoint.transform.position.x + (OffsetX), rightDownWindowPoint.transform.position.y, rightDownWindowPoint.transform.position.z);
			leftUpWindowPoint.transform.position = new Vector3(tmp.x, leftUpWindowPoint.transform.position.y, leftUpWindowPoint.transform.position.z);
			leftDownWindowPoint.transform.position = new Vector3(tmp.x, leftDownWindowPoint.transform.position.y, leftDownWindowPoint.transform.position.z);
			wallWidth = (rightUpPoint.transform.position.x - leftUpPoint.transform.position.x) / 2.0f;
		}
		else if (chooseGameObject == rightUpPoint)
		{
			OffsetX = (tmp.x - lastControlPointPosition[(int)PointIndex.RightUpPoint].x);

			leftUpPoint.transform.position = new Vector3(leftUpPoint.transform.position.x - (OffsetX), leftUpPoint.transform.position.y, leftUpPoint.transform.position.z);
			leftDownPoint.transform.position = new Vector3(leftDownPoint.transform.position.x - (OffsetX), leftDownPoint.transform.position.y, leftDownPoint.transform.position.z);
			rightDownPoint.transform.position = new Vector3(tmp.x, rightDownPoint.transform.position.y, rightDownPoint.transform.position.z);


			leftUpWindowPoint.transform.position = new Vector3(leftUpWindowPoint.transform.position.x - (OffsetX), leftUpWindowPoint.transform.position.y, leftUpWindowPoint.transform.position.z);
			leftDownWindowPoint.transform.position = new Vector3(leftDownWindowPoint.transform.position.x - (OffsetX), leftDownWindowPoint.transform.position.y, leftDownWindowPoint.transform.position.z);
			rightDownWindowPoint.transform.position = new Vector3(tmp.x, rightDownWindowPoint.transform.position.y, rightDownWindowPoint.transform.position.z);
			rightUpWindowPoint.transform.position = new Vector3(tmp.x, rightUpWindowPoint.transform.position.y, rightUpWindowPoint.transform.position.z);
			wallWidth = (rightUpPoint.transform.position.x - leftUpPoint.transform.position.x) / 2.0f;
		}
		else if (chooseGameObject == rightDownPoint)
		{
			OffsetX = (tmp.x - lastControlPointPosition[(int)PointIndex.RightDownPoint].x);

			leftUpPoint.transform.position = new Vector3(leftUpPoint.transform.position.x - (OffsetX), leftUpPoint.transform.position.y, leftUpPoint.transform.position.z);
			leftDownPoint.transform.position = new Vector3(leftDownPoint.transform.position.x - (OffsetX), leftDownPoint.transform.position.y, leftDownPoint.transform.position.z);
			rightUpPoint.transform.position = new Vector3(tmp.x, rightUpPoint.transform.position.y, rightUpPoint.transform.position.z);

			leftUpWindowPoint.transform.position = new Vector3(leftUpWindowPoint.transform.position.x - (OffsetX), leftUpWindowPoint.transform.position.y, leftUpWindowPoint.transform.position.z);
			leftDownWindowPoint.transform.position = new Vector3(leftDownWindowPoint.transform.position.x - (OffsetX), leftDownWindowPoint.transform.position.y, leftDownWindowPoint.transform.position.z);
			rightUpWindowPoint.transform.position = new Vector3(tmp.x, rightUpWindowPoint.transform.position.y, rightUpWindowPoint.transform.position.z);
			rightDownWindowPoint.transform.position = new Vector3(tmp.x, rightDownWindowPoint.transform.position.y, rightDownWindowPoint.transform.position.z);
			wallWidth = (rightUpPoint.transform.position.x - leftUpPoint.transform.position.x) / 2.0f;
		}
		else if (chooseGameObject == leftDownPoint)
		{
			OffsetX = (tmp.x - lastControlPointPosition[(int)PointIndex.LeftDownPoint].x);
			rightUpPoint.transform.position = new Vector3(rightUpPoint.transform.position.x + (OffsetX), rightUpPoint.transform.position.y, rightUpPoint.transform.position.z);
			rightDownPoint.transform.position = new Vector3(rightDownPoint.transform.position.x + (OffsetX), rightDownPoint.transform.position.y, rightDownPoint.transform.position.z);
			leftUpPoint.transform.position = new Vector3(tmp.x, leftUpPoint.transform.position.y, leftUpPoint.transform.position.z);

			rightUpWindowPoint.transform.position = new Vector3(rightUpWindowPoint.transform.position.x + (OffsetX), rightUpWindowPoint.transform.position.y, rightUpWindowPoint.transform.position.z);
			rightDownWindowPoint.transform.position = new Vector3(rightDownWindowPoint.transform.position.x + (OffsetX), rightDownWindowPoint.transform.position.y, rightDownWindowPoint.transform.position.z);
			leftUpWindowPoint.transform.position = new Vector3(tmp.x, leftUpWindowPoint.transform.position.y, leftUpWindowPoint.transform.position.z);
			leftDownWindowPoint.transform.position = new Vector3(tmp.x, leftDownWindowPoint.transform.position.y, leftDownWindowPoint.transform.position.z);
			wallWidth = (rightUpPoint.transform.position.x - leftUpPoint.transform.position.x) / 2.0f;
		}
		else if (chooseGameObject == leftUpWindowPoint)
		{
			OffsetY = (tmp.y - lastControlPointPosition[(int)PointIndex.LeftUpWindowPoint].y);
			rightUpWindowPoint.transform.position = new Vector3(rightUpWindowPoint.transform.position.x, rightUpWindowPoint.transform.position.y + (OffsetY), rightUpWindowPoint.transform.position.z);
			windowHeight = (rightUpPoint.transform.position.x - leftUpPoint.transform.position.x) / 2.0f;

		}
		else if (chooseGameObject == rightUpWindowPoint)
		{
			OffsetY = (tmp.y - lastControlPointPosition[(int)PointIndex.RightUpWindowPoint].y);
			leftUpWindowPoint.transform.position = new Vector3(leftUpWindowPoint.transform.position.x, leftUpWindowPoint.transform.position.y + (OffsetY), rightUpPoint.transform.position.z);
			windowHeight = (rightUpPoint.transform.position.x - leftUpPoint.transform.position.x) / 2.0f;
		}
		else if (chooseGameObject == rightDownWindowPoint)
		{
			OffsetY = (tmp.y - lastControlPointPosition[(int)PointIndex.RightDownWindowPoint].y);
			leftDownWindowPoint.transform.position = new Vector3(leftDownWindowPoint.transform.position.x, leftDownWindowPoint.transform.position.y + (OffsetY), leftDownWindowPoint.transform.position.z);
			windowHeight = (rightUpPoint.transform.position.x - leftUpPoint.transform.position.x) / 2.0f;
		}
		else if (chooseGameObject == leftDownWindowPoint)
		{
			OffsetY = (tmp.y - lastControlPointPosition[(int)PointIndex.LeftDownWindowPoint].y);
			rightDownWindowPoint.transform.position = new Vector3(rightDownWindowPoint.transform.position.x, rightDownWindowPoint.transform.position.y + (OffsetY), rightDownWindowPoint.transform.position.z);
			windowHeight = (rightUpPoint.transform.position.x - leftUpPoint.transform.position.x) / 2.0f;
		}
		UpdateLastPos();
	}
}
public class BalustradeIcon : RecMeshCreate
{
	public enum PointIndex { LeftUpPoint = 0, RightUpPoint = 1, RightDownPoint = 2, LeftDownPoint = 3, };
	public GameObject rightUpPoint;
	public GameObject rightDownPoint;
	public GameObject leftUpPoint;
	public GameObject leftDownPoint;
	public float balustradeHeight;
	public void BalustradeIconCreate<T>(T thisGameObject, string objName, ColumnIcon columnIcon, float ini_balustradeHeight) where T : Component
	{
		InitBodySetting(objName, (int)BodyType.GeneralBody);

		Vector3 h = new Vector3(0.0f, ini_balustradeHeight, 0.0f);
		balustradeHeight = ini_balustradeHeight;
		rightDownPoint = columnIcon.rightColumn.downPoint;
		leftDownPoint = columnIcon.leftColumn.downPoint;
		Vector3 rightUpPointPos = rightDownPoint.transform.position + h;
		Vector3 leftUpPointPos = leftDownPoint.transform.position + h;

		//right
		rightUpPoint = columnIcon.rightColumn.balustradePoint = CreateControlPoint("BRU", columnIcon.rightColumn.downPoint.transform.localScale, rightUpPointPos);
		//left
		leftUpPoint = columnIcon.leftColumn.balustradePoint = CreateControlPoint("BLU", columnIcon.rightColumn.downPoint.transform.localScale, leftUpPointPos);

		mFilter.mesh = CreatRecMesh(leftUpPoint.transform.position, rightUpPoint.transform.position, rightDownPoint.transform.position, leftDownPoint.transform.position, mFilter.mesh);
		//初始位置
		controlPointList.Add(leftUpPoint);
		controlPointList.Add(rightUpPoint);
		controlPointList.Add(rightDownPoint);
		controlPointList.Add(leftDownPoint);
		InitControlPointList2lastControlPointPosition();

	//	columnIcon.leftColumn.controlPointList.Add(columnIcon.leftColumn.balustradePoint);
		//columnIcon.rightColumn.controlPointList.Add(columnIcon.rightColumn.balustradePoint);

		InitLineRender(thisGameObject);
		SetIconObjectColor(columnIcon);
		SetParent2BodyAndControlPointList(thisGameObject);
	}
	public void AdjMesh()
	{
		Vector3 h = new Vector3(0.0f, balustradeHeight, 0.0f);
		mFilter.mesh.Clear();
		rightUpPoint.transform.position = rightDownPoint.transform.position + h;
		leftUpPoint.transform.position = leftDownPoint.transform.position + h;
		mFilter.mesh = CreatRecMesh(leftUpPoint.transform.position, rightUpPoint.transform.position, rightDownPoint.transform.position, leftDownPoint.transform.position, mFilter.mesh);

		UpdateLineRender();
	}

	//public void SetParent2BodyAndControlPointList<T>(T thisGameObject)
	//where T : Component
	//{
	//	if (body != null) body.transform.parent = thisGameObject.transform;
	//	rightUpPoint.transform.parent = body.transform;
	//	leftUpPoint.transform.parent = body.transform;
	//}
	public void SetIconObjectColor(ColumnIcon columnIcon)
	{
		if (silhouetteShader != null) 
		{
			columnIcon.rightColumn.balustradePoint.GetComponent<MeshRenderer>().material = silhouetteShader;
			columnIcon.leftColumn.balustradePoint.GetComponent<MeshRenderer>().material = silhouetteShader;
		}
		mRenderer.material.color = Color.red;
		columnIcon.rightColumn.balustradePoint.GetComponent<MeshRenderer>().material.color = Color.yellow;
		columnIcon.leftColumn.balustradePoint.GetComponent<MeshRenderer>().material.color = Color.yellow;
	}
	public void AdjPos(Vector3 tmp)
	{
		leftUpPoint.transform.position = new Vector3(leftUpPoint.transform.position.x, tmp.y, leftUpPoint.transform.position.z);
		rightUpPoint.transform.position = new Vector3(rightUpPoint.transform.position.x, tmp.y, rightUpPoint.transform.position.z);

		balustradeHeight = rightUpPoint.transform.position.y - rightDownPoint.transform.position.y;

		UpdateLastPos();
		UpdateLineRender();
	}
}
public class ColumnIcon : IconObject
{
	public enum PointIndex { LeftUpPoint = 0, RightUpPoint = 1, RightDownPoint = 2, LeftDownPoint = 3, };
	public List<GameObject> body=new List<GameObject>();
	public Column leftColumn;
	public Column rightColumn;

	public DoubleRoofIcon doubleRoofIcon =new DoubleRoofIcon();

	public FriezeIcon friezeIcon = new FriezeIcon();
	public BalustradeIcon balustradeIcon=new BalustradeIcon();

	public WallIcon wallIcon = new WallIcon();

	public float columnHeight;

	public void ColumnIconCreate<T>(T thisGameObject, GameObject rightUpPoint, GameObject rightDownPoint, GameObject leftUpPoint, GameObject leftDownPoint, float columnHeight) where T : Component
	{
		leftColumn = new Column(leftUpPoint, leftDownPoint, columnHeight);
		rightColumn = new Column(rightUpPoint, rightDownPoint, columnHeight);
		this.columnHeight = columnHeight;

		body.Add(leftColumn.body);
		body.Add(rightColumn.body);

		controlPointList.Add(leftColumn.upPoint);
		controlPointList.Add(rightColumn.upPoint);
		controlPointList.Add(rightColumn.downPoint);
		controlPointList.Add(leftColumn.downPoint);
		InitControlPointList2lastControlPointPosition();

		leftColumn.body.transform.parent = thisGameObject.transform;
		rightColumn.body.transform.parent = thisGameObject.transform;

	}
	public void CreateWall<T>(T thisGameObject, string objName, float ini_wallWidth, float ini_windowHeight) where T : Component
	{
		wallIcon=new WallIcon();
		wallIcon.WallIconCreate(thisGameObject, objName, this, ini_wallWidth, ini_windowHeight);
	}
	public void CreateDoubleRoof<T>(T thisGameObject, string objName, float ini_doubleRoofHeight, float ini_doubleRoofWidth) where T : Component
	{
		doubleRoofIcon=new DoubleRoofIcon();
		doubleRoofIcon.DoubleRoofIconCreate(thisGameObject, objName, this, ini_doubleRoofHeight, ini_doubleRoofWidth);
	}
	public void CreateBlustrade<T>(T thisGameObject, string objName, float ini_balustradeHeight) where T : Component
	{
		balustradeIcon=new BalustradeIcon();
		balustradeIcon.BalustradeIconCreate(thisGameObject, objName, this, ini_balustradeHeight);
	}
	public void CreateFrieze<T>(T thisGameObject, string objName, float ini_friezeHeight) where T : Component
	{
		friezeIcon = new FriezeIcon();
		friezeIcon.FriezeIconCreate(thisGameObject, objName, this, ini_friezeHeight);
	}
	public void AdjPos(Vector3 tmp, GameObject chooseObject)
	{
		float OffsetX = 0;
		if (chooseObject == leftColumn.upPoint || chooseObject == rightColumn.upPoint)
		{
			columnHeight = (tmp.y - rightColumn.downPoint.transform.position.y);
			columnHeight = Mathf.Abs(columnHeight);
			//update point
			rightColumn.upPoint.transform.position = new Vector3(rightColumn.upPoint.transform.position.x, tmp.y, rightColumn.upPoint.transform.position.z);
			leftColumn.upPoint.transform.position = new Vector3(leftColumn.upPoint.transform.position.x, tmp.y, leftColumn.upPoint.transform.position.z);

			rightColumn.body.transform.position = new Vector3(rightColumn.upPoint.transform.position.x, rightColumn.upPoint.transform.position.y - columnHeight / 2.0f, rightColumn.upPoint.transform.position.z);

			leftColumn.body.transform.position = new Vector3(leftColumn.upPoint.transform.position.x, leftColumn.upPoint.transform.position.y - columnHeight / 2.0f, leftColumn.upPoint.transform.position.z);

			rightColumn.body.transform.localScale = new Vector3(rightColumn.radius, columnHeight / 2.0f, rightColumn.radius);
			leftColumn.body.transform.localScale = new Vector3(leftColumn.radius, columnHeight / 2.0f, leftColumn.radius);


			if (friezeIcon.body != null)
			{
				rightColumn.friezePoint.transform.position = new Vector3(rightColumn.upPoint.transform.position.x, tmp.y - friezeIcon.friezeHeight, rightColumn.upPoint.transform.position.z);
				leftColumn.friezePoint.transform.position = new Vector3(leftColumn.upPoint.transform.position.x, tmp.y - friezeIcon.friezeHeight, leftColumn.upPoint.transform.position.z);

				friezeIcon.AdjMesh();
			}
			if (doubleRoofIcon.body != null)
			{
				doubleRoofIcon.AdjMesh(this, doubleRoofIcon.doubleRoofHeight, doubleRoofIcon.doubleRoofWidth);
			}
			if (wallIcon.body != null)
			{
				wallIcon.rightUpPoint.transform.position = new Vector3(wallIcon.rightUpPoint.transform.position.x, tmp.y, wallIcon.rightUpPoint.transform.position.z);
				wallIcon.leftUpPoint.transform.position = new Vector3(wallIcon.leftUpPoint.transform.position.x, tmp.y, wallIcon.leftUpPoint.transform.position.z);


				wallIcon.AdjMesh();
			}
		}
		else if (chooseObject == leftColumn.downPoint || chooseObject == rightColumn.downPoint)
		{
			columnHeight = (tmp.y - rightColumn.upPoint.transform.position.y);
			columnHeight = Mathf.Abs(columnHeight);
			//update point
			rightColumn.downPoint.transform.position = new Vector3(rightColumn.downPoint.transform.position.x, tmp.y, rightColumn.downPoint.transform.position.z);
			leftColumn.downPoint.transform.position = new Vector3(leftColumn.downPoint.transform.position.x, tmp.y, rightColumn.downPoint.transform.position.z);
			rightColumn.body.transform.position = new Vector3(rightColumn.upPoint.transform.position.x, rightColumn.upPoint.transform.position.y - columnHeight / 2.0f, rightColumn.upPoint.transform.position.z);
			leftColumn.body.transform.position = new Vector3(leftColumn.upPoint.transform.position.x, leftColumn.upPoint.transform.position.y - columnHeight / 2.0f, leftColumn.upPoint.transform.position.z);


			rightColumn.body.transform.localScale = new Vector3(rightColumn.radius, columnHeight / 2.0f, rightColumn.radius);
			leftColumn.body.transform.localScale = new Vector3(leftColumn.radius, columnHeight / 2.0f, leftColumn.radius);


			if (balustradeIcon.body != null)
			{
				rightColumn.balustradePoint.transform.position = new Vector3(rightColumn.downPoint.transform.position.x, tmp.y + balustradeIcon.balustradeHeight, rightColumn.upPoint.transform.position.z);
				leftColumn.balustradePoint.transform.position = new Vector3(leftColumn.downPoint.transform.position.x, tmp.y + balustradeIcon.balustradeHeight, leftColumn.upPoint.transform.position.z);

				balustradeIcon.AdjMesh();
			}
			if (wallIcon.body != null)
			{
				wallIcon.rightDownPoint.transform.position = new Vector3(wallIcon.rightDownPoint.transform.position.x, tmp.y, wallIcon.rightDownPoint.transform.position.z);
				wallIcon.leftDownPoint.transform.position = new Vector3(wallIcon.leftDownPoint.transform.position.x, tmp.y, wallIcon.leftDownPoint.transform.position.z);

				wallIcon.AdjMesh();
			}
		}
		else if (chooseObject == leftColumn.body)
		{
			OffsetX = (tmp.x - lastControlPointPosition[(int)PointIndex.LeftUpPoint].x);
			for (int i = 0; i < rightColumn.controlPointList.Count; i++)
			{
				leftColumn.controlPointList[i].transform.position = new Vector3(tmp.x, leftColumn.controlPointList[i].transform.position.y, leftColumn.controlPointList[i].transform.position.z);
				rightColumn.controlPointList[i].transform.position = new Vector3(rightColumn.controlPointList[i].transform.position.x - (OffsetX), rightColumn.controlPointList[i].transform.position.y, rightColumn.controlPointList[i].transform.position.z);
			}

			leftColumn.body.transform.position = new Vector3(tmp.x, leftColumn.body.transform.position.y, leftColumn.body.transform.position.z);
			rightColumn.body.transform.position = new Vector3(rightColumn.body.transform.position.x - (OffsetX), rightColumn.body.transform.position.y, rightColumn.body.transform.position.z);
			if (friezeIcon.body != null)
			{
				friezeIcon.AdjMesh();
				friezeIcon.UpdateLastPos();
			}
			if (balustradeIcon.body != null)
			{
				balustradeIcon.AdjMesh();
				balustradeIcon.UpdateLastPos();
			}
			if (doubleRoofIcon.body != null)
			{
				doubleRoofIcon.AdjMesh(this, doubleRoofIcon.doubleRoofHeight, doubleRoofIcon.doubleRoofWidth);
			}
		}
		else if (chooseObject == rightColumn.body)
		{
			OffsetX = (tmp.x - lastControlPointPosition[(int)PointIndex.RightUpPoint].x);
			for (int i = 0; i < leftColumn.controlPointList.Count; i++)
			{
				rightColumn.controlPointList[i].transform.position = new Vector3(tmp.x, rightColumn.controlPointList[i].transform.position.y, rightColumn.controlPointList[i].transform.position.z);
				leftColumn.controlPointList[i].transform.position = new Vector3(leftColumn.controlPointList[i].transform.position.x - (OffsetX), leftColumn.controlPointList[i].transform.position.y, leftColumn.controlPointList[i].transform.position.z);

			}
			if (friezeIcon.body != null)
			{
				friezeIcon.AdjMesh();
				friezeIcon.UpdateLastPos();
			}
			if (balustradeIcon.body != null)
			{
				balustradeIcon.AdjMesh();
				balustradeIcon.UpdateLastPos();
			}
			if (doubleRoofIcon.body != null)
			{
				doubleRoofIcon.AdjMesh(this, doubleRoofIcon.doubleRoofHeight, doubleRoofIcon.doubleRoofWidth);
			}
		}
		UpdateLastPos();
	}
}
public class Column : IconObject
{
	public enum PointIndex { UpPoint = 0, DownPoint = 1, Body = 2 };
	public GameObject upPoint = null;
	public GameObject downPoint = null;
	public GameObject balustradePoint = null;
	public GameObject friezePoint = null;
	public float radius = 0.01f;
	public Column(GameObject upPoint, GameObject downPoint, float columnHeight)
	{

		InitBodySetting("Cylinder", (int)BodyType.CylinderBody);

		body.transform.localScale = new Vector3(radius, columnHeight / 2.0f, radius);
		body.transform.position = new Vector3(upPoint.transform.position.x, upPoint.transform.position.y - columnHeight / 2.0f, upPoint.transform.position.z);

		//柱子是可以移動的部分
		this.body.tag = "ControlPoint";

		this.upPoint = upPoint;
		this.downPoint = downPoint;

		controlPointList.Add(upPoint);
		controlPointList.Add(downPoint);
		controlPointList.Add(body);
		InitControlPointList2lastControlPointPosition();

		SetIconObjectColor();
	}
	public void SetIconObjectColor()
	{
		if (silhouetteShader != null)
		{
			mRenderer.material = silhouetteShader;
			upPoint.GetComponent<MeshRenderer>().material = silhouetteShader;
			downPoint.GetComponent<MeshRenderer>().material = silhouetteShader;
		}
		mRenderer.material.color = Color.red;
		upPoint.GetComponent<MeshRenderer>().material.color = Color.yellow;
		downPoint.GetComponent<MeshRenderer>().material.color = Color.yellow;
	}
}

public class body2icon : MonoBehaviour
{
	public List<GameObject> controlPointList = new List<GameObject>();//所有控制點

	//just try two point
	public ColumnIcon columnIcon;

	private DragItemController dragitemcontroller;
	private Movement movement;

	public Vector2 ini_bodydis;
	public Vector2 chang_bodydis;
	public Vector2 ratio_bodydis;
	public float chang_walldis;
	public float ratio_walldis;
	public float ini_friezeHeight;
	public float ini_balustradeHeight;
	public float ini_doubleRoofWidth;
	public float ini_doubleRoofHeight;
	public float ini_windowHeight;
	public float ini_wallWidth;

	public bool isBalustrade;
	public bool isFrieze;
	public bool isDoubleRoof;
	public bool isWall;

	public float cylinderHeight;
	public float friezeHeight;
	public float balustradeHeight;
	public float windowHeight;
	public float windowUp2TopDis;
	public float windowDown2ButtonDis;


	// Use this for initialization

	void Start()
	{
		dragitemcontroller = GameObject.Find("DragItemController").GetComponent<DragItemController>();
		movement = GameObject.Find("Movement").GetComponent<Movement>();
		movement.verlist.AddRange(controlPointList);

		cylinderHeight = ini_bodydis.y = Vector3.Distance(controlPointList[0].transform.position, controlPointList[1].transform.position);

		columnIcon = new ColumnIcon();
		columnIcon.ColumnIconCreate(this, controlPointList[2], controlPointList[3], controlPointList[0], controlPointList[1], ini_bodydis.y);


		movement.horlist.Add(columnIcon.leftColumn.body);
		movement.horlist.Add(columnIcon.rightColumn.body);


		friezeHeight = ini_friezeHeight = 0.2f * ini_bodydis.y;
		balustradeHeight = ini_balustradeHeight = 0.2f * ini_bodydis.y;
		windowHeight = ini_windowHeight = 0.5f * ini_bodydis.y;
		ini_doubleRoofHeight = 0.4f * ini_bodydis.y;
		ini_doubleRoofWidth = 0.3f * ini_bodydis.y;
		ini_bodydis.x = columnIcon.rightColumn.upPoint.transform.position.x - columnIcon.leftColumn.upPoint.transform.position.x;
		ini_bodydis.x = ini_bodydis.x / 2.0f;
		ini_wallWidth = ini_bodydis.x * 0.6f;
	}

	public void adjPos()
	{
		ratio_bodydis = chang_bodydis = Vector2.zero;
		ratio_walldis = chang_walldis = 0;
		Vector3 tmp = dragitemcontroller.chooseObj.transform.position;
		GameObject chooseObj = dragitemcontroller.chooseObj;
		float dis = 0;
		if (chooseObj == columnIcon.rightColumn.upPoint || chooseObj == columnIcon.leftColumn.upPoint)//RU LU
		{

			if (chooseObj == columnIcon.leftColumn.upPoint)
			{
				dis = (tmp.y - columnIcon.rightColumn.upPoint.transform.position.y);
				columnIcon.AdjPos(tmp, chooseObj);
				cylinderHeight = columnIcon.columnHeight;
			}
			else if (chooseObj == columnIcon.rightColumn.upPoint)
			{
				dis = (tmp.y - columnIcon.leftColumn.upPoint.transform.position.y);
				columnIcon.AdjPos(tmp, chooseObj);

				cylinderHeight = columnIcon.columnHeight;
			}

			chang_bodydis.y = dis;
			ratio_bodydis.y = chang_bodydis.y / ini_bodydis.y;
		}
		else if (chooseObj == columnIcon.rightColumn.downPoint || chooseObj == columnIcon.leftColumn.downPoint)//RD  LD
		{
			if (chooseObj == columnIcon.leftColumn.downPoint)
			{
				dis = (tmp.y - columnIcon.rightColumn.downPoint.transform.position.y);

				columnIcon.AdjPos(tmp, chooseObj);
				cylinderHeight = columnIcon.columnHeight;

			}
			else if (chooseObj == columnIcon.rightColumn.downPoint)
			{
				dis = (tmp.y - columnIcon.leftColumn.downPoint.transform.position.y);

				columnIcon.AdjPos(tmp, chooseObj);
				cylinderHeight = columnIcon.columnHeight;

			}
			chang_bodydis.y = -dis;
			ratio_bodydis.y = chang_bodydis.y / ini_bodydis.y;
		}
		else if (chooseObj == columnIcon.rightColumn.body)
		{
			dis = (tmp.x - columnIcon.rightColumn.upPoint.transform.position.x);

			columnIcon.AdjPos(tmp, chooseObj);

			chang_bodydis.x = dis;
			ratio_bodydis.x = chang_bodydis.x / ini_bodydis.x;
		}
		else if (chooseObj == columnIcon.leftColumn.body)
		{
			dis = (tmp.x - columnIcon.leftColumn.upPoint.transform.position.x);

			columnIcon.AdjPos(tmp, chooseObj);
			chang_bodydis.x = -dis;
			ratio_bodydis.x = chang_bodydis.x / ini_bodydis.x;
		}
		else if (chooseObj == columnIcon.rightColumn.friezePoint || chooseObj == columnIcon.leftColumn.friezePoint)
		{//frieze

			columnIcon.friezeIcon.AdjPos(tmp);


			friezeHeight = columnIcon.friezeIcon.friezeHeight;

			columnIcon.friezeIcon.AdjMesh(); ;


		}
		else if (chooseObj == columnIcon.rightColumn.balustradePoint || chooseObj == columnIcon.leftColumn.balustradePoint)
		{ //balustrade

			columnIcon.balustradeIcon.AdjPos(tmp);

			balustradeHeight = columnIcon.balustradeIcon.balustradeHeight;
			columnIcon.balustradeIcon.AdjMesh();

		}
		else if (chooseObj == columnIcon.wallIcon.rightUpPoint)
		{
			dis = (tmp.x - columnIcon.wallIcon.rightDownPoint.transform.position.x);
			columnIcon.wallIcon.AdjPos(tmp, chooseObj);
			columnIcon.wallIcon.AdjMesh();

			chang_walldis = dis;
			ratio_walldis = chang_walldis / ini_wallWidth;
		}
		else if (chooseObj == columnIcon.wallIcon.leftUpPoint)
		{
			dis = (tmp.x - columnIcon.wallIcon.leftDownPoint.transform.position.x);

			columnIcon.wallIcon.AdjPos(tmp, chooseObj);

			columnIcon.wallIcon.AdjMesh();

			chang_walldis = -dis;
			ratio_walldis = chang_walldis / ini_wallWidth;
		}
		else if (chooseObj == columnIcon.wallIcon.rightDownPoint)
		{
			dis = (tmp.x - columnIcon.wallIcon.rightUpPoint.transform.position.x);

			columnIcon.wallIcon.AdjPos(tmp, chooseObj);

			columnIcon.wallIcon.AdjMesh();

			chang_walldis = dis;
			ratio_walldis = chang_walldis / ini_wallWidth;
		}
		else if (chooseObj == columnIcon.wallIcon.leftDownPoint)
		{
			dis = (tmp.x - columnIcon.wallIcon.leftUpPoint.transform.position.x);

			columnIcon.wallIcon.AdjPos(tmp, chooseObj);

			columnIcon.wallIcon.AdjMesh();

			chang_walldis = -dis;
			ratio_walldis = chang_walldis / ini_wallWidth;
		}
		else if (chooseObj == columnIcon.wallIcon.rightUpWindowPoint)
		{
			dis = (tmp.y - columnIcon.wallIcon.leftUpWindowPoint.transform.position.y);

			columnIcon.wallIcon.AdjPos(tmp, chooseObj);

			windowHeight = columnIcon.wallIcon.windowHeight;

			windowUp2TopDis = columnIcon.wallIcon.rightUpPoint.transform.position.y - columnIcon.wallIcon.rightUpWindowPoint.transform.position.y;
		}
		else if (chooseObj == columnIcon.wallIcon.leftUpWindowPoint)
		{
			dis = (tmp.y - columnIcon.wallIcon.rightUpWindowPoint.transform.position.y);

			columnIcon.wallIcon.AdjPos(tmp, chooseObj);

			windowHeight = columnIcon.wallIcon.windowHeight;

			windowUp2TopDis = columnIcon.wallIcon.rightUpPoint.transform.position.y - columnIcon.wallIcon.rightUpWindowPoint.transform.position.y;
		}
		else if (chooseObj == columnIcon.wallIcon.rightDownWindowPoint)
		{
			dis = (tmp.y - columnIcon.wallIcon.leftDownWindowPoint.transform.position.y);

			columnIcon.wallIcon.AdjPos(tmp, chooseObj);

			windowHeight = columnIcon.wallIcon.windowHeight;

			windowDown2ButtonDis = columnIcon.wallIcon.rightDownWindowPoint.transform.position.y - columnIcon.wallIcon.rightDownPoint.transform.position.y;
		}
		else if (chooseObj == columnIcon.wallIcon.leftDownWindowPoint)
		{
			dis = (tmp.y - columnIcon.wallIcon.rightDownWindowPoint.transform.position.y);

			columnIcon.wallIcon.AdjPos(tmp, chooseObj);

			windowHeight = columnIcon.wallIcon.windowHeight;

			windowDown2ButtonDis = columnIcon.wallIcon.rightDownWindowPoint.transform.position.y - columnIcon.wallIcon.rightDownPoint.transform.position.y;
		}

	}
	public void UpdateFunction(string objName, GameObject correspondingDragItemObject)
	{
		switch (objName)
		{
			case "Frieze":
				if (columnIcon.friezeIcon.body==null)
				{
					isFrieze = true;

					columnIcon.CreateFrieze(this, "Frieze_mesh", ini_friezeHeight);

					controlPointList.Add(columnIcon.rightColumn.friezePoint);
					controlPointList.Add(columnIcon.leftColumn.friezePoint);

					movement.verlist.Add(columnIcon.rightColumn.friezePoint);
					movement.verlist.Add(columnIcon.leftColumn.friezePoint);

					columnIcon.friezeIcon.SetParent2BodyAndControlPointList(correspondingDragItemObject);
					columnIcon.friezeIcon.SetParent2LineRenderList(correspondingDragItemObject);	

				}
				break;
			case "Balustrade":
				if (columnIcon.balustradeIcon.body==null)
				{
					isBalustrade = true;
					columnIcon.CreateBlustrade(this, "Blustrade_mesh", ini_balustradeHeight);

					controlPointList.Add(columnIcon.rightColumn.balustradePoint);
					controlPointList.Add(columnIcon.leftColumn.balustradePoint);

					movement.verlist.Add(columnIcon.rightColumn.balustradePoint);
					movement.verlist.Add(columnIcon.leftColumn.balustradePoint);


					columnIcon.balustradeIcon.SetParent2BodyAndControlPointList(correspondingDragItemObject);
					columnIcon.balustradeIcon.SetParent2LineRenderList(correspondingDragItemObject);	
				}
				break;
			case "DoubleRoof":
				if (columnIcon.doubleRoofIcon.body==null)
				{
					isDoubleRoof = true;

					columnIcon.CreateDoubleRoof(this, "DoubleRoof_mesh", ini_doubleRoofHeight, ini_doubleRoofWidth);

					columnIcon.doubleRoofIcon.SetParent2BodyAndControlPointList(correspondingDragItemObject);
					columnIcon.doubleRoofIcon.SetParent2LineRenderList(correspondingDragItemObject);

				}
				break;
			case "Wall":
				if (columnIcon.wallIcon.body == null)
				{
					isWall = true;

					columnIcon.CreateWall(this, "Wall_mesh", ini_wallWidth, ini_windowHeight);

					movement.horlist.Add(columnIcon.wallIcon.rightDownPoint);
					movement.horlist.Add(columnIcon.wallIcon.rightUpPoint);
					movement.horlist.Add(columnIcon.wallIcon.leftDownPoint);
					movement.horlist.Add(columnIcon.wallIcon.leftUpPoint);


					columnIcon.wallIcon.SetParent2BodyAndControlPointList(correspondingDragItemObject);
					columnIcon.wallIcon.SetParent2LineRenderList(correspondingDragItemObject);

					windowUp2TopDis = columnIcon.wallIcon.rightUpPoint.transform.position.y - columnIcon.wallIcon.rightUpWindowPoint.transform.position.y;
					windowDown2ButtonDis = columnIcon.wallIcon.rightDownWindowPoint.transform.position.y - columnIcon.wallIcon.rightDownPoint.transform.position.y;

				}
				break;
		}
	}
	public void addpoint()
	{
		controlPointList.RemoveAll(GameObject => GameObject == null); 
		movement.verlist.AddRange(controlPointList);
		movement.horlist.Add(columnIcon.rightColumn.body);
		movement.horlist.Add(columnIcon.leftColumn.body);
		if (isWall)
		{
			movement.horlist.Add(columnIcon.wallIcon.rightDownPoint);
			movement.horlist.Add(columnIcon.wallIcon.rightUpPoint);
			movement.horlist.Add(columnIcon.wallIcon.leftDownPoint);
			movement.horlist.Add(columnIcon.wallIcon.leftUpPoint);

			movement.verlist.Add(columnIcon.wallIcon.rightDownWindowPoint);
			movement.verlist.Add(columnIcon.wallIcon.rightUpWindowPoint);
			movement.verlist.Add(columnIcon.wallIcon.leftDownWindowPoint);
			movement.verlist.Add(columnIcon.wallIcon.leftUpWindowPoint);
		}
	}
	public Vector3 ClampPos(Vector3 inputPos)
	{
		float minClampX = float.MinValue;
		float maxClampX = float.MaxValue;
		float minClampY = float.MinValue;
		float maxClampY = float.MaxValue;
		float minWidth = ini_bodydis.x * 0.2f;
		float minHeight = ini_bodydis.y * 0.7f;
		float minFriezeHeight = ini_bodydis.y * 0.1f;
		float minBalustradeHeight = ini_bodydis.y * 0.1f;
		float minWallHeight = ini_bodydis.y * 0.1f;
		float minCloseHeight = ini_bodydis.y * 0.1f;
		if (dragitemcontroller.chooseObj == columnIcon.rightColumn.body)
		{
			if (isWall) minClampX = columnIcon.wallIcon.rightUpPoint.transform.position.x + minWidth;
			else minClampX = columnIcon.leftColumn.upPoint.transform.position.x + minWidth;
		}
		else if (dragitemcontroller.chooseObj == columnIcon.leftColumn.body)
		{
			if (isWall) maxClampX = columnIcon.wallIcon.leftUpPoint.transform.position.x - minWidth;
			else maxClampX = columnIcon.leftColumn.upPoint.transform.position.x - minWidth;
		}
		else if (dragitemcontroller.chooseObj == columnIcon.rightColumn.upPoint)
		{
			if (isWall) minClampY = columnIcon.wallIcon.rightUpWindowPoint.transform.position.y + minCloseHeight;
			else minClampY = columnIcon.rightColumn.downPoint.transform.position.y + minCloseHeight + friezeHeight + balustradeHeight;
		}
		else if (dragitemcontroller.chooseObj == columnIcon.rightColumn.downPoint)
		{
			if (isWall) maxClampY = columnIcon.wallIcon.rightDownWindowPoint.transform.position.y - minCloseHeight;
			else maxClampY = columnIcon.rightColumn.upPoint.transform.position.y - minCloseHeight - friezeHeight - balustradeHeight;
		}
		else if (dragitemcontroller.chooseObj == columnIcon.rightColumn.friezePoint)
		{
			minClampY = columnIcon.rightColumn.downPoint.transform.position.y + minCloseHeight + balustradeHeight;
			maxClampY = columnIcon.rightColumn.upPoint.transform.position.y - minFriezeHeight;
		}
		else if (dragitemcontroller.chooseObj == columnIcon.rightColumn.balustradePoint)
		{
			minClampY = columnIcon.rightColumn.downPoint.transform.position.y + minBalustradeHeight;
			maxClampY = columnIcon.rightColumn.upPoint.transform.position.y - minCloseHeight - friezeHeight;
		}
		else if (dragitemcontroller.chooseObj == columnIcon.leftColumn.upPoint)
		{
			if (isWall) minClampY = columnIcon.wallIcon.leftUpWindowPoint.transform.position.y + minCloseHeight;
			else minClampY = columnIcon.leftColumn.downPoint.transform.position.y + minHeight;
		}
		else if (dragitemcontroller.chooseObj == columnIcon.leftColumn.downPoint)
		{
			if (isWall) maxClampY = columnIcon.wallIcon.leftDownWindowPoint.transform.position.y - minCloseHeight;
			else maxClampY = columnIcon.leftColumn.upPoint.transform.position.y - minHeight;
		}
		else if (dragitemcontroller.chooseObj == columnIcon.leftColumn.friezePoint)
		{
			minClampY = columnIcon.leftColumn.downPoint.transform.position.y + minCloseHeight + balustradeHeight;
			maxClampY = columnIcon.leftColumn.upPoint.transform.position.y - minFriezeHeight;
		}
		else if (dragitemcontroller.chooseObj == columnIcon.leftColumn.balustradePoint)
		{
			minClampY = columnIcon.leftColumn.downPoint.transform.position.y + minBalustradeHeight;
			maxClampY = columnIcon.leftColumn.upPoint.transform.position.y - minCloseHeight - friezeHeight;
		}
		else if (dragitemcontroller.chooseObj == columnIcon.wallIcon.rightUpPoint)
		{
			maxClampX = columnIcon.rightColumn.upPoint.transform.position.x - minWidth;
			minClampX = columnIcon.wallIcon.leftUpPoint.transform.position.x + minWidth;
		}
		else if (dragitemcontroller.chooseObj == columnIcon.wallIcon.rightDownPoint)
		{
			maxClampX = columnIcon.rightColumn.downPoint.transform.position.x - minWidth;
			minClampX = columnIcon.wallIcon.leftUpPoint.transform.position.x + minWidth;
		}
		else if (dragitemcontroller.chooseObj == columnIcon.wallIcon.leftUpPoint)
		{
			minClampX = columnIcon.leftColumn.upPoint.transform.position.x + minWidth;
			maxClampX = columnIcon.wallIcon.rightUpPoint.transform.position.x - minWidth;
		}
		else if (dragitemcontroller.chooseObj == columnIcon.wallIcon.leftDownPoint)
		{
			minClampX = columnIcon.leftColumn.downPoint.transform.position.x + minWidth;
			maxClampX = columnIcon.wallIcon.rightUpPoint.transform.position.x - minWidth;
		}
		else if (dragitemcontroller.chooseObj == columnIcon.wallIcon.rightUpWindowPoint)
		{
			minClampY = columnIcon.wallIcon.rightDownWindowPoint.transform.position.y + minWallHeight;
			maxClampY = columnIcon.wallIcon.rightUpPoint.transform.position.y - minCloseHeight;
		}
		else if (dragitemcontroller.chooseObj == columnIcon.wallIcon.leftUpWindowPoint)
		{
			minClampY = columnIcon.wallIcon.leftDownWindowPoint.transform.position.y + minWallHeight;
			maxClampY = columnIcon.wallIcon.leftUpPoint.transform.position.y - minCloseHeight;
		}
		else if (dragitemcontroller.chooseObj == columnIcon.wallIcon.rightDownWindowPoint)
		{
			minClampY = columnIcon.wallIcon.rightDownPoint.transform.position.y + minCloseHeight;
			maxClampY = columnIcon.wallIcon.rightUpWindowPoint.transform.position.y - minWallHeight;
		}
		else if (dragitemcontroller.chooseObj == columnIcon.wallIcon.leftDownWindowPoint)
		{
			minClampY = columnIcon.wallIcon.leftDownPoint.transform.position.y + minCloseHeight;
			maxClampY = columnIcon.wallIcon.leftUpWindowPoint.transform.position.y - minWallHeight;
		}
		float posX = Mathf.Clamp(inputPos.x, minClampX, maxClampX);
		float posY = Mathf.Clamp(inputPos.y, minClampY, maxClampY);

		return new Vector3(posX, posY, inputPos.z);
	}
}*/

using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class RecMeshCreate : IconObject
{
	public GameObject rightUpPoint;
	public GameObject rightDownPoint;
	public GameObject leftUpPoint;
	public GameObject leftDownPoint;
	public Mesh CreatRecMesh(Vector3 lu, Vector3 ru, Vector3 rd, Vector3 ld, Mesh ismesh)
	{
		if (!ismesh)
		{
			ismesh = new Mesh();
			if (bodyStruct.mCollider.GetComponent<MeshCollider>())
				bodyStruct.mCollider.GetComponent<MeshCollider>().sharedMesh = ismesh;
		}
		ismesh.vertices = new Vector3[] {

			lu,
			ru,
			rd,
			ld
		};
		ismesh.triangles = new int[] { 0, 1, 2, 0, 2, 3 };
		ismesh.RecalculateNormals();
		bodyStruct.mFilter.mesh.RecalculateBounds();
		return ismesh;
	}
	public override void InitLineRender<T>(T thisGameObject)
	{
		for (int i = 0; i < controlPointList.Count; i++)
		{
			controlPointList_Vec3_2_LineRender.Add(controlPointList[i].transform.position);
		}

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
		for (int i = 0; i < controlPointList.Count; i++)
		{
			controlPointList_Vec3_2_LineRender[i] = (controlPointList[i].transform.position);
		}
		for (int i = 0; i < lineRenderList.Count; i++)
		{
			if (i != controlPointList_Vec3_2_LineRender.Count - 1)
				AdjLineRenderer(i, controlPointList_Vec3_2_LineRender[i], controlPointList_Vec3_2_LineRender[i + 1]);
			else
				AdjLineRenderer(i, controlPointList_Vec3_2_LineRender[i], controlPointList_Vec3_2_LineRender[0]);
		}
	}
}
public class DecorateIconObject : RecMeshCreate
{
	public GameObject correspondingDragItemObject;
	public void InitDecorateIconObjectSetting(GameObject correspondingDragItemObject, params GameObject[] values)
	{

		if (correspondingDragItemObject.GetComponent<DecorateEmptyObjectList>() == null) return;

		DecorateEmptyObjectList decorateEmptyObjectList = correspondingDragItemObject.GetComponent<DecorateEmptyObjectList>();
		decorateEmptyObjectList.objectList.Clear();
		decorateEmptyObjectList.objectList.Add(bodyStruct.body);
		for (int i = 0; i < values.Length; i++)
		{
			decorateEmptyObjectList.objectList.Add(values[i]);
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
}
public class MutiColumnIcon : DecorateIconObject
{
	public Vector3 upPoint;
	public Vector3 downPoint;
	public int mutiColumnIconCount = 5;
	public int mutiColumnIconMaxCount = 11;
	public void MutiColumnIconCreate<T>(T thisGameObject, string objName, ColumnIcon columnIcon, GameObject correspondingDragItemObject) where T : Component
	{
		InitBodySetting("MutiColumnIcon", (int)BodyType.CylinderBody);
		InitIconMenuButtonSetting();

		float columnHeight = columnIcon.columnHeight;
		float radius = columnIcon.rightColumn.radius;
		upPoint = (columnIcon.rightColumn.upPoint.transform.position + columnIcon.leftColumn.upPoint.transform.position) / 2.0f;
		downPoint = (columnIcon.rightColumn.downPoint.transform.position + columnIcon.leftColumn.downPoint.transform.position) / 2.0f;

		bodyStruct.body.transform.localScale = new Vector3(radius, columnHeight / 2.0f, radius);
		bodyStruct.body.transform.position = new Vector3(upPoint.x, upPoint.y - columnHeight / 2.0f, upPoint.z);
		SetIconObjectColor();
		SetParent2BodyAndControlPointList(thisGameObject);

		InitDecorateIconObjectSetting(correspondingDragItemObject);
	}
	public void SetIconObjectColor()
	{
		if (silhouetteShader != null)
		{
			bodyStruct.mRenderer.material = silhouetteShader;
		}
		bodyStruct.mRenderer.material.color = Color.red;
	}
	public void InitIconMenuButtonSetting()
	{
		iconMenuControl.delelteButton.isDeleteIconButton = true;
		iconMenuControl.scrollBarButton.isScrollBarIconButton = true;
		iconMenuControl.scrollBarButton.scrollBarIconValue = mutiColumnIconCount;
		iconMenuControl.scrollBarButton.scrollBarIconMaxValue = mutiColumnIconMaxCount;
		iconMenuControl.scrollBarButton.scrollBarIconType = (int)ScrollBarButton.ScrollType.OddINT;
	}
	public override void InitIconMenuButtonUpdate()
	{
		mutiColumnIconCount = iconMenuControl.scrollBarButton.scrollBarIconValue;
	}
}
public class DoubleRoofIcon : DecorateIconObject
{
	public float doubleRoofEaveWidth;
	public float doubleRoofHeight;
	public float doubleRoofTopWidth;
	public float initDoubleRoofTopWidth;

	float offset = 0.01f;

	ColumnIcon columnIcon;
	public void DoubleRoofIconCreate<T>(T thisGameObject, string objName, ColumnIcon columnIcon, float doubleRoofHeight, float doubleRoofEaveWidth, GameObject correspondingDragItemObject)
	where T : Component
	{
		InitBodySetting(objName, (int)BodyType.GeneralBody);
		InitIconMenuButtonSetting();

		this.doubleRoofHeight = doubleRoofHeight;
		this.doubleRoofEaveWidth = doubleRoofEaveWidth;
		this.columnIcon = columnIcon;

		Vector3 offsetVector = new Vector3(0.0f, offset, 0.0f);

		Vector3 rightDownPointPos = columnIcon.rightColumn.upPoint.transform.position + offsetVector;
		Vector3 leftDownPointPos = columnIcon.leftColumn.upPoint.transform.position + offsetVector;

		centerX = (leftDownPointPos.x + rightDownPointPos.x) / 2.0f;

		float tmp = rightDownPointPos.y + doubleRoofHeight;

		Vector3 rightUpPointPos = new Vector3(rightDownPointPos.x, tmp, rightDownPointPos.z) + offsetVector;
		Vector3 leftUpPointPos = new Vector3(leftDownPointPos.x, tmp, leftDownPointPos.z) + offsetVector;

		 rightDownPointPos +=  new Vector3(doubleRoofEaveWidth, 0, 0);
		 leftDownPointPos -= new Vector3(doubleRoofEaveWidth, 0, 0);
		//right
		rightUpPoint = CreateControlPoint("DRU", columnIcon.rightColumn.downPoint.transform.localScale, rightUpPointPos);
		//left
		leftUpPoint = CreateControlPoint("DLU", columnIcon.rightColumn.downPoint.transform.localScale, leftUpPointPos);

		//right
		rightDownPoint = CreateControlPoint("DRD", columnIcon.rightColumn.downPoint.transform.localScale, rightDownPointPos);
		//left
		leftDownPoint = CreateControlPoint("DLD", columnIcon.rightColumn.downPoint.transform.localScale, leftDownPointPos);


		initDoubleRoofTopWidth = doubleRoofTopWidth = (rightUpPoint.transform.position.x - leftUpPoint.transform.position.x);
		bodyStruct.mFilter.mesh = CreatRecMesh(leftUpPoint.transform.position, rightUpPoint.transform.position, rightDownPoint.transform.position, leftDownPoint.transform.position, bodyStruct.mFilter.mesh);
		//初始位置
		controlPointList.Add(leftUpPoint);
		controlPointList.Add(rightUpPoint);
		controlPointList.Add(rightDownPoint);
		controlPointList.Add(leftDownPoint);
		InitControlPointList2lastControlPointPosition();

		InitLineRender(thisGameObject);
		SetIconObjectColor();
		SetParent2BodyAndControlPointList(thisGameObject);


		InitDecorateIconObjectSetting(correspondingDragItemObject);
	}
	public void AdjPos(Vector3 tmp, GameObject chooseGameObject)
	{
		float OffsetX = 0;
		if (chooseGameObject == rightUpPoint)
		{
			OffsetX = (tmp.x - lastControlPointPosition[(int)PointIndex.RightUpPoint].x);
			leftUpPoint.transform.position = new Vector3(leftUpPoint.transform.position.x - OffsetX, leftUpPoint.transform.position.y, leftUpPoint.transform.position.z);
		}
		else if (chooseGameObject == leftUpPoint)
		{
			OffsetX = (tmp.x - lastControlPointPosition[(int)PointIndex.LeftUpPoint].x);
			rightUpPoint.transform.position = new Vector3(rightUpPoint.transform.position.x - OffsetX, rightUpPoint.transform.position.y, rightUpPoint.transform.position.z);
		}
		else if (chooseGameObject == rightDownPoint)
		{
			OffsetX = (tmp.x - lastControlPointPosition[(int)PointIndex.RightDownPoint].x);
			leftDownPoint.transform.position = new Vector3(leftDownPoint.transform.position.x - OffsetX, leftDownPoint.transform.position.y, leftDownPoint.transform.position.z);

			doubleRoofEaveWidth = rightDownPoint.transform.position.x-columnIcon.rightColumn.upPoint.transform.position.x;
		}
		else if (chooseGameObject == leftDownPoint)
		{
			OffsetX = (tmp.x - lastControlPointPosition[(int)PointIndex.LeftDownPoint].x);
			rightDownPoint.transform.position = new Vector3(rightDownPoint.transform.position.x - OffsetX, rightDownPoint.transform.position.y, rightDownPoint.transform.position.z);

			doubleRoofEaveWidth = rightDownPoint.transform.position.x - columnIcon.rightColumn.upPoint.transform.position.x;
		}
		doubleRoofTopWidth = (rightUpPoint.transform.position.x - leftUpPoint.transform.position.x);
		UpdateLastPos();
	}
	public void AdjMesh()
	{

		bodyStruct.mFilter.mesh.Clear();
		bodyStruct.mFilter.mesh = CreatRecMesh(leftUpPoint.transform.position, rightUpPoint.transform.position, rightDownPoint.transform.position, leftDownPoint.transform.position, bodyStruct.mFilter.mesh);

		UpdateLineRender();
		UpdateCollider();
	}
/*
	public void SetIconObjectColor()
	{
		if (silhouetteShader != null)
		{
			rightUpPoint.GetComponent<MeshRenderer>().material = silhouetteShader;
			leftUpPoint.GetComponent<MeshRenderer>().material = silhouetteShader;
			rightUpPoint.GetComponent<MeshRenderer>().material = silhouetteShader;
			leftUpPoint.GetComponent<MeshRenderer>().material = silhouetteShader;
		}
		bodyStruct.mRenderer.material.color = Color.red;
		rightUpPoint.GetComponent<MeshRenderer>().material.color = Color.yellow;
		leftUpPoint.GetComponent<MeshRenderer>().material.color = Color.yellow;
	}*/
/*
	public override void InitLineRender<T>(T thisGameObject)
	{
		controlPointList_Vec3_2_LineRender.Add(leftUpPoint.transform.position);
		controlPointList_Vec3_2_LineRender.Add(rightUpPoint.transform.position);
		controlPointList_Vec3_2_LineRender.Add(rightDownPoint.transform.position);
		controlPointList_Vec3_2_LineRender.Add(leftDownPoint.transform.position);

		for (int i = 0; i < controlPointList_Vec3_2_LineRender.Count; i++)
		{
			if (i != controlPointList_Vec3_2_LineRender.Count - 1)
				CreateLineRenderer(thisGameObject, controlPointList_Vec3_2_LineRender[i], controlPointList_Vec3_2_LineRender[i + 1]);
			else
				CreateLineRenderer(thisGameObject, controlPointList_Vec3_2_LineRender[i], controlPointList_Vec3_2_LineRender[0]);
		}
	}*/
/*
	public override void UpdateLineRender()
	{
		controlPointList_Vec3_2_LineRender[(int)PointIndex.LeftUpPoint] = (leftUpPoint.transform.position);
		controlPointList_Vec3_2_LineRender[(int)PointIndex.RightUpPoint] = (rightUpPoint.transform.position);
		controlPointList_Vec3_2_LineRender[(int)PointIndex.RightDownPoint] = (rightDownPoint.transform.position);
		controlPointList_Vec3_2_LineRender[(int)PointIndex.LeftDownPoint] = (leftDownPoint.transform.position);
		for (int i = 0; i < lineRenderList.Count; i++)
		{
			if (i != controlPointList_Vec3_2_LineRender.Count - 1)
				AdjLineRenderer(i, controlPointList_Vec3_2_LineRender[i], controlPointList_Vec3_2_LineRender[i + 1]);
			else
				AdjLineRenderer(i, controlPointList_Vec3_2_LineRender[i], controlPointList_Vec3_2_LineRender[0]);
		}
	}*/
	public Vector3 ClampPos(Vector3 inputPos, GameObject chooseObj)
	{
		float minClampX = float.MinValue;
		float maxClampX = float.MaxValue;
		float minClampY = float.MinValue;
		float maxClampY = float.MaxValue;
		if (chooseObj == rightUpPoint)
		{
			maxClampX = rightDownPoint.transform.position.x;
			minClampX = centerX + closerDis;
		}
		else if (chooseObj == leftUpPoint)
		{
			minClampX = leftDownPoint.transform.position.x;
			maxClampX = centerX - closerDis;
		}
		else if (chooseObj == rightDownPoint)
		{
			minClampX = columnIcon.rightColumn.upPoint.transform.position.x;
		}
		else if (chooseObj == leftDownPoint)
		{
			maxClampX = columnIcon.leftColumn.upPoint.transform.position.x;
		}
		float posX = Mathf.Clamp(inputPos.x, minClampX, maxClampX);
		float posY = Mathf.Clamp(inputPos.y, minClampY, maxClampY);
		return new Vector3(posX, posY, inputPos.z);
	}
}
public class FriezeIcon : DecorateIconObject
{
	public float friezeHeight;
	public void FriezeIconCreate<T>(T thisGameObject, string objName, ColumnIcon columnIcon, float ini_friezeHeight, GameObject correspondingDragItemObject) where T : Component
	{
		InitBodySetting(objName, (int)BodyType.GeneralBody);
		InitIconMenuButtonSetting();

		Vector3 h = new Vector3(0.0f, ini_friezeHeight, 0.0f);
		friezeHeight = ini_friezeHeight;
		rightUpPoint = columnIcon.rightColumn.upPoint;
		leftUpPoint = columnIcon.leftColumn.upPoint;
		Vector3 rightDownPointPos = rightUpPoint.transform.position - h;
		Vector3 leftDownPointPos = leftUpPoint.transform.position - h;

		//frieze cp
		rightDownPoint = columnIcon.rightColumn.friezePoint = CreateControlPoint("FRD", columnIcon.rightColumn.downPoint.transform.localScale, rightDownPointPos);
		leftDownPoint = columnIcon.leftColumn.friezePoint = CreateControlPoint("FLD", columnIcon.rightColumn.downPoint.transform.localScale, leftDownPointPos); ;


		bodyStruct.mFilter.mesh = CreatRecMesh(leftUpPoint.transform.position, rightUpPoint.transform.position, rightDownPoint.transform.position, leftDownPoint.transform.position, bodyStruct.mFilter.mesh);
		//初始位置
		columnIcon.controlPointList.Add(rightDownPoint);
		columnIcon.controlPointList.Add(leftDownPoint);
		controlPointList.Add(rightDownPoint);
		controlPointList.Add(leftDownPoint);
		InitControlPointList2lastControlPointPosition();


		InitLineRender(thisGameObject);
		SetIconObjectColor();
		SetParent2BodyAndControlPointList(thisGameObject);

		InitDecorateIconObjectSetting(correspondingDragItemObject);

	}
	public void AdjMesh()
	{

		bodyStruct.mFilter.mesh.Clear();

		bodyStruct.mFilter.mesh = CreatRecMesh(leftUpPoint.transform.position, rightUpPoint.transform.position, rightDownPoint.transform.position, leftDownPoint.transform.position, bodyStruct.mFilter.mesh);

		UpdateLineRender();
		UpdateCollider();

	}
	public void SetIconObjectColor()
	{
		if (silhouetteShader != null)
		{
			rightDownPoint.GetComponent<MeshRenderer>().material = silhouetteShader;
			leftDownPoint.GetComponent<MeshRenderer>().material = silhouetteShader;
		}
		bodyStruct.mRenderer.material.color = Color.red;
		rightDownPoint.GetComponent<MeshRenderer>().material.color = Color.yellow;
		leftDownPoint.GetComponent<MeshRenderer>().material.color = Color.yellow;
	}
	public void AdjPos(Vector3 tmp)
	{
		leftDownPoint.transform.position = new Vector3(leftDownPoint.transform.position.x, tmp.y, leftDownPoint.transform.position.z);
		rightDownPoint.transform.position = new Vector3(rightDownPoint.transform.position.x, tmp.y, rightDownPoint.transform.position.z);

		friezeHeight = rightUpPoint.transform.position.y - rightDownPoint.transform.position.y;
		UpdateLastPos();
	}
	public override void InitLineRender<T>(T thisGameObject)
	{
		controlPointList_Vec3_2_LineRender.Add(leftUpPoint.transform.position);
		controlPointList_Vec3_2_LineRender.Add(rightUpPoint.transform.position);
		controlPointList_Vec3_2_LineRender.Add(rightDownPoint.transform.position);
		controlPointList_Vec3_2_LineRender.Add(leftDownPoint.transform.position);

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
		controlPointList_Vec3_2_LineRender[(int)PointIndex.LeftUpPoint] = (leftUpPoint.transform.position);
		controlPointList_Vec3_2_LineRender[(int)PointIndex.RightUpPoint] = (rightUpPoint.transform.position);
		controlPointList_Vec3_2_LineRender[(int)PointIndex.RightDownPoint] = (rightDownPoint.transform.position);
		controlPointList_Vec3_2_LineRender[(int)PointIndex.LeftDownPoint] = (leftDownPoint.transform.position);
		for (int i = 0; i < lineRenderList.Count; i++)
		{
			if (i != controlPointList_Vec3_2_LineRender.Count - 1)
				AdjLineRenderer(i, controlPointList_Vec3_2_LineRender[i], controlPointList_Vec3_2_LineRender[i + 1]);
			else
				AdjLineRenderer(i, controlPointList_Vec3_2_LineRender[i], controlPointList_Vec3_2_LineRender[0]);
		}
	}
}
public class WallIcon : DecorateIconObject
{
	public enum PointIndex { LeftUpPoint = 0, RightUpPoint = 1, RightDownPoint = 2, LeftDownPoint = 3, LeftUpWindowPoint = 4, RightUpWindowPoint = 5, RightDownWindowPoint = 6, LeftDownWindowPoint = 7, };

	public GameObject rightUpWindowPoint;
	public GameObject rightDownWindowPoint;
	public GameObject leftUpWindowPoint;
	public GameObject leftDownWindowPoint;

	public int windowIconCount = 1;
	public int windowIconMaxCount = 5;

	public float wallWidth;
	public float windowHeight;
	public float initWallWidth;
	public float initWallHeight;
	public float initWindowsHeight;

	ColumnIcon MainComponent;
	BodyStruct windowBody = new BodyStruct();
	public void WallIconCreate<T>(T thisGameObject, string objName, ColumnIcon columnIcon, float ini_wallWidth, float ini_windowsHeight, GameObject correspondingDragItemObject) where T : Component
	{
		MainComponent = columnIcon;
		InitBodySetting(objName, (int)BodyType.GeneralBody);
		windowBody = InitBodySetting("WindowMesh", (int)BodyType.GeneralBody, windowBody);
		InitIconMenuButtonSetting();

		centerX = columnIcon.centerX;

		Vector3 wallOffset = new Vector3(Mathf.Abs(columnIcon.rightColumn.upPoint.transform.transform.position.x - columnIcon.leftColumn.upPoint.transform.transform.position.x) / 2.0f - ini_wallWidth, 0, 0);
		float columnHeight = columnIcon.rightColumn.upPoint.transform.transform.position.y - columnIcon.rightColumn.downPoint.transform.transform.position.y;
		Vector3 windowsOffset = new Vector3(0, columnHeight / 2.0f - ini_windowsHeight / 2.0f, 0);

		initWallWidth = wallWidth = ini_wallWidth;
		initWallHeight = columnHeight;
		windowHeight = initWindowsHeight = ini_windowsHeight;
		//WallIcon cp
		rightUpPoint = CreateControlPoint("WRU", columnIcon.rightColumn.upPoint.transform.localScale, columnIcon.rightColumn.upPoint.transform.transform.position - wallOffset);
		rightDownPoint = CreateControlPoint("WRD", columnIcon.rightColumn.downPoint.transform.localScale, columnIcon.rightColumn.downPoint.transform.transform.position - wallOffset);
		leftUpPoint = CreateControlPoint("WLU", columnIcon.leftColumn.upPoint.transform.localScale, columnIcon.leftColumn.upPoint.transform.transform.position + wallOffset);
		leftDownPoint = CreateControlPoint("WLD", columnIcon.leftColumn.downPoint.transform.localScale, columnIcon.leftColumn.downPoint.transform.transform.position + wallOffset);
		rightUpWindowPoint = CreateControlPoint("WWRU", columnIcon.rightColumn.upPoint.transform.localScale, columnIcon.rightColumn.upPoint.transform.transform.position - windowsOffset - wallOffset);
		rightDownWindowPoint = CreateControlPoint("WWRD", columnIcon.rightColumn.downPoint.transform.localScale, columnIcon.rightColumn.downPoint.transform.transform.position + windowsOffset - wallOffset);
		leftUpWindowPoint = CreateControlPoint("WWLU", columnIcon.leftColumn.upPoint.transform.localScale, columnIcon.leftColumn.upPoint.transform.transform.position - windowsOffset + wallOffset);
		leftDownWindowPoint = CreateControlPoint("WWLD", columnIcon.leftColumn.downPoint.transform.localScale, columnIcon.leftColumn.downPoint.transform.transform.position + windowsOffset + wallOffset);


		bodyStruct.mFilter.mesh = CreatRecMesh(leftUpPoint.transform.position, rightUpPoint.transform.position, rightDownPoint.transform.position, leftDownPoint.transform.position, bodyStruct.mFilter.mesh);
		windowBody.mFilter.mesh = CreatRecMesh(leftUpWindowPoint.transform.position, rightUpWindowPoint.transform.position, rightDownWindowPoint.transform.position, leftDownWindowPoint.transform.position, windowBody.mFilter.mesh);

		controlPointList.Add(leftUpPoint);
		controlPointList.Add(rightUpPoint);
		controlPointList.Add(rightDownPoint);
		controlPointList.Add(leftDownPoint);
		controlPointList.Add(leftUpWindowPoint);
		controlPointList.Add(rightUpWindowPoint);
		controlPointList.Add(rightDownWindowPoint);
		controlPointList.Add(leftDownWindowPoint);
		InitControlPointList2lastControlPointPosition();


		InitLineRender(thisGameObject);
		SetIconObjectColor();
		SetParent2BodyAndControlPointList(thisGameObject, windowBody.body);


		InitDecorateIconObjectSetting(correspondingDragItemObject, windowBody.body);
	}
	public void AdjMesh()
	{
		bodyStruct.mFilter.mesh.Clear();
		bodyStruct.mFilter.mesh = CreatRecMesh(leftUpPoint.transform.position, rightUpPoint.transform.position, rightDownPoint.transform.position, leftDownPoint.transform.position, bodyStruct.mFilter.mesh);
		windowBody.mFilter.mesh = CreatRecMesh(leftUpWindowPoint.transform.position, rightUpWindowPoint.transform.position, rightDownWindowPoint.transform.position, leftDownWindowPoint.transform.position, windowBody.mFilter.mesh);
		UpdateLineRender();
		UpdateCollider();
	}
	public override void InitLineRender<T>(T thisGameObject)
	{
		controlPointList_Vec3_2_LineRender.Add(leftUpPoint.transform.position);
		controlPointList_Vec3_2_LineRender.Add(rightUpPoint.transform.position);
		controlPointList_Vec3_2_LineRender.Add(rightDownPoint.transform.position);
		controlPointList_Vec3_2_LineRender.Add(leftDownPoint.transform.position);
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
		controlPointList_Vec3_2_LineRender[(int)PointIndex.LeftUpPoint] = (leftUpPoint.transform.position);
		controlPointList_Vec3_2_LineRender[(int)PointIndex.RightUpPoint] = (rightUpPoint.transform.position);
		controlPointList_Vec3_2_LineRender[(int)PointIndex.RightDownPoint] = (rightDownPoint.transform.position);
		controlPointList_Vec3_2_LineRender[(int)PointIndex.LeftDownPoint] = (leftDownPoint.transform.position);
		for (int i = 0; i < lineRenderList.Count; i++)
		{
			if (i != controlPointList_Vec3_2_LineRender.Count - 1)
				AdjLineRenderer(i, controlPointList_Vec3_2_LineRender[i], controlPointList_Vec3_2_LineRender[i + 1]);
			else
				AdjLineRenderer(i, controlPointList_Vec3_2_LineRender[i], controlPointList_Vec3_2_LineRender[0]);
		}
	}
	public void SetIconObjectColor()
	{
		bodyStruct.mRenderer.material.color = Color.red;
		windowBody.mRenderer.material.color = Color.white;
		leftUpPoint.GetComponent<MeshRenderer>().material.color = Color.yellow;
		rightUpPoint.GetComponent<MeshRenderer>().material.color = Color.yellow;
		rightDownPoint.GetComponent<MeshRenderer>().material.color = Color.yellow;
		leftDownPoint.GetComponent<MeshRenderer>().material.color = Color.yellow;

		leftUpWindowPoint.GetComponent<MeshRenderer>().material.color = Color.yellow;
		rightUpWindowPoint.GetComponent<MeshRenderer>().material.color = Color.yellow;
		rightDownWindowPoint.GetComponent<MeshRenderer>().material.color = Color.yellow;
		leftDownWindowPoint.GetComponent<MeshRenderer>().material.color = Color.yellow;
	}
	public Vector3 ClampPos(Vector3 inputPos, GameObject chooseObj)
	{
		float minClampX = float.MinValue;
		float maxClampX = float.MaxValue;
		float minClampY = float.MinValue;
		float maxClampY = float.MaxValue;

		float minWidth = closerDis;
		float minWindowHeight = initWindowsHeight * 0.2f;

		if (chooseObj == rightUpPoint)
		{
			maxClampX = MainComponent.rightColumn.upPoint.transform.position.x - closerDis;
			minClampX = centerX + minWidth;
		}
		else if (chooseObj == rightDownPoint)
		{
			maxClampX = MainComponent.rightColumn.downPoint.transform.position.x - closerDis;
			minClampX = centerX + minWidth;
		}
		else if (chooseObj == leftUpPoint)
		{
			minClampX = MainComponent.leftColumn.upPoint.transform.position.x + closerDis;
			maxClampX = centerX - minWidth;
		}
		else if (chooseObj == leftDownPoint)
		{
			minClampX = MainComponent.leftColumn.downPoint.transform.position.x + closerDis;
			maxClampX = centerX - minWidth;
		}
		else if (chooseObj == rightUpWindowPoint)
		{
			minClampY = rightDownWindowPoint.transform.position.y + minWindowHeight;
			maxClampY = rightUpPoint.transform.position.y - closerDis;
		}
		else if (chooseObj == leftUpWindowPoint)
		{
			minClampY = leftDownWindowPoint.transform.position.y + minWindowHeight;
			maxClampY = leftUpPoint.transform.position.y - closerDis;
		}
		else if (chooseObj == rightDownWindowPoint)
		{
			minClampY = rightDownPoint.transform.position.y + closerDis;
			maxClampY = rightUpWindowPoint.transform.position.y - minWindowHeight;
		}
		else if (chooseObj == leftDownWindowPoint)
		{
			minClampY = leftDownPoint.transform.position.y + closerDis;
			maxClampY = leftUpWindowPoint.transform.position.y - minWindowHeight;
		}

		float posX = Mathf.Clamp(inputPos.x, minClampX, maxClampX);
		float posY = Mathf.Clamp(inputPos.y, minClampY, maxClampY);
		return new Vector3(posX, posY, inputPos.z);
	}
	public void AdjPos(Vector3 tmp, GameObject chooseGameObject)
	{
		float OffsetX = 0;
		float OffsetY = 0;
		if (chooseGameObject == leftUpPoint)
		{
			OffsetX = (tmp.x - lastControlPointPosition[(int)PointIndex.LeftUpPoint].x);
			rightUpPoint.transform.position = new Vector3(rightUpPoint.transform.position.x - (OffsetX), rightUpPoint.transform.position.y, rightUpPoint.transform.position.z);
			rightDownPoint.transform.position = new Vector3(rightDownPoint.transform.position.x - (OffsetX), rightDownPoint.transform.position.y, rightDownPoint.transform.position.z);
			leftDownPoint.transform.position = new Vector3(tmp.x, leftDownPoint.transform.position.y, leftDownPoint.transform.position.z);

			rightUpWindowPoint.transform.position = new Vector3(rightUpWindowPoint.transform.position.x - (OffsetX), rightUpWindowPoint.transform.position.y, rightUpWindowPoint.transform.position.z);
			rightDownWindowPoint.transform.position = new Vector3(rightDownWindowPoint.transform.position.x - (OffsetX), rightDownWindowPoint.transform.position.y, rightDownWindowPoint.transform.position.z);
			leftUpWindowPoint.transform.position = new Vector3(tmp.x, leftUpWindowPoint.transform.position.y, leftUpWindowPoint.transform.position.z);
			leftDownWindowPoint.transform.position = new Vector3(tmp.x, leftDownWindowPoint.transform.position.y, leftDownWindowPoint.transform.position.z);
			wallWidth = (rightUpPoint.transform.position.x - leftUpPoint.transform.position.x);
		}
		else if (chooseGameObject == rightUpPoint)
		{
			OffsetX = (tmp.x - lastControlPointPosition[(int)PointIndex.RightUpPoint].x);

			leftUpPoint.transform.position = new Vector3(leftUpPoint.transform.position.x - (OffsetX), leftUpPoint.transform.position.y, leftUpPoint.transform.position.z);
			leftDownPoint.transform.position = new Vector3(leftDownPoint.transform.position.x - (OffsetX), leftDownPoint.transform.position.y, leftDownPoint.transform.position.z);
			rightDownPoint.transform.position = new Vector3(tmp.x, rightDownPoint.transform.position.y, rightDownPoint.transform.position.z);


			leftUpWindowPoint.transform.position = new Vector3(leftUpWindowPoint.transform.position.x - (OffsetX), leftUpWindowPoint.transform.position.y, leftUpWindowPoint.transform.position.z);
			leftDownWindowPoint.transform.position = new Vector3(leftDownWindowPoint.transform.position.x - (OffsetX), leftDownWindowPoint.transform.position.y, leftDownWindowPoint.transform.position.z);
			rightDownWindowPoint.transform.position = new Vector3(tmp.x, rightDownWindowPoint.transform.position.y, rightDownWindowPoint.transform.position.z);
			rightUpWindowPoint.transform.position = new Vector3(tmp.x, rightUpWindowPoint.transform.position.y, rightUpWindowPoint.transform.position.z);
			wallWidth = (rightUpPoint.transform.position.x - leftUpPoint.transform.position.x);
		}
		else if (chooseGameObject == rightDownPoint)
		{
			OffsetX = (tmp.x - lastControlPointPosition[(int)PointIndex.RightDownPoint].x);

			leftUpPoint.transform.position = new Vector3(leftUpPoint.transform.position.x - (OffsetX), leftUpPoint.transform.position.y, leftUpPoint.transform.position.z);
			leftDownPoint.transform.position = new Vector3(leftDownPoint.transform.position.x - (OffsetX), leftDownPoint.transform.position.y, leftDownPoint.transform.position.z);
			rightUpPoint.transform.position = new Vector3(tmp.x, rightUpPoint.transform.position.y, rightUpPoint.transform.position.z);

			leftUpWindowPoint.transform.position = new Vector3(leftUpWindowPoint.transform.position.x - (OffsetX), leftUpWindowPoint.transform.position.y, leftUpWindowPoint.transform.position.z);
			leftDownWindowPoint.transform.position = new Vector3(leftDownWindowPoint.transform.position.x - (OffsetX), leftDownWindowPoint.transform.position.y, leftDownWindowPoint.transform.position.z);
			rightUpWindowPoint.transform.position = new Vector3(tmp.x, rightUpWindowPoint.transform.position.y, rightUpWindowPoint.transform.position.z);
			rightDownWindowPoint.transform.position = new Vector3(tmp.x, rightDownWindowPoint.transform.position.y, rightDownWindowPoint.transform.position.z);
			wallWidth = (rightUpPoint.transform.position.x - leftUpPoint.transform.position.x);
		}
		else if (chooseGameObject == leftDownPoint)
		{
			OffsetX = (tmp.x - lastControlPointPosition[(int)PointIndex.LeftDownPoint].x);
			rightUpPoint.transform.position = new Vector3(rightUpPoint.transform.position.x - (OffsetX), rightUpPoint.transform.position.y, rightUpPoint.transform.position.z);
			rightDownPoint.transform.position = new Vector3(rightDownPoint.transform.position.x - (OffsetX), rightDownPoint.transform.position.y, rightDownPoint.transform.position.z);
			leftUpPoint.transform.position = new Vector3(tmp.x, leftUpPoint.transform.position.y, leftUpPoint.transform.position.z);

			rightUpWindowPoint.transform.position = new Vector3(rightUpWindowPoint.transform.position.x - (OffsetX), rightUpWindowPoint.transform.position.y, rightUpWindowPoint.transform.position.z);
			rightDownWindowPoint.transform.position = new Vector3(rightDownWindowPoint.transform.position.x - (OffsetX), rightDownWindowPoint.transform.position.y, rightDownWindowPoint.transform.position.z);
			leftUpWindowPoint.transform.position = new Vector3(tmp.x, leftUpWindowPoint.transform.position.y, leftUpWindowPoint.transform.position.z);
			leftDownWindowPoint.transform.position = new Vector3(tmp.x, leftDownWindowPoint.transform.position.y, leftDownWindowPoint.transform.position.z);
			wallWidth = (rightUpPoint.transform.position.x - leftUpPoint.transform.position.x);
		}
		else if (chooseGameObject == leftUpWindowPoint)
		{
			OffsetY = (tmp.y - lastControlPointPosition[(int)PointIndex.LeftUpWindowPoint].y);
			rightUpWindowPoint.transform.position = new Vector3(rightUpWindowPoint.transform.position.x, rightUpWindowPoint.transform.position.y + (OffsetY), rightUpWindowPoint.transform.position.z);
			windowHeight = (rightUpPoint.transform.position.x - leftUpPoint.transform.position.x);

		}
		else if (chooseGameObject == rightUpWindowPoint)
		{
			OffsetY = (tmp.y - lastControlPointPosition[(int)PointIndex.RightUpWindowPoint].y);
			leftUpWindowPoint.transform.position = new Vector3(leftUpWindowPoint.transform.position.x, leftUpWindowPoint.transform.position.y + (OffsetY), rightUpPoint.transform.position.z);
			windowHeight = (rightUpPoint.transform.position.x - leftUpPoint.transform.position.x);
		}
		else if (chooseGameObject == rightDownWindowPoint)
		{
			OffsetY = (tmp.y - lastControlPointPosition[(int)PointIndex.RightDownWindowPoint].y);
			leftDownWindowPoint.transform.position = new Vector3(leftDownWindowPoint.transform.position.x, leftDownWindowPoint.transform.position.y + (OffsetY), leftDownWindowPoint.transform.position.z);
			windowHeight = (rightUpPoint.transform.position.x - leftUpPoint.transform.position.x);
		}
		else if (chooseGameObject == leftDownWindowPoint)
		{
			OffsetY = (tmp.y - lastControlPointPosition[(int)PointIndex.LeftDownWindowPoint].y);
			rightDownWindowPoint.transform.position = new Vector3(rightDownWindowPoint.transform.position.x, rightDownWindowPoint.transform.position.y + (OffsetY), rightDownWindowPoint.transform.position.z);
			windowHeight = (rightUpPoint.transform.position.x - leftUpPoint.transform.position.x);
		}
		UpdateLastPos();
	}
	public void InitIconMenuButtonSetting()
	{
		iconMenuControl.delelteButton.isDeleteIconButton = true;
		iconMenuControl.scrollBarButton.isScrollBarIconButton = true;
		iconMenuControl.scrollBarButton.scrollBarIconValue = windowIconCount;
		iconMenuControl.scrollBarButton.scrollBarIconMaxValue = windowIconMaxCount;
		iconMenuControl.scrollBarButton.scrollBarIconType = (int)ScrollBarButton.ScrollType.INT;
	}
	public override void InitIconMenuButtonUpdate()
	{
		windowIconCount = iconMenuControl.scrollBarButton.scrollBarIconValue;
	}
}
public class BalustradeIcon : DecorateIconObject
{
	public float balustradeHeight;
	public void BalustradeIconCreate<T>(T thisGameObject, string objName, ColumnIcon columnIcon, float ini_balustradeHeight, GameObject correspondingDragItemObject) where T : Component
	{
		InitBodySetting(objName, (int)BodyType.GeneralBody);
		InitIconMenuButtonSetting();

		Vector3 h = new Vector3(0.0f, ini_balustradeHeight, 0.0f);
		balustradeHeight = ini_balustradeHeight;
		rightDownPoint = columnIcon.rightColumn.downPoint;
		leftDownPoint = columnIcon.leftColumn.downPoint;
		Vector3 rightUpPointPos = rightDownPoint.transform.position + h;
		Vector3 leftUpPointPos = leftDownPoint.transform.position + h;

		//right
		rightUpPoint = columnIcon.rightColumn.balustradePoint = CreateControlPoint("BRU", columnIcon.rightColumn.downPoint.transform.localScale, rightUpPointPos);
		//left
		leftUpPoint = columnIcon.leftColumn.balustradePoint = CreateControlPoint("BLU", columnIcon.rightColumn.downPoint.transform.localScale, leftUpPointPos);

		bodyStruct.mFilter.mesh = CreatRecMesh(leftUpPoint.transform.position, rightUpPoint.transform.position, rightDownPoint.transform.position, leftDownPoint.transform.position, bodyStruct.mFilter.mesh);
		//初始位置
		columnIcon.controlPointList.Add(leftUpPoint);
		columnIcon.controlPointList.Add(rightUpPoint);
		controlPointList.Add(leftUpPoint);
		controlPointList.Add(rightUpPoint);
		InitControlPointList2lastControlPointPosition();

		/*
				columnIcon.leftColumn.controlPointList.Add(columnIcon.leftColumn.balustradePoint);
				columnIcon.rightColumn.controlPointList.Add(columnIcon.rightColumn.balustradePoint);*/

		InitLineRender(thisGameObject);
		SetIconObjectColor(columnIcon);
		SetParent2BodyAndControlPointList(thisGameObject);


		InitDecorateIconObjectSetting(correspondingDragItemObject);
	}
	public void AdjMesh()
	{

		bodyStruct.mFilter.mesh.Clear();

		bodyStruct.mFilter.mesh = CreatRecMesh(leftUpPoint.transform.position, rightUpPoint.transform.position, rightDownPoint.transform.position, leftDownPoint.transform.position, bodyStruct.mFilter.mesh);

		UpdateLineRender();
		UpdateCollider();
	}
	public void SetIconObjectColor(ColumnIcon columnIcon)
	{
		if (silhouetteShader != null)
		{
			columnIcon.rightColumn.balustradePoint.GetComponent<MeshRenderer>().material = silhouetteShader;
			columnIcon.leftColumn.balustradePoint.GetComponent<MeshRenderer>().material = silhouetteShader;
		}
		bodyStruct.mRenderer.material.color = Color.red;
		columnIcon.rightColumn.balustradePoint.GetComponent<MeshRenderer>().material.color = Color.yellow;
		columnIcon.leftColumn.balustradePoint.GetComponent<MeshRenderer>().material.color = Color.yellow;
	}
	public void AdjPos(Vector3 tmp)
	{
		leftUpPoint.transform.position = new Vector3(leftUpPoint.transform.position.x, tmp.y, leftUpPoint.transform.position.z);
		rightUpPoint.transform.position = new Vector3(rightUpPoint.transform.position.x, tmp.y, rightUpPoint.transform.position.z);

		balustradeHeight = rightUpPoint.transform.position.y - rightDownPoint.transform.position.y;

		UpdateLastPos();
		UpdateLineRender();
	}
	public override void InitLineRender<T>(T thisGameObject)
	{
		controlPointList_Vec3_2_LineRender.Add(leftUpPoint.transform.position);
		controlPointList_Vec3_2_LineRender.Add(rightUpPoint.transform.position);
		controlPointList_Vec3_2_LineRender.Add(rightDownPoint.transform.position);
		controlPointList_Vec3_2_LineRender.Add(leftDownPoint.transform.position);

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
		controlPointList_Vec3_2_LineRender[(int)PointIndex.LeftUpPoint] = (leftUpPoint.transform.position);
		controlPointList_Vec3_2_LineRender[(int)PointIndex.RightUpPoint] = (rightUpPoint.transform.position);
		controlPointList_Vec3_2_LineRender[(int)PointIndex.RightDownPoint] = (rightDownPoint.transform.position);
		controlPointList_Vec3_2_LineRender[(int)PointIndex.LeftDownPoint] = (leftDownPoint.transform.position);
		for (int i = 0; i < lineRenderList.Count; i++)
		{
			if (i != controlPointList_Vec3_2_LineRender.Count - 1)
				AdjLineRenderer(i, controlPointList_Vec3_2_LineRender[i], controlPointList_Vec3_2_LineRender[i + 1]);
			else
				AdjLineRenderer(i, controlPointList_Vec3_2_LineRender[i], controlPointList_Vec3_2_LineRender[0]);
		}
	}
}
public class ColumnIcon : IconObject
{
	public enum PointIndex { LeftUpPoint = 0, RightUpPoint = 1, RightDownPoint = 2, LeftDownPoint = 3, };
	public List<GameObject> body = null;
	public Column leftColumn;
	public Column rightColumn;

	public DoubleRoofIcon doubleRoofIcon = null;

	public FriezeIcon friezeIcon = null;

	public BalustradeIcon balustradeIcon = null;

	public WallIcon wallIcon = null;

	public MutiColumnIcon mutiColumnIcon = null;

	public int mutiColumnIconCount = 6;
	public int mutiColumnIconMaxCount = 15;

	public float initFriezeHeight;
	public float initBalustradeHeight;

	public float columnHeight;
	public float columnWidth;
	public float initColumnWidth;
	public float initColumnHeight;
	public float minFriezeHeight;
	public float minBalustradeHeight;
	public void ColumnIconCreate<T>(T thisGameObject, GameObject rightUpPoint, GameObject rightDownPoint, GameObject leftUpPoint, GameObject leftDownPoint, float columnHeight, float ini_friezeHeight, float ini_balustradeHeight) where T : Component
	{

		InitBodySetting(thisGameObject);
		InitIconMenuButtonSetting();

		centerX = (leftUpPoint.transform.position.x + rightUpPoint.transform.position.x) / 2.0f;

		leftColumn = new Column("ColumnIcon", leftUpPoint, leftDownPoint, columnHeight);
		rightColumn = new Column("ColumnIcon", rightUpPoint, rightDownPoint, columnHeight);

		this.columnHeight = initColumnHeight = columnHeight;
		this.columnWidth = initColumnWidth = rightUpPoint.transform.position.x - leftUpPoint.transform.position.x;
		this.initFriezeHeight = ini_friezeHeight;
		this.initBalustradeHeight = ini_balustradeHeight;
		minFriezeHeight = initColumnHeight * 0.1f;
		minBalustradeHeight = initColumnHeight * 0.1f;

		body = new List<GameObject>();
		body.Add(leftColumn.bodyStruct.body);
		body.Add(rightColumn.bodyStruct.body);

		controlPointList.Add(leftColumn.upPoint);
		controlPointList.Add(rightColumn.upPoint);
		controlPointList.Add(rightColumn.downPoint);
		controlPointList.Add(leftColumn.downPoint);
		controlPointList.Add(rightColumn.bodyStruct.body);
		controlPointList.Add(leftColumn.bodyStruct.body);
		InitControlPointList2lastControlPointPosition();

		SetParent2BodyAndControlPointList(thisGameObject);

		for (int i = 0; i < body.Count; i++)
		{
			if (body[i].GetComponent<IconControl>())
				UnityEngine.Object.Destroy(body[i].GetComponent<IconControl>());
		}
	}
	public void SetParent2BodyAndControlPointList<T>(T thisGameObject)
where T : Component
	{
		for (int i = 0; i < body.Count; i++)
		{
			body[i].transform.parent = thisGameObject.transform;
		}
	}
	public void CreateWall<T>(T thisGameObject, string objName, float ini_wallWidth, float ini_windowHeight, GameObject correspondingDragItemObject) where T : Component
	{
		wallIcon = new WallIcon();
		wallIcon.WallIconCreate(thisGameObject, objName, this, ini_wallWidth, ini_windowHeight, correspondingDragItemObject);
	}
	public void CreateDoubleRoof<T>(T thisGameObject, string objName, float ini_doubleRoofHeight, float ini_doubleRoofWidth, GameObject correspondingDragItemObject) where T : Component
	{
		doubleRoofIcon = new DoubleRoofIcon();
		doubleRoofIcon.DoubleRoofIconCreate(thisGameObject, objName, this, ini_doubleRoofHeight, ini_doubleRoofWidth, correspondingDragItemObject);
	}
	public void CreateBlustrade<T>(T thisGameObject, string objName, float ini_balustradeHeight, GameObject correspondingDragItemObject) where T : Component
	{
		balustradeIcon = new BalustradeIcon();
		balustradeIcon.BalustradeIconCreate(thisGameObject, objName, this, ini_balustradeHeight, correspondingDragItemObject);
	}
	public void CreateFrieze<T>(T thisGameObject, string objName, float ini_friezeHeight, GameObject correspondingDragItemObject) where T : Component
	{
		friezeIcon = new FriezeIcon();
		friezeIcon.FriezeIconCreate(thisGameObject, objName, this, ini_friezeHeight, correspondingDragItemObject);
	}
	public void CreateMutiColumn<T>(T thisGameObject, string objName, GameObject correspondingDragItemObject) where T : Component
	{
		mutiColumnIcon = new MutiColumnIcon();
		mutiColumnIcon.MutiColumnIconCreate(thisGameObject, objName, this, correspondingDragItemObject);
	}
	public Vector3 ClampPos(Vector3 inputPos, GameObject chooseObj)
	{
		float minClampX = float.MinValue;
		float maxClampX = float.MaxValue;
		float minClampY = float.MinValue;
		float maxClampY = float.MaxValue;

		float minWidth = closerDis;
		float minHeight = initColumnHeight * 0.7f;
		float friezeHeight = (friezeIcon != null) ? friezeIcon.friezeHeight : initFriezeHeight;
		float balustradeHeight = (balustradeIcon != null) ? balustradeIcon.balustradeHeight : initBalustradeHeight;

		if (chooseObj == rightColumn.bodyStruct.body)
		{
			if (wallIcon != null) minClampX = wallIcon.rightUpPoint.transform.position.x + closerDis;
			else minClampX = centerX + minWidth;
		}
		else if (chooseObj == leftColumn.bodyStruct.body)
		{
			if (wallIcon != null) maxClampX = wallIcon.leftUpPoint.transform.position.x - closerDis;
			else maxClampX = centerX - minWidth;
		}
		else if (chooseObj == rightColumn.upPoint)
		{
			if (wallIcon != null) minClampY = wallIcon.rightUpWindowPoint.transform.position.y + closerDis;
			else minClampY = rightColumn.downPoint.transform.position.y + closerDis + friezeHeight + balustradeHeight;
		}
		else if (chooseObj == rightColumn.downPoint)
		{
			if (wallIcon != null) maxClampY = wallIcon.rightDownWindowPoint.transform.position.y - closerDis;
			else maxClampY = rightColumn.upPoint.transform.position.y - closerDis - friezeHeight - balustradeHeight;
		}
		else if (chooseObj == leftColumn.upPoint)
		{
			if (wallIcon != null) minClampY = wallIcon.leftUpWindowPoint.transform.position.y + closerDis;
			else minClampY = leftColumn.downPoint.transform.position.y + closerDis + friezeHeight + balustradeHeight;
		}
		else if (chooseObj == leftColumn.downPoint)
		{
			if (wallIcon != null) maxClampY = wallIcon.leftDownWindowPoint.transform.position.y - closerDis;
			else maxClampY = leftColumn.upPoint.transform.position.y - closerDis - friezeHeight - balustradeHeight;
		}
		else if (chooseObj == rightColumn.friezePoint)
		{
			minClampY = rightColumn.downPoint.transform.position.y + closerDis + balustradeHeight;
			maxClampY = rightColumn.upPoint.transform.position.y - minFriezeHeight;
		}
		else if (chooseObj == leftColumn.friezePoint)
		{
			minClampY = leftColumn.downPoint.transform.position.y + closerDis + balustradeHeight;
			maxClampY = leftColumn.upPoint.transform.position.y - minFriezeHeight;
		}
		else if (chooseObj == rightColumn.balustradePoint)
		{
			minClampY = rightColumn.downPoint.transform.position.y + minBalustradeHeight;
			maxClampY = rightColumn.upPoint.transform.position.y - closerDis - friezeHeight;
			Debug.Log("rfgfgfgf");
		}
		else if (chooseObj == leftColumn.balustradePoint)
		{
			minClampY = leftColumn.downPoint.transform.position.y + minBalustradeHeight;
			maxClampY = leftColumn.upPoint.transform.position.y - friezeHeight;
		}


		float posX = Mathf.Clamp(inputPos.x, minClampX, maxClampX);
		float posY = Mathf.Clamp(inputPos.y, minClampY, maxClampY);
		return new Vector3(posX, posY, inputPos.z);
	}
	public Vector3 AdjPos(Vector3 tmp, GameObject chooseObject)
	{
		float OffsetX = 0;
		float OffsetY = 0;
		columnHeight = (rightColumn.upPoint.transform.position.y - rightColumn.downPoint.transform.position.y);
		columnHeight = Mathf.Abs(columnHeight);
		if (chooseObject == leftColumn.upPoint || chooseObject == rightColumn.upPoint)
		{
			OffsetY = tmp.y - lastControlPointPosition[(int)PointIndex.LeftUpPoint].y;
			//update point
			rightColumn.upPoint.transform.position = new Vector3(rightColumn.upPoint.transform.position.x, tmp.y, rightColumn.upPoint.transform.position.z);
			leftColumn.upPoint.transform.position = new Vector3(leftColumn.upPoint.transform.position.x, tmp.y, leftColumn.upPoint.transform.position.z);

			rightColumn.bodyStruct.body.transform.position = new Vector3(rightColumn.upPoint.transform.position.x, rightColumn.upPoint.transform.position.y - columnHeight / 2.0f, rightColumn.upPoint.transform.position.z);

			leftColumn.bodyStruct.body.transform.position = new Vector3(leftColumn.upPoint.transform.position.x, leftColumn.upPoint.transform.position.y - columnHeight / 2.0f, leftColumn.upPoint.transform.position.z);

			rightColumn.bodyStruct.body.transform.localScale = new Vector3(rightColumn.radius, columnHeight / 2.0f, rightColumn.radius);
			leftColumn.bodyStruct.body.transform.localScale = new Vector3(leftColumn.radius, columnHeight / 2.0f, leftColumn.radius);


			if (friezeIcon != null)
			{
				rightColumn.friezePoint.transform.position = new Vector3(rightColumn.upPoint.transform.position.x, tmp.y - friezeIcon.friezeHeight, rightColumn.upPoint.transform.position.z);
				leftColumn.friezePoint.transform.position = new Vector3(leftColumn.upPoint.transform.position.x, tmp.y - friezeIcon.friezeHeight, leftColumn.upPoint.transform.position.z);

				friezeIcon.AdjMesh();
				friezeIcon.UpdateLastPos();
			}
			if (doubleRoofIcon != null)
			{

				doubleRoofIcon.rightDownPoint.transform.position += new Vector3(0,OffsetY,0);
				doubleRoofIcon.leftDownPoint.transform.position += new Vector3(0, OffsetY, 0);
				doubleRoofIcon.rightUpPoint.transform.position += new Vector3(0, OffsetY, 0);
				doubleRoofIcon.leftUpPoint.transform.position += new Vector3(0, OffsetY, 0);

				doubleRoofIcon.AdjMesh();
			}
			if (wallIcon != null)
			{
				wallIcon.rightUpPoint.transform.position = new Vector3(wallIcon.rightUpPoint.transform.position.x, tmp.y, wallIcon.rightUpPoint.transform.position.z);
				wallIcon.leftUpPoint.transform.position = new Vector3(wallIcon.leftUpPoint.transform.position.x, tmp.y, wallIcon.leftUpPoint.transform.position.z);


				wallIcon.AdjMesh();
				wallIcon.UpdateLastPos();
			}
		}
		else if (chooseObject == leftColumn.downPoint || chooseObject == rightColumn.downPoint)
		{
			OffsetY = tmp.y - lastControlPointPosition[(int)PointIndex.LeftDownPoint].y;
			//update point
			rightColumn.downPoint.transform.position = new Vector3(rightColumn.downPoint.transform.position.x, tmp.y, rightColumn.downPoint.transform.position.z);
			leftColumn.downPoint.transform.position = new Vector3(leftColumn.downPoint.transform.position.x, tmp.y, rightColumn.downPoint.transform.position.z);
			rightColumn.bodyStruct.body.transform.position = new Vector3(rightColumn.upPoint.transform.position.x, rightColumn.upPoint.transform.position.y - columnHeight / 2.0f, rightColumn.upPoint.transform.position.z);
			leftColumn.bodyStruct.body.transform.position = new Vector3(leftColumn.upPoint.transform.position.x, leftColumn.upPoint.transform.position.y - columnHeight / 2.0f, leftColumn.upPoint.transform.position.z);


			rightColumn.bodyStruct.body.transform.localScale = new Vector3(rightColumn.radius, columnHeight / 2.0f, rightColumn.radius);
			leftColumn.bodyStruct.body.transform.localScale = new Vector3(leftColumn.radius, columnHeight / 2.0f, leftColumn.radius);

			if (balustradeIcon != null)
			{
				rightColumn.balustradePoint.transform.position = new Vector3(rightColumn.downPoint.transform.position.x, tmp.y + balustradeIcon.balustradeHeight, rightColumn.upPoint.transform.position.z);
				leftColumn.balustradePoint.transform.position = new Vector3(leftColumn.downPoint.transform.position.x, tmp.y + balustradeIcon.balustradeHeight, leftColumn.upPoint.transform.position.z);

				balustradeIcon.AdjMesh();
				balustradeIcon.UpdateLastPos();
			}
			if (wallIcon != null)
			{
				wallIcon.rightDownPoint.transform.position = new Vector3(wallIcon.rightDownPoint.transform.position.x, tmp.y, wallIcon.rightDownPoint.transform.position.z);
				wallIcon.leftDownPoint.transform.position = new Vector3(wallIcon.leftDownPoint.transform.position.x, tmp.y, wallIcon.leftDownPoint.transform.position.z);

				wallIcon.AdjMesh();
				wallIcon.UpdateLastPos();
			}
		}
		else if (chooseObject == leftColumn.bodyStruct.body)
		{
			OffsetX = (tmp.x - lastControlPointPosition[(int)PointIndex.LeftUpPoint].x);

			for (int i = 0; i < leftColumn.controlPointList.Count; i++)
			{
				leftColumn.controlPointList[i].transform.position = new Vector3(tmp.x, leftColumn.controlPointList[i].transform.position.y, leftColumn.controlPointList[i].transform.position.z);
				rightColumn.controlPointList[i].transform.position = new Vector3(rightColumn.controlPointList[i].transform.position.x - (OffsetX), rightColumn.controlPointList[i].transform.position.y, rightColumn.controlPointList[i].transform.position.z);
			}
			columnWidth = rightColumn.upPoint.transform.position.x - leftColumn.upPoint.transform.position.x;
			if (friezeIcon != null)
			{
				rightColumn.friezePoint.transform.position = new Vector3(rightColumn.upPoint.transform.position.x, rightColumn.friezePoint.transform.position.y, rightColumn.friezePoint.transform.position.z);
				leftColumn.friezePoint.transform.position = new Vector3(tmp.x, leftColumn.friezePoint.transform.position.y, leftColumn.friezePoint.transform.position.z);

				friezeIcon.AdjMesh();
				friezeIcon.UpdateLastPos();
			}
			if (balustradeIcon != null)
			{
				balustradeIcon.rightUpPoint.transform.position = new Vector3(rightColumn.upPoint.transform.position.x, balustradeIcon.rightUpPoint.transform.position.y, balustradeIcon.rightUpPoint.transform.position.z);
				balustradeIcon.leftUpPoint.transform.position = new Vector3(tmp.x, balustradeIcon.leftUpPoint.transform.position.y, balustradeIcon.leftUpPoint.transform.position.z);

				balustradeIcon.AdjMesh();
				balustradeIcon.UpdateLastPos();
			}
			if (doubleRoofIcon != null)
			{

				doubleRoofIcon.rightDownPoint.transform.position += new Vector3(-OffsetX, 0, 0);
				doubleRoofIcon.leftDownPoint.transform.position += new Vector3(OffsetX, 0, 0);

				doubleRoofIcon.AdjMesh();
			}
		}
		else if (chooseObject == rightColumn.bodyStruct.body)
		{
			OffsetX = (tmp.x - lastControlPointPosition[(int)PointIndex.RightUpPoint].x);

			for (int i = 0; i < rightColumn.controlPointList.Count; i++)
			{
				rightColumn.controlPointList[i].transform.position = new Vector3(tmp.x, rightColumn.controlPointList[i].transform.position.y, rightColumn.controlPointList[i].transform.position.z);
				leftColumn.controlPointList[i].transform.position = new Vector3(leftColumn.controlPointList[i].transform.position.x - (OffsetX), leftColumn.controlPointList[i].transform.position.y, leftColumn.controlPointList[i].transform.position.z);

			}
			columnWidth = rightColumn.upPoint.transform.position.x - leftColumn.upPoint.transform.position.x;
			if (friezeIcon != null)
			{
				rightColumn.friezePoint.transform.position = new Vector3(tmp.x, rightColumn.friezePoint.transform.position.y, rightColumn.friezePoint.transform.position.z);
				leftColumn.friezePoint.transform.position = new Vector3(leftColumn.upPoint.transform.position.x, leftColumn.friezePoint.transform.position.y, leftColumn.friezePoint.transform.position.z);

				friezeIcon.AdjMesh();
				friezeIcon.UpdateLastPos();
			}
			if (balustradeIcon != null)
			{

				balustradeIcon.rightUpPoint.transform.position = new Vector3(tmp.x, balustradeIcon.rightUpPoint.transform.position.y, balustradeIcon.rightUpPoint.transform.position.z);
				balustradeIcon.leftUpPoint.transform.position = new Vector3(leftColumn.upPoint.transform.position.x, balustradeIcon.leftUpPoint.transform.position.y, balustradeIcon.leftUpPoint.transform.position.z);

				balustradeIcon.AdjMesh();
				balustradeIcon.UpdateLastPos();
			}
			if (doubleRoofIcon != null)
			{

				doubleRoofIcon.rightDownPoint.transform.position += new Vector3(OffsetX,0,0);
				doubleRoofIcon.leftDownPoint.transform.position += new Vector3(-OffsetX, 0, 0);

				doubleRoofIcon.AdjMesh();
			}
		}
		rightColumn.UpdateLastPos();
		leftColumn.UpdateLastPos();
		UpdateLastPos();
		return new Vector3(OffsetX,OffsetY,0);
	}
	public void InitBodySetting<T>(T thisGameObject) where T : Component
	{
		iconMenuControl = thisGameObject.gameObject.AddComponent<IconControl>();
	}
	public void InitIconMenuButtonSetting()
	{
		iconMenuControl.delelteButton.isDeleteIconButton = true;
		iconMenuControl.scrollBarButton.isScrollBarIconButton = true;
		iconMenuControl.scrollBarButton.scrollBarIconValue = mutiColumnIconCount;
		iconMenuControl.scrollBarButton.scrollBarIconMaxValue = mutiColumnIconMaxCount;
		iconMenuControl.scrollBarButton.scrollBarIconType = (int)ScrollBarButton.ScrollType.OddINT;
	}
	public override void InitIconMenuButtonUpdate()
	{
		if (wallIcon != null) wallIcon.InitIconMenuButtonUpdate();
		mutiColumnIconCount = iconMenuControl.scrollBarButton.scrollBarIconValue;

	}
}
public class Column : IconObject
{
	public enum PointIndex { UpPoint = 0, DownPoint = 1, Body = 2 };
	public GameObject upPoint = null;
	public GameObject downPoint = null;
	public GameObject balustradePoint = null;
	public GameObject friezePoint = null;
	public float radius = 0.01f;
	public Column(string objName, GameObject upPoint, GameObject downPoint, float columnHeight)
	{
		InitBodySetting(objName, (int)BodyType.CylinderBody);

		bodyStruct.body.transform.localScale = new Vector3(radius, columnHeight / 2.0f, radius);
		bodyStruct.body.transform.position = new Vector3(upPoint.transform.position.x, upPoint.transform.position.y - columnHeight / 2.0f, upPoint.transform.position.z);

		//柱子是可以移動的部分
		this.bodyStruct.body.tag = "ControlPoint";

		this.upPoint = upPoint;
		this.downPoint = downPoint;

		controlPointList.Add(upPoint);
		controlPointList.Add(downPoint);
		controlPointList.Add(bodyStruct.body);
		InitControlPointList2lastControlPointPosition();

		SetIconObjectColor();
	}
	public void SetIconObjectColor()
	{
		if (silhouetteShader != null)
		{
			bodyStruct.mRenderer.material = silhouetteShader;
			upPoint.GetComponent<MeshRenderer>().material = silhouetteShader;
			downPoint.GetComponent<MeshRenderer>().material = silhouetteShader;
		}
		bodyStruct.mRenderer.material.color = Color.red;
		upPoint.GetComponent<MeshRenderer>().material.color = Color.yellow;
		downPoint.GetComponent<MeshRenderer>().material.color = Color.yellow;
	}
}

public class body2icon : MonoBehaviour
{
	public List<GameObject> controlPointList = new List<GameObject>();//所有控制點

	//just try two point
	[HideInInspector]
	[SerializeField]
	public ColumnIcon columnIcon;

	private DragItemController dragitemcontroller;
	private Movement movement;

	public Vector2 ini_bodydis;
	public Vector2 bodydis;
	public float wallWidth;
	public float ini_friezeHeight;
	public float ini_balustradeHeight;
	public float ini_doubleRoofEaveWidth;
	public float ini_doubleRoofTopWidth;
	public float ini_doubleRoofDownWidth;
	public float ini_doubleRoofHeight;
	public float ini_windowHeight;
	public float ini_wallWidth;

	public bool isBalustrade;
	public bool isFrieze;
	public bool isDoubleRoof;
	public bool isWall;
	public bool isMutiColumn;

	public float friezeHeight;
	public float balustradeHeight;
	public float doubleRoofEaveWidth;
	public float doubleRoofTopWidth;
	public float doubleRoofDownWidth;
	public float windowHeight;
	public float windowUp2TopDis;
	public float windowDown2ButtonDis;

	public float bodyHeightChange;
	// Use this for initialization

	void Start()
	{
		dragitemcontroller = GameObject.Find("DragItemController").GetComponent<DragItemController>();
		movement = GameObject.Find("Movement").GetComponent<Movement>();
		movement.verlist.AddRange(controlPointList);

		ini_bodydis.y = controlPointList[1].transform.position.y - controlPointList[2].transform.position.y;
		friezeHeight = ini_friezeHeight = 0.2f * ini_bodydis.y;
		balustradeHeight = ini_balustradeHeight = 0.2f * ini_bodydis.y;
		windowHeight = ini_windowHeight = 0.5f * ini_bodydis.y;
		ini_doubleRoofHeight = 0.4f * ini_bodydis.y;
		ini_doubleRoofEaveWidth = doubleRoofEaveWidth = 0.3f * ini_bodydis.y;


		columnIcon = new ColumnIcon();
		columnIcon.ColumnIconCreate(this, controlPointList[1], controlPointList[2], controlPointList[0], controlPointList[3], ini_bodydis.y, ini_friezeHeight, ini_balustradeHeight);

		ini_bodydis.x = bodydis.x = (columnIcon.rightColumn.upPoint.transform.position.x - columnIcon.leftColumn.upPoint.transform.position.x) / 2.0f;
		ini_wallWidth = wallWidth = ini_bodydis.x * 0.8f;

		movement.horlist.Add(columnIcon.leftColumn.bodyStruct.body);
		movement.horlist.Add(columnIcon.rightColumn.bodyStruct.body);

	}

	public void adjPos()
	{
		bodyHeightChange=0;
		Vector3 tmp = dragitemcontroller.chooseObj.transform.position;
		GameObject chooseObj = dragitemcontroller.chooseObj;
		if (chooseObj == columnIcon.rightColumn.upPoint || chooseObj == columnIcon.leftColumn.upPoint || chooseObj == columnIcon.rightColumn.downPoint || chooseObj == columnIcon.leftColumn.downPoint || chooseObj == columnIcon.rightColumn.bodyStruct.body || chooseObj == columnIcon.leftColumn.bodyStruct.body)//RU LU RD LD RBody LBody
		{
			Vector3 offset=columnIcon.AdjPos(tmp, chooseObj);

			bodydis = new Vector2(columnIcon.columnWidth / 2.0f, columnIcon.columnHeight);

			if (chooseObj == columnIcon.rightColumn.upPoint || chooseObj == columnIcon.leftColumn.upPoint)
			{
				bodyHeightChange = offset.y;
			}
			else if(chooseObj == columnIcon.rightColumn.downPoint || chooseObj == columnIcon.leftColumn.downPoint)
			{
				bodyHeightChange = -offset.y;
			}
		}
		if (isFrieze)
			if (chooseObj == columnIcon.rightColumn.friezePoint || chooseObj == columnIcon.leftColumn.friezePoint)
			{//frieze
				columnIcon.friezeIcon.AdjPos(tmp);

				friezeHeight = columnIcon.friezeIcon.friezeHeight;

				columnIcon.friezeIcon.AdjMesh(); ;

			}
		if (isBalustrade)
			if (chooseObj == columnIcon.rightColumn.balustradePoint || chooseObj == columnIcon.leftColumn.balustradePoint)
			{ //balustrade

				columnIcon.balustradeIcon.AdjPos(tmp);

				balustradeHeight = columnIcon.balustradeIcon.balustradeHeight;

				columnIcon.balustradeIcon.AdjMesh();

			}
		if (isDoubleRoof)
		{
			if (chooseObj == columnIcon.doubleRoofIcon.rightUpPoint)
			{
				columnIcon.doubleRoofIcon.AdjPos(tmp, chooseObj);
				columnIcon.doubleRoofIcon.AdjMesh();
				doubleRoofTopWidth = columnIcon.doubleRoofIcon.doubleRoofTopWidth / 2.0f;
			}
			else if (chooseObj == columnIcon.doubleRoofIcon.leftUpPoint)
			{
				columnIcon.doubleRoofIcon.AdjPos(tmp, chooseObj);
				columnIcon.doubleRoofIcon.AdjMesh();
				doubleRoofTopWidth = columnIcon.doubleRoofIcon.doubleRoofTopWidth / 2.0f;
			}
			else if (chooseObj == columnIcon.doubleRoofIcon.rightDownPoint)
			{
				columnIcon.doubleRoofIcon.AdjPos(tmp, chooseObj);
				columnIcon.doubleRoofIcon.AdjMesh();
				doubleRoofEaveWidth=columnIcon.doubleRoofIcon.doubleRoofEaveWidth;
				doubleRoofDownWidth = doubleRoofEaveWidth + columnIcon.columnWidth / 2.0f;
			}
			else if (chooseObj == columnIcon.doubleRoofIcon.leftDownPoint)
			{
				columnIcon.doubleRoofIcon.AdjPos(tmp, chooseObj);
				columnIcon.doubleRoofIcon.AdjMesh();

				doubleRoofEaveWidth = columnIcon.doubleRoofIcon.doubleRoofEaveWidth;
				doubleRoofDownWidth = doubleRoofEaveWidth + columnIcon.columnWidth / 2.0f;
			}
		}
		if (isWall)
		{
			if (chooseObj == columnIcon.wallIcon.rightUpPoint)
			{
				columnIcon.wallIcon.AdjPos(tmp, chooseObj);
				columnIcon.wallIcon.AdjMesh();
				wallWidth = columnIcon.wallIcon.wallWidth / 2.0f;

			}
			else if (chooseObj == columnIcon.wallIcon.leftUpPoint)
			{

				columnIcon.wallIcon.AdjPos(tmp, chooseObj);

				columnIcon.wallIcon.AdjMesh();
				wallWidth = columnIcon.wallIcon.wallWidth / 2.0f;
			}
			else if (chooseObj == columnIcon.wallIcon.rightDownPoint)
			{

				columnIcon.wallIcon.AdjPos(tmp, chooseObj);

				columnIcon.wallIcon.AdjMesh();
				wallWidth = columnIcon.wallIcon.wallWidth / 2.0f;

			}
			else if (chooseObj == columnIcon.wallIcon.leftDownPoint)
			{
				columnIcon.wallIcon.AdjPos(tmp, chooseObj);

				columnIcon.wallIcon.AdjMesh();
				wallWidth = columnIcon.wallIcon.wallWidth / 2.0f;
			}
			else if (chooseObj == columnIcon.wallIcon.rightUpWindowPoint)
			{

				columnIcon.wallIcon.AdjPos(tmp, chooseObj);
				columnIcon.wallIcon.AdjMesh();
				windowHeight = columnIcon.wallIcon.windowHeight / 2.0f;

				windowUp2TopDis = columnIcon.wallIcon.rightUpPoint.transform.position.y - columnIcon.wallIcon.rightUpWindowPoint.transform.position.y;
			}
			else if (chooseObj == columnIcon.wallIcon.leftUpWindowPoint)
			{
				columnIcon.wallIcon.AdjPos(tmp, chooseObj);
				columnIcon.wallIcon.AdjMesh();
				windowHeight = columnIcon.wallIcon.windowHeight / 2.0f;

				windowUp2TopDis = columnIcon.wallIcon.rightUpPoint.transform.position.y - columnIcon.wallIcon.rightUpWindowPoint.transform.position.y;
			}
			else if (chooseObj == columnIcon.wallIcon.rightDownWindowPoint)
			{

				columnIcon.wallIcon.AdjPos(tmp, chooseObj);
				columnIcon.wallIcon.AdjMesh();
				windowHeight = columnIcon.wallIcon.windowHeight / 2.0f;

				windowDown2ButtonDis = columnIcon.wallIcon.rightDownWindowPoint.transform.position.y - columnIcon.wallIcon.rightDownPoint.transform.position.y;
			}
			else if (chooseObj == columnIcon.wallIcon.leftDownWindowPoint)
			{

				columnIcon.wallIcon.AdjPos(tmp, chooseObj);
				columnIcon.wallIcon.AdjMesh();
				windowHeight = columnIcon.wallIcon.windowHeight / 2.0f;

				windowDown2ButtonDis = columnIcon.wallIcon.rightDownWindowPoint.transform.position.y - columnIcon.wallIcon.rightDownPoint.transform.position.y;
			}
		}
		//transform.CenterOnChildred();
	}
	public void DestroyFunction(string objName)
	{
		switch (objName)
		{
			case "Frieze":
				isFrieze = false;
				columnIcon.friezeIcon = null;
				
				controlPointList.Remove(columnIcon.rightColumn.friezePoint);
				controlPointList.Remove(columnIcon.leftColumn.friezePoint);
				columnIcon.controlPointList.Remove(columnIcon.rightColumn.friezePoint);
				columnIcon.controlPointList.Remove(columnIcon.leftColumn.friezePoint);

				break;
			case "Balustrade":
				isBalustrade = false;
				columnIcon.balustradeIcon = null;

				controlPointList.Remove(columnIcon.rightColumn.balustradePoint);
				controlPointList.Remove(columnIcon.leftColumn.balustradePoint);
				columnIcon.controlPointList.Remove(columnIcon.rightColumn.balustradePoint);
				columnIcon.controlPointList.Remove(columnIcon.leftColumn.balustradePoint);
				break;
			case "DoubleRoof":
				isDoubleRoof = false;
				columnIcon.doubleRoofIcon = null;
				break;
			case "Wall":
				isWall = false;
				windowUp2TopDis = 0;
				columnIcon.wallIcon = null;
				break;
			case "MutiColumn":
				isMutiColumn = false;
				columnIcon.mutiColumnIcon = null;
				break;
		}
	}
	public void UpdateFunction(string objName, GameObject correspondingDragItemObject)
	{
		switch (objName)
		{
			case "Frieze":
				if (columnIcon.friezeIcon == null)
				{
					isFrieze = true;

					columnIcon.CreateFrieze(this, "FriezeIcon", ini_friezeHeight, correspondingDragItemObject);

					controlPointList.Add(columnIcon.rightColumn.friezePoint);
					controlPointList.Add(columnIcon.leftColumn.friezePoint);

					/*movement.verlist.Add(columnIcon.rightColumn.friezePoint);
					movement.verlist.Add(columnIcon.leftColumn.friezePoint);*/
				}
				break;
			case "Balustrade":
				if (columnIcon.balustradeIcon == null)
				{
					isBalustrade = true;
					columnIcon.CreateBlustrade(this, "BlustradeIcon", ini_balustradeHeight, correspondingDragItemObject);

					controlPointList.Add(columnIcon.rightColumn.balustradePoint);
					controlPointList.Add(columnIcon.leftColumn.balustradePoint);

					/*movement.verlist.Add(columnIcon.rightColumn.balustradePoint);
					movement.verlist.Add(columnIcon.leftColumn.balustradePoint);*/
				}
				break;
			case "DoubleRoof":
				if (columnIcon.doubleRoofIcon == null)
				{
					isDoubleRoof = true;

					columnIcon.CreateDoubleRoof(this, "DoubleRoofIcon", ini_doubleRoofHeight, ini_doubleRoofEaveWidth, correspondingDragItemObject);

					ini_doubleRoofTopWidth = doubleRoofTopWidth = columnIcon.doubleRoofIcon.doubleRoofTopWidth / 2.0f;
					ini_doubleRoofDownWidth = doubleRoofDownWidth = ini_doubleRoofEaveWidth + columnIcon.columnWidth/2.0f;
				}
				break;
			case "Wall":
				if (columnIcon.wallIcon == null)
				{
					isWall = true;
					ini_wallWidth = wallWidth = columnIcon.columnWidth / 2.0f * 0.9f;
					columnIcon.CreateWall(this, "WallIcon", ini_wallWidth, ini_windowHeight, correspondingDragItemObject);

					/*	movement.horlist.Add(columnIcon.wallIcon.rightDownPoint);
						movement.horlist.Add(columnIcon.wallIcon.rightUpPoint);
						movement.horlist.Add(columnIcon.wallIcon.leftDownPoint);
						movement.horlist.Add(columnIcon.wallIcon.leftUpPoint);*/


					windowUp2TopDis = columnIcon.wallIcon.rightUpPoint.transform.position.y - columnIcon.wallIcon.rightUpWindowPoint.transform.position.y;
					windowDown2ButtonDis = columnIcon.wallIcon.rightDownWindowPoint.transform.position.y - columnIcon.wallIcon.rightDownPoint.transform.position.y;

				}
				break;
			case "MutiColumn":
				if (columnIcon.mutiColumnIcon == null)
				{
					isMutiColumn = true;

					columnIcon.CreateMutiColumn(this, "MutiColumnIcon", correspondingDragItemObject);

				}
				break;

		}
		transform.CenterOnChildred();
	}
	public void addpoint()
	{
		controlPointList.RemoveAll(GameObject => GameObject == null);
		movement.verlist.AddRange(controlPointList);
		movement.horlist.Add(columnIcon.rightColumn.bodyStruct.body);
		movement.horlist.Add(columnIcon.leftColumn.bodyStruct.body);
		if (isWall)
		{
			movement.horlist.Add(columnIcon.wallIcon.rightDownPoint);
			movement.horlist.Add(columnIcon.wallIcon.rightUpPoint);
			movement.horlist.Add(columnIcon.wallIcon.leftDownPoint);
			movement.horlist.Add(columnIcon.wallIcon.leftUpPoint);

			movement.verlist.Add(columnIcon.wallIcon.rightDownWindowPoint);
			movement.verlist.Add(columnIcon.wallIcon.rightUpWindowPoint);
			movement.verlist.Add(columnIcon.wallIcon.leftDownWindowPoint);
			movement.verlist.Add(columnIcon.wallIcon.leftUpWindowPoint);
		}
		if (isDoubleRoof)
		{
			movement.horlist.Add(columnIcon.doubleRoofIcon.rightUpPoint);
			movement.horlist.Add(columnIcon.doubleRoofIcon.leftUpPoint);
			movement.horlist.Add(columnIcon.doubleRoofIcon.rightDownPoint);
			movement.horlist.Add(columnIcon.doubleRoofIcon.leftDownPoint);
		}
	}
	public Vector3 ClampPos(Vector3 inputPos)
	{
		GameObject chooseObj = dragitemcontroller.chooseObj;
		if (columnIcon.wallIcon != null)
		{
			foreach (GameObject controlPoint in columnIcon.wallIcon.controlPointList)
			{
				if (chooseObj == controlPoint)
					return columnIcon.wallIcon.ClampPos(inputPos, chooseObj);
			}
		}
		if (columnIcon.doubleRoofIcon != null)
		{
			foreach (GameObject controlPoint in columnIcon.doubleRoofIcon.controlPointList)
			{
				if (chooseObj == controlPoint)
					return columnIcon.doubleRoofIcon.ClampPos(inputPos, chooseObj);
			}
		}
		foreach (GameObject controlPoint in columnIcon.controlPointList)
		{
			if (chooseObj == controlPoint)
				return columnIcon.ClampPos(inputPos, chooseObj);
		}
		return inputPos;
	}
	public void IconUpdate()
	{
		columnIcon.InitIconMenuButtonUpdate();
	}

}