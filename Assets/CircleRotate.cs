using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleRotate : MonoBehaviour {


	[SerializeField] private float rotationSpeed = 50f;


	private bool canRotate = true;

	private float angle;

	// Use this for initialization
	void Awake () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{

		// check that we can rotate
		if (canRotate) {

			RotateTheCircle();

		}


	}


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
