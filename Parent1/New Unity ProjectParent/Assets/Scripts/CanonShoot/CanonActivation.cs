using UnityEngine;
using System.Collections;

public class CanonActivation : MonoBehaviour {

	void Start () {
	
	}

	void Update () {
	
	}

    void OnTriggerEnter(Collider other) {
        CanonShoot.canonCanShoot = true;
    }
}
