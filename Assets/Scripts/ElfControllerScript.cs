using UnityEngine;
using System.Collections;


public class ElfControllerScript : MonoBehaviour {
	
	public GameObject blood;
	public GameObject heart;
	public GameObject deathSounds;
	private GameObject player;
	private PlayerControlScript pScript;
	public GameControlScript controlScript;
	private bool killed = false;
	private bool isRunningLeft = true;
	public float animSpeed = .15f;				// a public setting for overall animator animation speed
	
	private Animator anim;							// a reference to the animator on the character
	//private CapsuleCollider col;
	private AnimatorStateInfo currentBaseState;	

	void Start ()
	{
		// initialising reference variables
		anim = GetComponent<Animator>();
		controlScript = GameObject.Find("GameControl").GetComponent<GameControlScript>();
		player = GameObject.Find("Jack");
		pScript = player.GetComponent<PlayerControlScript>();
		if( transform.position.z < player.transform.position.z)
			isRunningLeft = false;
		
	}
	
	
	void FixedUpdate ()
	{
		//anim.SetFloat("Speed", -1);							// set our animator's float parameter 'Speed' equal to the vertical input axis				
		anim.speed = animSpeed;								// set the speed of our animator to the public variable 'animSpeed'
		
		if(isRunningLeft)
			transform.rotation = Quaternion.Euler(0F, 180F, 0F);
		else
			transform.rotation = Quaternion.Euler(0F, 0F, 0F);
	}
	
	void OnTriggerEnter(Collider other)
	{
		if(!pScript.IsPunching()) return;
		
		Destroy(collider);
		anim.SetBool("Killed", true);
		
		Instantiate(blood, transform.position, Quaternion.identity);
		var temp = (GameObject)Instantiate(heart, transform.position, Quaternion.identity);
		temp.rigidbody.AddForce(0f, 1f, 0f);
		
		controlScript.Score();
		
		StartCoroutine(Kill());
        playRandomDeathSounds();
	}
	
	void OnCollisionEnter(Collision collision)
	{
		if(collision.gameObject.name != "Jack") return;
		
		Destroy(collider);
		anim.SetBool("Killed", true);
		
		Instantiate(blood, transform.position, Quaternion.identity);
		var temp = (GameObject)Instantiate(heart, transform.position, Quaternion.identity);
		temp.rigidbody.AddForce(0f, 1f, 0f);
		
		StartCoroutine(Kill());
        playRandomDeathSounds();
		
		if(pScript.IsJumping())
			controlScript.Score();
		else
			controlScript.Hit();
	}
	
	IEnumerator Kill() {

        yield return new WaitForSeconds(1);
        Destroy(this.gameObject);
    }
	
	void playRandomDeathSounds()
	{
		if(Random.Range(0, 40) < 10)
			Instantiate(deathSounds, transform.position, Quaternion.identity);
	}
}

