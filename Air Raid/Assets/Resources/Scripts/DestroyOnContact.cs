using UnityEngine;
using System.Collections;

public class DestroyOnContact : MonoBehaviour
{
	//destroy on contact script

	//explosion object
	public GameObject explosion;

	//player object
	GameObject player;

	//player health script
	PlayerHealth playerHealth;

	//score variables
	public int scoreValue;
	public int deductValue;

	//Game controller script
	private GameController gameController;
	
	void Start()
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
	void OnTriggerEnter(Collider other) 
	{
		//if other object is boundary, do nothing.
		if (other.tag == "Boundary")
		{
			return;
		}

		//if other object is building, destroy plane
		if (other.tag == "Building") {
			for(int i = 0; i < 5 ; ++i)
			{
				Instantiate (explosion, transform.position, transform.rotation);
			}
			Destroy(gameObject);
		}

		//if other object is bullet, destroy plane and bullet + add score
		if (other.tag == "Bullet") {
			for(int i = 0; i < 5 ; ++i)
			{
				Instantiate (explosion, transform.position, transform.rotation);
			}
			gameController.AddScore(scoreValue);
			Destroy(gameObject);
			Destroy (other.gameObject);
		}

		//if plane reaches fly to point, destroy plane and remove health & score from player
		if (other.tag == "FlyToPoint") {

			Destroy(gameObject);
			gameController.DeductScore(deductValue);
			playerHealth.TakeDamage(10);

		}
		
	}
}

