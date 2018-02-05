using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class timer : MonoBehaviour {

    private float timeLeft;
    public int playerScore;
    public GameObject time;

	// Use this for initialization
	void Start () {
        playerScore = 0;
        timeLeft = 120;
	}
	
	// Update is called once per frame
	void Update () {
        timeLeft -= Time.deltaTime;

        time.gameObject.GetComponent<Text>().text = ("Time\n" + timeLeft);

        if(timeLeft < 0.1f)
        {
            SceneManager.LoadScene("Main");
        }
	}

    void OnTriggerEnter2D(Collider2D end)
    {
        CountScore();
    }

    void CountScore()
    {
        playerScore = playerScore + (int)(timeLeft * 10);
    }
}
