using UnityEngine;
using System.Collections;

public class pressureplates : MonoBehaviour {

	public bool isdown;
	public bool moveDoor;
	public bool movePlatform;
	public GameObject col;
	// Use this for initialization
	void Start () {
		isdown = false;
	}
	
	// Update is called once per frame
	void Update () {
		checking ();
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
				col = otherCollider.gameObject;
				break;
			} 
		}
		
		// if players are on top of the pressure plates
		if (!isUnderneath)
		{
			Debug.Log("HOORAY!");
			//Destroy(this.gameObject);
		}
		else
		{
			if(col.name == "open door"){
				moveDoor = true;
			}
			else if(col.name == "move platform"){
				movePlatform = true;
			}
			//have boolean that triggers the whatever pressure plate is doing
			Debug.Log("On top of box");
		}
	
	}
}
