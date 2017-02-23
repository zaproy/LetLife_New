using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WashNew : MonoBehaviour {
	
	public GameObject hygine;


	void Awake(){
		hygine.SetActive (false);	
	}


	void OnMouseDown(){
		
		hygine.SetActive (true);

	}



	void OnTriggerEnter2D(Collider2D isDirty){
		if (isDirty.gameObject.tag == "WashMachine") {
			Debug.Log ("Dirty");
		}
	}
}
