function Start(){
	//script for objects that will be invisible but still rendered
  // get all renderers in this object and its children:
  var renders = GetComponentsInChildren(Renderer);
  for (var rendr: Renderer in renders){
    rendr.material.renderQueue = 2000; // set their renderQueue
  }
}

function Update(){
}