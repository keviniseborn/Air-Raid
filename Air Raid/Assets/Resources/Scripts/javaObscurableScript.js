function Start(){
	//script for objects that are rendered and are hidden by invisible objects
  // get all renderers in this object and its children:
  var renders = GetComponentsInChildren(Renderer);
  for (var rendr: Renderer in renders){
    rendr.material.renderQueue = 2002; // set their renderQueue
  }
}
function Update(){
}