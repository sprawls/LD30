using UnityEngine;
using System.Collections;

public class ChangeText_Money : MonoBehaviour {

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
		text.text = ("Starting Funds : " + manager.dayManager.startingMoney [manager.currentDay]);
	}


}
