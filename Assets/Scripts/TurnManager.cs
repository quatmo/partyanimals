using UnityEngine;
using System.Collections;

public class TurnManager : MonoBehaviour {
	public const int SELECT_BASE = 1;
	public const int MY_TURN = 2;
	public const int ENEMY_TURN = 3;

	public GameObject playerAvatar;
	public tk2dTextMesh statusText;

	private CameraController cameraController;
	private DistrictManager districtManager;

	private int gameState = SELECT_BASE;
	private DistrictBehaviour selectedDistrict;
	
	// Use this for initialization
	void Start () {
		cameraController = GetComponent<CameraController>();
		districtManager = GetComponent<DistrictManager>();
		// Check if this is the start of a game
		if(GameManager.GetInstance().IsNewGame){
			//show district selection screen
			gameState = SELECT_BASE;
			playerAvatar.SetActive(false);
		}else{
			//show where the avatars are based on saved game
			statusText.text = "Turn";
			gameState = MY_TURN;
		}
	}
	
	// Update is called once per frame
	void Update () {

	}

	[Signal]
	void onClick(DistrictBehaviour districtBehaviour){
		Vector3 districtPosition = districtBehaviour.gameObject.transform.position;
		DistrictData districtData = districtBehaviour.districtData;

		selectedDistrict = districtBehaviour;

		GameManager.GetInstance().setSelectedDistrict(districtData);

		cameraController.zoomIn();
		cameraController.tweenTo(districtPosition.x, districtPosition.y);

		//what state of the game is this?
		if(gameState == SELECT_BASE){
			districtManager.showSelectHomeDistrictWindow(districtData);
		}else if(gameState == MY_TURN){
			districtManager.showDistrictDataWindow(districtData);
		}

	}

	[Signal]
	void onSortieClicked()
	{
		Application.LoadLevel("Sortie");
	}

	[Signal]
	void onSelectBaseClicked(){
		//select base for AI
		districtManager.hideHomeDistrictSelectionWindow();
		GameManager.GetInstance().IsNewGame = false;
		GameManager.GetInstance().IsPlayerTurn = true;
		playerAvatar.SetActive(true);

		Vector3 districtPosition = selectedDistrict.gameObject.transform.position;
		playerAvatar.GetComponent<AvatarController>().appearAt(districtPosition.x, districtPosition.y);

		gameState = MY_TURN;

		statusText.text = "Do Sortie";
	}
}
