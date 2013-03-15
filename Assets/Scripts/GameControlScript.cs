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
		{
			PlayerPrefs.SetInt("score", score);
			Application.LoadLevel(2);
			
		}
		
	}
	
	public void Score()
	{
		score += 10;
		
	}
	
	void OnGUI()
	{
		GUI.Box(new Rect(20, 20, 200, 100), "");
		GUI.Label(new Rect(30, 25, 190, 25), "Health: " + playerHealth.ToString());
		GUI.Label(new Rect(30, 50, 190, 50), "Organs freed from elvish captivity: " + score.ToString());
	}
}
