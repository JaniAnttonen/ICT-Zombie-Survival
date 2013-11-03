using UnityEngine;
using System.Collections;

public class Player_script : MonoBehaviour {
	
	public int Player_Health = 100;
	public int Player_Food = 10;
	
	public GUIStyle Health_bar_GUI;
	public GUIStyle Foor_bar_GUI;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//Health monitoring
		if(Player_Health > 100){
			Player_Health = 100;
		}
		if(Player_Health < 0){
			Player_Health =0;
		}
		//Food monitoring
		if(Player_Food > 10){
			Player_Food = 10;
		}
		if(Player_Food < 0){
			Player_Food = 0;
		}	
	}
	
	void OnGUI(){
		//Health bar
		GUI.Box( new Rect(5,5,Screen.width/10,20), "Health");
		GUI.Box( new Rect(Screen.width/10+10 ,5,Screen.width /3 /(100/Player_Health),20), "" + Player_Health, Health_bar_GUI);
		
		//Food bar
		GUI.Box( new Rect(5,30,Screen.width/10,20), "Food");
		GUI.Box( new Rect(Screen.width/10+10 ,30,Screen.width /(100/Player_Food),20), "" + Player_Food, Foor_bar_GUI);
	}
}
	

