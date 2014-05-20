﻿using UnityEngine;
using System.Collections;

public class GameManager {

	// Use this for initialization
	private static GameManager _instance;

	private TownData _townData;

	private DistrictData _selectedDistrict;

	public bool IsNewGame = true;
	public bool IsPlayerTurn = true;

	public PlayerData myPlayer;
	public PlayerData aiPlayer;

	public TownData townData{
		get {return _townData;}
	}

	public DistrictData selectedDistrict{
		get {return _selectedDistrict;}
	}

	public static GameManager GetInstance(){
		if(_instance == null){
			_instance = new GameManager();
		}

		return _instance;
	}


	public void initialize(TownData townData){
		if(!_townData){
			_townData = townData;
		}else{
			Debug.Log("Did not initialize because town data already exists");
		}
	}

	public void setSelectedDistrict(DistrictData district){
		_selectedDistrict = district;
	}

	public void sortieUpdate(){
		//do update selected district
		//Debug.Log("Update district now" + _selectedDistrict.districtName);
	}

	public DistrictBehaviour findDistrict(string id){
		GameObject go = GameObject.Find(id);
		DistrictBehaviour db = go.GetComponent<DistrictBehaviour>();
		return db;
	}
	
}
