using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BulbScript : MonoBehaviour {
   // public Button bulletSeedButton;
    //public GameObject spawnPoint;
    public GameObject bulletSeed;
    // Use this for initialization
    void Start () {
        //bulletSeedButton.onClick.AddListener(onBulbButton);
        bulletSeed.transform.gameObject.SetActive(false);
        StartCoroutine(Wait());
    }
    IEnumerator Wait()
    {
        int health = 20;
       while(health != 0)
        {

            yield return new WaitForSeconds(2);
            bulletSeed.transform.gameObject.SetActive(true);
            yield return new WaitForSeconds(4);
            bulletSeed.transform.gameObject.SetActive(false);
            health -= 10;
            
        }
    }
   /*
    void onBulbButton()
    {
        StartCoroutine(Wait());

    }
    */
	// Update is called once per frame
	void Update () {
       // StartCoroutine(Wait());
    }
}
