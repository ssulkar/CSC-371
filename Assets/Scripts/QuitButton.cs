using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class QuitButton : MonoBehaviour {

	public Button yourButton2;

	void Start()
	{
		Button btn = yourButton2.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick2);
	}

	void TaskOnClick2()
	{
		UnityEditor.EditorApplication.isPlaying = false;
	}
}
