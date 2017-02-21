using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoldCloth : MonoBehaviour {

	public enum Swipe
	{
		None,Up,Down,Left,Right
	};

	public GameObject[] clothPart;
	public GameObject[] clothes;
	public int clothType;
	public bool[] clear = {false,false,false};
	Vector2 firstPress;
	Vector2 secondPress;
	Vector2 currentSwipe;

	public RuleNTime score6;

	public int stage;
	int maxStage;

	float changeTime;

	public static Swipe swipeDirection;


	void Start () {
		changeTime = 1f;
		stage = 1;
	}

	void Update () {

		Cloth3Type ();
		if (clear [0] == true && clear [1] == true && clear [2] == true) {
			changeTime -= 1*  Time.deltaTime;
			if (changeTime <= 0) {
				clear [0] = false;
				clear [1] = false;
				clear [2] = false;
				stage += 1;
				changeTime = 1f;
				score6.totalScore += 1;
			}
		}
		StageControl ();
		 
	}

	void OnMouseDown(){
		if (score6.startCount <= 0) {
			firstPress = new Vector2 (Input.mousePosition.x, Input.mousePosition.y);
		}
	}

	void OnMouseUp(){
		if (score6.startCount <= 0) {
			secondPress = new Vector2 (Input.mousePosition.x, Input.mousePosition.y);
			currentSwipe = new Vector2 (secondPress.x - firstPress.x, secondPress.y - firstPress.y);

			currentSwipe.Normalize ();

			if (currentSwipe.y > 0 && currentSwipe.x > -0.2f && currentSwipe.x < 0.2f) {
				swipeDirection = Swipe.Up;
			} else if (currentSwipe.y < 0 && currentSwipe.x > -0.2f && currentSwipe.x < 0.2f) {
				swipeDirection = Swipe.Down;
			} else if (currentSwipe.x < 0 && currentSwipe.y > -0.2f && currentSwipe.y < 0.2f) {
				swipeDirection = Swipe.Left;
			} else if (currentSwipe.x > 0 && currentSwipe.y > -0.2f && currentSwipe.y < 0.2f) {
				swipeDirection = Swipe.Right;
			}
		}
	}

	public void StageControl(){

		if (stage == 2) {
			clothType = 1;
			clothes [0].SetActive (false);
			clothes [1].SetActive (true);
			//score6.totalScore += 1;
		}else if (stage == 3) {
			clothType = 2;
			clothes [1].SetActive (false);
			clothes [2].SetActive (true);
			//score6.totalScore += 1;
		}else if (stage == 4) {
			clothType = 3;
			clothes [2].SetActive (false);
			clothes [3].SetActive (true);
			//score6.totalScore += 1;
		}else if (stage == 5) {
			clothType = 4;
			clothes [3].SetActive (false);
			clothes [4].SetActive (true);
			//score6.totalScore += 1;
		}else if (stage == 6) {
			clothType = 5;
			clothes [4].SetActive (false);
			clothes [5].SetActive (true);
			//score6.totalScore += 1;
		}else if (stage == 7) {
			clothType = 6;
			clothes [5].SetActive (false);
			clothes [6].SetActive (true);
			//score6.totalScore += 1;
		}else if (stage == 8) {
			clothType = 7;
			clothes [6].SetActive (false);
			clothes [7].SetActive (true);
			//score6.totalScore += 1;
		}else if (stage == 9) {
			clothType = 8;
			clothes [7].SetActive (false);
			clothes [8].SetActive (true);
			//score6.totalScore += 1;
		}else if (stage == 10) {
			clothType = 9;
			clothes [8].SetActive (false);
			clothes [9].SetActive (true);
			//score6.totalScore += 1;
		}
	}



	public void Cloth3Type(){
		if (clothType == 0) {
			if (swipeDirection == Swipe.Up) {
				swipeDirection = Swipe.None;
				clothPart [0].SetActive (false);
				clear [0] = true;
			} else if (swipeDirection == Swipe.Left) {
				swipeDirection = Swipe.None;
				clothPart [1].SetActive (false);
				clear [1] = true;
			} else if (swipeDirection == Swipe.Right) {
				swipeDirection = Swipe.None;
				clothPart [2].SetActive (false);
				clear [2] = true;
			}


		} else if (clothType == 1) {
			if (swipeDirection == Swipe.Right) {
				swipeDirection = Swipe.None;
				clothPart [3].SetActive (false);
				clear [2] = true;
				clear [1] = true;
				clear [0] = true;
			}

		}else if (clothType == 2) {
			if (swipeDirection == Swipe.Right) {
				swipeDirection = Swipe.None;
				clothPart [4].SetActive (false);
				clear [0] = true;
			} else if (swipeDirection == Swipe.Down) {
				swipeDirection = Swipe.None;
				clothPart [5].SetActive (false);
				clear [1] = true;
				clear [2] = true;
			} 
		}else if (clothType == 3) {
			if (swipeDirection == Swipe.Up) {
				swipeDirection = Swipe.None;
				clothPart [6].SetActive (false);
				clear [0] = true;
			} else if (swipeDirection == Swipe.Left) {
				swipeDirection = Swipe.None;
				clothPart [7].SetActive (false);
				clear [1] = true;
			} else if (swipeDirection == Swipe.Right) {
				swipeDirection = Swipe.None;
				clothPart [8].SetActive (false);
				clear [2] = true;
			}
		}else if (clothType == 4) {
			if (swipeDirection == Swipe.Up) {
				swipeDirection = Swipe.None;
				clothPart [9].SetActive (false);
				clear [0] = true;
			} else if (swipeDirection == Swipe.Left) {
				swipeDirection = Swipe.None;
				clothPart [10].SetActive (false);
				clear [1] = true;
			} else if (swipeDirection == Swipe.Right) {
				swipeDirection = Swipe.None;
				clothPart [11].SetActive (false);
				clear [2] = true;
			}
		}else if (clothType == 5) {
			if (swipeDirection == Swipe.Right) {
				swipeDirection = Swipe.None;
				clothPart [12].SetActive (false);
				clear [0] = true;
			} else if (swipeDirection == Swipe.Up) {
				swipeDirection = Swipe.None;
				clothPart [13].SetActive (false);
				clear [1] = true;
				clear [2] = true;
			} 
		}else if (clothType == 6) {
			if (swipeDirection == Swipe.Right) {
				swipeDirection = Swipe.None;
				clothPart [14].SetActive (false);
				clear [2] = true;
				clear [1] = true;
				clear [0] = true;
			}

		}else if (clothType == 7) {
			if (swipeDirection == Swipe.Up) {
				swipeDirection = Swipe.None;
				clothPart [15].SetActive (false);
				clear [0] = true;
			} else if (swipeDirection == Swipe.Left) {
				swipeDirection = Swipe.None;
				clothPart [16].SetActive (false);
				clear [1] = true;
			} else if (swipeDirection == Swipe.Right) {
				swipeDirection = Swipe.None;
				clothPart [17].SetActive (false);
				clear [2] = true;
			}
		}else if (clothType == 8) {
			if (swipeDirection == Swipe.Right) {
				swipeDirection = Swipe.None;
				clothPart [18].SetActive (false);
				clear [0] = true;
			} else if (swipeDirection == Swipe.Up) {
				swipeDirection = Swipe.None;
				clothPart [19].SetActive (false);
				clear [1] = true;
				clear [2] = true;
			} 
		}else if (clothType == 9) {
		if (swipeDirection == Swipe.Right) {
			swipeDirection = Swipe.None;
			clothPart [20].SetActive (false);
			clear [0] = true;
		} else if (swipeDirection == Swipe.Down) {
			swipeDirection = Swipe.None;
			clothPart [21].SetActive (false);
			clear [1] = true;
			clear [2] = true;
		} 
	}
	}

}
