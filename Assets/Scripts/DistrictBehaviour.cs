using UnityEngine;
using System.Collections;

public class DistrictBehaviour : MonoBehaviour {

	public iTween.EaseType easeType;

	// Use this for initialization
	void Start () {
		var random = Random.Range(.7f, 1.5f);
		iTween.MoveFrom(gameObject, iTween.Hash ("y", 2, "time", random, "easetype", easeType));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
