 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashNDirty : MonoBehaviour {

	public RuleNTime score6;
	public bool trash;
	bool isBin;
	SpriteRenderer dirty;
	float m;

	Rigidbody2D moveT;
	public float speed;
	bool addSpeed;
	float maxSpeed;
	public float mass;
	public bool isDirty;

	void Start () {
		isDirty = true;
		m = 1f;
		isBin = false;
		speed = 0f;
		maxSpeed = 5f;
		moveT = gameObject.GetComponent<Rigidbody2D> ();
		dirty = gameObject.GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		

		if (trash) {
		
			if (isBin) {
				dirty.color = new Color (1f, 1f, 1f, m);
				m -= Time.deltaTime;
				StartCoroutine (DeTrash ());
			}

			if (addSpeed) {
				if (speed >= 0) {
					speed += 1 * Time.deltaTime;
				}
			}
		} else {
			dirty.color = new Color (1f, 1f, 1f, m);
			if (m <= 0) {
				isDirty = false;
				gameObject.SetActive (isDirty);
			}
		}
	}

	void OnMouseDown(){
		if (trash) {
			addSpeed = false;
		}
	}

	void OnMouseDrag(){
		if (trash) {

			addSpeed = true;


		}
	}
	void OnMouseUp(){
		if (trash) {
			addSpeed = false;
			moveT.velocity = transform.right * -speed / mass;
			StartCoroutine(Stop());
		}
	}


	void OnTriggerEnter2D(Collider2D clean){
		if (clean.gameObject.tag == "Mob") {
			m -= 0.1f;
			if (m <= 0f) {
				score6.totalScore += 2;
			}
		}

		if (clean.gameObject.tag == "Bin") {
			isBin = true;
			score6.totalScore += 1;
		}
	}

	IEnumerator DeTrash(){
		yield return new WaitForSeconds (1);
		gameObject.SetActive (false);
	}

	IEnumerator Stop(){
		yield return new WaitForSeconds (3);
		moveT.velocity = transform.right * 0f;
	}
}
