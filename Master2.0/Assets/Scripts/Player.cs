﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Controller2D))]
public class Player : MonoBehaviour
{
    [SerializeField]
    private float jumpHeight;

    private float timeToJumpApex = .4f;

    [SerializeField]
    private float moveSpeed;

    private float gravity;

    private float jumpVelocity;

    private Vector3 playerVelocity;

    private Controller2D myController;
    private Animator myAnimator;
    private bool canJump;
	private SpriteRenderer renderer;

    void Start()
    {
        myAnimator = GetComponent<Animator>();
		renderer = GetComponent<SpriteRenderer> ();
        myController = GetComponent<Controller2D>();
        gravity = -(2 * jumpHeight) / Mathf.Pow(timeToJumpApex, 2);
        jumpVelocity = Mathf.Abs(gravity * timeToJumpApex);
    }

    void Update()
    {
        HandleMovments();
        HandleInputs();
		//nearObject ();
		if (Input.GetKeyDown (KeyCode.F)) {
			StartCoroutine("Fade");
		}
		//onTopOfPressurePlates ();
    }

    private void HandleMovments()
    {
        if (myController.collisions.above || myController.collisions.below)
        {
            playerVelocity.y = 0;
        }

        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")); //get input from the player (left and Right Keys)

        if (Input.GetKeyDown(KeyCode.Space) && myController.collisions.below)  //if spacebar is pressed, jump
        {
            playerVelocity.y = jumpVelocity;
        }
        playerVelocity.x = input.x * moveSpeed;

        playerVelocity.y += gravity * Time.deltaTime;
        myController.Move(playerVelocity * Time.deltaTime);
        myAnimator.SetFloat("speed", Mathf.Abs(Input.GetAxis("Horizontal")));

    }

    private void HandleInputs()
    {

    }
	IEnumerator Fade() {
		for (float f = 1f; f >= 0; f -= 0.01f) {
			Color c = renderer.material.color;
			c.a = f;
			renderer.material.color = c;
			yield return null;
		}
		yield return new WaitForSeconds (1.0f);
		Application.LoadLevel ("ninja");


	}

	/*void nearObject(){
		GameObject[] obstacles = GameObject.FindGameObjectsWithTag ("obstacle");

		for (int i = 0; i < obstacles.Length; ++i) {
			
			if (Vector3.Distance (transform.position, obstacles [i].transform.position) <= 1.5f) {
				Debug.Log ("testing in here");
				StartCoroutine("Fade");
				moveSpeed = 0;

			}
		}
	}*/

	//Players trigger lever
	void nearLever(){
		GameObject[] levers = GameObject.FindGameObjectsWithTag ("lever");
		
		for (int i = 0; i < levers.Length; ++i) {
			
			if (Vector3.Distance (transform.position, levers [i].transform.position) <= 1.5f) {
				//Player presses lever, and it does something. 
				Debug.Log ("Lever pressed. Some boolean to keep track of lever");
				//Instantiate(this.gameObject, this.transform.position, Quaternion.identity);
			}
		}
	}

}

