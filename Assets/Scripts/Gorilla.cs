using UnityEngine;
using System.Collections;

public class Gorilla : MonoBehaviour {
	public Rigidbody2D barrel;
	public Transform spawnedObjects;
	Animator animator;
	bool ready = true;
	int speed = 5;
	int health = 10;
	public Texture youWinTexture;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
	}

	// Gives gorilla health, destroy gorilla if health equal 0
	void OnCollisionEnter2D (Collision2D other){
		if(other.gameObject.tag.Equals("Beam")){
			health = health - 1;
			Destroy (other.gameObject);
			if (health == 0) {
				Die();
				}
			}
		}

	// Update is called once per frame
	void Update () {
		if(animator.GetCurrentAnimatorStateInfo(0).IsName("Blend Tree"))
		{
			if(ready) 
			{
				// Generates a value between -4 and 4 (the upper bound of a random range is never hit)
				var y = Random.Range(-speed+1,speed);
				Rigidbody2D barrelRB = (Instantiate(barrel, transform.position + new Vector3(-transform.localScale.x*1.6f,transform.localScale.y*1.4f,0), Quaternion.Euler(Vector3.zero)) as Rigidbody2D);
				barrelRB.velocity = new Vector2(-Mathf.Sqrt(speed * speed - y * y),y);
				barrelRB.gameObject.transform.parent = spawnedObjects;
				ready = false;
			}
		}
		else 
		{
			ready = true;
		}
	}

	void Die ()
	{
		GetComponent<ExplosionCreator>().CreateExplosion(this.transform.position);
	}
}
