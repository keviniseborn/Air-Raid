using UnityEngine;
using System.Collections;

public class DestroyByTime : MonoBehaviour
{
	//variable for how long object is "alive"
	public float lifeTime;
	// Use this for initialization
	void Start ()
	{
		//destroy object after set time
		Destroy (gameObject, lifeTime);
	}
	
}

