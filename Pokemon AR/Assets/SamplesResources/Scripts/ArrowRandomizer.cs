using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowRandomizer : MonoBehaviour {

    int[] arrows = new int[30];
    //public GameObject arrow;

    // Use this for initialization
    void Start ()
    {
        arrows = RandomizeArrows(arrows);
        ArrowsMoving();
	}

    IEnumerator Wait()
    {
        transform.Translate(Vector3.right * 10 * Time.deltaTime);
        yield return new WaitForSeconds(2);
    }

    void ArrowsMoving()
    {
        StartCoroutine(Wait());
    }
	
	// Update is called once per frame
	void Update ()
    {

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
