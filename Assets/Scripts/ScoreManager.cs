using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {


	public static ScoreManager instance;

	// Text object for the score display
	[SerializeField] private Text scoreText;

	// keep track of the score.
	private int score = 0;

	// Use this for initialization
	void Awake ()
	{

		// Create instance
		if (instance == null) {
			instance = this;
		}

		// Start the core at zero
		scoreText.text = score.ToString();

	}

//	// Updae the display of the score
//	public void SetScore ()
//	{
//		// increment the score
//		score++;
//		scoreText.text = score.ToString();
//
//		//Debug.Log("SetScore() called");
//	}

}
