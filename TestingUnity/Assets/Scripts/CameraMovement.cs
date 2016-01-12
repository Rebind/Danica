using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {
	Transform player;
	// Use this for initialization
	void Start () {
		player = GameObject.Find ("ROLLINGHEAD_0").transform;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 playerpos = player.position;
		playerpos.z = transform.position.z;
		transform.position = playerpos;
	}
}
