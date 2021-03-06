﻿using UnityEngine;
using System.Collections;

public class Player_script : MonoBehaviour {

public int Player_Health = 100;
public int Player_Krabul = 10;

public GUIStyle Health_bar_GUI;
public GUIStyle Krabul_bar_GUI;

public Transform player;
public Transform healthBox;

//sound efects
public Vector3 playerInPos;
public AudioClip healthChime;
public Vector3 playerOutPos;
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
//transform.position = new Vector3(100,17,10);
//Player_Health = 100;
Application.LoadLevel("GameOverMenu");

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
// Font size
GUI.skin.box.fontSize = 12;
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
audio.clip = healthChime;
audio.Play();
}
void OnControllerColliderHit (ControllerColliderHit c){
c.gameObject.SendMessage("playerCollided",SendMessageOptions.DontRequireReceiver);
}
void saveInPos(){
playerInPos = transform.position;
Debug.Log("In pos " + playerInPos);
}
void saveOutPos(){
playerOutPos = transform.position;
Debug.Log("Out pos " + playerOutPos);

}
public Vector3 giveInPos(){
return playerInPos;
}
public Vector3 giveOutPos(){
return playerOutPos;
}
void OnTriggerEnter(Collider other){
	other.gameObject.SendMessage("playerTrigger",SendMessageOptions.DontRequireReceiver);
	saveInPos();
}
void OnTriggerExit(Collider other){
	saveOutPos();
	other.gameObject.SendMessage("playerTriggerExit",SendMessageOptions.DontRequireReceiver);

}
}
