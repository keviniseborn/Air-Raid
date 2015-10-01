using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	//variable for if player has previously played the game
	private int hasPlayed;
	//variable for checking if audio is playing
	private int audioPlaying;

	// Use this for initialization
	void Start () {
		//retrieve hasplayed and audio variables
		hasPlayed = PlayerPrefs.GetInt ("HasPlayed", 0);
		audioPlaying = PlayerPrefs.GetInt ("audio", 0);
	}
	
	// Update is called once per frame
	void Update () {
		//have music on/off based on audio variables
		if (audioPlaying == 0) {
			AudioListener.pause = false;
		} else if(audioPlaying == 1){
			AudioListener.pause = true;
		}
	}

	//function for clicking on play
	public void OnClickPlay(){

		//if player has played before, load the game. If not, load the introduction scene
		if (hasPlayed != 0) {
			Application.LoadLevel ("emptyGameScene");
		} else {
			Application.LoadLevel ("introScene");
		}
	}

	//function for loading high scores
	public void OnClickScores(){
		Application.LoadLevel("highScoreMenu");
	}

	//function for loading facts page
	public void OnClickFacts(){
		Application.LoadLevel("factsMenu");
	}

	//function for loading tutorial page
	public void OnClickTutorial(){
		Application.LoadLevel ("tutorialScene");
	}

	//function for loading options page
	public void OnClickOptions(){
		Application.LoadLevel ("optionsMenu");
	}

	//function for quitting the game
	public void OnClickQuit(){
		Application.Quit();
	}
}
