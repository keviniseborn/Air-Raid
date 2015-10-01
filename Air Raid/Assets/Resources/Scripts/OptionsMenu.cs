using UnityEngine;
using System.Collections;

public class OptionsMenu : MonoBehaviour
{
	//variables for audio
	private int audioPlaying;
	private bool toggleBool = true;
	

	// Use this for initialization
	void Start ()
	{
		//check if audio is playing
		audioPlaying = PlayerPrefs.GetInt ("audio");
	}
	
	// Update is called once per frame
	void Update ()
	{
		//have music on/off based on audio variables
		if (audioPlaying == 0) {
			AudioListener.pause = false;
		} else{
			AudioListener.pause = true;
		}
	}

	//toggle audio function, on/off
	public void ToggleSound()
	{
		if (audioPlaying == 0) {
			PlayerPrefs.SetInt("audio", 1);
			audioPlaying = 1;
		} else {
			PlayerPrefs.SetInt("audio", 0);
			audioPlaying = 0;
		}
	}

	//function to return to main menu
	public void Return()
	{
		Application.LoadLevel ("mainMenu");
	}

	//reset game function - resets high scores and set has played to has not played previously.
	public void ResetGame()
	{
		PlayerPrefs.SetInt ("highScoreOne", 0);
		PlayerPrefs.SetInt ("highScoreTwo", 0);
		PlayerPrefs.SetInt ("highScoreThree", 0);
		PlayerPrefs.SetInt ("HasPlayed", 0);
	}
}

