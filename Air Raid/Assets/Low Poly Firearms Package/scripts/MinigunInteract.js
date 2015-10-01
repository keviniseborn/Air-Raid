#pragma strict
var Barrels : Transform;
var FxShells : ParticleSystem;
var FxMuzzle : ParticleSystem;
var MaxSpinRate : float = 1500;
var SpinUpTime : float = 2;
private var SpinUpTimer : float;
private var Firing : boolean;
private var theta : float;
private var playing : boolean = false;


var shot : GameObject;
var shotSpawn : Transform;
var fireRate : float;
private var nextFire : float;

function Start () {
}
function Update()
{
	Firing = Input.GetButton("Fire1");
	if (Firing)
	{
    	SpinUpTimer = Mathf.Clamp( SpinUpTimer + Time.deltaTime,0, SpinUpTime);
        if (SpinUpTimer >= SpinUpTime)
        {
			if (!playing)   
			{ 
				playing = true;    
				if(FxShells!=null)
         		{
             		FxShells.Play();
         		}
         		if(FxShells!=null)
         		{
             		FxMuzzle.Play();
         		}
         	}
         	if(Time.time > nextFire)
         	{
         		nextFire = Time.time + fireRate;
         		Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
         		
         	}
        }
    }
    else
    {
        // Not firing now. Spin back down
        SpinUpTimer = Mathf.Clamp( SpinUpTimer - Time.deltaTime,0, SpinUpTime);
        if (!Firing)
        {
        if (playing)   
			{ 
				playing = false;    
				if(FxShells!=null)
         		{
             		FxShells.Stop();
             		//shootSound.Stop();
         		}
         		if(FxShells!=null)
         		{
             		FxMuzzle.Stop();
         		}
         	}
        }
    }
       // Spin the barrels
       theta = ((SpinUpTimer / SpinUpTime) * MaxSpinRate * Time.deltaTime);
       Barrels.transform.Rotate(0,0,theta);
    
}