using UnityEngine;
using System.Collections;

public class Menu_UI : MonoBehaviour {

	public Texture GestionBackground; // Background of the gestion part of the game.

	private GameManager manager;


	void Awake() {

	}

	void Start () {
		manager = (GameManager) GameObject.FindGameObjectWithTag ("manager").GetComponent<GameManager>();
	}

	void Update () {
	
	}

	void OnGUI() {

		GUI.DrawTexture(new Rect(3*Screen.width/4, 0, Screen.width/4, Screen.height ), GestionBackground);
		//Add GUI STYLE
		GUI.color = Color.black;

		GUI.Label (new Rect (3 * Screen.width / 4, 1 * Screen.height / 8, Screen.width / 6, Screen.height / 12), "Goods");

		if(GUI.Button(new Rect(3*Screen.width/4, 2*Screen.height/12, Screen.width/6, Screen.height/12 ),"TEST")){
			Debug.Log ("Clicked");
		}
		if(GUI.Button(new Rect(3*Screen.width/4, 3*Screen.height/12, Screen.width/6, Screen.height/12 ),"TEST 2")){
			Debug.Log ("Clicked");
		}
		if(GUI.Button(new Rect(3*Screen.width/4, 4*Screen.height/12, Screen.width/6, Screen.height/12 ),"TEST 3")){
			Debug.Log ("Clicked");
		}
		if(GUI.Button(new Rect(3*Screen.width/4, 5*Screen.height/12, Screen.width/6, Screen.height/12 ),"TEST 4")){
			Debug.Log ("Clicked");
		}
	}

}
