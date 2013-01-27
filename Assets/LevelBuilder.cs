using UnityEngine;
using System.Collections;


public class LevelBuilder : MonoBehaviour {		
		
	public GameObject Pillar;
	public GameObject Exit;
	public GameObject Ball;
	public GameObject Wall;
	public GameObject InvisibleWall;
	public GameObject WallTall;
	public GameObject Tube;
	public GUIText text;
	public ParticleSystem particles;
	public Light exitLight;

	public const float FIRE_ELEVATION = -7f;
	public const float BALL_ELEVATION = 0f;
	public const float PILLAR_ELEVATION = -10f;
	public const float WALL_ELEVATION = 0f;
	
	[HideInInspector]
	public Vector3 levelDimensions;
	
	private IList allLevels;
	
	private int[,]level;	
	private int currentLevel = 0;
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
		
	//	text.text = "Level " + (currentLevel + 1);
				
		Debug.Log ("Build Level was loaded current level is " + currentLevel + " " + this.gameObject.GetInstanceID());
	
		
		
		
		allLevels = new ArrayList();
		
		/* 0 no square
		 * 1 regular
		 * 2 pointy
		 * 3 wall
		 * 4 superspring
		 * 6 super wall
		 * 7 invisible wall
		 * 8 Start
		 * 9 exit
		 */	
		
