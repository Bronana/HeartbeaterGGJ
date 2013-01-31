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
	
		if(Random.Range(0F, 500F) < 10F)
		{
			//Instantiate(elf, new Vector3(player.transform.position.x + 2F, player.transform.position.y, player.transform.position.z), Quaternion.Euler(0, -90, 0));
			Instantiate(elf, new Vector3(player.transform.position.x + 10F, player.transform.position.y, player.transform.position.z), Quaternion.identity);
			
			if(Random.Range(0, 40) < 10)
				Instantiate(elfBattleCry, transform.position, Quaternion.identity);
		}
		
	}
}
