using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counters : MonoBehaviour
{
    public static int happiness = 0;
    public static int points = 0;
    public Text happy;
    public Text point;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        happy.text = happiness.ToString() + " / 100";
        point.text = points.ToString() + " / 100";
	}
}
