using UnityEngine;
using System.Collections;

public class animationMovement : MonoBehaviour {
	Animator anim;
	bool animbool;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.D)) {
			anim.CrossFade("run", 0.3f);
			animbool = true;
			Debug.Log("Testing");
			Debug.Log ("whaa");
		}  if(Input.GetKeyUp (KeyCode.D)){
			//anim.StopPlayback ();
			anim.CrossFade ("stay", 0.3f);
		}
	}
}
