﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class player_movement : MonoBehaviour {


	public Text countText;
	public Text cloutText;
	public Text moneyText;

	private int playerSpeed = 10;
	private float moveX;
	private bool facingRight;
	public int count;
	public int money;



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

	//Animations
	private Animator playerAnim;

	void Start()
	{
		count = 0;
		cloutText.text = "";
		SetCountText();

		money = 0;
		moneyText.text = "";
		SetMoneyText ();


		facingRight = true;
		playerAnim = GetComponent<Animator> ();
	}


	// Update is called once per frame
	void Update () {
		float currentSpeed = Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x);
		playerAnim.SetFloat ("speed", Mathf.Abs(currentSpeed));
		PlayerMove();
		Jump();
		//shooting stuff
		if (Input.GetAxisRaw ("Fire1")>0) {
			FireMixtape ();
		}
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
		
	}

	void PlayerMove()
	{
		//CONTROLS
		float moveX = Input.GetAxis( "Horizontal");

		//ANIMATIONS

		//PLAYER DIRECTION
		if (moveX < 0.0f && facingRight == true) {
			FlipPlayer ();
		} else if (moveX > 0.0f && facingRight == false) {
			FlipPlayer ();
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
			//GetComponent<Rigidbody2D>().velocity = new Vector2 (0, 0);
			GetComponent<Rigidbody2D>().AddForce(transform.up * playerJumpPower, ForceMode2D.Impulse);
			playerAnim.SetBool ("isGrounded", false);
		}
		isGrounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, groundLayer);
		playerAnim.SetBool ("isGrounded", isGrounded);
		playerAnim.SetFloat ("verticalSpeed", GetComponent<Rigidbody2D>().velocity.y);
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
        if (other.gameObject.CompareTag("token"))
        {
            other.gameObject.SetActive(false);
            count++;
            PlayerPrefs.SetInt("followers", PlayerPrefs.GetInt("followers", 0) + 10);
            checkLevelUp();
            SetCountText();
        }

        else if (other.gameObject.CompareTag("Money"))
        {
            other.gameObject.SetActive(false);
            PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money", 0) + 100);
            SetMoneyText();
            Destroy(other);
        }
        else if (other.gameObject.CompareTag("music"))
        {
            other.gameObject.SetActive(false);
        }

        else if (other.gameObject.CompareTag("finish"))
        {
            TimeController.instance.AfterFinish();
            StartCoroutine(TestCoroutine());
        }
        else if (other.gameObject.CompareTag("enemy"))
        {
            SceneManager.LoadScene("Menu(inbetween)");
        }
	}

	void checkLevelUp()
	{
		// Check if Player Leveled up
		// Need to display this to the player
		if (PlayerPrefs.GetInt ("level") > 0) {
			if (PlayerPrefs.GetInt ("followers") >= (PlayerPrefs.GetInt ("level") * 100)) {
				PlayerPrefs.SetInt ("followers", 0);
				PlayerPrefs.SetInt ("level", PlayerPrefs.GetInt ("level") + 1);
			}	
		} else {
			if (PlayerPrefs.GetInt ("followers") >= 50) {
				PlayerPrefs.SetInt ("followers", 0);
				PlayerPrefs.SetInt ("level", PlayerPrefs.GetInt ("level") + 1);
			}
		}
	}

	void SetCountText()
	{
		countText.text = "Clout: " + PlayerPrefs.GetInt("followers").ToString();

		if(count == 1)
		{
			cloutText.text = "Clout Acquired";
		}
	}


	void SetMoneyText() {
		moneyText.text = "$ " + PlayerPrefs.GetInt("money").ToString ();
	}

	IEnumerator TestCoroutine()
	{

		yield return new WaitForSeconds(3);
		SceneManager.LoadScene("Menu(inbetween)");

	}

    public void reloadCurrentScene()
    {

    }
}