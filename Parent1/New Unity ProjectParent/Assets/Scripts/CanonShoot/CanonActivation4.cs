using UnityEngine;
using System.Collections;

public class CanonActivation4 : MonoBehaviour {

	void Start () {
	
	}
	
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        CanonShoot4.canonCanShoot = true;
    }
}
