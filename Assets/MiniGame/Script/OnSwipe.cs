using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnSwipe : MonoBehaviour {

	public enum Swipe
	{
		None,Up,Down,Left,Right
	};


	Vector2 firstPress;
	Vector2 secondPress;
	Vector2 currentSwipe;
	public static Swipe swipeDirection;
	public string direction;

	void Update(){
		if (swipeDirection == Swipe.Left) {
			direction = "Left";

			if (direction == "Left") {

				swipeDirection = Swipe.None;
			}

		}
	}




	void OnMouseDown(){
		firstPress = new Vector2 (Input.mousePosition.x, Input.mousePosition.y);
	}

	void OnMouseUp(){
		
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
