using UnityEngine;
using System.Collections;

public class GroundGenerator : MonoBehaviour {
	
	public GameObject ground;
	public int tiles = 40;
	Vector3 initialPosition = new Vector3(-5F, -.5F, -10F);
	
	// Use this for initialization
	void Start () {
			
		for(int i = 0; i < tiles; i++)
			Instantiate(ground, new Vector3(initialPosition.x + i * .5F, initialPosition.y, initialPosition.z), Quaternion.identity); 
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
