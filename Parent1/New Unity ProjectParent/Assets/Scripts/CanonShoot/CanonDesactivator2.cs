using UnityEngine;
using System.Collections;

public class CanonDesactivator2 : MonoBehaviour {

	void Start () {
	
	}
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        CanonShoot2.canonCanShoot = false;
    }
}
