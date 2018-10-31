using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdviceScript : MonoBehaviour {

    public Text advice;
    public GameObject sword;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer ==LayerMask.NameToLayer("Player"))
        {
            if (sword.activeInHierarchy == false)
            {
                advice.text = "Go find a weapon so you can help us!";
            }
            else
            {
                advice.text = "Great! Now help us fight the these bandits!";
            }
            advice.gameObject.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            advice.gameObject.SetActive(false);
        }
    }
}
