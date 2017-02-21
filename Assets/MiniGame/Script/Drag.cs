using UnityEngine;
using System.Collections;

public class Drag : MonoBehaviour {

	public bool desk2;
	public bool isInteract;
	Vector3 dist;
	float posX;
	float posY;

	void Start(){
		
		isInteract = true;
	}

	void OnMouseDown(){
		if (isInteract) {
			dist = Camera.main.WorldToScreenPoint (transform.position);
			posX = Input.mousePosition.x - dist.x;
			posY = Input.mousePosition.y - dist.y;
		}
	}

	void OnMouseDrag(){
		if (isInteract) {
			Vector3 curPos = new Vector3 (Input.mousePosition.x - posX, Input.mousePosition.y - posY, dist.z);
			Vector3 worldPos = Camera.main.ScreenToWorldPoint (curPos);
			transform.position = worldPos;
		}
	}

	void OnMouseUp(){
		if (isInteract) {
			transform.Rotate (Vector3.forward * 90);
			//Debug.Log ("On");
		}
	}

	void OnCollisionEnter2D(Collision2D colli){
		if (colli.gameObject.tag == "floor") {
			isInteract = false;
			Destroy (GetComponent<Rigidbody2D>());
			if(!desk2)
			GetComponent<BoxCollider2D> ().enabled = false;
		}
	}
}
