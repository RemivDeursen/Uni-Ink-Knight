using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu_Button : MonoBehaviour {
	public GameObject menu;
	public void Toggle_Menu(){
		if(menu.activeSelf){
			menu.SetActive(false);
		}
		else{
			
			menu.SetActive(true);
		}
	}
}
