﻿/* This entire script was written by Aidan Hartnett */
using UnityEngine;
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
	public Text level;

	public Image gol;
	public Image sil;
	public Image plat;
	public Image followerBar;

	private float clockTime = 0;
	public int silverTime;
	public int goldTime;
	public int platinumTime;

	public string lvlComplete;
	public string lvlAttempted;
	public int lvlNum;

	public GameObject allPickups;

	private bool done;
	private string enableKey;

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


	void Start () {
		PlayerPrefs.SetInt (lvlAttempted, 1);
		enableKey = lvlComplete;

		//gets all the pickups to allow them to be disabled when timer is active
		Transform[] allChildren = allPickups.GetComponentsInChildren<Transform>();

		// don't show timer stuff first time through level
		// enableKey is set at end of level
		// enableKey is cleared by menu when new game is started
		if (PlayerPrefs.GetInt (enableKey) == 0) {
			Silver.enabled = false;
			Gold.enabled = false;
			Platinum.enabled = false;
			Clock.enabled = false;
			gol.enabled = false;
			sil.enabled = false;
			plat.enabled = false;
		}
		//When timer is active we disable all the pickups
		else {
			foreach (Transform child in allChildren) {
				child.gameObject.SetActive(false);
			}
		}

		winText.enabled = false;
		done = false;

		//Negative Feedback loop to reduce allotted time if player is consistently fast
		if (PlayerPrefs.GetInt ("streak") >= 2) {
			silverTime = (int)(silverTime * .9);
			goldTime = (int)(goldTime * .9);
			platinumTime = (int)(platinumTime * .9);
		}

		//set the amount of time alloted
		Silver.text = "Silver: " + silverTime.ToString () + " seconds";
		Gold.text = "Gold: " + goldTime.ToString () + " seconds";
		Platinum.text = "Platinum: " + platinumTime.ToString ()+ " seconds";
	}


	void Update () {

		//updates level and exp bar
		level.text = "Clout Level: " + PlayerPrefs.GetInt ("level");
		if (PlayerPrefs.GetInt ("level") > 0) {
			followerBar.fillAmount = (PlayerPrefs.GetInt ("followers") / ((float)(PlayerPrefs.GetInt ("level", 10) * 100)));
		} else {
			followerBar.fillAmount = (PlayerPrefs.GetInt ("followers") / 50.0f);
		}

		//update and display the clock time
		clockTime = clockTime + Time.deltaTime;
		Clock.text = ((int)clockTime).ToString();

		//check each of the times to see if they have expired
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
		if (PlayerPrefs.GetInt (enableKey) == 1) {
			//ensure we dont hit finish twice
			if (done == true)
				return;
			Clock.enabled = false;

			int followersGained;
		

			//if else block to display to the player what time goal they hit
			//also awards experience to the player
			if (clockTime <= platinumTime) {
				//score = score + 1000;
				followersGained = lvlNum * 50;
				if (PlayerPrefs.GetInt ("streak") >= 2) {
					followersGained = followersGained * 2;
				}
				winText.text = "Platinum Time Acheived, you gained " + followersGained.ToString () + " followers";
				winText.enabled = true;
				PlayerPrefs.SetInt ("followers", PlayerPrefs.GetInt ("followers") + followersGained);
				PlayerPrefs.SetInt ("streak", (PlayerPrefs.GetInt ("streak") + 1));
			} else if (clockTime <= goldTime) {
				//score = score + 500;
				followersGained = lvlNum * 25;
				winText.text = "Gold Time Acheived, you gained " + followersGained.ToString () + " followers";
				winText.enabled = true;
				PlayerPrefs.SetInt ("followers", PlayerPrefs.GetInt ("followers") + followersGained);
				PlayerPrefs.SetInt ("streak", 0);
			} else if (clockTime <= silverTime) {
				//score = score + 100;
				followersGained = lvlNum * 10;
				winText.text = "Silver Time Acheived, you gained " + followersGained.ToString () + " followers";
				winText.enabled = true;
				PlayerPrefs.SetInt ("followers", PlayerPrefs.GetInt ("followers") + followersGained);
				PlayerPrefs.SetInt ("streak", 0);
			} else {
				winText.text = "You're gona have to be faster than that";
				PlayerPrefs.SetInt ("streak", 0);
			}
			player_movement.instance.checkLevelUp ();

			//to ensure we dont pass any more time goals
			clockTime = -10000;
			done = true;
		} else {
			winText.enabled = true;
			winText.text = "LEVEL COMPLETE";
		}

		if (PlayerPrefs.GetInt ("currentLevel") <= lvlNum + 1) {
			PlayerPrefs.SetInt ("currentLevel", lvlNum + 1);
		}


		// allow the timers to come back
		StartCoroutine(TestCoroutine3());




	}

	IEnumerator TestCoroutine3()
	{

		yield return new WaitForSeconds(3);
		PlayerPrefs.SetInt(enableKey, 1);

	}

}
