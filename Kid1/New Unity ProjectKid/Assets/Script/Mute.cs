using UnityEngine;
using System.Collections;

public class Mute : MonoBehaviour {
	public AudioListener audioListener;
	// Use this for initialization

	
	// Update is called once per frame
	public void mute () {
		/*if (audioListener.volume==0.0f) {
			audioListener.volume=.1f;
				}
		else if(audioListener.volume==0.1f){
			audioListener.volume=0.0f;}*/
		
		audioListener.enabled = !audioListener.enabled;
	}
}
