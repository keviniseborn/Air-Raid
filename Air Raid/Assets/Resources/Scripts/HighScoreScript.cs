using UnityEngine;
using System.Collections;

public class HighScoreScript : MonoBehaviour
{
	//variables to store high score
	private int highScoreOne;
	private int highScoreTwo;
	private int highScoreThree;

	//text variables to display high score
	public GUIText oneText;
	public GUIText twoText;
	public GUIText threeText;

	//if audio is playing or not
	private int audioPlaying;


	void Start ()
	{
		//update the highscore
		UpdateHighScore ();
		//check if audio is playing
		audioPlaying = PlayerPrefs.GetInt ("audio", 0);
	}
	
	// Update is called once per frame
	void Update ()
	{
		//check if audio is playing
		if (audioPlaying == 0) {
			AudioListener.pause = false;
		} else if(audioPlaying == 1){
			AudioListener.pause = true;
		}
	}

	//function to reset high scores back to 0
	public void ClearScores()
	{
		PlayerPrefs.SetInt ("highScoreOne", 0);
		PlayerPrefs.SetInt ("highScoreTwo", 0);
		PlayerPrefs.SetInt ("highScoreThree", 0);

		//update score text
		UpdateHighScore ();
	}

	//function to load main menu
	public void MainMenu()
	{
		Application.LoadLevel("mainMenu");
	}

	//function to retrieve high scores and update the text on the screen
	void UpdateHighScore()
	{
		highScoreOne = PlayerPrefs.GetInt ("highScoreOne", 0);
		highScoreTwo = PlayerPrefs.GetInt ("highScoreTwo", 0);
		highScoreThree = PlayerPrefs.GetInt ("highScoreThree", 0);
		
		oneText.text = "1. " + highScoreOne;
		twoText.text = "2. " + highScoreTwo;
		threeText.text = "3. "+ highScoreThree;
	}
}

