using UnityEngine;
using System.Collections;

public class BombScript : MonoBehaviour {

	//bomb game object
	public GameObject bomb;

	//variables for spawning bombs
	public int bombCount;
	public int startWait;
	public int bombWaitMin;
	public int bombWaitMax;
	
	// Use this for initialization
	void Start () {
		//run a coroutine along side main process
		StartCoroutine (DropBombs ());
	}
	
	
	//drop bomb function
	IEnumerator DropBombs()
	{
		//Create bombs based on set variables in the inspector
		yield return new WaitForSeconds(startWait);
		for (int i = 0; i < bombCount; ++i) {
			Vector3 spawnPosition = transform.position;
			Quaternion spawnRotation = bomb.transform.rotation;
			Instantiate (bomb, spawnPosition, spawnRotation);
			float waitTime = Random.Range(bombWaitMin, bombWaitMax);
			yield return new WaitForSeconds(waitTime);
		}
	}
}
