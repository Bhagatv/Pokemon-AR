using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class BulbScript : MonoBehaviour
{
    // public Button bulletSeedButton;
    //public GameObject spawnPoint;
    public GameObject bulletSeed;
    public Slider healthbar;
    public GameObject explosion;
    public Image winBoard;
    public Text loseText;
    //public GameObject temp = GameObject.Find("Slider");

    // Use this for initialization
    void Start()
    {
        winBoard.enabled = false;
        loseText.enabled = false;
        //bulletSeedButton.onClick.AddListener(onBulbButton);
        bulletSeed.transform.gameObject.SetActive(false);
        explosion.transform.gameObject.SetActive(false);
       // explosion.SetActive(false);
        StartCoroutine(Wait());
    }
    IEnumerator Wait()
    {
       
       
        while (healthbar.value > 0) //will check if true)
        {
            bool bulb = GameObject.Find("ImageTarget (1)").GetComponent<DefaultTrackableEventHandler>().bulb;
            bool pika = GameObject.Find("ImageTarget (1)").GetComponent<DefaultTrackableEventHandler>().pika;
            bulb = bulb || GameObject.Find("ImageTarget (2)").GetComponent<DefaultTrackableEventHandler>().bulb;
            pika = pika || GameObject.Find("ImageTarget (2)").GetComponent<DefaultTrackableEventHandler>().pika;
            Debug.Log(bulb);
            Debug.Log(pika);
            yield return new WaitForSeconds(3);
            if(bulb && pika)
                bulletSeed.transform.gameObject.SetActive(true);
            yield return new WaitForSeconds(1);
            if (healthbar.value - 10 < 0 && bulb && pika)
            {
                healthbar.value = 0;

            }
            else if(healthbar.value - 10 >= 0 && bulb && pika)
            {
                healthbar.value -= 10;
            }
            yield return new WaitForSeconds(4);
            bulletSeed.transform.gameObject.SetActive(false);
            

        }
        if(healthbar.value <= 0)
        {
            Debug.Log("d");
            //explosion.transform.Find("Trail Black").gameObject.SetActive(true);
            //explosion.SetActive(true);
            explosion.transform.gameObject.SetActive(true);
            yield return new WaitForSeconds(2);
            winBoard.enabled = true;
            loseText.enabled = true;
            Counters.points -= 20;
            yield return new WaitForSeconds(3);
            SceneManager.LoadScene("Market");

            //explosion.SetActive(false);
            //explosion.transform.Find("Trail Black").gameObject.SetActive(true);
        }
    }
    /*
     void onBulbButton()
     {
         StartCoroutine(Wait());

     }
     */
    // Update is called once per frame
    void Update()
    {
        // StartCoroutine(Wait());
    }
}
