using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class DropdownControl : MonoBehaviour
{
	public List<string> list = new List<string>() {"","Level 1","Level 2","Level 3","Level 4","Level 5","Level 6","Level 7","Level 8","Level 9","Level 10"};
	public Dropdown myDropdown;
	public Text text;

	void Start() {
		
		myDropdown.options.Clear();

		for(int i = 0; i<=(PlayerPrefs.GetInt("currentLevel")); i++){
			myDropdown.options.Add(new Dropdown.OptionData() {text = list[i]} );
		}

		myDropdown.onValueChanged.AddListener(delegate {
			myDropdownValueChangedHandler(myDropdown);
		});
	}
	void Destroy() {
		myDropdown.onValueChanged.RemoveAllListeners();
	}

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

	}

	public void SetDropdownIndex(int index) {
		myDropdown.value = index;
	}
}