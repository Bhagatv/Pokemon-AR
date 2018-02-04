using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SwipeDetection : MonoBehaviour
{
	public float minSwipeLength = 200f;
	Vector2 isPress;
	Vector2 notPress;
	Vector2 deltaSwipe;

	public static Swipe swipeDirection;

	public enum Swipe { None, Up, Down, Left, Right };
	public Transform Parent;
	public bool currentlySwiping = false;
	public int direction = 5;
	public bool hasBeenSwiped = false;



	void Start()
	{
		
	}

	void Update ()
	{
		DetectSwipe();

	}

	public void DetectSwipe ()
	{
		if (Application.platform != RuntimePlatform.Android || Application.platform != RuntimePlatform.Android) {
			if (Input.GetMouseButtonDown (0)) {
				isPress = new Vector2 (Input.mousePosition.x, Input.mousePosition.y);
				currentlySwiping = true;
			}
			if (Input.GetMouseButtonUp (0)) {
				currentlySwiping = false;
				notPress = new Vector2 (Input.mousePosition.x, Input.mousePosition.y);
				deltaSwipe = new Vector2 (notPress.x - isPress.x, notPress.y - isPress.y);
				deltaSwipe.Normalize ();
			}

			if (deltaSwipe.x > -0.5f && deltaSwipe.y > 0 && deltaSwipe.x < 0.5f && currentlySwiping && !hasBeenSwiped) {
				Debug.Log ("up");
				direction = 0;
				hasBeenSwiped = true;

			}
			if (deltaSwipe.x > -0.5f && deltaSwipe.y < 0 && deltaSwipe.x < 0.5f && currentlySwiping && !hasBeenSwiped) {
				Debug.Log ("down");
				direction = 2;
				hasBeenSwiped = true;
			}
			if (deltaSwipe.x < 0 && deltaSwipe.y > -0.5f && deltaSwipe.y < 0.5f && currentlySwiping && !hasBeenSwiped) {
				Debug.Log ("left");
				direction = 3;
				hasBeenSwiped = true;
			}
			if (deltaSwipe.x > 0 && deltaSwipe.y > -0.5f && deltaSwipe.y < 0.5f && currentlySwiping && !hasBeenSwiped) {
				Debug.Log ("right");
				direction = 1;
				hasBeenSwiped = true;
			}


		} else {
			if (Input.touches.Length > 0) {
				Touch t = Input.GetTouch (0);

				if (t.phase == TouchPhase.Began) {
					isPress = new Vector2 (t.position.x, t.position.y);
				}
				if (t.phase == TouchPhase.Ended) {
					notPress = new Vector2 (t.position.x, t.position.y);
					deltaSwipe = new Vector2 (notPress.x - isPress.x, notPress.y - isPress.y);
				}

				if (deltaSwipe.magnitude < minSwipeLength) {
					swipeDirection = Swipe.None;
					return;
				}

				deltaSwipe.Normalize ();

				if (deltaSwipe.x > -0.5f && deltaSwipe.y > 0 && deltaSwipe.x < 0.5f && currentlySwiping && !hasBeenSwiped) {
					Debug.Log ("up");
					direction = 0;
					hasBeenSwiped = true;

				}
				if (deltaSwipe.x > -0.5f && deltaSwipe.y < 0 && deltaSwipe.x < 0.5f && currentlySwiping && !hasBeenSwiped) {
					Debug.Log ("down");
					direction = 2;
					hasBeenSwiped = true;
				}
				if (deltaSwipe.x < 0 && deltaSwipe.y > -0.5f && deltaSwipe.y < 0.5f && currentlySwiping && !hasBeenSwiped) {
					Debug.Log ("left");
					direction = 3;
					hasBeenSwiped = true;
				}
				if (deltaSwipe.x > 0 && deltaSwipe.y > -0.5f && deltaSwipe.y < 0.5f && currentlySwiping && !hasBeenSwiped) {
					Debug.Log ("right");
					direction = 1;
					hasBeenSwiped = true;
				}


			}
		}
	  
	}

	IEnumerator Delay()
	{
		yield return new WaitForSeconds (5);
	}
}

