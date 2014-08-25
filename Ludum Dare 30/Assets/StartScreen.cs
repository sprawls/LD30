using UnityEngine;
using System.Collections;

public class StartScreen : MonoBehaviour {

	public Renderer blackBackground;
	public bool menuShown = false;

	private GameManager manager;
	private GUIText[] texts;



	void Start () {
		manager =(GameManager) GameObject.FindGameObjectWithTag("manager").GetComponent<GameManager>();
		texts = gameObject.GetComponentsInChildren<GUIText> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void StartIntro() {
		menuShown = true;
		StartCoroutine(FadeBackground (0f,0.7f,2f));
		Vector3 distance = new Vector3 (0.8f, 0, 0);
		for(int i = 0; i < texts.Length; i++) {
			StartCoroutine(SmoothTranslate(distance,3f,texts[i].transform,true));
		}
	}

	public void StopIntro() {
		menuShown = false;
		StartCoroutine(FadeBackground (0.7f,0f,2f));
		Vector3 distance = new Vector3 (-0.8f, 0, 0);
		for(int i = 0; i < texts.Length; i++) {
			StartCoroutine(SmoothTranslate(distance,3f,texts[i].transform,true));
		}

		manager.dontStartDay = false;
	}

	IEnumerator FadeBackground(float start, float end, float time) {
		for(float i = 0; i< 1 ; i += Time.deltaTime/time) { // Lerp Alpha of the COLOR
			blackBackground.material.color = new Color(1,1,1, Mathf.Lerp(start,end,i));
			yield return null;
		}
		blackBackground.material.color = new Color(1,1,1,end); // Complete alpha change to be sure we're on "end" value.
	}

	IEnumerator SmoothTranslate(Vector3 DistanceToMove, float time, Transform objectToMove, bool isSmooth) { //Smoothly translate object of DistanceToMove distance in time seconds.
		
		float step = 0f; //raw step
		float rate = 1f/time; //amount to add to raw step
		float smoothStep = 0f; //current smooth step
		float lastStep = 0f; //previous smooth step
		
		Vector3 startingPosition = objectToMove.localPosition;
		Vector3 endingPosition = startingPosition + DistanceToMove;

		while(step < 1f) { // until we're done
			step += Time.deltaTime * rate; 
			if(isSmooth == true) smoothStep = Mathf.SmoothStep(0f, 1f, step); // finding smooth step
			else smoothStep = step;
			objectToMove.localPosition = new Vector3 (Mathf.Lerp(startingPosition.x, endingPosition.x, (smoothStep)),
			                                          Mathf.Lerp(startingPosition.y, endingPosition.y, (smoothStep)),
			                                          Mathf.Lerp(startingPosition.z, endingPosition.z, (smoothStep))); //lerp position
		
			lastStep = smoothStep; //get previous last step
			yield return null;
		}
		//complete translation
		objectToMove.localPosition = endingPosition; // Sometimes, step isnt 1 so distance might not be exactly ending position.
	}
	
}
