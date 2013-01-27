using UnityEngine;
using System.Collections;

public class CharacterMover : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		transform.position = new Vector3(transform.position.x + Input.GetAxis("Horizontal") * .5F , transform.position.y, transform.position.z);
	}
}
