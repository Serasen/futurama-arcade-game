using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {
	public GameObject explosionPixel;
	public int numPixels;
	public int pixelSpeed;
	public int numExplosions;
	public float explosionOffset;
	public bool iAmDestroyerOfWorlds = false;
	public bool isGorillaExplosion = false;
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
			GameOver();
		}
		else if(isGorillaExplosion) {
			YouWin();
		}
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

	public void GameOver() {
		StartCoroutine("GameOverCoroutine");
	}

	private IEnumerator GameOverCoroutine() {
		yield return new WaitForSeconds(1);
		Transform gameover = transform.Find("gameover");
		gameover.position = Camera.main.ScreenToWorldPoint( new Vector3(Screen.width/2, Screen.height/2, Camera.main.transform.position.z*-1 - 1) );
		gameover.rotation = Quaternion.Euler(Vector3.zero);
		gameover.GetComponent<SpriteRenderer>().enabled = true;
		yield return new WaitForSeconds(2);
		Application.LoadLevel(Application.loadedLevel);
	}

	public void YouWin() {
		StartCoroutine("YouWinCoroutine");
	}
	
	private IEnumerator YouWinCoroutine() {
		yield return new WaitForSeconds(1);
		Transform youwin = transform.Find("youwin");
		youwin.position = Camera.main.ScreenToWorldPoint( new Vector3(Screen.width/2, Screen.height/2, Camera.main.transform.position.z*-1 - 1) );
		youwin.rotation = Quaternion.Euler(Vector3.zero);
		youwin.GetComponent<SpriteRenderer>().enabled = true;
		yield return new WaitForSeconds(2);
		Application.LoadLevel(Application.loadedLevel);
	}
}
