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
	
		if(destroyed)
		{
			if(++deadCounter == 10)
				Destroy(transform.parent.gameObject);
			else{
				Color originalColor = renderer.material.color;
				renderer.material.color = new Color(originalColor.r, originalColor.g, originalColor.b, 1F - deadCounter * .1F);
			}
			
		}
		
	}
	
	void OnTriggerEnter(Collider other)
	{
		destroyed = true;
		
		Destroy(this.gameObject);
		
		Instantiate(blood, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
	}
}
