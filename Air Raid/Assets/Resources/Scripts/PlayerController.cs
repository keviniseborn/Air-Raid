using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
	public GameObject shot;
	public Transform shotSpawn;
	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
		Debug.Log ("player controller");
	}
}

