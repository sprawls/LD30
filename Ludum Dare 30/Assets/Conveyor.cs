using UnityEngine;
using System.Collections;

public class Conveyor : MonoBehaviour {

	public Transform startObject;
	public Transform endObject;
	public GameObject box_type0; //Food Box Prefab
	public GameObject box_type1; //Contraband Box Prefab

	public float boxesSpeed = 1f;
	private GameManager manager;

	// Use this for initialization
	void Start () {
		manager = (GameManager) GameObject.FindGameObjectWithTag ("manager").GetComponent<GameManager>();
		StartCoroutine (BoxSpawner ());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void CreateBox(int type){
		GameObject newBox;
		if(type == 1) {
			newBox = (GameObject) GameObject.Instantiate(box_type1,transform.position + new Vector3(0,0,-3), Quaternion.identity);
		} else {
			newBox = (GameObject) GameObject.Instantiate(box_type0,transform.position + new Vector3(0,0,-3), Quaternion.identity);
		}

		OnConveyorBelt boxScript = newBox.GetComponent<OnConveyorBelt> ();
		boxScript.conveyorBelt = this;
		boxScript.speed = boxesSpeed;
		boxScript.activationDistance = startObject.position.x;
		boxScript.deactivationDistance = endObject.position.x;
	}

	IEnumerator BoxSpawner() {
		while(true){ //Repeats forever
			yield return new WaitForSeconds(manager.currentBoxSpawnTime);
			CreateBox(0);
		}
	}

}
