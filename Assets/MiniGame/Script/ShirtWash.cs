using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShirtWash : MonoBehaviour {

	public RuleNTime score10;
	SpriteRenderer dirty1;
	float z;
	float x;

	bool detered;
	public GameObject cleanser;

	void Start () {
		z = 1f;
		x = 0f;
		dirty1 = gameObject.GetComponent<SpriteRenderer> ();	
	}
	

	void Update () {
		
		if (detered) {
			dirty1.color = new Color (1f, 1f, 1f, z);
			cleanser.GetComponent<SpriteRenderer> ().color = new Color (1f, 1f, 1f, x);
		} else {
			cleanser.GetComponent<SpriteRenderer> ().color = new Color (1f, 1f, 1f, x);
		}
	}

	void OnTriggerEnter2D(Collider2D deter){
		if (deter.gameObject.tag == "Brush") {
			if (z > 0.5f) {
				z -= 0.1f;

			}


		}

		if (deter.gameObject.tag == "Deter") {
			x += 0.2f;
			if (x >= 1f) {
				detered = true;

			}
		}

		if (deter.gameObject.tag == "Water") {
			if (z <= 0.5f) {
				z -= 0.1f;
				x -= 0.2f;
			}
			if(z>= 0f){
				score10.totalScore+= 2;
			}
		}
	}
}
