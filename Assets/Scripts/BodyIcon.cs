using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class BodyIcon : MonoBehaviour
{

	public List<GameObject> controlPointList = new List<GameObject>();
	[HideInInspector]
	Mesh[] mesh;
	void Start()
	{
		mesh = new Mesh[2];
		SetMesh();

	}
	void SetMesh()
	{
		float width = (controlPointList[0].transform.position.x - transform.position.x)/2.0f;
		float height = (controlPointList[0].transform.position.y - transform.position.y);
		Vector3 offset=new Vector3(width*2,0,0);
		for (int i = 0; i < 2; i++)
		{
			GameObject TTL = new GameObject();
			TTL.transform.parent = transform;
			TTL.name = ("iconMesh");
			TTL.AddComponent<MeshFilter>();
			TTL.AddComponent<MeshRenderer>();
			TTL.GetComponent<MeshRenderer>().material = GetComponent<MeshRenderer>().material;
			mesh[i] = TTL.GetComponent<MeshFilter>().mesh;
			mesh[i].Clear();
			Vector3[] v = new Vector3[4];
			Vector3[] n = new Vector3[4];
			Vector2[] uv = new Vector2[4];
			int[] t = new int[6];
			
			Vector3 pos=controlPointList[0].transform.position;
			mesh[i].vertices = new Vector3[]
			{

				new Vector3(pos.x-width,transform.position.y-height,pos.z)+(-1)*i*offset,
				new Vector3(pos.x-width,pos.y,pos.z)+(-1)*i*offset,
				new Vector3(pos.x,transform.position.y-height,pos.z)+(-1)*i*offset,
				pos+(-1)*i*offset,
			};
			mesh[i].uv = new Vector2[]
			{
				new Vector2(0,0),
				new Vector2(0,1),
				new Vector2(1,0),
				new Vector2(1,1)
			};
			mesh[i].triangles = new int[] { 0, 1, 2, 3, 2, 1 };

			mesh[i].RecalculateBounds();
			mesh[i].RecalculateNormals();
		}
	}
}
