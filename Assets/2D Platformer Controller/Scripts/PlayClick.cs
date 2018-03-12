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

	void TaskOnClick()
	{
		int lvl = PlayerPrefs.GetInt("currentLevel");

		if (lvl == 1) {
			SceneManager.LoadScene ("Cutscene1");
		}
		else if(lvl == 2){
			SceneManager.LoadScene ("Cutscene2");
		}
		else if(lvl == 3){
			SceneManager.LoadScene ("Cutscene3");
		}
		else if(lvl == 4){
			SceneManager.LoadScene ("Aftershow");
		}
		else if(lvl == 5){
			SceneManager.LoadScene ("Cutscene6");
		}
		else if(lvl == 6){
			SceneManager.LoadScene ("LevelDrake");
		}
	}
}
