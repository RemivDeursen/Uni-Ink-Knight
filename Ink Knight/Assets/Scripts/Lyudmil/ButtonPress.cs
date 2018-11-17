using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonPress : MonoBehaviour {
    public GameObject bridge;
    public Button buildingButton;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Interactables"))
        {
            bridge.SetActive(true);
        }
        if(collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Debug.Log("building button on");
            buildingButton.gameObject.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            buildingButton.gameObject.SetActive(false);
        }
    }
}
