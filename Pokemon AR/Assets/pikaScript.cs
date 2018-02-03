using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class pikaScript : MonoBehaviour
{
    public Button waterGun;
    //public GameObject spawnPoint;
    public GameObject waterSpray;
    // Use this for initialization
    void Start()
    {

        waterGun.onClick.AddListener(waterGunDown);
        waterSpray.transform.Find("WaterShower").gameObject.SetActive(false);

    }



    IEnumerator Wait()
    {
        waterSpray.transform.Find("WaterShower").gameObject.SetActive(true);
        yield return new WaitForSeconds(10);
        waterSpray.transform.Find("WaterShower").gameObject.SetActive(false);

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
