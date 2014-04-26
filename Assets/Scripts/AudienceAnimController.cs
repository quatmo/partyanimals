using UnityEngine;
using System.Collections;

public class AudienceAnimController : MonoBehaviour {

	private tk2dSpriteAnimator animator;

	// Use this for initialization
	void Start () {
		animator = GetComponent<tk2dSpriteAnimator>();
	}

	// Update is called once per frame
	void Update () {

	}

	public void think(){
		if(!animator.IsPlaying ("think")){
			animator.Play ("think");
		}
	}

	public void walk(){
		if(!animator.IsPlaying("walk")){
			animator.Play("walk");
		}
	}

}
