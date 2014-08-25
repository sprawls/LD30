using UnityEngine;
using System.Collections;

public class moneyPopup : MonoBehaviour {

	private Vector2 popupMouvement;

	void Start () {
		StartCoroutine (DisplayPopup ());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SetMoney(int amount, Vector2 mouvement) {
		guiText.text = amount + "$";
		popupMouvement = mouvement;
	}

	IEnumerator DisplayPopup() {
		Vector3 StartMouvement = transform.position;
		Vector3 endMouvement = StartMouvement + new Vector3(popupMouvement.x,popupMouvement.y,0);
		for(float i = 0; i < 1; i += Time.deltaTime/2f) {
			transform.position = Vector3.Lerp(StartMouvement,endMouvement,i);
			yield return null;
		}
		Destroy (gameObject);
	}
}
