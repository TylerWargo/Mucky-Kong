using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//(2018) Made by Tyler Wargo

public class playerController : MonoBehaviour 
{
	//Physics Vars
	public Rigidbody2D playerRB;
	public float speed;
	public float jumpForce;

	//Walking Vars
	public bool isWalking;

	//Sprite Vars
	public SpriteRenderer playerSpriteRen;

	//Audio Vars
	public AudioSource walkingAud;
	public AudioSource jumpingAud;
	public AudioSource jumpScoreAud;
	public AudioSource rakeScoreAud;

	private Animator anim;

	//Ground Check Vars
	public Transform groundCheck;
	public float groundCheckRadius;
	public LayerMask whatIsGround;
	private bool grounded;

	//Ladder Vars
	public bool onLadder;
	public float climbSpeed;
	private float climbVel;
	private float formerGrav;

	//Collider Vars
	private Collider2D playerCol;
	public Collider2D ladder1FloorCol;
	public Collider2D ladder2FloorCol;
	public Collider2D ladder3FloorCol;
	public Collider2D ladder4FloorCol;

	//Prefab Vars
	public GameObject rakePrefab;

	//Score Vars
	public int score = 0;
	public Text scoreText;

	public int muckJumpScoreAdd = 100;
	public int rakeScoreAdd = 500;


	public void Awake()
	{
		//Fetch Compontents
		playerRB = GetComponent<Rigidbody2D> ();
		playerSpriteRen = GetComponent<SpriteRenderer> ();
		anim = GetComponent<Animator> ();
		playerCol = GetComponent<Collider2D> ();

		//Pause Walking Audio - Precautionary Measure
		walkingAud.Pause ();
	}


	public void Start()
	{
		//Set FormerGrav To Former Gravity Scale
		formerGrav = playerRB.gravityScale;
	}

	//Collision detection
	public void OnTriggerEnter2D(Collider2D other)
	{
		//Adds score and plays sound after jumping over muck
		if (other.tag == "JumpScoreZone" && !onLadder) 
		{
			score += muckJumpScoreAdd;
			jumpScoreAud.PlayDelayed (0.10f);
		}

		//Destroys object and loads next level set when player hits muck (LEVEL OVER)
		if (other.tag == "Muck") 
		{
			Destroy (gameObject);
			SceneManager.LoadScene (MinigameController.nextMinigameQuestion);
		}

		//'Picks up' Rake w/ sound (Also adds item score)
		if (other.tag == "RakePickup") 
		{
			score += rakeScoreAdd;
			rakeScoreAud.Play ();
			Destroy (other.gameObject);
		}

		//'Win' level by reaching end - Chanage scene
		if (other.tag == "EndZone") 
		{
			SceneManager.LoadScene (MinigameController.nextMinigameQuestion);
		}
	}


	public void FixedUpdate()
	{
		//Sets Ground Check Settings
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, whatIsGround);

		//Horizontal Movement
		float x = Input.GetAxis ("Horizontal");
		playerRB.velocity = new Vector2 (x * speed, playerRB.velocity.y);

		//Check if player is walking - Set vars. accordingly & play sound / not
		if (Mathf.Abs (playerRB.velocity.x) > 0.3 && grounded) 
		{
			isWalking = true;
			walkingAud.UnPause ();
		} else 
		{
			isWalking = false;
			walkingAud.Pause ();
		}
	}


	public void Update()
	{
		scoreText.text = "SCORE: " + score.ToString ();

		//Checks If Arrows Or AD Pressed - Flips Sprites & isWalking If They Are
		if (Input.GetKey (KeyCode.LeftArrow) || Input.GetKey (KeyCode.A)) 
		{
			//Flips Sprite To The Left
			playerSpriteRen.flipX = true;
		} 
		else if (Input.GetKey (KeyCode.RightArrow) || Input.GetKey (KeyCode.D)) 
		{
			//Flips Sprite To The Right
			playerSpriteRen.flipX = false;
		}

		//Sets 'Speed' Variable To Control States In Animator
		anim.SetFloat("Speed", Mathf.Abs(playerRB.velocity.x));

		//Sets 'Grounded' Bool In Animator To Control Jump Animation
		anim.SetBool ("Grounded", grounded);



		//Jump Check - Checks For Input, Jumps & Plays Sound
		if (Input.GetKeyDown (KeyCode.Space) && grounded || Input.GetKeyDown(KeyCode.UpArrow) && grounded || Input.GetKeyDown(KeyCode.W) && grounded) 
		{
			//Jumps
			playerRB.AddForce (transform.up * jumpForce);
			//Plays Jump Audio
			jumpingAud.Play ();
		}


		if (onLadder) 
		{
			//Ladder Movement
			playerRB.gravityScale = 0f;
			climbVel = climbSpeed * Input.GetAxisRaw ("Vertical");
			playerRB.velocity = new Vector2 (playerRB.velocity.x, climbVel);

			//Player Ignores Colliders When Above Ladders
			Physics2D.IgnoreCollision (ladder1FloorCol, playerCol, true);
			Physics2D.IgnoreCollision (ladder2FloorCol, playerCol, true);
			Physics2D.IgnoreCollision (ladder3FloorCol, playerCol, true);
			Physics2D.IgnoreCollision (ladder4FloorCol, playerCol, true);
		} 
		else if (!onLadder) 
		{
			//Sets Gravity Back To Normal
			playerRB.gravityScale = formerGrav;
			//Stops Player From Ignoring Collision With Colliders Above Ladders
			Physics2D.IgnoreCollision (ladder1FloorCol, playerCol, false);
			Physics2D.IgnoreCollision (ladder2FloorCol, playerCol, false);
			Physics2D.IgnoreCollision (ladder3FloorCol, playerCol, false);
			Physics2D.IgnoreCollision (ladder4FloorCol, playerCol, false);
		}
	}
}