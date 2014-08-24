using UnityEngine;
using System.Collections;

public class UnlockButton : MonoBehaviour {

	//Unlocks when conditions are met

	public int level; // level of upgrade
	public int index; // which index of the manager is this linked to
	public int requiredDay; //Day required to unlock
	public int cost; //cost of the upgrade

	public bool isActive = false;
	public bool isUnlocked = false;

	private GameManager manager;

	void Start () {
		manager = (GameManager)GameObject.FindGameObjectWithTag ("manager").GetComponent<GameManager> ();
		SetState ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown() {
		if(isActive == true && isUnlocked == false) {
			if(manager.money >= cost) {
				manager.money -= cost;
				UnlockUpgrade();
			}
		}
	}

	void UnlockUpgrade() {
		manager.upgrades [index] = level;
	}

	void SetState (){
		if(requiredDay > manager.currentDay) {
			isActive = false;
			isUnlocked = false;
		} else if(requiredDay <= manager.currentDay && manager.upgrades[index] < level) {
			isActive = true;
			isUnlocked = false;
		} else {
			isActive = false;
			isUnlocked = true;
		}
	}
}
