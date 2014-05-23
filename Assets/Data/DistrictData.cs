using UnityEngine;
using System.Collections;

[System.Serializable]
public class DistrictData:ScriptableObject{

	public string id;
	public string districtName;
	public string description;
	public float winnabilityA;
	public float winnabilityB;
	public int totalPopulation;
	public int votingPopulation;
	public float x;
	public float y;

}
