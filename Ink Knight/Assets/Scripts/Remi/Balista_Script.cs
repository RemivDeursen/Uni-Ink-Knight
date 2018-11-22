using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balista_Script : MonoBehaviour {
	public GameObject BalistaBow;
	public GameObject ArrowPrefab;
	// Use this for initialization
	Vector3 axis = new Vector3(0,0,1);
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public float turnrate = 10;
	public void MoveBalistaUP(){
		BalistaBow.transform.RotateAround(BalistaBow.transform.position, axis, turnrate);
	}
	public void MoveBalistaDOWN(){
		BalistaBow.transform.RotateAround(BalistaBow.transform.position, axis, -turnrate);
	}
	public void FireBalista(){
		Instantiate(ArrowPrefab, BalistaBow.transform.position, BalistaBow.transform.rotation);
	}
}
