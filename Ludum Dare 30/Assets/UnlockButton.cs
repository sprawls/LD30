using UnityEngine;
using System.Collections;

public class UnlockButton : MonoBehaviour {

	//Unlocks when conditions are met
	public Sprite unchekedTexture;
	public Sprite checkedTexture;


	public int level; // level of upgrade
	public int index; // which index of the manager is this linked to
	public int requiredDay; //Day required to unlock
	public int cost; //cost of the upgrade

	public bool isActive = false;
	public bool isUnlocked = false;


	private SpriteRenderer sprite;
	private GameManager manager;

	void Start () {
		manager = (GameManager)GameObject.FindGameObjectWithTag ("manager").GetComponent<GameManager> ();
		sprite = (SpriteRenderer) gameObject.GetComponent<SpriteRenderer> ();
		SetState ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown() {
		Debug.Log ("CLICKED " + gameObject.name);
		if(isActive == true && isUnlocked == false) {
			if(manager.money >= cost) {
				Debug.Log ("Bought Updrade : " + gameObject.name);
				manager.money -= cost;
				UnlockUpgrade();
			} else Debug.Log ("Insufficent funds for : " + gameObject.name);
		}
	}

	void UnlockUpgrade() {
		manager.upgrades [index] = level;
		SetAllState ();
	}

	void SetAllState (){ //update the state of ALL buttons
		UnlockButton[] buttons = transform.parent.GetComponentsInChildren<UnlockButton> ();
		for(int i =0; i < buttons.Length; i++) {
			buttons[i].SetState();
		}
	}

	public void SetState (){ //update the state of the current button
		if(requiredDay > manager.currentDay || manager.upgrades[index] + 1 < level) {
			isActive = false;
			isUnlocked = false;
			SetInactiveState();
		} else if(requiredDay <= manager.currentDay && manager.upgrades[index] < level) {
			isActive = true;
			isUnlocked = false;
			SetActiveState();
		} else {
			isActive = false;
			isUnlocked = true;
			SetPurchasedState();
		}
		Debug.Log (isActive + "    unlock: " + isUnlocked);
	}

	void SetInactiveState(){
		sprite.sprite = unchekedTexture;
		sprite.color = new Color (1, 1, 1, 0.5f);
	}
	void SetActiveState(){
		sprite.sprite = unchekedTexture;
		sprite.color = new Color (1, 1, 1, 1f);
	}
	void SetPurchasedState(){
		sprite.sprite = checkedTexture;
		sprite.color = new Color (1, 1, 1, 1f);
	}
}
