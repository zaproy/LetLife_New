using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Status : MonoBehaviour {
	
	public Text showTime;
	public string niceTime;

	public GameObject bar1;
	public GameObject bar2;

	public GameObject[] bar;

	public int sceneNum;

	public float stamina;
	public float cleaness;
	public int days;

	public int inGameHour;
	public int inGameMin;
	public float inGameSecound;

	public int sceneCount;

	public bool isDay;
	int GameStartCount;
	public float cleanScore;

	public float Status1;
	public float Status2;
	public float Status3;
	public float Status4;


	void Awake(){
		cleaness = PlayerPrefs.GetFloat ("PlayerCleaness");
		days = PlayerPrefs.GetInt ("Day");
		Status1 = PlayerPrefs.GetFloat ("PointChar1");
		Status2 = PlayerPrefs.GetFloat ("PointChar2");
		Status3 = PlayerPrefs.GetFloat ("PointChar3");
		Status4 = PlayerPrefs.GetFloat ("PointChar4");
		SetPreviousTime ();
	}
	void Start () {
		sceneCount = PlayerPrefs.GetInt ("SceneCount");
		if (PlayerPrefs.GetInt("a") == 0) {
			PlayerPrefs.SetInt ("a", 1);
			FirstSetting ();
			Debug.Log ("a");
		} else {
			if (PlayerPrefs.GetFloat ("PlayerStamina") >= 0) {
				SetPreStamina ();
				SetPreviousTime ();
			} else if (PlayerPrefs.GetFloat ("PlayerStamina") < 0) {
				SetStamina ();
				inGameHour = 9;
				inGameMin = 0;
				inGameSecound = 0f;
			}


		}

		if (sceneNum == 5) {
			if (days == 1) {
			}
			LoadAllStatus ();
			ShowAllStatus ();

		}

		if (sceneNum == 0 && days == 1) {
			sceneCount++;
			PlayerPrefs.SetInt ("SceneCount", sceneCount);
		} else if (sceneNum == 5 && days == 1) {
			sceneCount = 0;
			PlayerPrefs.SetInt ("SceneCount", sceneCount);
		} else if (sceneNum == 4 && days == 1) {
			sceneCount = PlayerPrefs.GetInt ("SceneCount") - 1;
			PlayerPrefs.SetInt ("SceneCount", sceneCount);
		}


	}
	

	void Update () {
		if (sceneNum != 5) {
			Cleaness ();
			GameTime ();
			niceTime = string.Format ("{0:D2}:{1:D2}", inGameHour, inGameMin);	
			ContinuousSetStamina ();
			PlayerPrefs.SetFloat ("PlayerStamina", stamina);
			PlayerPrefs.SetFloat ("PlayerCleaness", cleaness);
		}

		if (sceneNum == 1) {
			StatusBar ();
		}

		if (sceneNum == 1 || sceneNum == 2) {
			showTime.text = niceTime;	
		}
	}

	void SetStamina(){
		stamina = 3600f;

	}

	void SetPreStamina(){
		stamina = PlayerPrefs.GetFloat ("PlayerStamina");

	}

	void FirstSetting(){
		SetStamina ();
		days = 1;
		PlayerPrefs.SetInt ("Day",days);
		inGameHour = 9;
		inGameMin = 0;
		inGameSecound = 0f;
		cleaness = 1000f;
		PlayerPrefs.SetFloat ("PointChar1", 50f);
		PlayerPrefs.SetFloat ("PointChar2", 50f);
		PlayerPrefs.SetFloat ("PointChar3", 50f);
		PlayerPrefs.SetFloat ("PointChar4", 50f);
		Status1 = PlayerPrefs.GetFloat ("PointChar1");
		Status2 = PlayerPrefs.GetFloat ("PointChar2");
		Status3 = PlayerPrefs.GetFloat ("PointChar3");
		Status4 = PlayerPrefs.GetFloat ("PointChar4");
	}

	void ContinuousSetStamina(){
		if (sceneNum == 0) {
			stamina -= 1.5f * Time.deltaTime;
			if (stamina <= 0) {
				ToTotalPage ();
			}
		} else if (sceneNum == 1) {
			stamina -= 1f * Time.deltaTime;
			if (stamina <= 0) {
				ToTotalPage ();
			}
		} else if (sceneNum == 2) {
			stamina -= 1.5f * Time.deltaTime;
			if (stamina <= 0) {
				ToTotalPage ();
			}
		} else if (sceneNum == 3) {
			stamina -= 2 * Time.deltaTime;
			if (stamina <= 0) {
				ToTotalPage ();
			}
		} else if (sceneNum == 4) {
			stamina -= 2 * Time.deltaTime;
			if (stamina <= 0) {
				ToTotalPage ();
			}
		}
	}

	public void ToTotalPage(){
		days++;
		PlayerPrefs.SetInt ("Day",days);
		SceneManager.LoadScene ("TotalStatus");
	}

	public void SetPreviousTime (){
		inGameHour = PlayerPrefs.GetInt ("Hour");
		inGameMin = PlayerPrefs.GetInt ("Min");
	}

	public void GameTime(){
		if (sceneNum == 0 || sceneNum == 1 || sceneNum == 2) {
			inGameSecound += 12 * Time.deltaTime;
		} 

		if (inGameSecound >= 60f) {
			inGameSecound = 0;
			inGameMin++;

		}

		if (inGameMin >= 60) {
			inGameMin = 0;
			inGameHour++;

		}
		PlayerPrefs.SetInt ("Min", inGameMin);
		PlayerPrefs.SetInt ("Hour", inGameHour);
	}

	public void LoseTime(){

		if (PlayerPrefs.GetInt ("PlayedGame") == 2) {
			inGameMin += 10;
		} else if (sceneNum == 3 || sceneNum == 4) {
			inGameMin += 30;
		}
	}

	public void Cleaness(){
		if (cleaness > 0) {
			cleaness -= Time.deltaTime;
			PlayerPrefs.GetFloat ("CleanScore");
		} else if (cleaness <= 0) {
			cleaness = 0;
			cleanScore = PlayerPrefs.GetInt ("CleanScore") - 20;
			PlayerPrefs.GetFloat ("CleanScore");
		}
	}

	public void LoadAllStatus(){
		
		PlayerPrefs.GetInt ("CleanScore");
	}



	public void ShowAllStatus(){
		float ratio0 = PlayerPrefs.GetFloat("PointChar1") / 100;
		bar[0].transform.localScale = new Vector3 (ratio0, 1, 1);
		float ratio1 = PlayerPrefs.GetFloat("PointChar2") / 100;
		bar[1].transform.localScale = new Vector3 (ratio1, 1, 1);
		float ratio2 = PlayerPrefs.GetFloat("PointChar3") / 100;
		bar[2].transform.localScale = new Vector3 (ratio2, 1, 1);
		float ratio3 = PlayerPrefs.GetFloat("PointChar4") / 100;
		bar[3].transform.localScale = new Vector3 (ratio3, 1, 1);
	}

	public void DeletePref(){
		PlayerPrefs.DeleteAll ();
	}

	public void Toilet(){
		PlayerPrefs.SetFloat ("PlayerCleaness", 1800f);
		cleaness = PlayerPrefs.GetFloat ("PlayerCleaness");
	}

	public void Game1ToIso(){
		inGameHour = 13;
		inGameMin = 0;
		PlayerPrefs.SetInt ("Hour",inGameHour);
		PlayerPrefs.SetInt ("Min",inGameMin);
		SceneManager.LoadScene ("Isometric", LoadSceneMode.Single);
	}

	public void Game2ToIso(){
		inGameHour = 13;
		inGameMin = 30;
		PlayerPrefs.SetInt ("Hour",inGameHour);
		PlayerPrefs.SetInt ("Min",inGameMin);

	}

	public void StatusBar(){
		
		float ratio = stamina / 3600;

		bar1.transform.localScale = new Vector3 (ratio, 1, 1);

		float ratio2 = cleaness / 1000;

		bar2.transform.localScale = new Vector3 (ratio2, 1, 1);
	}
}
