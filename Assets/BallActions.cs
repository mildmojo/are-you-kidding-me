using UnityEngine;
using System.Collections;

public class BallActions : MonoBehaviour {
	
	LevelBuilder levelBuilder;
	public AudioClip flatline;
	
	public const float FLOOR_ELEVATION = -5f;  // This should ultimately be a nicer number, but simply replicates the existing plane.
	// Use this for initialization
	void Start () {		
		levelBuilder = GameObject.Find("LevelBuilder").GetComponent<LevelBuilder>();			
	}
	
	// Update is called once per frame
	void Update () {
		if (this.gameObject.transform.position.y < FLOOR_ELEVATION) {
			Debug.Log("Restart Level");
			audio.Play();
			int dist_to_exit = (int) (transform.position - GameObject.Find("Exit").transform.position).magnitude;
			GA.instance.track("level_" + levelBuilder.getCurrentLevel().ToString() + "_death", "distance_from_exit", dist_to_exit);
			Application.LoadLevel(Application.loadedLevel);
		}
	
	}
	
	void OnCollisionEnter(Collision other) {
//		Debug.Log("collided with " + other.gameObject.name);
		if (other.gameObject.name == "Plane") {		
			// Currently abandoned.....delete after test.
		} else if (other.gameObject.name == "Exit(Clone)") {
			
		}
	}
	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Exit") {
			Debug.Log ("Level Complete");
			levelBuilder.goToNextLevel();
		}
	}
}
	
