using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Grounding : MonoBehaviour {

	public Player_Controls player;
    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Floor") || other.gameObject.layer == LayerMask.NameToLayer("Interactables"))
        {
           player.isGrounded = true;
        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Floor") || collision.gameObject.layer == LayerMask.NameToLayer("Interactables"))
        {
           player.isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Level"))
        {
            Debug.Log("Exit");
            //isGrounded = false;
            GetComponent<Animator>().SetBool("IsJumping", true);
        }
        if (other.gameObject.layer == LayerMask.NameToLayer("Floor") || other.gameObject.layer == LayerMask.NameToLayer("Interactables"))
        {
            Debug.Log(player.isGrounded);
            player.isGrounded = false;
        }

    }
}
