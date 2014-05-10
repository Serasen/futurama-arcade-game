using UnityEngine;
using System.Collections;

public class StartSign : MonoBehaviour {

	void Start() {
		transform.parent.parent = null;
	}
	
	void OnTriggerEnter2D(Collider2D c) {
		if(c.gameObject.tag.Equals("Player")) {
			c.rigidbody2D.velocity = Vector2.zero;
			GameObject.Find("space").GetComponent<Jeff>().enabled = true;
		}
	}
}
