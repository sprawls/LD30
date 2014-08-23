using UnityEngine;
using System.Collections;

public class notification_goodsUI : MonoBehaviour {

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
		if(notification.goodFound == 1) {
			text.text = "Goods Caught : Smuggle 1";
		}
		if(notification.goodFound == 2) {
			text.text = "Goods Caught : Smuggle 2";
		}
		if(notification.goodFound == 3) {
			text.text = "Goods Caught : Smuggle 3";
		}
	}

}
