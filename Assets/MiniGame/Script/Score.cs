using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {

	//Check Score when objects hit a desk
	//Must do(Create Another area to check where to place objects)
	//Attatch to area
	public ParticleSystem clickParticle;
	public AudioSource clickSound;
	public int score;
	public RuleNTime total;
	//Select Area
	public bool book;
	public bool pen;
	public bool keyboard;
	public bool monitor;
	public bool pc;
	public bool stereo;
	public bool mouse;

	void OnTriggerEnter2D(Collider2D sc){
		if (book) {
			if (sc.gameObject.tag == "book") {
				AddScore();
			}
		} else if (pen) {
			if (sc.gameObject.tag == "pen") {
				AddScore();;
			}
		}else if (monitor) {
			if (sc.gameObject.tag == "monitor") {
				AddScore();
			}
		}else if (pc) {
			if (sc.gameObject.tag == "pc") {
				AddScore();
			}
		}else if (keyboard) {
			if (sc.gameObject.tag == "keyboard") {
				AddScore();
			}
		}else if (mouse) {
			if (sc.gameObject.tag == "mouse") {
				AddScore();
			}
		}else if (stereo) {
			if (sc.gameObject.tag == "stereo") {
				AddScore();
			}
		}
	}
	
	void AddScore(){
		clickSound.Play();
		total.endScore += 1;
		gameObject.GetComponent<BoxCollider2D>().enabled = false;
	}
}
