using UnityEngine;
using System.Collections;

public class CameraClick : MonoBehaviour {
	
	public GameObject Fire;
	RaycastHit hit;
	public AudioClip heartbeat;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit)) {
				if (hit.collider.gameObject.tag == "Pillar") {
					GameObject pillar = hit.collider.gameObject;
					GameObject newFire = (GameObject) GameObject.Instantiate(Fire, new Vector3(pillar.transform.position.x, -7, pillar.transform.position.z), pillar.transform.rotation);
					newFire.transform.Rotate(-90,0,0);
					audio.PlayOneShot(heartbeat);
				}
				Debug.Log("Hit on " + hit.collider.gameObject.name);
			}
			Debug.Log("clicked");
		}
	}
	
	void OnMouseDown() {
		
	}
}
