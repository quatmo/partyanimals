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
		Debug.Log ("State is: "+GameManager.GetInstance().state.isNewGame);
		if(GameManager.GetInstance().state.isNewGame){
			//show district selection screen
			gameState = SELECT_BASE;
			playerAvatar.SetActive(false);
		}else{
			//show where the avatars are based on saved game
			statusText.text = "Turn";
			gameState = MY_TURN;
			initializePlayer(GameManager.GetInstance().state.humanPlayer);
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
		GameManager.GetInstance().state.isNewGame = false;

		PlayerData playerData = new PlayerData();
		playerData.avatar = playerAvatar.GetComponent<AvatarController>();
		playerData.hq = selectedDistrict.districtData;
		playerData.hqID = selectedDistrict.districtData.id;
		GameManager.GetInstance().state.humanPlayer = playerData;

		playerAvatar.SetActive(true);

		initializePlayer(playerData);

		gameState = MY_TURN;

		statusText.text = "Do Sortie";
	}

	private void initializePlayer(PlayerData playerData){
		if(playerData.hq == null){
			playerData.hq = GameManager.GetInstance().findDistrict(playerData.hqID).districtData;
		}

		Vector3 districtPosition = new Vector3(playerData.hq.x, playerData.hq.y, 0);

		playerAvatar.GetComponent<AvatarController>().appearAt(districtPosition.x, districtPosition.y);

	}
}
