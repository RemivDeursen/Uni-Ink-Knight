using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPress : MonoBehaviour {

    public bool effectNr1 = false;
    public GameObject bridge;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Interactables"))
        {
            Debug.Log("activate");
            bridge.SetActive(true);
        }
    }
}
