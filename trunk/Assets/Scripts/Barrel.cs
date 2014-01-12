using UnityEngine;
using System.Collections;

public class Barrel : MonoBehaviour {

	// Use this for initialization
	void Start () {
		rigidbody2D.AddTorque (10f);
	}
}
