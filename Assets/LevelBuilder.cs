using UnityEngine;
using System.Collections;


public class LevelBuilder : MonoBehaviour {		
		
	public GameObject Pillar;
	public GameObject Exit;
	public GameObject Ball;
	public GameObject Wall;
	public GUIText text;
	
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
		if (currentLevel == 0) {
		  Debug.Log("Building because level zero actually is " + currentLevel);
		  BuildLevel();
		}
		
	}

	// Use this for initialization
	void OnLevelWasLoaded () {
		Debug.Log ("OnLevelLoaded sees currentLevel as " + currentLevel + " " + this.gameObject.GetInstanceID());
		BuildLevel();
	}
	
	void BuildLevel() {
		
		text.text = "Level " + (currentLevel + 1);
				
		Debug.Log ("Build Level was loaded current level is " + currentLevel + " " + this.gameObject.GetInstanceID());
	
		
		if (currentLevel == null )
			currentLevel = 0;
		
		allLevels = new ArrayList();
		
		/* 0 no square
		 * 1 regular
		 * 2 pointy
		 * 3 wall
		 * 4 superspring
		 * 8 Start
		 * 9 exit
		 */
		
		allLevels.Add ( new 
					int [,] {	{0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
								{0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
								{0,0,0,9,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
								{0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
								{0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
								{1,1,1,1,1,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
								{1,1,1,1,1,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
								{1,1,1,1,1,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
								{1,1,1,1,1,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1},	
								{1,1,1,1,1,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
								{1,1,1,1,1,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
								{1,1,1,1,1,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
								{1,1,1,1,1,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
								{1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
								{1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
								{1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
								{1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,8,1,1,1},
								{1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
								{1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},	
								{1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1}}	);	
		allLevels.Add ( new 
					int [,] {	{0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,3},
								{0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,3},
								{0,0,9,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,3},
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
								{1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,1,8,1,1,3},
								{1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,1,1,1,1,3},
								{1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,1,1,1,1,3},	
								{1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,1,1,1,1,3}}	);	
		allLevels.Add ( new 
					int [,] {	{0,0,0,0,0,3,1,1,1,1,1,1,1,1,1,1,1,1,1,3},
								{0,0,0,0,0,3,1,1,1,1,1,1,1,1,1,1,1,1,1,3},
								{0,0,9,0,0,3,1,1,1,1,1,1,1,1,1,1,1,1,1,3},
								{0,0,0,0,0,3,1,1,1,1,1,1,1,1,1,1,1,1,1,3},
								{0,0,0,0,0,3,1,1,1,1,1,1,1,1,1,1,1,1,1,3},
								{1,1,1,1,1,3,1,1,1,1,1,1,1,1,1,1,1,1,1,3},
								{1,1,1,1,1,3,1,1,1,1,1,1,1,0,0,1,1,1,1,3},
								{1,1,1,1,1,3,1,1,1,1,1,1,1,0,0,1,1,1,1,3},
								{1,1,1,1,1,3,1,1,1,1,1,1,1,0,0,1,1,1,1,3},	
								{1,1,1,1,1,3,1,1,1,1,1,1,1,0,0,1,1,1,1,3},
								{1,1,1,1,1,3,1,1,1,8,1,1,1,0,0,1,1,1,1,3},
								{1,1,1,1,1,3,1,1,1,1,1,1,1,0,0,1,1,1,1,3},
								{1,1,1,1,1,3,3,3,3,3,3,3,3,0,0,1,1,1,1,3},
								{1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,3},
								{1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,3},
								{1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,3},
								{1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,3},
								{1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,3},
								{1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,3},	
								{1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,3,3,3,3,3}}	);		
		allLevels.Add ( new 
					int [,] {	{0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,3},
								{0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,3},
								{0,0,9,0,0,1,1,1,1,1,1,1,1,8,1,1,1,1,1,3},
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
								{1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,1,8,1,1,3},
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
					GameObject newExit = (GameObject) GameObject.Instantiate(Exit, new Vector3(i, -10, j), Quaternion.identity);
					newExit.transform.Rotate(-90,0,0);
				} else if (level[i,j] == 3) {
					GameObject newWall = (GameObject) GameObject.Instantiate(Wall, new Vector3(i*2.1f, 0, j*2.1f), Quaternion.identity);
					newWall.transform.Rotate(-90,0,0);
				} else if (level[i,j] == 8) {
					GameObject newBall = (GameObject) GameObject.Instantiate(Ball, new Vector3(i*2.1f, 0, j*2.1f), Quaternion.identity);
					GameObject newPillar = (GameObject) GameObject.Instantiate(Pillar, new Vector3(i*2.1f, -10, j*2.1f), Quaternion.identity);
					newPillar.transform.Rotate(-90,0,0);
					
				}
			}
		}
	
	}
	
	public void incrementLevel() {
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
