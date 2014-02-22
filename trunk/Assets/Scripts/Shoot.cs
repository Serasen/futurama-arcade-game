using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {

	public GameObject beam;
	public float speed = 20f;
	public float shootCD = .4f;
	public Transform spawnedObjects;
	private bool ready = true;

	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Jump") && ready)
		{
			GameObject beamInstance = ((GameObject) Instantiate(beam, transform.position + new Vector3(transform.localScale.x*1.3f,0,0), Quaternion.Euler(0,0,0)));;
			beamInstance.rigidbody2D.velocity = new Vector2(speed, 0);
			beamInstance.transform.parent = spawnedObjects;
			ready = false;
			StartCoroutine("ShootCD");
			audio.Play ();
		}
	}

	IEnumerator ShootCD() 
	{
		yield return new WaitForSeconds(shootCD);
		ready = true;
	}
}