		// 1
		allLevels.Add ( new 
					int [,] {	{0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,3,3,3,3,3},
								{0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,3},
								{0,0,0,9,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,3},
								{0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,3},
								{0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,3},
								{1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
								{1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
								{1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
								{1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},	
								{1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
								{1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
								{1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
								{1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
								{1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
								{1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
								{3,1,1,1,1,1,1,1,1,1,1,1,1,1,1,8,1,1,1,3},
								{3,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,3},
								{3,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,3},
								{3,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,3},	
								{3,3,3,3,3,1,1,1,1,1,1,1,1,1,1,3,3,3,3,3}}	);	
		//2
		allLevels.Add ( new 
					int [,] {	{0,0,0,0,0,3,1,1,1,1,1,1,1,1,3,3,3,3,3,3},
								{0,0,0,0,0,3,1,1,1,1,1,1,1,1,1,1,1,1,1,3},
								{0,0,9,0,0,3,1,1,1,1,1,1,1,1,1,1,1,1,1,3},
								{0,0,0,0,0,3,1,1,1,1,1,1,1,1,1,1,1,1,1,3},
								{0,0,0,0,0,3,1,1,1,1,1,1,1,1,1,1,1,1,1,3},
								{1,1,1,1,7,7,7,1,1,1,1,1,1,1,1,1,1,1,1,3},
								{1,1,1,1,7,7,7,1,1,1,1,1,1,7,1,1,1,1,1,3},
								{1,1,1,1,7,7,7,1,1,1,1,1,7,7,7,1,1,1,1,3},
								{1,1,1,1,7,7,7,1,1,1,1,1,7,7,7,1,1,1,1,3},	
								{1,1,1,1,7,7,7,1,1,1,1,1,7,7,7,1,1,1,1,3},
								{1,1,1,1,7,7,7,1,1,1,1,1,7,7,7,1,1,1,1,3},
								{1,1,1,1,7,7,7,1,1,1,1,1,7,7,7,1,1,1,1,3},
								{1,1,1,1,7,7,7,1,1,1,1,1,7,7,7,1,1,1,1,3},
								{1,1,1,1,1,7,1,1,1,1,1,1,7,7,1,1,1,1,1,3},
								{1,1,1,1,1,1,1,1,1,1,1,1,7,1,1,1,1,1,1,3},
								{1,1,1,1,1,1,1,1,1,1,1,1,7,1,1,8,1,1,1,3},
								{1,1,1,1,1,1,1,1,1,1,1,1,7,1,1,1,1,1,1,3},
								{3,1,1,1,1,1,1,1,1,1,1,1,7,1,1,1,1,1,1,3},
								{3,1,1,1,1,1,1,1,1,1,1,1,7,7,7,1,1,1,1,3},	
								{3,3,3,1,1,3,3,3,3,3,3,3,0,0,0,1,1,1,1,3}}	);	
		//3
		allLevels.Add ( new 
					int [,] {	{0,0,0,0,0,3,1,1,1,1,1,1,1,1,1,1,1,1,1,3},
								{0,0,0,0,0,3,1,1,1,1,1,1,1,1,1,1,1,1,1,3},
								{0,0,9,0,0,3,1,1,1,1,1,1,1,1,1,1,1,1,1,3},
								{0,0,0,0,0,3,1,1,1,1,1,1,1,1,1,1,1,1,1,3},
								{0,0,0,0,0,3,1,1,1,1,1,1,1,1,1,1,1,1,1,3},
								{1,1,1,1,1,3,1,1,1,1,1,1,1,1,1,1,1,1,1,3},
								{1,1,1,1,1,3,1,1,1,1,1,1,7,7,7,1,1,1,1,3},
								{1,1,1,1,1,3,1,1,1,1,1,1,7,7,7,1,1,1,1,3},
								{1,1,1,1,1,3,1,1,1,1,1,1,7,7,7,1,1,1,1,3},	
								{1,1,1,1,1,3,1,1,1,1,1,1,7,7,7,1,1,1,1,3},
								{1,1,1,1,1,3,1,1,1,8,1,1,7,7,7,1,1,1,1,3},
								{1,1,1,1,1,3,1,1,1,1,1,1,7,7,7,1,1,1,1,3},
								{1,1,1,1,1,3,3,3,3,3,3,3,7,7,7,1,1,1,1,3},
								{1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,3},
								{1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,3},
								{1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,3},
								{1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,3},
								{1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,3},
								{1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,3},	
								{1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,3,3,3,3,3}}	);
		//4
		allLevels.Add ( new 
					int [,] {	{0,0,0,0,0,1,1,1,3,3,3,3,1,1,1,1,1,1,1,1},
								{0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
								{0,0,9,0,0,1,1,1,1,1,1,1,1,8,1,1,1,1,1,1},
								{0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
								{0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
								{1,1,1,1,1,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
								{1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
								{1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
								{3,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,3},	
								{3,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,3},
								{3,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,3},
								{3,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,3},
								{1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
								{1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
								{1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
								{1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
								{1,1,1,1,8,1,1,1,1,1,1,1,1,1,1,1,8,1,1,1},
								{1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
								{1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},	
								{1,1,1,1,1,1,1,1,3,3,3,3,1,1,1,1,1,1,1,1}}	);	
		
		//5
		allLevels.Add ( new 
					int [,] {	{0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,3,3,3,3,3},
								{0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,3},
								{0,0,9,0,0,0,0,0,0,0,0,0,0,0,1,1,1,8,1,3},
								{0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,3},
								{0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,3},
								{0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,3},
								{0,1,1,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,3},
								{0,1,1,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,3},
								{3,1,1,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,3},	
								{3,1,1,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,0,3},
								{3,1,1,1,0,0,0,0,0,0,0,0,0,0,0,1,1,1,0,3},
								{3,1,1,1,0,0,0,0,0,0,0,0,0,0,0,1,1,1,0,3},
								{3,1,1,1,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,3},
								{3,1,1,1,0,3,3,3,3,3,0,0,0,0,1,1,1,1,1,3},
								{3,1,1,1,1,1,1,1,1,1,0,0,0,0,1,1,1,1,1,3},
								{3,1,1,1,1,1,1,1,1,1,0,0,0,0,1,1,1,1,1,3},
								{3,1,1,1,1,1,1,1,1,1,1,0,0,0,3,3,3,3,3,3},
								{3,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0},
								{3,1,1,1,1,1,3,3,3,3,3,0,0,0,0,0,0,0,0,0},	
								{3,3,3,3,3,3,3,0,0,0,0,0,0,0,0,0,0,0,0,0}}	);		
		
		//6
		allLevels.Add ( new 
					int [,] {	{0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1},
								{0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,8,1},
								{0,0,9,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1},
								{0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1},
								{0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1},
								{0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1},
								{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
								{0,0,0,0,0,0,0,1,1,1,1,1,1,0,0,0,0,0,0,0},
								{0,0,0,0,0,0,0,1,1,1,1,1,1,0,0,0,0,0,0,0},	
								{0,0,0,0,0,0,0,1,1,1,1,1,1,0,0,0,0,0,0,0},
								{0,0,0,0,0,0,0,1,1,1,1,1,1,0,0,0,0,0,0,0},
								{0,0,0,0,0,0,0,1,1,1,1,1,1,0,0,0,0,0,0,0},
								{0,0,0,0,0,0,0,1,1,1,1,1,1,0,0,0,0,0,0,0},
								{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
								{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
								{1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
								{1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
								{1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
								{1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0},	
								{1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0}}	);		
		
		// 7
		allLevels.Add ( new 
					int [,] {	{3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3},
								{3,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,3},
								{3,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,3},
								{3,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,3},
								{3,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,3},
								{3,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,3},
								{3,1,1,1,1,1,6,6,6,6,6,6,6,6,1,1,1,1,1,3},
								{3,1,1,1,1,1,6,0,0,0,0,0,0,6,1,1,1,1,1,3},
								{3,1,1,1,1,1,6,0,0,0,0,0,0,6,1,1,1,1,1,3},	
								{3,1,1,8,1,1,6,0,0,0,0,0,0,6,1,1,1,1,1,3},
								{3,1,1,1,1,1,6,0,0,0,0,0,0,6,1,1,1,1,1,3},
								{3,1,1,1,1,1,6,0,0,0,0,0,0,6,1,1,1,1,1,3},
								{3,1,1,1,1,1,6,0,0,0,0,0,0,6,1,1,1,1,1,3},
								{3,1,1,1,1,1,6,6,6,6,6,6,6,6,1,1,1,1,1,3},
								{3,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,3},
								{3,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,3},
								{3,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,3},
								{3,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,3},
								{3,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,3},	
								{3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,9}}	);	
		
	//	allLevels.Add(level1);
	
		
		
		
		numLevels = allLevels.Count;
		Debug.Log("Loading level " + currentLevel);
		// Check for game over
	//	if ((currentLevel + 1) > numLevels) {
	//		Debug.Log("Loading Credits.");
	//		Application.LoadLevel("Credits");
	//	}
			
		level = (int [,]) allLevels[currentLevel];
		levelDimensions = new Vector3(level.GetLength(0), 0, level.GetLength(1));
		
		for (int i = 0; i < 20;i++) {
			for (int j = 0; j < 20; j++) {		
				if (level[i,j] == 1) {					
					GameObject newPillar = (GameObject) GameObject.Instantiate(Pillar, new Vector3(i*2.1f, -10, j*2.1f), Quaternion.identity);
					newPillar.transform.Rotate(-90,0,0);
				} else if (level[i,j] == 9) {
					GameObject newExit = (GameObject) GameObject.Instantiate(Exit, new Vector3(i, -10, j), Quaternion.identity);
					newExit.transform.Rotate(-90,0,0);
					//GameObject newTube = (GameObject) GameObject.Instantiate(Tube, new Vector3(i, 5, j), Quaternion.identity);
					//newTube.transform.Rotate(-90,0,0);
				//	ParticleSystem newParticle = (ParticleSystem) ParticleSystem.Instantiate(particles, new Vector3(i,5,j), Quaternion.identity);
				//	Light newLight = (Light) Light.Instantiate(exitLight, new Vector3(i,5,j), Quaternion.identity);
				} else if (level[i,j] == 3) {
					GameObject newWall = (GameObject) GameObject.Instantiate(Wall, new Vector3(i*2.1f, 0, j*2.1f), Quaternion.identity);
					newWall.transform.Rotate(-90,0,0);
				} else if (level[i,j] == 8) {
					GameObject newBall = (GameObject) GameObject.Instantiate(Ball, new Vector3(i*2.1f, 0, j*2.1f), Quaternion.identity);
					GameObject newPillar = (GameObject) GameObject.Instantiate(Pillar, new Vector3(i*2.1f, -10, j*2.1f), Quaternion.identity);
					newPillar.transform.Rotate(-90,0,0);					
				} else if (level[i,j] == 7) {
					GameObject newInvisibleWall = (GameObject) GameObject.Instantiate(InvisibleWall, new Vector3(i*2.1f, 0, j*2.1f), Quaternion.identity);
					newInvisibleWall.transform.Rotate(-90,0,0);
				} else if (level[i,j] == 6) {
					GameObject newWallTall = (GameObject) GameObject.Instantiate(WallTall, new Vector3(i*2.1f, -4, j*2.1f), Quaternion.identity);
					newWallTall.transform.Rotate(-90,0,0);
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
