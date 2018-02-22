using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inventoryMenu : MonoBehaviour {

	public int ScoreNum;
	public Text ScoreText;
	public Button[] minusItem = new Button[8]; 
	public Button[] addItem = new Button[8]; 
	public Image[] imagesitem = new Image[8]; 
	public int[] trackItems = new int[8]; 
	public int[] buyMoney = new int[8];
	public int[] sellMoney = new int[8];



	void Awake()
	{
		DontDestroyOnLoad (transform.gameObject);
		if (FindObjectsOfType (GetType ()).Length > 1) {
			Destroy (gameObject);
		}
	}

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


		for (int i = 0; i < 8; i++) {
			trackItems [i] = i-3;
			sellMoney [i] = buyMoney[i] /2 ;
		}
			
	}



	// Update is called once per frame
	void Update () {

		for (int i = 0; i < 8; i++) {
			if (trackItems [i] >= 0) {
				imagesitem [i].enabled = true;
				if (trackItems [i] == 0) {
					minusItem [i].gameObject.SetActive (false);
					addItem [i].gameObject.SetActive (true);
				} else {
					minusItem [i].gameObject.SetActive (true);
					addItem [i].gameObject.SetActive (false);
				}
			} else {
				imagesitem [i].enabled = false;
				minusItem [i].gameObject.SetActive (false);
				addItem [i].gameObject.SetActive (false);
			}
		}
			
		printScore ();

	}



	public void press_button1minus()
	{
		int button = 1-1;
		int type = 0;

		ScoreNum += sellMoney [button];
		trackItems [button] = type;
	}

	public void press_button1plus()
	{
		int button = 1-1;
		int type = 1;

		if (ScoreNum < buyMoney [button])
			return;

		ScoreNum -= buyMoney [button];
		trackItems [button] = type;
	}

	public void press_button2minus()
	{
		int button = 2-1;
		int type = 0;

		ScoreNum += sellMoney [button];
		trackItems [button] = type;
	}

	public void press_button2plus()
	{
		int button = 2-1;
		int type = 1;

		if (ScoreNum < buyMoney [button])
			return;
		
		ScoreNum -= buyMoney [button];
		trackItems [button] = type;
	}

	public void press_button3minus()
	{
		int button = 3-1;
		int type = 0;

		ScoreNum += sellMoney [button];
		trackItems [button] = type;
	}

	public void press_button3plus()
	{
		int button = 3-1;
		int type = 1;

		if (ScoreNum < buyMoney [button])
			return;

		ScoreNum -= buyMoney [button];
		trackItems [button] = type;
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
