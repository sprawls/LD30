using UnityEngine;
using System.Collections;

public class ChooseSong : MonoBehaviour {

	public AudioClip song1;
	public AudioClip song2; 


	private AudioSource audioSource;

	// Use this for initialization
	void Start () {
		audioSource = (AudioSource)gameObject.GetComponent<AudioSource> ();
		if(ChooseSongToPlay () == true) {
			audioSource.PlayOneShot(song1);
		} else {
			audioSource.PlayOneShot(song2);
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private bool ChooseSongToPlay() {
		int random = Random.Range (0,100);
		if(random > 30) return true;
		else return false;
	}

}
