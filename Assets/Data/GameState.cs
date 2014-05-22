using UnityEngine;
using System.Collections;

public class GameState:ScriptableObject{
	public PlayerData humanPlayer;
	public PlayerData aiPlayer;

	public PlayerData activePlayer;

	public bool isNewGame = true;
}
