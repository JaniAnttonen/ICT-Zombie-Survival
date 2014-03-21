using UnityEngine;
using System.Collections;

public class PopUpMsg : MonoBehaviour {
	
	public string msg;
	public bool showMsg = false;
	public int buttonW = 200;
	public int buttonH = 100;
	public int fontSize = 16;
	
	// Use this for initialization
	void Start () {
		renderer.enabled = false;
		msg = msg.Replace("NEWLINE","\n");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI(){
		if(showMsg){
			GUI.skin.box.fontSize = fontSize;

			GUI.Box (new Rect ((Screen.width /2) - (buttonW /2),(Screen.height /2) - (buttonH / 2), buttonW, buttonH), msg);
			}
		
	}
	
	void playerTrigger(){
		showMsg = true;
	}
	void playerTriggerExit(){
		showMsg = false;
	}
}
