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
	float maxTime;
	float release;
	public GameObject[] container;
	public int objectNum;
	public GameObject desk2;
	int j; 

	public int totalScore;
	public Text showScore;
	public int endScore;
	public Text showEndScore; 
	public GameObject timeBar;
	
	public int gameScore;
	public GameObject[] popUp;

	void Start () {
		if (Stage == 0) {//set //set kong
			j = 0;
			release = 5f;
			SetTime(60f,60f);
		} else if(Stage == 1) {//set com
			SetTime(20f,20f);
		} else if(Stage == 2) {//cooking
			release = 1f;
			SetTime(60f,60f);
		}else if(Stage == 3) {//set bloom
			SetTime(55f,55f);
		}else if(Stage == 4) { //mob
			SetTime(50f,50f);
		}else if(Stage == 5) {//shoe
			SetTime(50f,50f);
		}else if(Stage == 6) {//set wash
			SetTime(25f,25f);
		}else if(Stage == 7) {//set fold
			SetTime(50f,50f);
		}

		startCount = 6f;
	}
	
	void SetTime(float gameTime,float maxgameTime){
		timer = gameTime;
		maxTime = maxgameTime;
		SetTotalScore();
		
	}
	
	// Update is called once per frame
	void Update () {
		SetScore();
		if (startCount <= 0) {
			startCountText.gameObject.SetActive (false);
			SetScore ();

			timer -= Time.deltaTime;

			float ratio = timer / maxTime;

			timeBar.transform.localScale = new Vector3 (ratio, 1, 1);

			if (Stage == 0) {//set
				if (timer <= 0) {
					PlayerPrefs.SetInt ("PlayedGame",1);
					PopUpUI();
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
					PopUpUI();
				}
			}else if (Stage == 2) {
				if (timer <= 0) {
					PlayerPrefs.SetInt ("PlayedGame",3);
					PopUpUI();
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
					PopUpUI();
				}
			}else if (Stage == 4) {
				if (timer <= 0) {
					PlayerPrefs.SetInt ("PlayedGame",5);
					PopUpUI();
				}
			}else if (Stage == 5) {
				if (timer <= 0) {
					PlayerPrefs.SetInt ("PlayedGame",6);
					PopUpUI();
				}
			}else if (Stage == 6) {
				if (timer <= 0) {
					PlayerPrefs.SetInt ("PlayedGame",7);
					PopUpUI();
				}
			}else if (Stage == 7) {
				if (timer <= 0) {
					PlayerPrefs.SetInt ("PlayedGame",7);
					PopUpUI();
				}
			}
		} else if (startCount > 0) {
			startCount -= Time.deltaTime;
			startCountText.text = "" + (int)startCount;
		}
	}
	
	void PopUpUI(){
		popUp [0].SetActive (true);
		popUp [1].SetActive (true);
		timer = 0;
	}

	public void PopUpToOther(){
		if (Stage == 0) {
			PlayerPrefs.SetInt ("CleanScore", totalScore);
			//test
			SceneManager.LoadScene("Present", LoadSceneMode.Single);
		} else  if (Stage == 1){
			endScore += PlayerPrefs.GetInt ("CleanScore");
			PlayerPrefs.SetInt ("CleanScore", totalScore);
			//NovelSingleton.StatusManager.callJoker ("wide/scene2Day1", "");
			SceneManager.LoadScene("Present", LoadSceneMode.Single);
		} else  if (Stage == 2){
			endScore += PlayerPrefs.GetInt ("CleanScore");
			PlayerPrefs.SetInt ("CleanScore", totalScore);
			//NovelSingleton.StatusManager.callJoker ("wide/scene2Day1", "");
			SceneManager.LoadScene("Present", LoadSceneMode.Single);
		}else  if (Stage == 3){
			endScore += PlayerPrefs.GetInt ("CleanScore");
			PlayerPrefs.SetInt ("CleanScore", totalScore);
			//NovelSingleton.StatusManager.callJoker ("wide/scene2Day1", "");
			SceneManager.LoadScene("Present", LoadSceneMode.Single);
		}else  if (Stage == 4){
			endScore += PlayerPrefs.GetInt ("CleanScore");
			PlayerPrefs.SetInt ("CleanScore", totalScore);
			//NovelSingleton.StatusManager.callJoker ("wide/scene2Day1", "");
			SceneManager.LoadScene("Present", LoadSceneMode.Single);
		}else  if (Stage == 5){
			endScore += PlayerPrefs.GetInt ("CleanScore");
			PlayerPrefs.SetInt ("CleanScore", totalScore);
			//NovelSingleton.StatusManager.callJoker ("wide/scene2Day1", "");
			SceneManager.LoadScene("Present", LoadSceneMode.Single);
		}else  if (Stage == 6){
			endScore += PlayerPrefs.GetInt ("CleanScore");
			PlayerPrefs.SetInt ("CleanScore", totalScore);
			//NovelSingleton.StatusManager.callJoker ("wide/scene2Day1", "");
			SceneManager.LoadScene("Present", LoadSceneMode.Single);
		}else  if (Stage == 7){
			endScore += PlayerPrefs.GetInt ("CleanScore") ;
			PlayerPrefs.SetInt ("CleanScore", totalScore);
			//NovelSingleton.StatusManager.callJoker ("wide/scene2Day1", "");
			SceneManager.LoadScene("Present", LoadSceneMode.Single);
		}
	} 
	
	void SetTotalScore(){
		
		
		showScore.text = "Score : " + gameScore.ToString ();
	}

	void SetScore(){
		showEndScore.text ="Score : " + endScore.ToString ();
	}
}
