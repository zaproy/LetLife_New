using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDrop : MonoBehaviour {

	Vector3 dist;
	float posX;
	float posY;
	bool inPot;
    SpriteRenderer a;
	float b;
	public RuleNTime score2;
	public bool eat;

	void Start(){
		inPot = false;
		a = gameObject.GetComponent<SpriteRenderer> ();
		b = 1.0f;
	}

	void OnMouseDown(){
		if (!inPot) {
			dist = Camera.main.WorldToScreenPoint (transform.position);
			posX = Input.mousePosition.x - dist.x;
			posY = Input.mousePosition.y - dist.y;
		}

	}

	void OnMouseDrag(){
		if (!inPot) {
			Vector3 curPos = new Vector3 (Input.mousePosition.x - posX, Input.mousePosition.y - posY, dist.z);
			Vector3 worldPos = Camera.main.ScreenToWorldPoint (curPos);
			transform.position = worldPos;
		}
	}

	void Update(){
		a.color = new Color (1f, 1f, 1f, b);
		if (inPot) {
			b -= Time.deltaTime;
			StartCoroutine (Deactive ());
		}
	}

	void OnTriggerEnter2D(Collider2D putIn){

		if (putIn.gameObject.tag == "Mor") {
			if (eat) {
				inPot = true;
				score2.totalScore += 1;
			} else {
				inPot = true;
				score2.totalScore -= 1;
			}
		}

		if (putIn.gameObject.tag == "floor") {
			Destroy (gameObject);
		}
	}

	IEnumerator Deactive(){
		
		yield return new WaitForSeconds (0.5f);
		gameObject.SetActive (false);
	}
}
