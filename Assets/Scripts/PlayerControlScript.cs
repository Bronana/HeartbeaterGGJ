using UnityEngine;
using System.Collections;

// Require these components when using this script
[RequireComponent(typeof (Animator))]
[RequireComponent(typeof (CapsuleCollider))]
[RequireComponent(typeof (Rigidbody))]
public class PlayerControlScript : MonoBehaviour
{
	public float animSpeed = 1.5f;				// a public setting for overall animator animation speed
	public float heightBump;					// a setting for teaching purposes to show use of curves
	public bool simulating;
	int lastLook = 1;
	
	private Animator anim;							// a reference to the animator on the character
	private CapsuleCollider col;
	private bool justJumped = false;
	private AnimatorStateInfo currentBaseState;
		
	static int locoState = Animator.StringToHash("BaseLayer.Locomotion");			// these integers are references to our animator's states
	static int locoState2 = Animator.StringToHash("BaseLayer.Locomotion 0");
	static int jumpState = Animator.StringToHash("BaseLayer.Jump");				// and are used to check state for various actions to occur
	static int punchState = Animator.StringToHash("BaseLayer.Punch");	
	

	void Start ()
	{
		// initialising reference variables
		anim = GetComponent<Animator>();					  			
	}
	
	public void SimulateRightHandMovement()
	{
		float h = 1F;				// setup h variable as our horizontal input axis				// setup v variables as our vertical input axis
		anim.SetFloat("Speed", h);							// set our animator's float parameter 'Speed' equal to the vertical input axis				
		anim.speed = animSpeed;	
		transform.Translate(0, 0, h * .1F);
		transform.rotation = Quaternion.Euler(0F, 0F, 0F);
		if(anim.GetBool("Jump"))
			anim.SetBool("Jump", false);
	}
	
	public void SimulateJump()
	{
		anim.SetBool("Jump", true);
	}
	
	public bool IsPunching()
	{
		return currentBaseState.nameHash == punchState;		
	}
	
	public bool IsJumping()
	{
		return currentBaseState.nameHash == jumpState;
	}
	
	void FixedUpdate ()
	{
		if(simulating) return;
		currentBaseState = anim.GetCurrentAnimatorStateInfo(0);
		float h = Input.GetAxis("Horizontal");				// setup h variable as our horizontal input axis
		anim.SetFloat("Speed", h);							// set our animator's float parameter 'Speed' equal to the vertical input axis				
		anim.speed = animSpeed;								// set the speed of our animator to the public variable 'animSpeed'
		
		if(Input.GetKey(KeyCode.Return))
		{
			anim.SetBool("Punch", true);
		}
		
		if (currentBaseState.nameHash == locoState || currentBaseState.nameHash == locoState2)
		{
			if(Input.GetButton("Jump") && !justJumped)
			{
				anim.SetBool("Jump", true);
				justJumped = true;
				return;
			}
			
			if(h > .1F)
				lastLook = 1;
			else if(h < -.1F)
				lastLook = -1;
			
			if(lastLook == 1)
				transform.rotation = Quaternion.Euler(0F, 0F, 0F);
			else
				transform.rotation = Quaternion.Euler(0F, -180F, 0F);
			
			
			if(transform.position.y < .1F)
				heightBump = .05F;
			else
				heightBump = 0;
			
			transform.Translate(0, heightBump, Mathf.Abs(h) * .1F);
			justJumped = false;
		}	
		else if (currentBaseState.nameHash == punchState)
		{
			anim.SetBool("Punch", false);
			if(lastLook == 1)
				transform.rotation = Quaternion.Euler(0F, 35F, 0F);
			else
				transform.rotation = Quaternion.Euler(0F, -135F, 0F);
		}
		// if we are in the jumping state... 
		else if(currentBaseState.nameHash == jumpState)
		{
			//  ..and not still in transition..
			if(!anim.IsInTransition(0))
			{
				
				// reset the Jump bool so we can jump again, and so that the state does not loop 
				anim.SetBool("Jump", false);
			}
			
			// Raycast down from the center of the character.. 
			Ray ray = new Ray(transform.position + Vector3.up, -Vector3.up);
			RaycastHit hitInfo = new RaycastHit();
			
			if (Physics.Raycast(ray, out hitInfo))
			{
				// ..if distance to the ground is more than 1.75, use Match Target
				if (hitInfo.distance > 1.75f)
				{
					
					// MatchTarget allows us to take over animation and smoothly transition our character towards a location - the hit point from the ray.
					// Here we're telling the Root of the character to only be influenced on the Y axis (MatchTargetWeightMask) and only occur between 0.35 and 0.5
					// of the timeline of our animation clip
					anim.MatchTarget(hitInfo.point, Quaternion.identity, AvatarTarget.Root, new MatchTargetWeightMask(new Vector3(0, 1, 0), 0), 0.35f, 0.5f);
				}
			}
		}
		
		
	}
}
