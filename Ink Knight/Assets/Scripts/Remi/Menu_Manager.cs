using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_Manager : MonoBehaviour {
	public AudioSource newgameAudio;
	public AudioSource quitAudio;
	enum MenuState
	{
		Waiting,
		Newgame,
		Continue,
		Settings,
		Quit
	}
	MenuState menuState = MenuState.Waiting;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(menuState == MenuState.Newgame)
		if(!newgameAudio.isPlaying)
		SceneManager.LoadScene("Main_Game_Lyudmil");
		Debug.Log("Loading Game..");

		
		if(menuState == MenuState.Quit)
		if(!newgameAudio.isPlaying)
		Application.Quit();
		Debug.Log("Exiting Game..");
	}

	public void NewGameClicked(){
		newgameAudio.Play();
		menuState = MenuState.Newgame;
	}

	public void ContinueClicked(){

	}

	public void SettingsClicked(){

	}

	public void QuitClicked(){
		quitAudio.Play();
		menuState = MenuState.Quit;
	}
}
