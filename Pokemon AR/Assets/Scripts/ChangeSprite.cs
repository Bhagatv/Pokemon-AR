using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSprite : MonoBehaviour {
    public Sprite arrowNorth, arrowEast, arrowSouth, arrowWest;
    public int index = 0;
    public bool increaseIndex = false;

    int[] arrows = new int[30];
    // Use this for initialization
    void Start ()
    {
        arrows = RandomizeArrows(arrows);
    }

    // Update is called once per frame
    void Update ()
    {
        if (increaseIndex == true)
            ArrowsMoving();
    }

    IEnumerator Wait(int arrow)
    {
        yield return new WaitForSeconds(5.0f);
        if (arrow == 0)
        {
            Debug.Log("Changing to north");
            this.GetComponent<SpriteRenderer>().sprite = arrowNorth;
        }
        else if (arrow == 1)
        {
            Debug.Log("Changing to east");
            this.GetComponent<SpriteRenderer>().sprite = arrowEast;
        }
        else if (arrow == 2)
        {
            Debug.Log("Changing to south");
            this.GetComponent<SpriteRenderer>().sprite = arrowSouth;
        }
        else if (arrow == 3)
        {
            Debug.Log("Changing to west");
            this.GetComponent<SpriteRenderer>().sprite = arrowWest;
        }
    }

    void ArrowsMoving()
    {
        increaseIndex = false;
        int idx = 0;
        while (idx < 30)
        {
            Debug.Log(arrows[idx]);
            StartCoroutine(Wait(arrows[idx]));
            idx++;
        }
    }

    public int[] RandomizeArrows(int[] arrows)
    {
        for (int i = 0; i < 30; i++)
        {
            arrows[i] = Random.Range(0, 4);
        }
        return arrows;
    }
}
