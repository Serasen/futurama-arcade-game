using UnityEngine;
using System.Collections;

public class shoot : MonoBehaviour {

	public GameObject beam;
	float speed = 20f;
	bool ready = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire1") && ready)
		{
			((GameObject) Instantiate(beam, transform.position + new Vector3(transform.localScale.x*1.3f,0,0), Quaternion.Euler(0,0,0))).rigidbody2D.velocity = new Vector2(speed, 0);
			ready = false;
			StartCoroutine("ShootCD");

		}
	}

	IEnumerator ShootCD() 
	{
		yield return new WaitForSeconds(.2f);
		ready = true;
	}
}
