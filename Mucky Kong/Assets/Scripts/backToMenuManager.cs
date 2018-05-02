using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//(2018) Made by Tyler Wargo

public class backToMenuManager : MonoBehaviour 
{
	public void Update()
	{
		//Takes User Back To Main Screen On 'Escape'
		if (Input.GetKey (KeyCode.Escape)) 
		{
			SceneManager.LoadScene ("Title");
		}
	}
}
