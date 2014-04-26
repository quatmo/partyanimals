using UnityEngine;
using System.Collections;

public class AudienceAIController : MonoBehaviour {

	private AudienceAnimController anim;

	private enum AudienceState {
		WALKING,
		THINK
	};

	private AudienceState state;
	private float attention = 0f;

	// Use this for initialization
	void Start () {
		anim = GetComponent<AudienceAnimController>();
		state = AudienceState.WALKING;
		anim.walk ();
	}
	
	// Update is called once per frame
	void Update () {
		//called everytime
		if(state == AudienceState.WALKING){
			//count to 10
			attention+=.2f;
			if(attention > 100f){
				state = AudienceState.THINK;
				anim.think ();
				attention = 0f;
			}
		}else if(state == AudienceState.THINK){
			attention+=.2f;
			if(attention > 100f){
				state = AudienceState.WALKING;
				anim.walk();
				attention = 0f;
			}

		}
	}

}
