using UnityEngine;
using System.Collections;

public class draggableBox : MonoBehaviour {
	
	public bool isGrabbed = false;

	private Vector3 originalPosition;
	private Camera mainCamera;
	private OnConveyorBelt conveyorBelt;
	private int dropLayermask =  (1 << 9); //Only check "Truck" layer

	void Awake() {
		gameObject.layer = 8;
		mainCamera = Camera.main;
		conveyorBelt = gameObject.GetComponent<OnConveyorBelt> ();
	}
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if(Time.timeScale != 0 && isGrabbed == true) {
			transform.position = mainCamera.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0,0,5);
		
		}
	}

	void OnMouseDown() { //function called when player clicks on sprite
		if(Time.timeScale != 0 && isGrabbed == false) {
			StartDrag ();
		} else if(Time.timeScale != 0 && isGrabbed == true) {
			StopDrag ();
		}
	}

	void StartDrag(){
		isGrabbed = true;
		//Change Position and scale for feedback
		originalPosition = transform.position;
		transform.localScale *= 1.25f;
		//If object is OnConveyorbelt
		if(conveyorBelt != null) {
			conveyorBelt.isActive = false;
		}
	}
	
	void StopDrag(){
		if(LoadInTruck () == true) return; //If drag work, box is deleted
		// else If drag failed
		isGrabbed = false;
		transform.position = originalPosition;
		transform.localScale *= 1/1.25f;
		//If object is OnConveyorbelt
		if(conveyorBelt != null) {
			conveyorBelt.isActive = true;
		}
	}

	bool LoadInTruck() {
		RaycastHit hit;
		if(Physics.Raycast(transform.position,Camera.main.transform.forward,out hit,100f, dropLayermask)){
			Debug.Log ("HIT !");
			Truck truckScript = hit.transform.gameObject.GetComponent<Truck>();
			if(truckScript.AddGood(0) == true){
				Destroy (gameObject);
				return true;
			}
		}
		return false;

	}


}
