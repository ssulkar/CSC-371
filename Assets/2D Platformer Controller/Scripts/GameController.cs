using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public Text level;
	public Text money;

	// Use this for initialization
	void Start () {
		level.text = "Clout Level: " + PlayerPrefs.GetInt ("level");
		money.text = "Money: $" + PlayerPrefs.GetInt ("money");
	}
	
	// Update is called once per frame
	void Update () {

	}
}
