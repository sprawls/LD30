using UnityEngine;
using System.Collections;

public class OnConveyorBelt : MonoBehaviour {

	public Conveyor conveyorBelt;
	public float speed;
	


	[HideInInspector] public float activationDistance;
	[HideInInspector] public float deactivationDistance;

	private draggableBox dragScript; // Draggable SCript
	private Vector3 lastPosition; //last position Coinveyor belt, usefull for resetting object on conveyor belt if player dont use it on a truck.

	public bool isGrabable = false; //Can the box be grabbed
	public bool isActive = true; //Is the object active on conyeorbelt (false if at the end or being grabbed


	void Awake() {
		dragScript = gameObject.GetComponent<draggableBox> ();
	}

	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if(isActive) {
			transform.Translate(new Vector3(-speed,0,0) * Time.deltaTime);
			lastPosition = transform.position;
			CheckPosition();
		}

	}

	void CheckPosition() { //Checks position to see if state is changing
		if(transform.position.x < deactivationDistance) makeInactive(); 
		else if(isGrabable == false && transform.position.x < activationDistance) makeGrabable();
	}

	void makeGrabable() { // Make Object Grabable
		isGrabable = true;
		if(dragScript != null) dragScript.enabled = true;
	}

	void makeInactive() {
		isGrabable = false;
		isActive = false;
		StartCoroutine (DestroyBox ());

	}

	IEnumerator DestroyBox() { //Destroys object
		yield return new WaitForSeconds(1f);
		Destroy (gameObject);
	}

}
