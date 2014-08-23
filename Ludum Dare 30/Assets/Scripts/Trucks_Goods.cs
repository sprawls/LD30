using UnityEngine;
using System.Collections;

public class Trucks_Goods : MonoBehaviour {

	private Truck truck;
	private GUIText text;
	
	
	void Start () {
		truck = transform.parent.GetComponent<Truck> ();
		text = gameObject.GetComponent<GUIText> ();
		
	}
	
	// Update is called once per frame
	void Update () {
		ChangeString ();
	}
	
	void ChangeString() {
		text.text = truck.currentAmountGoods + " / " + truck.maxGoods;
	}

}
