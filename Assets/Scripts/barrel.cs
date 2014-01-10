using UnityEngine;
using System.Collections;

public class barrel : MonoBehaviour {

	void OnCollisionEnter2D (Collision2D other) {
		if (other.gameObject.tag == "Boundary") 
		{
			Destroy(gameObject);
			return;
		}
		Destroy (other.gameObject);
		Destroy (gameObject);
	}

	// Use this for initialization
	void Start () {
		rigidbody2D.AddTorque (10f);
		Destroy(gameObject, 5);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
