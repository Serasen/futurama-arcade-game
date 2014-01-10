using UnityEngine;
using System.Collections;

public class barrel : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D other) {
		Destroy(other.gameObject);
		Destroy(gameObject);
	}

	// Use this for initialization
	void Start () {
		rigidbody2D.AddTorque (10f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
