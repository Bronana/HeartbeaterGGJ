using UnityEngine;
using System.Collections;

public class GameOverScript : MonoBehaviour {
	
	public Texture texture;
	private int score;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI()
	{
		GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), texture);
		GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height - 300, 100, 25), "Score: " + PlayerPrefs.GetInt("score").ToString());
		if(GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height - 100, 100, 25), "Play Again"))
		{
			Application.LoadLevel(0);
			PlayerPrefs.DeleteAll();
		}
	}
}
