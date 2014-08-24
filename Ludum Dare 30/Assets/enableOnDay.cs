using UnityEngine;
using System.Collections;

public class enableOnDay : MonoBehaviour {
	
	public int dayToEnable = 0;

	private GameManager manager;
	private SpriteRenderer sprite;


	void Awake() {
		manager = (GameManager)GameObject.FindGameObjectWithTag ("manager").GetComponent<GameManager> ();
		sprite = gameObject.GetComponent<SpriteRenderer> ();
	}

	void Start () {
		sprite.enabled = false;
		if(manager.currentDay == dayToEnable)	sprite.enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
	}
}
