#pragma strict

var target : Transform;
var distance : float;

function Start () {

}


function Update(){
 
    transform.position.z = -165.883;
   // transform.position.y = target.position.y-distance;
   transform.position.y = 43.50676;
    transform.position.x = target.position.x-distance;
 
}