using UnityEngine;
using System.Collections;

public class CanonDesactivator4 : MonoBehaviour {

	void Start () {
	
	}
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        CanonShoot4.canonCanShoot = false;
    }
}
