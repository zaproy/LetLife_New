using UnityEngine;
using System.Collections;
using Novel;

public class EventSystem : MonoBehaviour {

	public int eventDate;
	public GameObject[] gameAlert;
	public bool SceneMap;

	void Start () {
		eventDate = PlayerPrefs.GetInt ("Day");
	}

	void Update () {
		if (eventDate == 1) {
			EventDay1 ();
			Debug.Log (PlayerPrefs.GetInt ("PlayedGame"));
		}
	}

	public void EventDay1(){
		if (!SceneMap) {	
			if (PlayerPrefs.GetInt ("PlayedGame") == 0) {
				gameAlert [0].SetActive (true);
			} else if (PlayerPrefs.GetInt ("PlayedGame") == 1) {
				gameAlert [1].SetActive (true);
			}
		}

	}

	public void Event1Day1(){
		//Wrong Place

		if (PlayerPrefs.GetInt ("Day") == 1 && PlayerPrefs.GetInt ("PlayedGame") >= 1) {
			NovelSingleton.StatusManager.callJoker ("wide/scene3Day1", "");
		}
	}

	public void Event2Day1(){
	//introduce Activities
		if (PlayerPrefs.GetInt ("Hour") > 14) {
				NovelSingleton.StatusManager.callJoker ("wide/scene5Day1", "");
		} else if (PlayerPrefs.GetInt ("Hour") < 14) {
			NovelSingleton.StatusManager.callJoker ("wide/scene4Day1", "");
		} else if (PlayerPrefs.GetInt ("Hour") == 14) {
			if (PlayerPrefs.GetInt ("Min") > 0) {
				NovelSingleton.StatusManager.callJoker ("wide/scene5Day1", "");
			}else if (PlayerPrefs.GetInt ("Min") <= 0) {
				NovelSingleton.StatusManager.callJoker ("wide/scene5Day1", "");
			}
		}
	}
}
