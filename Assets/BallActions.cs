using UnityEngine;
using System.Collections;

public class BallActions : MonoBehaviour {
	
	LevelBuilder levelBuilder;
	public AudioClip flatline;
	
	// Use this for initialization
	void Start () {		
		levelBuilder = GameObject.Find("LevelBuilder").GetComponent<LevelBuilder>();			
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnCollisionEnter(Collision other) {
//		Debug.Log("collided with " + other.gameObject.name);
		if (other.gameObject.name == "Plane") {
			Debug.Log("Restart Level");
			audio.Play();
			Application.LoadLevel(Application.loadedLevel);
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
	
