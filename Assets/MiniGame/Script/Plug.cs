using UnityEngine;
using System.Collections;

public class Plug : MonoBehaviour {

	public RuleNTime total;

	public bool usb;
	public bool stereoPlug;
	public bool monitor;
	public bool elecPC;
	public bool lan;

	public GameObject[] plugEffect;

	bool isInteract2;
	public GameObject[] usbPlug;
	Vector3 dist2;
	float posX2;
	float posY2;

	void Start(){
		isInteract2 = true;
	}

	void OnMouseDown(){
		if (isInteract2) {
			dist2 = Camera.main.WorldToScreenPoint (transform.position);
			posX2 = Input.mousePosition.x - dist2.x;
			posY2 = Input.mousePosition.y - dist2.y;
		}
	}

	void OnMouseDrag(){
		if (isInteract2) {
			Vector3 curPos = new Vector3 (Input.mousePosition.x - posX2, Input.mousePosition.y - posY2, dist2.z);
			Vector3 worldPos = Camera.main.ScreenToWorldPoint (curPos);
			transform.position = worldPos;
		}
	}
	void OnTriggerEnter2D(Collider2D pluged){
		if (usb) {
			if (pluged.gameObject.tag == "usb1") {
				Destroy (GetComponent<Rigidbody2D> ());
				isInteract2 = false;
				total.endScore++;;
				transform.position = usbPlug [0].transform.position;
				usbPlug [0].SetActive (false);
				plugEffect [0].SetActive(true);
			} else if (pluged.gameObject.tag == "usb2") {
				Destroy (GetComponent<Rigidbody2D> ());
				isInteract2 = false;
				total.endScore++;
				transform.position = usbPlug [1].transform.position;
				usbPlug [1].SetActive (false);
				plugEffect [1].SetActive(true);
			} else if (pluged.gameObject.tag == "usb3") {
				Destroy (GetComponent<Rigidbody2D> ());
				isInteract2 = false;
				total.endScore++;
				transform.position = usbPlug [2].transform.position;
				usbPlug [2].SetActive (false);
				plugEffect [0].SetActive(true);
			} else if (pluged.gameObject.tag == "usb4") {
				Destroy (GetComponent<Rigidbody2D> ());
				isInteract2 = false;
				total.endScore++;
				transform.position = usbPlug [3].transform.position;
				usbPlug [3].SetActive (false);
				plugEffect [1].SetActive(true);
			}
		} else if (monitor) {
			if (pluged.gameObject.tag == "monitor") {
				Destroy (GetComponent<Rigidbody2D> ());
				isInteract2 = false;
				total.endScore++;
				transform.position = usbPlug [1].transform.position;
				usbPlug [1].SetActive (false);
				plugEffect [2].SetActive(true);
			} else if (pluged.gameObject.tag == "monitorW") {
				transform.position = usbPlug [0].transform.position;
			}
		}else if (stereoPlug) {
			if (pluged.gameObject.tag == "stereo") {
				Destroy (GetComponent<Rigidbody2D> ());
				isInteract2 = false;
				total.endScore++;
				transform.position = usbPlug [0].transform.position;
				usbPlug [0].SetActive (false);
			} else if (pluged.gameObject.tag == "stereoW1") {
				transform.position = usbPlug [1].transform.position;
			} else if (pluged.gameObject.tag == "stereoW2") {
				transform.position = usbPlug [2].transform.position;
			}
		} else if (lan) {
			if (pluged.gameObject.tag == "lan") {
				Destroy (GetComponent<Rigidbody2D> ());
				isInteract2 = false;
				total.endScore++;
				transform.position = usbPlug [0].transform.position;
				usbPlug [0].SetActive (false);
				plugEffect [3].SetActive(true);
			}
		}else if (elecPC) {
			if (pluged.gameObject.tag == "elecPC") {
				Destroy (GetComponent<Rigidbody2D> ());
				isInteract2 = false;
				total.endScore++;
				transform.position = usbPlug [0].transform.position;
				usbPlug [0].SetActive (false);

			}
		}
	}
}
