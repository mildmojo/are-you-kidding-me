using UnityEngine;
using System.Collections;

public class LevelReader : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (this.guiText.text == "Level") {
			int level = LevelBuilder.instance.getCurrentLevel();
			string name = LevelBuilder.instance.getLevelName(level);
			this.guiText.text = "Level " + (level + 1) + ": " + name;
		}
	}
}
