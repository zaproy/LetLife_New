using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WashEq : MonoBehaviour {

	public bool shoe;
	public RuleNTime time;
	public int equip;
	public Transform posE1,posE2,posE3,posE4,posE5;

	public bool isShirt;
	public GameObject water1, water2;
	SpriteRenderer w1,w2;
	public bool isWater;

	Vector3 dist2;
	float posX2;
	float posY2;

	public GameObject[] paper;

	public float o,x;

	int i;

	void Start(){
		i = 0;
		o = 1f;
		x = 1f;
		if (equip == 1) {
			transform.position = posE1.position;
		} else if (equip == 2) {
			transform.position = posE2.position;
		} else if (equip == 4) {
			transform.position = posE4.position;
		} else if (equip == 5) {
			transform.position = posE5.position;
		}

		w1 = water1.GetComponent<SpriteRenderer> ();
		w2 = water2.GetComponent<SpriteRenderer> ();
	}

	void Update(){
		if (isWater ) {

			w1.color = new Color (o, x, x, 1f);
			w2.color = new Color (o, x, x, 1f);
		}

		if (o >= 1f) {
			o = 1f;
		} else if (o <= 0f) {
			o = 0f;
		}

		if (x >= 1f) {
			x = 1f;
		} else if (x <= 0f) {
			x = 0f;
		}
		
	}

	void OnMouseDown(){
		if (!isWater) {
			dist2 = Camera.main.WorldToScreenPoint (transform.position);
			posX2 = Input.mousePosition.x - dist2.x;
			posY2 = Input.mousePosition.y - dist2.y;
		}
		
			
	}

	void OnMouseDrag(){
		if (!isWater) {
			Vector3 curPos = new Vector3 (Input.mousePosition.x - posX2, Input.mousePosition.y - posY2, dist2.z);
			Vector3 worldPos = Camera.main.ScreenToWorldPoint (curPos);
			transform.position = worldPos;
		}

	}

	void OnMouseUp(){
		if (equip == 1) {
			transform.position = posE1.position;
		} else if (equip == 2) {
			transform.position = posE2.position;
		} else if (equip == 3) {
			transform.position = posE3.position;
		} else if (equip == 4) {
			transform.position = posE4.position;
		} else if (equip == 5) {
			transform.position = posE5.position;
		}
	}
	           
	void OnTriggerEnter2D(Collider2D water){
		if (water.gameObject.tag == "Dirty") {
			
				o -= 0.2f;
			x -= 0.2f;
			
		}

		if (water.gameObject.tag == "Water") {
			time.endScore++;
			if (isShirt) {
				o = 1f;
				x = 1f;

				if (time.timer <= 30) {
					time.endScore++;
				}
			}

			if (shoe && isWater) {
				water1.SetActive (false);
				water2.SetActive (false);
				time.endScore++;
			}
		}

		if (water.gameObject.tag == "Softener") {
			
			if (isShirt) {
				o = 1f;
				x = 0f;
				if (time.timer <= 30) {
					time.endScore++;
				}
			}
		}

		if (water.gameObject.tag == "Paper") {
			
			time.totalScore += 1;
			if (shoe && i < 16) {
				paper [i].SetActive (true);
				i++;
				time.endScore++;
			}
		}
	}
}
