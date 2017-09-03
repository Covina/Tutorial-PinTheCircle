using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleRotate : MonoBehaviour {

	// rotation speed of the circle
	private float rotationSpeed = 25f;

	private float circleRadiusIncrement = -0.06f;

	// can the circle rotate?
	private bool canRotate = true;

	// what is the angle
	private float angle;


	void Start ()
	{

		// adjust the size of the center circle
		Vector3 temp = transform.localScale;
		temp.x = 0.8f;
		temp.y = 0.8f;
		temp.z = 1.0f;

		// assign
		transform.localScale = temp;


		// start circle as black;
		GetComponent<SpriteRenderer>().color = GameManager.instance.CurrentColor;


	}


	// Update is called once per frame
	void Update ()
	{

		// check that we can rotate
		if (canRotate) {

			RotateTheCircle();

		}

	}

	// Rotate the circle
	void RotateTheCircle() 
	{
		// get the current angle
		angle = transform.rotation.eulerAngles.z;

		// rotate according to speed and frame rate
		angle += rotationSpeed * Time.deltaTime;

		// set the rotation position of the circle
		transform.rotation = Quaternion.Euler( new Vector3(0,0,angle) );

	}

	// Increase the size of the square
	public void IncrementCircleSize ()
	{

		Vector3 newSize = transform.localScale;

		newSize.x += circleRadiusIncrement;
		newSize.y += circleRadiusIncrement;

		transform.localScale = newSize;

		// set color
		GetComponent<SpriteRenderer>().color = GameManager.instance.CurrentColor;


	}

	// increase the rotation speed of the circle
	public void IncrementRotationSpeed ()
	{
		Debug.Log("IncrementRotationSpeed() called.  Current Rotation Speed: " + rotationSpeed);
		Debug.Log(".. adding speed increment: " + GameManager.instance.RotationIncreaseIncrement);

		// Increase the rotation speed
		rotationSpeed += GameManager.instance.RotationIncreaseIncrement;

	}


}
