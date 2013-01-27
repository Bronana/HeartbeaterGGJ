using UnityEngine;
using System.Collections;

public class environmentGenerator : MonoBehaviour {

    public GameObject mountain;
    public GameObject tree;
    public GameObject cloud1;
    public GameObject cloud2;
    public GameObject groundTile;
    public int numMountains = 100;
    public int numTree = 200;
    public int numCloud1 = 25;
    public int numCloud2 = 25;
    public int numTiles = 500;

	// Use this for initialization
	void Start () 
    {
        for (int i = 0; i < numTiles; i++)
            Instantiate(groundTile, new Vector3(-7 + i * .5f, 0, 4), Quaternion.identity);

        for (int i = 0; i < numMountains; i++)
            Instantiate(mountain, new Vector3(-6.5f + i * 10f, 0.2f, 8.2f), Quaternion.identity);

        for (int i = 0; i < numTree; i++)
            Instantiate(tree, new Vector3(-4.4f + i * 20f, 1f, 7.9f), Quaternion.identity);

        for (int i = 0; i < numCloud1; i++)
            Instantiate(cloud1, new Vector3(-6.7f + i * 5f, 1.4f, 4.8f), Quaternion.identity);

        for (int i = 0; i < numCloud2; i++)
            Instantiate(cloud2, new Vector3(-3.7f + i * 5f, 3.0f, 5.1f), Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}
}
