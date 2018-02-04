using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChangeSprite : MonoBehaviour
{
    public bool done;
    public Image board;
    public Text winText;
    public Text loseText;

    public Sprite arrowNorth, arrowEast, arrowSouth, arrowWest;
    bool gameIsOver = false;
    int arrow;
    bool gameIsOverReal = false;

    public int num_losses = 0;
    public int num_wins = 0;

    public int swipeNum;
    public bool gameWin;
	public GameObject pokemon;
	Animator myanimator;


    // Use this for initialization
    void Start()
    {
        done = false;
        board.enabled = false;
        winText.enabled = false;
        loseText.enabled = false;

		myanimator = pokemon.GetComponent<Animator> ();
        swipeNum = this.GetComponentInChildren<DirectionManager>().direction;
        gameIsOver = false;



    }

    IEnumerator stallForPrep()
    {
        Debug.Log("yeet");
        yield return new WaitForSeconds(3);
        Debug.Log("begin!");


    }
    IEnumerator win()
    {
        board.enabled = true;
        winText.enabled = true;
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Market");

    }

    IEnumerator lose()
    {
        board.enabled = true;
        loseText.enabled = true;
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Market");
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
				myanimator.SetBool ("Success", true);
				yield return new WaitForSeconds (1);
				myanimator.SetBool ("Success", false);
            }
            else
            {
                this.GetComponent<SpriteRenderer>().color = Color.red;
                num_losses++;
				myanimator.SetBool ("Fail", true);
				yield return new WaitForSeconds (1);
				myanimator.SetBool ("Fail", false);
            }
        }
        else if (arrow == 3)
        {
            this.GetComponent<SpriteRenderer>().sprite = arrowEast;
            this.GetComponent<SpriteRenderer>().color = Color.white;
            yield return new WaitForSeconds(2);
            if (swipeNum == 3)
            {
                this.GetComponent<SpriteRenderer>().color = Color.green;
                num_wins++;
				myanimator.SetBool ("Success", true);
				yield return new WaitForSeconds (1);
				myanimator.SetBool ("Success", false);
            }
            else
            {
                this.GetComponent<SpriteRenderer>().color = Color.red;
                num_losses++;
				myanimator.SetBool ("Fail", true);
				yield return new WaitForSeconds (1);
				myanimator.SetBool ("Fail", false);
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
				myanimator.SetBool ("Success", true);
				yield return new WaitForSeconds (1);
				myanimator.SetBool ("Success", false);
            }
            else
            {
                this.GetComponent<SpriteRenderer>().color = Color.red;
                num_losses++;
				myanimator.SetBool ("Fail", true);
				yield return new WaitForSeconds (1);
				myanimator.SetBool ("Fail", false);
            }
        }
        else if (arrow == 1)
        {
            this.GetComponent<SpriteRenderer>().sprite = arrowWest;
            this.GetComponent<SpriteRenderer>().color = Color.white;
            yield return new WaitForSeconds(2);
            if (swipeNum == 1)
            {
                this.GetComponent<SpriteRenderer>().color = Color.green;
                num_wins++;
				myanimator.SetBool ("Success", true);
				yield return new WaitForSeconds (1);
				myanimator.SetBool ("Success", false);
            }
            else
            {
                this.GetComponent<SpriteRenderer>().color = Color.red;
                num_losses++;
				myanimator.SetBool ("Fail", true);
				yield return new WaitForSeconds (1);
				myanimator.SetBool ("Fail", false);
            }
        }

        yield return new WaitForSeconds(1);
        this.GetComponentInChildren<DirectionManager>().isPressed = false;
        this.GetComponentInChildren<DirectionManager>().direction = -1;
        gameIsOver = false;
        IsGameOver();
    }

    // Update is called once per frame
    void Update()
    {
        bool pika = GameObject.Find("WorkingPikachuCard").GetComponent<DefaultTrackableEventHandler>().pika;

        if (pika)
        {
            //if (!this.GetComponentInChildren<DirectionManager>().isPressed)
            swipeNum = this.GetComponentInChildren<DirectionManager>().direction;
            if (!gameIsOver)
            {
                arrow = Random.Range(0, 4);
                Debug.Log(arrow);
                StartCoroutine(Wait(arrow));

            }

            if (gameIsOverReal)
            {
                if (gameWin)
                {
                    if (!done)
                    {
                        done = true;
                        Counters.happiness += 20;
                        StartCoroutine(win());
                    }

                }
                else
                {
                    if (!done)
                    {
                        done = true;
                        Counters.happiness -= 20;
                        StartCoroutine(lose());
                    }

                }
            }

        }
    }

    void IsGameOver()
    {
        if (num_losses >= 3)
        {
            gameIsOverReal = true;
            gameIsOver = true;
            gameWin = false;
        }
        if (num_wins >= 10)
        {
            gameIsOverReal = true;
            gameIsOver = true;
            gameWin = true;

        }
    }


}
