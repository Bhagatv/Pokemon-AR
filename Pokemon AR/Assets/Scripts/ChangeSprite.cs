using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSprite : MonoBehaviour
{
    public Sprite arrowNorth, arrowEast, arrowSouth, arrowWest;
    int[] arrows = new int[30];
    int arrow;
    public bool isBusy = false;

    public int index = 0;
    // Use this for initialization
    void Start()
    {
        arrows = RandomizeArrows(arrows);
    }


    IEnumerator Wait(int arrow)
    {
        isBusy = true;
        if (arrow == 0)
        {
            this.GetComponent<SpriteRenderer>().sprite = arrowNorth;
            this.GetComponent<SpriteRenderer>().color = Color.white;
            yield return new WaitForSeconds(0.5f);
            this.GetComponent<SpriteRenderer>().color = Color.black;
        }
        else if (arrow == 1)
        {
            this.GetComponent<SpriteRenderer>().sprite = arrowEast;
            this.GetComponent<SpriteRenderer>().color = Color.white;
            yield return new WaitForSeconds(0.5f);
            this.GetComponent<SpriteRenderer>().color = Color.black;
        }
        else if (arrow == 2)
        {
            this.GetComponent<SpriteRenderer>().sprite = arrowSouth;
            this.GetComponent<SpriteRenderer>().color = Color.white;
            yield return new WaitForSeconds(0.5f);
            this.GetComponent<SpriteRenderer>().color = Color.black;
        }
        else if (arrow == 3)
        {
            this.GetComponent<SpriteRenderer>().sprite = arrowWest;
            this.GetComponent<SpriteRenderer>().color = Color.white;
            yield return new WaitForSeconds(0.5f);
            this.GetComponent<SpriteRenderer>().color = Color.black;
        }
        yield return new WaitForSeconds(1);
        isBusy = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isBusy)
        {
            arrow = Random.Range(0, 4);
            Debug.Log(arrow);
            StartCoroutine(Wait(arrow));
        }
    }

    void ArrowsMoving()
    {
        int idx = 0;
        while (index < 30)
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
