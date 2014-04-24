using UnityEngine;
using UnityEditor;
using System;

public class DistrictCreateAsset
{
	[MenuItem("Assets/Create/DistrictData")]
	public static void CreateAsset ()
	{
		CustomAssetUtility.CreateAsset<DistrictData>();
	}
}