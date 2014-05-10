using UnityEngine;
using System.Collections;

public class StopSign : MonoBehaviour {
	public GameObject gorilla;
	public Transform space;

	void Start() {
		space = GameObject.Find("space").transform;
	}

	void OnTriggerEnter2D(Collider2D c) {
		if(c.gameObject.tag.Equals("Player")) {
			//c.rigidbody2D.velocity = new Vector2(0,0);
			transform.parent.parent.rigidbody2D.velocity = Vector2.zero;
			c.GetComponent<Shoot>().enabled = true;
			gorilla.GetComponent<Animator>().enabled = true;
			space.rigidbody2D.velocity = Vector2.zero;
		}
	}
}
