using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {

	float verticalSpeed = 5f;
	float horizontalSpeed = 10f;
	private float maxHeight = 3.5f;
	private float minHeight = -3.4f;

	// Use this for initialization
	void Start () {
		rigidbody2D.velocity = new Vector2(horizontalSpeed, 0);
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
