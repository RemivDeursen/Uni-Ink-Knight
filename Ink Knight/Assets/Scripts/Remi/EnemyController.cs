﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public enum Directions
    {
        left,
        right
    }
    public Directions MoveDirection = Directions.left;
    public float moveMax = 5;
    public float moveAmmount = 0;
    private float moveSpeed = 1f;
    public Vector2 velocity;
    private Rigidbody2D rb2D;
    public LayerMask groundLayer;
    // Use this for initialization
    void Start()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
       
        velocity = new Vector2(0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded();
        if (MoveDirection == Directions.left)
        {
            GetComponent<SpriteRenderer>().flipX = true;
            if (moveAmmount < moveMax)
            {
                moveAmmount += 1 * Time.deltaTime;
                transform.position = new Vector2(transform.position.x - (moveSpeed * Time.deltaTime), transform.position.y);
            }
            else
            {
                moveAmmount = 0;
                MoveDirection = Directions.right;
            }
        }
        else
        {
            GetComponent<SpriteRenderer>().flipX = false;
            if (moveAmmount < moveMax)
            {
                moveAmmount += 1 * Time.deltaTime;
                transform.position = new Vector2(transform.position.x + (moveSpeed * Time.deltaTime), transform.position.y);
            }
            else
            {
                moveAmmount = 0;
                MoveDirection = Directions.left;
            }
        }

        if (isGrounded() && velocity.y < 0)
        {
            velocity.y = 0;
            velocity.x = 0;
        }
        else if (!isGrounded() && velocity.y > -10)
        {
            velocity.y -= 1f;
        }
        rb2D.MovePosition(rb2D.position + velocity * Time.deltaTime);
    }


    public void getHit(string direction)
    {
        if (direction == "left")
        {
            velocity.x = -4;
            velocity.y = 6;
        }
        if (direction == "right")
        {
            velocity.x = 4;
            velocity.y = 6;
        }

        StartCoroutine(DieAfter2());
    }

    IEnumerator DieAfter2(){
        yield return new WaitForSeconds(1);
        Destroy(this.gameObject);
    }
    
    public bool isGrounded()
    {
        Vector2 position = transform.position;
        Vector2 direction = Vector2.down;
        float distance = 1f;

        RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, groundLayer);
        if (hit.collider != null)
        {
            return true;
        }
        else return false;
    }
}
