using UnityEngine;
using System.Collections;

public class Glow : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		this.gameObject.renderer.material.color = new Color(0,0,0);
	
	}
}
