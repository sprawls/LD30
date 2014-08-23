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
		if(notification.punishement == 0) {
			text.text = "Employee Caught Arrested";
		} else {
			text.text = "Goods Caught : " + notification.punishement + "$ fine.";
		}
	}

}
