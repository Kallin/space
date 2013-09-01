using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Debugger : MonoBehaviour {
	
	private bool isEnabled = false;
	private static UnityEngine.KeyCode debugKey = UnityEngine.KeyCode.F10;
	HashSet<UnityEngine.KeyCode> pressedKeys = new HashSet<UnityEngine.KeyCode> ();
	
	void Awake ()
	{
		// Make the game run as fast as possible
		Application.targetFrameRate = -1;
	}

	void OnGUI ()
	{
		UpdateDebugEnabledStatus ();
		UpdatedPressedKeys ();
	
		if (isEnabled) {
			GUI.Label (new Rect (25, 35, 200, 20), "runtime: " + Time.realtimeSinceStartup.ToString ("F1"));			
			GUI.Label (new Rect (25, 55, 200, 20), "smoothed fps: " + (1 / Time.smoothDeltaTime).ToString ("F1"));			
			
			string keyString = "";
			foreach (KeyCode enumType in pressedKeys) {
				keyString += enumType + ", ";
			}
			GUI.Label (new Rect (25, 75, 1000, 20), "pressed keys: " + keyString);			
			
			GUI.Label (new Rect (25, 95, 1000, 20), "mouse x: " + Input.GetAxis("Mouse X"));			
			GUI.Label (new Rect (25, 115, 1000, 20), "mouse y: " + Input.GetAxis("Mouse Y"));			
			
			GUI.Label (new Rect (25, 135, 1000, 20), "Vertical: " + Input.GetAxis("Vertical"));			
			GUI.Label (new Rect (25, 155, 1000, 20), "Hortizontal: " + Input.GetAxis("Horizontal"));			

		}
	}
	
	void UpdateDebugEnabledStatus ()
	{
		if (Event.current.type == EventType.KeyUp) {
			Event e = Event.current;
			if (e.keyCode == debugKey) {
				isEnabled = !isEnabled;
			}
		}
	}
	
	void UpdatedPressedKeys ()
	{
		Event currentEvent = Event.current;
		if (currentEvent.type == EventType.KeyDown && currentEvent.keyCode != KeyCode.None) {
			pressedKeys.Add (currentEvent.keyCode);
		}
		if (currentEvent.type == EventType.KeyUp) {
			pressedKeys.Remove (currentEvent.keyCode);
		}
		
	}
}
