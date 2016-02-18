using UnityEngine;
using System.Collections;

public class CanonActivation3 : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        CanonShoot3.canonCanShoot = true;
    }
}
