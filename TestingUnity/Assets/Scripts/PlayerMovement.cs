using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {


	//Sprite player = Resources.Load <Sprite> ("Sprite/block_1");
	public float playerSpeed = 6f;
	public float rolling;
	private bool collision = false;
	public float gravity = 0.5f;
	public float jumpSpeed = 5f;
	public float jumpHeight = 0.02f;
	public Rigidbody2D rb;
	//private SpriteRenderer spriteRenderer; 
	SpriteRenderer sprRend; 
	float num;
	//LegObject leg;
	//GameObject testArms;
	public Sprite head; // No file extension.
	bool canJump = false;
	Vector3 v;

	//private bool isFalling = false;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		 v = rb.velocity;
//		Arms test = new Arms ();
		//testArms = GameObject.Find ("Arm");
		Arms testing = GetComponent<Arms> ();
		num = testing.armCount;
		this.GetComponent<SpriteRenderer> ().sprite = head;
		/*sprRend = GetComponent<SpriteRenderer> ();
		test = sprRend.sprite = 
			Resources.Load<Sprite>("alienRunin2_9"); */
		//anim = GetComponent<Animator> ();
	}



	// Update is called once per frame
	//In this update function call the other functions
	void Update () {
		Movement ();
		//Debug.Log (num + "Testing class");


	}


	//Moving the character
	void Movement(){
		if (Input.GetKey (KeyCode.D))
			transform.position += new Vector3(playerSpeed * Time.deltaTime, 0.0f, 0.0f);
		if (Input.GetKey (KeyCode.A))
			transform.position -= new Vector3(playerSpeed * Time.deltaTime, 0.0f, 0.0f);
		if (Input.GetKey (KeyCode.W) && canJump) {
			rb.gravityScale = 0.08f;
			v.y = jumpHeight;
			rb.velocity= v;
			canJump = false; //Disable jumping until landing
		}
		if (canJump) {
			v.y = 0.0f;
			rb.velocity = v;
		}
		if (Input.GetKeyDown (KeyCode.X)) {
			//Application.LoadLevel("Testing");
			//anim.Play("test");
		}
	}
	

	//Colliding with objects on screen
	void OnCollisionEnter2D(Collision2D col){
		//Debug.Log ("TESTING");
		if(col.gameObject.name == "item"){

			Destroy (col.gameObject);
			//Application.LoadLevel ("Testing");
			Debug.Log("TRUE, YA KNOW");
			//add a sprite here for the attachment?
		}
		if (col.gameObject.tag == "ground") {
			//Destroy (col.gameObject);
			canJump = true;
			Debug.Log ("Where you at?");
		}
	
	}



}
