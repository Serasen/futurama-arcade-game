using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {
	public GameObject explosionPixel;
	public int numPixels;
	public int pixelSpeed;
	public int numExplosions;
	public float explosionOffset;
	public bool iAmDestroyerOfWorlds = false;
	public Transform spawnedObjects;

	void Start() {
		StartCoroutine("Explosions");
	}
	
	IEnumerator Explosions() {
		for(int i = 0; i < numExplosions; i++)
		{
			Explode();
			yield return new WaitForSeconds(explosionOffset);
		}
		if(iAmDestroyerOfWorlds) {
			yield return new WaitForSeconds(2);
			GameOver();
		}
		Destroy(gameObject);
	}

	private void Explode() {
		for(int i = 0; i < numPixels; i++) 
		{
			GameObject pixel = ((GameObject) Instantiate(explosionPixel, transform.position, Quaternion.Euler(Vector3.zero)));
			pixel.rigidbody2D.velocity = GetRandom2DDirection(pixelSpeed*Random.value);
			pixel.transform.parent = spawnedObjects;
		}

	}

	private Vector2 GetRandom2DDirection(float speed) {
		var y = Random.Range(-speed,speed);
		int xDirection = CoinFlip()? -1 : 1;
		var x = xDirection * Mathf.Sqrt(speed * speed - y * y);
		return new Vector2(x,y);
	}

	private bool CoinFlip() {
		return Random.value >= 0.5;
	}

	private void GameOver() {
		Application.LoadLevel(Application.loadedLevel);
	}
}
