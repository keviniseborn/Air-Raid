using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WayPointMovement : MonoBehaviour
{
	
	// speed of the AI player
	public float speed;
	
	//speed the ai player rotates by
	public float rotSpeed = 2f;
	//variables for rotation and direction of FlyToPoint
	Quaternion FTPRotation;
	Vector3 FTPDirection;
	//current rotation quaternion
	private Quaternion currentRotation;
	
	// the waypoints
	public GameObject[] wpLayerOne;
	public GameObject[] wpLayerTwo;

	//number of waypoints per layer
	public int waypointsPerLayer;
	//current layer
	private int currentLayer;

	//fly to point game object
	public GameObject FTP;

	//current waypoint id
	private int wpIdOne = 0;
	private int wpIdTwo = 0;

	// Use this for initialization
	void Start ()
	{
		//retrieve all game objects with layer tags and assign to correct layer
		wpLayerOne = GameObject.FindGameObjectsWithTag ("wpLayerOne");
		wpLayerTwo = GameObject.FindGameObjectsWithTag ("wpLayerTwo");
		//retrieve the fly to point game object
		FTP = GameObject.FindGameObjectWithTag ("FlyToPoint");

		//set random waypoint on each layer for each plane
		wpIdOne = Random.Range (0, waypointsPerLayer);
		wpIdTwo = Random.Range (0, waypointsPerLayer);

		//set current layer to first layer
		currentLayer = 1;

		//calculate fly to point direction
		FTPDirection = ( transform.position - wpLayerOne[wpIdOne].transform.position);
		//get current rotation
		currentRotation = transform.rotation;
		//assign FTP rotation to look rotation in fly to point direction
		FTPRotation = Quaternion.LookRotation(FTPDirection);

	}
	
	// Update is called once per frame
	void Update ()
	{
		//if timescale is not 0, allow enemy movement (for pausing the game)
		if (Time.timeScale != 0) {
			Patrol ();
		}
	}

	//movement function for planes
	void Patrol()
	{
		//if current layer is 1
		if (currentLayer == 1) {

			// if distance to waypoint is less than 2 meters then start heading toward next waypoint
			if (Vector3.Distance(wpLayerOne[wpIdOne].transform.position, transform.position) < 2)
			{
				currentLayer ++;
			}
			//if distance to waypoint is less than 10 meters, calculate new fly to direction and rotation based on waypoint 2
			if(Vector3.Distance(wpLayerOne[wpIdOne].transform.position, transform.position) < 10)
			{
				FTPDirection = ( transform.position - wpLayerTwo[wpIdTwo].transform.position);
				currentRotation = transform.rotation;
				FTPRotation = Quaternion.LookRotation(FTPDirection);

			}else{

				//else continue calculating for waypoint layer 1
				FTPDirection = ( transform.position - wpLayerOne[wpIdOne].transform.position);
				currentRotation = transform.rotation;
				FTPRotation = Quaternion.LookRotation(FTPDirection);
			}

			// move towards the current waypointId's position
			transform.position = Vector3.MoveTowards(transform.position, wpLayerOne[wpIdOne].transform.position, Time.deltaTime * speed);
		}

		if (currentLayer == 2) {
			
			// if distance to waypoint is less than 2 metres then start heading toward next waypoint
			if (Vector3.Distance(wpLayerTwo[wpIdTwo].transform.position, transform.position) < 2)
			{
				currentLayer ++;
			}

			//if distance to waypoint is less than 10 meters, calculate new fly to direction and rotation based on Fly To Point
			if(Vector3.Distance(wpLayerTwo[wpIdTwo].transform.position, transform.position) < 10)
			{
				currentRotation = transform.rotation;
				FTPDirection = (transform.position - FTP.transform.position);
				FTPRotation = Quaternion.LookRotation(FTPDirection);
			}else{

				//else continue calculating for waypoint layer 2
				currentRotation = transform.rotation;
				FTPDirection = (transform.position - wpLayerTwo[wpIdTwo].transform.position );
				FTPRotation = Quaternion.LookRotation(FTPDirection);
			}
			// move towards the current waypointId's position
			transform.position = Vector3.MoveTowards(transform.position, wpLayerTwo[wpIdTwo].transform.position, Time.deltaTime * speed);
		}

		if (currentLayer == 3) {

			// alculate new fly to direction and rotation based on Fly To Point
			currentRotation = transform.rotation;
			FTPDirection = (transform.position - FTP.transform.position);
			FTPRotation = Quaternion.LookRotation(FTPDirection);

			// move towards the Fly to Point
			transform.position = Vector3.MoveTowards(transform.position,FTP.transform.position, Time.deltaTime * speed);
		}

		//if current rotation is not same rotation as to next fly point
		if (currentRotation != FTPRotation) {
			//rotate using slerp from current rotation to desired rotation
			transform.rotation = Quaternion.Slerp (currentRotation, FTPRotation, Time.deltaTime * rotSpeed);
		}
	}
	
}