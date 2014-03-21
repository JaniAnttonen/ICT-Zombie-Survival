using UnityEngine;
using System.Collections;

public class rotate : MonoBehaviour {
	int rotationSpeed = 100;

	// Update is called once per frame
	void Update () {
		renderer.material.color = Color.black;
		float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
		rotation *= Time.deltaTime;
		rigidbody.AddRelativeTorque(Vector3.back * rotation);
		float rotateDepth = Input.GetAxis("Vertical") * rotationSpeed;
		rotateDepth *= Time.deltaTime;
		rigidbody.AddRelativeTorque(Vector3.right * rotateDepth);
			
		
	
	}
}
