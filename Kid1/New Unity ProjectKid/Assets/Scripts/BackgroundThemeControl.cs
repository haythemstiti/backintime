using UnityEngine;
using System.Collections;

public class BackgroundThemeControl : MonoBehaviour {

    public static bool isPlaying = true;
    private AudioSource itemSource;
	// Use this for initialization
	void Start () {
        isPlaying = true;
        itemSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        if (!isPlaying)
            itemSource.Stop();
	}
}
