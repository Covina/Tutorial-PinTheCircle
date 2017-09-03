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

		if (instance == null) {
			instance = this;
		}

		// start at zero
		scoreText.text = score.ToString();

	}

	public void SetScore ()
	{
		// increment the score
		score++;
		scoreText.text = score.ToString();

		Debug.Log("SetScore() called");
	}

}
