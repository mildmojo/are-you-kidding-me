using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	
	private LevelBuilder levelBuilder;
	
	[HideInInspector]
	public GameObject ball;
	
	[HideInInspector]
	public GameObject exit;
	
	private const float CAMERA_ANGLE    = 35f;
	private const float DISTANCE_FACTOR = 1.3f;
	private const float MIN_DISTANCE    = 30f;
	private const float MAX_DISTANCE    = Mathf.Infinity;
	
	void Start () {
		if (QualitySettings.GetQualityLevel() < 2) {
			this.camera.GetComponent<DepthOfFieldScatter>().enabled = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (ball && exit) {
			// Find ray from ball to exit
			// Find midpoint of ray
			// Find camera angle between midpoint and XZ plane
			// Find camera distance based on ray magnitude
			// Move camera to angle + distance
			// Point camera at midpoint
			Vector3 ball_pos = ball.transform.position;
			Vector3 exit_pos = exit.transform.position;
			Vector3 ball_to_exit = exit_pos - ball_pos;
			Vector3 midpoint = ball_to_exit * 0.5f;
			Vector3 camera_angle = Quaternion.AngleAxis(CAMERA_ANGLE, midpoint) * Vector3.up;
			Vector3 camera_up = Quaternion.AngleAxis(CAMERA_ANGLE - 90, midpoint) * Vector3.up;
			float camera_distance = ball_to_exit.magnitude * DISTANCE_FACTOR;
			camera_distance = Mathf.Clamp(camera_distance, MIN_DISTANCE, MAX_DISTANCE);
//			Debug.Log ("Camera distance: " + camera_distance);
			Vector3 new_camera_pos = ball_pos + midpoint + camera_angle * camera_distance;
//			Debug.Log (ball_pos.x + ", " + ball_pos.y + ", " + ball_pos.z);
//			Debug.DrawRay(ball_pos + midpoint, camera_angle * camera_distance, Color.grey);
//			Debug.DrawRay(camera_pos, camera_up, Color.blue);
			Camera.mainCamera.transform.position = new_camera_pos;
			Camera.mainCamera.transform.LookAt(ball_pos + midpoint, Vector3.up);
		}
	}
}
