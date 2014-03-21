using UnityEngine;
using System.Collections;

public class health : MonoBehaviour {
	
	public int healthAmount = 50;
	public Transform healthGainer;

	// Use this for initialization
  	void OnControllerColliderHit (ControllerColliderHit collision){
		Debug.Log("moi");
		GameObject.Destroy(gameObject);
	}
	void applyDamage(int damage){
		//Debug.Log("somesome");
		healthGainer.SendMessage("applyHealth",SendMessageOptions.DontRequireReceiver);
		GameObject.Destroy(gameObject);
	}
	void playerCollided(){
		healthGainer.SendMessage("applyHealth",SendMessageOptions.DontRequireReceiver);
		GameObject.Destroy(gameObject);
	}
}