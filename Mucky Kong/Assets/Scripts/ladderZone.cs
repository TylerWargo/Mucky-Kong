using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//(2018) Made by Tyler Wargo

public class ladderZone : MonoBehaviour 
{
	private playerController playerGO;

	public void Start()
	{
		//Fetch Player GameObject Script
		playerGO = FindObjectOfType<playerController> ();
	}

	//When Player's On Ladder: Set So
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.name == "Player") 
		{
			playerGO.onLadder = true;
		}
	}

	//When Player's Not On Ladder: Set So
	void OnTriggerExit2D(Collider2D other)
	{
		if (other.name == "Player") 
		{
			playerGO.onLadder = false;
		}
	}
}
