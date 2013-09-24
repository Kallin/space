using UnityEngine;
using System.Collections;

public class DiamondFollower : MonoBehaviour {
	
	private Vector3[] points;
	private int currentTarget = 0;
	
	// Use this for initialization
	void Start () {
		Vector3 currentPosition = transform.position;
		Vector3 vertex1 = currentPosition + Vector3.up * 100;
		Vector3 vertex2 = currentPosition + Vector3.forward * 50;
		Vector3 vertex3 = currentPosition + Vector3.back * 50;
		Vector3 vertex4 = currentPosition + Vector3.down * 50;
		
		points = new Vector3[4];
		points[0]=vertex1;
		points[1]=vertex2;
		points[2]=vertex4;
		points[3]=vertex3;
	}
	
	// Update is called once per frame
	void Update () {
		
		Vector3 target = points[currentTarget];
		Vector3 lineToTarget = target - transform.position;
		Quaternion targetRotation = Quaternion.LookRotation (lineToTarget);
		float strength = 2.5f;
   		float str = Mathf.Min (strength * Time.deltaTime, 1);
   		
		transform.rotation = Quaternion.Lerp (transform.rotation, targetRotation, str);
		transform.Translate (Vector3.forward * 20 * Time.deltaTime);
		
		float dist = Vector3.Distance (transform.position, target);
		if (dist < 5){
			//we've reached our target, onto the next
			currentTarget++;
			if (currentTarget == points.Length - 1)
				currentTarget=0;
		}
		
		Debug.DrawRay(transform.position,points[0] - transform.position, Color.red); 
		Debug.DrawRay(transform.position,points[1] - transform.position, Color.red); 
		Debug.DrawRay(transform.position,points[2] - transform.position, Color.red); 
		Debug.DrawRay(transform.position,points[3] - transform.position, Color.red); 
	}
}
