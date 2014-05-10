using UnityEngine;
using System.Collections;

public class ScrollUp : MonoBehaviour {

	public float scrollSpeed;

	public void FulfillDestiny() {
		rigidbody2D.velocity = new Vector2(0f,scrollSpeed);
	}
}
