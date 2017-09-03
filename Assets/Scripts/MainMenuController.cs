using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour {

	// Generic Scene Loader
	public void LoadScene(string sceneName) 
	{
		SceneManager.LoadScene(sceneName);

	}


	// Reload the current scene
	public void ResetCurrentScene() 
	{

		SceneManager.LoadScene( SceneManager.GetActiveScene().name );

	}

}
