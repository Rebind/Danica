using UnityEngine;
using System.Collections;

public class testMovement : MonoBehaviour {

	//Controller controller;
	float speed = 6.0f;
	float jumpSpeed = 8.0f;
	float gravity = 20.0f;

	private Vector3 moveDirection = Vector3.zero;

	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
		CharacterController controller = GetComponent<CharacterController> ();
		if (controller.isGrounded) {
			moveDirection = new Vector3(Input.GetAxis ("Horizontal"), 0,0);
			moveDirection = transform.TransformDirection (moveDirection);
			moveDirection *= speed;

		}
		moveDirection.y -= gravity * Time.deltaTime;
		controller.Move (moveDirection * Time.deltaTime);
	}

	void OnControllerColliderHit(ControllerColliderHit hit){
		if (hit.normal.y < 0.707) {
			print ("Testing");
		}
		if (hit.gameObject.name == "item") {
			print ("Test");
		}
	}
	void OnCollisionEnter2D(Collision2D other){
		if(other.gameObject.name == "item")
			print ("Test");
	}

}
