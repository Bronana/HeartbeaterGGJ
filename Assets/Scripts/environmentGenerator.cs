using UnityEngine;
using System.Collections;

public class environmentGenerator : MonoBehaviour {

    public GameObject backTree1;
	public GameObject backTree2;
	public GameObject frontTree1;
	public GameObject frontTree2;
    public GameObject cloud;
	public float boardStart = -7.3F;
	public float boardEnd = 80.0F;
	

	// Use this for initialization
	void Start () 
    {
        for (float i = boardStart; i < boardEnd; i += Random.Range(3, 10)){
           Instantiate(backTree1, new Vector3(backTree1.transform.position.x,
				backTree1.transform.position.y, i), backTree1.transform.rotation);
		}
		for (float i = boardStart + 5; i < boardEnd; i += Random.Range(5, 15)){
            Instantiate(backTree2, new Vector3(backTree2.transform.position.x,
				backTree2.transform.position.y, i), backTree2.transform.rotation);
		}
		for (float i = boardStart + 2; i < boardEnd; i += Random.Range(14, 22)){
            Instantiate(frontTree1, new Vector3(frontTree1.transform.position.x,
				frontTree1.transform.position.y, i), frontTree1.transform.rotation);
		}
		
		for (float i = boardStart + 7; i < boardEnd; i += Random.Range(17, 28)){
            Instantiate(frontTree2, new Vector3(frontTree2.transform.position.x,
				frontTree2.transform.position.y, i), frontTree2.transform.rotation);
		}
		
		for (float i = boardStart - 7; i < boardEnd + 7; i += Random.Range(5, 11)){
            Instantiate(cloud, new Vector3(cloud.transform.position.x,
				cloud.transform.position.y + Random.Range(-1.5F, 1.5F), i), cloud.transform.rotation);
		}

	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}
}
