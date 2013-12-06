using UnityEngine;
using System.Collections;

public class Zombie : MonoBehaviour {
	
	float Distance;
	public Transform Target;
	public float lookAtDistance = 25.0f;
	public float chaseRange = 15.0f;
	public float attackRange = 1.5f;
	public float moveSpeed = 5.0f;
	float Damping = 6.0f;
	float attackRepeatTime = 1;
	public int health = 100;

	public float damage = 2;

	private float attackTime;
	
	ParticleSystem particlesystem;
	public int framecounter = 5;
	public int bloodyframes = 5;
	
	public bool isAttacking = false;

//	CharacterController controller;

	float gravity = 20.0f;
	Vector3 moveDirection = Vector3.zero;

	//Sound effects
	public AudioClip zombieGrowl;
	public AudioClip omNomNom;
	public AudioClip zombieHit;
	
	// Use this for initialization
	void Start () {
		attackTime = Time.time;
		particlesystem = (ParticleSystem)gameObject.GetComponent("ParticleSystem");
		particlesystem.enableEmission = false;
		particlesystem.startLifetime = 0.5f;
		particleSystem.emissionRate = 200;

	
	}
	
	// Update is called once per frame
	void Update () {
		framecounter++;
		if (framecounter > bloodyframes){
			framecounter = bloodyframes;
		}
		bloody();
		
		if(health <= 0){
			GameObject.Destroy(gameObject);
		}
		Distance = Vector3.Distance(Target.position, transform.position);
		
		if (Distance < lookAtDistance || isAttacking)
		{
			lookAt();
		}
		
		if (Distance > lookAtDistance)
		{
		//	renderer.material.color = Color.green;
		}
		
		if (Distance < attackRange)
		{
			attack();
		}
		else if (Distance < chaseRange || isAttacking)
		{
			chase ();
		}
	}
	void lookAt (){
	//	renderer.material.color = Color.yellow;
		Quaternion rotation = Quaternion.LookRotation(Target.position - transform.position);
		transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * Damping);
	}

	void chase (){
		isAttacking = true;
		CharacterController controller = GetComponent<CharacterController>();
	//	renderer.material.color = Color.red;
	
		moveDirection = transform.forward;
		moveDirection *= moveSpeed;
	
		moveDirection.y -= gravity * Time.deltaTime;
		controller.Move(moveDirection * Time.deltaTime);
	}

	void attack (){
		if (Time.time > attackTime){
			Target.SendMessage("applyDamage", damage);
		//	Debug.Log("The Enemy Has Attacked");
			audio.clip = omNomNom;
			audio.Play ();
			attackTime = Time.time + attackRepeatTime;
		}
	}

	void applyDamage(int damage){
		health -= damage;
		moveSpeed -= 1;
		framecounter = 0;
		isAttacking = true;
	}
	void bloody(){
		if(framecounter < bloodyframes){
			particlesystem.enableEmission = true;
			audio.clip = zombieHit;
			audio.Play ();
		}
		if (framecounter >= bloodyframes){
			particlesystem.enableEmission = false;
		}
	}
}