using UnityEngine;
using System.Collections;

public class Follow : MonoBehaviour {

	public Transform leader;
	private int xOffset = 5;
	
	// Update is called once per frame
	void Update () {
		if(leader == null) return;
		transform.position = new Vector3(leader.position.x + xOffset, 
		                                 transform.position.y, 
		                                 transform.position.z
		                                 );
	}
}
