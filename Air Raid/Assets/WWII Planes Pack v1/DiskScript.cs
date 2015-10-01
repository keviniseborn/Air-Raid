using UnityEngine;
using System.Collections;

public class DiskScript : MonoBehaviour 
{

	public int Speed;
	
	void Update () 
	{
		transform.Rotate(Vector3.forward * Time.deltaTime * Speed); 
	}
}
