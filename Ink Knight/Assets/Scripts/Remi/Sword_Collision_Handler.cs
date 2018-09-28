using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword_Collision_Handler : MonoBehaviour {
    public Rigidbody2D rbEnemy;
    public float x, y;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            Debug.Log("Trigger:" + collision.gameObject.name);
            rbEnemy.AddForce(new Vector2(x*Time.deltaTime*1000, y*Time.deltaTime*1000));
        }
    }
}
