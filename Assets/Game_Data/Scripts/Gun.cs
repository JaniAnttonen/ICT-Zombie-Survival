using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour {
	
	public Rigidbody bullet;
	public float speed = 50f;
	public AudioClip gunShot;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Fire1")){
			Rigidbody inp = Instantiate(bullet, transform.position, transform.rotation) as Rigidbody;
			inp.velocity = transform.TransformDirection(new Vector3(0,0,speed));
			audio.clip = gunShot;
			audio.Play();
		}	
	}
}