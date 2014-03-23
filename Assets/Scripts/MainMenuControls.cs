using UnityEngine;
using System.Collections;

public class MainMenuControls : MonoBehaviour {
	
	void OnGUI()
	{
		if(GUI.Button(new Rect(Screen.width/2, Screen.height/2, 80, 20), "Start")){
			Application.LoadLevel("Game");
		}
	}
}
