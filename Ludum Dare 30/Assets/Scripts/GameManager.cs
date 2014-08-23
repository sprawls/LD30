using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

	static bool managerIsLoaded = false;
	static bool isPaused = false;

	//public variables
	public GameObject truck_prefab;

	//Public for test purposes 
	public int currentDay = 0; // Current Day
	public int money = 180; //Current Money of the player

	public GameObject[] currentTrucks;
	public int[] upgrades; //Tablec of the upgrades the player has (detailed below(OR MAYBE NOT YET!))
	//Current Day Variables
	public int dailyFoodQuota = 10;
	public int currentDailyFoodQuota = 0;
	public int dailyWeaponQuota = 0;
	public int currentDailyWeaponQuota = 0;
	public int maxNumTrucks = 2; //Maximum number of trucks currenty possible
	public float spawnTruckTime = 2f; //Time it takes for trucks to come back
	public float currentDayTimeLeft;
	public bool DayIsStarted = false; // Is the day started ?
	//Goods Stats
	[HideInInspector] public int goods_food_cost = 50;
	[HideInInspector] public int goods_food_reward = 70;
	[HideInInspector] public int goods_food_danger = 0;
	[HideInInspector] public float goods_food_time = 2;
	[HideInInspector] public int goods_alcohol_cost = 80;
	[HideInInspector] public int goods_alcohol_reward = 150;
	[HideInInspector] public int goods_alcohol_danger = 30;
	[HideInInspector] public float goods_alcohol_time = 3.5f;
	[HideInInspector] public int goods_drug_cost = 100;
	[HideInInspector] public int goods_drug_reward = 300;
	[HideInInspector] public int goods_drug_danger = 70;
	[HideInInspector] public float goods_drug_time = 5f;
	[HideInInspector] public int goods_weapon_cost = 500;
	[HideInInspector] public int goods_weapon_reward = 600;
	[HideInInspector] public int goods_weapon_danger = 120;
	[HideInInspector] public float goods_weapon_time = 6.5f;
	//Private Variables
	private Vector3 TruckSpawnPosition;
	private float truckPositionYdiff;
	private float dayTime = 90f; //Time in seconds in a day

	void Awake() {
		gameObject.tag = "manager"; // Set tag of manager
		if(managerIsLoaded == false) { // Starting Manager Setup
			managerIsLoaded = true;
			DontDestroyOnLoad(transform.gameObject);
		} else Destroy (gameObject);

		CreateUpgradeList (); // Creates the upgrade list
	}

	void Start () {
		//FOR TEST PURPOSES
		StartNewDay ();
	}

	void Update () {
		if(isPaused == false) {
			SpawnTrucks(spawnTruckTime); // Spawns trucks if needed

		}
	}

	public void StartNewDay (){ //Starts a new day
		//Create Trucks
		currentTrucks = new GameObject[maxNumTrucks];
		TruckSpawnPosition = new Vector3 (-10f, 2f, 0);
		truckPositionYdiff = -2f;
		SpawnTrucks (0.25f); //Spawn Starting Trucks
		//Start Timers
		DayIsStarted = true;
		StartCoroutine(DayCountdown());
	}

	public void EndDay() {
		DayIsStarted = false;
		Debug.Log ("DAY IS OVER!!!");
	}


	void CreateUpgradeList() {
		/*Upgrade List : 
		 *  0 : truck_box Quantity (+2 boxes / level)
		 *  1 : Faster Production(Faster Box Creation, -20% / level)
		 *  2 : Better Truck (faster return/ less Stall)
		 * 	3 : Better Smuggling (-10% danger / level)
		 *  4 : More Trucks ( + 1 truck / level)
		 *  5 : Better Food ( + 1 foodQuota per food / level)
		 */ 
		// Create  Upgrade list
		upgrades = new int[6];
		for(int i = 0; i< upgrades.Length; i++) {
			upgrades[i] = 0;
		}

	}

	void SpawnTrucks(float time) {
		for(int i = 0; i < maxNumTrucks; i++) {
			if(currentTrucks[i] == null) {
				currentTrucks[i] = gameObject; // We give a temporary gameobject to the array since the gameobject isnt spawned directly.
				StartCoroutine(SpawnNewTruck(Random.Range (time-0.25f, time+0.25f),i));
			}
		}
	}

	IEnumerator SpawnNewTruck(float time, int index) { //Spawn a truck
		yield return new WaitForSeconds(time);
		currentTrucks[index] = (GameObject) Instantiate (truck_prefab, new Vector3(TruckSpawnPosition.x, TruckSpawnPosition.y - (index*truckPositionYdiff), 0), Quaternion.identity);
		//mark currentTruck by his index
		currentTrucks [index].GetComponent<Truck> ().indexInManager = index;
	}

	IEnumerator DayCountdown() {
		// Reason we simply dont just put a WaitForSecond here is because other object (clock) will refer to currentDayTimeLeft for reference.
		currentDayTimeLeft = dayTime; // Set Timer to a Day Time
		while(currentDayTimeLeft > 0) { //while day is not over, reduce value by time elapsed since last time.
			currentDayTimeLeft -= Time.deltaTime;
			yield return null;
		}
		EndDay ();
	}







}
