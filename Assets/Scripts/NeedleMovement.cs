using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedleMovement : MonoBehaviour {

	[SerializeField]
	private GameObject needleBody;


	private bool canFireNeedle;
	private bool touchedTheCircle;


	// Needle speed
	private float forceY = 5f;

	// To get access to the rigidbody of the Parent Needle
	private Rigidbody2D myBody;


	void Awake ()
	{

		Initialize ();

		// TODO - debug to remvoe
		//FireTheNeedle();	

	}


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{

		if (canFireNeedle == true) {

			// apply force in the Y axis
			myBody.velocity = new Vector2(0, forceY);

		}

	}


	// Deactivate the Needle on load
	private void Initialize ()
	{

		// deactivate the needlebody to start
		needleBody.SetActive(false);

		// get the Rigidbody of the Parent Needle object for use later
		myBody = GetComponent<Rigidbody2D>();

	}


	public void FireTheNeedle ()
	{
		// reactivate the needle
		needleBody.SetActive(true);

		// set the kinematic setting
		myBody.isKinematic = false;

		// set the bool that we can fire the needle
		canFireNeedle = true;

	}

	// stop the needle when it hits the circle
	void OnTriggerEnter2D (Collider2D target)
	{

		//Debug.Log(gameObject.name + " just collided with " + target.gameObject.name + " with tag value [" + target.tag + "]");

		// Ignore if we're already touching the circle
		if (touchedTheCircle == true) {

			return;

		}


		// Detect if we collided with the Circle
		if (target.tag == "Circle") {


			//Debug.Log("hit Circle, updating values");

			// Disable firing the needle
			canFireNeedle = false;

			// Flag this needle as having touched the circle
			touchedTheCircle = true;

			// disable physics on the needle
			myBody.isKinematic = true;
			myBody.simulated = false;

			// make the needle part of the Circle object so they all rotate together
			transform.parent = target.transform;


			// Update the score
			if (GameManager.instance != null) {

				// incremenet and update the score
				GameManager.instance.SetScore();
	
			}

			//Debug.Log("canFireNeedle:[" + canFireNeedle + "]");

		}


	}


}
