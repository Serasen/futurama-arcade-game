using UnityEngine;
using System.Collections;

public class Space : MonoBehaviour {

	public Rigidbody2D ship;
	private float speedDifference = 2f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		try {
			var horizontalSpeed = ship.velocity.x - speedDifference;
			if(horizontalSpeed < 0) horizontalSpeed = 0;
			this.rigidbody2D.velocity = new Vector2(horizontalSpeed, 0f);
		}
		catch(MissingReferenceException) {
			this.rigidbody2D.velocity = Vector2.zero;
		}
	}
}
