using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Novel;

public class RuleNTime : MonoBehaviour {

	public float startCount;
	public Text startCountText;
	public int Stage;

	public float timer;
	public float maxTime;
	public float release;
	public GameObject[] container;
	public int objectNum;
	public GameObject desk2;
	int j; 

	public int totalScore;
	public Text showScore;
	public GameObject timeBar;

	public GameObject[] popUp;

	void Start () {
		if (Stage == 0) {//set //set kong
			j = 0;
			timer = 60f;
			maxTime = 60f;
			release = 5f;
			SetScore ();

		} else if(Stage == 1) {//set com
			
			timer = 20f;
			maxTime = 20f;
			SetScore ();
		} else if(Stage == 2) {//cooking

			timer = 60f;
			maxTime = 60f;
			release = 1f;
			SetScore ();
		}else if(Stage == 3) {//set bloom

			timer = 55f;
			maxTime = 55f;
			SetScore ();
		}else if(Stage == 4) { //mob

			timer = 50f;
			maxTime = 50f;
			SetScore ();
		}else if(Stage == 5) {//shoe

			timer = 50f;
			maxTime = 50f;
			SetScore ();
		}else if(Stage == 6) {//set wash

			timer = 25f;
			maxTime = 25f;
			SetScore ();
		}else if(Stage == 7) {//set fold

			timer = 50f;
			maxTime = 50f;
			SetScore ();
		}

		startCount = 6f;
	}
	
	// Update is called once per frame
	void Update () {

		if (startCount <= 0) {
			startCountText.gameObject.SetActive (false);
			SetScore ();

			timer -= Time.deltaTime;

			float ratio = timer / maxTime;

			timeBar.transform.localScale = new Vector3 (ratio, 1, 1);

			if (Stage == 0) {//set
				if (timer <= 0) {
					PlayerPrefs.SetInt ("PlayedGame",1);
					popUp [0].SetActive (true);
					popUp [1].SetActive (true);
					timer = 0;
				} else{
					//Release Object
					release -= 1 * Time.deltaTime;
					if (release <= 0 && j < objectNum) {
						j++;
						container [j].SetActive (true);
						if (timer <= 25f) {
							desk2.SetActive (true);
						}
						release = 5f;
					}
				}
			} else if (Stage == 1) {//set
				if (timer <= 0) {
					PlayerPrefs.SetInt ("PlayedGame",2);

					popUp [0].SetActive (true);
					popUp [1].SetActive (true);
					timer = 0;
				}
			}else if (Stage == 2) {
				if (timer <= 0) {
					PlayerPrefs.SetInt ("PlayedGame",3);
					popUp [0].SetActive (true);
					popUp [1].SetActive (true);
					timer = 0;
				} else{
					//Release Object
					release -= 1 * Time.deltaTime;
					if (release <= 0 && j < objectNum) {
						j++;
						container [j].SetActive (true);
						release = 2f;
					}
				}
			}else if (Stage == 3) {//set
				if (timer <= 0) {
					PlayerPrefs.SetInt ("PlayedGame",4);
					timer = 0;
					popUp [0].SetActive (true);
					popUp [1].SetActive (true);
				}
			}else if (Stage == 4) {
				if (timer <= 0) {
					PlayerPrefs.SetInt ("PlayedGame",5);
					popUp [0].SetActive (true);
					popUp [1].SetActive (true);
					timer = 0;
				}
			}else if (Stage == 5) {
				if (timer <= 0) {
					PlayerPrefs.SetInt ("PlayedGame",6);
					popUp [0].SetActive (true);
					popUp [1].SetActive (true);
					timer = 0;
				}
			}else if (Stage == 6) {
				if (timer <= 0) {
					PlayerPrefs.SetInt ("PlayedGame",7);
					popUp [0].SetActive (true);
					popUp [1].SetActive (true);
					timer = 0;
				}
			}else if (Stage == 7) {
				if (timer <= 0) {
					PlayerPrefs.SetInt ("PlayedGame",7);
					popUp [0].SetActive (true);
					popUp [1].SetActive (true);
					timer = 0;
				}
			}
		} else if (startCount > 0) {
			startCount -= Time.deltaTime;
			startCountText.text = "" + (int)startCount;
		}
	}

	public void PopUpToOther(){
		if (Stage == 0) {
			PlayerPrefs.SetInt ("CleanScore", totalScore);
			//test
			SceneManager.LoadScene("Present", LoadSceneMode.Single);
		} else  if (Stage == 1){
			totalScore += PlayerPrefs.GetInt ("CleanScore");
			PlayerPrefs.SetInt ("CleanScore", totalScore);
			//NovelSingleton.StatusManager.callJoker ("wide/scene2Day1", "");
			SceneManager.LoadScene("Present", LoadSceneMode.Single);
		} else  if (Stage == 2){
			totalScore += PlayerPrefs.GetInt ("CleanScore");
			PlayerPrefs.SetInt ("CleanScore", totalScore);
			//NovelSingleton.StatusManager.callJoker ("wide/scene2Day1", "");
			SceneManager.LoadScene("Present", LoadSceneMode.Single);
		}else  if (Stage == 3){
			totalScore += PlayerPrefs.GetInt ("CleanScore");
			PlayerPrefs.SetInt ("CleanScore", totalScore);
			//NovelSingleton.StatusManager.callJoker ("wide/scene2Day1", "");
			SceneManager.LoadScene("Present", LoadSceneMode.Single);
		}else  if (Stage == 4){
			totalScore += PlayerPrefs.GetInt ("CleanScore");
			PlayerPrefs.SetInt ("CleanScore", totalScore);
			//NovelSingleton.StatusManager.callJoker ("wide/scene2Day1", "");
			SceneManager.LoadScene("Present", LoadSceneMode.Single);
		}else  if (Stage == 5){
			totalScore += PlayerPrefs.GetInt ("CleanScore");
			PlayerPrefs.SetInt ("CleanScore", totalScore);
			//NovelSingleton.StatusManager.callJoker ("wide/scene2Day1", "");
			SceneManager.LoadScene("Present", LoadSceneMode.Single);
		}else  if (Stage == 6){
			totalScore += PlayerPrefs.GetInt ("CleanScore");
			PlayerPrefs.SetInt ("CleanScore", totalScore);
			//NovelSingleton.StatusManager.callJoker ("wide/scene2Day1", "");
			SceneManager.LoadScene("Present", LoadSceneMode.Single);
		}else  if (Stage == 7){
			totalScore += PlayerPrefs.GetInt ("CleanScore");
			PlayerPrefs.SetInt ("CleanScore", totalScore);
			//NovelSingleton.StatusManager.callJoker ("wide/scene2Day1", "");
			SceneManager.LoadScene("Present", LoadSceneMode.Single);
		}
	} 

	void SetScore(){
		showScore.text = "Score : " + totalScore.ToString ();
	}
}
