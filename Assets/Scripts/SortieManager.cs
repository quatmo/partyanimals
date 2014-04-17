using UnityEngine;
using System.Collections;

public class SortieManager : MonoBehaviour {

	[Signal]
	void onDoneClicked()
	{
		Application.LoadLevel("Game");
	}
}
