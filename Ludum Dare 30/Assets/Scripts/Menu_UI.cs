using UnityEngine;
using System.Collections;

public class Menu_UI : MonoBehaviour {

	public Texture GestionBackground; // Background of the gestion part of the game.
	public Texture[] OrderListBackground; // Background of dots for the order List
	[HideInInspector] public float loadingBarProgress;

	private GameManager manager;
	private Conveyor conveyor;
	private GUIStyle orderListButtonsStyle;

	void Awake() {
		if(OrderListBackground == null) Debug.Log ("OrderListBackground is null in " + gameObject.name + ". Configure its values in Inspector.");
	}

	void Start () {
		manager = (GameManager) GameObject.FindGameObjectWithTag ("manager").GetComponent<GameManager>();
		conveyor = (Conveyor)GameObject.FindGameObjectWithTag ("conveyor").GetComponent<Conveyor> ();
		CreateStyle_orderList();
	}

	void Update () {
	
	}

	void OnGUI() {

		GUI.DrawTexture(new Rect(3*Screen.width/4, 0, Screen.width/4, Screen.height ), GestionBackground);
		//Add GUI STYLE
		GUI.color = Color.black;
		//Stats
		GUI.Label (new Rect (3.1f * Screen.width / 4, 1 * Screen.height / 8, Screen.width / 6, Screen.height / 12), "Money : " + manager.money + " $.");
		if(manager.dailyFoodQuota > 0) GUI.Label (new Rect (3.1f * Screen.width / 4, 1.3f * Screen.height / 8, Screen.width / 5, Screen.height / 12), "Food Quota : " + manager.dailyFoodQuota + "       Current : " + manager.currentDailyFoodQuota);
		if(manager.dailyWeaponQuota > 0)GUI.Label (new Rect (3.1f * Screen.width / 4, 1.6f * Screen.height / 8, Screen.width / 5, Screen.height / 12), "Weapon Quota : " + manager.dailyWeaponQuota + "       Current : " + manager.currentDailyWeaponQuota);

		//Produce
		GUI.Label (new Rect (3.1f * Screen.width / 4, 1.9f * Screen.height / 8, Screen.width / 6, Screen.height / 12), "Production :");
		if(GUI.Button(new Rect(16*Screen.width/20, 3.5f*Screen.height/12, Screen.width/6, Screen.height/12 ),"Produce Food")){
			if(conveyor.orders.Count < 12) conveyor.orders.Add (0);
			Debug.Log ("Producing Food");
		}
		if(GUI.Button(new Rect(16*Screen.width/20, 4.5f*Screen.height/12, Screen.width/6, Screen.height/12 ),"Produce Alcohol")){
			if(conveyor.orders.Count < 12) conveyor.orders.Add (1);
			Debug.Log ("Producing Alcohol");
		}
		if(GUI.Button(new Rect(16*Screen.width/20, 5.5f*Screen.height/12, Screen.width/6, Screen.height/12 ),"Produce Drugs")){
			if(conveyor.orders.Count < 12) conveyor.orders.Add (2);
			Debug.Log ("Producing Drugs");
		}
		if(GUI.Button(new Rect(16*Screen.width/20, 6.5f*Screen.height/12, Screen.width/6, Screen.height/12 ),"Produce Weapons")){
			if(conveyor.orders.Count < 12) conveyor.orders.Add (3);
			Debug.Log ("Producing Weapons");
		}

		//OrderList
		GUI.Label (new Rect (3.1f * Screen.width / 4, 8.2f * Screen.height / 12, Screen.width / 6, Screen.height / 12), "Order List : ");
		GUI.color = Color.white;
		for(int i = 0; i< 4; i++) {
			if(GUI.Button(new Rect((15.65f+(i*1))*Screen.width/20, 10f*Screen.height/12, Screen.width/48, Screen.height/24 ),FindOrderTexture(i),orderListButtonsStyle)){
				conveyor.RemoveOrder(i);
			}
		}
		for(int i = 0; i< 4; i++) {
			if(GUI.Button(new Rect((18.65f-(i*1))*Screen.width/20, 9.5f*Screen.height/12, Screen.width/48, Screen.height/24 ),FindOrderTexture(i+4),orderListButtonsStyle)){
				conveyor.RemoveOrder(i+4);
			}
		}
		for(int i = 0; i< 4; i++) {
			if(GUI.Button(new Rect((15.65f+(i*1))*Screen.width/20, 9f*Screen.height/12, Screen.width/48, Screen.height/24 ),FindOrderTexture(i+8),orderListButtonsStyle)){
				conveyor.RemoveOrder(i+8);
			}
		}
		GUI.DrawTexture(new Rect(0.8f*Screen.width, 0.9f*Screen.height, 0.15f*Screen.width, 0.025f*Screen.height), OrderListBackground[4]);
		GUI.DrawTexture(new Rect(0.8f*Screen.width, 0.9f*Screen.height, 0.15f*Screen.width * loadingBarProgress, 0.025f*Screen.height), OrderListBackground[3]);




	}

	Texture FindOrderTexture(int index) { //returns the texture to use for the order queue. Needs index.
		if(index >= conveyor.orders.Count) return(OrderListBackground[4]);
		return (OrderListBackground[conveyor.orders[index]]);

	}

	void CreateStyle_orderList(){
		orderListButtonsStyle = new GUIStyle();
	}

}
