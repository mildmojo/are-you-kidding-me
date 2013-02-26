using UnityEngine;
using System.Collections;

public class LevelReader : MonoBehaviour {

	// Use this for initialization
	void Start () {
		// NOTE: THIS CLEARS LEVEL TEXT, TOTAL HACK FOR VIDEO
		this.guiText.text = "";
	}

	// Update is called once per frame
	void Update () {
		if (LevelBuilder.instance != null) {
			if (this.guiText.text == "Level") {
				int level = LevelBuilder.instance.getCurrentLevel();
				string name = LevelBuilder.instance.getLevelName(level);
				this.guiText.text = "Level " + level + ": " + name;
			}
		}
	}
}
