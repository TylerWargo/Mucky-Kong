using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//(2018) Made by Tyler Wargo

public class escapeManager : MonoBehaviour 
{
	public void Update()
	{
		//Quits Application on Title Screen
		if (Input.GetKey (KeyCode.Escape)) 
		{
			Application.Quit ();
		}
	}
}
