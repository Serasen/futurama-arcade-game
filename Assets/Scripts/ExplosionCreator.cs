using UnityEngine;
using System.Collections;

public class ExplosionCreator : MonoBehaviour {
	public GameObject explosionPixel;
	public int numPixels;
	public int pixelSpeed;
	public int numExplosions;
	public float explosionOffset;
	public string explosionCauserTag;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void OnCollisionEnter2D (Collision2D other) {
		if(other.gameObject.tag.Equals(explosionCauserTag))
			CreateExplosion();
	}

	private void CreateExplosion() {
		GameObject explosion = Instantiate(new GameObject(), transform.position, transform.rotation) as GameObject;
		Explosion explodeScript = explosion.AddComponent<Explosion>();
		explodeScript.explosionPixel = this.explosionPixel;
		explodeScript.numPixels = this.numPixels;
		explodeScript.pixelSpeed = this.pixelSpeed;
		explodeScript.numExplosions = this.numExplosions;
		explodeScript.explosionOffset = this.explosionOffset;
		explodeScript.StartCoroutine("Explosions");
		Destroy(gameObject);
	}
}
