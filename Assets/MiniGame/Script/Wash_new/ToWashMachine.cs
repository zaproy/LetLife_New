using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToWashMachine : MonoBehaviour {

	public OnSwipe swipe;
	public GameObject[] shirt;
	public bool toWash;
	int i = 0;

	void Update(){
		
		ChangeShirt (swipe.direction);

	}

	void ChangeShirt(string sw){
		
		if (sw == "Left") {

			toWash = true;
			VisualChangeShirt (toWash);
			swipe.direction = "None";
		}
	}

	void VisualChangeShirt(bool wash){
		if (wash && i < 5) {
			
			shirt [i].SetActive (false);
			shirt [i + 1].SetActive (true);
			wash = false;
			i++;
		} else if (wash && i >= 5) {
			Debug.Log ("End");
		}
	}		

}
