using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour
{
	//menu variables
	public GUISkin guiSkin;
	private Rect menuRect;

	//booleans for sound toggle and if paused
	private bool paused;
	private bool sound;

	//is audio playing
	private int audioPlaying;

	//object with webcamscript attached
	public GameObject camObject;
	//web cam script
	webCamScript webCamScript;

	//custom button for pause menu
	private GUIStyle customButton;

	// Use this for initialization
	void Start ()
	{	
		//initialise variables
		paused = false;
		audioPlaying = PlayerPrefs.GetInt ("audio");

		//set button fontsize
		customButton = new GUIStyle("button");
		customButton.fontSize = 32;

		//initialise rect for menu
		menuRect = new Rect (Screen.width / 4, 100, Screen.width / 2,  Screen.height / 2);

		//check if audio is playing
		if (audioPlaying == 0) {
			sound = true;
		} else {
			sound = false;
		}

		//retrieve webcamscript from the web cam object
		webCamScript = camObject.GetComponent <webCamScript>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		//if sound is true play sound, else do not play sound.
		if (sound == true) {
			AudioListener.pause = false;
			PlayerPrefs.SetInt("audio", 0);
		}else{
			AudioListener.pause = true;
			PlayerPrefs.SetInt("audio", 1);
		}

		//if paused, set time scale to 0 - will stop all objects from moving, else set timescale back to original.
		if (paused == true) {
			Time.timeScale = 0.0f;
			Time.fixedDeltaTime = 0.0f;
		} else {
			Time.timeScale = 1.0f;
			Time.fixedDeltaTime = 0.02f;
		}
	}

	//on gui function, if paused, create gui window
	void OnGUI () {
		if (paused) {
			menuRect = GUI.Window (0, menuRect, PauseFunction, "Pause Menu");
		}
	}

	//pause function for all buttons in pause menu
	void PauseFunction(int id) {
		//resume game button
		if (GUILayout.Button ("Resume", customButton,GUILayout.Height(100))) {
			paused = false;
		}
		// toggle sound on/off button
		if (sound = GUILayout.Toggle(sound, "Sound", guiSkin.toggle, GUILayout.Height(100))) {

		}
		//restart game button
		if (GUILayout.Button ("Restart", customButton, GUILayout.Height(100))) {
			webCamScript.stopCamera();
			paused = false;
			Application.LoadLevel("emptyGameScene");
		}
		//quit game button - returns to main menu
		if (GUILayout.Button ("Quit", customButton, GUILayout.Height(100))) {
			webCamScript.stopCamera();
			paused = false;
			Application.LoadLevel("emptyMenuScene");

		}

	}

	//function for pausing the game
	public void onClickPause(){

		if (paused) {
			paused = false;
		} else {
			paused = true;

		}

	}
}