using UnityEngine;
using System.Collections;

public class AvatarController : MonoBehaviour {

	public AvatarAnimController animPrefab;
	public iTween.EaseType easeType;

	private AvatarAnimController anim;

	// Use this for initialization
	void Start () {
		anim = (AvatarAnimController) Instantiate(animPrefab, transform.position, transform.rotation);
		anim.transform.parent = transform;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void moveTo(float x, float y){
		iTween.MoveTo(gameObject, iTween.Hash (
			"x", x,
			"y", y,
			"time", 0.6f,
			"easetype", easeType));
	}

	public void appearAt(float x, float y){
		Debug.Log("moving to" + x +", "+ y);
		transform.position = new Vector3(x, y, 0f);
	}
}
