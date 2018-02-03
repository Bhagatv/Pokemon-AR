using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowRandomizer : MonoBehaviour {

	// Use this for initialization
	void Start () {
        int[] arrows = new int[30];
        arrows = RandomizeArrows(arrows);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public int[] RandomizeArrows (int[] arrows)
    {
        for (int i = 0; i < 30; i++)
        {
            arrows[i] = Random.Range(0, 3);
        }
        return arrows;
    }

}
