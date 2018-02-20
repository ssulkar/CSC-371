﻿﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class player_movement : MonoBehaviour {


	public Text countText;
	public Text cloutText;

	private int playerSpeed = 10;
	private float moveX;
	private bool facingRight = true;
	public int count;



	//jumping stuff
	public LayerMask groundLayer;
	public Transform groundCheck;
	public int playerJumpPower;
	private float groundCheckRadius = 0.2f;
	private bool isGrounded = false;

	//shooting stuff
	public Transform GunBarrel;
	public GameObject mixTape;
	private float fireRate = 0.5f;
	private float coolDown = 0f;

	void Start()
	{
		count = 0;
		cloutText.text = "";
		SetCountText();
	}


	// Update is called once per frame
	void Update () {
		PlayerMove();
		//shooting stuff
		if (Input.GetAxisRaw ("Fire1")>0) {
			FireMixtape ();
		}
		Jump ();
	}

	//shooting stuff
	void FireMixtape(){
		if (Time.time > coolDown) {
			coolDown = Time.time + fireRate;
			if (facingRight) {
				Instantiate (mixTape, GunBarrel.position, Quaternion.Euler (new Vector3 (0, 0, 0)));
			} else if (!facingRight) {
				Instantiate (mixTape, GunBarrel.position, Quaternion.Euler (new Vector3 (0, 0, 180f)));
			}
		}

	}

	void FixedUpdate(){
		Jump();
	}

	void PlayerMove()
	{
		//CONTROLS
		moveX = Input.GetAxis( "Horizontal");

		//ANIMATIONS

		//PLAYER DIRECTION
		if(moveX < 0.0f && facingRight == false)
		{
			FlipPlayer();
		}
		else if(moveX > 0.0f && facingRight == true)
		{
			FlipPlayer();
		}

		//PHYSICS
		gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
	}
	/*
    void Jump()
    {
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * playerJumpPower);
        isGrounded = false;
    }*/

	void Jump(){
		if(isGrounded == true && Input.GetKeyDown(KeyCode.Space)){
			isGrounded = false;
			GetComponent<Rigidbody2D>().AddForce(transform.up * playerJumpPower, ForceMode2D.Impulse);
		}
		isGrounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, groundLayer);
	}


	void FlipPlayer()
	{
		facingRight = !facingRight;
		Vector2 localScale = gameObject.transform.localScale;
		localScale.x *= -1;
		transform.localScale = localScale;
	}
	/*
    void GroundCollision(Collision2D col)
    {
        if(col.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }*/

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.CompareTag ("token"))
		{
			other.gameObject.SetActive(false);
			count++;
			SetCountText();
		}
		else if (other.gameObject.CompareTag("finish"))
		{
			TimeController.instance.AfterFinish();
			StartCoroutine(TestCoroutine());
		}
		else if(other.gameObject.CompareTag ("enemy"))
		{
			SceneManager.LoadScene("Main");
		}
	}

	void SetCountText()
	{
		countText.text = "Clout: " + count.ToString();

		if(count == 1)
		{
			cloutText.text = "Clout Acquired";
		}
	}

	IEnumerator TestCoroutine()
	{

		yield return new WaitForSeconds(3);
		SceneManager.LoadScene("Level1");

	}
}