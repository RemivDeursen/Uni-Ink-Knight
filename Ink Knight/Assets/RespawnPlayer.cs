using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPlayer : MonoBehaviour {
	public Transform respawnPoint;
	public GameObject player;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnCollisionEnter2D(Collision2D other) {
		if(other.gameObject.tag == "Player"){
			player.transform.position = respawnPoint.position;
		}
	}
}
