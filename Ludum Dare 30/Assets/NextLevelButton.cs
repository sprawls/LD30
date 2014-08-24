using UnityEngine;
using System.Collections;

public class NextLevelButton : MonoBehaviour {

	public Vector2 position;
	public Vector2 lenght; 
	public string message;

	public bool goesToNextLevel = true;
	public int targetLevel = 0;

	public bool createAButton = true; //if we dont create a button, otherwise use this object collider as button

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown() {
		if(createAButton == false) {
			ButtonActivated ();
		}
	}

	void OnGUI() {
		if(createAButton == true) { //if we create a button, do it, otherwise use this object collider as button
			if (GUI.Button (new Rect (position.x * Screen.width, position.y * Screen.height, lenght.x * Screen.width, lenght.y * Screen.height), message)){
				ButtonActivated ();
			}
		}
						
	}

	void ButtonActivated(){
		if(goesToNextLevel == true) Application.LoadLevel(Application.loadedLevel + 1);
		else Application.LoadLevel(targetLevel);
	}
		 
}
