using UnityEngine;
using System.Collections;

public class ScrollUp : MonoBehaviour {

	public float scrollSpeed;
	public float maxHeight;

	public void FulfillDestiny() {
		rigidbody2D.velocity = new Vector2(0f,scrollSpeed);
	}

	void Update() {
		if(transform.position.y > maxHeight) {
			rigidbody2D.velocity = Vector2.zero;
		}
	}
}
