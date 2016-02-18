using UnityEngine;
using System.Collections;

public class CanonDesactivator3 : MonoBehaviour {

	void Start () {
	
	}
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        CanonShoot3.canonCanShoot = false;
    }
}
