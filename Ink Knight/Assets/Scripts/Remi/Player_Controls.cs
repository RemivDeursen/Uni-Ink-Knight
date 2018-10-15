using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Controls : MonoBehaviour
{
    public enum Directions
    {
        left,
        right
    }
    [SerializeField]
    public Directions MoveDirection = Directions.right;
    public LayerMask groundLayer;
    public Text touchText;
    public Text swipeText;
    private Vector2 BeginSwipe;
    private Vector2 EndSwipe;
    private bool isMoving;
    public Vector2 velocity;
    private Rigidbody2D rb2D;
    private Sprite mySprite;
    private SpriteRenderer sr;
    public bool isGroundedVis = false;
    //public bool isGrounded = false;
    public Player_Data player_Data;
    public AudioSource swingSword;
    public Player_Sword sword; 
    void Start()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        //smallchange
        velocity = new Vector2(0, 0);
        //player_Data.playerSword.GetComponent<PolygonCollider2D>().enabled = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        Movement();
    }

    private bool IsLeftButton;
    private bool IsRightButton;
    private bool IsJumpButton;
    private float speed = 0.5f;
    private float maxSpeed = 2;
    private float timer = 0;
    public bool isGrounded;
    public Animation swordAnim;
    public List<Collider2D> sideColliders;
    private void Movement()
    {
        if (IsJumpButton && isGrounded && velocity.y == 0)
        {
            if (IsLeftButton)
            {


                if (velocity.x >= -maxSpeed)
                {
                    velocity.x -= speed;
                }
            }
            else if (IsRightButton)
            {

                if (velocity.x <= maxSpeed)
                {
                    velocity.x += speed;
                }
            }
            velocity.y = 7;
            IsJumpButton = false;
        }
        else if (!IsJumpButton)
        {
            if (IsLeftButton)
            {
                if (velocity.x >= -maxSpeed)
                {
                    velocity.x -= speed;
                }
            }
            else if (IsRightButton)
            {
                if (velocity.x <= maxSpeed)
                {
                    velocity.x += speed;
                }
            }
        }
        if (!IsRightButton && !IsLeftButton)
        {
            if (velocity.x > 0)
            {
                velocity.x -= speed;
            }
            else if (velocity.x < 0)
            {
                velocity.x += speed;
            }
        }
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = 0;
        }
        else if (!isGrounded && velocity.y > -10)
        {
            velocity.y -= 0.5f;
        }
        rb2D.MovePosition(rb2D.position + velocity * Time.deltaTime);
    }
    public void getHit(string direction)
    {
        GetComponent<Animator>().SetTrigger("isHit");
        foreach (Collider2D item in sideColliders)
        {
            item.enabled = false;
        }
        if (direction == "right")
            {
                velocity.x = -3f;
                velocity.y = 4;
            }
            if (direction == "left")
            {
                velocity.x = 3f;
                velocity.y = 4;
            }
        Invoke("makePlayerHittable", 1f);
    }
    public void makePlayerHittable()
    {
        GetComponent<Animator>().SetTrigger("IsIdle");
        foreach (Collider2D item in sideColliders)
        {
            item.enabled = true;
        }
    }
    public void OnLeftButton()
    {
        IsLeftButton = true;
        MoveDirection = Directions.left;
        Debug.Log(MoveDirection.ToString());
        player_Data.playerSword.GetComponent<Animator>().SetBool("Forward", false);
        GetComponent<SpriteRenderer>().flipX = true;
        GetComponent<Animator>().SetTrigger("IsRunning");
    }
    public void OnLeftButtonRelease()
    {
        IsLeftButton = false;
        GetComponent<Animator>().SetTrigger("IsIdle");
    }
    public void OnRightButton()
    {
        IsRightButton = true;
        MoveDirection = Directions.right;
        Debug.Log(MoveDirection.ToString());
        player_Data.playerSword.GetComponent<Animator>().SetBool("Forward", true);
        GetComponent<SpriteRenderer>().flipX = false;
        GetComponent<Animator>().SetTrigger("IsRunning");
    }
    public void OnRightButtonRelease()
    {
        IsRightButton = false;
        GetComponent<Animator>().SetTrigger("IsIdle");
    }

    public void OnJumpButton()
    {
        IsJumpButton = true;
    }
    public void OnJumpButtonRelease()
    {
        IsJumpButton = false;
    }
    public void OnAttackButton()
    {
       
            player_Data.playerSword.GetComponent<PolygonCollider2D>().enabled = true;
            player_Data.playerSword.GetComponent<SpriteRenderer>().enabled = true;
            player_Data.playerSword.GetComponent<Animator>().SetTrigger("Attack");
            if (sword.isActiveAndEnabled)
                GetComponent<AudioSource>().Play();
        Invoke("colliderOff", 0.5f);
    }
    public void colliderOff()
    {
        Debug.Log("colliderOFF");
        player_Data.playerSword.GetComponent<PolygonCollider2D>().enabled = false;
        
    }
    public void OnAttackButtonRelease()
    {
        
    }
}
