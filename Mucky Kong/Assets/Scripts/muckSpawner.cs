using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//(2018) Made by Tyler Wargo

public class muckSpawner : MonoBehaviour 
{
	//Set Muck Ball Prefab for spawning
	public GameObject muckPrefab;

	//Spawns a Muck Ball w/ position and rotation
	public void spawnMuck()
	{
		Instantiate (muckPrefab, transform.position, Quaternion.identity);
	}

	public void Start()
	{
		//Sets spawn rate
		InvokeRepeating ("spawnMuck", 0f, 2.5f);
	}
}
