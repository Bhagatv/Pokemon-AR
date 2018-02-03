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
	public Vector3 jumpDistance;
	public float jumpForce = 2.0f;
	public bool isGrounded;
	Rigidbody rb;


	void Start()
	{
		rb = GetComponentInParent<Rigidbody> ();
		jumpDistance = new Vector3 (0.0f, 2.0f, 0.0f);
	}

	void Update ()
	{
		DetectSwipe();

	}

	void OnCollsionStay()
	{
		isGrounded = true;
	}

	public void DetectSwipe ()
	{
		if (Application.platform != RuntimePlatform.Android || Application.platform != RuntimePlatform.Android)
		{
			if (Input.GetMouseButtonDown (0)) {
				isPress = new Vector2 (Input.mousePosition.x, Input.mousePosition.y);
				currentlySwiping = true;
			}
			if (Input.GetMouseButtonUp(0)) {
				currentlySwiping = false;
				notPress = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
				deltaSwipe = new Vector2 (notPress.x - isPress.x, notPress.y - isPress.y);
				deltaSwipe.Normalize ();
			}

			if (deltaSwipe.x > -0.5f && deltaSwipe.y > 0 && deltaSwipe.x < 0.5f && currentlySwiping) {
				Debug.Log ("up");
				rb.AddForce (jumpDistance * jumpForce, ForceMode.Impulse);
				isGrounded = false;

			}
			if (deltaSwipe.x > -0.5f && deltaSwipe.y < 0 && deltaSwipe.x < 0.5f && currentlySwiping) {
				Debug.Log ("down");

			}
			if (deltaSwipe.x < 0 && deltaSwipe.y > -0.5f && deltaSwipe.y < 0.5f && currentlySwiping) {
				Debug.Log ("left");

			}
			if (deltaSwipe.x > 0 && deltaSwipe.y > -0.5f && deltaSwipe.y < 0.5f && currentlySwiping) {
				Debug.Log ("right");

			}


		}
	  
	}

	IEnumerator Delay()
	{
		yield return new WaitForSeconds (5);
	}
}

