using UnityEngine;
using System.Collections;

public class Escape : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown("escape")) {
			Application.Quit();
		}
	}
}
