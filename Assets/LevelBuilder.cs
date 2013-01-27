using UnityEngine;
using System.Collections;


public class LevelBuilder : MonoBehaviour {		
	
	public static LevelBuilder instance;
	
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
	
	private IList levelNames;
	private IList allLevels;
	
	private int[,]level;	
	private int currentLevel = 0;
	private int numLevels;
	
	private CameraController cameraController;
	
	private static bool created = false;
	private static bool introLoaded = false;
	
	void Awake() {
		
		if (!created) {
			Debug.Log ("Create new levelbuilder" + " " + this.gameObject.GetInstanceID());
			DontDestroyOnLoad(this.gameObject);
			LevelBuilder.instance = this;
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
			initLevels();
			BuildLevel();
		}
		
	}

	// Use this for initialization
	void OnLevelWasLoaded () {
		if (Application.loadedLevelName == "Credits") {
			DestroyImmediate(this);
		}
		Debug.Log ("OnLevelLoaded sees currentLevel as " + currentLevel + " " + this.gameObject.GetInstanceID());
		if (currentLevel != 0 || introLoaded == true) {		
			BuildLevel();
		}
		
		if (introLoaded == false) {
			introLoaded = true;
			// BuildLevel();
		}
		
	}
	
	void initLevels() {
		levelNames = new ArrayList();
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
		levelNames.Add("Easy Does It");
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
		levelNames.Add("On the Importance of General Relativity");
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
								{3,1,1,1,1,1,1,1,1,1,1,1,7,1,1,1,1,1,1,3},
								{3,1,1,1,1,1,1,1,1,1,1,1,7,1,1,8,1,1,1,3},
								{3,1,1,1,1,1,1,1,1,1,1,1,7,1,1,1,1,1,1,3},
								{3,1,1,1,1,1,1,1,1,1,1,1,7,1,1,1,1,1,1,3},
								{3,1,1,1,1,1,1,1,1,1,1,1,7,7,7,1,1,1,1,3},	
								{3,3,3,1,1,3,3,3,3,3,3,3,0,0,0,1,1,1,1,3}}	);	
		//3
		levelNames.Add("Rome Wasn't Burned in a Day");
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
		levelNames.Add("One In to Win");
		allLevels.Add ( new 
					int [,] {	{0,0,0,0,0,1,1,1,3,3,3,3,1,1,1,1,1,1,1,1},
								{0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
								{0,0,9,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
								{0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,8,1,1,1},
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
								{1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,8,1,1,1,1},
								{1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
								{1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
								{1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},	
								{1,1,1,1,1,1,1,1,3,3,3,3,1,1,1,1,1,1,1,1}}	);	
		
		//5
		levelNames.Add("Washington Minding the Gap");
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
								{3,1,1,1,1,1,1,1,1,1,1,0,0,1,1,1,1,1,1,3},
								{3,1,1,1,1,1,1,1,1,1,1,0,0,1,1,1,1,1,1,3},
								{3,1,1,1,1,1,1,1,1,1,1,0,0,0,3,3,3,3,3,3},
								{3,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0},
								{3,1,1,1,1,1,3,3,3,3,3,0,0,0,0,0,0,0,0,0},	
								{3,3,3,3,3,3,3,0,0,0,0,0,0,0,0,0,0,0,0,0}}	);		
		
		//6
		levelNames.Add("Human Heart Simulation - Hyper-realistic Mode");
		allLevels.Add ( new 
					int [,] {	{0,0,0,0,0,1,6,1,6,6,1,6,1,6,1,1,6,6,6,6},
								{0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,6,1,1},
								{0,0,9,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,6},
								{0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
								{0,0,0,0,0,0,0,1,0,0,0,0,0,1,1,1,1,1,1,6},
								{0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,6},
								{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1},
								{0,0,0,0,0,0,0,0,0,0,1,1,1,0,0,0,1,1,1,6},
								{0,0,0,0,0,0,0,1,1,1,1,1,1,6,0,6,1,1,1,6},	
								{0,0,0,0,0,0,0,1,6,0,0,0,1,1,6,1,1,1,1,1},
								{0,0,0,0,0,0,0,1,1,0,0,0,0,0,0,6,1,1,1,6},
								{0,0,0,0,0,0,0,0,0,1,1,1,0,0,0,1,1,1,1,1},
								{0,0,0,0,0,0,0,0,0,1,0,0,1,0,0,1,1,1,1,6},
								{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1},
								{0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1},
								{0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,6},
								{1,1,1,1,1,1,0,0,1,1,1,0,0,1,1,1,1,1,1,6},
								{6,1,8,1,1,1,0,0,1,1,1,0,0,1,1,1,1,1,1,1},
								{1,1,1,1,1,1,0,0,1,1,1,0,0,1,1,0,0,1,1,6},	
								{6,6,1,6,1,1,6,1,6,1,6,1,6,1,6,0,6,6,6,6}}	);	
		
		//6
		levelNames.Add("Kriss Kross");
		allLevels.Add ( new 
					int [,] {	{0,0,0,0,0,0,0,0,0,0,6,6,6,6,6,6,6,6,1,6},
								{0,0,0,0,0,0,0,0,0,0,1,0,0,1,1,1,1,1,1,6},
								{0,0,9,0,0,0,0,0,0,0,0,1,1,0,1,1,8,1,1,1},
								{0,0,0,0,0,0,0,0,6,6,1,1,1,1,1,1,1,1,1,6},
								{0,0,0,0,0,0,0,0,0,1,6,6,1,1,1,1,1,1,1,1},
								{6,1,1,1,0,0,1,0,0,1,1,1,6,6,1,1,1,1,6,1},
								{6,1,1,0,0,0,0,1,0,1,1,1,1,1,6,6,1,1,1,6},
								{6,1,1,1,0,1,0,1,0,0,0,1,0,1,1,1,6,6,1,1},
								{6,1,1,1,1,0,0,1,6,1,1,0,1,1,1,1,1,1,6,6},	
								{6,1,1,1,1,1,0,0,1,6,1,1,1,1,1,1,1,1,1,1},
								{6,1,1,1,1,1,0,1,1,0,6,1,1,1,1,1,1,1,1,6},
								{6,1,1,1,1,0,1,0,1,1,0,6,1,1,1,1,1,1,1,6},
								{6,1,1,1,1,0,1,6,1,1,1,1,6,1,1,1,1,1,1,6},
								{6,1,1,1,1,1,1,6,1,1,1,1,1,6,1,1,1,1,6,1},
								{6,1,1,1,1,1,1,1,6,1,1,1,1,1,6,1,1,1,1,6},
								{6,1,1,1,1,1,1,1,6,1,1,1,1,1,1,6,1,1,1,6},
								{6,1,1,1,1,1,1,1,6,1,1,1,1,1,1,1,6,1,6,6},
								{6,1,1,1,1,1,1,1,6,1,1,1,1,1,1,1,1,6,6,6},
								{6,1,1,1,6,1,1,1,6,1,1,1,1,1,1,1,1,1,6,6},	
								{6,6,6,6,1,6,6,6,6,6,6,6,6,6,1,6,6,6,6,6}}	);		
		
		// 7
		levelNames.Add("Horse");
		allLevels.Add ( new 
					int [,] {	{1,1,1,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6},
								{1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,6,6,6},
								{1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,6},
								{6,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,6},
								{6,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
								{6,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,6},
								{6,1,1,1,1,1,6,6,6,6,6,6,6,6,1,1,1,1,1,6},
								{6,1,1,1,1,1,6,0,0,0,0,0,0,6,1,1,1,1,1,6},
								{6,1,1,1,1,1,6,0,0,0,0,0,0,6,1,1,1,1,1,6},	
								{6,1,1,8,1,1,6,0,0,0,0,0,0,6,1,1,1,1,1,1},
								{6,1,1,1,1,1,6,0,0,0,0,0,0,6,1,1,1,1,1,6},
								{6,1,1,1,1,1,6,0,0,0,0,0,0,6,1,1,1,1,1,6},
								{6,1,1,1,1,1,6,0,0,0,0,0,0,6,1,1,1,1,1,6},
								{6,1,1,1,1,1,6,6,6,6,6,6,6,6,1,1,1,1,1,6},
								{6,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,6,6},
								{6,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
								{6,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,6},
								{6,6,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,6,6},
								{6,6,1,1,1,1,1,1,1,1,1,6,1,6,1,1,1,6,6,6},	
								{6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,9}}	);	
								
		// 7
		levelNames.Add("Follow the yellow brick road");
		allLevels.Add ( new 
					int [,] {	{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
								{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
								{0,0,0,9,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0},
								{0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0},
								{0,0,0,0,0,0,1,1,0,0,0,0,0,0,0,0,0,0,0,0},
								{0,0,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0},
								{0,0,0,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0},
								{0,0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0},
								{0,0,0,0,0,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0},	
								{0,0,0,0,0,0,1,1,1,1,1,0,0,0,0,0,0,0,0,0},
								{0,0,0,0,0,0,0,0,0,1,1,0,0,0,0,0,0,0,0,0},
								{0,0,0,0,0,0,0,0,0,1,1,1,1,1,0,0,0,0,0,0},
								{0,0,0,0,0,0,0,0,0,1,1,1,1,1,0,0,0,0,0,0},
								{0,0,0,0,0,0,0,0,0,0,0,0,1,1,0,0,0,0,0,0},
								{0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,0,0,0},
								{0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,0,0,0},
								{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,8,0,0,0},
								{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1},
								{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1},	
								{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}}	);	
		
		
				
		
		numLevels = allLevels.Count;
	}
	
	void BuildLevel() {				
		
		//currentLevel = 8;
		Debug.Log("Loading level " + currentLevel);
		// Check for game over
		Debug.Log ("Current level is " + currentLevel + " number of levels is " + numLevels);
		
			
		level = (int [,]) allLevels[currentLevel];
		levelDimensions = new Vector3(level.GetLength(0), 0, level.GetLength(1));
		
		cameraController = Camera.mainCamera.GetComponent<CameraController>();
		
		
		for (int i = 0; i < 20;i++) {
			for (int j = 0; j < 20; j++) {		
				if (level[i,j] == 1) {					
					GameObject newPillar = (GameObject) GameObject.Instantiate(Pillar, new Vector3(i*2.1f, -10, j*2.1f), Quaternion.identity);
					newPillar.transform.Rotate(-90,0,0);
				} else if (level[i,j] == 9) {
					GameObject newExit = (GameObject) GameObject.Instantiate(Exit, new Vector3(i, -10, j), Quaternion.identity);
				//	cameraController.exit = newExit;
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
//					cameraController.ball = newBall;
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
		Debug.Log ("Incremementing currentLevel " + currentLevel + " and numLevels = " + numLevels );
		if (currentLevel == numLevels) {
			Debug.Log("Loading Credits.");	
	//		Application.LoadLevel("Credits");
		//	this.transform.parent.gameObject.SetActive(false);
			
			//Destroy(this);
		}
		Debug.Log("Current Level is " + currentLevel + " " + this.gameObject.GetInstanceID());
	}
	public int getCurrentLevel() {
		return currentLevel;
	}
	public string getLevelName(int levelNumber) {
		Debug.Log ("Get level name " + levelNumber);
		return (string) levelNames[levelNumber];
	}
	// Update is called once per frame
	void Update () {
	
	}
}
