using UnityEngine;
using System.Collections;

public class RotatearoundObjects : MonoBehaviour
{
	public GameObject FTP; //fly to point
	public Gyroscope gyro;
	public int curRot;
	// Use this for initialization
	void Start ()
	{
		gyro = Input.gyro;
	}
	
	// Update is called once per frame
	void Update ()
	{
		//test one
		//transform.RotateAround (FTP.transform.position, Vector3.up, -gyro.rotationRate.x);

		//test two
		//if(gyro.rotationRate.x > 1){
		//curRot += 1;
		//}if(gyro.rotationRate.x < -1){
		//curRot -= 1;
		//}		
		//transform.RotateAround (FTP.transform.position, Vector3.up, curRot);

		//test three
		if(gyro.rotationRate.x > 1){
		transform.Translate(1,0,0);
		}if(gyro.rotationRate.x < -1){
		transform.Translate(-1,0,0);
		}


		//*/
	}
}

