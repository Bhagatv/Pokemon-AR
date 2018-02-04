using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSprite : MonoBehaviour
{
    public Sprite arrowNorth, arrowEast, arrowSouth, arrowWest;
    public bool gameIsOver = false;

    int arrow;
    public int num_losses = 0;
    public int num_wins = 0;

    public int swipeNum;



    // Use this for initialization
    void Start()
    {
        swipeNum = this.GetComponentInChildren<DirectionManager>().direction;
        Debug.Log(swipeNum);
        Debug.Log("TESTING");
        gameIsOver = false;


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
            {
                this.GetComponent<SpriteRenderer>().color = Color.green;
                num_wins++;
            }
            else
            {
                this.GetComponent<SpriteRenderer>().color = Color.red;
                num_losses++;
            }
        }
        else if (arrow == 1)
        {
            this.GetComponent<SpriteRenderer>().sprite = arrowEast;
            this.GetComponent<SpriteRenderer>().color = Color.white;
            yield return new WaitForSeconds(2);
            if (swipeNum == 1)
            {
                this.GetComponent<SpriteRenderer>().color = Color.green;
                num_wins++;
            }
            else
            {
                this.GetComponent<SpriteRenderer>().color = Color.red;
                num_losses++;
            }
        }
        else if (arrow == 2)
        {
            this.GetComponent<SpriteRenderer>().sprite = arrowSouth;
            this.GetComponent<SpriteRenderer>().color = Color.white;
            yield return new WaitForSeconds(2);
            if (swipeNum == 2)
            {
                this.GetComponent<SpriteRenderer>().color = Color.green;
                num_wins++;
            }
            else
            {
                this.GetComponent<SpriteRenderer>().color = Color.red;
                num_losses++;
            }
        }
        else if (arrow == 3)
        {
            this.GetComponent<SpriteRenderer>().sprite = arrowWest;
            this.GetComponent<SpriteRenderer>().color = Color.white;
            yield return new WaitForSeconds(2);
            if (swipeNum == 3)
            {
                this.GetComponent<SpriteRenderer>().color = Color.green;
                num_wins++;
            }
            else
            {
                this.GetComponent<SpriteRenderer>().color = Color.red;
                num_losses++;
            }
        }

        yield return new WaitForSeconds(1);
        this.GetComponentInChildren<DirectionManager>().isPressed = false;
        this.GetComponentInChildren<DirectionManager>().direction = -1;
        gameIsOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        //if (!this.GetComponentInChildren<DirectionManager>().isPressed)
            swipeNum = this.GetComponentInChildren<DirectionManager>().direction;
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
        if (num_losses >= 3)
            gameIsOver = true;
        if (num_wins >= 10)
            gameIsOver = true;
    }


}
