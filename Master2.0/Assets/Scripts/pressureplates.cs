using UnityEngine;
using System.Collections;

public class pressureplates : MonoBehaviour {

	public bool isdown;
	public float distance;
	public Collider2D col;
	// Use this for initialization
	void Start () {
		isdown = false;
		col = GetComponent<Collider2D> ();
		distance = col.bounds.extents.y;
	}
	
	// Update is called once per frame
	void Update () {
		if (check ()) {
			Debug.Log ("pressure plates");
		}
		checking ();
	}
	bool check(){
		return Physics.Raycast(transform.position, -Vector3.up, distance + 0.1f, 0);
	}

	void checking(){
		// Find all colliders that overlap
		BoxCollider2D myCollider = GetComponent<BoxCollider2D>();
		Collider2D[] otherColliders = Physics2D.OverlapAreaAll(myCollider.bounds.min, myCollider.bounds.max);
		
		// Check for any colliders that are on top
		bool isUnderneath = false;
		foreach (var otherCollider in otherColliders)
		{
			if (otherCollider.transform.position.y > this.transform.position.y)
			{
				isUnderneath = true;
				break;
			}
		}
		
		// Take the appropriate action
		if (!isUnderneath)
		{
			Debug.Log("HOORAY!");
			//Destroy(this.gameObject);
		}
		else
		{
			Debug.Log("On top of the box");
		}
	
	}
	/*void onTriggerEnter2D(Collider2D col){
		if (col.gameObject.name == "Player") {
			isdown = true;
			Debug.Log ("Pressure Plates pressed");
		}
	}*/
}
