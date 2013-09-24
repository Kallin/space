using UnityEngine;
using System.Collections;

public class DumbMover : MonoBehaviour {
	
	private Vector3 targetPoint;
	private bool turning = false;
	private static float pathDistance = 15;
	private Quaternion targetRotation;
	
	private const int PATH_DISTANCE = 100;

	void Start ()
	{
		targetPoint = transform.position + transform.forward * PATH_DISTANCE;
		targetRotation = transform.rotation * Quaternion.AngleAxis( 180, transform.up );
	}
	
	void Update ()
	{		
		if (turning) {
			TurnAround();
		} else {
			MoveForward();	
		}
	}
	
	private void MoveForward(){
	float dist = Vector3.Distance (transform.position, targetPoint);
			if (dist < 5) {	
				turning = true;
				TurnAround();
			} else {
				transform.Translate (new Vector3 (0, 0, 10 * Time.deltaTime));
			}
		
		Debug.Log(targetPoint);
	}
	
	private void TurnAround (){
		// rotate around ship's y-axis until it's facing near-opposite from original vector
		transform.Rotate(Vector3.up * Time.deltaTime * 100);
		
		Quaternion currentRotation = transform.rotation;
		
		if (Quaternion.Angle(targetRotation, currentRotation) <= 2){
			transform.rotation = targetRotation;	
			targetRotation = targetRotation * Quaternion.AngleAxis( 180, transform.up );
			
			targetPoint = targetPoint + transform.forward * PATH_DISTANCE;
		
			turning = false;
		}
	}
}
