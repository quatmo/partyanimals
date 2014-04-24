using UnityEngine;
using System.Collections;

public class DistrictManager : MonoBehaviour
{
	public GameObject districtDescriptionWindow;
	public iTween.EaseType easeType;
	public Camera gameCamera;

	public TownData townData;
		
	private GameObject[] districts;

	private float normalCameraSize;
	
	// Use this for initialization
	void Start ()
	{
		normalCameraSize = gameCamera.orthographicSize;
		districts = new GameObject[11];
		//load all gameobjects on screen
		//loop through towndata array
		for(int i = 0; i < townData.districts.Length; i++){
			DistrictData districtData = townData.districts[i];
			GameObject go = GameObject.Find(districtData.id);
			Debug.Log(districtData.id);
			DistrictBehaviour db = go.GetComponent<DistrictBehaviour>();
			db.districtData = districtData;
			Debug.Log (db.districtData.districtName);
			districts[i] = go;
		}
	}

	// Update is called once per frame
	void Update ()
	{

	}

	[Signal]
	void onClick(DistrictBehaviour districtBehaviour)
	{	
		Vector3 districtPosition = districtBehaviour.gameObject.transform.position;
		DistrictData districtData = districtBehaviour.districtData;
		iTween.ValueTo(gameCamera.gameObject, iTween.Hash(
			"time", 0.6f,
			"from", gameCamera.orthographicSize,
			"to", 3,
			"onupdate", "setZoomCamera",
			"onupdatetarget", this.gameObject
			));
		Debug.Log(districtPosition);
		Debug.Log (districtData.districtName);
		districtDescriptionWindow.GetComponent<DistrictWindowDisplay>().districtData = districtData;
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

