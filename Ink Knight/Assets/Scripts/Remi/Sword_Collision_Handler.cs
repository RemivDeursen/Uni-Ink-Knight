using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword_Collision_Handler : MonoBehaviour {
    public Rigidbody2D rbEnemy;
    public float x, y;
    public Player_Controls player;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            Debug.Log("Trigger:" + collision.gameObject.name);
            collision.gameObject.GetComponent<EnemyController>().getHit(player.MoveDirection.ToString());
        }
    }
}
