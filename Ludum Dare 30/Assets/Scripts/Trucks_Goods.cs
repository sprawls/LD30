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
	void LateUpdate () {
		ChangeString ();
		Reposition ();
	}
	
	void ChangeString() {
		text.text = truck.currentAmountGoods + " / " + truck.maxGoods;
	}

	public void Reposition() {
		//Reposition GUI To fit Trucks
		transform.position = new Vector3 ((truck.transform.position.x + 8f)/16f - 0.02f,
		                                  (truck.transform.position.y + 5f)/10f - 0.02f,
		                                  0);
	}

}
