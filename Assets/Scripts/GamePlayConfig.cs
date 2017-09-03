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

		// Game is active
		Time.timeScale = 1f;

	}
	
	// Update is called once per frame
	void Update () {
		
	}


	// Handling the game end conditions
	public void GameOver()
	{
		// log game over
		Debug.Log("Game Over");

		// Stop movement on game end
		Time.timeScale = 0f;

		// display game over text
		GameManager.instance.gameOverText.enabled = true;

		// Disable the Shoot touch button to prevent errors
		GameManager.instance.shootButton.gameObject.SetActive(false);

		// Turn ON game over nav buttons
		GameManager.instance.mainMenuButton.gameObject.SetActive(true);
		GameManager.instance.playAgainButton.gameObject.SetActive(true);

	}

}
