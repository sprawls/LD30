using UnityEngine;
using System.Collections;

public class SmuggleNotification : MonoBehaviour {
	

	
	public int goodFound = 1;
	public int punishement = 100;
	
	
	
	// Use this for initialization
	void Start () {

		
		CreateNotification ();
		StartCoroutine (AnimateNotification ());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void CreateNotification() {
		//TODO: CREATE THIS
		transform.position = new Vector3 ( 0.5f, 1.1f, 1);
	}
	
	IEnumerator AnimateNotification() {
		StartCoroutine (TranslateNotification (new Vector3(0,-0.20f,0),2f));
		yield return new WaitForSeconds (5f);
		StartCoroutine (TranslateNotification (new Vector3(0,0.20f,0),2f));
		yield return new WaitForSeconds (5f);
		Destroy (gameObject);
		
	}
	
	IEnumerator TranslateNotification(Vector3 DistanceToMove, float time) {
		float step = 0f; //raw step
		float rate = 1f/time; //amount to add to raw step
		float smoothStep = 0f; //current smooth step
		float lastStep = 0f; //previous smooth step
		
		Vector3 startingPosition = transform.position;
		Vector3 endingPosition = startingPosition + DistanceToMove;
		while(step < 1f) { // until we're done
			step += Time.deltaTime * rate; 
			smoothStep = Mathf.SmoothStep(0f, 1f, step); // finding smooth step
			transform.localPosition = new Vector3 (Mathf.Lerp(startingPosition.x, endingPosition.x, (smoothStep)),
			                                       Mathf.Lerp(startingPosition.y, endingPosition.y, (smoothStep)),
			                                       Mathf.Lerp(startingPosition.z, endingPosition.z, (smoothStep))); //lerp position
			lastStep = smoothStep; //get previous last step
			yield return null;
		}
		//complete rotation
		transform.localPosition = endingPosition; // Sometimes, step isnt 1 so distance might not be exactly ending position.
	}
	
	
}
