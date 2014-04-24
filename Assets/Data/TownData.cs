using UnityEngine;
using System.Collections;

[System.Serializable]
public class TownData:ScriptableObject{
	public string townName;
	public Hashtable townData;

	public DistrictData[] districts;
	
}
