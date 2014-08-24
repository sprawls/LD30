using UnityEngine;
using System.Collections;

public class RecapUI : MonoBehaviour {

	private GameManager manager;
	private GUIStyle menuStyle;

	void Awake() {
		menuStyle = new GUIStyle ();
		menuStyle.fontSize = 14;
	}
	void Start () {
		manager = (GameManager)GameObject.FindGameObjectWithTag ("manager").GetComponent<GameManager> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI(){
		GUI.color = Color.gray;
		GUI.Label (new Rect (0.55f * Screen.width, 0.365f * Screen.height, 0.2f * Screen.width, 0.1f * Screen.height), "Funds : " + manager.money,menuStyle + " $");

		GUI.Label (new Rect (0.55f * Screen.width, 0.42f * Screen.height, 0.01f * Screen.width, 0.1f * Screen.height), "Improved Engine",menuStyle);
		GUI.Label (new Rect (0.55f * Screen.width, 0.48f * Screen.height, 0.01f * Screen.width, 0.1f * Screen.height), "Faster Production",menuStyle);
		GUI.Label (new Rect (0.55f * Screen.width, 0.54f * Screen.height, 0.01f * Screen.width, 0.1f * Screen.height), "Craftier Smuggling",menuStyle);
		GUI.Label (new Rect (0.55f * Screen.width, 0.60f * Screen.height, 0.01f * Screen.width, 0.1f * Screen.height), "Bigger Loadout",menuStyle);
		GUI.Label (new Rect (0.55f * Screen.width, 0.66f * Screen.height, 0.01f * Screen.width, 0.1f * Screen.height), "More Vehicules",menuStyle);
		GUI.Label (new Rect (0.55f * Screen.width, 0.72f * Screen.height, 0.01f * Screen.width, 0.1f * Screen.height), "Better Food",menuStyle);

		GUI.Label (new Rect (0.74f * Screen.width, 0.42f * Screen.height, 0.01f * Screen.width, 0.1f * Screen.height), "100",menuStyle);
		GUI.Label (new Rect (0.74f * Screen.width, 0.48f * Screen.height, 0.01f * Screen.width, 0.1f * Screen.height), "100",menuStyle);
		GUI.Label (new Rect (0.74f * Screen.width, 0.54f * Screen.height, 0.01f * Screen.width, 0.1f * Screen.height), "200",menuStyle);
		GUI.Label (new Rect (0.74f * Screen.width, 0.60f * Screen.height, 0.01f * Screen.width, 0.1f * Screen.height), "200",menuStyle);
		GUI.Label (new Rect (0.74f * Screen.width, 0.66f * Screen.height, 0.01f * Screen.width, 0.1f * Screen.height), "500",menuStyle);
		GUI.Label (new Rect (0.74f * Screen.width, 0.72f * Screen.height, 0.01f * Screen.width, 0.1f * Screen.height), "250",menuStyle);

		GUI.Label (new Rect (0.82f * Screen.width, 0.42f * Screen.height, 0.01f * Screen.width, 0.1f * Screen.height), "300",menuStyle);
		GUI.Label (new Rect (0.82f * Screen.width, 0.48f * Screen.height, 0.01f * Screen.width, 0.1f * Screen.height), "300",menuStyle);
		GUI.Label (new Rect (0.82f * Screen.width, 0.54f * Screen.height, 0.01f * Screen.width, 0.1f * Screen.height), "400",menuStyle);
		GUI.Label (new Rect (0.82f * Screen.width, 0.60f * Screen.height, 0.01f * Screen.width, 0.1f * Screen.height), "400",menuStyle);
		GUI.Label (new Rect (0.82f * Screen.width, 0.66f * Screen.height, 0.01f * Screen.width, 0.1f * Screen.height), "600",menuStyle);
		GUI.Label (new Rect (0.82f * Screen.width, 0.72f * Screen.height, 0.01f * Screen.width, 0.1f * Screen.height), "400",menuStyle);

		GUI.Label (new Rect (0.90f * Screen.width, 0.42f * Screen.height, 0.01f * Screen.width, 0.1f * Screen.height), "450",menuStyle);
		GUI.Label (new Rect (0.90f * Screen.width, 0.48f * Screen.height, 0.01f * Screen.width, 0.1f * Screen.height), "450",menuStyle);
		GUI.Label (new Rect (0.90f * Screen.width, 0.54f * Screen.height, 0.01f * Screen.width, 0.1f * Screen.height), "600",menuStyle);
		GUI.Label (new Rect (0.90f * Screen.width, 0.60f * Screen.height, 0.01f * Screen.width, 0.1f * Screen.height), "600",menuStyle);

		GUI.Label (new Rect (0.55f * Screen.width, 0.82f * Screen.height, 0.01f * Screen.width, 0.1f * Screen.height), "As usual, Money will be collected at the end of the month.",menuStyle);
		GUI.Label (new Rect (0.55f * Screen.width, 0.85f * Screen.height, 0.01f * Screen.width, 0.1f * Screen.height), "Be sure to Spend what you need.",menuStyle);
		GUI.Label (new Rect (0.55f * Screen.width, 0.88f * Screen.height, 0.01f * Screen.width, 0.1f * Screen.height), "We Thank you for your services. ",menuStyle);
	
		GUI.color = Color.white;
		if(GUI.Button(new Rect (0.80f * Screen.width, 0.86f * Screen.height, 0.1f * Screen.width, 0.05f * Screen.height), "Next Month")){
			manager.LoadNextLevel();
		}
	}
}
