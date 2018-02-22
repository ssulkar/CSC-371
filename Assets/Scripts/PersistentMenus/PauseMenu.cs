using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

	public GameObject PauseUI;
	public GameObject InvUI;
	public GameObject BuySellUI;

	private bool paused = false;
	private bool invt = false;



	void Update(){

		if (Input.GetButtonDown ("Pause")) {
			paused = !paused;
			invt = false;
		}

		if (paused) {

			InvUI.SetActive (false);
			if (!invt) {
				PauseUI.SetActive (true);
				BuySellUI.SetActive (false);
			} else {
				PauseUI.SetActive (false);
				BuySellUI.SetActive (true);
			}
				
			Time.timeScale = 0;
		}
		else if (!paused) {

			PauseUI.SetActive (false);
			BuySellUI.SetActive (false);
			InvUI.SetActive (true);
			Time.timeScale = 1;
		}

	}


	public void Resume(){
		paused = false;
	}



	public void Inventory(){
		invt = true;
	}

	public void BackToPauseMain(){
		invt = false;
	}



	public void MainMenu(){
		paused = false;
		Time.timeScale = 1;
		SceneManager.LoadScene(0, LoadSceneMode.Single);
	}

	public void Quit(){
		paused = false;
		Time.timeScale = 1;
		Application.Quit ();
	}

	public void Restart(){
		paused = false;
		Time.timeScale = 1;
		Scene scene = SceneManager.GetActiveScene();
		SceneManager.LoadScene(scene.name, LoadSceneMode.Single);
	}

	public void StartGame(){
		paused = false;
		Time.timeScale = 1;
		SceneManager.LoadScene(1, LoadSceneMode.Single);
	}
}

