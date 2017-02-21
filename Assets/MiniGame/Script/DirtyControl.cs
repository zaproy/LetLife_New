using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtyControl : MonoBehaviour {

	public RuleNTime score9;
	public GameObject[] z;
	DirtyLine y;
	BoxCollider2D x;
	public int dNum;
	bool changeNum;
	// Use this for initialization
	void Start () {
		dNum = 0;
		y = z [dNum].GetComponent<DirtyLine> ();
		x = z [dNum].GetComponent<BoxCollider2D> ();
	}
	
	// Update is called once per frame
	void Update () {

		y = z [dNum].GetComponent<DirtyLine> ();
		x = z [dNum].GetComponent<BoxCollider2D> ();

		if (!y.isDir) {
			x.enabled = false;
			changeNum = true;
			z [dNum].SetActive (false);
			if (changeNum ) {
				if (dNum < 23) {
					dNum++;
					score9.totalScore += 1;
				}
				changeNum = false;

			}
		}
	}
}
