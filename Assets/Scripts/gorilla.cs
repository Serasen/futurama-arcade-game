using UnityEngine;
using System.Collections;

public class gorilla : MonoBehaviour {
	public Rigidbody2D barrel;
	Animator animator;
	bool ready = true;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(animator.GetCurrentAnimatorStateInfo(0).IsName("Blend Tree"))
		{
			if(ready) 
			{
				(Instantiate(barrel, transform.position + new Vector3(-transform.localScale.x*1.6f,transform.localScale.y*1.4f,0), Quaternion.Euler(Vector3.zero)) as Rigidbody2D).velocity = new Vector2(-10f,0);
				ready = false;
			}
		}
		else 
		{
			ready = true;
		}
	}
}
