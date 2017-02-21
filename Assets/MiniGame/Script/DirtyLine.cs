using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtyLine : MonoBehaviour {

	public bool isDir; 

	void Start(){
		isDir = true;
	}

	void OnTriggerEnter2D(Collider2D d){
		if (d.gameObject.tag == "Mob") {
			isDir = false;
		}
		
	}
}
