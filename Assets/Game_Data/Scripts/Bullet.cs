using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
			public int damage = 20;
	
	void OnCollisionEnter(Collision c){
		c.transform.SendMessage("applyDamage", damage, SendMessageOptions.DontRequireReceiver);

		//Destroys bullet when it collides anything
		GameObject.Destroy(gameObject);
	}
	
	void Start(){
		Destroy(gameObject, 5);
	}
}
