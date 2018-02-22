using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public float speed;

	public AudioClip jumpSound;
	public AudioSource jumpSource;

	private Rigidbody2D rb2d; 
	private BoxCollider2D col;
	private float distToGround;
	private bool isGrounded = true;



	void Start()
	{
		jumpSource.clip = jumpSound;

		//Physics.gravity.y = Physics.gravity.y * 2;
		//Get and store a reference to the Rigidbody2D component so that we can access it.
		rb2d = GetComponent<Rigidbody2D> ();

		rb2d.freezeRotation = true;

	}


	void FixedUpdate()
	{
		//Store the current horizontal input in the float moveHorizontal.
		float moveHorizontal = Input.GetAxis ("Horizontal");


		//Use the two store floats to create a new Vector2 variable movement.
		Vector2 movement = new Vector2 (moveHorizontal, 0);

		//Call the AddForce function of our Rigidbody2D rb2d supplying movement multiplied by speed to move our player.
		rb2d.AddForce (movement * speed);
	}

	void Update()
	{

		if (Input.GetKeyDown ("space") && isGrounded==true) {
			Vector2 jump = new Vector2 (0.0f, 800.0f);
			rb2d.AddForce (jump);
			jumpSource.Play ();
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.CompareTag("Death"))
		{
			LevelController.instance.death ();

		}
		if (other.gameObject.CompareTag("Finish"))
		{
			LevelController.instance.AfterFinish ();
			StartCoroutine(TestCoroutine());
		}
		if (other.gameObject.tag == "Pickup") {
			GameObject gtemp = other.transform.GetChild (0).gameObject;
			Vector2 temp = gtemp.transform.position;
			gtemp.gameObject.SetActive (true);
			gtemp.transform.parent = null;
			gtemp.transform.position = temp;
			StartCoroutine(TestCoroutine2(gtemp));
			other.gameObject.SetActive (false);
			LevelController.instance.increaseScore (100);
		}
	}

	IEnumerator TestCoroutine2(GameObject gtemp)
	{
		
		yield return new WaitForSeconds(1);
		gtemp.SetActive (false);

	}

	IEnumerator TestCoroutine()
	{

		yield return new WaitForSeconds(3);
		SceneManager.LoadScene("Menu");

	}

	void OnCollisionEnter2D(Collision2D theCollision)
	{
		if (theCollision.gameObject.tag == "Enemy") {
			int force;
			if (transform.position.x > theCollision.transform.position.x) {
				force = 75;
			} else {
				force = -75;
			}
			Vector2 push = new Vector2 (force, 0);
			rb2d.AddForce (push * speed);
		}
		if (theCollision.gameObject.tag == "Floor")
		{
			isGrounded = true;
		}
	}

	//consider when character is jumping .. it will exit collision.
	void OnCollisionExit2D(Collision2D theCollision)
	{
		if (theCollision.gameObject.tag == "Floor")
		{
			isGrounded = false;
		}
	}
}