using UnityEngine;
using System.Collections;

public class notification_punishment : MonoBehaviour {

	private SmuggleNotification notification;
	private GUIText text;
	
	
	void Start () {
		notification = transform.parent.GetComponent<SmuggleNotification> ();
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
