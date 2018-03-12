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
		//CHANGE THIS TO LOAD CUTSCENE USING IF ELSE
		//int lvl = PlayerPrefs.GetInt("currentLevel")
		SceneManager.LoadScene(PlayerPrefs.GetInt("currentLevel"));
	}
}
