using UnityEngine;
using System.Collections;

public class notification_punishment : MonoBehaviour {

	private SmuggleNotification notification;
	private GUIText text;
	private GameManager manager;
	
	void Start () {
		notification = transform.parent.GetComponent<SmuggleNotification> ();
		manager = (GameManager) GameObject.FindGameObjectWithTag ("manager").GetComponent<GameManager>();
		text = gameObject.GetComponent<GUIText> ();
		ChangeString ();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void ChangeString() {
		if(notification.punishement == -1) {
			text.text = "Employee Caught Arrested";
		} else {
			int randomNumber = Random.Range(0,11);
			switch(randomNumber){
				case 0 : 
					text.text = "Truck criver in custody";
					break;
				case 1 : 
					text.text = "Shipment lost in transition";
					break;
				case 2 : 
					text.text = "Shipment confiscated";
					break;
				case 3 : 
					text.text = "Illegal goods confiscated";
					break;
				case 4 : 
					text.text = "Illegal merchandise kept at border";
					break;
				case 5 : 
					text.text = "Employee Arrested";
					break;
				case 6 : 
					text.text = "Employee suspected, keep him in check";
					break;
				case 7 : 
					text.text = "Driver deported to South Linborough";
					break;
				case 8 : 
					text.text = "Unregistered goods confiscated";
					break;
				case 9 : 
					text.text = "Goods have been taken by the government";
					break;
				case 10 : 
					text.text = "Goods lost...";
					break;
				case 11 : 
					text.text = "Goods lost.";
					break;
			}
		}
	}

}
