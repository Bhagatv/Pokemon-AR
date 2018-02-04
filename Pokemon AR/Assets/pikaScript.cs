using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class pikaScript : MonoBehaviour
{
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
            explosion.transform.gameObject.SetActive(true);

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
