#pragma strict
	
	//bool if device has gyroscope
	static var gyroBool : boolean;
 	//gyroscope object
    private var gyro : Gyroscope;
 	//quaternion for device rotation
    private var quatRot : Quaternion;
	//quaternion for gyro values
    private var quatGyro : Quaternion;
    //has positioned boolean
    private var hasPosition : boolean;
    //Camera variable for the camera in game
    private var thisCam : Camera;

 	//on start up
    function Awake() {
    
 		//initialise hasPosition bool
 		hasPosition = false;
 		//get Camera component and assign to this cam
 		thisCam = GetComponent(Camera);
 		
        // find the current parent of the camera's transform
        var currentParent = transform.parent;
 
        // instantiate a new transform
        var camParent = new GameObject ("camParent");
 
        // match the transform to the camera position
        camParent.transform.position = transform.position;
 
        // make the new transform the parent of the camera transform
        transform.parent = camParent.transform;
 
        // make the original parent the grandparent of the camera transform
 
        //camParent.transform.parent = currentParent;
 
        // instantiate a new transform
 
        var camGrandparent = new GameObject ("camGrandParent");
 
        // match the transform to the camera position
 
        camGrandparent.transform.position = transform.position;
 
        // make the new transform the parent of the camera transform
 
        camParent.transform.parent = camGrandparent.transform;
 
        // make the original parent the grandparent of the camera transform
 
        camGrandparent.transform.parent = currentParent; 
 
      	//does device suport gyroscope
        gyroBool = SystemInfo.supportsGyroscope;
 
 
 	
       //if device supports gyroscope
 
        if (gyroBool) {
 			
 			//assign actual gyroscope to gyro variable
            gyro = Input.gyro;
 			//enable the gyroscope
            gyro.enabled = true;

			//if android device
            #if UNITY_ANDROID
 
					//transform parent for actual orientation of device
                    camParent.transform.eulerAngles = Vector3(90,0,0);
 						
 						//screen orientation should be landscape left. identity quaternion to rotate to correct orientation
                        if (Screen.orientation == ScreenOrientation.LandscapeLeft) {
 
                           quatRot = Quaternion(0,0,1,0);
 
                        } else if (Screen.orientation == ScreenOrientation.LandscapeRight) {
 
                           quatRot = Quaternion(0,0,1,0);
 
                        } else if (Screen.orientation == ScreenOrientation.Portrait) {
 
                           quatRot = Quaternion(0,0,1,0);
 
                        }
 
            #endif
 			//Set screen sleep time to never sleep
            Screen.sleepTimeout = SleepTimeout.NeverSleep;
 
        } else{
 			
 			//if playing in unity editor, there is no gyroscope
            #if UNITY_EDITOR
 
                print("No gyroscope in unity editor");
 
            #endif
 
        }
 
    }
 
     
 
    function Update () {
 

            #if UNITY_ANDROID
            	//set quatGyro to mobile device gyroscope values
                quatGyro = Quaternion(gyro.attitude.x,gyro.attitude.y,gyro.attitude.z,gyro.attitude.w);

            #endif
			//transform local rotation by gyroscope values and screen orientation identity matrix
 			transform.localRotation = (quatGyro * quatRot);

    }