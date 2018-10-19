using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flickeringAnimation : MonoBehaviour {
    public float spriteBlinkingTimer = 0.0f;
    public float spriteBlinkingMiniDuration = 0.1f;
    public float spriteBlinkingTotalTimer = 0.0f;
    public float spriteBlinkingTotalDuration = 1.0f;
    public GameObject player;
    public void SpriteBlinkingEffect()
    {
        player.GetComponent<SpriteRenderer>().color = Color.red;
        spriteBlinkingTotalTimer += Time.deltaTime;
        if (spriteBlinkingTotalTimer >= spriteBlinkingTotalDuration)
        {
            spriteBlinkingTotalTimer = 0.0f;
            player.GetComponent<SpriteRenderer>().enabled = true;   
            return;
        }
        spriteBlinkingTimer += Time.deltaTime;
        if (spriteBlinkingTimer >= spriteBlinkingMiniDuration)
        {
            spriteBlinkingTimer = 0.0f;
            if (player.GetComponent<SpriteRenderer>().enabled == true)
            {
                player.GetComponent<SpriteRenderer>().enabled = false;  
            }
            else
            {
                player.GetComponent<SpriteRenderer>().enabled = true;   
            }
        }
    }
}
