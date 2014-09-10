using UnityEngine;
using System.Collections;

public class Gorilla : MonoBehaviour {
	public Rigidbody2D barrel, barrelRB;
	public Transform spawnedObjects;
	Animator animator;
	int speed = 5;
	int health = 50;
	public Texture youWinTexture;
	public AudioClip gorillaSound;
	public AudioClip pulloutSound;
	SpriteRenderer spriteRenderer;
	Color flashOnHitColor = Color.red;
	float flashDuration = .1f;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		spriteRenderer = GetComponent<SpriteRenderer>();
	}

	// Gives gorilla health, destroy gorilla if health equal 0
	void OnCollisionEnter2D (Collision2D other){
		if(other.gameObject.tag.Equals("Beam")){
			health = health - 1;
			StartCoroutine(FlashOnHit());
			Destroy (other.gameObject);
			if (health == 0) {
				Die();
			}
		}
	}

	IEnumerator FlashOnHit()
	{
		spriteRenderer.color = flashOnHitColor;
		yield return new WaitForSeconds(flashDuration);
		spriteRenderer.color = Color.white;
	}

	void SpawnBarrel()
	{
		barrelRB = (Instantiate(barrel, transform.position + new Vector3(-.05f,.8f,0), Quaternion.Euler(Vector3.zero)) as Rigidbody2D);
	}

	void ThrowBarrel()
	{
		int y;
		if(Random.value > .5) {
			// Half the time we want to hit this sweet spot
			// It is the one angle that hits the player when he is in a sweet spot that he can safely shoot all other barrels from
			y = speed -1;
		}
		else
		{
			// Generates a value between -3 and 4 (the upper bound of a random range is never hit)
			y = Random.Range(-speed+2,speed);
		}

		if(barrelRB != null) {
			barrelRB.velocity = new Vector2(-Mathf.Sqrt(speed * speed - y * y),y);
			barrelRB.gameObject.transform.parent = spawnedObjects;
			barrelRB.AddTorque(10f);
			barrelRB.gravityScale = 0.5f;
		}

		PlayGorillaSound();
	}

	void Die ()
	{
		Destroy (barrelRB.gameObject);
		GetComponent<ExplosionCreator>().CreateExplosion(this.transform.position - new Vector3(0, 1f));
	}

	void PlayGorillaSound()
	{
		audio.clip = gorillaSound;
		audio.Play();
	}

	void PlayPulloutSound()
	{
		audio.clip = pulloutSound;
		audio.Play();
	}
}
