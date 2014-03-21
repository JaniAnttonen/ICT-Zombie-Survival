using UnityEngine;
using System.Collections;

public class ICTZS_startScreen : MonoBehaviour {
	public int frameCounter = 100;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		frameCounter--;
			if (frameCounter <= 0){
				 Application.LoadLevel("Level1");
		}
	
	}
}
