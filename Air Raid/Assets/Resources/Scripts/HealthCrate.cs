using UnityEngine;
using System.Collections;

public class HealthCrate : MonoBehaviour
{
	//variables for health crate
	public float rotationValue;
	public float bobValue;
	private bool bobUp;
	private Vector3 originPos;
	private Vector3 tempPos;

	//player game object
	GameObject player;
	//player health script 
	PlayerHealth playerHealth;
	//explosion object
	public GameObject explosion;

	// Use this for initialization
	void Start ()
	{
		//instantiate variables
		bobUp = false;
		originPos = transform.position;
		tempPos = transform.position;
		
		//retrieve playerhealth script from player object
		player = GameObject.FindGameObjectWithTag ("Player");
		playerHealth = player.GetComponent<PlayerHealth> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		//rotate health crate
		transform.Rotate(Vector3.up, rotationValue * Time.deltaTime);

		//if bobup, move crate up, else move down (visual effect for health crate)
		if (bobUp) {
			MoveUp();
		} else{
			MoveDown();
		}
	}


	void OnTriggerEnter(Collider other) 
	{
		//if bullet enters collider - add health, instantiate an explosion and destroy both health crate + bullet
		if (other.tag == "Bullet") {
			playerHealth.AddHealth(15);
			Instantiate (explosion, transform.position, transform.rotation);
			Destroy (other.gameObject);
			Destroy(gameObject);
		}
	}

	//move the health crate up
	void MoveUp()
	{
		tempPos.y += bobValue * Time.deltaTime;
		transform.position = tempPos;
		if (transform.position.y >= originPos.y + 5) {
			bobUp = false;
		}
		
	}
	//move the health crate down
	void MoveDown()
	{
		tempPos.y -= bobValue * Time.deltaTime;
		transform.position = tempPos;
		if (transform.position.y <= originPos.y - 5) {
			bobUp = true;
		}
	}
}