using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public Camera gameCamera;
	public iTween.EaseType easeType;

	private float normalCameraSize; 

	// Use this for initialization
	void Start () {
		normalCameraSize = gameCamera.orthographicSize;
	}
	
	public void tweenTo(float x, float y){
		iTween.MoveTo(gameCamera.gameObject, iTween.Hash (
			"x", x,
			"y", y,
			"time", 0.6f,
			"easetype", easeType));
	}

	public void zoomIn(){
		iTween.ValueTo(gameCamera.gameObject, iTween.Hash(
			"time", 0.6f,
			"from", gameCamera.orthographicSize,
			"to", 3,
			"onupdate", "setZoomCamera",
			"onupdatetarget", this.gameObject
		));
	}

	public void zoomOut(){
		iTween.ValueTo(gameCamera.gameObject, iTween.Hash(
			"time", 0.6f,
			"from", gameCamera.orthographicSize,
			"to", normalCameraSize,
			"onupdate", "setZoomCamera",
			"onupdatetarget", this.gameObject
			));
	}
	
	void setZoomCamera(float p){
		gameCamera.orthographicSize = p;
	}
}
