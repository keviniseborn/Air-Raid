using UnityEngine;
using System.Collections;

public class loadDepthMaterial : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
		//load the depth material and assign it to the game object
		Material newMat = Resources.Load("depthMat", typeof(Material)) as Material;
		gameObject.GetComponent<MeshRenderer>().material = newMat;
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
}

