using UnityEngine;
using System.Collections;

public class AvatarAnimController : MonoBehaviour {
	
	private tk2dSpriteAnimator animator;
	
	// Use this for initialization
	void Start () {
		animator = GetComponent<tk2dSpriteAnimator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void run(){
		if(!animator.IsPlaying ("run")){
			animator.Play ("run");
		}
	}
	
	public void idle(){
		if(!animator.IsPlaying("idle")){
			animator.Play("idle");
		}
	}
	
}
