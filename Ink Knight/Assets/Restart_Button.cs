using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart_Button : MonoBehaviour {

	public void Restart_Game(){
		SceneManager.LoadScene("Main_Game_Remi");
	}
}
