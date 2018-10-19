﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorColliderScript : MonoBehaviour {

    public Player_Controls player;
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Floor") )
        {
            Debug.Log(player.isGrounded);
            //player.isGrounded = true;
            player.velocity.y = -1;
        }
    }
    }
