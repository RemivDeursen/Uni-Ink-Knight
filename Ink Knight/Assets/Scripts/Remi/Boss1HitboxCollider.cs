using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1HitboxCollider : MonoBehaviour {
	public EnemyController enemy;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnCollisionEnter2D(Collision2D other) {
		Debug.Log(gameObject.name + ": Got hit");
		int i = enemy.getHitBoss();
		if (i == 0)
		{
			
		}
		else{
			Destroy(this.gameObject);
		}
	}
}
