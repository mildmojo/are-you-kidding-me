using UnityEngine;
using System.Collections;

public class LevelReader : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (this.guiText.text == "Level") {
			int level = LevelBuilder.instance.getCurrentLevel() + 1;
			string name = LevelBuilder.instance.getLevelName(level);
			this.guiText.text = "Level " + level + ": " + name;
		}
	}
}
