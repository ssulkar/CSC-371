using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inventoryMenu : MonoBehaviour {

	public int ScoreNum;
	public Text ScoreText;
	public Text[] ItemMoneyText;
	public Button[] minusItem = new Button[8]; 
	public Button[] addItem = new Button[8]; 
	public Image[] imagesitem = new Image[8]; 
	public int[] trackItems = new int[8]; 
	public int[] buyMoney = new int[8];
	public int[] sellMoney = new int[8];




	// Use this for initialization
	void Start () {

		buyMoney [0] = 200;
		buyMoney [1] = 400;
		buyMoney [2] = 600;
		buyMoney [3] = 700;
		buyMoney [4] = 300;
		buyMoney [5] = 500;
		buyMoney [6] = 700;
		buyMoney [7] = 900;

		ScoreNum = PlayerPrefs.GetInt ("money");

		trackItems[0] = PlayerPrefs.GetInt ("item1");
		trackItems[1] = PlayerPrefs.GetInt ("item2");
		trackItems[2] = PlayerPrefs.GetInt ("item3");

		ItemMoneyText[0].text = buyMoney [0].ToString();
		ItemMoneyText[1].text = buyMoney [1].ToString();
		ItemMoneyText[2].text = buyMoney [2].ToString();


		for (int i = 3; i < 8; i++) {
			trackItems [i] = -1;
			sellMoney [i] = buyMoney [i];
		}

		for (int c = 0; c < 3; c++) {
			sellMoney [c] = buyMoney[c];
		}

		//ScoreNum = 300;        was for testing purposes
			
	}



	// Update is called once per frame
	void Update () {

		for (int i = 0; i < 8; i++) {
			if (trackItems [i] >= 0) {
				if (imagesitem[i] != null)
					imagesitem [i].enabled = true;
				if (trackItems [i] == 0) {
					if (minusItem[i] != null)
						minusItem [i].gameObject.SetActive (false);
					if (addItem[i] != null)
						addItem [i].gameObject.SetActive (true);
				} else {
					if (minusItem[i] != null)
						minusItem [i].gameObject.SetActive (true);
					if (addItem[i] != null)
						addItem [i].gameObject.SetActive (false);
				}
			} else {
				if (imagesitem[i] != null)
					imagesitem [i].enabled = false;
				if (minusItem[i] != null)
					minusItem [i].gameObject.SetActive (false);
				if (addItem[i] != null)
					addItem [i].gameObject.SetActive (false);

			}
		}
			
		printScore ();

	}

	private void updateMoney()
	{
		PlayerPrefs.SetInt ("money", ScoreNum);

		PlayerPrefs.SetInt ("item1", trackItems[0]);
		PlayerPrefs.SetInt ("item2", trackItems[1]);
		PlayerPrefs.SetInt ("item3", trackItems[2]);
	}



	public void press_button1minus()
	{
		int button = 1-1;
		int type = 0;

		ScoreNum += sellMoney [button];
		trackItems [button] = type;
		updateMoney ();
	}

	public void press_button1plus()
	{
		int button = 1-1;
		int type = 1;

		if (ScoreNum < buyMoney [button])
			return;

		ScoreNum -= buyMoney [button];
		trackItems [button] = type;
		updateMoney ();
	}

	public void press_button2minus()
	{
		int button = 2-1;
		int type = 0;

		ScoreNum += sellMoney [button];
		trackItems [button] = type;
		updateMoney ();
	}

	public void press_button2plus()
	{
		int button = 2-1;
		int type = 1;

		if (ScoreNum < buyMoney [button])
			return;
		
		ScoreNum -= buyMoney [button];
		trackItems [button] = type;
		updateMoney ();
	}

	public void press_button3minus()
	{
		int button = 3-1;
		int type = 0;

		ScoreNum += sellMoney [button];
		trackItems [button] = type;
		updateMoney ();
	}

	public void press_button3plus()
	{
		int button = 3-1;
		int type = 1;

		if (ScoreNum < buyMoney [button])
			return;

		ScoreNum -= buyMoney [button];
		trackItems [button] = type;
		updateMoney ();
	}

	public void press_button4minus()
	{
		int button = 4-1;
		int type = 0;

		ScoreNum += sellMoney [button];
		trackItems [button] = type;
	}

	public void press_button4plus()
	{
		int button = 4-1;
		int type = 1;

		if (ScoreNum < buyMoney [button])
			return;

		ScoreNum -= buyMoney [button];
		trackItems [button] = type;
	}



	public void press_button5minus()
	{
		int button = 5-1;
		int type = 0;

		ScoreNum += sellMoney [button];
		trackItems [button] = type;
	}

	public void press_button5plus()
	{
		int button = 5-1;
		int type = 1;

		if (ScoreNum < buyMoney [button])
			return;

		ScoreNum -= buyMoney [button];
		trackItems [button] = type;
	}

	public void press_button6minus()
	{
		int button = 6-1;
		int type = 0;

		ScoreNum += sellMoney [button];
		trackItems [button] = type;
	}

	public void press_button6plus()
	{
		int button = 6-1;
		int type = 1;

		if (ScoreNum < buyMoney [button])
			return;

		ScoreNum -= buyMoney [button];
		trackItems [button] = type;
	}

	public void press_button7minus()
	{
		int button = 7-1;
		int type = 0;

		ScoreNum += sellMoney [button];
		trackItems [button] = type;
	}

	public void press_button7plus()
	{
		int button = 7-1;
		int type = 1;

		if (ScoreNum < buyMoney [button])
			return;

		ScoreNum -= buyMoney [button];
		trackItems [button] = type;
	}

	public void press_button8minus()
	{
		int button = 8-1;
		int type = 0;

		ScoreNum += sellMoney [button];
		trackItems [button] = type;
	}

	public void press_button8plus()
	{
		int button = 8-1;
		int type = 1;

		if (ScoreNum < buyMoney [button])
			return;

		ScoreNum -= buyMoney [button];
		trackItems [button] = type;
	}
		

	private void printScore(){
		ScoreText.text = ScoreNum.ToString();
	}
}
