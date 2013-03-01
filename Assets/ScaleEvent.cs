using UnityEngine;
using System.Collections;

public class ScaleEvent : MonoBehaviour {

	[HideInInspector]
	public float? dieAtSize;

	private float propogationSpeed;

	// Use this for initialization
	void Start () {
		// LevelBuilder levelBuilder = GameObject.Find("LevelBuilder").GetComponent<LevelBuilder>();
		// if (levelBuilder.levelDimensions.x > levelBuilder.levelDimensions.z) {
		// 	dieAtSize = levelBuilder.levelDimensions.x;
		// } else {
		// 	dieAtSize = levelBuilder.levelDimensions.z;
		// }
		// Scale factor from world coordinates to localScale units.
		//dieAtSize *= 7f;
		if (!dieAtSize.HasValue) {
			dieAtSize = 1000;
		}
		propogationSpeed = 20.0f;

	}

	// Update is called once per frame
	void Update () {
		if (this.gameObject.transform.localScale.x > dieAtSize)
			Destroy(this.gameObject);
		this.gameObject.transform.localScale += new Vector3(propogationSpeed * Time.deltaTime,0,propogationSpeed * Time.deltaTime);
	}
	/*
	void OnCollisionEnter(Collision other) {
		if (other.gameObject.name == "Terrain") {
			Debug.Log("Restart Level");
		}
		Debug.Log ("what?");
		// this.gameObject.transform.localScale += new Vector3(10,10,10);
	}
	*/




}
