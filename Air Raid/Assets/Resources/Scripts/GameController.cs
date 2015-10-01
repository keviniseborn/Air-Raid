using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	//Enemy object array(different types of enemies)
	public GameObject[] enemy;
	//health crate object	
	public GameObject healthCrate;
	//private int for deciding if health crate should spawn
	private int spawnHealth;

	//vector3 of min and max spawn positions for planes
	public Vector3 spawnValuesMin;
	public Vector3 spawnValuesMax;

	//spawn position and rotation of planes
	private Vector3 spawnPosition;
	private Quaternion spawnRotation;

	//Variables for wave information
	private int waveNumber;
	public int maxWaves;
	public GUIText waveText;

	//number of planes
	public int planeCount;
	//wait time between each plane
	public float spawnWait;
	//wait time for first wave to start
	public float startWait;
	//wait time between waves
	public float waveWait;

	//Text to display score
	public GUIText scoreText;

	//gameover and restart booleans
	private bool gameOver;

	//variables for score and high score
	private int score;
	private int[] highScore;

	//if audio is on/off
	private int audioPlaying;

	//background plane object - object with webcam script attached
	public GameObject camObject;
	webCamScript webCamScript;		// - web cam script

	// Use this for initialization
	void Start () {

		//initialise variables
		spawnHealth = 0;
		waveNumber = 0;
		score = 0;
		gameOver = false;

		//retrieve high scores
		highScore = new int[3];
		highScore[0] = PlayerPrefs.GetInt ("highScoreOne", 0);
		highScore [1] = PlayerPrefs.GetInt ("highScoreTwo", 0);
		highScore [2] = PlayerPrefs.GetInt ("highScoreThree", 0);

		//retrieve sound information (on/off)
		audioPlaying = PlayerPrefs.GetInt ("audio");

		//set spawn rotation to identity quaternion
		Quaternion spawnRotation = Quaternion.identity;

		//retreieve webcamscript from game object with it attached
		webCamScript = camObject.GetComponent <webCamScript>();

		UpdateScore ();

		//start coroutine of wave spawner
		StartCoroutine (SpawnWaves ());
	
	}
	
	// Update is called once per frame
	void Update () {

		//if Game over (player died)
		if (gameOver == true) {
			StopCoroutine(SpawnWaves());				//stop spawning enemies
			UpdateHighScore ();							//run updatehighscore function
			PlayerPrefs.SetInt ("lastScore", score);	//set last score to be this score
			webCamScript.stopCamera();					//stop camera playing using webcamscript
			Application.LoadLevel ("looseScene");		//load loose scene to inform player they lost
		}

		if (audioPlaying == 0) {
			//AudioListener.pause = false;
		} else if(audioPlaying == 1){
			//AudioListener.pause = true;
		}

		//if player has won (wave number exceeds that of maximum waves)
		if (waveNumber > maxWaves) {
			webCamScript.stopCamera();					//stop camera
			UpdateHighScore ();							//run updatehighscore function
			PlayerPrefs.SetInt ("lastScore", score);	//set last score to be this score
			Application.LoadLevel ("winScene");			//load win scene to inform player they won
		}
	}

	//Wave spawning function/coroutine 
	IEnumerator SpawnWaves()
	{
		//wait for set amount of time before enemies start spawning
		yield return new WaitForSeconds(startWait);

		//constant loop until it is broken out of
		while (true) {

			//updatewave function
			UpdateWave ();
			//for number of planes to spawn this wave
			for (int i = 0; i < planeCount; ++i) {
				//set spawn position based on random values within ranges set in the inspector
				spawnPosition = new Vector3 (Random.Range (spawnValuesMin.x, spawnValuesMax.x), Random.Range (spawnValuesMin.y, spawnValuesMax.y), spawnValuesMax.z);
				//decide on enemy type - random between the two current planes and instantiate
				int enemyType;
				enemyType = Random.Range(0,2);
				Instantiate (enemy[enemyType], spawnPosition, spawnRotation);
				//wait for set amount of time until next plane spawns
				yield return new WaitForSeconds (spawnWait);

				//if game over break out of for loop
				if(gameOver == true)
				{
					break;
				}
			}
			//if game over break out of while loop
			if(gameOver == true)
			{
				break;
			}

			//add same amount of planes to next wave as current wave number
			planeCount += waveNumber;
			//wait set amount of time until next wave
			yield return new WaitForSeconds (waveWait);

			//spawn health ~ 50% chance 
			spawnHealth = Random.Range (0,2);
			//if spawn health = 0, set a spawn position and instantiate health crate
			if(spawnHealth == 0)
			{
				spawnPosition = new Vector3 (Random.Range (spawnValuesMin.x, spawnValuesMax.x), 70, 120);
				Instantiate(healthCrate, spawnPosition, spawnRotation);
			}
		}
	}

	//add score function
	public void AddScore(int scoreValue)
	{
		score += scoreValue;
		UpdateScore ();
	}

	//deduct score function
	public void DeductScore(int scoreValue)
	{
		score -= scoreValue;
		UpdateScore ();
	}

	//game over function
	public void GameOver()
	{
		gameOver = true;
	}

	//update score function - updates text on screen to current score
	void UpdateScore()
	{
		scoreText.text = "Score: " + score;
	}

	//update wave function - updates wave text on screen to current wave + moves to next wave
	void UpdateWave()
	{
		waveNumber += 1;
		waveText.text = "Wave: " + waveNumber;
	}

	//checks if new score is high score - if it is, sets new score.
	void UpdateHighScore()
	{

			if(score > highScore[0])
			{
				PlayerPrefs.SetInt("highScoreOne", score);
			return;
			}

			if(score > highScore[1])
			{
				PlayerPrefs.SetInt("highScoreTwo", score);
			return;
			}

			if(score > highScore[2])
			{
				PlayerPrefs.SetInt("highScoreThree", score);
			return;
			}

	}
}
