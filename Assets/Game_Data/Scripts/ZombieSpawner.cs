using UnityEngine;
using System.Collections;

public class ZombieSpawner : MonoBehaviour {
	
	public GameObject[] goa;
	
	public float spawnRate = 5;
	public float time = 0;
	public float maxSpawnDist = 10;
	Transform target;
	float Damping = 6.0f;
	public float playerDistance;
	// Use this for initialization
	void Start () {
		target = GameObject.Find("Player").transform;
	
	}
	
	// Update is called once per frame
	void Update () {
		if (doISpawnZombies()){
		if (time > spawnRate){
				GameObject go = Instantiate(goa[Random.Range(0, goa.Length)],transform.position, Quaternion.identity) as GameObject;
			time = 0;
		} else{
			time += Time.deltaTime;
	}
		}
	}
	
		bool doISpawnZombies(){
		Quaternion rotation = Quaternion.LookRotation(target.position - transform.position);
		transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * Damping);
		Vector3 fwd = transform.TransformDirection(Vector3.forward);
		playerDistance = Vector3.Distance(target.position, transform.position);
		if (playerDistance < maxSpawnDist){
			//Debug.Log("ei oo suurempi");
			RaycastHit hit;
			if (Physics.Raycast(transform.position,fwd,out hit, playerDistance)){
			//	Debug.Log("osu johonki");
				if (hit.transform != target){
					
					//Debug.Log("There is wall or object between player and zombie");
					return true;
				
				}
			
			}
		}
		return false;
		
	}
}