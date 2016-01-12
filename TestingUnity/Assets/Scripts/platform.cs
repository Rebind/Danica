using UnityEngine;
using System.Collections;

public class platform : MonoBehaviour {
	Vector3 vec; 
	public Rigidbody2D rigid;
	// Use this for initialization
	void Start () {
		rigid = GetComponent<Rigidbody2D> ();
		vec = rigid.velocity;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void onCollisionEnter2D(Collision2D col){
		if (col.gameObject.name == "player") {
			vec.y = 0.0f;
			rigid.velocity = vec;
		}
	}
}
