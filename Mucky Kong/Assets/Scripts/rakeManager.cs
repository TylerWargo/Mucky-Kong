using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//(2018) Made by Tyler Wargo

public class rakeManager : MonoBehaviour 
{
	public AudioSource itemDestroyAud;

	//Automatically destroys Muck after time
	public void Awake()
	{
			Destroy (gameObject, 5.0f);
	}

	//If Muck collides with 'Destroy Muck Zone', destroy it.
	public void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Muck") 
		{
			Debug.Log ("Hit Muck");
			itemDestroyAud.Play ();
		}
	}
}
