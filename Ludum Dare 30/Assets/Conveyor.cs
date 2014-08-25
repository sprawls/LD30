using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Conveyor : MonoBehaviour {

	public Transform startObject;
	public Transform endObject;
	public GameObject box_type0; //Food Box Prefab
	public GameObject box_type1; //Alcohol Box Prefab
	public GameObject box_type2; //Drugs Box Prefab
	public GameObject box_type3; //Weapon Box Prefab
	public List<int> orders; //List of orders that are used to generate the crates
	public GameObject redPopup;


	public float boxesSpeed = 1f;
	private GameManager manager;
	private Menu_UI menuUI;
	private bool isOn = false;
	private Vector3 popupPosition;


	// Use this for initialization
	void Start () {
		manager = (GameManager) GameObject.FindGameObjectWithTag ("manager").GetComponent<GameManager>();
		menuUI = (Menu_UI)GameObject.FindGameObjectWithTag ("UI").GetComponent<Menu_UI> ();
		orders = new List<int> ();
		popupPosition = new Vector3(0.72f,0.19f,0);

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(manager.DayIsStarted == false && isOn == true) {
			isOn = false;
			StopAllCoroutines(); //Stopping the coroutines stops the spawning of crates.
		} else if(manager.DayIsStarted == true && isOn == false) {
			isOn = true;
			StartCoroutine ("BoxSpawner");
		}
	}

	void OnGUI() {

	}

	public void RemoveOrder(int index) {
		if(index == 0) { //If we cancel the index we're currently working on, have to reset all coroutines. Otherwise just remove it from list
			StopAllCoroutines(); //Reset Coroutines
			menuUI.loadingBarProgress = 0f; //Reset Progress bar
			orders.RemoveAt (index);
			StartCoroutine("BoxSpawner");
		} else orders.RemoveAt (index);
	}

	public void CreateBox(int type){
		GameObject newBox = null;
		if(type == 1) {
			if(manager.money >= manager.goods_alcohol_cost) {
				newBox = (GameObject) GameObject.Instantiate(box_type1,transform.position + new Vector3(0,0,-3), Quaternion.identity);
				StartCoroutine(SpawnPopop(manager.goods_alcohol_cost, false));
				manager.money -=  manager.goods_alcohol_cost;
			} else {
				StartCoroutine(SpawnPopop(0,true));
			}
		} else if(type == 2) {
			if(manager.money >= manager.goods_drug_cost) {
				newBox = (GameObject) GameObject.Instantiate(box_type2,transform.position + new Vector3(0,0,-3), Quaternion.identity);
				StartCoroutine(SpawnPopop(manager.goods_drug_cost, false));
				manager.money -= manager.goods_drug_cost;
			} else {
				StartCoroutine(SpawnPopop(0,true));
			} 
		} else if(type == 3) {
			if(manager.money >= manager.goods_weapon_cost) {
				newBox = (GameObject) GameObject.Instantiate(box_type3,transform.position + new Vector3(0,0,-3), Quaternion.identity);
				StartCoroutine(SpawnPopop(manager.goods_weapon_cost, false));
				manager.money -= manager.goods_weapon_cost;
			} else {
				StartCoroutine(SpawnPopop(0,true));
			} 
		} else {
			if(manager.money >= manager.goods_food_cost) {
				newBox = (GameObject) GameObject.Instantiate(box_type0,transform.position + new Vector3(0,0,-3), Quaternion.identity);
				StartCoroutine(SpawnPopop(manager.goods_food_cost, false));
				manager.money -= manager.goods_food_cost;
			} else {
				StartCoroutine(SpawnPopop(0,true));
			} 
		}

		if(newBox != null) {
			OnConveyorBelt boxScript = newBox.GetComponent<OnConveyorBelt> ();
			boxScript.conveyorBelt = this;
			boxScript.speed = boxesSpeed;
			boxScript.activationDistance = startObject.position.x;
			boxScript.deactivationDistance = endObject.position.x;
		}
	}

	IEnumerator BoxSpawner() {
		while(true){ //Repeats forever
			if(orders.Count != 0) {
				if(orders[0] == 1) {
					StartCoroutine (DrawLoadingBar (manager.goods_alcohol_time * (1-(0.25f*manager.upgrades[1]))));
					yield return new WaitForSeconds(manager.goods_alcohol_time * (1-(0.25f*manager.upgrades[1])));
				} else if (orders[0] == 2) {
					StartCoroutine (DrawLoadingBar (manager.goods_drug_time * (1-(0.25f*manager.upgrades[1]))));
					yield return new WaitForSeconds(manager.goods_drug_time * (1-(0.25f*manager.upgrades[1])));
				} else if (orders[0] == 3) {
					StartCoroutine (DrawLoadingBar (manager.goods_weapon_time * (1-(0.25f*manager.upgrades[1]))));
					yield return new WaitForSeconds(manager.goods_weapon_time * (1-(0.25f*manager.upgrades[1])));
				} else {
					StartCoroutine (DrawLoadingBar (manager.goods_food_time * (1-(0.25f*manager.upgrades[1]))));
					yield return new WaitForSeconds(manager.goods_food_time * (1-(0.25f*manager.upgrades[1])));
				}
				CreateBox(orders[0]);
				orders.RemoveAt(0);
			}
			yield return null;
		}
	}

	IEnumerator DrawLoadingBar(float loadTime) {
		for( float i = 0; i < 1; i += Time.deltaTime/loadTime) {
			menuUI.loadingBarProgress = i;
			yield return null;
		}
		menuUI.loadingBarProgress = 0f;
	}

	IEnumerator SpawnPopop(int amount, bool errorMessage) {
			if(errorMessage == false) yield return new WaitForSeconds (0.8f * (1f-(0.25f*manager.upgrades[1])));
			GameObject popup = (GameObject) GameObject.Instantiate(redPopup, popupPosition, Quaternion.identity);
			moneyPopup popupScript = popup.GetComponent<moneyPopup>();
			popupScript.SetMoney(-amount,new Vector2(-0.02f,0.1f),errorMessage);
	}

}
