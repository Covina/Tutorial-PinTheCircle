using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	// Generic Scene Loader
	public void LoadScene(string sceneName) 
	{
		SceneManager.LoadScene(sceneName);

	}



}
