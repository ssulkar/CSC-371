/* This entire script was written by Aidan Hartnett */
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class DropdownControl : MonoBehaviour
{
	public List<string> list = new List<string>() {"","Level 1","Level 2","Level 3","Level 4","Level 5","Level 6","Level 7","Level 8","Level 9"};
	public Dropdown myDropdown;
	public Text text;

	void Start() {
		
		myDropdown.options.Clear();

		//populate the list with the available trials to the player
		for(int i = 0; i<=(PlayerPrefs.GetInt("currentLevel")-1); i++){
			myDropdown.options.Add(new Dropdown.OptionData() {text = list[i]} );
		}

		myDropdown.onValueChanged.AddListener(delegate {
			myDropdownValueChangedHandler(myDropdown);
		});
	}
	void Destroy() {
		myDropdown.onValueChanged.RemoveAllListeners();
	}

	//Load selected time trial
	private void myDropdownValueChangedHandler(Dropdown target) {
		if (target.value == 1) {
			SceneManager.LoadScene(1);
		}
		if (target.value == 2) {
			SceneManager.LoadScene(2);
		}
		if (target.value == 3) {
			SceneManager.LoadScene(3);
		}
		if (target.value == 4) {
			SceneManager.LoadScene(4);
		}		
		if (target.value == 5) {
			SceneManager.LoadScene(5);
		}
		if (target.value == 6) {
			SceneManager.LoadScene(6);
		}
		if (target.value == 7) {
			SceneManager.LoadScene(7);
		}		
		if (target.value == 8) {
			SceneManager.LoadScene(8);
		}
		if (target.value == 9) {
			SceneManager.LoadScene(9);
		}

	}

	public void SetDropdownIndex(int index) {
		myDropdown.value = index;
	}
}