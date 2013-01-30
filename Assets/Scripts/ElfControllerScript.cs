using UnityEngine;
using System.Collections;


public class ElfControllerScript : MonoBehaviour {
	
	public GameObject blood;
	public GameObject heart;
    public AudioClip[] deathSounds;
    public AudioClip[] battleCries;
	public GameControlScript controlScript;
	bool killed = false;
	public float animSpeed = 1f;				// a public setting for overall animator animation speed
	
	private Animator anim;							// a reference to the animator on the character
	//private CapsuleCollider col;
	private AnimatorStateInfo currentBaseState;	

	void Start ()
	{
		// initialising reference variables
		anim = GetComponent<Animator>();
		controlScript = GameObject.Find("GameControl").GetComponent<GameControlScript>();
		//col = GetComponent<CapsuleCollider>();				
	}
	
	
	void FixedUpdate ()
	{
		//anim.SetFloat("Speed", -1);							// set our animator's float parameter 'Speed' equal to the vertical input axis				
		anim.speed = animSpeed;								// set the speed of our animator to the public variable 'animSpeed'
		
		transform.rotation = Quaternion.Euler(0F, -90F, 0F);
		
		//transform.Translate(0, 0, -1 * .1F);
	}
	
	void OnTriggerEnter(Collider other)
	{
		Destroy(collider);
		anim.SetBool("Killed", true);
		Instantiate(blood, transform.position, Quaternion.identity);
		Instantiate(heart, transform.position, Quaternion.identity);
		Destroy(collider);
		StartCoroutine(Kill());
        playRandomDeathSounds();
	}
	
	void OnCollisionEnter(Collision collision)
	{
		print(collision.gameObject.name);
		if(collision.gameObject.name != "Jack") return;
		Destroy(collider);
		anim.SetBool("Killed", true);
		Instantiate(blood, transform.position, Quaternion.identity);
		Instantiate(heart, transform.position, Quaternion.identity);
		Destroy(collider);
		StartCoroutine(Kill());
        playRandomDeathSounds();
		//Destroy(this.gameObject);
		
		controlScript.Hit();
	}
	
	IEnumerator Kill() {

        yield return new WaitForSeconds(1);
        Destroy(this.gameObject);
    }

    void playRandomDeathSounds()
    {
        Instantiate(deathSounds[Random.Range(1, deathSounds.Length)], transform.position, transform.rotation);
    }

    void playRandomBattleCries()
    {
        Instantiate(battleCries[Random.Range(1, battleCries.Length)], transform.position, transform.rotation);
    }
}

