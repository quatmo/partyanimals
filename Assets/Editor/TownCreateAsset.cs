using UnityEngine;
using UnityEditor;
using System;

public class TownCreateAsset
{
	[MenuItem("Assets/Create/TownData")]
	public static void CreateAsset ()
	{
		CustomAssetUtility.CreateAsset<TownData>();
	}
}