using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	
	private Vector3 ball_pos;
	private Vector3 exit_pos;

	// Use this for initialization
	void Start () {
		ball_pos = GameObject.Find("Ball").transform.position;
		exit_pos = GameObject.Find("Exit").transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 ball_to_exit = exit_pos - ball_pos;
		//Vector3 midpoint = 
		// Find ray from ball to exit
		// Find midpoint of ray
		// Find camera angle between midpoint and XZ plane
		// Find camera distance based on ray magnitude
		// Move camera to angle + distance
		// Point camera at midpoint

		
		//this.gameObject.transform.rotation.SetLookRotation();
		
		
	}
}
