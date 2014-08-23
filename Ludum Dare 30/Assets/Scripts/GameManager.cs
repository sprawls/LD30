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
	public int money = 0; //Current Money of the player
	public int maxNumTrucks = 2; //Maximum number of trucks currenty possible
	public float currentBoxSpawnTime = 2f; //Time it takes for a box to spawn on Conveyor
	public float spawnTruckTime = 2f; //Time it takes for trucks to come back
	public float currentDayTimeLeft;
	public bool DayIsStarted = false; // Is the day started ?

	public GameObject[] currentTrucks;
	public int[] upgrades; //Tablec of the upgrades the player has (detailed below(OR MAYBE NOT YET!))

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
		 *  0 : truck_box Quantity (up to 2)
		 *  1 : Faster Production
		 *  2 : Better Truck (Stall less Often) (up to 2)
		 */ 
		// Create  Upgrade list
		upgrades = new int[3];
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
