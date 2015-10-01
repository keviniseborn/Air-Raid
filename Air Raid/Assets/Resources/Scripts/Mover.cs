using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {
	//used for bullet movement
	//variable for speed
	public float speed;
	
	void Start ()
	{
		//set velocity to speed variable
		GetComponent<Rigidbody>().velocity = transform.up * speed;
	}
	
}
