﻿/* This entire script was written by Aidan Hartnett */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayClick : MonoBehaviour {

	public Button yourButton;

	void Start()
	{
		Button btn = yourButton.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}


	//Loads the correct level the player is on, Boss levels are level locked to encourage time trials
	//Only loads cutscene if the player has not attempted the level
	void TaskOnClick()
	{
		int lvl = PlayerPrefs.GetInt("currentLevel");
		int playerlvl = PlayerPrefs.GetInt ("level");

		if (lvl == 1) {
			if (PlayerPrefs.GetInt ("lvlAttempted_1") == 0) {	
				SceneManager.LoadScene ("Cutscene1");
			} else {
				SceneManager.LoadScene (1);
			}
		}
		else if(lvl == 2){
			if (PlayerPrefs.GetInt ("lvlAttempted_2") == 0) {	
				SceneManager.LoadScene ("Cutscene2");
			} else {
				SceneManager.LoadScene (2);
			}
		}
		else if(lvl == 3){
			if (playerlvl < 2) {
				SceneManager.LoadScene ("Level Locked");
			} else {
				if (PlayerPrefs.GetInt ("lvlAttempted_3") == 0) {	
					SceneManager.LoadScene ("Cutscene3");
				} else {
					SceneManager.LoadScene (3);
				}
			}
		}
		else if(lvl == 4){
			if (PlayerPrefs.GetInt ("lvlAttempted_4") == 0) {	
				SceneManager.LoadScene ("Cutscene5");
			} else {
				SceneManager.LoadScene (4);
			}
		}
		else if(lvl == 5){
			if (PlayerPrefs.GetInt ("lvlAttempted_5") == 0) {	
				SceneManager.LoadScene ("Cutscene6");
			} else {
				SceneManager.LoadScene (5);
			}
		}

		else if(lvl == 6){
			if (playerlvl < 3) {
				SceneManager.LoadScene ("Level Locked");
			} else {
				if (PlayerPrefs.GetInt ("lvlAttempted_6") == 0) {	
					SceneManager.LoadScene ("Cutscene8");
				} else {
					SceneManager.LoadScene (6);
				}
			}
		}

		else if(lvl == 7){
			if (PlayerPrefs.GetInt ("lvlAttempted_7") == 0) {	
				SceneManager.LoadScene ("Cutscene9");
			} else {
				SceneManager.LoadScene (7);
			}
		}
		else if(lvl == 8){
			if (PlayerPrefs.GetInt ("lvlAttempted_8") == 0) {	
				SceneManager.LoadScene ("LaterThatDay");
			} else {
				SceneManager.LoadScene (8);
			}
		}
		else if(lvl == 9){
			if (playerlvl < 4) {
				SceneManager.LoadScene ("Level Locked");
			}else{
				if (PlayerPrefs.GetInt ("lvlAttempted_9") == 0) {	
					SceneManager.LoadScene ("Cutscene13");
				} else {
					SceneManager.LoadScene (9);
				}
			}
		}
	}
}
