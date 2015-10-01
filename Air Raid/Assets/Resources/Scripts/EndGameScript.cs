using UnityEngine;
using System.Collections;

public class EndGameScript : MonoBehaviour
{
	//text variable for displaying score
	public GUIText scoreText;

	//integer to get last score
	private int lastScore;

	// Use this for initialization
	void Start ()
	{
		UpdateScore ();
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	//updates the score text to display last score achieved
	void UpdateScore()
	{
		lastScore = PlayerPrefs.GetInt ("lastScore", 0);
		
		scoreText.text = "Score :  " + lastScore;

	}

	//load main menu
	public void MainMenu()
	{
		Application.LoadLevel("mainMenu");
	}
}

