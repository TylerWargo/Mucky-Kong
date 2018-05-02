using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//(2018) Made by Tyler Wargo

public class muckControl : MonoBehaviour 
{
	//Other Vars
	public float muckForce = 1000f;
	public Collider2D muckCol;
	public Rigidbody2D muckRB;

	//Audio Vars
	public AudioSource fallAud;

	//Render Vars
	public SpriteRenderer muckSpriteRen;

	public void Awake()
	{
		//Set Collider Component Vars
		muckCol = GetComponent<CircleCollider2D> ();
		muckRB = GetComponent<Rigidbody2D> ();
		muckSpriteRen = GetComponent<SpriteRenderer> ();
	}

	//Determines which way the Muck should go depending on current collision
	public void OnTriggerEnter2D(Collider2D other)
	{
		//Sends Muck left
		if (other.tag == "LeftZone") 
		{
			Debug.Log("Going Left");
			muckRB.AddForce (-transform.right * muckForce);
			muckSpriteRen.flipX = true;

		}
		//Sends Muck right
		else if (other.tag == "RightZone") 
		{
			Debug.Log("Going Right");
			muckRB.AddForce (transform.right * muckForce);
			muckSpriteRen.flipX = false;
		}

		//Plays 'falling Muck' audio
		if (other.tag == "LandZone") 
		{
			fallAud.Play ();
		}

		//Destroys Muck
		if (other.tag == "DestroyMuckZone") 
		{
			Destroy (gameObject);
		}

		//[REMOVED FEATURE?]
		if (other.tag == "rakeHeld") 
		{
			Destroy (gameObject);
		}
	}
}
