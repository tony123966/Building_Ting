using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public Transform target;
	public float smoothing = 5f;
	void Update()
	{
		if(target==null)return;
		Vector3 targetCamPos = new Vector3(target.position.x, target.position.y, transform.position.z);
		transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
	}
}
