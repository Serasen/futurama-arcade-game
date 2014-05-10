using UnityEngine;
using System.Collections;

public class Jeff : MonoBehaviour {
	
	public float horizontalSpeed;
	public GameObject space;

	// Use this for initialization
	void Start () {
		rigidbody2D.velocity = new Vector2(horizontalSpeed, 0);
		space = GameObject.Find("space");
	}

	void OnCollisionEnter2D(Collision2D c) {
		c.gameObject.rigidbody2D.velocity = space.rigidbody2D.velocity = Vector2.zero;
	}
}
