using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Novel;

public class PresentScript : MonoBehaviour {

	public GameObject[] GameButton;

	void Start(){

	}

	void Update(){
		if (PlayerPrefs.GetInt ("Game1") == 1) {
			GameButton [0].SetActive (false);
		}
		if (PlayerPrefs.GetInt ("Game2") == 1) {
			GameButton [1].SetActive (false);
		}
		if (PlayerPrefs.GetInt ("Game3") == 1) {
			GameButton [2].SetActive (false);
		}
		if (PlayerPrefs.GetInt ("Game4") == 1) {
			GameButton [3].SetActive (false);
		}
		if (PlayerPrefs.GetInt ("Game5") == 1) {
			GameButton [4].SetActive (false);
		}
		if (PlayerPrefs.GetInt ("Game6") == 1) {
			GameButton [5].SetActive (false);
		}
		if (PlayerPrefs.GetInt ("Game7") == 1) {
			GameButton [6].SetActive (false);
		}
		if (PlayerPrefs.GetInt ("Game8") == 1) {
			GameButton [7].SetActive (false);
		}
	}
	public void Game1(){
		NovelSingleton.StatusManager.callJoker ("wide/Day1Game1Tutorial", "");
		PlayerPrefs.SetInt ("Game1", 1);
	}
	public void Game2(){
		NovelSingleton.StatusManager.callJoker ("wide/Day1Game2Tutorial", "");
		PlayerPrefs.SetInt ("Game2", 1);
	}
	public void Game3(){
		NovelSingleton.StatusManager.callJoker ("wide/Game3", "");
		PlayerPrefs.SetInt ("Game3", 1);
	}
	public void Game4(){
		NovelSingleton.StatusManager.callJoker ("wide/Game4", "");
		PlayerPrefs.SetInt ("Game4", 1);
	}
	public void Game5(){
		NovelSingleton.StatusManager.callJoker ("wide/Game5", "");
		PlayerPrefs.SetInt ("Game5", 1);
	}
	public void Game6(){
		NovelSingleton.StatusManager.callJoker ("wide/Game6", "");
		PlayerPrefs.SetInt ("Game6", 1);
	}
	public void Game7(){
		NovelSingleton.StatusManager.callJoker ("wide/Game7", "");
		PlayerPrefs.SetInt ("Game7", 1);
	}
	public void Game8(){
		NovelSingleton.StatusManager.callJoker ("wide/Game8", "");
		PlayerPrefs.SetInt ("Game8", 1);
	}

	public void ResetPref(){
		PlayerPrefs.DeleteAll ();
	}
}
