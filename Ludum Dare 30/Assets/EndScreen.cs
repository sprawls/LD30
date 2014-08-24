using UnityEngine;
using System.Collections;

public class EndScreen : MonoBehaviour {


	public GUITexture blackBackground;
	public Transform SuccessTexture;

	public Transform PrisonCell;
	public GameObject GameOverObject;

	public Transform RebelsLost;
	public Transform RebelsLost2;

	void Start () {
		ShowRebelLostScreen ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ShowVictoryScreen() {
		StartCoroutine (ShowSuccess ());
	}
	public void ShowFailScreen() {
		StartCoroutine (ShowFailure ());
	}
	public void ShowRebelLostScreen() {
		StartCoroutine (ShowRebels ());
	}

	IEnumerator StartFadingInBackground (float time) {
		for(float i = 0; i < 1; i += Time.deltaTime/time) {
			blackBackground.color = new Color(1,1,1,((i/2)));
			yield return null;
		}
	}
	IEnumerator ShowSuccess(){
		StartCoroutine(StartFadingInBackground (10f));
		StartCoroutine (SmoothTranslate (new Vector3 (0, -2, 0), 3f, SuccessTexture.transform, true));
		yield return null;
	}

	IEnumerator ShowFailure() {
		Debug.Log ("showing Fail Screen");
		StartCoroutine(SmoothTranslate (new Vector3 (0, -12, 0), 2f, PrisonCell,true));
		yield return new WaitForSeconds (3.00f);
		StartCoroutine (SmoothTranslate (new Vector3 (0, -8, 0), 4f, GameOverObject.transform, true));
	}

	
	IEnumerator ShowRebels() {
		StartCoroutine (SmoothTranslate (new Vector3 (0, -12, 0), 5f, RebelsLost, true));
		yield return new WaitForSeconds (6.00f);
		StartCoroutine (SmoothTranslate (new Vector3 (0, -8, 0), 4f, RebelsLost2, true));
	}



	IEnumerator SmoothTranslate(Vector3 DistanceToMove, float time, Transform objectToMove, bool isSmooth) { //Smoothly translate object of DistanceToMove distance in time seconds.
		
		float step = 0f; //raw step
		float rate = 1f/time; //amount to add to raw step
		float smoothStep = 0f; //current smooth step
		float lastStep = 0f; //previous smooth step
		
		Vector3 startingPosition = objectToMove.localPosition;
		Vector3 endingPosition = startingPosition + DistanceToMove;
		Debug.Log ("startingPosition : " + startingPosition + "    endingPosition : " + endingPosition); 
		while(step < 1f) { // until we're done
			step += Time.deltaTime * rate; 
			if(isSmooth == true) smoothStep = Mathf.SmoothStep(0f, 1f, step); // finding smooth step
			else smoothStep = step;
			objectToMove.localPosition = new Vector3 (Mathf.Lerp(startingPosition.x, endingPosition.x, (smoothStep)),
			                                       Mathf.Lerp(startingPosition.y, endingPosition.y, (smoothStep)),
			                                       Mathf.Lerp(startingPosition.z, endingPosition.z, (smoothStep))); //lerp position
			Debug.Log (smoothStep);
			lastStep = smoothStep; //get previous last step
			yield return null;
		}
		//complete translation
		objectToMove.localPosition = endingPosition; // Sometimes, step isnt 1 so distance might not be exactly ending position.
	}



}
