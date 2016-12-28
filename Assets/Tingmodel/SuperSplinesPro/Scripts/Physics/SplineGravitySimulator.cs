using UnityEngine;
using System.Collections;

//This class applies gravity towards a spline to rigidbodies that this script is attached to
[AddComponentMenu("SuperSplines/Animation/Gravity Animator")]
public class SplineGravitySimulator : MonoBehaviour
{
	public Spline spline;
	
	public float gravityConstant = 9.81f;
	
	public int iterations = 5;

    public static GameObject other;
    public Rigidbody rb = other.GetComponent<Rigidbody>();
	
	void Start( )
	{
		//Disable default gravity calculations
		rb.useGravity = false;
        
	}
	
	void FixedUpdate( ) 
	{
		if( rb == null || spline == null )
			return;
		
		Vector3 closestPointOnSpline = spline.GetPositionOnSpline( spline.GetClosestPointParam( rb.position, iterations ) ); 
		Vector3 shortestConnection = closestPointOnSpline - rb.position;
		
		//Calculate gravity force according to Newton's law of universal gravity
		Vector3 force = shortestConnection * Mathf.Pow( shortestConnection.magnitude, -3 ) * gravityConstant * rb.mass;
		
		rb.AddForce( force );
       
	}
}
