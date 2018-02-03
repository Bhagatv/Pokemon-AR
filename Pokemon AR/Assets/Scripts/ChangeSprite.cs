using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSprite : MonoBehaviour
{
    public Sprite arrowNorth, arrowEast, arrowSouth, arrowWest;
    public bool gameIsOver = true;

    int arrow;
    int num_losses = 0;
    int num_wins = 0;

    public int index = 0;
    // Use this for initialization
    void Start()
    {
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
            gameIsOver = IsGameOver();
        }
    }

    bool IsGameOver()
    {
        if (num_losses >= 10)
            return true;
        if (num_wins >= 3)
            return true;
        else
            return false;
    }


}
