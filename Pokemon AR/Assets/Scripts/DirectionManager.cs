using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionManager : MonoBehaviour {
    public int direction;
    public bool isPressed = false;
	// Use this for initialization
    public void dir(int name)
    {
        if (!isPressed)
            direction = name;
        isPressed = true;
        Debug.Log(direction);
    }
}
