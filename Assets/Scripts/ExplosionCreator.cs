﻿using UnityEngine;
using System.Collections;

public class ExplosionCreator : MonoBehaviour {
	public GameObject explosionPixel;
	public GameObject explosionPrefab;
	public int numPixels;
	public int pixelSpeed;
	public int numExplosions;
	public float explosionOffset;
	public string explosionCauserTag;
	public Transform spawnedObjects;

	// Use this for initialization
	void Start () {
		if(spawnedObjects == null) {
			spawnedObjects = GameObject.Find("spawnedObjects").transform;
		}
	}
	
	// Update is called once per frame
	void OnCollisionEnter2D (Collision2D other) {
		if(other.gameObject.tag.Equals(explosionCauserTag))
			CreateExplosion(other.contacts[0].point);
	}

	public void CreateExplosion(Vector2 explosionPosition) {
		GameObject explosion = Instantiate(explosionPrefab, explosionPosition, transform.rotation) as GameObject;
		explosion.transform.parent = spawnedObjects;
		Explosion explodeScript = explosion.GetComponent<Explosion>();
		explodeScript.explosionPixel = this.explosionPixel;
		explodeScript.numPixels = this.numPixels;
		explodeScript.pixelSpeed = this.pixelSpeed;
		explodeScript.numExplosions = this.numExplosions;
		explodeScript.explosionOffset = this.explosionOffset;
		explodeScript.spawnedObjects = this.spawnedObjects;
		if(gameObject.tag.Equals("Player")) {
			explodeScript.iAmDestroyerOfWorlds = true;
		}
		else if(gameObject.tag.Equals("Gorilla")) {
			explodeScript.isGorillaExplosion = true;
		}
		Destroy(gameObject);
	}

	public float TotalExplosionTime() {
		return explosionOffset*numExplosions;
	}
}
