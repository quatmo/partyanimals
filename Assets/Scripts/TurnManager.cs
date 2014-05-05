using UnityEngine;
using System.Collections;

public class TurnManager : MonoBehaviour {
	private CameraController cameraController;
	private DistrictManager districtManager;
	
	// Use this for initialization
	void Start () {
		cameraController = GetComponent<CameraController>();
		districtManager = GetComponent<DistrictManager>();
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

	[Signal]
	void onClick(DistrictBehaviour districtBehaviour){
		Vector3 districtPosition = districtBehaviour.gameObject.transform.position;
		DistrictData districtData = districtBehaviour.districtData;

		GameManager.GetInstance().setSelectedDistrict(districtData);

		cameraController.zoomIn();
		cameraController.tweenTo(districtPosition.x, districtPosition.y);

		//what state of the game is this?

		//if in start of game


		//if in my turn
		districtManager.showDistrictDataWindow(districtData);
	}

	[Signal]
	void onSortieClicked()
	{
		Application.LoadLevel("Sortie");
	}
}
