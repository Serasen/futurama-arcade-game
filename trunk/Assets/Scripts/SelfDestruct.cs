using UnityEngine;
using System.Collections;

public class SelfDestruct : MonoBehaviour {
	public float lifeSpan;
	public bool destructsOnHit;

	// Use this for initialization
	void Start () {
		Destroy(gameObject, lifeSpan);
	}
	
	void OnCollisionEnter2D() {
		if(destructsOnHit) Destroy(gameObject);
	}
}
