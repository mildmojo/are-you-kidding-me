using UnityEngine;
using System.Collections;

public class Popup : MonoBehaviour {
	
	private int popupForce; 
	private int falloffDistance;
	
	public GameObject Fire; 
	// Use this for initialization
	void Awake () {	
		popupForce = 400;
		falloffDistance = 100;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	
	}
	
	/*void OnCollisionEnter(Collision other) {		
		Debug.Log("Collision occurred with " + other.gameObject.name);
		if (other.gameObject.name == "Sphere") {
		  Debug.Log ("pillar hit?");
		  this.gameObject.transform.rigidbody.AddForce(Vector3.up * 1000);
		}
	}
*/
	void OnTriggerEnter(Collider other) {		
		
		if (!(other.gameObject.tag == "Pillar")) {			
			float distance = Vector3.Distance(this.transform.position, other.transform.position);
			this.rigidbody.AddForce(Vector3.up.normalized * popupForce);
			//this.gameObject.rigidbody.AddForce(Vector3.up.normalized * (popupForce * (falloffDistance - distance)/falloffDistance ));
		} else {
			Debug.Log("Hit pillar?");
		}
	}

	
	void OnMouseDown() {		
		GameObject newFire = (GameObject) GameObject.Instantiate(Fire, new Vector3(transform.position.x, -7, transform.position.z), transform.rotation);
		newFire.transform.Rotate(-90,0,0);

	}
	
}
