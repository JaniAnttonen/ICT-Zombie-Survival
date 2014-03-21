using UnityEngine;
using System;

public class Zombie2 : MonoBehaviour {
	
	float Distance;
	public Transform Target1;
	public	float lookAtDistance = 25.0f;
	public float chaseRange = 15.0f;
	public float attackRange = 1.5f;
	public float moveSpeed = 5.0f;
	float Damping = 6.0f;
	public float attackRepeatTime = 1;
	int health = 100;
	int moveTime = 0;

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
	public AudioClip oispa;
	System.Random rnd = new System.Random();
	public bool aani = false;



	// Use this for initialization
	void Start () {
		attackTime = Time.time;
		particlesystem = (ParticleSystem)gameObject.GetComponent("ParticleSystem");
		particlesystem.enableEmission = false;
		particlesystem.startLifetime = 0.5f;
		particleSystem.emissionRate = 200;
		
		Target1 = GameObject.Find("Player").transform;

	}
	
	// Update is called once per frame
	void Update () {
		framecounter++;
		if (framecounter > bloodyframes){
			framecounter = bloodyframes;
		}
		bloody();
		if( health <= 0)
		{
			GameObject.Destroy(gameObject);
		}
		Distance = Vector3.Distance(Target1.position, transform.position);
		
		if (Distance < lookAtDistance || isAttacking)
		{
			lookAt();
		}
		
		if (Distance > lookAtDistance)
		{
			//renderer.material.color = Color.green;
			wonderAround();
		}
		
		if (Distance < attackRange)
		{
			attack();
		}
		else if (Distance < chaseRange  || isAttacking)
		{
			chase ();
		}
	}
	void lookAt (){
		//renderer.material.color = Color.yellow;
		Quaternion rotation = Quaternion.LookRotation(Target1.position - transform.position);
		transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * Damping);
	}

	void chase (){
		isAttacking = true;
		CharacterController controller = GetComponent<CharacterController>();
		//renderer.material.color = Color.red;
	
		moveDirection = transform.forward;
		moveDirection *= moveSpeed;
		
		while(!aani){
		int clipno = rnd.Next(0,2);
			if(clipno==1)
				audio.clip = oispa;
			else
				audio.clip = zombieGrowl;
			audio.Play();
			aani = true;
		}

	
		moveDirection.y -= gravity * Time.deltaTime;
		controller.Move(moveDirection * Time.deltaTime);
	}

	void attack (){
		if (Time.time > attackTime){
			Target1.SendMessage("applyDamage", damage);
		//	Debug.Log("The Enemy Has Attacked");
			
			// Randomize the sound effect of zombie eating player's flesh
			int clipno = rnd.Next(0,2);
			if(clipno==1)
				audio.clip = omNomNom;
			else
				audio.clip = zombieGrowl;
			audio.Play ();
			aani = false;
			

			attackTime = Time.time + attackRepeatTime;
		}
	}

	void applyDamage(int damage){
		isAttacking = true;
		health -= damage;
		moveSpeed -= 1;
		framecounter = 0;

	}
	void wonderAround(){
		CharacterController controller = GetComponent<CharacterController>();
		
		System.Random random = new System.Random();

		if (moveTime > 50){
			int rndNr = random.Next(0,360);
			transform.Rotate(0.0f, rndNr, 0.0f);
			moveTime = 0;
		}else{
		moveTime++;
		moveDirection = transform.forward;
		moveDirection *= moveSpeed;
	
		moveDirection.y -= gravity * Time.deltaTime;
		controller.Move(moveDirection * Time.deltaTime);
		}
	}
	void bloody(){
		if(framecounter < bloodyframes){
			particlesystem.enableEmission = true;
			
			// Randomize the sound effect of zombie getting hit
			int clipno = rnd.Next(0,3);
			if(clipno==1)
				audio.clip = zombieHit;
			if(clipno==2)
				audio.clip = zombieGrowl;
			else
				audio.clip = oispa;
			audio.Play ();
			aani = false;

		}
		if (framecounter >= bloodyframes){
			particlesystem.enableEmission = false;
		}
	}
}