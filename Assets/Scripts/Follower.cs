using UnityEngine;
using System.Collections;

public class Follower : MonoBehaviour {
	
	public GameObject target;
	
	void Update () {
		Vector3 lineToTarget = target.transform.position - transform.position;
		Quaternion targetRotation = Quaternion.LookRotation (lineToTarget);
		float strength = 2.5f;
   		float str = Mathf.Min (strength * Time.deltaTime, 1);
   		
		transform.rotation = Quaternion.Lerp (transform.rotation, targetRotation, str);
		transform.Translate (Vector3.forward * 20 * Time.deltaTime);
	}
}
