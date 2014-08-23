using UnityEngine;
using System.Collections;

public class DayManager : MonoBehaviour {

	/// <summary>
	/// This is basicly the stats for each Level. Does nothing but store data. 
	/// </summary>

	public bool managerIsLoaded = false;
	public int[] levelTime; //Time of the level
	public int[] foodQuota; //Food required to succeed
	public int[] weaponQuota; //Weapons required to succeed


	void Awake() {
		if(managerIsLoaded == false) { // Starting Manager Setup
			managerIsLoaded = true;
			DontDestroyOnLoad(transform.gameObject);
		} else Destroy (gameObject);
	}

	void Start () {
		CreateTables ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void CreateTables(){
		CreateFoodQuotaTable ();
		CreateWeaponQuotaTable ();
		CreateLevelTimeTable ();
	}

	void CreateFoodQuotaTable() {
		foodQuota = new int[8];
		foodQuota [0] = 6;
		foodQuota [1] = 8;
		foodQuota [2] = 10;
		foodQuota [3] = 14;
		foodQuota [4] = 22;
		foodQuota [5] = 18;
		foodQuota [6] = 20;
		foodQuota [7] = 25;
	}

	void CreateWeaponQuotaTable() {
		weaponQuota = new int[8];
		weaponQuota [0] = 0;
		weaponQuota [1] = 0;
		weaponQuota [2] = 0;
		weaponQuota [3] = 0;
		weaponQuota [4] = 0;
		weaponQuota [5] = 1;
		weaponQuota [6] = 3;
		weaponQuota [7] = 6;
	}

	void CreateLevelTimeTable() {
		levelTime = new int[8];
		levelTime [0] = 50;
		levelTime [1] = 60;
		levelTime [2] = 70;
		levelTime [3] = 80;
		levelTime [4] = 90;
		levelTime [5] = 90;
		levelTime [6] = 90;
		levelTime [7] = 100;
	}

}
