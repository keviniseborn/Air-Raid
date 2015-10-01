using UnityEngine;
using System.Collections;

public class TutorialMenu : MonoBehaviour
{
	//variable to check if audio is on/off
	private int audioPlaying;

	// Use this for initialization
	void Start ()
	{	
		//retrieve int to see if audio is playing
		audioPlaying = PlayerPrefs.GetInt ("audio", 0);
	}

	void Update()
	{
		//based on audio variable have sound on/off
		if (audioPlaying == 0) {
			AudioListener.pause = false;
		} else if(audioPlaying == 1){
			AudioListener.pause = true;
		}
	}

	//function for clicking on skip. Sets has played to 1 (means they have played) and loads the main game
	public void OnClickSkip(){
		PlayerPrefs.SetInt ("HasPlayed" , 1);
		Application.LoadLevel("mainGame");
	}

	//function for going back to main menu
	public void OnClickBack(){
		Application.LoadLevel ("mainMenu");
	}
}