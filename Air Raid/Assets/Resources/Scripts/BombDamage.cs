using UnityEngine;
using System.Collections;

public class BombDamage : MonoBehaviour
{
	//explosion object
	public GameObject explosion;

	//player object
	GameObject player;

	//player health script from player object
	PlayerHealth playerHealth;

	//score values
	public int scoreValue;
	public int deductValue;

	//game controller
	private GameController gameController;


	// Use this for initialization
	void Start ()
	{
		//Get game controller and player objects and retrieve necessary scripts
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent <GameController>();
		}
		if (gameController == null)
		{
			Debug.Log ("Cannot find 'GameController' script");
		}

		player = GameObject.FindGameObjectWithTag ("Player");
		playerHealth = player.GetComponent<PlayerHealth> ();
	}

	//on trigger exit
	void OnTriggerExit(Collider other) 
	{
		//if bomb leaves boundary, create explosion and deduct score
		if (other.tag == "Boundary")
		{
			Instantiate (explosion, transform.position, transform.rotation);
			Destroy (gameObject);
			gameController.DeductScore(20);

		}

		//if bullet and bomb pass through each other, create explosion and add score.
		if (other.tag == "Bullet") {

				Instantiate (explosion, transform.position, transform.rotation);
			
			gameController.AddScore(scoreValue);
			Destroy(gameObject);
			Destroy (other.gameObject);
		}
		
	}
}

