using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//(2018) Made by Tyler Wargo

public class TitleManager : MonoBehaviour 
{
	//Changes scene to next scene in editor
	public void changeScene(int sceneTo)
	{
		SceneManager.LoadScene (sceneTo);
	}

	//Allows user to press key to start
	public void Update()
	{
		if (Input.GetKeyDown (KeyCode.Return) || Input.GetKeyDown (KeyCode.KeypadEnter)) 
		{
			changeScene (1);
		}
	}
}
