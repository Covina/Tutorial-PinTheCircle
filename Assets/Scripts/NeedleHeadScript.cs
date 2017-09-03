using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedleHeadScript : MonoBehaviour {

	void Start ()
	{
		// start circle as black;
		GetComponent<SpriteRenderer>().color = GameManager.instance.currentColor;
	}


	// Find out if two needle heads have collided
	void OnTriggerEnter2D (Collider2D target)
	{

		//Debug.Log("OnTriggerEnter2D::NeedleHeadScript()");

		// if two needle heads collide, the game ends
		if (target.tag == "NeedleHead") {

			GameManager.instance.GameOver();

		}

	}

}
