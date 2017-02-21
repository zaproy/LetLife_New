using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloomMouse : MonoBehaviour {

	public Vector3 dist4;
	public GameObject bloom;
	public bool isDown;
	float g;
	public bool max;
	
	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButtonDown (0)) {
			
			isDown = true;


		}else if (Input.GetMouseButtonUp (0)) {
			//bloom.transform.Rotate (0, 0, 0);
			isDown = false;
		}

		dist4 = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		dist4.z = 0f;
		transform.position = dist4;

		if (isDown) {
			bloom.transform.Rotate (Vector3.forward, 10 * Time.deltaTime);
		} else if (!isDown && bloom.transform.rotation.z >= 0) {
			bloom.transform.Rotate (Vector3.forward, -500 * Time.deltaTime);
		}
	}
		
}
