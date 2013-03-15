using UnityEngine;
using System.Collections;

public class ElfGenerator : MonoBehaviour {

	public GameObject elf;
	public GameObject player;
	public GameObject elfBattleCry;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if(Random.Range(0F, 750F) < 5F)
		{
			//Instantiate(elf, new Vector3(player.transform.position.x + 2F, player.transform.position.y, player.transform.position.z), Quaternion.Euler(0, -90, 0));
			int temp = Random.Range(0, 2);
			float posz = player.transform.position.z + (10F - (20F * temp));
			if(posz > 57) posz = 57f;
			if(posz < -3.8) posz = -3.8f;
			
			Instantiate(elf, new Vector3(player.transform.position.x, .33f, posz), Quaternion.identity);
			
			if(Random.Range(0, 40) < 10)
				Instantiate(elfBattleCry, transform.position, Quaternion.identity);
		}
		
	}
}
