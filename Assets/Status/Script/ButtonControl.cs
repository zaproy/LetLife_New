using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using Novel;

public class ButtonControl : MonoBehaviour {

	void Start(){
		if (PlayerPrefs.GetInt ("a") == 1) {

		} else {
		
		}
	}

	public void StartGame(){
		PlayerPrefs.DeleteAll ();
		//test
		//NovelSingleton.StatusManager.callJoker("wide/scene1Day1","");
		PlayerPrefs.SetInt ("PlayedGame",0);
		PlayerPrefs.SetInt ("Day", 1);
		SceneManager.LoadScene ("Present", LoadSceneMode.Single);
	}



	public void LoadGame(){
	
	}


	public void ExitGame(){
		Application.Quit ();
	}

	public void Game1(){
		NovelSingleton.StatusManager.callJoker ("wide/Day1Game1Tutorial", "");
	}
	public void Game2(){
		NovelSingleton.StatusManager.callJoker ("wide/Day1Game2Tutorial", "");
	}

	public void ExitRoom(){
		SceneManager.LoadScene ("Map", LoadSceneMode.Single);
	} 

	public void ToRoom(){
		SceneManager.LoadScene ("Isometric", LoadSceneMode.Single);
	}

	public void ToScene(){
		NovelSingleton.StatusManager.callJoker("wide/scene2Day1","");
	}

	public void Sleep(){
		SceneManager.LoadScene ("TotalStatus", LoadSceneMode.Single);
	}
}
