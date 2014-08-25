using UnityEngine;
using System.Collections;

public class ChangeText_Month : MonoBehaviour {

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
		string month;
		int index = manager.currentDay;
		
		if(index == 0) month = "August 1967";
		else if(index == 1) month = "September 1967";
		else if(index == 2) month = "October 1967";
		else if(index == 3) month = "November 1967";
		else if(index == 4) month = "December 1967";
		else if(index == 5) month = "January 1968";
		else if(index == 6) month = "February 1968";
		else month = "March 1968";
		
		
		text.text = month;
	}
}
