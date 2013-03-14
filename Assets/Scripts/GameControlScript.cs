using UnityEngine;
using System.Collections;

public class GameControlScript : MonoBehaviour {
	public int playerHealth = 100;
	private int score = 0;
	
	bool dead = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void Hit()
	{
		playerHealth -= 10;
		if(playerHealth <= 0)
			dead = true;
		
	}
	
	public void Score()
	{
		score += 10;
		
	}
	
	void OnGUI()
	{
		GUI.Box(new Rect(Screen.width / 2 - 50F, 0, 100, 50), "Health");
		GUI.Label(new Rect(Screen.width / 2 - 20F, 20, 40, 25), playerHealth.ToString());
	}
}
