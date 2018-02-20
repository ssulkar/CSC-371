﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeController : MonoBehaviour {

	public static TimeController instance;	

	public Text Silver;						
	public Text Gold;	
	public Text Platinum;						
	public Text Clock;
	public Text winText;
	//public Text scoreText;

	public Image gol;
	public Image sil;
	public Image plat;

	private float clockTime = 0;
	public int silverTime;
	public int goldTime;
	public int platinumTime;

	private bool done;

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

	// Use this for initialization
	void Start () {
		winText.enabled = false;

		done = false;

		//scoreText.text = "Score: " + score.ToString ();
		Silver.text = "Silver: " + silverTime.ToString () + " seconds";
		Gold.text = "Gold: " + goldTime.ToString () + " seconds";
		Platinum.text = "Platinum: " + platinumTime.ToString ()+ " seconds";
	}

	// Update is called once per frame
	void Update () {
		//scoreText.text = "Score: " + score.ToString ();
		clockTime = clockTime + Time.deltaTime;
		Clock.text = ((int)clockTime).ToString();

		if (clockTime > silverTime) {
			Silver.color = Color.red;
			sil.enabled = false;
		}
		if (clockTime > goldTime) {
			Gold.color = Color.red;
			gol.enabled = false;
		}
		if (clockTime > platinumTime) {
			Platinum.color = Color.red;
			plat.enabled = false;
		}
	}

	public void AfterFinish (){
		if (done == true)
			return;
		Clock.enabled = false;
		if (clockTime <= platinumTime) {
			//score = score + 1000;
			winText.text = "Platinum Time Acheived +1000 score!!";
			winText.enabled = true;

		}
		else if (clockTime <= goldTime) {
			//score = score + 500;
			winText.text = "Gold Time Acheived +500 score";
			winText.enabled = true;
		}
		else if (clockTime <= silverTime) {
			//score = score + 100;
			winText.text = "Silver Time Acheived +100 score";
			winText.enabled = true;
		}
		else{
			winText.text = "You're gona have to be faster than that";
		}
		clockTime = -10000;
		done = true;
	}


}