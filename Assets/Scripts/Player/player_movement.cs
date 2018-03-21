/* This script was written by Michael Lozada, Shiv Sulkar, and Aidan Hartnett
 * Michael wrote the intial bulk of the code and Aidan and Shiv made changes to refine
 * the physics and movement within the game
 * In general this piece of code was a massive collaborative effort
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class player_movement : MonoBehaviour {


	public static player_movement instance;

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

	void Awake()
	{ 
		//If we don't currently have a game control...
		if (instance == null) {
			//...set this one to be it...
			instance = this;

		}
		//...otherwise...
		else if(instance != this)
			//...destroy this one because it is a duplicate.
			Destroy (gameObject);
	}

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


	// Update is called once per frame; Michael Lozada
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
	//Shiv
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

		// extra movement speed
		float extraSpeed = PlayerPrefs.GetInt ("item1");
		if (extraSpeed == 0)
			extraSpeed = 1.0f;
		else
			extraSpeed = 1.2f;


		//PHYSICS
		gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * playerSpeed * extraSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
	}
	/*
     *  Michael Lozada
    void Jump()
    {
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * playerJumpPower);
        isGrounded = false;
    }*/
	
	//Shiv
	void Jump(){
		//if(isGrounded == true && Input.GetKeyDown(KeyCode.Space)){

		//added extra jump for item effect
		float extraJump = PlayerPrefs.GetInt ("item3");
		if (extraJump == 0)
			extraJump = 1.0f;
		else
			extraJump = 1.2f;

		if(isGrounded == true && Input.GetButtonDown("Jump")){
			isGrounded = false;
			//GetComponent<Rigidbody2D>().velocity = new Vector2 (0, 0);
			GetComponent<Rigidbody2D>().AddForce(transform.up * playerJumpPower * extraJump, ForceMode2D.Impulse);
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

		//Shiv
        else if (other.gameObject.CompareTag("Money"))
        {
            other.gameObject.SetActive(false);
            PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money", 0) + 100);
            SetMoneyText();

			Destroy(other.gameObject);
        }

        // Michael Lozada
        else if (other.gameObject.CompareTag("music"))
        {
            other.gameObject.SetActive(false);
        }

        // Michael Lozada
        else if (other.gameObject.CompareTag("finish"))
        {
            TimeController.instance.AfterFinish();
            StartCoroutine(TestCoroutine());
        }
		/*
        else if (other.gameObject.CompareTag("enemy"))
        {
            SceneManager.LoadScene("Menu(inbetween)");
        }*/
	}

	public void checkLevelUp()
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

	}


	void SetMoneyText() {
		moneyText.text = "$ " + PlayerPrefs.GetInt("money").ToString ();
	}

    // Michael Lozada
	IEnumerator TestCoroutine()
	{
		Scene scene = SceneManager.GetActiveScene();
        playerSpeed = 0;
        playerJumpPower = 0;
        yield return new WaitForSeconds(12);
		if (string.Equals (scene.name, "LevelDrake")) {
			SceneManager.LoadScene ("You Win");
		} else {
			SceneManager.LoadScene ("Menu(inbetween)");
		}
	}

    public void reloadCurrentScene()
    {

    }
}