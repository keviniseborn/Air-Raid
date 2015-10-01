using UnityEngine;
using System.Collections;

public class GyroMovement : MonoBehaviour {
	
	float gyroSensitivity = 5.0f;
	float xRot,yRot;
	private Vector3 tempVec;
	// Use this for initialization
	void Start () {
		xRot = 0.0f;
		yRot = 0.0f;
		tempVec = transform.position;
		Input.gyro.enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
		GetRotation (); 
		MoveObject (xRot, yRot);
	}
	
	void GetRotation() {
		xRot = Input.gyro.rotationRateUnbiased.y * gyroSensitivity;
		yRot = Input.gyro.rotationRateUnbiased.x * gyroSensitivity;
	}
	
	void MoveObject(float x, float y) {
		float zBias;
		zBias = transform.position.z;
		zBias = zBias / 10;
		transform.Translate(x * zBias, y * zBias, 0);
	}
}