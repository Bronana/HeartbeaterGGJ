using UnityEngine;
using System.Collections;

public class HeartScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine(Kill());
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	IEnumerator Kill() {

        yield return new WaitForSeconds(3);
        Destroy(this.gameObject);
    }
}
