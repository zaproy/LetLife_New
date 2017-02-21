using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloomNMob : MonoBehaviour {

	public bool bin;
	Vector3 dist1;
	float posX1;
	float posY1;
	public Transform mPoint;
	int dirtyPoint;
	public float mColor;

	SpriteRenderer mobColor;
	public RuleNTime score3;

	void Start(){
		mColor = 1f;
		dirtyPoint = 0;
		mobColor = gameObject.GetComponent<SpriteRenderer> ();
	}

	void Update(){
		mobColor.color = new Color (mColor,mColor,mColor);
		if (dirtyPoint >= 10) {
			dirtyPoint = 10;
			gameObject.tag = "Untagged";
		} else if (dirtyPoint <= 0) {
			gameObject.tag = "Mob";
		}

	}
	void OnMouseDown(){
		if (!bin && score3.startCount<=0) {
			dist1 = Camera.main.WorldToScreenPoint (transform.position);
			posX1 = Input.mousePosition.x - dist1.x;
			posY1 = Input.mousePosition.y - dist1.y;
		}

	}

	void OnMouseDrag(){
		if (!bin&& score3.startCount<=0) {
			Vector3 curPos = new Vector3 (Input.mousePosition.x - posX1, Input.mousePosition.y - posY1, dist1.z);
			Vector3 worldPos = Camera.main.ScreenToWorldPoint (curPos);
			transform.position = worldPos;
		}

	}

	void OnMouseUp(){
		if (!bin&& score3.startCount<=0) {
			transform.position = mPoint.position;
		}
	}

	void OnTriggerEnter2D(Collider2D mob){
		if (mob.gameObject.tag == "Dirty") {
			if (mColor < 0f) {
				mColor = 0f;
			}	
				mColor -= 0.05f;
				dirtyPoint += 1;
			
		} else if (mob.gameObject.tag == "Water") {
			if (mColor >= 1f) {
				mColor = 1f;
			}
			dirtyPoint -= 2;
			mColor += 0.05f;
		}
	}
}
