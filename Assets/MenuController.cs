<<<<<<< HEAD
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour {

	public Text level;
	public Text money;
	public Image character;

	public Image followerBar;

	private Sprite[] sprites;
	private SpriteRenderer spriteR;

	// Use this for initialization
	void Start () {
		level.text = "Clout Level: " + PlayerPrefs.GetInt ("level");
		money.text = "Money: $" + PlayerPrefs.GetInt ("money");

		//This line will need to be updated to use playerprefs to select which sprite we want
		sprites = Resources.LoadAll<Sprite>("ShivHD");
		character.sprite = (Sprite)sprites [0];

		//code for followers bar
		if (PlayerPrefs.GetInt ("level") > 0) {
			followerBar.fillAmount = (PlayerPrefs.GetInt ("followers") / ((float)PlayerPrefs.GetInt ("level", 10) * 100));
		} else {
			followerBar.fillAmount = (PlayerPrefs.GetInt ("followers") / 50.0f);
		}
	}

	
	// Update is called once per frame
	void Update () {
		
	}
}
=======
﻿using System.Collections;
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
>>>>>>> afe9a64a341b2951a5e69351d4cbc493ae0cf8fd
