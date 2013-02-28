using UnityEngine;
using System.Collections;

public class CameraClick : MonoBehaviour {

	public GameObject Fire;
	public GameObject Fire2;

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

		if (Input.GetKeyDown(KeyCode.R)) {
			Application.LoadLevel(Application.loadedLevel);
		}

		if (Input.GetKeyDown(KeyCode.N)) {
			if (Application.loadedLevelName == "Scene1") {
				LevelBuilder.instance.goToNextLevel();
			} else {
				Application.LoadLevel(Application.loadedLevel + 1);
			}
		}

		if (Input.GetMouseButtonDown(0)) {
			int pillarLayer = LayerMask.NameToLayer("Pillar");
			int pillar2Layer = LayerMask.NameToLayer("Pillar2");
			layerMask = 1 << pillarLayer;
			layerMask += 1 << pillar2Layer;
			if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity, layerMask)) {
				if (hit.collider.gameObject.tag == "Pillar") {
					//LevelBuilder.instance.startTimers();
					GameObject pillar = hit.collider.gameObject;
					GameObject newFire = hit.collider.gameObject.layer == pillarLayer ? Fire : Fire2;
					newFire = (GameObject) GameObject.Instantiate(newFire, new Vector3(pillar.transform.position.x, -7, pillar.transform.position.z), pillar.transform.rotation);
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
