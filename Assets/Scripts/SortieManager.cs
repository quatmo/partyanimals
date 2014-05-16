using UnityEngine;
using System.Collections;

public class SortieManager : MonoBehaviour {

	public Camera mainCam;

	public AudienceAIController carabao;
	
	//add AI 
	private AudienceAIController[] carabaos;

	void Start(){
		mainCam.orthographicSize = 3.8f * 2f;

		carabaos = new AudienceAIController[10];

		for(int i = 0; i < 10; i++){
			Vector3 pos = transform.position;
			pos.x += .5f * (float)i;
			pos.y += -5f;
			AudienceAIController cbao = (AudienceAIController) Instantiate(carabao, pos, transform.rotation);
			carabaos[i] = cbao;
			cbao.transform.parent = transform;
		}
	}

	void Update(){
		//update carabaos AI
	}

	[Signal]
	void onDoneClicked()
	{
		GameManager.GetInstance().sortieUpdate();
		Application.LoadLevel("Game");
	}
}
