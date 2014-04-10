using UnityEngine;
using System.Collections;

public class DistrictManager : MonoBehaviour
{
	public GameObject districtDescriptionWindow;
	public iTween.EaseType easeType;
	public Camera gameCamera;
		
	private float normalCameraSize;
	// Use this for initialization
	void Start ()
	{
		normalCameraSize = gameCamera.orthographicSize;
	}

	// Update is called once per frame
	void Update ()
	{

	}

	[Signal]
	void onClick(Vector3 districtPosition)
	{	
		iTween.ValueTo(gameCamera.gameObject, iTween.Hash(
			"time", 0.6f,
			"from", gameCamera.orthographicSize,
			"to", 3,
			"onupdate", "setZoomCamera",
			"onupdatetarget", this.gameObject
			));
		Debug.Log(districtPosition); 
		iTween.MoveTo(gameCamera.gameObject, iTween.Hash (
			"x", districtPosition.x,
			"y", districtPosition.y,
			"time", 0.6f,
			"easetype", easeType));
		iTween.MoveTo(districtDescriptionWindow, 
	                iTween.Hash ("y", 3.45, "time", .3, "easetype", easeType));
	//Application.LoadLevel("Sortie");
	}

	[Signal]
	void onCloseDistrictWindow()
	{
		iTween.ValueTo(gameCamera.gameObject, iTween.Hash(
			"time", 0.6f,
			"from", gameCamera.orthographicSize,
			"to", normalCameraSize,
			"onupdate", "setZoomCamera",
			"onupdatetarget", this.gameObject
			));
		iTween.MoveTo(gameCamera.gameObject, iTween.Hash (
			"x", 0,
			"y", 0,
			"time", 0.6f,
			"easetype", easeType));
		iTween.MoveTo(districtDescriptionWindow, 
	                iTween.Hash ("y", 7, "time", .3, "easetype", easeType));
	}

	void setZoomCamera(float p){
		gameCamera.orthographicSize = p;
	}

	[Signal]
	void onSortieClicked()
	{
		Application.LoadLevel("Sortie");
	}
}

