using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {

	//Check Score when objects hit a desk
	//Must do(Create Another area to check where to place objects)
	//Attatch to area

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
				total.totalScore += 1;
			}
		} else if (pen) {
			if (sc.gameObject.tag == "pen") {
				total.totalScore += 1;
			}
		}else if (monitor) {
			if (sc.gameObject.tag == "monitor") {
				total.totalScore += 1;
			}
		}else if (pc) {
			if (sc.gameObject.tag == "pc") {
				total.totalScore += 1;
			}
		}else if (keyboard) {
			if (sc.gameObject.tag == "keyboard") {
				total.totalScore += 1;
			}
		}else if (mouse) {
			if (sc.gameObject.tag == "mouse") {
				total.totalScore += 1;
			}
		}else if (stereo) {
			if (sc.gameObject.tag == "stereo") {
				total.totalScore += 1;
			}
		}
	}
}
