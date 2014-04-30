using UnityEngine;
using System.Collections;

public class StartGame : MonoBehaviour {

	void Update() {
		if(Input.anyKeyDown) Application.LoadLevel("main");
	}
}
