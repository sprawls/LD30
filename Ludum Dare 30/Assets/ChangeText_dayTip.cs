using UnityEngine;
using System.Collections;

public class ChangeText_dayTip : MonoBehaviour {
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
		string month;
		int index = manager.currentDay;

		
		if(index == 0) month = "\"So you were chosen to provide food for our troops in South Linborough. \n Dont worry, just make sure to fill out their request and everything should be fine.\"\n\n Tip : Load the crates in the truck, then click on the truck to ship the goods. ";
		else if(index == 1) month = "\"Looks like they banned Alcohol down there. \n If you're looking for a profit, you could take advantage of the situation you're in and\n ship some alcohol down there. Just don't get caught.\"\n\n Tip : The % on the trucks indicates the change of the illegal goods being spotted. \n          Confiscated goods do not generate money.";
		else if(index == 2) month = "\"The more food you have in a truck, the less likely is it to get caught. \n   If you do get caught, just frame one of your employee. Easy !\"\n\n Tip : The more money you do, the more upgrades you can afford at the end of the day.";
		else if(index == 3) month = "\"With the biggest actor of the drug dealing scene gone, there a great opportunity \n  for someone to sweep in. I mean, if you have the guts to.\"\n\n Tip : Drugs are a high risk, high reward type of goods.";
		else if(index == 4) month = "\"They really do keep asking for more. \n  Don't forget to meet their needs, I dont want to be punished.\"\n\n Tip : Drugs are a high risk, high reward type of goods.";
		else if(index == 5) month = "\"It became ugly in the South. They're not even armed... \n  There's not much we can do, can we ?\"\n\n Tip : You can now help the South rebellion by providing weapons. \n          Meet The Weapon Quota to help them, but don't forget Food Quota.";
		else if(index == 6) month = "\"Are you sure you want to helping them ?\n  If you get caught, we're all going down with you.\"\n\n Tip : Weapons don't make a good profit, and they're really hard to hide.";
		else month = "\"Well, whatever happens, dont forget the food Quota.\n  We don't want anyone inspecting us.\"\n\n Tip : Good Luck.";
		
		
		text.text = month;
		text.fontSize = 16;
	}

}
