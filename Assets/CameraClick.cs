using UnityEngine;
using System.Collections;

public class CameraClick : MonoBehaviour {
	
	public GameObject Fire;
	RaycastHit hit;
	int layerMask;
	public AudioClip Heartbeat;	
	
	private bool soundKeyDown;
	
	private const KeyCode SOUND_TOGGLE_KEY = KeyCode.S;
	
	// Use this for initialization
	void Start () {		
		
	}
	
	// Update is called once per frame
	void Update () {
		if (soundKeyDown) {
			soundKeyDown = Input.GetKeyDown(SOUND_TOGGLE_KEY);
		} else if (soundKeyDown = Input.GetKeyDown(KeyCode.S)) {
			AudioListener listener = GetComponent<AudioListener>();
			listener.enabled = !listener.enabled;
		}
			
		if (Input.GetMouseButtonDown(0)) {
			layerMask = 1 << LayerMask.NameToLayer("Pillar");
			if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity, layerMask)) {
				if (hit.collider.gameObject.tag == "Pillar") {
					GameObject pillar = hit.collider.gameObject;
					GameObject newFire = (GameObject) GameObject.Instantiate(Fire, new Vector3(pillar.transform.position.x, -7, pillar.transform.position.z), pillar.transform.rotation);
					newFire.transform.Rotate(-90,0,0);
					audio.PlayOneShot(Heartbeat);
				}
				Debug.Log("Hit on " + hit.collider.gameObject.name);
			}
			Debug.Log("clicked");
		}
		if (Input.GetKeyDown("escape")) {
			Application.Quit();
		}
	}
	
	void OnMouseDown() {
		
	}
}
