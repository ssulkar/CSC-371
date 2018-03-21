using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NewGame : MonoBehaviour {

	public Button yourButton;

	void Start()
	{
		Button btn = yourButton.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}

	void TaskOnClick()
	{
		//reset all attributes and load level one
		//will need to reset available levels
		PlayerPrefs.SetInt ("money", 0);
		PlayerPrefs.SetInt ("followers", 0);
		PlayerPrefs.SetInt ("level", 0);

		PlayerPrefs.SetInt ("item1", 0);
		PlayerPrefs.SetInt ("item2", 0);
		PlayerPrefs.SetInt ("item3", 0);

		PlayerPrefs.SetInt ("currentLevel", 1);

		PlayerPrefs.SetInt ("LevelComplete_1", 0);
		PlayerPrefs.SetInt ("LevelComplete_2", 0);
		PlayerPrefs.SetInt ("LevelComplete_3", 0);
		PlayerPrefs.SetInt ("LevelComplete_4", 0);
		PlayerPrefs.SetInt ("LevelComplete_5", 0);
		PlayerPrefs.SetInt ("LevelComplete_6", 0);
		PlayerPrefs.SetInt ("LevelComplete_7", 0);
		PlayerPrefs.SetInt ("LevelComplete_8", 0);
		PlayerPrefs.SetInt ("LevelComplete_9", 0);

		PlayerPrefs.SetInt ("lvlAttempted_1", 0);
		PlayerPrefs.SetInt ("lvlAttempted_2", 0);
		PlayerPrefs.SetInt ("lvlAttempted_3", 0);
		PlayerPrefs.SetInt ("lvlAttempted_4", 0);
		PlayerPrefs.SetInt ("lvlAttempted_5", 0);
		PlayerPrefs.SetInt ("lvlAttempted_6", 0);
		PlayerPrefs.SetInt ("lvlAttempted_7", 0);
		PlayerPrefs.SetInt ("lvlAttempted_8", 0);
		PlayerPrefs.SetInt ("lvlAttempted_9", 0);


		PlayerPrefs.SetInt ("streak", 0);

		SceneManager.LoadScene ("Cutscene1");
	}
}
