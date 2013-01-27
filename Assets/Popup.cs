using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class Popup : MonoBehaviour {
	
	private int popupForce; 
	private int falloffDistance;
	public AudioClip heartBeat;
	
	public GameObject Fire; 
	
	private LevelBuilder levelBuilder;
	
	// Use this for initialization
	void Awake () {	
		popupForce = 400;
		falloffDistance = 100;
		levelBuilder = GameObject.Find("LevelBuilder").GetComponent<LevelBuilder>();
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
		if (this.rigidbody.velocity.y < 0) {
			this.rigidbody.velocity = Vector3.zero;
		}

		//float distance = Vector3.Distance(this.transform.position, other.transform.position);
		//this.gameObject.rigidbody.AddForce(Vector3.up.normalized * (popupForce * (falloffDistance - distance)/falloffDistance ));
		this.rigidbody.AddForce(Vector3.up.normalized * popupForce);
	}

	
	void OnMouseDown() {		
		//GameObject newFire = (GameObject) GameObject.Instantiate(Fire, new Vector3(transform.position.x, -7, transform.position.z), transform.rotation);
		//newFire.transform.Rotate(-90,0,0);
		//audio.PlayOneShot(heartBeat);
		

	}
	
	Vector3 vectAtElevation(Vector3 vector, float elevation) {
		return new Vector3(vector.x, elevation, vector.z);
	}

	bool wallBetween(Vector3 vect1, Vector3 vect2) {
		Debug.DrawRay(vect1, Vector3.up * 10f, Color.magenta, 3.0f);
		Debug.DrawRay(vect2, Vector3.up * 10f, Color.cyan, 3.0f);
			
		float wall_elev = LevelBuilder.WALL_ELEVATION - 3.75f;
		Vector3 origin = vectAtElevation(vect1, wall_elev);
		Vector3 dir = vectAtElevation(vect2, wall_elev) - origin;
		int layerMask = 1 << LayerMask.NameToLayer("Wall");
		
		RaycastHit my_hit;
		
		Debug.DrawRay(origin, dir, Color.blue, 3.0f);
		if (Physics.Raycast(origin, dir, out my_hit, dir.magnitude)) {
			Color color = my_hit.collider.gameObject.layer != 0 ? Color.red : Color.gray;
			Debug.DrawRay(my_hit.collider.gameObject.transform.position, Vector3.up * 10f, color, 3.0f);
			Debug.Log ("Layer: " + my_hit.collider.gameObject.layer);
		}
		
		return Physics.Raycast(origin, dir, dir.magnitude, layerMask);
	}

}
