
var cameraTarget			 : GameObject;			//object to look at / follow
var player					 : GameObject;			//player object for moving

var smoothTime				 : float = 0.1; 		// time for camera dampen
var cameraFollowX			 : boolean = true;		//camera follows on horizontal
var cameraFollowY			 : boolean = true;	    //camera follows on vertical
var cameraFollowHeight		 : boolean = false;	    //camera follow cameraTarget object height, not the Y
var cameraHeight			 : float = 2.5; 		//height of camera adjustable in the inspector
var cameraZoom				 : boolean = false; 	//toggle for zoom in and out on ORTHO size
var cameraZoomMax			 : float = 2.5;		    //minimum amount that the camera can pull in
var cameraZoomMin			 : float = 4.0;		    //minimum amount that the camera can pull out
var cameraZoomTime			 : float = 0.03;		//speed for camera zoom
var velocity    			 : Vector2;			    //speed of camera movement
private var thisTransform	 : Transform;		    //cameras transform
private var curPos			 : float = 0.0;  	    //current position of camera target
private var playerJumpHeight : float = 0.0;  	    //current position of camera target


function Start()
{
	thisTransform = transform;
}

function Update ()
{
	if(cameraFollowX)
	{
		thisTransform.position.z = Mathf.SmoothDamp(thisTransform.position.z, cameraTarget.transform.position.z, velocity.x, smoothTime);		
	}   
	if(cameraFollowY)
	{
		thisTransform.position.y = Mathf.SmoothDamp(thisTransform.position.y, cameraTarget.transform.position.y, velocity.y, smoothTime);		
	}
	if(!cameraFollowY && cameraFollowHeight)
	{
		camera.transform.position.y = cameraHeight;
	}
	if(cameraZoom)
	{
		// get current postion of players current y position (getcomponent -> where is player?)
		
		// check for players position and how it relates to the curPos and cur jump height pos.
		
		// adjust the orthographic size from camera to equal the height jump distance (maybe a lerp?)
	} 
}