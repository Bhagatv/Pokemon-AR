using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BulbScript : MonoBehaviour
{
    // public Button bulletSeedButton;
    //public GameObject spawnPoint;
    public GameObject bulletSeed;
    public Slider healthbar;
    public GameObject explosion;
    //public GameObject temp = GameObject.Find("Slider");
<<<<<<< HEAD

=======
    
>>>>>>> f9dccff8dda9676eb498b6bcdcf5368d49ad2cdf
    // Use this for initialization
    void Start()
    {
        //bulletSeedButton.onClick.AddListener(onBulbButton);
        bulletSeed.transform.gameObject.SetActive(false);
        explosion.transform.gameObject.SetActive(false);
<<<<<<< HEAD
        // explosion.SetActive(false);
=======
       // explosion.SetActive(false);
>>>>>>> f9dccff8dda9676eb498b6bcdcf5368d49ad2cdf
        StartCoroutine(Wait());
    }
    IEnumerator Wait()
    {
<<<<<<< HEAD


=======
       
       
>>>>>>> f9dccff8dda9676eb498b6bcdcf5368d49ad2cdf
        while (healthbar.value > 0) //will check if true)
        {
            bool bulb = GameObject.Find("ImageTarget (1)").GetComponent<DefaultTrackableEventHandler>().bulb;
            bool pika = GameObject.Find("ImageTarget (1)").GetComponent<DefaultTrackableEventHandler>().pika;
            bulb = bulb || GameObject.Find("ImageTarget (2)").GetComponent<DefaultTrackableEventHandler>().bulb;
            pika = pika || GameObject.Find("ImageTarget (2)").GetComponent<DefaultTrackableEventHandler>().pika;
            Debug.Log(bulb);
            Debug.Log(pika);
            yield return new WaitForSeconds(3);
<<<<<<< HEAD
            if (bulb && pika)
=======
            if(bulb && pika)
>>>>>>> f9dccff8dda9676eb498b6bcdcf5368d49ad2cdf
                bulletSeed.transform.gameObject.SetActive(true);
            yield return new WaitForSeconds(1);
            if (healthbar.value - 10 < 0 && bulb && pika)
            {
                healthbar.value = 0;

            }
<<<<<<< HEAD
            else if (healthbar.value - 10 >= 0 && bulb && pika)
=======
            else if(healthbar.value - 10 >= 0 && bulb && pika)
>>>>>>> f9dccff8dda9676eb498b6bcdcf5368d49ad2cdf
            {
                healthbar.value -= 10;
            }
            yield return new WaitForSeconds(4);
            bulletSeed.transform.gameObject.SetActive(false);
<<<<<<< HEAD


        }
        if (healthbar.value <= 0)
=======
            

        }
        if(healthbar.value <= 0)
>>>>>>> f9dccff8dda9676eb498b6bcdcf5368d49ad2cdf
        {
            Debug.Log("d");
            //explosion.transform.Find("Trail Black").gameObject.SetActive(true);
            //explosion.SetActive(true);
            explosion.transform.gameObject.SetActive(true);
            yield return new WaitForSeconds(3);
            explosion.transform.gameObject.SetActive(false);
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
<<<<<<< HEAD
}
=======
}
>>>>>>> f9dccff8dda9676eb498b6bcdcf5368d49ad2cdf
