using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
	public int startingHealth = 50;                            	// The amount of health the player starts the game with.
	public int currentHealth;                                   // The current health the player has.
	public Slider healthSlider;                                 // Reference to the UI's health bar.
	public Image damageImage;                                   // Reference to an image to flash on the screen on being hurt.
	public AudioClip deathClip;                                 // The audio clip to play when the player dies.
	public AudioClip damageClip;
	public float flashSpeed = 5f;                               // The speed the damageImage will fade at.
	public Color flashColour = new Color(1f, 0f, 0f, 0.35f);  	// The colour the damageImage is set to, to flash.
	
	
	Animator anim;                                              // Reference to the Animator component.
	AudioSource playerAudio;                                    // Reference to the AudioSource component.


	bool isDead;                                                // Whether the player is dead.
	bool damaged;                                               // True when the player gets damaged.

	private GameController gameController;						// Game controller object
	
	void Awake ()
	{
		// Setting up the references.
		playerAudio = GetComponent <AudioSource> ();

		//retrieve game controller object
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null)
		{	//if gamecontroller object was found, retreieve the game controller script.
			gameController = gameControllerObject.GetComponent <GameController>();
		}
		if (gameController == null)
		{
			Debug.Log ("Cannot find 'GameController' script");
		}

		// Set the initial health of the player.
		currentHealth = startingHealth;
	}
	
	
	void Update ()
	{
		// If the player is damaged
		if(damaged)
		{
			//set the colour of the damageImage to the flash colour.
			damageImage.color = flashColour;
		}
		else
		{
			// transition the colour back to normal.
			damageImage.color = Color.Lerp (damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
		}
		
		// Reset the damaged bool
		damaged = false;

		// If the player has lost all health
		if(currentHealth <= 0)
		{
			///use game controller game over function
			gameController.GameOver();
			Death ();	
		}
	}
	
	//take damage function
	public void TakeDamage (int amount)
	{
		// set damaged to true for red screen flash
		damaged = true;
		
		// Reduce health by damage amount
		currentHealth -= amount;

		// Set the health bar's value to the current health
		healthSlider.value = currentHealth;
		
		//play the damaged sound effect
		playerAudio.Play ();
		

	}

	//add health to the player (for health crate)
	public void AddHealth (int amount)
	{
		//update current health and health slider
		currentHealth += amount;
		healthSlider.value = currentHealth;	
	}
	
	
	void Death ()
	{
		// Set the death bool to true
		isDead = true;
		
		// Set the audiosource to play the death clip and play it
		playerAudio.clip = deathClip;
		playerAudio.Play ();

	}       
}