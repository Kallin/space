using UnityEngine;
using System.Collections;

[AddComponentMenu("Camera-Control/Mouse Look")]
public class SpaceMouseLook : MonoBehaviour {

	public float sensitivityX = 15F;
	public float sensitivityY = 15F;
	float velocity = 0;
	private static float maxVelocity = 50.0f;
	private static float maxAcceleration = 25.0f; // max change in velocity/second

	void Update ()
	{
		float rotationX = Input.GetAxis ("Mouse X") * sensitivityX;
		float rotationY = Input.GetAxis ("Mouse Y") * sensitivityY;
			
		transform.Rotate (rotationY, rotationX, 0.0f);
		
		float throttle = Input.GetAxis ("Vertical");
		
		// calculate desired acceleration
		// let's say if throttle is 'open' (1), then we desire max acceleration. 
		//float acceleration = throttle * maxAcceleration * Time.deltaTime;
		
		velocity += throttle ;
		
		if (velocity > maxVelocity)
			velocity = maxVelocity;
		if (velocity < maxVelocity * -1)
			velocity = maxVelocity * -1;
		
		//transform.position
		
		transform.Translate (Vector3.forward * velocity * Time.deltaTime);
		
		
		
		
	}
	
	void Start ()
	{
		transform.localEulerAngles = new Vector3 (0, 0, 0);
	}

}