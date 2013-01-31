using UnityEngine;
using System.Collections;

public class ElfAudioScript : MonoBehaviour {
	
	int position;
	AudioSource [] sources;
	
	// Use this for initialization
	void Start () {
		sources = GetComponents<AudioSource>();
		position = (int)Random.Range(0, sources.Length - 1);
		print("playing clip " + position);
		sources[position].Play();
	}
	
	// Update is called once per frame
	void Update () {
		if(!sources[position].isPlaying)
		{
			print("clip done");
			Destroy(this.gameObject);
		}
	}
}
