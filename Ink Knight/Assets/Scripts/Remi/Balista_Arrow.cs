using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balista_Arrow : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine(DestroyAfter5());
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector2.right * Time.deltaTime * 10, Space.Self);
	}

	IEnumerator DestroyAfter5(){
		yield return new WaitForSeconds(5);
		Destroy(this.gameObject);
	}

	private void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.tag == "Boss1Hitbox")
		{
		Destroy(this.gameObject);
		}
	}
}
