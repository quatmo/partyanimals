using UnityEngine;
using System.Collections;

public class SortieManager : MonoBehaviour {

	void Start(){
	}

	void Update(){
	}

	[Signal]
	void onDoneClicked()
	{
		GameManager.GetInstance().sortieUpdate();
		Application.LoadLevel("Game");
	}
}
