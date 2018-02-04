using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSprite : MonoBehaviour
{
    public Sprite arrowNorth, arrowEast, arrowSouth, arrowWest;
    public bool gameIsOver = true;
    public GameObject swipeDirection;

    int arrow;
    int num_losses = 0;
    int num_wins = 0;

    public int index = 0;
    // Use this for initialization
    void Start()
    {
        int a = swipeDirection.GetComponent<SwipeDetection>().direction;
        Debug.Log(a);
        Debug.Log("TESTING");


    }

    IEnumerator Wait(int arrow)
    {
        gameIsOver = true;
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
        gameIsOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameIsOver)
        {
            arrow = Random.Range(0, 4);
            Debug.Log(arrow);
            StartCoroutine(Wait(arrow));
        }
    }

    void IsGameOver()
    {
        if (num_losses >= 10)
            gameIsOver = true;
        if (num_wins >= 3)
            gameIsOver = true;
    }


}
