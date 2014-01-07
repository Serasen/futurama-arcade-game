using UnityEngine;
using System.Collections;

public class move : MonoBehaviour {

	float speed = 10f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		rigidbody2D.velocity = new Vector2 (0, Input.GetAxis ("Vertical") * speed);
	}
}
