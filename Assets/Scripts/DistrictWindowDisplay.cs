using UnityEngine;
using System.Collections;

public class DistrictWindowDisplay : MonoBehaviour {

	public DistrictData districtData{
		get {return _districtData;}
		set { 
			_districtData = value;
			updateDistrictData();
		}
	}

	private DistrictData _districtData;
	private tk2dTextMesh titleLabel;
	private tk2dTextMesh descriptionLabel;

	// Use this for initialization
	void Start () {

	}

	private void updateDistrictData(){
//		_districtData.districtName;
		titleLabel = transform.Find ("NameLabel").GetComponent<tk2dTextMesh>();
		titleLabel.text = _districtData.districtName;
		descriptionLabel = transform.Find("DescriptionLabel").GetComponent<tk2dTextMesh>();
		descriptionLabel.text = _districtData.description;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
