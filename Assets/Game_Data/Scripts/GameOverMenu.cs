using UnityEngine;
using System.Collections;

public class GameOverMenu : MonoBehaviour {
	

	public int buttonW = 200;
	public int buttonH = 100;
	public int boxW = 400;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI(){
		//print(GUI.skin.box.fontSize);
		GUI.skin.box.fontSize = 24;
		GUI.Box(new Rect((Screen.width /2)- (boxW/2), 200, boxW, 200),"Game over");
		if (GUI.Button (new Rect ((Screen.width /2) - (buttonW /2),(Screen.height /2) - (buttonH / 2), buttonW, buttonH), "Play again")) {
			Application.LoadLevel("Level1");
		}
		if (GUI.Button (new Rect ((Screen.width /2) - (buttonW /2),(Screen.height /2) - (buttonH / 2) + buttonH, buttonW, buttonH), "Exit")) {
			Application.Quit();
		}	}
	
}
