using UnityEngine;
using System.Collections;

[RequireComponent(typeof (Animator))]
[RequireComponent(typeof (CapsuleCollider))]
[RequireComponent(typeof (Rigidbody))]

public class ElfControllerScript : MonoBehaviour {

	public float animSpeed = 1.5f;				// a public setting for overall animator animation speed
	
	private Animator anim;							// a reference to the animator on the character
	private CapsuleCollider col;
	private AnimatorStateInfo currentBaseState;	

	void Start ()
	{
		// initialising reference variables
		anim = GetComponent<Animator>();					  
		col = GetComponent<CapsuleCollider>();				
	}
	
	
	void FixedUpdate ()
	{
		anim.SetFloat("Speed", -1);							// set our animator's float parameter 'Speed' equal to the vertical input axis				
		anim.speed = animSpeed;								// set the speed of our animator to the public variable 'animSpeed'
		
		transform.rotation = Quaternion.Euler(0F, -90F, 0F);
		
		//transform.Translate(0, 0, -1 * .1F);
		
		
	}
}

