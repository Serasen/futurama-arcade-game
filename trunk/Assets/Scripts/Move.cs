using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {

	float verticalSpeed = 5f;
	float horizontalSpeed = 10f;

	// Use this for initialization
	void Start () {
		rigidbody2D.velocity = new Vector2(horizontalSpeed, 0);
	}
	
	// Update is called once per frame
	void Update () {
		rigidbody2D.velocity = new Vector2 (rigidbody2D.velocity.x, Input.GetAxis ("Vertical") * verticalSpeed);
	}
}
