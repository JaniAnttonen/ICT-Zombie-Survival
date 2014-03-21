using UnityEngine;
using System.Collections;

public class DoorWay : MonoBehaviour {

	// Use this for initialization
	void Start () {
	renderer.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void onTriggerEnter(Collider other){
		other.transform.SendMessage("SaveInPos", SendMessageOptions.DontRequireReceiver);
		Debug.Log("Sisällä ollaan");
		
		
	}
	void onTriggerExit(Collider other){
		other.transform.SendMessage("SaveOutPos", SendMessageOptions.DontRequireReceiver);	
	}
	void playerCollided(){
		Debug.Log("Sisällä ollaan");

	}
	void playerTrigger(){
		Debug.Log("Triggeriviesti");
	}
}
