using UnityEngine;
using System.Collections;

public class TurnManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		// Check if this is the start of a game
		if(GameManager.GetInstance().IsNewGame){
			//show district selection screen
		}else{
			//show where the avatars are based on saved game
		}
	}
	
	// Update is called once per frame
	void Update () {

	}
}
