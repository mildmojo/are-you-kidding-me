using UnityEngine;
using System.Collections;


public class LevelBuilder : MonoBehaviour {		
		
	public GameObject Pillar;
	public GameObject Exit;
	
	private IList allLevels;
	
	private int[,]level;	
	private int currentLevel;
	private int numLevels;
	
	private static bool created = false;
	
	void Awake() {
		if (!created) {
			Debug.Log ("Create new levelbuilder" + " " + this.gameObject.GetInstanceID());
			DontDestroyOnLoad(this.gameObject);
			created = true;
		}
		else {
			Debug.Log("Bad level builder, bad!" + " " + this.gameObject.GetInstanceID());
			DestroyImmediate(this.gameObject);
		}
			
	}
	
	void Start () {		
		Debug.Log ("Level Builder Start() from object " + this.gameObject.GetInstanceID());
		OnLevelWasLoaded();
	}
	
	
	// Use this for initialization
	void OnLevelWasLoaded () {
		BuildLevel();
	}
	
	void BuildLevel() {
				
		Debug.Log ("Build Level was loaded current level is " + currentLevel + " " + this.gameObject.GetInstanceID());
	
		
		allLevels = new ArrayList();
		
		allLevels.Add ( new 
					int [,] {	{0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,3},
								{0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,3},
								{0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,3},
								{0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,3},
								{0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,3},
								{1,1,1,1,1,0,1,1,1,1,1,1,1,1,1,1,1,1,1,3},
								{1,1,1,1,1,0,1,1,1,1,1,1,1,1,1,1,1,1,1,3},
								{1,1,1,1,1,0,1,1,1,1,1,1,1,1,1,1,1,1,1,3},
								{1,1,1,1,1,0,1,1,1,1,1,1,1,1,1,1,1,1,1,3},	
								{1,1,1,1,1,0,1,1,1,1,1,1,1,1,1,1,1,1,1,3},
								{1,1,1,1,1,0,1,1,1,1,1,1,1,1,1,1,1,1,1,3},
								{1,1,1,1,1,0,1,1,1,1,1,1,1,1,1,1,1,1,1,3},
								{1,1,1,1,1,0,1,1,1,1,1,1,1,1,1,1,1,1,1,3},
								{1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,3},
								{1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,3},
								{1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,3},
								{1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,3},
								{1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,3},
								{1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,3},	
								{1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,3}}	);	
		allLevels.Add ( new 
					int [,] {	{0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,3},
								{0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,3},
								{0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,3},
								{0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,3},
								{0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,3},
								{1,1,1,1,1,0,1,1,1,1,1,1,1,1,1,1,1,1,1,3},
								{1,1,1,1,1,0,1,1,1,1,1,1,1,0,0,1,1,1,1,3},
								{1,1,1,1,1,0,1,1,1,1,1,1,1,0,0,1,1,1,1,3},
								{1,1,1,1,1,0,1,1,1,1,1,1,1,0,0,1,1,1,1,3},	
								{1,1,1,1,1,0,1,1,1,1,1,1,1,0,0,1,1,1,1,3},
								{1,1,1,1,1,0,1,1,1,1,1,1,1,0,0,1,1,1,1,3},
								{1,1,1,1,1,0,1,1,1,1,1,1,1,0,0,1,1,1,1,3},
								{1,1,1,1,1,0,1,1,1,1,1,1,1,0,0,1,1,1,1,3},
								{1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,1,1,1,1,3},
								{1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,1,1,1,1,3},
								{1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,1,1,1,1,3},
								{1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,1,1,1,1,3},
								{1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,1,1,1,1,3},
								{1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,1,1,1,1,3},	
								{1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,1,1,1,1,3}}	);	
		allLevels.Add ( new 
					int [,] {	{0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,3},
								{0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,3},
								{0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,3},
								{0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,3},
								{0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,3},
								{1,1,1,1,1,0,1,1,1,1,1,1,1,1,1,1,1,1,1,3},
								{1,1,1,1,1,0,1,1,1,1,1,1,1,0,0,1,1,1,1,3},
								{1,1,1,1,1,0,1,1,1,1,1,1,1,0,0,1,1,1,1,3},
								{1,1,1,1,1,0,1,1,1,1,1,1,1,0,0,1,1,1,1,3},	
								{1,1,1,1,1,0,1,1,1,1,1,1,1,0,0,1,1,1,1,3},
								{1,1,1,1,1,0,1,1,1,1,1,1,1,0,0,1,1,1,1,3},
								{1,1,1,1,1,0,1,1,1,1,1,1,1,0,0,1,1,1,1,3},
								{1,1,1,1,1,0,1,1,1,1,1,1,1,0,0,1,1,1,1,3},
								{1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,1,1,1,1,3},
								{1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,1,1,1,1,3},
								{1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,1,1,1,1,3},
								{1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,1,1,1,1,3},
								{1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,1,1,1,1,3},
								{1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,1,1,1,1,3},	
								{1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,1,1,1,1,3}}	);		
	//	allLevels.Add(level1);
	
		
		
		
		numLevels = allLevels.Count;
		Debug.Log("Loading level " + currentLevel);
		// Check for game over
	//	if ((currentLevel + 1) > numLevels) {
	//		Debug.Log("Loading Credits.");
	//		Application.LoadLevel("Credits");
	//	}
			
		level = (int [,]) allLevels[currentLevel];
		for (int i = 0; i < 20;i++) {
			for (int j = 0; j < 20; j++) {		
				if (level[i,j] == 1) {					
					GameObject newPillar = (GameObject) GameObject.Instantiate(Pillar, new Vector3(i*2.1f, -10, j*2.1f), Quaternion.identity);
					newPillar.transform.Rotate(-90,0,0);
				} else if (level[i,j] == 9) {
					GameObject newExit = (GameObject) GameObject.Instantiate(Exit, new Vector3(i*2.1f, -10, j*2.1f), Quaternion.identity);
					newExit.transform.Rotate(-90,0,0);
				} else if (level[i,j] == 3) {
					// Create wall
				}
			}
		}
	
	}
	
	public void restartGame () {
		currentLevel = 0;
		reloadScene();
	}
	
	public void loadNextLevel () {
		Debug.Log ("loadNextLevel sees currentLevel as " + currentLevel + " " + this.gameObject.GetInstanceID());
		incrementLevel();
		reloadScene();
	}
	
	void reloadScene () {
		// Reset the scene
		Application.LoadLevel(Application.loadedLevel);
	}
	
	void incrementLevel() {
		this.currentLevel += 1;
		Debug.Log("Current Level is " + currentLevel + " " + this.gameObject.GetInstanceID());
	}
	public int getCurrentLevel() {
		return currentLevel;
	}
	// Update is called once per frame
	void Update () {
	
	}
}
