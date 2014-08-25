using UnityEngine;
using System.Collections;

public class Truck : MonoBehaviour {

	public GameObject SmuggleNotification;
	public int[] currentGoods; //index : 0 = food, 1=smuggle_1,  2=smuggle 2,  3=smuggle 3;
	public int currentAmountGoods = 0; //number of total goods in truck
	public int stallChance = 40; //Chance the truck stall when leaving ( in %)
	public int indexInManager; //index this truck uses in manager.
	public int maxGoods; //max amount of goods possible
	[HideInInspector] public int currentDanger;

	private GameManager manager;
	private GUITexture currentGUIText;
	private float spawnTime = 3f; //Time of the tranlation animation
	private float spawnDistance = 6f; //Distance of the tranlation animation
	private float DeletionDelay = 6f; // times it take for the truck to be deleted once it leaves screen. Also time it takes to show Smuggle Notification.


	//Different States
	public bool isReady = false; // can the truck be loaded ? (as in loading of goods, not loading in computer term !)

	void Awake() {
		gameObject.layer = 9;
	}

	void Start () {
		SetScale ();  // Set scale of the Texture on screen
		manager = (GameManager) GameObject.FindGameObjectWithTag ("manager").GetComponent<GameManager>();
		//Start Translation into Screen
		Spawn ();
	}

	void Update () {
		if(isReady) {

		}
	}

	void OnMouseDown(){ //function called when player clicks on GUI Texture
		if(this.enabled == true && isReady && Time.timeScale != 0) {
			if(currentAmountGoods != 0) LeaveWarehouse ();
		}
	}

	void SetScale() {
		transform.localScale = new Vector3 (2, 2, 0);
	}

	void Spawn() {
		//Set Stats
		maxGoods = 5 + 2 * manager.upgrades [0]; // 3 basic spots + 2 per upgrade.
		stallChance -= 20 * manager.upgrades [2];
		currentGoods = new int[4];
		for(int i = 0; i < currentGoods.Length; i++) {
			currentGoods[i] = 0;
		}
		//Play Animation
		StartCoroutine (SmoothTranslate (new Vector3 (spawnDistance, 0, 0), spawnTime)); //Smoothly translate object in screen.
	}

	public bool AddGood(int type) { //Verify if the truck is full. if not, add good on it. Type is the index of the desired good to add.
		if(isReady == true && currentAmountGoods < maxGoods) {
			currentGoods[type]++; 
			currentAmountGoods++;
			currentDanger = (int)EstimateDanger(); //Update Danger Estimate
			return true;
		} else return false;
	}

	public void LeaveWarehouse() { //function called when truck leaves warehouse.
		isReady = false;
		StartCoroutine (CheckSmugglingSuccess()); //Check if smuggling was successfull or not
		StartCoroutine(SmoothTranslate (new Vector3 (-spawnDistance, 0, 0), spawnTime)); //Smoothly translate object out of screen.
	}

	private int CalculateShipmentWorth(bool smuggleSuccess){ //Calculate shipment's worth and return it
		int worth = 0;
		//Food goods
		manager.currentDailyFoodQuota += currentGoods[0];
		worth += currentGoods[0] * (manager.goods_food_reward + manager.upgrades[5]); //+1 food quota per food (+ 1 more further per upgrade of food)
		//Contraband, only if isnt caught
		if(smuggleSuccess == true) {
			worth += currentGoods[1] * manager.goods_alcohol_reward;
			worth += currentGoods[2] * manager.goods_drug_reward;
			worth += currentGoods[3] * manager.goods_weapon_reward;
			manager.currentDailyWeaponQuota += currentGoods[3];
		}
		return worth;
	}

	public float EstimateDanger() {
		float finalDanger = 0f;
		finalDanger += currentGoods[1] * manager.goods_alcohol_danger;
		finalDanger += currentGoods[2] * manager.goods_drug_danger;
		finalDanger += currentGoods[3] * manager.goods_weapon_danger;
		finalDanger = (finalDanger / (currentGoods[0]+1)) - manager.upgrades[3]*10f;
		if(finalDanger < 0) return(0f);
		else return(finalDanger);
	}

	private bool isShipmentCaught (){ //Verify if shipment is caught and return it
		float finalDanger = 0f;
		finalDanger += currentGoods[1] * manager.goods_alcohol_danger;
		finalDanger += currentGoods[2] * manager.goods_drug_danger;
		finalDanger += currentGoods[3] * manager.goods_weapon_danger;
		finalDanger = (finalDanger / currentGoods[0]+1) - manager.upgrades[3]*10f;
		if(finalDanger < 5) return false;
		else{
			int DangerToBeat = Random.Range(1,100);
			if(finalDanger <= DangerToBeat) return false;
			else return true;
		}
	}

	IEnumerator SmoothTranslate(Vector3 DistanceToMove, float time) { //Smoothly translate object of DistanceToMove distance in time seconds.

		float step = 0f; //raw step
		float rate = 1f/time; //amount to add to raw step
		float smoothStep = 0f; //current smooth step
		float lastStep = 0f; //previous smooth step

		Vector3 startingPosition = transform.position;
		Vector3 endingPosition = startingPosition + DistanceToMove;
		while(step < 1f) { // until we're done
			step += Time.deltaTime * rate; 
			smoothStep = Mathf.SmoothStep(0f, 1f, step); // finding smooth step
			transform.localPosition = new Vector3 (Mathf.Lerp(startingPosition.x, endingPosition.x, (smoothStep)),
			                                       Mathf.Lerp(startingPosition.y, endingPosition.y, (smoothStep)),
			                                       Mathf.Lerp(startingPosition.z, endingPosition.z, (smoothStep))); //lerp position
			lastStep = smoothStep; //get previous last step
			yield return null;
		}
		//complete rotation
		transform.localPosition = endingPosition; // Sometimes, step isnt 1 so distance might not be exactly ending position.
		isReady = true;
	}

	IEnumerator CheckSmugglingSuccess() {
		bool smuggleSuccess = true;
		int moneyReward = 0;

		smuggleSuccess = !isShipmentCaught ();
		moneyReward = CalculateShipmentWorth (smuggleSuccess);

		yield return new WaitForSeconds(DeletionDelay *(1f-0.15f*manager.upgrades[2]));
		Debug.Log ("Shipment Safe = :" + smuggleSuccess + "      Money Made : " + moneyReward);
		manager.money += moneyReward;
		if(smuggleSuccess == false) {
			GameObject notification = (GameObject) Instantiate (SmuggleNotification, transform.position, Quaternion.identity);
			SmuggleNotification notificationScript = notification.GetComponent<SmuggleNotification> ();
			//Report Highest danger item
			if(currentGoods[3] != 0) notificationScript.goodFound = 3;
			else if(currentGoods[2] != 0) notificationScript.goodFound = 2;
			else notificationScript.goodFound = 1;
		}
		manager.currentTrucks [indexInManager] = null;
		Destroy (gameObject);
	}

}
