﻿using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {
	public GameObject explosionPixel;
	public int numPixels;
	public int pixelSpeed;
	public int numExplosions;
	public float explosionOffset;

	void Start() {
		StartCoroutine("Explosions");
	}
	
	IEnumerator Explosions() {
		//GetComponent<move>().enabled = false;
		for(int i = 0; i < numExplosions; i++)
		{
			Explode();
			yield return new WaitForSeconds(explosionOffset);
		}
		Destroy(gameObject);
	}

	private void Explode() {
		for(int i = 0; i < numPixels; i++) 
		{
			GameObject pixel = ((GameObject) Instantiate(explosionPixel, transform.position, Quaternion.Euler(Vector3.zero)));
			pixel.rigidbody2D.velocity = GetRandom2DDirection(pixelSpeed*Random.value);
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
}
