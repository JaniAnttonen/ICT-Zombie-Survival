using UnityEngine;
using System.Collections;
using System;

public class NewBehaviourScript : MonoBehaviour {
	
	public float moveSpeed = 5.0f;
	public Transform Target;
	public float Damping = 6.0f; 
	public int moveTime = 50;
	public int counter = 0;
	System.Random random = new System.Random();
	float distance;
	public float lookAtDistance = 50;
	public bool isAttacking = false;


	// Update is called once per frame
	void Update () {
		distance = Vector3.Distance(Target.position, transform.position);
	
		if (distance < lookAtDistance || isAttacking){
			lookAt();
			attack();
		}
		else{
		
				if (counter < moveTime){
			counter ++;
			transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
		} else {
			int randomNumber = random.Next(0, 360);
			transform.Rotate(0.0f, randomNumber, 0.0f);
			counter = 0;
		}
		}
	}
	void lookAt (){
	Quaternion rotation = Quaternion.LookRotation(Target.position - transform.position);
	transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * Damping);
		}
	void attack(){
		transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
		isAttacking = true;
	}
	
}
