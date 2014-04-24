using UnityEngine;
using System.Collections;

public class DistrictHUD : MonoBehaviour {

	// Use this for initialization
	private DistrictData districtData;
	private TextMesh textmesh;
	private Renderer guiRenderer;

	void Start () {
		textmesh = transform.Find("TextLabel").GetComponent<TextMesh>();
		guiRenderer = transform.Find("TextLabel").renderer;


		guiRenderer.sortingLayerName = "text";
	}

	public void updateDistrictData(DistrictData data)
	{
		Debug.Log ("Executing..." + data.districtName);
		textmesh = transform.Find("TextLabel").GetComponent<TextMesh>();
		districtData = data;
		textmesh.text = districtData.districtName;
	}
	
	// Update is called once per frame
	void Update () {
//		textmesh.text = districtData.districtName;
	}
}
