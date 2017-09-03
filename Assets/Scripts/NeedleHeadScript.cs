using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedleHeadScript : MonoBehaviour {


	void OnTriggerEnter2D (Collider2D target)
	{

		Debug.Log("NeedleHeadScript() needlhead");

		// if the needle head collides with another needlehead, the game ends
		if (target.tag == "NeedleHead") {

			GameManager.instance.GameOver();

		}

	}

}
