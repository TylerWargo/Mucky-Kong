using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//(2018) Made by Tyler Wargo

public class youWinManager : MonoBehaviour 
{
	public void Update()
	{
		//Allows user to hit a button to return to the title screen
		if (Input.GetKeyDown (KeyCode.KeypadEnter) || Input.GetKeyDown (KeyCode.Return)) 
		{
			SceneManager.LoadScene ("Title");
		}

		//Allows user to click to return to 'Title'
		if (Input.GetMouseButtonDown (0) || Input.GetMouseButtonDown (1)) 
		{
			SceneManager.LoadScene ("Title");
		}
	}
}
