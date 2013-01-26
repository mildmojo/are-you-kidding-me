using UnityEngine;
using System.Collections;

public class Popup : MonoBehaviour {
	
	private int popupForce; 
	private int falloffDistance;
	
	public GameObject Fire; 
	// Use this for initialization
	void Awake () {	
		popupForce = 1000;
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
		Vector3 test_ray;
		LayerMask layerMask;
		
		// Don't collide with other pillars.
		if (other.gameObject.tag == "Pillar") {			
			Debug.Log("Hit pillar?");
			return;
		}
		
		// Don't propagate through walls.
		//if (wallBetween(other.transform.position, this.rigidbody.position)) {
		//	return;
		//}
		
		// Pillar movement looks better if wave force only acts on resting or rising pillars.
		if (this.rigidbody.velocity.z < 0) {
			this.rigidbody.velocity = Vector3.zero;
		}

		//float distance = Vector3.Distance(this.transform.position, other.transform.position);
		//this.gameObject.rigidbody.AddForce(Vector3.up.normalized * (popupForce * (falloffDistance - distance)/falloffDistance ));
		this.rigidbody.AddForce(Vector3.up.normalized * popupForce);
	}

	
	void OnMouseDown() {		
		GameObject newFire = (GameObject) GameObject.Instantiate(Fire, new Vector3(transform.position.x, -7, transform.position.z), transform.rotation);
		newFire.transform.Rotate(-90,0,0);

	}
	
	Vector3 xzPlane(Vector3 vector) {
		return new Vector3(vector.x, 0, vector.y);
	}

	bool wallBetween(Vector3 vect1, Vector3 vect2) {
		Vector3 test_ray = xzPlane(vect2) - xzPlane(vect1);
		int layerMask = LayerMask.NameToLayer("Wall");
		return Physics.Raycast(vect1, test_ray, test_ray.sqrMagnitude, layerMask);
	}

}
