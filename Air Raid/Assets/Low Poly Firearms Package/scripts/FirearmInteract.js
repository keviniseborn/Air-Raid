#pragma strict
var FxShells : ParticleSystem;
var FxMuzzle : ParticleSystem;
private var Firing : boolean;
private var playing : boolean = false;

function Start () {

}
function Update()
{
	Firing = Input.GetButton("Fire1");
	if (Firing)
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
     }
    else
    {
        if (!Firing)
        {
        if (playing)   
			{ 
				playing = false;    
				if(FxShells!=null)
         		{
             		FxShells.Stop();
         		}
         		if(FxShells!=null)
         		{
             		FxMuzzle.Stop();
         		}
         	}
        }
    }
    
}