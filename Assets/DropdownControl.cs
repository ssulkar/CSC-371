using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class DropdownControl : MonoBehaviour
{

	public Dropdown myDropdown;

	void Start() {
		myDropdown.onValueChanged.AddListener(delegate {
			myDropdownValueChangedHandler(myDropdown);
		});
	}
	void Destroy() {
		myDropdown.onValueChanged.RemoveAllListeners();
	}

	private void myDropdownValueChangedHandler(Dropdown target) {
		if (target.value == 1) {
			SceneManager.LoadScene("Level1");
		}
	}

	public void SetDropdownIndex(int index) {
		myDropdown.value = index;
	}
}
