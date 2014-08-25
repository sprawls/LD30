using UnityEngine;
using System.Collections;

public class StartDayButton : MonoBehaviour {

	public StartScreen startScreen;

	public Vector2 position;
	public Vector2 scale;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI() {

		if(startScreen.menuShown == true && GUI.Button(new Rect(position.x * Screen.width, position.y * Screen.height, scale.x * Screen.width,  scale.y * Screen.height), "Start")){
			startScreen.StopIntro ();
		}
	}


}
