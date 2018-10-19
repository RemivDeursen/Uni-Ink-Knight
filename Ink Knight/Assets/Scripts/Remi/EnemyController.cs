using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
    public float counterHP = 100f;
    public Player_Controls player;
    // Use this for initialization
    void Start()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        startHealth = counterHP;
        velocity = new Vector2(0, 0);
    }

    // Update is called once per frame
    void Update()
    {
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

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = 0;
            velocity.x = 0;
        }
        else if (!isGrounded && velocity.y > -10)
        {
            velocity.y -= 1f;
        }
        rb2D.MovePosition(rb2D.position + velocity * Time.deltaTime);
    }

    public Image HealthBar;
    private float startHealth;
    public void getHit(string direction)
    {
        Debug.Log("hit");
        if (direction == "left")
        {
            velocity.x = -3f;
            velocity.y = 6;
        }
        if (direction == "right")
        {
            velocity.x = 3f;
            velocity.y = 6;
        }
        counterHP= counterHP - 20f;
        HealthBar.fillAmount = counterHP / startHealth;
        if (counterHP <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    
    public bool isGrounded;
    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Floor"))
        {
            this.isGrounded = true;
        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
       
        if (other.gameObject.layer == LayerMask.NameToLayer("Floor"))
        {
            this.isGrounded = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D playerCollision)
    {

        if (playerCollision.name == "LeftCollider")
        {
            player.getHit("left");
        }
        if (playerCollision.name == "RightCollider")
        {
            player.getHit("right");
        }
    }
}
