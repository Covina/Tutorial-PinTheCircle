using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedleMovement : MonoBehaviour {

	// the long needle body
	[SerializeField] private GameObject needleBody;

	// Is the needle moving through game space?
	private bool needleMoving;

	// Has the Needle hit the center circle?
	private bool touchedTheCircle;

	// Needle speed
	private float forceY = 5f;

	// To get access to the rigidbody of the Parent Needle
	private Rigidbody2D myBody;


	void Awake ()
	{

		// get the Rigidbody of the Parent Needle object for use later
		myBody = GetComponent<Rigidbody2D>();
		//Debug.Log("MyBody:" + myBody);

		Initialize ();

	}


	// Update is called once per frame
	void Update ()
	{

		// if the needle object is moving, keep moving it
		if (needleMoving == true) {

			// apply force in the Y axis
			myBody.velocity = new Vector2(0, forceY);

		}

	}


	// Deactivate the Needle on load
	private void Initialize ()
	{

		// deactivate the needlebody to start
		needleBody.SetActive(false);

	}

	// Display the pin and start moving the needle
	public void FireTheNeedle ()
	{
		// reactivate the needle
		needleBody.SetActive(true);

		// set the kinematic setting
		myBody.isKinematic = false;

		// set the bool that we can fire the needle
		needleMoving = true;

	}


	// stop the needle when it hits the circle
	void OnTriggerEnter2D (Collider2D target)
	{

		// Ignore if we're already touching the circle
		if (touchedTheCircle == true) {

			return;

		}

		// Detect if we collided with the Circle
		if (target.tag == "Circle") {

			Debug.Log("OnTriggerEnter2D::NeedleMovement = hit tag 'Circle', updating values");

			// Stop the needle from moving
			needleMoving = false;

			// Flag this needle as having touched the circle
			touchedTheCircle = true;

			// Disable physics on the needle
			myBody.isKinematic = true;
			myBody.bodyType = RigidbodyType2D.Static;


			// Move the needle into a child object of the Circle so it sticks and rotates together
			transform.parent = target.transform;

			// Update the score
			if (GameManager.instance != null) {

				// incremenet and update the score
				GameManager.instance.SetScore();
	
			}

		}

	}


}
