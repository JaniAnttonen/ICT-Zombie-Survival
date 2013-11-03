using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	
	void OnCollisionEnter(Collision c){
		
		//Destroys bullet when it collides anything
		GameObject.Destroy(gameObject);
	}
	
	void Start(){
		Destroy(gameObject, 5);
	}
}
