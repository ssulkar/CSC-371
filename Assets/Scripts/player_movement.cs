using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class player_movement : MonoBehaviour {

    public bool isGrounded = true;
    public Text countText;
    public Text cloutText;
    public int count;

    private int playerSpeed = 10;
    private int playerJumpPower = 1700;
    private float moveX;
    private bool facingRight = true;

	void Start()
    {
        count = 0;
        cloutText.text = "";
        SetCountText();
    }


    // Update is called once per frame
    void Update () {
        PlayerMove();

    }

    void PlayerMove()
    {
        //CONTROLS
        moveX = Input.GetAxis( "Horizontal");

        if(Input.GetButtonDown ("Jump"))
        {
            Jump();
        }

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

    void Jump()
    {
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * playerJumpPower);
        isGrounded = false;
    }

    void FlipPlayer()
    {
        facingRight = !facingRight;
        Vector2 localScale = gameObject.transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    void GroundCollision(Collision2D col)
    {
        if(col.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag ("token"))
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
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
}
