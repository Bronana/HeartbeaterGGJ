using UnityEngine;
using System.Collections;

// Require these components when using this script
[RequireComponent(typeof (Animator))]
[RequireComponent(typeof (CapsuleCollider))]
[RequireComponent(typeof (Rigidbody))]
public class PlayerControlScript : MonoBehaviour
{
	
	
	public float animSpeed = 1.5f;				// a public setting for overall animator animation speed
	public bool useCurves;						// a setting for teaching purposes to show use of curves
	public bool simulating;
	
	private Animator anim;							// a reference to the animator on the character
	private CapsuleCollider col;
	private AnimatorStateInfo currentBaseState;
	
	static int idleState = Animator.StringToHash("Base Layer.Idle");	
	static int locoState = Animator.StringToHash("Base Layer.Locomotion");			// these integers are references to our animator's states
	static int jumpState = Animator.StringToHash("Base Layer.Jump");				// and are used to check state for various actions to occur
	static int punchState = Animator.StringToHash("Base Layer.Punch");	
	

	void Start ()
	{
		// initialising reference variables
		anim = GetComponent<Animator>();					  
		col = GetComponent<CapsuleCollider>();				
	}
	
	public void SimulateRightHandMovement()
	{
		float h = .9F;				// setup h variable as our horizontal input axis				// setup v variables as our vertical input axis
		anim.SetFloat("Speed", h);							// set our animator's float parameter 'Speed' equal to the vertical input axis				
		anim.speed = animSpeed;	
		transform.rotation = Quaternion.Euler(0F, 90F, 0F);
		
		if(anim.GetBool("Jump"))
			anim.SetBool("Jump", false);
	}
	
	public void SimulateJump()
	{
		transform.rotation = Quaternion.Euler(0F, 90F, 0F);
		anim.SetBool("Jump", true);
	}
	
	void FixedUpdate ()
	{
		if(simulating) return;
		float h = Input.GetAxis("Horizontal");				// setup h variable as our horizontal input axis
		anim.SetFloat("Speed", h);							// set our animator's float parameter 'Speed' equal to the vertical input axis				
		anim.speed = animSpeed;								// set the speed of our animator to the public variable 'animSpeed'
		
		
		if(h > 0F)
			transform.rotation = Quaternion.Euler(0F, 90F, 0F);
		else
			transform.rotation = Quaternion.Euler(0F, -90F, 0F);
		
		// STANDARD JUMPING
		
		if(Input.GetMouseButtonDown(0))
		{
			anim.SetBool("Punch", true);
		}
		
		// if we are currently in a state called Locomotion (see line 25), then allow Jump input (Space) to set the Jump bool parameter in the Animator to true
		if (currentBaseState.nameHash == locoState)
		{
			if(Input.GetButtonDown("Jump"))
			{
				anim.SetBool("Jump", true);
			}
			
		}
		
		// if we are in the jumping state... 
		else if(currentBaseState.nameHash == jumpState)
		{
			//  ..and not still in transition..
			if(!anim.IsInTransition(0))
			{
				if(useCurves)
					// ..set the collider height to a float curve in the clip called ColliderHeight
					col.height = anim.GetFloat("ColliderHeight");
				
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
		if (currentBaseState.nameHash == punchState)
		{
			anim.SetBool("Punch", false);
		}
		
		
	}
}
