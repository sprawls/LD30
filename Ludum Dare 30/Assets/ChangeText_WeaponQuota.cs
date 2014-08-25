using UnityEngine;
using System.Collections;

public class ChangeText_WeaponQuota : MonoBehaviour {

	private GUIText text;
	private GameManager manager;
	
	void Start () {
		manager =(GameManager) GameObject.FindGameObjectWithTag("manager").GetComponent<GameManager>();
		text = (GUIText) gameObject.GetComponent<GUIText> ();
		SetText ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void SetText() {
		if(manager.dayManager.weaponQuota [manager.currentDay] > 0) {
			text.text = ("Monthly Weapon Quota : " + manager.dayManager.weaponQuota [manager.currentDay]);
		} else {
			text.text = "";
		}

	}
}
