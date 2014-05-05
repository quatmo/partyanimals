using UnityEngine;
using System.Collections;

public class DistrictManager : MonoBehaviour
{
	public GameObject districtDescriptionWindow;
	public iTween.EaseType easeType;
	
	public TownData townData;
		
	private GameObject[] districts;
	private CameraController cameraController;

	// Use this for initialization
	void Start ()
	{
		cameraController = GetComponent<CameraController>();

		GameManager.GetInstance().initialize(townData);

		townData = GameManager.GetInstance().townData;
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

	public void showDistrictDataWindow(DistrictData data){
		districtDescriptionWindow.GetComponent<DistrictWindowDisplay>().districtData = data;
		iTween.MoveTo(districtDescriptionWindow, 
		              iTween.Hash ("y", 3.45, "time", .3, "easetype", easeType));
	}

	[Signal]
	void onCloseDistrictWindow()
	{
		cameraController.zoomOut();
		cameraController.tweenTo(0f, 0f);

		iTween.MoveTo(districtDescriptionWindow, 
	                iTween.Hash ("y", 7, "time", .3, "easetype", easeType));
	}

}

