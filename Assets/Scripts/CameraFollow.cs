using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

/*
	public Transform target;
	public float smoothing = 1f;
	void Update()
	{
		if(target==null)return;
		Vector3 targetCamPos = new Vector3(target.position.x, target.position.y, transform.position.z);

		//Transform parent= transform.parent;
		//transform.parent=null;
		transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
		//transform.parent=parent;
	}*/

	public GameObject target;
	[SerializeField]
	Transform[] targets;

	[SerializeField]
	float boundingBoxPadding = 10f;

	[SerializeField]
	float minimumOrthographicSize = 0.2f;

	[SerializeField]
	float zoomSpeed = 20f;

	[SerializeField]
	float zoomScale = 50f;

	Camera camera;
	public void SetTarget(Transform target) 
	{
		this.target=target.gameObject;
		 targets = target.GetComponentsInChildren<Transform>() as Transform[];
	}
	void Awake()
	{
		camera = GetComponent<Camera>();
		camera.orthographic = true;
	}

	void LateUpdate()
	{
		if (target!=null)
		{
			SetTarget(target.transform);

			Rect boundingBox = CalculateTargetsBoundingBox();
			Debug.Log("boundingBox" + boundingBox);
			Debug.Log("camera.OrthographicBounds()" + camera.OrthographicBounds());
			transform.position = CalculateCameraPosition(boundingBox);
			camera.orthographicSize = CalculateOrthographicSize(boundingBox);
		}
	}

	/// <summary>
	/// Calculates a bounding box that contains all the targets.
	/// </summary>
	/// <returns>A Rect containing all the targets.</returns>
	Rect CalculateTargetsBoundingBox()
	{
		float minX = Mathf.Infinity;
		float maxX = Mathf.NegativeInfinity;
		float minY = Mathf.Infinity;
		float maxY = Mathf.NegativeInfinity;

		foreach (Transform target in targets)
		{
			if (target.tag!="ControlPoint")continue;
			Vector3 position = target.position;
		
			minX = Mathf.Min(minX, position.x);
			minY = Mathf.Min(minY, position.y);
			maxX = Mathf.Max(maxX, position.x);
			maxY = Mathf.Max(maxY, position.y);
		}
		return Rect.MinMaxRect(minX - boundingBoxPadding, maxY + boundingBoxPadding, maxX + boundingBoxPadding, minY - boundingBoxPadding);
	}

	/// <summary>
	/// Calculates a camera position given the a bounding box containing all the targets.
	/// </summary>
	/// <param name="boundingBox">A Rect bounding box containg all targets.</param>
	/// <returns>A Vector3 in the center of the bounding box.</returns>
	Vector3 CalculateCameraPosition(Rect boundingBox)
	{
		Vector2 boundingBoxCenter = boundingBox.center;

		return new Vector3(boundingBoxCenter.x, boundingBoxCenter.y , camera.transform.position.z);
	}

	/// <summary>
	/// Calculates a new orthographic size for the camera based on the target bounding box.
	/// </summary>
	/// <param name="boundingBox">A Rect bounding box containg all targets.</param>
	/// <returns>A float for the orthographic size.</returns>
	float CalculateOrthographicSize(Rect boundingBox)
	{
		float orthographicSize = camera.orthographicSize;
		Vector3 topRight = new Vector3(boundingBox.x + boundingBox.width, boundingBox.y, 0f);
		Vector3 topRightAsViewport = camera.WorldToViewportPoint(topRight);


		if (topRightAsViewport.x >= topRightAsViewport.y)
			orthographicSize = (Mathf.Abs(boundingBox.width) / camera.aspect / 2f) / zoomScale;
		else
			orthographicSize = (Mathf.Abs(boundingBox.height)  / 2f) / zoomScale;

		return Mathf.Clamp(Mathf.Lerp(camera.orthographicSize, orthographicSize, Time.deltaTime * zoomSpeed), minimumOrthographicSize, Mathf.Infinity);
	}
}
