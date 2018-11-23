using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class specialAttackCollider : MonoBehaviour {

    public Player_Controls player;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {

            collision.gameObject.GetComponent<EnemyController>().getHitSpecial(player.MoveDirection.ToString());
            player.GetComponent<Player_Controls>().colliderOff();
        }
    }
 
}
