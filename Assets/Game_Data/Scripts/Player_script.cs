using UnityEngine;
using System.Collections;

public class Player_script : MonoBehaviour {
	
	public int Player_Health = 100;
	public int Player_Krabul = 10;
	
	public GUIStyle Health_bar_GUI;
	public GUIStyle Krabul_bar_GUI;
	
	public Transform transform;
	public Transform healthBox;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//Health monitoring
		if(Player_Health > 100){
			Player_Health = 100;
		}
		if(Player_Health <= 0){
			Player_Health =0;
			transform.position = new Vector3(100,17,10);
			Player_Health = 100;
			
		}
		//Krabul monitoring
		if(Player_Krabul > 10){
			Player_Krabul = 10;
		}
		if(Player_Krabul < 0){
			Player_Krabul = 0;
		}	
	}
	
	void OnGUI(){
		int p_health;
		if (Player_Health <= 0){
			p_health = 1;
		}else{
			p_health = 100/Player_Health;
			if (p_health <= 0){
				p_health = 1;
			}
		}
		
		//Health bar
		GUI.Box( new Rect(5,5,Screen.width/10,20), "Health");
		GUI.Box( new Rect(Screen.width/10+10 ,5,Screen.width /3 /(p_health),20), "" + Player_Health, Health_bar_GUI);
		
		//Krabul bar
		GUI.Box( new Rect(5,30,Screen.width/10,20), "Krabul");
		GUI.Box( new Rect(Screen.width/10+10 ,30,Screen.width /(100/Player_Krabul),20), "" + Player_Krabul, Krabul_bar_GUI);
	}
	void applyDamage(int damage){
		Player_Health -= damage;
	}
	void applyHealth(){
		Player_Health += 25;
	}
	void OnControllerColliderHit (ControllerColliderHit c){
		c.gameObject.SendMessage("playerCollided",SendMessageOptions.DontRequireReceiver);
	}
	
}
	

