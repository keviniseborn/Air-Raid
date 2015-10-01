using System;
using UnityEngine;
using System.Collections.Generic;

public class webCamScript : MonoBehaviour
{
	// material for the camera
	public Material cameraMaterial;

	// The number of frames per second
	private int framesPerSecond;

	// The current number of frames
	private int frameNum;

	// The frames timer
	private DateTime timerFrames = DateTime.MinValue;

	// The web cam texture
	private WebCamTexture mTexture = null;
	private WebCamDevice device;

	//texture for loading after web cam has stopped
	public Texture emptytexture;

	//boolean variables for checking if camera is active/updated/stopped
	public bool camActive = false;
	private bool camStopped;
	public bool hasUpdated;
	
	// Use this for initialization
	void Start()
	{	
		//initialise variables
		hasUpdated = false;
		camStopped = false;

		//load webcam material and assign to correct variable
		cameraMaterial = (Material)Resources.Load("WebCameraMaterial", typeof(Material));

		//if camera material did not load, throw exception with error
		if (null == cameraMaterial)
		{
			throw new ApplicationException("Missing camera material reference");
		}

		//request authorization for the use of the camera on the device
		Application.RequestUserAuthorization(UserAuthorization.WebCam);

		
	}
	
	void OnGUI()
	{
		//FPS COUNTER
		/*
		if (timerFrames < DateTime.Now)
		{
			framesPerSecond = frameNum;
			frameNum = 0;
			timerFrames = DateTime.Now + TimeSpan.FromSeconds(1);
		}
		++frameNum;

		GUILayout.Label(string.Format("Frames per second: {0}", framesPerSecond));
		*/

		//if application has authorization for webcame
		if (Application.HasUserAuthorization(UserAuthorization.WebCam))
		{
			//if there are camera devices available
			if (null != WebCamTexture.devices)
			{

				//use back facing camera (hard coded to 0)
				device = WebCamTexture.devices[0];
					
					//if cam active is set to false
					if(camActive == false)
					{

						// stop playing if mTexture is present
						if (null != mTexture)
						{
							if (mTexture.isPlaying)
							{
								mTexture.Stop();
							}
						}
						
						// destroy the old texture
						if (null != mTexture)
						{
							UnityEngine.Object.DestroyImmediate(mTexture, true);
						}
						
						// use the device name for the texture
						mTexture = new WebCamTexture(device.name);
						
						//assign camera material to new texture
						cameraMaterial.mainTexture = mTexture;

						// start playing
						mTexture.Play();
						//set camera to active
						camActive = true;
					}
			}
	
		}
		else
		{
			//if no authorization, write message to screen
			GUILayout.Label("Pending WebCam Authorization...");
		}
		
	}
	
	// Update is called once per frame
	private void Update()
	{
		//if mTexture is presetn and it did update this frame, as well as cam not having stopped, re-asign mTexture to camera materials main texture.
		if (null != mTexture &&
		    mTexture.didUpdateThisFrame && camStopped == false)
		{
			cameraMaterial.mainTexture = mTexture;
		}

	}

	//stop camera function - stops use of camera and assigns material to pre-existing image
	public void stopCamera()
	{
		camStopped = true;
		mTexture.Stop();
		mTexture=null;
		cameraMaterial.mainTexture = emptytexture;
	}
}