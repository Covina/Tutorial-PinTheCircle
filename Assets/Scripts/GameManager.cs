using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	// for creating a singleton
	public static GameManager instance;


	[SerializeField] private int howManyNeedles;

	// get access to the needle object
	[SerializeField] private GameObject needle;


	// the shoot button
	private Button shootButton;

	// store the needles to be fired and in play for this round
	private GameObject[] gameNeedles;

	// 
	private float needleDistance = 0.5f;

	// tracking how many needles we've fired
	private int needleIndex = 0;


	// Use this for initialization
	void Awake ()
	{
		// create singleton
		if (instance == null) {

			instance = this;
		}

		// set button reference
		GetButton();

	}


	void Start () 
	{
		// create the series of needles on start
		CreateNeedles();

	}


	// Update is called once per frame
	void Update () 
	{
					
	}


	// Set reference to shoot button and add the OnClik functionality
	private void GetButton()
	{

		// get a reference to the button
		shootButton = GameObject.Find("Shoot Button").GetComponent<Button>();

		// add the fire function to the button
		shootButton.onClick.AddListener( () => ShootTheNeedle() );

	}

	// Shoot the needle function
	// connected to the shoot button
	public void ShootTheNeedle ()
	{
		Debug.Log("ShootTheNeedle() called");


		// Call the FireTheNeedle() function to send the needle toward the Circle
		gameNeedles[needleIndex].GetComponent<NeedleMovement>().FireTheNeedle();
		needleIndex++;


		// Check to see if we're out of needles
		if(needleIndex == gameNeedles.Length) {

			Debug.Log("No more needs, game is finished");

			// remove the functionality from the button to prevent errors
			shootButton.onClick.RemoveAllListeners();

		}


	}


	// Spawn the needles for this round
	private void CreateNeedles ()
	{

		// create empty array of X elements
		gameNeedles = new GameObject[howManyNeedles];


		// store the current position of the GameManager object
		Vector3 temp = transform.position;

		// spawn and store the needles in an array
		for (int i = 0; i < gameNeedles.Length; i++) {

			// create the needle and assign it to this element position
			gameNeedles[i] = Instantiate(needle, temp, Quaternion.identity) as GameObject;

			// move it down in increments
			//temp.y -= needleDistance;
		}

	}

	// needle creation function
	// OPTIONAL DEPENDING ON HOW WE WANT THE GAME TO PLAY
	// CALL FROM THE NEEDLE MOVEMENT SCRIPT EACH TIME THE NEEDLE IS CONSUMED
	public void InstantiateNeedle ()
	{
		
		Instantiate(needle, transform.position, Quaternion.identity);

	}





}
