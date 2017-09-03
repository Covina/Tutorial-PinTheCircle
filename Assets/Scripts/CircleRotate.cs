using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleRotate : MonoBehaviour {

	// rotation speed of the circle
	public float rotationSpeed = 25f;

	// can the circle rotate?
	private bool canRotate = true;

	// what is the angle
	private float angle;


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

}
