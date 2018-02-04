using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSprite : MonoBehaviour
{
    public Sprite arrowNorth, arrowEast, arrowSouth, arrowWest;
    public bool gameIsOver = false;
    public GameObject swipeDirection;

    int arrow;
    int num_losses = 0;
    int num_wins = 0;

    public int swipeNum;



    // Use this for initialization
    void Start()
    {
        swipeNum = swipeDirection.GetComponent<SwipeDetection>().direction;
        Debug.Log(swipeNum);
        Debug.Log("TESTING");


    }

    IEnumerator Wait(int arrow)
    {
        gameIsOver = true;
        if (arrow == 0)
        {
            this.GetComponent<SpriteRenderer>().sprite = arrowNorth;
            this.GetComponent<SpriteRenderer>().color = Color.white;
            yield return new WaitForSeconds(2);
            if (swipeNum == 0)
                this.GetComponent<SpriteRenderer>().color = Color.green;
            else
                this.GetComponent<SpriteRenderer>().color = Color.red;
        }
        else if (arrow == 1)
        {
            this.GetComponent<SpriteRenderer>().sprite = arrowEast;
            this.GetComponent<SpriteRenderer>().color = Color.white;
            yield return new WaitForSeconds(2);
            if (swipeNum == 1)
                this.GetComponent<SpriteRenderer>().color = Color.green;
            else
                this.GetComponent<SpriteRenderer>().color = Color.red;
        }
        else if (arrow == 2)
        {
            this.GetComponent<SpriteRenderer>().sprite = arrowSouth;
            this.GetComponent<SpriteRenderer>().color = Color.white;
            yield return new WaitForSeconds(2);
            if (swipeNum == 2)
                this.GetComponent<SpriteRenderer>().color = Color.green;
            else
                this.GetComponent<SpriteRenderer>().color = Color.red;
        }
        else if (arrow == 3)
        {
            this.GetComponent<SpriteRenderer>().sprite = arrowWest;
            this.GetComponent<SpriteRenderer>().color = Color.white;
            yield return new WaitForSeconds(2);
            if (swipeNum == 3)
                this.GetComponent<SpriteRenderer>().color = Color.green;
            else
                this.GetComponent<SpriteRenderer>().color = Color.red;
        }
        yield return new WaitForSeconds(1);
        swipeDirection.GetComponent<SwipeDetection>().hasBeenSwiped = false;
        swipeNum = -1;
        gameIsOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        swipeNum = swipeDirection.GetComponent<SwipeDetection>().direction;
        if (!gameIsOver)
        {
            arrow = Random.Range(0, 4);
            Debug.Log(arrow);
            StartCoroutine(Wait(arrow));
      
            IsGameOver();
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
