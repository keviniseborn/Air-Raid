using UnityEngine;
using System.Collections;

public class DestroyByBoundary : MonoBehaviour {

	//if object leaves boundary, destroy that object
	void onTriggerExit(Collider other)
	{
		//if bomb leaves boundary
		if (other.tag == "Bomb")
		{
			Destroy(other.gameObject);
		}

		//if bullet leaves boundary
		if (other.tag == "Bullet") {
			Destroy (other.gameObject);
		}

	}
}
