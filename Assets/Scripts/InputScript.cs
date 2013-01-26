using UnityEngine;
using System.Collections;

public class InputScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetAxis("horizontal") != 0)
			transform.parent.transform.animation.Play("Run_Impulse");
	}
}
