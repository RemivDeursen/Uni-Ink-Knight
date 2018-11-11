using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class specialAttack : MonoBehaviour {

    public GameObject beamRight;
    public GameObject beamLeft;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void specialAttack1()
    {
        if (gameObject.transform.parent.GetComponent<SpriteRenderer>().flipX == false)
        {  
            StartCoroutine(BeamOnRight());
        }
        else
        {
            StartCoroutine(BeamOnLeft());
        }
    }
    IEnumerator BeamOnRight()
    {
        gameObject.transform.parent.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        gameObject.transform.parent.GetComponent<Animator>().enabled = false;
       beamRight.GetComponent<SpriteRenderer>().enabled = true;
        beamRight.GetComponent<BoxCollider2D>().enabled = true;
        GetComponent<Animator>().speed = 0;
        yield return new WaitForSeconds(1.5f);
        GetComponent<Animator>().speed = 3;
        beamRight.GetComponent<SpriteRenderer>().enabled = false;
        beamRight.GetComponent<BoxCollider2D>().enabled = false;
        gameObject.transform.parent.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        gameObject.transform.parent.GetComponent<Animator>().enabled = true;
    }

    IEnumerator BeamOnLeft()
    {
        gameObject.transform.parent.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        gameObject.transform.parent.GetComponent<Animator>().enabled = false;
        beamLeft.GetComponent<SpriteRenderer>().enabled = true;
        beamLeft.GetComponent<BoxCollider2D>().enabled = true;
        GetComponent<Animator>().speed = 0;
        yield return new WaitForSeconds(1.5f);
        GetComponent<Animator>().speed = 3;
        beamLeft.GetComponent<SpriteRenderer>().enabled = false;
        beamLeft.GetComponent<BoxCollider2D>().enabled = false;
        gameObject.transform.parent.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        gameObject.transform.parent.GetComponent<Animator>().enabled = true;
    }
    public void runAnimation()
    {
        if (gameObject.transform.parent.GetComponent<SpriteRenderer>().flipX == false)
        {
            GetComponent<Animator>().SetTrigger("specialRight");
        }
        else
        {
            GetComponent<Animator>().SetTrigger("specialLeft");
        }
    }
    
}
