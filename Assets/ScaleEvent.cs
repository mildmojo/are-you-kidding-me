using UnityEngine;
using System.Collections;

public class ScaleEvent : MonoBehaviour {
	
	private float propogationSpeed;
	private float dieAtSize;

	// Use this for initialization
	void Start () {
		dieAtSize = 1000;
		propogationSpeed = 50.0f;
	
	}
	
	// Update is called once per frame
	void Update () {
		this.gameObject.transform.localScale += new Vector3(propogationSpeed * Time.deltaTime,0,propogationSpeed * Time.deltaTime);
		if (this.gameObject.transform.localScale.x > dieAtSize)
			Destroy(this.gameObject);
	
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
