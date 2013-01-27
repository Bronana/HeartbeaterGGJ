using UnityEngine;
using System.Collections;

public class OpeningSceneAnimationScript : MonoBehaviour {

	private PlayerControlScript pcs;
	private bool startAnimation = false;
	
	// Use this for initialization
	void Start () {
		pcs = GetComponent<PlayerControlScript>();
		//startAnimation = true;
		StartCoroutine(Do());

	}
	
	// Update is called once per frame
	void Update () {
		if(startAnimation)
			pcs.SimulateRightHandMovement();
	}
	
	 IEnumerator Do() {

        yield return new WaitForSeconds(13);
        startAnimation = true;
    }
}
