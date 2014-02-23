using UnityEngine;
using System.Collections;

public class StopSign : MonoBehaviour {
	public GameObject gorilla;

	void OnTriggerEnter2D(Collider2D c) {
		if(c.gameObject.tag.Equals("Player")) {
			c.rigidbody2D.velocity = new Vector2(0,0);
			c.GetComponent<Shoot>().enabled = true;
			gorilla.GetComponent<Animator>().enabled = true;
		}
	}
}
