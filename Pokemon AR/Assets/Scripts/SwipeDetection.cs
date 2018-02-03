using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeDetection : MonoBehaviour {

	public bool isSwiping;

	public float minSwipeDistance;
	public float errorRange;

	public SwipeDetection direction = SwipeDirection.None;

	public enum SwipeDirection {Right, Left, Up, Down, None};

	private Touch initialTouch;

	// Use this for initialization
	void Start () {
		Input.multiTouchEnabled = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.touchCount <= 0) {
			return;
		}
		print (direction);
		foreach (var touch in Input.touches) {
			if (touch.phase == TouchPhase.Began) {
				initialTouch = touch;
			} else if (touch.phase == TouchPhase.Moved) {
				float deltaX = touch.position.x - initialTouch.position.x;
				float deltaY = touch.position.y - initialTouch.position.y;
				float swipeDistance = Mathf.Abs (deltaX) + Mathf.Abs (deltaY);
				if (swipeDistance > minSwipeDistance && (Mathf.Abs (deltaX) > 0 || Mathf.Abs (deltaY) > 0)) {
					isSwiping = true;

					CalculateSwipeDirection (deltaX, deltaY);
				}
			}
			else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled) {
				initialTouch = new Touch ();
				isSwiping = false;
				direction = SwipeDirection.None;
			}

		}
	}

	void CalculateSwipeDirection(float deltaX, float deltaY){
		bool isHorizontalSwipe = Mathf.Abs (deltaX) > Mathf.Abs (deltaY);

		if (isHorizontalSwipe && Mathf.Abs (deltaY) <= errorRange) {
			if (deltaX > 0) {
				direction = SwipeDirection.Right;
			} else {
				direction = SwipeDirection.Left;
			}
		} else if (!isHorizontalSwipe && Mathf.Abs (deltaX) <= errorRange) {
			if (deltaY > 0) {
				direction = SwipeDirection.Up;
			} else {
				direction = SwipeDirection.Down;
			}
		} else {
			isSwiping = false;
		}
	
	}
}
