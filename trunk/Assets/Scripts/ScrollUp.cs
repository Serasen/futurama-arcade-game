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
			EndGame();
		}
	}

	private void EndGame()
	{
		float flyAwaySpeed = GameObject.Find("approachingObjects").GetComponent<Jeff>().horizontalSpeed * -1;
		GameObject ship = GameObject.Find("ship");
		ship.GetComponent<Move>().enabled = false;
		ship.rigidbody2D.velocity = new Vector2(flyAwaySpeed, 0f);
		GameObject.Find("death planet").collider2D.enabled = false;
	}
}
