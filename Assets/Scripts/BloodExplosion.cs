using UnityEngine;
using System.Collections;

public class BloodExplosion : MonoBehaviour {
	
	public GameObject blood;
	private bool destroyed  = false;
	private int deadCounter = 0;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter(Collider other)
	{
		Destroy(other.gameObject);
		//destroyed = true;
		transform.parent.transform.animation.Play("death");
		Destroy(collider);
		
		Instantiate(blood, new Vector3(transform.position.x, transform.position.y + 1.5F, transform.position.z), Quaternion.identity);
	}
}
