﻿using UnityEngine;
using System.Collections;

public class StartGame : MonoBehaviour {
	public GameObject theGameItself;

	void Update() {
		if(Input.anyKey) {
			InitializeGame();
		}
	}

	private void InitializeGame() {
		Instantiate(theGameItself);
		Destroy(gameObject);
	}
}
