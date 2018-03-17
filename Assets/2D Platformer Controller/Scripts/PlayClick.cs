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
			if (PlayerPrefs.GetInt ("lvlAttempted_3") == 0) {	
				SceneManager.LoadScene ("Cutscene3");
			} else {
				SceneManager.LoadScene (3);
			}
		}
		else if(lvl == 4){
			if (PlayerPrefs.GetInt ("lvlAttempted_4") == 0) {	
				SceneManager.LoadScene ("Cutscene4");
			} else {
				SceneManager.LoadScene (4);
			}
		}
		else if(lvl == 5){
			if (PlayerPrefs.GetInt ("lvlAttempted_5") == 0) {	
				SceneManager.LoadScene ("Cutscene5");
			} else {
				SceneManager.LoadScene (5);
			}
		}
		else if(lvl == 6){
			SceneManager.LoadScene ("LevelDrake");
		}
	}
}
