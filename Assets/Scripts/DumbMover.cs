using UnityEngine;
using System.Collections;

public class DumbMover : MonoBehaviour {
	
	Vector3 pointA;
	Vector3 pointB;
	bool turning = false;
	
	void Start ()
	{
		pointA = transform.position;
		pointB = pointA + new Vector3 (0, 0, 100);
		
	}
	
	void Update ()
	{
		
		if (turning) {
			
		} else {
			float dist = Vector3.Distance (transform.position, pointB);
			if (dist < 5) {
				turning = true;
				TurnAround();
				//turnaround	
			} else {
				transform.Translate (new Vector3 (0, 0, 10 * Time.deltaTime));
			}
			
		}
		
		
	}
	
	private void TurnAround (){
	}
}
