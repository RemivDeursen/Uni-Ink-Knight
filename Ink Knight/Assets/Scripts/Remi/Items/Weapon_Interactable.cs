using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Interactable : MonoBehaviour {
	public Player_Sword sword;
	public NPC_Blockade Npc;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Weapon_Pickup(){
		sword.gameObject.SetActive(true);
		Npc.GetComponent<BoxCollider2D>().enabled = false;
	}
}
