using UnityEngine;
using System.Collections;

public class Debugger : MonoBehaviour {
	
	private bool isEnabled = false;
	private static UnityEngine.KeyCode debugKey = UnityEngine.KeyCode.F10;
	
	void Awake () {
		// Make the game run as fast as possible
		Application.targetFrameRate = -1;
	}

	void OnGUI ()
	{
		UpdateDebugEnabledStatus ();
	
		if (isEnabled) {
			GUI.Label (new Rect (25, 35, 200, 20), "runtime: " + Time.realtimeSinceStartup.ToString("F1"));			
			GUI.Label (new Rect (25, 55, 200, 20), "smoothed fps: " + (1/Time.smoothDeltaTime).ToString("F1"));			
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

	
	
}
