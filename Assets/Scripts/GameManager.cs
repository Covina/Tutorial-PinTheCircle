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
	private GameObject[] needles;

	// 
	private float needleDistance = 1.5f;

	//
	private int needleIndex;


	// Use this for initialization
	void Awake () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
