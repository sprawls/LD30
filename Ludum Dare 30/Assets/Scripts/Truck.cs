using UnityEngine;
using System.Collections;

public class Truck : MonoBehaviour {

	public GameObject SmuggleNotification;
	public int[] currentGoods; //index : 0 = food, 1=smuggle_1,  2=smuggle 2,  3=smuggle 3;
	public int currentAmountGoods = 0; //number of total goods in truck
	public int stallChance = 40; //Chance the truck stall when leaving ( in %)
	public int indexInManager; //index this truck uses in manager.
	public int maxGoods; //max amount of goods possible

	private GameManager manager;
	private GUITexture currentGUIText;
	private float spawnTime = 3f; //Time of the tranlation animation
	private float spawnDistance = 4f; //Distance of the tranlation animation
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
		if(isReady && Time.timeScale != 0) {
			if(currentAmountGoods != 1) LeaveWarehouse ();
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
			return true;
		} else return false;
	}

	public void LeaveWarehouse() { //function called when truck leaves warehouse.
		isReady = false;
		StartCoroutine (CheckSmugglingSuccess()); //Check if smuggling was successfull or not
		StartCoroutine(SmoothTranslate (new Vector3 (-spawnDistance, 0, 0), spawnTime)); //Smoothly translate object out of screen.
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
		//TODO : ADD smuggle values to GAME MANAGER
		bool smuggleSuccess = true;
		int smuggleIndex = 0;

		yield return new WaitForSeconds(DeletionDelay);
		if(smuggleSuccess == false) {
			GameObject notification = (GameObject) Instantiate (SmuggleNotification, transform.position, Quaternion.identity);
			SmuggleNotification notificationScript = notification.GetComponent<SmuggleNotification> ();
			notificationScript.goodFound = smuggleIndex;
		}
		manager.currentTrucks [indexInManager] = null;
		Destroy (gameObject);
	}

}
