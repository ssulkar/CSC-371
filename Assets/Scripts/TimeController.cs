using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeController : MonoBehaviour {
	public static TimeController instance;	

	public Text Silver;						
	public Text Gold;	
	public Text Platinum;						
	public Text Clock;
	public Text winText;

	public Image gol;
	public Image sil;
	public Image plat;

	private float clockTime = 0;
	public int silverTime;
	public int goldTime;
	public int platinumTime;

	private bool done;
	private const string enableKey = "LevelComplete_1";

	void Awake()
	{
		//If we don't currently have a game control...
		if (instance == null) {
			//...set this one to be it...
			instance = this;

		}
		//...otherwise...
		else if(instance != this)
			//...destroy this one because it is a duplicate.
			Destroy (gameObject);
	}


	void Start () {
		// don't show timer stuff first time through level
		// enableKey is set at end of level
		// enableKey is cleared by menu when new game is started
		if (PlayerPrefs.GetInt(enableKey) == 0) {
			Silver.enabled = false;
			Gold.enabled = false;
			Platinum.enabled = false;
			Clock.enabled = false;
			gol.enabled = false;
			sil.enabled = false;
			plat.enabled = false;
		}

		winText.enabled = false;
		done = false;

		//set the amount of time alloted
		Silver.text = "Silver: " + silverTime.ToString () + " seconds";
		Gold.text = "Gold: " + goldTime.ToString () + " seconds";
		Platinum.text = "Platinum: " + platinumTime.ToString ()+ " seconds";
	}


	void Update () {

		//update and display the clock time
		clockTime = clockTime + Time.deltaTime;
		Clock.text = ((int)clockTime).ToString();

		//check each of the times to see if they have expired
		if (clockTime > silverTime) {
			Silver.color = Color.red;
			sil.enabled = false;
		}
		if (clockTime > goldTime) {
			Gold.color = Color.red;
			gol.enabled = false;
		}
		if (clockTime > platinumTime) {
			Platinum.color = Color.red;
			plat.enabled = false;
		}
	}

	public void AfterFinish (){
		//ensure we dont hit finish twice
		if (done == true)
			return;
		Clock.enabled = false;

		//if else block to display to the player what time goal they hit
		//should also be used in the future to award experience to the player
		if (clockTime <= platinumTime) {
			//score = score + 1000;
			winText.text = "Platinum Time Acheived +1000 score!!";
			winText.enabled = true;

		}
		else if (clockTime <= goldTime) {
			//score = score + 500;
			winText.text = "Gold Time Acheived +500 score";
			winText.enabled = true;
		}
		else if (clockTime <= silverTime) {
			//score = score + 100;
			winText.text = "Silver Time Acheived +100 score";
			winText.enabled = true;
		}
		else{
			winText.text = "You're gona have to be faster than that";
		}
		//to ensure we dont pass any more time goals
		clockTime = -10000;
		done = true;



		// allow the timers to come back
		PlayerPrefs.SetInt(enableKey, 1);


		//CHANGE FOR EACH LEVEL
		PlayerPrefs.SetInt ("currentLevel", 2);

		SceneManager.LoadScene("Menu(inbetween)");
	}


}
