using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShirtToWash : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D washMach){
		if (washMach.gameObject.tag == "WashMachine") {

			gameObject.SetActive (false);
		}
	}
}
