using UnityEngine;
using System.Collections;

public class OpeningSceneAnimationScript : MonoBehaviour {

	private PlayerControlScript pcs;
	private bool startAnimation = false;
	
	// Use this for initialization
	void Start () {
		pcs = GetComponent<PlayerControlScript>();
		//startAnimation = true;
		StartCoroutine(DoRunAnimation());
		StartCoroutine(DoJumpAnimation());
	}
	
	// Update is called once per frame
	void Update () {
		if(startAnimation)
			pcs.SimulateRightHandMovement();
		
		if(Input.anyKeyDown)
			Application.LoadLevel(1);
	}
	
	 IEnumerator DoRunAnimation() {

        yield return new WaitForSeconds(13);
        startAnimation = true;
    }
	
	IEnumerator DoJumpAnimation() {

        yield return new WaitForSeconds(13.22f);
        pcs.SimulateJump();
    }
}
