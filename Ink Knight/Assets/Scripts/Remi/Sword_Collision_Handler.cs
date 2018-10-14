using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword_Collision_Handler : MonoBehaviour {
    public Player_Controls player;
  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            collision.gameObject.GetComponent<EnemyController>().getHit(player.MoveDirection.ToString());
            player.GetComponent<Player_Controls>().ColliderOff();
        }
    }
    
}
