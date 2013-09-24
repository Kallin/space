using UnityEngine;
using System.Collections;

[AddComponentMenu("Camera-Control/Mouse Look")]
public class SpaceMouseLook : MonoBehaviour {

	public float sensitivityX = 15F;
	public float sensitivityY = 15F;
	
	private static float maxVelocity = 50.0f;

	void Update ()
	{
		float rotationX = Input.GetAxis ("Mouse X") * sensitivityX;
		float rotationY = Input.GetAxis ("Mouse Y") * sensitivityY;

		transform.Rotate (rotationY, rotationX, 0.0f);
		
		float targetZVelocity = Input.GetAxis ("Vertical");
		float targetXVelocity = Input.GetAxis ("Horizontal");
				
		float zVelocity = targetZVelocity * maxVelocity ;
		float xVelocity = targetXVelocity * maxVelocity ;
		
		transform.Translate (Vector3.forward * zVelocity * Time.deltaTime);
		transform.Translate (Vector3.right * xVelocity * Time.deltaTime);
	}
	

}