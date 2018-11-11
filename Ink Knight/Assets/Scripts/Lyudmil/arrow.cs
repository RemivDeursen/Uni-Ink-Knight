using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrow : MonoBehaviour {
    public float speed = 5f;
    public Rigidbody2D rb;
    GameObject player;
    string direction;

    private void Start()
    {
        if (gameObject.transform.parent.transform.parent.GetComponent<SpriteRenderer>().flipX == true)
        {
            //    rb.velocity = -transform.right * speed;
            rb.velocity = -transform.right * speed;
            gameObject.transform.Rotate(new Vector3(0, 0, 90));
        }
        else
        {
            rb.velocity = transform.right * speed;
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
            gameObject.GetComponent<CircleCollider2D>().offset = new Vector2(0.08f, 0.1f);
            gameObject.transform.Rotate(new Vector3(0, 0, 270));
        }
           
        
        player = GameObject.Find("Player");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Floor"))
        {
            gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
            StartCoroutine(DestroyArrow());
        }
        if (collision.gameObject.GetComponent<Collider2D>().name == "LeftCollider"  || collision.gameObject.GetComponent<Collider2D>().name == "RightCollider")
        {

            gameObject.GetComponent<FixedJoint2D>().enabled = true;
            gameObject.GetComponent<FixedJoint2D>().connectedBody = player.GetComponent<Rigidbody2D>();
            player.GetComponent<Player_Controls>().getHitByArrow();
            StartCoroutine(DestroyArrow());
        }
        if(collision.gameObject.GetComponent<Collider2D>().name == "Sword")
        {
            
        }
    }
    IEnumerator DestroyArrow()
    {
        gameObject.GetComponent<CircleCollider2D>().enabled = false;
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}
