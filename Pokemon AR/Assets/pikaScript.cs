using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class pikaScript : MonoBehaviour
{
    public Image winBoard;
    public Text winText;
    public Button waterGun;
    //public GameObject spawnPoint;
    public GameObject waterSpray;
    public Slider AIhealthbar;
    public GameObject explosion;
    // Use this for initialization
    void Start()
    {

        waterGun.onClick.AddListener(waterGunDown);
        waterSpray.transform.Find("WaterShower").gameObject.SetActive(false);
        explosion.transform.gameObject.SetActive(false);
        winBoard.enabled = false;
        winText.enabled = false;
    }



    IEnumerator Wait()
    {
        if (AIhealthbar.value > 0)
        {
            waterSpray.transform.Find("WaterShower").gameObject.SetActive(true);
            yield return new WaitForSeconds(1);
            if (AIhealthbar.value - 10 < 0)
            {
                AIhealthbar.value = 0;

            }
            else
            {
                AIhealthbar.value -= 10;
            }
            yield return new WaitForSeconds(10);
            waterSpray.transform.Find("WaterShower").gameObject.SetActive(false);
        }
        else
        {
            //pika won

            explosion.transform.gameObject.SetActive(true);
            yield return new WaitForSeconds(2);
            winBoard.enabled = true;
            winText.enabled = true;
            Counters.points += 20;
            yield return new WaitForSeconds(3);
            SceneManager.LoadScene("Market");

        }
    }
    void waterGunDown()
    {
        StartCoroutine(Wait());
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
