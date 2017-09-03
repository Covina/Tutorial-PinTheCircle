using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayConfig : MonoBehaviour {

	// Use this for initialization
	void Start () {

		// set rotation increment
		GameManager.instance.RotationIncreaseIncrement = 5f;

		// Set starting Score
		GameManager.instance.Score = 0;

		// Set starting color index
		GameManager.instance.ColorIndex = 0;


	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
