using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class normalPikachuScript : MonoBehaviour {
    public GameObject pikachu;
    public GameObject fireworks;
    Animator animator;
    	
	
    public void pikachuPat()
    {
        // fireworks.SetActive(false);
        Counters.happiness++;
        Debug.Log("button clicked");
        animator = pikachu.GetComponent<Animator>();
        StartCoroutine("Wait");
        



    }
   IEnumerator Wait()
    {
        
        animator.SetBool("success", true);
        fireworks.SetActive(true);

        yield return new WaitForSeconds(3.0f);
        animator.SetBool("success", false);
        fireworks.SetActive(false);
        

    }
}
