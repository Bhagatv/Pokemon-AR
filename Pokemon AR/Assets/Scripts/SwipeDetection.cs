using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeDetection : MonoBehaviour {

	public bool isSwiping;

	public float minSwipeDistance;
	public float errorRange;

	public SwipeDetection direction = SwipeDirection.None;

	public enum SwipeDirection {Right, Left, Up, Down, None};

	private Touch intialTouch;

	// Use this for initialization
	void Start () {
		Input.multiTouchEnabled = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.touchCount <= 0) {
			return;
		}

		foreach (var touch in Input.touches) {
			if (touch.phase == TouchPhase.Began) {
				initialTouch = touch;
			}

	}
}
