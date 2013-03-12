#pragma strict

function Start () {
	yield WaitForSeconds (3);
	Destroy(this.gameObject);
}

function Update () {

}