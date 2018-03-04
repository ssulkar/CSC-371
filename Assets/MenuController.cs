using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour {

	public Text level;
	public Text money;
	public Image character;

	// Use this for initialization
	void Start () {
		level.text = "Clout Level: " + PlayerPrefs.GetInt ("level");
		money.text = "Money: " + PlayerPrefs.GetInt ("money");

		//set the image to show the character
		//Image.sprite = 
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
