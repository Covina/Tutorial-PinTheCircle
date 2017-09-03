using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	// for creating a singleton
	public static GameManager instance;


	// Game Over Text
	public Text gameOverText;

	// the shoot button
	public Button shootButton;

	// get access to the needle object
	[SerializeField] private GameObject needle;

	private GameObject needleToFire;

	// the increment of speed increase per successful pin placement
	private float rotationIncreaseIncrement = 5f;

	// Text object for the score display
	[SerializeField] private Text scoreText;

	// keep track of the score.
	private int score = 0;


	// Use this for initialization
	void Awake ()
	{
		// create singleton
		if (instance == null) {

			instance = this;
		}

	}


	// Start up the game
	void Start () 
	{

		// Create the first needle
		InstantiateNeedle();

		// disable the game over text
		gameOverText.enabled = false;

		// start at zero
		scoreText.text = score.ToString();

	}


	// Create new needle
	public void InstantiateNeedle ()
	{

		Debug.Log("InstantiateNeedle() Called");

		// Spawn the needle and store it as a game object		
		needleToFire = Instantiate(needle, transform.position, Quaternion.identity) as GameObject;

	}


	// Shoot the needle function
	public void ShootTheNeedle ()
	{
		Debug.Log("ShootTheNeedle() called");

		// Fire the needle through the fire function attached to this new needle
		needleToFire.GetComponent<NeedleMovement>().FireTheNeedle();

	}


	// Update the score counter and spawn the next needle
	public void SetScore ()
	{
		// increment the score
		score++;
		scoreText.text = score.ToString();

		// Increase the rotation speed
		GameObject.Find("Circle_Large").GetComponent<CircleRotate>().rotationSpeed += rotationIncreaseIncrement;

		// Spawn the next needle
		InstantiateNeedle();

		//Debug.Log("SetScore() called");
	}

	// Handling the game end conditions
	public void GameOver()
	{
		// log game over
		Debug.Log("Game Over");

		// end game movement
		Time.timeScale = 0f;

		// display game over text
		gameOverText.enabled = true;

		// remove the functionality from the button to prevent errors
		shootButton.onClick.RemoveAllListeners();

	}



}
