using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balista_Button : MonoBehaviour {
	public enum Button_Type
	{
		down,
		up,
		fire
	}
	public Button_Type button_Type;
	public Balista_Script balista;
    public AudioSource balistaSound;

	private void OnTriggerEnter2D(Collider2D other) {
			Debug.Log("Hit Something");
		if(other.gameObject.tag == "ButtonTrigger"){
			Debug.Log("Hit player");
			if(button_Type == Button_Type.down){
				Debug.Log("Balista Down");
				balista.MoveBalistaDOWN();
			}
			if(button_Type == Button_Type.up){
				Debug.Log("Balista Up");
				balista.MoveBalistaUP();
			}
			if(button_Type == Button_Type.fire){
				balista.FireBalista();
                balistaSound.Play();
			}
		}
	}
}
