using UnityEngine;
using System.Collections;

public class InstantiateTorsoObj : MonoBehaviour {


	Transform player;
	// Use this for initialization
	void Start () {
		player = GameObject.Find ("ROLLINGHEAD_0").transform;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 pos = player.position;
		if ( Input.GetKeyDown (KeyCode.Alpha1)) {

			//Instantiate (this.gameObject, pos, Quaternion.Euler(0f,0f,0f));
		}
	}
}
