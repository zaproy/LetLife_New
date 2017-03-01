using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToWashMachine : MonoBehaviour {

	public OnSwipe swipe;
	public GameObject[] shirt;
	public bool toWash;
	public int i = 0;
	public Transform EndPos;
	bool isMove;
	void Update(){
		i = 0;
		ChangeShirt (swipe.direction);
		MoveShirt (isMove);
	}

	void ChangeShirt(string sw){
		
		if (sw == "Left") {

			toWash = true;
			VisualChangeShirt (toWash);

		}
	}

	void VisualChangeShirt(bool wash){
		if (wash && i < 5) {
			
			shirt [i].SetActive (false);
			isMove = true;
			shirt [i + 1].SetActive (true);

			i++;
			swipe.direction = "None";
			wash = false;
		} else if (wash && i >= 5) {
			Debug.Log ("End");
		}
	}		

	void MoveShirt(bool move){
		if (move) {
			shirt [i].transform.position = Vector3.Lerp (shirt [i].transform.position, EndPos.position, 1f * Time.deltaTime);
			shirt [i].transform.localScale = Vector3.Lerp (shirt [i].transform.localScale, EndPos.transform.localScale, 1f * Time.deltaTime);
		}
	}
}
