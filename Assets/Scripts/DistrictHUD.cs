using UnityEngine;
using System.Collections;

public class DistrictHUD : MonoBehaviour {

	// Use this for initialization
	private DistrictData data;
	private TextMesh textmesh;
	private Renderer guiRenderer;

	void Start () {
		textmesh = transform.Find("TextLabel").GetComponent<TextMesh>();
		guiRenderer = transform.Find("TextLabel").renderer;
		data = gameObject.GetComponent<DistrictData>();



		guiRenderer.sortingLayerName = "text";
		textmesh.text = data.districtName;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
