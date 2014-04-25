using UnityEngine;
using System.Collections;

public class DistrictBehaviour : MonoBehaviour {

	public iTween.EaseType easeType;
	public DistrictData districtData
	{
		get {return _districtData;}
		set {
			_districtData = value;
			Debug.Log ("Updating district data");
			transform.GetComponent<DistrictHUD>().updateDistrictData(_districtData);
		}
	}
	public Shader toonShader;
	private Shader originalShader;

	public Signal clickMe = new Signal(typeof(DistrictBehaviour));

	private bool isActive;
	private tk2dSprite sprite;
	private DistrictData _districtData;

	// Use this for initialization
	void Start () {
		isActive = false;
//		gameObject.AddComponent("PolygonCollider2D");
		sprite = gameObject.GetComponent<tk2dSprite>();
		var random = Random.Range(.7f, 1.5f);
//		iTween.FadeFrom(gameObject, 0f, random);
		iTween.MoveFrom(gameObject, iTween.Hash ("y", 2, "time", random, "easetype", easeType));
	}

	void OnMouseDown(){
		Color color = sprite.color;
		color.a = .5f;
		if(!isActive){
			color.r = 1;
		}else{
			color.g = 1;
		}
		isActive = !isActive;
		iTween.ValueTo(sprite.gameObject, iTween.Hash(
			"time", 0.6f,
			"from", color,
			"to", new Color(1, 1, 1, 1),
			"onupdate", "setSpriteColor",
			"onupdatetarget", this.gameObject
			));

		clickMe.Invoke(this);
	}

	void setSpriteColor(Color color){
		sprite.color = color;
	}

	// Update is called once per frame
	void Update () {

	}
}
