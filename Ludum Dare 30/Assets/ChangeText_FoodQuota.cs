﻿using UnityEngine;
using System.Collections;

public class ChangeText_FoodQuota : MonoBehaviour {

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
		text.text = ("Monthly Food Quota : " + manager.dayManager.foodQuota [manager.currentDay]);
	}

}
