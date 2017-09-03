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

	[SerializeField] private Button mainMenuButton;
	[SerializeField] private Button playAgainButton;

	// get access to the needle object
	[SerializeField] private GameObject needle;

	private GameObject needleToFire;

	// the increment of speed increase per successful pin placement
	private float rotationIncreaseIncrement = 5f;

	// Text object for the score display
	[SerializeField] private Text scoreText;

	// keep track of the score.
	private int score = 0;

	// set 5 color cycle
	private Color[] circleColors = new Color[5];

	// Store the current color for the circle and the pin heads
	public Color currentColor;

	// Where are we in the color array
	private int colorIndex = 0;

	// Use this for initialization
	void Awake ()
	{
		// create singleton
		if (instance == null) {

			instance = this;
		}

		// Define the set of colors to choose from 
		circleColors[0] = Color.black;
		circleColors[1] = Color.red;
		circleColors[2] = Color.blue;
		circleColors[3] = Color.green;
		circleColors[4] = Color.yellow;

		// set current color
		currentColor = circleColors[0];

	}


	// Start up the game
	void Start () 
	{

		// Create the first needle
		InstantiateNeedle();

		// start at zero
		scoreText.text = score.ToString();


		// GAME OVER STUFF

		// disable the game over text
		gameOverText.enabled = false;

		// turn off game over nav buttons
		mainMenuButton.gameObject.SetActive(false);
		playAgainButton.gameObject.SetActive(false);


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
		scoreText.text = score.ToString ();

		// change size every 5 points
		if (score % 5 == 0) {

			// change colors
			colorIndex++;

			// loop back if we've gone around
			colorIndex = (colorIndex > circleColors.Length) ? 0 : colorIndex;

			// set the new color
			currentColor = circleColors[colorIndex];

			// Increase the size
			GameObject.Find ("Circle_Large").GetComponent<CircleRotate> ().IncrementCircleSize ();



		}

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

		// Disable the Shoot touch button to prevent errors
		shootButton.gameObject.SetActive(false);

		// Turn ON game over nav buttons
		mainMenuButton.gameObject.SetActive(true);
		playAgainButton.gameObject.SetActive(true);

	}



	void ResetGame()
	{



	}


}
