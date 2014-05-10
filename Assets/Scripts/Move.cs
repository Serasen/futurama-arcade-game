using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {

	float verticalSpeed = 5f;
	private float maxHeight = 4.6f;
	private float minHeight = -4.4f;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		rigidbody2D.velocity = new Vector2 (rigidbody2D.velocity.x, Input.GetAxis ("Vertical") * verticalSpeed);
		if(transform.position.y > maxHeight) {
			transform.position = new Vector2(transform.position.x, maxHeight);
		}
		if(transform.position.y < minHeight) {
			transform.position = new Vector2(transform.position.x, minHeight);
		}
	}
}
