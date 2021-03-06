﻿using UnityEngine;
using System.Collections;

public class DayManager : MonoBehaviour {

	/// <summary>
	/// This is basicly the stats for each Level. Does nothing but store data. 
	/// </summary>

	public bool managerIsLoaded = false;
	public int[] levelTime; //Time of the level
	public int[] foodQuota; //Food required to succeed
	public int[] weaponQuota; //Weapons required to succeed
	public int[] startingMoney; //Staring money of the level


	void Awake() {
		if(managerIsLoaded == false) { // Starting Manager Setup
			managerIsLoaded = true;
			DontDestroyOnLoad(transform.gameObject);
		} else Destroy (gameObject);
		CreateTables ();
	}

	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void CreateTables(){
		CreateFoodQuotaTable ();
		CreateWeaponQuotaTable ();
		CreateLevelTimeTable ();
		CreateStartingMoneyTable ();
	}

	void CreateFoodQuotaTable() {
		foodQuota = new int[8];
		foodQuota [0] = 3;
		foodQuota [1] = 7;
		foodQuota [2] = 10;
		foodQuota [3] = 14;
		foodQuota [4] = 40;
		foodQuota [5] = 45;
		foodQuota [6] = 50;
		foodQuota [7] = 80;
	}

	void CreateWeaponQuotaTable() {
		weaponQuota = new int[8];
		weaponQuota [0] = 0;
		weaponQuota [1] = 0;
		weaponQuota [2] = 0;
		weaponQuota [3] = 0;
		weaponQuota [4] = 0;
		weaponQuota [5] = 1;
		weaponQuota [6] = 4;
		weaponQuota [7] = 6;
	}

	void CreateLevelTimeTable() {
		levelTime = new int[8];
		levelTime [0] = 50;
		levelTime [1] = 60;
		levelTime [2] = 70;
		levelTime [3] = 70;
		levelTime [4] = 80;
		levelTime [5] = 90;
		levelTime [6] = 90;
		levelTime [7] = 100;
	}

	void CreateStartingMoneyTable() {
		startingMoney = new int[8];
		startingMoney [0] = 180;
		startingMoney [1] = 200;
		startingMoney [2] = 210;
		startingMoney [3] = 240;
		startingMoney [4] = 300;
		startingMoney [5] = 340;
		startingMoney [6] = 400;
		startingMoney [7] = 450;
	}

}
