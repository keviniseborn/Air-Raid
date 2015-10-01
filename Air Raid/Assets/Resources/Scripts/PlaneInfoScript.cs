using UnityEngine;
using System.Collections;

public class PlaneInfoScript : MonoBehaviour
{
	//array of gameobjects to store different planes
	public GameObject[] planes; 
	//current plane in view integer
	private int currentPlane;

	//rotation variables for inspecting the plane
	private int xRot, yRot, maxRot;

	//text variable to store/display information about plane
	public GUIText info;

	//audio on/off variable
	private int audioPlaying;

	// Use this for initialization
	void Start ()
	{
		//initialise variables
		currentPlane = 0;
		xRot = 0;
		yRot = 0;
		maxRot = 2;
		audioPlaying = PlayerPrefs.GetInt ("audio", 0);
	}
	
	// Update is called once per frame
	void Update ()
	{
		LimitRotation ();
		if (currentPlane == 0) {
			planes [0].SetActive (true);
			planes [1].SetActive (false);
		}
		if (currentPlane == 1) {
		
			planes[0].SetActive(false);
			planes[1].SetActive(true);

		}
		SetActiveText ();
		planes [currentPlane].transform.Rotate (xRot, yRot, 0);


		if (audioPlaying == 0) {
			AudioListener.pause = false;
		} else if(audioPlaying == 1){
			AudioListener.pause = true;
		}
	}

	//rotate functions for the buttons
	//rotate left by 1
	public void RotateLeft()
	{
		yRot -= 1;
	}
	//rotate right by 1
	public void RotateRight()
	{
		yRot += 1;
	}
	//rotate up by 1
	public void RotateUp()
	{
		xRot += 1;
	}
	//rotate down by 1
	public void RotateDown()
	{
		xRot -= 1;
	}

	//next plane button function, displays the next plane in the array
	public void NextPlane()
	{
		if (currentPlane < 1) {
			currentPlane++;
		} else {
			currentPlane = 0;
		}
	}
	//previous plane button function, displays the previous plane in the array
	public void PreviousPlane()
	{
		if (currentPlane > 0) {
			currentPlane--;
		} else {
			currentPlane = 1;
		}
	}

	//set the active text on the screen to display information about the correct plane
	void SetActiveText()
	{
		if (currentPlane == 0) {
			info.text = "Name: Messerschmitt Bf 109 \r\nCrew: 1 \r\nLength: 8.95m \r\nWingspan: 9.925m \r\nMax Speed: 640 km/h \r\nRange: 850km \r\nService Ceiling: 12,000m";

		}
		if (currentPlane == 1) {
			info.text = "Name: Junkers Ju 88 \r\nCrew: 4 \r\nPilot, \r\nbombardier/front gunner, \r\nradio operator/rear gunner, \r\nnavigator/ventral gunner\r\nLength: 14.36m \r\nWingspan: 20.08m \r\nMax Speed: 510km/h \r\nRange: 2,430 km \r\nService Ceiling 9,000m"; 

		}

	}

	//main menu function
	public void MainMenu()
	{
		Application.LoadLevel("mainMenu");
	}

	//limit rotation of the plane so that the user cant make it spin uncontrollably 
	private void LimitRotation()
	{
		if (xRot > 2) {
			xRot = 2;
		}
		if (xRot < -2) {
			xRot = -2;
		}
		if (yRot > 2) {
			yRot = 2;
		}
		if (yRot < -2) {
			yRot = -2;
		}
	}
}