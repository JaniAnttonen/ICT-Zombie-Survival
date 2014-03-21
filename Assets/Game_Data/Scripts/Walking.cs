using UnityEngine;
using System.Collections;

public class Walking : MonoBehaviour {
	
	public AudioClip sound;
	public float timer = 100.0f;
	public float clipLength;
	
	void Start() {
		audio.clip = sound;
		clipLength = sound.length + 0.2f;
	}
	
	void Update () {
		timer += Time.deltaTime;
		 
		if(Input.GetAxis("Horizontal") != 0.0f || Input.GetAxis("Vertical") != 0.0f){
			if(timer >= clipLength){
				audio.clip = sound;
				audio.PlayOneShot(sound); 
				audio.Play(); 
				timer = 0.0f;
			}
		}
	}
	
}

