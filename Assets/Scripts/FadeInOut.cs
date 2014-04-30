using UnityEngine;
using System.Collections;

public class FadeInOut : MonoBehaviour {
	private SpriteRenderer spriteRenderer;
	private int fadeDir = -1;
	private float fadeSpeed = 0.2f;
	private float r,g,b;

	// Use this for initialization
	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer>();
		r = spriteRenderer.color.r;
		g = spriteRenderer.color.g;
		b = spriteRenderer.color.b;
		StartCoroutine(FadeInOutRoutine());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator FadeInOutRoutine() {
		while(true) {
			float alpha = spriteRenderer.color.a + (fadeDir * fadeSpeed);
			alpha = Mathf.Clamp01(alpha);
			if(alpha == 0 || alpha == 1) {
				fadeDir *= -1;
			}
			spriteRenderer.color = new Color(r,g,b,alpha);
			yield return new WaitForSeconds(.1f);
		}
	}
}
